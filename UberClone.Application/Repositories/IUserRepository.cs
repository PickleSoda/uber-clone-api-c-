using System.Threading.Tasks;
using System.Collections.Generic;
using UberClone.Core.Entities;

namespace UberClone.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<User> FindUserByCredentialsAsync(string userId, string password);
    }
}
