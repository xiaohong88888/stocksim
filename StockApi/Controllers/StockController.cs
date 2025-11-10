using Api.Contracts;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController(IStockService service) : ControllerBase
    {
        [HttpPost]
        public ActionResult<StockResponseContract> CreateStock([FromBody] StockRequestContract stockRequestContract)
        {
            try
            {
                var createdStock = service.CreateStock(stockRequestContract);
                return CreatedAtAction(nameof(GetStock), new { id = createdStock.Id }, createdStock);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockResponseContract>> GetStock([FromRoute] int id)
        {
            try
            {
                var stock = await service.GetStock(id);
                return Ok(stock);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<StockResponseContract>> GetAllStocks()
        {
            var result = service.GetAllStocks();
            return Ok(result);
        }
    }
}
