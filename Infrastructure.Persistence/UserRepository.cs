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
}