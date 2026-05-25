using COPYTRADER.Models;
using System.Net.Http.Json;
namespace COPYTRADER.Services

{
    public class FinnhubService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public FinnhubService(
            HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<FinnhubQuoteResponse?> GetQuoteAsync(
            string ticker)
        {
            var apiKey = _config["Finnhub:ApiKey"];

            var url =
                $"https://finnhub.io/api/v1/quote?symbol={ticker}&token={apiKey}";

            return await _httpClient.GetFromJsonAsync<FinnhubQuoteResponse>(url);
        }
    }
}