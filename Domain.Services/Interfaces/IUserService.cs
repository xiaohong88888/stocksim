using System;
using Api.Contracts;

namespace Domain.Services.Interfaces;

public interface IUserService
{
    public IEnumerable<UserResponseContract> GetAllUsers();
    public UserResponseContract GetUserById(int id);
    public UserResponseContract CreateUser(UserRequestContract userRequestContract);
}
