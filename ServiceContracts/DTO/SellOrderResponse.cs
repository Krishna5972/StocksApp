using Entities;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class SellOrderResponse { 
    public Guid BuyOrderId { get; set; }

    [Required(ErrorMessage = "Stock symbol should be supplied")]
    public string StockSymbol { get; set; }


    [Required(ErrorMessage = "Stock Name should be supplied")]
    public string StockName { get; set; }

    // To validate DateAndTimeOfOrder (custom) we need to implement IValidatableObject interface
    public DateTime DateAndTimeOfOrder { get; set; }

    [Range(1, 100000)]
    public uint Quantity { get; set; }

    [Range(1, 10000)]
    public double Price { get; set; }

    public double TradeAmount { get; set; }



}

public static class SellOrderExtensions
{
    public static SellOrderResponse ToBuyOrderResoponse(this SellOrder sellOrder)
    {

        return new SellOrderResponse
        {
            BuyOrderId = sellOrder.SellOrderID,
            StockName = sellOrder.StockName,
            Price = sellOrder.Price,
            StockSymbol = sellOrder.StockSymbol,
            DateAndTimeOfOrder = sellOrder.DateAndTimeOfOrder,
            Quantity = sellOrder.Quantity,
            TradeAmount = sellOrder.Quantity * sellOrder.Price
        };
    }
}
}
