using System.Threading.Tasks;

namespace UberClone.Core.StateManagement
{
    public class TripRequestedState : ITripState
    {
        public async Task HandleAsync(TripContext context)
        {
            // Notify drivers about the new trip
            await context.NotifyObserversAsync();
            // Transition to the next appropriate state
            context.TransitionTo(new LookingForDriverState());
        }
    }
}