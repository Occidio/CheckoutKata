using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.src
{
    class Product : IProduct
    {
        public string SKU { get; set ; }
        public int Price { get; set; }
    }
}
