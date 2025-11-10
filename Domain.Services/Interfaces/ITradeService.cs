using System;
using Api.Contracts;

namespace Domain.Services.Interfaces;

public interface ITradeService
{
    public TradeStockResponseContract BuyStock(TradeStockRequestContract tradeStockRequestContract);
    public TradeStockResponseContract SellStock(TradeStockRequestContract tradeStockRequestContract);
}
