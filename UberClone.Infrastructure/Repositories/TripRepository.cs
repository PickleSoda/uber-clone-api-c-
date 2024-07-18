using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UberClone.Core.Entities;
using UberClone.Core.Interfaces;
using UberClone.Application.Repositories;
using UberClone.Infrastructure.Contexts;

namespace UberClone.Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        // Assuming using Entity Framework Core
        private readonly MockDbContext _context;

        public TripRepository(MockDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
        }

        public async Task<Trip> GetByIdAsync(int tripId)
        {
            return await _context.Trips.FindAsync(tripId);
        }

        public async Task UpdateAsync(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Trip>> FindByAsync(Func<Trip, bool> predicate)
        {
            return await Task.FromResult(_context.Trips.Where(predicate).ToList());
        }

        public async Task<IEnumerable<Trip>> FindByUserIdAsync(int userId)
        {
            return await Task.FromResult(_context.Trips.Where(t => t.Customer.Id == userId).ToList());
        }
    }
}
