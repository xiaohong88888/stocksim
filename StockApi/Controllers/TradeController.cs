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
        public ActionResult<TradeStockResponseContract> BuyStock([FromBody]TradeStockRequestContract tradeStockRequestContract)
        {
            var tradedStock = tradeService.BuyStock(tradeStockRequestContract);
            return Ok(tradedStock);
        }

        [HttpPost("sell")]
        public ActionResult<TradeStockResponseContract> SellStock([FromBody]TradeStockRequestContract tradeStockRequestContract)
        {
            var tradedStock = tradeService.SellStock(tradeStockRequestContract);
            return Ok(tradedStock);
        }
    }
}
