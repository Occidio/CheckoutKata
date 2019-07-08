using System;
namespace CheckoutKata.src
{
    class Discount : IDiscount
    {
        public string SKU { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
    }
}
