using System;
using Storage.Contracts;
using Storage.Repositories.Interfaces;
using Microsoft.Azure.Cosmos;
using Storage.Repositories.Exceptions;
using Microsoft.Azure.Cosmos.Linq;
namespace Storage.Repositories;

public class StockPriceRepository(CosmosClient cosmosClient) : IStockPriceRepository
{
    public async Task<StockPriceStorageContract> CreateStockPriceAsync(StockPriceStorageContract stockPriceStorageContract)
    {
        try
        {
            var itemResponse = await GetCosmosContainer().CreateItemAsync(
                item: stockPriceStorageContract,
                partitionKey: new PartitionKey(stockPriceStorageContract.id)
            );
            return itemResponse.Resource;
        }
        catch (Exception ex)
        {
            throw new CosmosDbException("Error creating stock price in Cosmos DB", ex);
        }
    }

    public async Task<IEnumerable<StockPriceStorageContract>> GetAllStockPricesAsync()
    {
        var response = GetCosmosContainer().GetItemLinqQueryable<StockPriceStorageContract>();
        var iterator = response.ToFeedIterator();
        var result = new List<StockPriceStorageContract>();
        while (iterator.HasMoreResults)
        {
            var current = await iterator.ReadNextAsync();
            result.AddRange(current.Resource);
        }
        return result;
    }

    public async Task<StockPriceStorageContract> GetStockPriceByIdAsync(string id)
    {
        try
        {
            var item = await GetCosmosContainer().ReadItemAsync<StockPriceStorageContract>(
            id: id,
            partitionKey: new PartitionKey(id)
        );
            if (item == null) { throw new CosmosDbException("Stock price not found in DB"); }
            return item.Resource;
        }
        catch (Exception ex)
        {
            throw new CosmosDbException("Error retrieving stock price from Cosmos DB", ex);
        }


    }

    public async Task<StockPriceStorageContract> UpdateStockPriceAsync(StockPriceStorageContract stockPriceStorageContract)
    {
        var itemReponse = await GetCosmosContainer().ReplaceItemAsync(
            item: stockPriceStorageContract,
            id: stockPriceStorageContract.id,
            partitionKey: new PartitionKey(stockPriceStorageContract.id)
        );
        return itemReponse.Resource;
    }

    private Container GetCosmosContainer()
    {
        var database = cosmosClient.GetDatabase("stockDb");
        var container = database.GetContainer("stockprices");
        if (container == null) throw new Exception("Could not obtain cosmos container.");
        return container;
    }
}
