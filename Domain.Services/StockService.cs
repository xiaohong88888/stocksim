using System;
using System.Threading.Tasks;
using Api.Contracts;
using Domain.Services.Interfaces;
using Domain.Services.Mapping;
using Infrastructure.ExternalApi.Interfaces;
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Domain.Services;

public class StockService(IFMPDataProvider dataProvider, IStockRepository stockRepository) : IStockService
{
    public StockResponseContract CreateStock(StockRequestContract stockRequestContract)
    {
        var stockToCreate = stockRequestContract.StockRequestContractAsModel().StockModelAsEntity();
        Stock stock = stockRepository.CreateStock(stockToCreate);
        return stock.EntityAsStockModel().StockModelAsResponseContract();
    }

    public IEnumerable<StockResponseContract> GetAllStocks()
    {
        return stockRepository.GetAllStocks().Select(s=>s.EntityAsStockModel().StockModelAsResponseContract());
    }

    public async Task<StockResponseContract> GetStock(int id)
    {
        var stock = stockRepository.GetStock(id).EntityAsStockModel().StockModelAsResponseContract();
        stock.Price = await dataProvider.GetPrice(stock.TickerSymbol);
        return stock;
    }
}
