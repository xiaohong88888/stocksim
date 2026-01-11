using System;

namespace TradeApi.Repositories.Models;

public class UserBalance
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public decimal Balance { get; set; }
}

// CREATE TABLE dbo.UserBalances (
//     UserBalancesId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
//     UserId NVARCHAR(100) NOT NULL,
//     Balance DECIMAL(18, 2) NOT NULL
// );