using System;

namespace Storage.Repositories.Exceptions;

public class CosmosDbException : Exception
{
    public CosmosDbException() : base()
    {

    }

    public CosmosDbException(string message) : base(message)
    {

    }

    public CosmosDbException(string message, Exception innerException) : base(message, innerException)
    {

    }
}
