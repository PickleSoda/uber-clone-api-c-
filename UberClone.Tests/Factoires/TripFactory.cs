using System;
using UberClone.Core.Entities;
using UberClone.Core.Enums;

namespace UberClone.Tests.Factories
{
    public static class TripFactory
    {
        public static Trip CreateTrip(int id, Location startLocation, Location endLocation, User customer, User driver, DateTime startTime, TripStatus status = TripStatus.Requested, DateTime? endTime = null, int? customerRating = null, int? driverRating = null)
        {
            return new Trip
            {
                Id = id,
                StartLocation = startLocation,
                EndLocation = endLocation,
                Customer = customer,
                Driver = driver,
                StartTime = startTime,
                EndTime = endTime,
                CustomerRating = customerRating,
                DriverRating = driverRating,
                Status = status
            };
        }
    }
}
