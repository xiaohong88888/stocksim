using System;

namespace DataProviders.Exceptions;

public class PriceNotFoundException : Exception
{
    public PriceNotFoundException() : base()
    {

    }
    public PriceNotFoundException(string id) : base($"price not found for {id}")
    {

    }
}