using System;
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Exceptions;
using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence;

public class UserRepository(StocksimContext dbContext) : IUserRepository
{
    public User CreateUser(User user)
    {
        user.Balance = 1000;
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
        return user;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return dbContext.Users;
    }

    public User GetUser(int id)
    {
        return dbContext.Users.Find(id) ?? throw new UserNotFoundException(id);
    }

    public decimal GetBalance(int id)
    {
        var user = GetUser(id);
        return user.Balance;
    }
    
    public decimal AddBalance(int id, decimal amount)
    {
        var user = GetUser(id);
        user.Balance += amount;
        dbContext.SaveChanges();
        return user.Balance;
    }

    public decimal SubstractBalance(int id, decimal amount)
    {
        var user = GetUser(id);
        if (user.Balance < amount)
        {
            throw new InvalidOperationException("user balance too low");
        }
        user.Balance -= amount;
        dbContext.SaveChanges();
        return user.Balance;
    }
}