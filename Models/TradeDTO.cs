namespace COPYTRADER.Models
{
    public class TradeDTO
    {
        public string Ticker { get; set; }

        public string CompanyName { get; set; }

        public string InsiderName { get; set; }

        public string InsiderTitle { get; set; }

        public DateTime TradeDate { get; set; }

        public string TradeType { get; set; }

        public decimal SharePrice { get; set; }

        public long SharesTraded { get; set; }

        public decimal TradeValue { get; set; }
    }
}