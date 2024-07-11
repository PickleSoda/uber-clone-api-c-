using System.Threading.Tasks;

namespace UberClone.Core.StateManagement
{
    public class LookingForDriverState : ITripState
    {
        public async Task HandleAsync(TripContext context)
        {
            // Logic to handle driver finding process
            // Transition to Starting mode if driver is found
            context.TransitionTo(new TripStartingState());
        }
    }
}

