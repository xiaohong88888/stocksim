using System;

namespace Domain.Model;

public class UserModel
{
    int? Id { get; set; }
    string? Name { get; set; }
    string? Email { get; set; }
    WalletModel? Wallet { get; set; }
}