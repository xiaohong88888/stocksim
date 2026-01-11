using System;

namespace TradeApi.Contracts;

public class TradeResponseContract
{
    public required int UserStocksId { get; set; }
    public required string UserId { get; set; }
    public required string Symbol { get; set; }
    public required int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Balance { get; set; }
}
