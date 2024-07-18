namespace UberClone.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double Rating { get; set; }
        public List<Trip> OrderHistory { get; set; }
        public string Password { get; set; }
    }
}
