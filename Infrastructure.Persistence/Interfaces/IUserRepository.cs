using System;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence.Interfaces;

public interface IUserRepository
{
    public IEnumerable<User> GetAllUsers();
    public User GetUser(int id);
    public User CreateUser(User user);
}
