using System;

namespace DataProviders.Exceptions;

public class ApiKeyException : Exception
{
    public ApiKeyException() : base()
    {

    }
    public ApiKeyException(string id) : base($"price not found for {id}")
    {

    }
}
