using System.Collections.Generic;
using UberClone.Core.Entities;
using UberClone.Core.Interfaces;

namespace UberClone.Core.StateManagement
{
    public class TripContext
    {
        private readonly List<ITripObserver> _observers = new List<ITripObserver>();

        public Trip Trip { get; private set; }
        public ITripState CurrentState { get; private set; }

        public TripContext(Trip trip, ITripState initialState)
        {
            Trip = trip;
            TransitionTo(initialState);
        }

        public void TransitionTo(ITripState state)
        {
            CurrentState = state;
        }

        public void Attach(ITripObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ITripObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(TripEvent tripEvent)
        {
            foreach (var observer in _observers)
            {
                observer.UpdateAsync(tripEvent);
            }
        }
    }
}
