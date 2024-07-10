using UberClone.Core.Enums;

namespace UberClone.Core.Entities;


public class Driver : User
{
    public Vehicle Vehicle { get; set; }
    public Availability Availability { get; set; }
    public RideOptions RideOptions { get; set; }
}
