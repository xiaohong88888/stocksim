namespace Api.Contracts;

public class TradeStockRequestContract
{
    public int UserId { get; set; }
    public int StockId { get; set; }
    public int Quantity { get; set; }
}
