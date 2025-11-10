using System;

namespace Infrastructure.Persistence.Exceptions;

public class StockNotFoundException : Exception
{
    public StockNotFoundException(int stockId) : base($"Stock with ID {stockId} was not found.")
    {

    }
    public StockNotFoundException(string message) : base(message)
    {

    }
}
