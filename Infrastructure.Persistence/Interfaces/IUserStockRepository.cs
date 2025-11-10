using System;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence.Interfaces;

public interface IUserStockRepository
{
    public Userstock BuyStock(Userstock userstock);
    public Userstock SellStock(Userstock userstock);
    public IEnumerable<Userstock> GetAllUserStocks(int userId);
}
