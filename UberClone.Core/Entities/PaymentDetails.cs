namespace UberClone.Core.Entities
{
    public class PaymentDetails
    {
        public string PaymentMethod { get; set; }
        public string CardNumber { get; set; }
        public User User { get; set; }
    }
}