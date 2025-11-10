using System;

namespace Api.Contracts;

public class TradeStockResponseContract
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int StockId { get; set; }
    public int Quantity { get; set; }
}