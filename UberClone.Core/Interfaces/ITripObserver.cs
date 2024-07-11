using System.Threading.Tasks;
using UberClone.Core.Entities;

namespace UberClone.Core.Interfaces
{
    public interface ITripObserver
    {
        Task UpdateAsync(Trip trip);
    }
}
