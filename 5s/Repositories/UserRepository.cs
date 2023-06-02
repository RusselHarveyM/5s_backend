using _5s.Context;
using _5s.Model;
using Dapper;

namespace _5s.Repositories
{
    public class UserRepository : IUserRepository
    {   
        private readonly DapperContext _context;

        public UserRepository(DapperContext con)
        {
            _context = con;
        }

        public async Task<int> CreateUser(User user)
        {
            var sql = @"
                INSERT INTO [dbo].[User] ([FirstName], [LastName], [Username], [Password], [Role])
                VALUES (@FirstName, @LastName, @Username, @Password, @Role);
                SELECT CAST(SCOPE_IDENTITY() AS INT);
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(sql, user);
            }
        }

        public async Task DeleteUser(int id)
        {
            var sql = @"
                DELETE FROM [dbo].[User]
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var sql = @"
                SELECT * FROM [dbo].[User];
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<User>(sql);
            }
        }

        public async Task<User> GetUserById(int id)
        {
            var sql = @"
                SELECT * FROM [dbo].[User]
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
            }
        }

        public async Task<User> GetUserByName(string name)
        {
            var sql = @"
                SELECT * FROM [dbo].[User]
                WHERE FirstName = @Name OR LastName = @Name;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Name = name });
            }
        }


        public async Task<int> UpdateUser(int id, User updatedUser)
        {
            var sql = @"
                UPDATE [dbo].[User]
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    Role = @Role
                WHERE Id = @Id; 
            ";

            updatedUser.Id = id;

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, updatedUser);
            }
        }

        public DapperContext Context => _context;
    }
}
