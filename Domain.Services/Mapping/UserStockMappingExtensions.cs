using System;
using Api.Contracts;
using Domain.Model;
using Infrastructure.Persistence.Entities;

namespace Domain.Services.Mapping;

public static class UserStockMappingExtensions
{
    public static UserStockModel UserStockContractAsModel(this TradeStockRequestContract tradeStockRequestContract)
    {
        return new UserStockModel
        {
            UserId = tradeStockRequestContract.UserId,
            StockId = tradeStockRequestContract.StockId,
            Quantity = tradeStockRequestContract.Quantity
        };
    }

    public static Userstock UserStockModelAsEntity(this UserStockModel userStockModel)
    {
        return new Userstock
        {
            Id = userStockModel.Id ?? 0,
            UserId = userStockModel.UserId,
            StockId = userStockModel.StockId,
            Quantity = userStockModel.Quantity
        };
    }

    public static UserStockModel EntityAsUserStockModel(this Userstock userstock)
    {
        return new UserStockModel
        {
            Id = userstock.Id,
            UserId = userstock.UserId,
            StockId = userstock.StockId,
            Quantity = userstock.Quantity
        };
    }

    public static TradeStockResponseContract UserStockModelAsResponseContract(this UserStockModel userStockModel)
    {
        return new TradeStockResponseContract
        {
            Id = userStockModel.Id ?? 0,
            UserId = userStockModel.UserId,
            StockId = userStockModel.StockId,
            Quantity = userStockModel.Quantity
        };
    }
}
