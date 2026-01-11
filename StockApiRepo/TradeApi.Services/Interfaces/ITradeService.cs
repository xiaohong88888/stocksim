using System;
using TradeApi.Contracts;

namespace TradeApi.Services.Interfaces;

public interface ITradeService
{
    public Task<TradeResponseContract> BuyStock(TradeRequestContract request);
    public Task<TradeResponseContract> SellStock(TradeRequestContract request);
}
