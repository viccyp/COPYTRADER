using Microsoft.AspNetCore.Mvc;
using COPYTRADER.Services;
using COPYTRADER.Models;

namespace COPYTRADER.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly TradeService _service;

        public TradeController (TradeService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<TradeDTO>>> GetAll()
        {
            var trades = await _service.GetAllTradesAsync();
            return Ok(trades);
        }
    }
}
