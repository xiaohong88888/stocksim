using System;
using Api.Contracts;
namespace Domain.Services.Interfaces;

public interface IStockService
{
    public StockResponseContract CreateStock(StockRequestContract stockRequestContract);
    public IEnumerable<StockResponseContract> GetAllStock();
    public Task<StockResponseContract> GetStock(int id);

}