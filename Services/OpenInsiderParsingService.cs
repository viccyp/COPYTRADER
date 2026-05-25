using AngleSharp;
using COPYTRADER.Models;
namespace COPYTRADER.Services

{
    public class OpenInsiderParserService
    {
        private readonly HttpClient _httpClient;

        public OpenInsiderParserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Trade>> GetLatestTradesAsync()
        {
            var trades = new List<Trade>();

            var html = await _httpClient.GetStringAsync(
                "http://openinsider.com/latest-insider-trading"
            );

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync(req => req.Content(html));

            var rows = document.QuerySelectorAll("table.tinytable tbody tr");

            foreach (var row in rows)
            {
                var cells = row.QuerySelectorAll("td");

                if (cells.Length < 13)
                    continue;

                try
                {
                    var trade = new Trade
                    {
                        FilingDate = DateTime.Parse(
                            cells[1].TextContent.Trim()
                        ),

                        TradeDate = DateTime.Parse(
                            cells[2].TextContent.Trim()
                        ),

                        Ticker = cells[3].TextContent.Trim(),

                        CompanyName = cells[4].TextContent.Trim(),

                        InsiderName = cells[5].TextContent.Trim(),

                        InsiderTitle = cells[6].TextContent.Trim(),

                        TradeType = cells[7].TextContent.Trim(),

                        Price = ParseDecimal(
                            cells[8].TextContent
                        ),

                        Qty = ParseLong(
                            cells[9].TextContent
                        ),

                        Owned = ParseLong(
                            cells[10].TextContent
                        ),

                        OwnershipChangePercent = ParsePercent(
                            cells[11].TextContent
                        ),

                        TradeValue = ParseDecimal(
                            cells[12].TextContent
                        )
                    };

                    trades.Add(trade);
                }
                catch
                {
                    // log later
                }
            }

            return trades;
        }

        private decimal ParseDecimal(string value)
        {
            value = value
                .Replace("$", "")
                .Replace(",", "")
                .Replace("+", "")
                .Trim();

            return decimal.TryParse(value, out var result)
                ? result
                : 0;
        }

        private long ParseLong(string value)
        {
            value = value
                .Replace(",", "")
                .Replace("+", "")
                .Trim();

            return long.TryParse(value, out var result)
                ? result
                : 0;
        }

        private decimal ParsePercent(string value)
        {
            value = value
                .Replace("%", "")
                .Replace("+", "")
                .Trim();

            return decimal.TryParse(value, out var result)
                ? result
                : 0;
        }
    }
}