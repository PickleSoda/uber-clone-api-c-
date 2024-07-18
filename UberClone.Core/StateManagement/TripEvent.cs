using UberClone.Core.Enums;
using UberClone.Core.Entities;

namespace UberClone.Core.StateManagement
{
    public class TripEvent
    {
        public Trip Trip { get; set; }
        public TripStatus Status { get; set; }
    }
}
