
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.src
{
    class Checkout : ICheckout
    {
        private List<IProduct> availableProducts;
        private List<IOrder> orders;
        private List<IDiscount> discounts;

        public Checkout()
        {
            availableProducts = new List<IProduct>() {
                new Product { SKU = "A", Price = 50 },
                new Product { SKU = "B", Price = 30 },
                new Product { SKU = "C", Price = 20 },
                new Product { SKU = "D", Price = 15 }
            };

            discounts = new List<IDiscount>()
            {
                new Discount{SKU="A", Amount= 3, Value = 20 },
                new Discount{SKU="B", Amount= 2, Value = 15 }
            };

            orders = new List<IOrder>();

        }
        public int GetTotalPrice()
        {
            int price = 0;
            foreach(Discount discount in discounts)
            {
                var order = orders.Find(o => o.Product.SKU == discount.SKU);
                if (order != null)
                {
                    order.Discount = CalculateDiscount(discount, order.Quantity);
                }
            }

            foreach (Order order in orders)
            {
                price += order.Price();
            }
            return price;
        }

        public void Scan(string item)
        {
            var order = orders.Find(o => o.Product.SKU == item);

            if (order != null)
            {
                order.Quantity++;
            }
            else
            {
                order = new Order { Product = availableProducts.Find((av) => av.SKU == item), Quantity = 1 };
                orders.Add(order);
            }
        }
        private int CalculateDiscount(IDiscount discount, int quantity)
        {
            return (quantity / discount.Amount) * discount.Value;
        }
    }
}
