namespace COPYTRADER.Models;
public class FinnhubQuoteResponse
{
    public decimal c { get; set; } // current price

    public decimal d { get; set; } // change

    public decimal dp { get; set; } // percent change

    public decimal h { get; set; } // high

    public decimal l { get; set; } // low

    public decimal o { get; set; } // open

    public decimal pc { get; set; } // previous close
}