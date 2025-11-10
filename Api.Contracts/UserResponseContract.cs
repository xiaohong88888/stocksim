using System;

namespace Api.Contracts;

public class UserResponseContract
{
    public required int Id { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public required decimal Balance { get; set; }
}
