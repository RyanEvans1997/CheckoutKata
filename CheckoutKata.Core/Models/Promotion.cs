using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Core.Models
{
    public class Promotion : IPromotion
    {
        public string SKU { get; set; }
        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public Promotion(string sKU, int? quantity, decimal? price)
        {
            SKU = sKU;
            Quantity = quantity;
            Price = price;
        }

    }
}
