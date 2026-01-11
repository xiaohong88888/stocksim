using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeApi.Contracts;
using TradeApi.Services.Interfaces;

namespace TradeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController(ITradeService service) : ControllerBase
    {
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

        [HttpPost("sell")]
        public async Task<ActionResult<TradeResponseContract>> SellStock([FromBody] TradeRequestContract request)
        {
            return await service.SellStock(request);
        }
    }
}
