using _5s.Model;

namespace _5s.Services
{
    public interface IUserService
    {
        public Task<int> CreateUser(User user);
        public Task<IEnumerable<User>> GetAllUser();
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByName(string name);
        public Task<int> UpdateUser(int id, User updatedUser);
        public Task DeleteUser(int id);
    }
}
