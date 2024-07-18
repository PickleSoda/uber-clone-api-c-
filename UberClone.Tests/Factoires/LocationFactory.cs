using UberClone.Core.Entities;

namespace UberClone.Tests.Factories
{
    public static class LocationFactory
    {
        public static Location CreateLocation(double latitude, double longitude, string locationName)
        {
            return new Location
            {
                Latitude = latitude,
                Longitude = longitude,
                LocationName = locationName
            };
        }
    }
}
