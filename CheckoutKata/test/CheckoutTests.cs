using CheckoutKata.src;
using NUnit.Framework;
using System.Collections.Generic;

namespace CheckoutKata.test
{
    [TestFixture]
    public class CheckoutTests
    {
        IEnumerable<IProduct> products;
        IEnumerable<IDiscount> discounts;

        [SetUp]
        public void Setup()
        {
            products = new[]
            {
                new Product{SKU = "A", Price = 50},
                new Product{SKU = "B", Price = 30},
                new Product{SKU = "C", Price = 20},
                new Product{SKU = "D", Price = 15}
            };

            discounts = new[]
            {
                new Discount{SKU = "A", Amount = 3, Value=20},
                new Discount{SKU = "B", Amount = 2, Value=15},
            };
        }

        [Test]
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void scan_once_single_item(string sku, int expectedPrice)
        {
            var checkout = new Checkout(products, discounts);

            checkout.Scan(sku);

            var price = checkout.GetTotalPrice();

            Assert.AreEqual(expectedPrice, price);
        }

        [Test]
        [TestCase("A", 2, 100)]
        [TestCase("C", 2, 40)]
        public void scan_multiple_times_single_item(string sku, int amount, int expectedPrice)
        {
            var checkout = new Checkout(products, discounts);

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
            var checkout = new Checkout(products, discounts);

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
            var checkout = new Checkout(products, discounts);

            for (int i = 0; i < amount; i++)
            {
                checkout.Scan(sku);
            }

            var price = checkout.GetTotalPrice();

            Assert.AreEqual(expectedPrice, price);
        }
    }
}
