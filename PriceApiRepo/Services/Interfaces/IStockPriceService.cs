using System;
using PriceApi.Contracts;

namespace Services.Interfaces;

public interface IStockPriceService
{
    public Task<StockPriceResponseContract> CreateStockPriceAsync(StockPriceRequestContract stockPriceRequestContract);
    public Task<StockPriceResponseContract> GetStockPriceByIdAsync(string id);
    public Task<IEnumerable<StockPriceResponseContract>> GetAllStockPricesAsync();
}
