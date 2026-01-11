using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeApi.Contracts;
using TradeApi.Services.Interfaces;

namespace TradeApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TradeController(ITradeService service) : ControllerBase
    {
        [Authorize(Policy = "TradePolicy")]
        [HttpPost("buy")]
        public async Task<ActionResult<TradeResponseContract>> BuyStock([FromBody] TradeRequestContract request)
        {
            try
            {
                return Ok(await service.BuyStock(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Policy = "TradePolicy")]
        [HttpPost("sell")]
        public async Task<ActionResult<TradeResponseContract>> SellStock([FromBody] TradeRequestContract request)
        {
            return await service.SellStock(request);
        }
    }
}
