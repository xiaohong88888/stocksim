using System;
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence;

public class UserStockRepository(StocksimContext dbContext) : IUserStockRepository
{
    public Userstock BuyStock(Userstock userstock)
    {
        Userstock? us = GetUserstock(userstock.UserId, userstock.StockId);
        if (us != null)
        {
            us.Quantity += userstock.Quantity;
        }
        else
        {
            us = userstock;
            dbContext.Userstocks.Add(us);
        }
        dbContext.SaveChanges();
        return us;
    }

    public Userstock SellStock(Userstock userstock)
    {
        Userstock? us = GetUserstock(userstock.UserId, userstock.StockId);
        if (us == null)
        {
            throw new Exception("stock not found for user");
        }
        else if (us.Quantity < userstock.Quantity)
        {
            throw new Exception("not enough stock to sell");
        }
        us.Quantity -= userstock.Quantity;
        if (us.Quantity == userstock.Quantity)
        {
            dbContext.Userstocks.Remove(us);
        }
        dbContext.SaveChanges();
        return us;
    }

    public IEnumerable<Userstock> GetAllUserStocks(int userId)
    {
        return dbContext.Userstocks.Where(us => us.UserId == userId);
    }

    private Userstock? GetUserstock(int userId, int stockId)
    {
        return dbContext.Userstocks
            .Where(us => us.UserId == userId && us.StockId == stockId)
            .FirstOrDefault();
    }
}