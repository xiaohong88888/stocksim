using System;
using Storage.Contracts;

namespace Storage.Repositories.Interfaces;

public interface IStockPriceRepository
{
    public Task<StockPriceStorageContract> GetStockPriceByIdAsync(string id);
    public Task<StockPriceStorageContract> CreateStockPriceAsync(StockPriceStorageContract stockPriceStorageContract);
    public Task<StockPriceStorageContract> UpdateStockPriceAsync(StockPriceStorageContract stockPriceStorageContract);
    public Task<IEnumerable<StockPriceStorageContract>> GetAllStockPricesAsync();
}
