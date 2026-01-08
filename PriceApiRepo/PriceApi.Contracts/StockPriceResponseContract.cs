using System;

namespace PriceApi.Contracts;

public class StockPriceResponseContract
{
    public string Id { get; set; } = null!;
    public string Naam { get; set; } = null!;
    public double Price { get; set; }
}
