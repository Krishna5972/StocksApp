using Microsoft.AspNetCore.Mvc;
using StocksApp.Models;
using Microsoft.Extensions.Options;
using StocksApp;
using StocksApp.Interfaces;

namespace StocksApp.Controllers
{
    public class TradeController : Controller {


        private readonly TradingOptions _tradingOptions;

        private readonly IFinnhubService _finnhubService;
        private readonly IConfiguration _configuration;


        public TradeController(IOptions<TradingOptions> tradingOptions, IFinnhubService finnhubService, IConfiguration configuration)
    {
            _tradingOptions = tradingOptions?.Value;
            _finnhubService = finnhubService;
            _configuration = configuration;


        }


    
        [Route("/")]
        public async Task<IActionResult> Index()
        {

            Dictionary<string, object> stockQuoteDictionary = await _finnhubService.GetStockPriceQuote(_tradingOptions.DefaultStockSymbol);


            foreach (var kvp in stockQuoteDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            ViewBag.StockQuote = stockQuoteDictionary;



            return View();
        }
    }
}
