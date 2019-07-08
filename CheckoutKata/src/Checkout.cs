
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
                new Discount{SKU="A", Amount= 3, Price = 130 },
                new Discount{SKU="B", Amount= 2, Price = 45 }
            };

            orders = new List<IOrder>();

        }
        public int GetTotalPrice()
        {
            int price = 0;
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
    }
}
