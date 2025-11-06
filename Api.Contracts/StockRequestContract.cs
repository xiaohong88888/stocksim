using System;

namespace Api.Contracts;

public class StockRequestContract
{
    public required string Exchange { get; set; }
    public required string TickerSymbol { get; set; }
    public required string Name { get; set; }
}

