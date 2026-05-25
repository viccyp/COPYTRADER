using COPYTRADER.Models;
using COPYTRADER.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COPYTRADER.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinnhubController : ControllerBase
    {
        private FinnhubService _finnhubService;

        public FinnhubController(FinnhubService finnhubService)
        {
            _finnhubService = finnhubService;
        }

        [HttpGet("apple")]
        public async Task<IActionResult> GetApple()
        {
            var quote = await _finnhubService.GetQuoteAsync("AAPL");
            return Ok(quote);
        }
    }
}
