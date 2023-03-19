using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class SellOrderRequest : IValidatableObject
    {

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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (DateAndTimeOfOrder < Convert.ToDateTime("2000-01-01"))
                results.Add(new ValidationResult("Date Should not be older than Jan 01,2000"));

            return results;
        }
    }
}
