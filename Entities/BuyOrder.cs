using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class BuyOrder
    {
        public Guid BuyOrderID { get; set; }

        [Required(ErrorMessage = "StockSymbol is not supplied")]
        public string? StockSymbol { get; set; }

        [Required(ErrorMessage = "Stock Name is not supplied")]
        public string? StockName { get; set; }

        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1,100000)]
        public uint Quantity { get; set; }

        [Range(1,10000)]
        public double Price { get; set; }

    }
}