using System;
using System.Net.Http.Json;
using TradeApi.Contracts;
using TradeApi.Repositories;
using TradeApi.Repositories.Interfaces;
using TradeApi.Repositories.Models;
using TradeApi.Services.Interfaces;

namespace TradeApi.Services;

public class TradeService(ITradeRepository tradeRepository, IBalanceRepository balanceRepository, HttpClient httpClient) : ITradeService
{
    public async Task<TradeResponseContract> BuyStock(TradeRequestContract request)
    {
        // handle balance changes
        var price = await GetPriceAsync(request.Symbol);
        decimal newBalance = await SubstractBalanceAsync(request, price);
        // handle userStock changes
        var userStock = await UpdateBuyUserStockAsync(request);

        return new TradeResponseContract
        {
            UserStocksId = userStock.UserStocksId,
            UserId = request.UserId,
            Symbol = request.Symbol,
            Price = price,
            Quantity = userStock.Quantity,
            Balance = newBalance
        };
    }

    public async Task<TradeResponseContract> SellStock(TradeRequestContract request)
    {
        var price = await GetPriceAsync(request.Symbol);
        var totalPrice = price * request.Quantity;
        // get user stocks
        var userStock = await UpdateSellUserStockAsync(request);
        // get user balance
        decimal newBalance = await AddBalanceAsync(request, price);
        // return response
        return new TradeResponseContract
        {
            UserStocksId = userStock.UserStocksId,
            UserId = request.UserId,
            Symbol = request.Symbol,
            Quantity = userStock.Quantity,
            Balance = newBalance
        };
    }

    private async Task<UserStock> UpdateBuyUserStockAsync(TradeRequestContract request)
    {
        // get user stocks
        var userStock = await GetUserStockAsync(request.UserId, request.Symbol);
        // user doesnt own stock
        if (userStock == null)
        {
            var userStockToCreate = new UserStock { UserId = request.UserId, Symbol = request.Symbol, Quantity = request.Quantity };
            userStock = await tradeRepository.CreateAsync(userStockToCreate);
        }
        else
        {
            userStock.Quantity += request.Quantity;
            userStock = await tradeRepository.UpdateAsync(userStock);
        }
        return userStock;
    }

    private async Task<UserStock> UpdateSellUserStockAsync(TradeRequestContract request)
    {
        // get user stocks
        var userStock = await GetUserStockAsync(request.UserId, request.Symbol);
        // user doesnt own or not enough
        if (userStock == null || userStock.Quantity < request.Quantity) throw new Exception("Insufficient stocks to sell");
        // substract quantity
        userStock.Quantity -= request.Quantity;
        // check if zero left => remove from db
        if (userStock.Quantity == 0)
        {
            await tradeRepository.DeleteAsync(userStock.UserStocksId);
        }
        else
        {
            // update db
            await tradeRepository.UpdateAsync(userStock);
        }
        return userStock;
    }

    private async Task<decimal> SubstractBalanceAsync(TradeRequestContract request, decimal price)
    {
        // get total price
        var totalPrice = price * request.Quantity;
        // get user balance / create if not exist
        var userBalance = await balanceRepository.GetBalanceAsync(request.UserId);
        if (userBalance == null) userBalance = await balanceRepository.InitUserBalanceAsync(request.UserId);
        // check balance
        if (userBalance.Balance < totalPrice) throw new Exception("Insufficient balance");
        // substract balance
        userBalance.Balance -= totalPrice;
        // update balance to db
        await balanceRepository.UpdateBalanceAsync(userBalance);
        // return new balance
        return userBalance.Balance;
    }

    private async Task<decimal> AddBalanceAsync(TradeRequestContract request, decimal price)
    {
        // get total price
        var totalPrice = price * request.Quantity;
        // get user balance / create if not exist
        var userBalance = await balanceRepository.GetBalanceAsync(request.UserId);
        if (userBalance == null) userBalance = await balanceRepository.InitUserBalanceAsync(request.UserId);
        // add balance
        userBalance.Balance += totalPrice;
        await balanceRepository.UpdateBalanceAsync(userBalance);
        return userBalance.Balance;
    }

    private async Task<decimal> GetPriceAsync(string symbol)
    {
        var url = $"http://localhost:5234/api/stocks/{symbol}";
        var response = await httpClient.GetFromJsonAsync<StockPriceContract>(url);
        if (response == null) throw new Exception("Stock not found");
        return Convert.ToDecimal(response.Price);
    }

    private async Task<UserStock?> GetUserStockAsync(string userId, string symbol)
    {
        var userStocks = await tradeRepository.GetByUserIdAsync(userId);
        return userStocks.FirstOrDefault(s => s.Symbol == symbol);
    }
}
