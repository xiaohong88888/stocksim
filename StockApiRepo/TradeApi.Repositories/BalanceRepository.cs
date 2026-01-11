using System;
using Dapper;
using Microsoft.Data.SqlClient;
using TradeApi.Repositories.Interfaces;
using TradeApi.Repositories.Models;

namespace TradeApi.Repositories;

public class BalanceRepository(SqlConnection connection) : IBalanceRepository
{
    public async Task<UserBalance?> GetBalanceAsync(string userId)
    {
        string sql = "SELECT * FROM UserBalances WHERE UserId = @UserId";
        var userBalance = await connection.QuerySingleOrDefaultAsync<UserBalance>(sql, new { UserId = userId });
        return userBalance;
    }

    public async Task<UserBalance> InitUserBalanceAsync(string userId)
    {
        UserBalance userBalance = new UserBalance
        {
            UserId = userId,
            Balance = 1000.0m
        };
        string sql = "INSERT INTO UserBalances (UserId, Balance) VALUES (@UserId, @Balance)";
        var id = await connection.ExecuteScalarAsync<int>(sql, userBalance);
        return await GetBalanceAsync(userId) ?? throw new Exception($"UserBalance for UserId {userId} could not be created");
    }

    public async Task<UserBalance> UpdateBalanceAsync(UserBalance userBalance)
    {
        string sql = "UPDATE UserBalances SET Balance = @Balance WHERE UserId = @UserId";
        await connection.ExecuteAsync(sql, userBalance);
        return await GetBalanceAsync(userBalance.UserId) ?? throw new Exception($"UserBalance for UserId {userBalance.UserId} could not be updated");
    }
}
