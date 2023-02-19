using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Core.Models
{
    public class Product : IProduct
    {
        public string SKU { get; set; }

        public decimal UnitPrice { get; set; }



        public Product(string SKU, decimal unitPrice)
        {
            this.SKU = SKU;
            UnitPrice = unitPrice;
        }

    }
}
