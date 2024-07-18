using System.Threading.Tasks;
using UberClone.Application.Interfaces;
using UberClone.Core.Entities;
using UberClone.Core.Interfaces;

namespace UberClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }

        public async Task RegisterCustomerAsync(Customer customer)
        {
            await _userRepository.AddUserAsync(customer);
        }

        public async Task RegisterDriverAsync(Driver driver)
        {
            await _userRepository.AddUserAsync(driver);
        }

        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userRepository.FindUserByCredentialsAsync(username, password);

            if (user == null)
                throw new Exception("Authentication failed: Invalid username or password.");

            // Process successful login, e.g., generate token, etc.
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }
    }
}
