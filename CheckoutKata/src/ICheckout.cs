namespace CheckoutKata.src
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
