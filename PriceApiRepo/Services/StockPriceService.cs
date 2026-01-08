using System;
using DataProviders.Interfaces;
using PriceApi.Contracts;
using Services.Interfaces;
using Services.Mappers;
using Services.Models;
using Storage.Repositories.Interfaces;

namespace Services;

public class StockPriceService(IStockPriceRepository stockPriceRepository, IFMPDataProvider fmpDataProvider) : IStockPriceService
{
    public async Task<StockPriceResponseContract> CreateStockPriceAsync(StockPriceRequestContract stockPriceRequestContract)
    {
        var stockPriceModel = StockPriceMapper.MapToModel(stockPriceRequestContract);

        var price = await fmpDataProvider.GetPriceAsync(stockPriceModel.Naam);
        stockPriceModel.Price = price;

        var stockPriceStorageContract = StockPriceMapper.MapToStorageContract(stockPriceModel);

        var result = await stockPriceRepository.CreateStockPriceAsync(stockPriceStorageContract);
        var responseModel = StockPriceMapper.MapToModel(result);
        var responseContract = StockPriceMapper.MapToResponseContract(responseModel);
        return responseContract;
    }

    public async Task<IEnumerable<StockPriceResponseContract>> GetAllStockPricesAsync()
    {
        var storageContracts = await stockPriceRepository.GetAllStockPricesAsync();
        return storageContracts.Select(s => StockPriceMapper.MapToModel(s))
                               .Select(m => StockPriceMapper.MapToResponseContract(m));
    }

    public async Task<StockPriceResponseContract> GetStockPriceByIdAsync(string id)
    {
        var storageContract = await stockPriceRepository.GetStockPriceByIdAsync(id);
        // updatedAt > 12 hours
        if (DateTime.UtcNow - storageContract.updatedAt > TimeSpan.FromHours(12))
        {
            return await UpdateStockPriceAsync(id);
        }
        var model = StockPriceMapper.MapToModel(storageContract);
        var responseContract = StockPriceMapper.MapToResponseContract(model);
        return responseContract;
    }

    private async Task<StockPriceResponseContract> UpdateStockPriceAsync(string id)
    {
        var price = await fmpDataProvider.GetPriceAsync(id);
        var stockPriceModel = new StockPriceModel
        {
            Id = id,
            Naam = id,
            Price = price,
            UpdatedAt = DateTime.UtcNow
        };

        var stockPriceStorageContract = StockPriceMapper.MapToStorageContract(stockPriceModel);

        var result = await stockPriceRepository.UpdateStockPriceAsync(stockPriceStorageContract);
        var responseModel = StockPriceMapper.MapToModel(result);
        var responseContract = StockPriceMapper.MapToResponseContract(responseModel);
        return responseContract;
    }
}
