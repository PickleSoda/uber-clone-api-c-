using System.Threading.Tasks;
using UberClone.Core.Entities;
using UberClone.Core.Enums;

namespace UberClone.Core.StateManagement
{
    public class TripFinishedState : ITripState
    {
        public async Task HandleAsync(TripContext context)
        {
            // Logic for when the trip is finished
            context.Trip.Status = TripStatus.Finished;
            context.Trip.EndTime = DateTime.Now;

            // Notify customer and driver about trip finish
            context.NotifyObservers(new TripEvent { Trip = context.Trip, Status = TripStatus.Finished });

            // No further state transition needed
            await Task.CompletedTask;
        }
    }
}
