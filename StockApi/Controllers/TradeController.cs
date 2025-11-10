using Api.Contracts;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController(ITradeService tradeService) : ControllerBase
    {
        [HttpPost("buy")]
        public async Task<ActionResult<TradeStockResponseContract>> BuyStock([FromBody]TradeStockRequestContract tradeStockRequestContract)
        {
            try
            {
                var tradedStock = await tradeService.BuyStock(tradeStockRequestContract);
                return Ok(tradedStock);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("sell")]
        public async Task<ActionResult<TradeStockResponseContract>> SellStock([FromBody]TradeStockRequestContract tradeStockRequestContract)
        {
            try
            {
                var tradedStock = await tradeService.SellStock(tradeStockRequestContract);
                return Ok(tradedStock);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
