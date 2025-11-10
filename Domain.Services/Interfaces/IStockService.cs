using System;
using Api.Contracts;
namespace Domain.Services.Interfaces;

public interface IStockService
{
    public StockResponseContract CreateStock(StockRequestContract stockRequestContract);
    public IEnumerable<StockResponseContract> GetAllStocks();
    public Task<StockResponseContract> GetStock(int id);

}