
using System.Text.Json.Serialization;
namespace COPYTRADER.Models;

public class Trade
{
    [JsonPropertyName("filingDate")]
    public DateTime FilingDate { get; set; }

    [JsonPropertyName("tradeDate")]
    public DateTime TradeDate { get; set; }

    [JsonPropertyName("ticker")]
    public string Ticker { get; set; }

    [JsonPropertyName("companyName")]
    public string CompanyName { get; set; }

    [JsonPropertyName("insiderName")]
    public string InsiderName { get; set; }

    [JsonPropertyName("title")]
    public string InsiderTitle { get; set; }

    [JsonPropertyName("tradeType")]
    public string TradeType { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("qty")]
    public long Qty { get; set; }

    [JsonPropertyName("owned")]
    public long Owned { get; set; }

    [JsonPropertyName("ownershipChangePercent")]
    public decimal OwnershipChangePercent { get; set; }

    [JsonPropertyName("tradeValue")]
    public decimal TradeValue { get; set; }
}

