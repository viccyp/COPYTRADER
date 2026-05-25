using System.Text.Json;
using COPYTRADER.Models;
namespace COPYTRADER.Services;

public class TradeService
{
    private readonly IWebHostEnvironment _env;

    public TradeService(IWebHostEnvironment env)
    {
        _env = env;
    }


    public async Task<List<TradeDTO>> GetAllTradesAsync()
    {
        var json = await File.ReadAllTextAsync("Data/mock-insider-buys.json");

        var trades = JsonSerializer.Deserialize<List<Trade>>(json);

        return trades.Select(t => new TradeDTO
        {
            Ticker = t.Ticker,
            CompanyName = t.CompanyName,
            InsiderName = t.InsiderName,
            InsiderTitle = t.InsiderTitle,
            TradeDate = t.TradeDate,
            TradeType = t.TradeType,
            SharePrice = t.Price,
            SharesTraded = t.Qty,
            TradeValue = t.TradeValue
        }).ToList();
    }
}
