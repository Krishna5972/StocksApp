using System.Diagnostics.CodeAnalysis;

namespace StocksApp;

public class TradingOptions
{
    [AllowNull]
    public string? DefaultStockSymbol { get; set; }
}
