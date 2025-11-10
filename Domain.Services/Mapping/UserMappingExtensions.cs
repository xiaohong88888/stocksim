using System;
using Api.Contracts;
using Domain.Model;
using Infrastructure.Persistence.Entities;

namespace Domain.Services.Mapping;

public static class UserMappingExtensions
{

    public static UserModel UserRequestContractAsModel(this UserRequestContract userRequestContract)
    {
        return new UserModel
        {
            Name = userRequestContract.Name,
            Email = userRequestContract.Email,
        };
    }
    public static User UserModelAsEntity(this UserModel userModel)
    {
        return new User
        {
            Id = userModel.Id ?? 0,
            Name = userModel.Name ?? throw new ArgumentNullException("Name is null"),
            Email = userModel.Email ?? throw new ArgumentNullException("Email is null"),
        };
    }
    public static UserModel EntityAsUserModel(this User user)
    {
        return new UserModel
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Balance = user.Balance
        };
    }
    public static UserResponseContract UserModelAsResponseContract(this UserModel user)
    {
        return new UserResponseContract
        {
            Id = user.Id ?? 0,
            Name = user.Name ?? throw new ArgumentNullException("Name is null"),
            Email = user.Email ?? throw new ArgumentNullException("Email is null"),
            Balance = user.Balance ?? throw new ArgumentNullException("Balance is null")
        };
    }
}
