
namespace CheckoutKata.src
{
    class Checkout : ICheckout
    {
        private Product[] availableProducts;
        private Product scannedProduct;

        public Checkout()
        {
            availableProducts = new Product[] {
                new Product { SKU = "A", Price = 50 },
                new Product { SKU = "B", Price = 30 },
                new Product { SKU = "C", Price = 20 },
                new Product { SKU = "D", Price = 15 }
            };
        }
        public int GetTotalPrice()
        {
            return scannedProduct.Price;
        }

        public void Scan(string item)
        {
            for (int i = 0; i < availableProducts.Length; i++)
            {
                if (availableProducts[i].SKU == item)
                {
                    scannedProduct = availableProducts[i];
                }
            }
        }
    }
}
