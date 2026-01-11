using System;
using Microsoft.AspNetCore.Authorization;

namespace TradeApi;

public class StocksimAuthRequirement : IAuthorizationRequirement
{
    public string Claim { get; set; }
    public string Role { get; set; }
    public StocksimAuthRequirement(string claim, string role)
    {
        Claim = claim;
        Role = role;
    }
}