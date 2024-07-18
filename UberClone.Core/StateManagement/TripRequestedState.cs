using System.Threading.Tasks;
using UberClone.Core.Enums;

namespace UberClone.Core.StateManagement
{
    public class TripRequestedState : ITripState
    {
        public async Task HandleAsync(TripContext context)
        {
            // Notify drivers about the new trip
            context.NotifyObservers(
                new TripEvent { Trip = context.Trip, Status = TripStatus.Requested }
            );

            // Transition to the next state (e.g., waiting for driver confirmation)
            context.TransitionTo(new TripConfirmedState());
            await context.CurrentState.HandleAsync(context);
        }
    }
}
