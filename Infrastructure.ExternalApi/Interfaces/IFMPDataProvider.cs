using System;

namespace Infrastructure.ExternalApi.Interfaces;

public interface IFMPDataProvider
{
    public Task<double> GetPrice(string ticker, string exchange);
}
