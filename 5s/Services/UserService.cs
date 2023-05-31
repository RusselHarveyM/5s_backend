using _5s.Model;
using _5s.Repositories;

namespace _5s.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CreateUser(User user)
        {
            var userModel = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                Role = user.Role,
            };

            user.Id = await _userRepository.CreateUser(userModel);

            return user.Id;
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> GetUserByName(string name) 
        {
            return await _userRepository.GetUserByName(name);
        }

        public async Task<int> UpdateUser(int id, User updatedUser)
        {
            var usermodel = new User
            {
                Username = updatedUser.Username,
                Password = updatedUser.Password,
            };

            var updateUser = await _userRepository.UpdateUser(id, usermodel);

            return updateUser;
        }

    }
}
