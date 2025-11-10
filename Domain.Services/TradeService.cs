using System;
using Api.Contracts;
using Domain.Services.Interfaces;
using Domain.Services.Mapping;
using Infrastructure.Persistence.Interfaces;

namespace Domain.Services;

public class TradeService(IUserStockRepository userStockRepository) : ITradeService
{
    //todo substract balance from user
    public TradeStockResponseContract BuyStock(TradeStockRequestContract tradeStockRequestContract)
    {
        var userstock = userStockRepository.BuyStock(tradeStockRequestContract.UserStockContractAsModel().UserStockModelAsEntity());
        return userstock.EntityAsUserStockModel().UserStockModelAsResponseContract();
    }
    //todo add balance to user
    public TradeStockResponseContract SellStock(TradeStockRequestContract tradeStockRequestContract)
    {
        var userstock = userStockRepository.SellStock(tradeStockRequestContract.UserStockContractAsModel().UserStockModelAsEntity());
        return userstock.EntityAsUserStockModel().UserStockModelAsResponseContract();
    }
}
