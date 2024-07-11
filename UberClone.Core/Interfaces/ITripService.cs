using System.Collections.Generic;
using System.Threading.Tasks;
using UberClone.Core.Entities;
using UberClone.Core.Enums;

namespace UberClone.Core.Interfaces
{
    public interface ITripService
    {
        Task CreateTripAsync(Trip trip);
        Task CancelTripAsync(int tripId);
        Task UpdateTripStatusAsync(int tripId, TripStatus status);
        Task<IEnumerable<Trip>> GetTripHistoryAsync(int userId);
    }
}