
namespace CheckoutKata.src
{
    class Checkout : ICheckout
    {
        private string scannedProduct;

        public int GetTotalPrice()
        {
            switch(scannedProduct)
            {
                case "A":
                    return 50;
                case "B":
                    return 30;
                case "C":
                    return 20;
                case "D":
                    return 15;
                default:
                    return 0;
            }
        }

        public void Scan(string item)
        {
            scannedProduct = item;
        }
    }
}
