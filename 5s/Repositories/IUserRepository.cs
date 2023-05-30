
using _5s.Model;

namespace _5s.Repositories
{
    public interface IUserRepository
    {
        public Task<int> CreateUser(User userModel);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByName(string name);
        public Task<int> UpdateUser(int id, User updatedUser);
        public Task DeleteUser(int id);
    }
}
