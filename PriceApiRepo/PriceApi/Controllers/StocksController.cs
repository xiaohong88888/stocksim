using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApi.Contracts;
using Services.Interfaces;

namespace PriceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController(IStockPriceService stockPriceService) : ControllerBase
    {
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockPriceById(string id)
        {
            var stocks = await stockPriceService.GetStockPriceByIdAsync(id);
            return Ok(stocks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockPrice([FromBody] StockPriceRequestContract request)
        {
            var result = await stockPriceService.CreateStockPriceAsync(request);
            return Ok(result);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllStockPrices()
        {
            var stocks = await stockPriceService.GetAllStockPricesAsync();
            return Ok(stocks);
        }
    }
}
