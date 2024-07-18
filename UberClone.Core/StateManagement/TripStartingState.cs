using System.Threading.Tasks;
using UberClone.Core.Entities;
using UberClone.Core.Enums;

namespace UberClone.Core.StateManagement
{
    public class TripStartingState : ITripState
    {
        public async Task HandleAsync(TripContext context)
        {
            // Logic for when the trip is starting
            context.Trip.Status = TripStatus.Started;

            // Notify customer and driver about trip start
            context.NotifyObservers(new TripEvent { Trip = context.Trip, Status = TripStatus.Started });

            // Transition to the next state (e.g., finishing the trip)
            context.TransitionTo(new TripFinishedState());
            await context.CurrentState.HandleAsync(context);
        }
    }
}
