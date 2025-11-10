using System;
using System.Runtime.CompilerServices;
using Api.Contracts;
using Domain.Services.Interfaces;
using Domain.Services.Mapping;
using Infrastructure.ExternalApi.Interfaces;
using Infrastructure.Persistence.Interfaces;

namespace Domain.Services;

public class TradeService(IUserStockRepository userStockRepository,IStockRepository stockRepository, IUserRepository userRepository, IFMPDataProvider dataProvider) : ITradeService
{
    public async Task<TradeStockResponseContract> BuyStock(TradeStockRequestContract tradeStockRequestContract)
    {
        //substract balance first then buy
        var stock = stockRepository.GetStock(tradeStockRequestContract.StockId);
        var price = await dataProvider.GetPrice(stock.Ticker);
        userRepository.SubstractBalance(tradeStockRequestContract.UserId, (decimal)price * tradeStockRequestContract.Quantity);

        var userstock = userStockRepository.BuyStock(tradeStockRequestContract.UserStockContractAsModel().UserStockModelAsEntity());
        return userstock.EntityAsUserStockModel().UserStockModelAsResponseContract();
    }
    public async Task<TradeStockResponseContract> SellStock(TradeStockRequestContract tradeStockRequestContract)
    {
        //sell first then add to balance
        var userstock = userStockRepository.SellStock(tradeStockRequestContract.UserStockContractAsModel().UserStockModelAsEntity());

        var stock = stockRepository.GetStock(tradeStockRequestContract.StockId);
        var price = await dataProvider.GetPrice(stock.Ticker);
        userRepository.AddBalance(tradeStockRequestContract.UserId, (decimal)price * tradeStockRequestContract.Quantity);

        return userstock.EntityAsUserStockModel().UserStockModelAsResponseContract();
    }
}
