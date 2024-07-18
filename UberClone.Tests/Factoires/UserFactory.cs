using UberClone.Core.Entities;
using UberClone.Core.Enums;
using System.Collections.Generic;

namespace UberClone.Tests.Factories
{
    public static class UserFactory
    {
        public static User CreateUser(int id, string username, string email, string phoneNumber, string password, double rating = 0.0)
        {
            return new User
            {
                Id = id,
                Username = username,
                Email = email,
                PhoneNumber = phoneNumber,
                Password = password,
                Rating = rating,
                OrderHistory = new List<Trip>()
            };
        }

        public static Driver CreateDriver(int id, string username, string email, string phoneNumber, string password, Vehicle vehicle, Availability availability, RideOptions rideOptions, double rating = 0.0)
        {
            return new Driver
            {
                Id = id,
                Username = username,
                Email = email,
                PhoneNumber = phoneNumber,
                Password = password,
                Rating = rating,
                OrderHistory = new List<Trip>(),
                Vehicle = vehicle,
                Availability = availability,
                RideOptions = rideOptions
            };
        }

        public static Customer CreateCustomer(int id, string username, string email, string phoneNumber, string password, string paymentMethod, double rating = 0.0)
        {
            return new Customer
            {
                Id = id,
                Username = username,
                Email = email,
                PhoneNumber = phoneNumber,
                Password = password,
                Rating = rating,
                OrderHistory = new List<Trip>(),
                PaymentMethod = paymentMethod
            };
        }
    }
}
