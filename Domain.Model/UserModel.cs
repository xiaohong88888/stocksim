using System;

namespace Domain.Model;

public class UserModel
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public decimal? Balance { get; set; }
}