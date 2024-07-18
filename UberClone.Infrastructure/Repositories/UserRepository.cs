using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UberClone.Application.Interfaces;
using UberClone.Core.Entities;
using UberClone.Infrastructure.Contexts;

namespace UberClone.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MockDbContext _context;

        public UserRepository(MockDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> FindUserByCredentialsAsync(string userId, string password)
        {
            // This is just an example, you should hash the password before comparing
            return await _context.Users.FirstOrDefaultAsync(u =>
                u.Username == userId
            );
        }
    }
}
