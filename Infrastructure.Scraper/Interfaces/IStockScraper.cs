using System;

namespace Infrastructure.Scraper.Interfaces;

public interface IStockScraper
{
    public Task<double> GetPrice(string ticker, string exchange);
}
