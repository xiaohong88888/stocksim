using System;

namespace Infrastructure.ExternalApi.Exceptions;

public class PriceNotFoundException : Exception
{
    public PriceNotFoundException() : base()
    {

    }
    public PriceNotFoundException(string ticker): base($"price not found for {ticker}")
    {
        
    }
}
