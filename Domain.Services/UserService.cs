using System;
using Api.Contracts;
using Domain.Services.Interfaces;
using Domain.Services.Mapping;
using Infrastructure.Persistence.Interfaces;

namespace Domain.Services;

public class UserService(IUserRepository userRepository) : IUserService
{

    public IEnumerable<UserResponseContract> GetAllUsers()
    {
        var users = userRepository.GetAllUsers();
        return users.Select(user => user.EntityAsUserModel().UserModelAsResponseContract());
    }

    public UserResponseContract GetUserById(int id)
    {
        var user = userRepository.GetUser(id);
        return user.EntityAsUserModel().UserModelAsResponseContract();
    }

    public UserResponseContract CreateUser(UserRequestContract userRequestContract)
    {
        var createdUser = userRepository.CreateUser(userRequestContract.UserRequestContractAsModel().UserModelAsEntity());
        return createdUser.EntityAsUserModel().UserModelAsResponseContract();
    }
}
