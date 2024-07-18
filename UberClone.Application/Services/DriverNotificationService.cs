using System;
using System.Threading.Tasks;
using UberClone.Core.Entities;
using UberClone.Core.Interfaces;
using UberClone.Core.StateManagement;

namespace UberClone.Application.Services
{
    public class DriverNotificationService : ITripObserver
    {
        private readonly INotificationService _notificationService;

        public DriverNotificationService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task UpdateAsync(TripEvent tripEvent)
        {
            // Notify drivers about the trip
            Console.WriteLine("Notifying drivers about trip: " + tripEvent.Trip.Id);

            // Simulate finding available drivers and sending notifications
            await _notificationService.SendNotificationAsync($"{tripEvent.Trip.Driver.Id}",$"Trip {tripEvent.Trip.Id} is now {tripEvent.Status}");
        }
    }
}
