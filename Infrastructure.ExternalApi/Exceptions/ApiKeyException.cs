using System;

namespace Infrastructure.ExternalApi.Exceptions;

public class ApiKeyException : Exception
{
    public ApiKeyException() : base()
    {

    }
    public ApiKeyException(string ticker) : base($"price not found for {ticker}")
    {

    }
}