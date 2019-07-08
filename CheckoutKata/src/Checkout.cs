
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.src
{
    class Checkout : ICheckout
    {
        private readonly IEnumerable<IProduct> AvailableProducts;
        private List<IOrder> Orders;
        private readonly IEnumerable<IDiscount> AvailableDiscounts;

        public Checkout(IEnumerable<IProduct> products, IEnumerable<IDiscount> discounts)
        {
            AvailableProducts = products;
            AvailableDiscounts = discounts;
            Orders = new List<IOrder>();

        }
        public int GetTotalPrice()
        {
            int price = 0;
            foreach(Discount discount in AvailableDiscounts)
            {
                var order = Orders.Find(o => o.Product.SKU == discount.SKU);
                if (order != null)
                {
                    order.Discount = CalculateDiscount(discount, order.Quantity);
                }
            }

            foreach (Order order in Orders)
            {
                price += order.Price();
            }
            return price;
        }

        public void Scan(string item)
        {
            var order = Orders.Find(o => o.Product.SKU == item);

            if (order != null)
            {
                order.Quantity++;
            }
            else
            {
                order = new Order { Product = AvailableProducts.ToList().Find((av) => av.SKU == item), Quantity = 1 };
                Orders.Add(order);
            }
        }
        private int CalculateDiscount(IDiscount discount, int quantity)
        {
            return (quantity / discount.Amount) * discount.Value;
        }
    }
}
