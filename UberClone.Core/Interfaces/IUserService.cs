using System.Threading.Tasks;
using UberClone.Core.Entities;

namespace UberClone.Core.Interfaces;

public interface IUserService
{
    Task RegisterUserAsync(User user);
    Task AuthenticateUserAsync(string username, string password);
    Task UpdateUserAsync(User user);
    Task<User> GetUserByIdAsync(int userId);
}
