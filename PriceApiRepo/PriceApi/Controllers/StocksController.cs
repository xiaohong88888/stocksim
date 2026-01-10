using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApi.Contracts;
using Services.Interfaces;
using Storage.Repositories.Exceptions;

namespace PriceApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class StocksController(IStockPriceService stockPriceService) : ControllerBase
    {
        [Authorize(Policy = "PriceReadPolicy")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockPriceById(string id)
        {
            try
            {
                var stocks = await stockPriceService.GetStockPriceByIdAsync(id);
                return Ok(stocks);
            }
            catch (CosmosDbException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Authorize(Policy = "PriceWritePolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateStockPrice([FromBody] StockPriceRequestContract request)
        {
            try
            {
                var result = await stockPriceService.CreateStockPriceAsync(request);
                return Ok(result);
            }
            catch (CosmosDbException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Authorize(Policy = "PriceReadPolicy")]
        public async Task<IActionResult> GetAllStockPrices()
        {
            var stocks = await stockPriceService.GetAllStockPricesAsync();
            return Ok(stocks);
        }
    }
}
