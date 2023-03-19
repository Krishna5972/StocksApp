using Microsoft.AspNetCore.Mvc;
using StocksApp.Models;
using Microsoft.Extensions.Options;
using StocksApp;
using ServiceContracts;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

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

            Dictionary<string, object> profileQuoteDictionary = await _finnhubService.GetCompanyProfile(_tradingOptions.DefaultStockSymbol);


            StockTrade stocktrade = new StockTrade() { StockSymbol = _tradingOptions.DefaultStockSymbol };
            


            if (stockQuoteDictionary.Count > 0 && profileQuoteDictionary.Count > 0)
            {
                stocktrade = new StockTrade() {
                    StockSymbol = profileQuoteDictionary["ticker"].ToString(),
                    StockName = profileQuoteDictionary["name"].ToString(),
                Price = ((JsonElement)stockQuoteDictionary["c"]).GetDouble()
            };

            }
            return View(stocktrade);
        }
    }
}
