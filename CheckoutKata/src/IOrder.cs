namespace CheckoutKata.src
{
    interface IOrder
    {
        IProduct Product { get; set; }
        int Quantity { get; set; }

        int Price();
    }
}
