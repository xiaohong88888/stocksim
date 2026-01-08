using System;

namespace Services.Models;

public class StockPriceModel
{
    public string? Id { get; set; }
    public string Naam { get; set; } = null!;
    public double Price { get; set; }

    public DateTime UpdatedAt { get; set; }
}
