using System;

namespace Domain.Model;

public class StockModel
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Exchange { get; set; }
    public string? TickerSymbol { get; set; }
    public double Price { get; set; }
}
