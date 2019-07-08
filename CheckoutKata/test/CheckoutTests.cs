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
        public void Scan(string sku, int expectedPrice)
        {
            var checkout = new Checkout();

            checkout.Scan(sku);

            var price = checkout.GetTotalPrice();

            Assert.AreEqual(expectedPrice, price);
        }
    }
}
