namespace CheckoutKata.src
{
    class Order : IOrder
    {
        public IProduct Product { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

        public int Price()
        {
            return (Product.Price * Quantity) - Discount;
        }
    }
}
