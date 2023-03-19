using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class BuyOrderResponse
    {
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

    public static class BuyOrderExtensions
    {
        public static BuyOrderResponse ToBuyOrderResoponse(this BuyOrder buyOrder)
        {

            return new BuyOrderResponse
            {
                BuyOrderId = buyOrder.BuyOrderID,
                StockName = buyOrder.StockName,
                Price = buyOrder.Price,
                StockSymbol = buyOrder.StockSymbol,
                DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
                Quantity = buyOrder.Quantity,
                TradeAmount = buyOrder.Quantity * buyOrder.Price
            };
        }
    }
}
