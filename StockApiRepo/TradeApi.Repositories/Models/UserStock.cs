using System;

namespace TradeApi.Repositories.Models;

public class UserStock
{
    public int UserStocksId { get; set; }
    public string UserId { get; set; } = null!;
    public string Symbol { get; set; } = null!;
    public int Quantity { get; set; }
}
// CREATE TABLE dbo.UserStocks (
//     UserStocksId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
//     UserId NVARCHAR(100) NOT NULL,
//     Symbol NVARCHAR(20) NOT NULL,
//     Quantity INT NOT NULL
// );
