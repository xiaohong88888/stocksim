using System;

namespace TradeApi.Contracts;

public class StockPriceContract
{
    public string Naam { get; set; } = null!;
    public double Price { get; set; }
}

