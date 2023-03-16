using FinnhubService;
using StocksApp.Interfaces;
using StocksApp.Models;
using StocksApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));
builder.Services.AddSingleton<IFinnhubService, FinnService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();



app.Run();