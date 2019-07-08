
using System.Collections.Generic;

namespace CheckoutKata.src
{
    class Checkout : ICheckout
    {
        private List<Product> availableProducts;
        private List<Product> scannedProducts;

        public Checkout()
        {
            availableProducts = new List<Product>() {
                new Product { SKU = "A", Price = 50 },
                new Product { SKU = "B", Price = 30 },
                new Product { SKU = "C", Price = 20 },
                new Product { SKU = "D", Price = 15 }
            };

            scannedProducts = new List<Product>();

        }
        public int GetTotalPrice()
        {
            int price = 0;
            foreach (Product product in scannedProducts){
                price += product.Price;
            }
            return price;
        }

        public void Scan(string item)
        {
            scannedProducts.Add(availableProducts.Find((av) => av.SKU == item));
        }
    }
}
