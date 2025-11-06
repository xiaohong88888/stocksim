using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class Stock
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Ticker { get; set; } = null!;

    public string Exchange { get; set; } = null!;

    public virtual ICollection<Userstock> Userstocks { get; set; } = new List<Userstock>();
}
