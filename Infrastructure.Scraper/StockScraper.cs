using System;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading.Tasks;
using Infrastructure.Scraper.Interfaces;
namespace Infrastructure.Scraper;

public class StockScraper:IStockScraper
{
    public async Task<double> GetPrice(string ticker, string exchange)
    {
        string symbol = ticker + ":" + exchange;
        string url = $"https://www.google.com/finance/quote/{symbol}";
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            string html = await client.GetStringAsync(url);
            var match = Regex.Match(html, @"<div class=""YMlKec fxKbKc"">.&nbsp;([\d,\.]+)<\/div>");
            if (!match.Success)
                throw new InvalidOperationException("Price not found in HTML.");
            var priceText = match.Groups[1].Value.Replace(",", ".").Trim();
            if (!double.TryParse(priceText, NumberStyles.Any, CultureInfo.InvariantCulture, out var price))
                throw new FormatException($"Unable to parse price '{priceText}'.");
            return price;
        }
    }
}