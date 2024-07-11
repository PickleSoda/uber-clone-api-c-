using System.Threading.Tasks;

namespace UberClone.Core.StateManagement
{
    public interface ITripState
    {
        Task HandleAsync(TripContext context);
    }
}
