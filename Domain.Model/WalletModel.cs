using System;

namespace Domain.Model;

public class WalletModel
{
    Dictionary<StockModel, int>? Stocks { get; set; }
}
