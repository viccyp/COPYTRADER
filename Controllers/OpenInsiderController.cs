using AngleSharp;
using COPYTRADER.Models;
using COPYTRADER.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace COPYTRADER.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenInsiderController : ControllerBase
    {
        private readonly OpenInsiderParserService _parserService;

        public OpenInsiderController (OpenInsiderParserService parserService)
        {
            _parserService = parserService;
        }

        [HttpGet("insider")]
        public async Task<IActionResult> GetInsiderTrades()
        {
            var trades = await _parserService.GetLatestTradesAsync();
            return Ok(trades);
        }
    }
}
