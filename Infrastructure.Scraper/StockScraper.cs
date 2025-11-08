using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading.Tasks;
using Infrastructure.Scraper.Interfaces;
namespace Infrastructure.Scraper;

public class StockScraper : IStockScraper
{

    public async Task<double> GetPrice(string ticker, string exchange)
    {
        string _apiKey = "fIgA75UuqY61RcmYKkINlaVBWDEOVkBy; // Replace with your FMP key if you have one
        string url = $"https://financialmodelingprep.com/stable/quote-short?symbol={ticker}&apikey={_apiKey}";
        using (var client = new HttpClient())
        {
            var json = await client.GetStringAsync(url);
            string response = await client.GetStringAsync(url);
            var quotes = JsonSerializer.Deserialize<List<Quote>>(json);
            var data = JsonConvert.DeserializeObject<Class2>(response);
            return quotes?.FirstOrDefault();
        }
    }
    
}