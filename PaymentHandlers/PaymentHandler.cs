// PaymentHandlers/PaymentHandler.cs
public abstract class PaymentHandler
{
    protected PaymentHandler _successor;

    public void SetSuccessor(PaymentHandler successor)
    {
        _successor = successor;
    }

    public abstract void HandlePayment(decimal amount);
}
