using _5s.Context;
using _5s.Model;
using Dapper;

namespace _5s.Repositories
{
    public class SpaceRepository : ISpaceRepository
    {
        private readonly DapperContext _context;

        public SpaceRepository(DapperContext context)
        {
            _context = context;
        }
        public DapperContext Context => _context;
        public async Task<int> CreateSpace(Space space)
        {
            var sql = @"
                INSERT INTO [dbo].[Spaces] ([Name], [Pictures], [RoomId])
                VALUES (@Name @Pictures, @RoomId);
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, space);
            }
        }

        public async Task DeleteSpace(string id)
        {
            var sql = @"
                DELETE FROM [dbo].[Spaces]
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Space>> GetAllSpace()
        {
            var sql = @"
                SELECT * FROM [dbo].[Spaces];
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Space>(sql);
            }
        }

        public async Task<Space> GetSpaceById(int id)
        {
            var sql = @"
                SELECT * FROM [dbo].[Spaces]
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Space>(sql, new { Id = id });
            }
        }

        public async Task<Space> GetSpaceByName(string name)
        {
            var sql = @"
                SELECT * FROM [dbo].[Spaces]
                WHERE Name = @Name;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Space>(sql, new { Name = name });
            }
        }

        public async Task<int> UpdateSpace(int id, Space updatedSpace)
        {
            var sql = @"
                UPDATE [dbo].[Spaces]
                SET ,
                    [Name] = @Name,
                    [Pictures] = @Pictures
                WHERE [Id] = @Id;
            ";

            updatedSpace.Id = id;

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, updatedSpace);
            }
        }

    }
}
