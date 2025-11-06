using System;
using Api.Contracts;
using Domain.Services.Interfaces;
using Domain.Services.Mapping;
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Scraper.Interfaces;

namespace Domain.Services;

public class StockService(IStockScraper stockScraper, IStockRepository stockRepository) : IStockService
{
    public StockResponseContract CreateStock(StockRequestContract stockRequestContract)
    {
        var stockToCreate = stockRequestContract.StockRequestContractAsModel().StockModelAsEntity();
        Stock stock = stockRepository.CreateStock(stockToCreate);
        return stock.EntityAsStockModel().StockModelAsResponseContract();
    }

    public IEnumerable<StockResponseContract> GetAllStock()
    {
        return stockRepository.GetAllStock().Select(s=>s.EntityAsStockModel().StockModelAsResponseContract());
    }

    public StockResponseContract GetStock(int id)
    {
        return stockRepository.GetStock(id).EntityAsStockModel().StockModelAsResponseContract();
    }
}
