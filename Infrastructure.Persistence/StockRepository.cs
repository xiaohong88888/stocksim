using System;
using System.Data.Common;
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Interfaces;
namespace Infrastructure.Persistence;

public class StockRepository(StocksimContext dbContext) : IStockRepository
{
    public Stock CreateStock(Stock stock)
    {
        dbContext.Stocks.Add(stock);
        dbContext.SaveChanges();
        return stock;
    }

    public Stock GetStock(int id)
    {
        return dbContext.Stocks.Find(id)??throw new KeyNotFoundException();
    }

    public IEnumerable<Stock> GetAllStock()
    {
        return dbContext.Stocks;
    }
}