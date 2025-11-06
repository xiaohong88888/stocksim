using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Balance { get; set; }

    public virtual ICollection<Userstock> Userstocks { get; set; } = new List<Userstock>();
}
