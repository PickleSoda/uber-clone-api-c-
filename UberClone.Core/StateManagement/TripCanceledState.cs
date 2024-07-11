namespace UberClone.Core.StateManagement
{
    public class TripCanceledState : ITripState
    {
        public async Task HandleAsync(TripContext context)
        {
            // Logic for handling a canceled trip
            // Maybe notify users, rollback operations, etc.
        }
    }

}
