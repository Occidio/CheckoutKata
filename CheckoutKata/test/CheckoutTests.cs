using CheckoutKata.src;
using NUnit.Framework;

namespace CheckoutKata.test
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void Scan()
        {
            var checkout = new Checkout();

            checkout.Scan("A");
        }

        [Test]
        public void GetTotalPrice()
        {
            var checkout = new Checkout();

            var price = checkout.GetTotalPrice();
        }
    }
}
