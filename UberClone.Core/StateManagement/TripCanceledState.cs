using System.Threading.Tasks;
using UberClone.Core.Entities;
using UberClone.Core.Enums;

namespace UberClone.Core.StateManagement
{
    public class TripCanceledState : ITripState
    {
        public async Task HandleAsync(TripContext context)
        {
            // Logic for when the trip is canceled
            context.Trip.Status = TripStatus.Canceled;

            // Notify customer and driver about trip cancellation
            context.NotifyObservers(
                new TripEvent { Trip = context.Trip, Status = TripStatus.Canceled }
            );

            // No further state transition needed
            await Task.CompletedTask;
        }
    }
}
