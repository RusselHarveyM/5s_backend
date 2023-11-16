using _5s.Context;
using _5s.Model;
using Dapper;

namespace _5s.Repositories
{
    public class SpaceImageRepository : ISpaceImageRepository
    {
        private readonly DapperContext _context;

        public SpaceImageRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateSpaceImage(SpaceImage spaceImage)
        {
            const string query = @"
                INSERT INTO [dbo].[SpaceImage] ([SpaceId], [Image], [UploadedDate])
                VALUES (@SpaceId, @Image, @UploadedDate);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (var connection = _context.CreateConnection())
            {
                // Use SELECT CAST(SCOPE_IDENTITY() AS INT) to retrieve the newly generated 'Id' value.
                return await connection.ExecuteScalarAsync<int>(query, spaceImage);
            }
        }


        public async Task DeleteSpaceImage(int id)
        {
            const string query = "DELETE FROM [dbo].[SpaceImage] WHERE Id = @Id;";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<SpaceImage>> GetAllSpaceImageBySpaceId(int spaceId)
        {
            const string query = "SELECT * FROM SpaceImage WHERE SpaceId = @SpaceId;";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<SpaceImage>(query, new { SpaceId = spaceId });
            }
        }
    }
}
