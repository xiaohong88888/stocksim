using System;
using System.Text.Json;
using Infrastructure.ExternalApi.Exceptions;
using Infrastructure.ExternalApi.ExternalModel;
using Infrastructure.ExternalApi.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.ExternalApi;

public class FMPDataProvider(IConfiguration config) : IFMPDataProvider
{
    public async Task<double> GetPrice(string ticker, string exchange)
    {
        string apiKey = config["ApiKeys:FMPKey"];
        string url = $"https://financialmodelingprep.com/stable/quote-short?symbol={ticker}&apikey={apiKey}";
        using var client = new HttpClient();
        var json = await client.GetStringAsync(url);
        var quotes = JsonSerializer.Deserialize<List<ExternalStock>>(json);
        return quotes?.First().price ?? throw new PriceNotFoundException(ticker);
    }
}