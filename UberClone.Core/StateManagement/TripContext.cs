using System.Collections.Generic;
using System.Threading.Tasks;
using UberClone.Core.Entities;
using UberClone.Core.Interfaces;


namespace UberClone.Core.StateManagement
{
    public class TripContext
    {
        public ITripState CurrentState { get; set; }

        public Trip Trip { get; set; }

        private List<ITripObserver> Observers = new List<ITripObserver>();

        public TripContext(Trip trip, ITripState initialState)
        {
            Trip = trip;
            CurrentState = initialState;
        }

        public void TransitionTo(ITripState state)
        {
            CurrentState = state;
            CurrentState.HandleAsync(this);
        }

        public async Task NotifyObserversAsync()
        {
            foreach (var observer in Observers)
            {
                await observer.UpdateAsync(Trip);
            }
        }

        public void Attach(ITripObserver observer)
        {
            Observers.Add(observer);
        }

        public void Detach(ITripObserver observer)
        {
            Observers.Remove(observer);
        }
    }
}
