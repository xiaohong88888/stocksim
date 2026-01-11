using System;

namespace TradeApi.Contracts;

public class TradeRequestContract
{
    public required string UserId { get; set; }
    public required string Symbol { get; set; }
    public required int Quantity { get; set; }
}