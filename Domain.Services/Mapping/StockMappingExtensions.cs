using System;
using Api.Contracts;
using Domain.Model;
using Infrastructure.Persistence.Entities;

namespace Domain.Services.Mapping;

public static class StockMappingExtensions
{
    public static StockModel StockRequestContractAsModel(this StockRequestContract stockRequestContract)
    {
        return new StockModel
        {
            Name = stockRequestContract.Name,
            Exchange = stockRequestContract.Exchange,
            TickerSymbol = stockRequestContract.TickerSymbol,
        };
    }

    public static Stock StockModelAsEntity(this StockModel stockModel)
    {
        return new Stock
        {
            Id = stockModel.Id ?? 0,
            Name = stockModel.Name ?? throw new ArgumentNullException("Name is null"),
            Exchange = stockModel.Exchange ?? "",
            Ticker = stockModel.TickerSymbol ?? throw new ArgumentNullException("Ticker is null"),
        };
    }

    public static StockModel EntityAsStockModel(this Stock stock)
    {
        return new StockModel
        {
            Id = stock.Id,
            Name = stock.Name,
            Exchange = stock.Exchange,
            TickerSymbol = stock.Ticker,
        };
    }

    public static StockResponseContract StockModelAsResponseContract(this StockModel stock)
    {
        return new StockResponseContract
        {
            Id = stock.Id ?? 0,
            Exchange = stock.Exchange ?? "",
            TickerSymbol = stock.TickerSymbol ?? throw new ArgumentNullException("Ticker is null"),
            Name = stock.Name ?? throw new ArgumentNullException("Name is null"),
        };
    }
}

