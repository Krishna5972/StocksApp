namespace Services;

using ServiceContracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System;


public class FinnService : IFinnhubService
{
    public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
    {
        string url =  $"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token=cg8taf1r01qk68o7pdj0cg8taf1r01qk68o7pdjg";
        Dictionary<string, object> ? profile = null;

        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {

            string json = await response.Content.ReadAsStringAsync();
            profile = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
        }
        else
        {
            Console.WriteLine("Error fetching data.");
        }
    
        return profile;
    
    }

    public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)

    {

        string quoteUrl = $"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token=cg8taf1r01qk68o7pdj0cg8taf1r01qk68o7pdjg";
        Dictionary<string, object>? quote = null;

        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(quoteUrl);

        if(response.IsSuccessStatusCode)
        {

            string json = await response.Content.ReadAsStringAsync();
            quote  = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        }
        else
        {
            Console.WriteLine("Error fetching data.");
        }


        return quote;

    }
}
