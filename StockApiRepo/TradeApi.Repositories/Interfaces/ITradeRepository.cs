using System;
using TradeApi.Repositories.Models;

namespace TradeApi.Repositories.Interfaces;

public interface ITradeRepository
{
    public Task<UserStock> CreateAsync(UserStock userStock);
    public Task<UserStock> UpdateAsync(UserStock userStock);
    public Task<UserStock?> GetByIdAsync(int id);
    public Task<IEnumerable<UserStock>> GetAllAsync();
    public Task DeleteAsync(int id);
    public Task<IEnumerable<UserStock>> GetByUserIdAsync(string userId);
}
