using System;

namespace Api.Contracts;

public class StockResponseContract
{
    public required int Id { get; set; }
    public required string Exchange { get; set; }
    public required string TickerSymbol { get; set; }
    public required string Name { get; set; }
    public double Price { get; set; }
}

