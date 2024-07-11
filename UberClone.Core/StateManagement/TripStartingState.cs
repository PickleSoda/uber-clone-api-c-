namespace UberClone.Core.StateManagement
{
    public class TripStartingState : ITripState
    {
        public async Task HandleAsync(TripContext context)
        {
            // Trip is now in starting mode
            // Transition to another state based on business logic
        }
    }
}
