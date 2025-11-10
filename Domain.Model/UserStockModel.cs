using System;

namespace Domain.Model;

public class UserStockModel
{
    public int? Id { get; set; }
    public int UserId { get; set; }
    public int StockId { get; set; }
    public int Quantity { get; set; }
}
