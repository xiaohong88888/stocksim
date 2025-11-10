using System;
using Api.Contracts;

namespace Domain.Services.Interfaces;

public interface ITradeService
{
    public Task<TradeStockResponseContract> BuyStock(TradeStockRequestContract tradeStockRequestContract);
    public Task<TradeStockResponseContract> SellStock(TradeStockRequestContract tradeStockRequestContract);
}
