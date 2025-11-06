using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class Userstock
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int StockId { get; set; }

    public int Quantity { get; set; }

    public virtual Stock Stock { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
