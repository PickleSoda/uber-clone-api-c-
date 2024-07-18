using System.Threading.Tasks;
using UberClone.Core.Entities;
using UberClone.Core.Enums;

namespace UberClone.Core.StateManagement
{
    public class TripConfirmedState : ITripState
    {
        public async Task HandleAsync(TripContext context)
        {
            // Logic for when the trip is confirmed (e.g., driver accepts the trip)
            context.Trip.Status = TripStatus.Confirmed;

            // Notify customer about trip confirmation
            context.NotifyObservers(new TripEvent { Trip = context.Trip, Status = TripStatus.Confirmed });

            // Transition to the next state (e.g., starting the trip)
            context.TransitionTo(new TripStartingState());
            await context.CurrentState.HandleAsync(context);
        }
    }
}
