using System;

namespace DataProviders.Models;

public class FMPStockModel
{
    public string symbol { get; set; } = null!;
    public double price { get; set; }
}
