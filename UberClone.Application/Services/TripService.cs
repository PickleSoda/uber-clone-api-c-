using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UberClone.Application.Repositories;
using UberClone.Core.Entities;
using UberClone.Core.Enums;
using UberClone.Core.Interfaces;
using UberClone.Core.StateManagement;
using UberClone.Application.Repositories;

namespace UberClone.Application.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly INotificationService _notificationService;

        public TripService(ITripRepository tripRepository, INotificationService notificationService)
        {
            _tripRepository = tripRepository;
            _notificationService = notificationService;
        }

        public async Task CreateTripAsync(Trip trip)
        {
            trip.Status = TripStatus.Requested;
            await _tripRepository.AddAsync(trip);

            var tripContext = new TripContext(trip, new TripRequestedState());
            tripContext.Attach(new DriverNotificationService(_notificationService));

            await tripContext.CurrentState.HandleAsync(tripContext);
        }

        public async Task CancelTripAsync(int tripId)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);
            if (trip == null)
                throw new InvalidOperationException("Trip not found");

            var tripContext = new TripContext(trip, new TripCanceledState());
            tripContext.Attach(new DriverNotificationService(_notificationService));

            await tripContext.CurrentState.HandleAsync(tripContext);

            trip.Status = TripStatus.Canceled;
            await _tripRepository.UpdateAsync(trip);
        }

        public async Task UpdateTripStatusAsync(int tripId, TripStatus status)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);
            if (trip == null)
                throw new InvalidOperationException("Trip not found");

            ITripState newState = status switch
            {
                TripStatus.Started => new TripStartingState(),
                TripStatus.Finished => new TripFinishedState(),
                TripStatus.Confirmed => new TripConfirmedState(),
                _ => throw new InvalidOperationException("Invalid status transition")
            };

            var tripContext = new TripContext(trip, newState);
            tripContext.Attach(new DriverNotificationService(_notificationService));

            await tripContext.CurrentState.HandleAsync(tripContext);

            trip.Status = status;
            await _tripRepository.UpdateAsync(trip);
        }

        public async Task<IEnumerable<Trip>> GetTripHistoryAsync(int userId)
        {
            // Retrieve trip history from the repository
            return await _tripRepository.FindByUserIdAsync(userId);
        }
    }
}
