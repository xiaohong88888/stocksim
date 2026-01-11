using System;
using TradeApi.Repositories.Models;

namespace TradeApi.Repositories.Interfaces;

public interface IBalanceRepository
{
    public Task<UserBalance?> GetBalanceAsync(string userId);
    public Task<UserBalance> UpdateBalanceAsync(UserBalance userBalance);
    public Task<UserBalance> InitUserBalanceAsync(string userId);
}
