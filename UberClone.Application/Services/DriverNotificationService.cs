using System;
using System.Threading.Tasks;
using UberClone.Core.Entities;
using UberClone.Core.Interfaces;

namespace UberClone.Application.Services
{
    //            tripContext.Attach(new DriverNotificationService(_notificationService)); // Observer for notifying drivers
    public class DriverNotificationService : ITripObserver
    {
        private readonly INotificationService _notificationService;

        public DriverNotificationService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task UpdateAsync(Trip trip)
        {
            // Notify drivers about the trip
            //find available drivers
            //notificationService.SendNotificationAsync(trip);
            Console.WriteLine("Notifying drivers about trip: " + trip.Id);
        }
    }
}
