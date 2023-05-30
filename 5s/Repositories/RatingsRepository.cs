using _5s.Context;
using _5s.Model;
using Dapper;

namespace _5s.Repositories
{
    public class RatingsRepository : IRatingsRepository
    {
        private readonly DapperContext _context;

        public RatingsRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateRatings(Ratings ratings)
        {
            var sql = @"
                INSERT INTO [dbo].[Ratings] ([Sort], [SetInOrder], [Shine], [Standarize], [Sustain], [Security], [isActive], [DateModified], [SpaceId])
                VALUES (@Sort, @SetInOrder, @Shine, @Standarize, @Sustain, @Security, @isActive, @DateModified, @SpaceId);
                SELECT CAST(SCOPE_IDENTITY() AS INT);
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(sql, ratings);
            }
        }

        public async Task DeleteRatings(int id)
        {
            var sql = @"
                DELETE FROM [dbo].[Ratings]
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Ratings>> GetAllRatings()
        {
            var sql = @"
                SELECT * FROM [dbo].[Ratings];
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Ratings>(sql);
            }
        }

        public async Task<Ratings> GetRatingsById(int id)
        {
            var sql = @"
                SELECT * FROM [dbo].[Ratings]
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Ratings>(sql, new { Id = id });
            }
        }

        public async Task<Ratings> GetRatingsByName(string name)
        {
            var sql = @"
                SELECT * FROM [dbo].[Ratings]
                WHERE Name = @Name;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Ratings>(sql, new { Name = name });
            }
        }

        public async Task<int> UpdateRatings(int id, Ratings updatedRatings)
        {
            var sql = @"
                UPDATE [dbo].[Ratings]
                SET Sort = @Sort,
                    SetInOrder = @SetInOrder,
                    Shine = @Shine,
                    Standarize = @Standarize,
                    Sustain = @Sustain,
                    Security = @Security,
                    isActive = @isActive,
                    DateModified = @DateModified
                WHERE Id = @Id;
            ";

            updatedRatings.Id = id;

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, updatedRatings);
            }
        }

        public DapperContext Context => _context;
    }
}
