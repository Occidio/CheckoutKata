using System;
namespace CheckoutKata.src
{
    interface IDiscount
    {
        string SKU { get; set; }
        int Amount { get; set;}
        int Price { get; set; }
    }
}
