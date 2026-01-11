using System;
using System.ComponentModel.Design;
using Dapper;
using Microsoft.Data.SqlClient;
using TradeApi.Repositories.Interfaces;
using TradeApi.Repositories.Models;

namespace TradeApi.Repositories;

public class TradeRepository(SqlConnection connection) : ITradeRepository
{
    public async Task<UserStock> CreateAsync(UserStock userStock)
    {
        string query = "INSERT INTO UserStocks(UserId, Symbol, Quantity) VALUES(@UserId, @Symbol, @Quantity)";
        var id = await connection.ExecuteScalarAsync<int>(query, userStock);
        return await GetByIdAsync(id) ?? throw new Exception($"UserStock ({userStock.UserId}, {userStock.Symbol}, {userStock.Quantity}) could not be created");
    }

    public async Task DeleteAsync(int id)
    {
        string query = "DELETE FROM UserStocks WHERE ID = @Id";
        await connection.ExecuteAsync(query, new { Id = id });
    }

    public async Task<IEnumerable<UserStock>> GetAllAsync()
    {
        string query = "SELECT * FROM UserStocks";
        var result = await connection.QueryAsync<UserStock>(query);
        return result.ToList();
    }

    public async Task<UserStock?> GetByIdAsync(int id)
    {
        string query = "SELECT * FROM UserStocks WHERE UserStocksId = @Id";
        var userStock = await connection.QuerySingleOrDefaultAsync<UserStock>(query, new { Id = id });
        return userStock;
    }

    public async Task<UserStock> UpdateAsync(UserStock userStock)
    {
        string query = "UPDATE UserStocks SET UserId = @UserId, Symbol = @Symbol, Quantity = @Quantity WHERE UserStocksId = @UserStocksId";
        await connection.ExecuteAsync(query, userStock);
        return await GetByIdAsync(userStock.UserStocksId) ?? throw new Exception($"UserStock ({userStock.UserId}, {userStock.Symbol}, {userStock.Quantity}) could not be updated");
    }

    public async Task<IEnumerable<UserStock>> GetByUserIdAsync(string userId)
    {
        string query = "SELECT * FROM UserStocks WHERE UserId = @UserId";
        var result = await connection.QueryAsync<UserStock>(query, new { UserId = userId });
        return result.ToList();
    }
}
