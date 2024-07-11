using UberClone.Core.Enums;

namespace UberClone.Core.Entities
{   
    public class Trip
    {
        public int Id { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public User Customer { get; set; }
        public User Driver { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? CustomerRating { get; set; }
        public int? DriverRating { get; set; }
        public TripStatus Status { get; set; }
    }

}