using System;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence.Interfaces;

public interface IUserRepository
{
    public IEnumerable<User> GetAllUsers();
    public User GetUser(int id);
    public User CreateUser(User user);
    public decimal SubstractBalance(int id, decimal amount);
    public decimal AddBalance(int id, decimal amount);
    public decimal GetBalance(int id);
}
