using System;
using System.Text.Json;
using DataProviders.Exceptions;
using DataProviders.Interfaces;
using DataProviders.Models;
using Microsoft.Extensions.Configuration;

namespace DataProviders;

public class FMPDataProvider(IConfiguration config, HttpClient httpClient) : IFMPDataProvider
{
    public async Task<double> GetPriceAsync(string id)
    {
        string apiKey = config["ApiKeys:FMPKey"] ?? throw new ApiKeyException("api key not found");
        string url = $"https://financialmodelingprep.com/stable/quote-short?symbol={id}&apikey={apiKey}";
        var json = await httpClient.GetStringAsync(url);
        var quotes = JsonSerializer.Deserialize<List<FMPStockModel>>(json);
        return quotes?.First().price ?? throw new PriceNotFoundException(id);
    }
}
