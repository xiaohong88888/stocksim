using System;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using PriceApi.Contracts;
using Services.Models;
using Storage.Contracts;

namespace Services.Mappers;

public static class StockPriceMapper
{
    public static StockPriceModel MapToModel(StockPriceRequestContract request)
    {
        return new StockPriceModel
        {
            Id = request.Naam,
            Naam = request.Naam,
            UpdatedAt = DateTime.UtcNow,
        };
    }

    public static StockPriceStorageContract MapToStorageContract(StockPriceModel model)
    {
        return new StockPriceStorageContract
        {
            id = model.Id ?? throw new ArgumentNullException(nameof(model.Id)),
            price = model.Price,
            updatedAt = model.UpdatedAt,
        };
    }

    public static StockPriceModel MapToModel(StockPriceStorageContract storageContract)
    {
        return new StockPriceModel
        {
            Id = storageContract.id,
            Naam = storageContract.id,
            Price = storageContract.price,
            UpdatedAt = storageContract.updatedAt,
        };
    }

    public static StockPriceResponseContract MapToResponseContract(StockPriceModel model)
    {
        return new StockPriceResponseContract
        {
            Id = model.Id ?? throw new ArgumentNullException(nameof(model.Id)),
            Naam = model.Naam,
            Price = model.Price,
        };
    }
}
