using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UberClone.Core.Entities;

namespace UberClone.Application.Repositories
{
    public interface ITripRepository
    {
        Task AddAsync(Trip trip);
        Task<Trip> GetByIdAsync(int tripId);
        Task UpdateAsync(Trip trip);
        Task<IEnumerable<Trip>> FindByAsync(Func<Trip, bool> predicate);
        Task<IEnumerable<Trip>> FindByUserIdAsync(int userId);
    }
}
