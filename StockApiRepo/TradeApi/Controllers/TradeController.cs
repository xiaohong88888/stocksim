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
        public async Task<TradeResponseContract> BuyStock([FromBody] TradeRequestContract request)
        {
            return await service.BuyStock(request);
        }

        [HttpPost("sell")]
        public async Task<TradeResponseContract> SellStock([FromBody] TradeRequestContract request)
        {
            return await service.SellStock(request);
        }
    }
}
