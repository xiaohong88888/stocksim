using System;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence.Interfaces;

public interface IStockRepository
{
    public Stock CreateStock(Stock stock);
    public Stock GetStock(int id);
    public IEnumerable<Stock> GetAllStock();
}