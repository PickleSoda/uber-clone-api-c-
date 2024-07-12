// PaymentHandlers/CashPaymentHandler.cs
public class CashPaymentHandler : PaymentHandler
{
    private decimal _cashOnHand;

    public CashPaymentHandler(decimal cashOnHand)
    {
        _cashOnHand = cashOnHand;
    }

    public override void HandlePayment(decimal amount)
    {
        if (_cashOnHand >= amount)
        {
            Console.WriteLine("Paid with cash");
            _cashOnHand -= amount;
        }
        else
        {
            Console.WriteLine("Payment failed, not enough cash");
        }
    }
}
