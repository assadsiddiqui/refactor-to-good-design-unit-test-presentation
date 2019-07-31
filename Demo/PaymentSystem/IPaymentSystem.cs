namespace PaymentSystem
{
    public interface IPaymentSystem
    {
        PaymentResult Charge(decimal amount);
    }
}
