using System;

namespace Storage.Contracts;

public class StockPriceStorageContract
{
    public string id { get; set; } = null!;
    public double price { get; set; }
    public DateTime updatedAt { get; set; }
}
