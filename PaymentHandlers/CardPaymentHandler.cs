// PaymentHandlers/CardPaymentHandler.cs
public class CardPaymentHandler : PaymentHandler
{
    private decimal _balance;

    public CardPaymentHandler(decimal balance)
    {
        _balance = balance;
    }

    public override void HandlePayment(decimal amount)
    {
        if (_balance >= amount)
        {
            Console.WriteLine("Paid with card");
            _balance -= amount;
        }
        else if (_successor != null)
        {
            Console.WriteLine("Not enough balance on card, trying next payment method...");
            _successor.HandlePayment(amount);
        }
        else
        {
            Console.WriteLine("Payment failed, not enough balance and no alternative payment method");
        }
    }
}
