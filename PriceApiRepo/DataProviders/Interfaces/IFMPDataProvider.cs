using System;

namespace DataProviders.Interfaces;

public interface IFMPDataProvider
{
    public Task<double> GetPriceAsync(string id);
}
