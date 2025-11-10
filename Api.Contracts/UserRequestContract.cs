using System;

namespace Api.Contracts;

public class UserRequestContract
{
    public required string Email { get; set; }
    public required string Name { get; set; }
}
