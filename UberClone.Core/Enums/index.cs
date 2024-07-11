namespace UberClone.Core.Enums
{
    public enum TripStatus
    {
        Requested,
        Confirmed,
        Started,
        Finished,
        Canceled
    }

    public enum Availability
    {
        Available,
        Occupied,
        Unreachable,
        OnBreak
    }

    public enum RideOptions
    {
        Lite,
        Premium,
        Pet,
        Minivan
    }
}
