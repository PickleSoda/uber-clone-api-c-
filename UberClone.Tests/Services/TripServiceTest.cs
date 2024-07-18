using System;
using System.Threading.Tasks;
using Moq;
using UberClone.Application.Repositories;
using UberClone.Application.Services;
using UberClone.Core.Entities;
using UberClone.Core.Enums;
using UberClone.Core.Interfaces;
using UberClone.Tests.Factories;
using Xunit;

namespace UberClone.Tests
{
    public class TripServiceTests
    {
        [Fact]
        public async Task CreateTrip_ShouldNotifyObservers()
        {
            // Arrange
            var mockTripRepository = new Mock<ITripRepository>();
            var mockNotificationService = new Mock<INotificationService>();

            mockTripRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Trip>()))
                .Returns(Task.CompletedTask);
            mockNotificationService
                .Setup(service =>
                    service.SendNotificationAsync(It.IsAny<string>(), It.IsAny<string>())
                )
                .Returns(Task.CompletedTask);

            var tripService = new TripService(
                mockTripRepository.Object,
                mockNotificationService.Object
            );

            var startLocation = LocationFactory.CreateLocation(40.7128, -74.0060, "Times Square");
            var endLocation = LocationFactory.CreateLocation(40.7829, -73.9654, "Central Park");
            var customer = UserFactory.CreateCustomer(
                1,
                "customer",
                "customer@example.com",
                "1234567890",
                "password",
                "Credit Card"
            );
            var driver = UserFactory.CreateDriver(
                2,
                "driver",
                "driver@example.com",
                "0987654321",
                "password",
                VehicleFactory.CreateVehicle("ABC123", "Toyota Prius"),
                Availability.Available,
                RideOptions.Lite
            );

            var newTrip = TripFactory.CreateTrip(
                1,
                startLocation,
                endLocation,
                customer,
                driver,
                DateTime.Now
            );

            // Act
            await tripService.CreateTripAsync(newTrip);

            // Assert
            mockTripRepository.Verify(repo => repo.AddAsync(It.IsAny<Trip>()), Times.Once);
            mockNotificationService.Verify(
                service => service.SendNotificationAsync(It.IsAny<string>(), It.IsAny<string>()),
                Times.Exactly(4)
            );
        }

        [Fact]
        public async Task CancelTrip_ShouldChangeStatusToCanceled()
        {
            // Arrange
            var mockTripRepository = new Mock<ITripRepository>();
            var mockNotificationService = new Mock<INotificationService>();

            var startLocation = LocationFactory.CreateLocation(40.7128, -74.0060, "Times Square");
            var endLocation = LocationFactory.CreateLocation(40.7829, -73.9654, "Central Park");
            var customer = UserFactory.CreateCustomer(
                1,
                "customer",
                "customer@example.com",
                "1234567890",
                "password",
                "Credit Card"
            );
            var driver = UserFactory.CreateDriver(
                2,
                "driver",
                "driver@example.com",
                "0987654321",
                "password",
                VehicleFactory.CreateVehicle("ABC123", "Toyota Prius"),
                Availability.Available,
                RideOptions.Lite
            );

            var existingTrip = TripFactory.CreateTrip(
                1,
                startLocation,
                endLocation,
                customer,
                driver,
                DateTime.Now
            );

            mockTripRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(existingTrip);
            mockTripRepository
                .Setup(repo => repo.UpdateAsync(It.IsAny<Trip>()))
                .Returns(Task.CompletedTask);

            var tripService = new TripService(
                mockTripRepository.Object,
                mockNotificationService.Object
            );

            // Act
            await tripService.CancelTripAsync(existingTrip.Id);

            // Assert
            mockTripRepository.Verify(
                repo => repo.UpdateAsync(It.Is<Trip>(t => t.Status == TripStatus.Canceled)),
                Times.Once
            );
            mockNotificationService.Verify(
                service =>
                    service.SendNotificationAsync(
                        It.IsAny<string>(),
                        It.Is<string>(s => s.Contains("Canceled"))
                    ),
                Times.Once
            );
        }

        [Fact]
        public async Task UpdateTripStatus_ShouldTransitionToCorrectState()
        {
            // Arrange
            var mockTripRepository = new Mock<ITripRepository>();
            var mockNotificationService = new Mock<INotificationService>();

            var startLocation = LocationFactory.CreateLocation(40.7128, -74.0060, "Times Square");
            var endLocation = LocationFactory.CreateLocation(40.7829, -73.9654, "Central Park");
            var customer = UserFactory.CreateCustomer(
                1,
                "customer",
                "customer@example.com",
                "1234567890",
                "password",
                "Credit Card"
            );
            var driver = UserFactory.CreateDriver(
                2,
                "driver",
                "driver@example.com",
                "0987654321",
                "password",
                VehicleFactory.CreateVehicle("ABC123", "Toyota Prius"),
                Availability.Available,
                RideOptions.Lite
            );

            var existingTrip = TripFactory.CreateTrip(
                1,
                startLocation,
                endLocation,
                customer,
                driver,
                DateTime.Now
            );

            mockTripRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(existingTrip);
            mockTripRepository
                .Setup(repo => repo.UpdateAsync(It.IsAny<Trip>()))
                .Returns(Task.CompletedTask);

            var tripService = new TripService(
                mockTripRepository.Object,
                mockNotificationService.Object
            );

            // Act
            await tripService.UpdateTripStatusAsync(existingTrip.Id, TripStatus.Started);

            // Assert
            mockTripRepository.Verify(
                repo => repo.UpdateAsync(It.Is<Trip>(t => t.Status == TripStatus.Started)),
                Times.Once
            );
            mockNotificationService.Verify(
                service =>
                    service.SendNotificationAsync(
                        It.IsAny<string>(),
                        It.Is<string>(s => s.Contains("Started"))
                    ),
                Times.Once
            );
        }
    }
}
