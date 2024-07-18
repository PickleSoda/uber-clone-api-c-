using System.Threading.Tasks;
using UberClone.Core.Entities;
using UberClone.Core.StateManagement;
namespace UberClone.Core.Interfaces
{
    public interface ITripObserver
    {
        Task UpdateAsync(TripEvent trip);
    }
}
