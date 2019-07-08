using CheckoutKata.src;
using NUnit.Framework;

namespace CheckoutKata.test
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void scan_once_single_item(string sku, int expectedPrice)
        {
            var checkout = new Checkout();

            checkout.Scan(sku);

            var price = checkout.GetTotalPrice();

            Assert.AreEqual(expectedPrice, price);
        }

        [Test]
        [TestCase("A", 2, 100)]
        [TestCase("C", 2, 40)]
        public void scan_multiple_times_single_item(string sku, int amount, int expectedPrice)
        {
            var checkout = new Checkout();

            for(int i = 0; i<amount; i++)
            {
                checkout.Scan(sku);
            }

            var price = checkout.GetTotalPrice();

            Assert.AreEqual(expectedPrice, price);
        }

        [Test]
        public void scan_multiple_times_multiple_items()
        {
            var expectedPrice = 80;
            var checkout = new Checkout();

            checkout.Scan("A");
            checkout.Scan("B");

            var price = checkout.GetTotalPrice();

            Assert.AreEqual(expectedPrice, price);
        }

        [Test]
        [TestCase("A", 3, 130)]
        [TestCase("B", 2, 45)]
        public void scan_multiple_times_single_item_with_discount(string sku, int amount, int expectedPrice)
        {
            var checkout = new Checkout();

            for (int i = 0; i < amount; i++)
            {
                checkout.Scan(sku);
            }

            var price = checkout.GetTotalPrice();

            Assert.AreEqual(expectedPrice, price);
        }
    }
}
