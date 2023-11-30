using _5s.Context;
using _5s.Model;
using Dapper;

namespace _5s.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DapperContext _context;

        public CommentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateComment(Comment comment)
        {
            var sql = @"
                INSERT INTO [dbo].[Comments] ([Sort], [SetInOrder], [Shine], [Standarize], [Sustain], [Security], [isActive], [DateModified], [RatingId])
                VALUES (@Sort, @SetInOrder, @Shine, @Standarize, @Sustain, @Security, @isActive, @DateModified, @RatingId);
                SELECT CAST(SCOPE_IDENTITY() AS INT);
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(sql, comment);
            }
        }

        public async Task DeleteComment(int id)
        {
            var sql = @"
                DELETE FROM [dbo].[Comments]
                WHERE [Id] = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Comment>> GetAllComment()
        {
            var sql = @"
                SELECT * FROM [dbo].[Comments];
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Comment>(sql);
            }
        }

        public async Task<Comment> GetCommentById(int id)
        {
            var sql = @"
                SELECT * FROM [dbo].[Comments]
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Comment>(sql, new { Id = id });
            }
        }

        public async Task<int> UpdateComment(int id, Comment updateComment)
        {
            var sql = @"
                UPDATE [dbo].[Comments]
                SET [Sort] = @Sort,
                    [SetInOrder] = @SetInOrder,
                    [Shine] = @Shine,
                    [Standarize] = @Standarize,
                    [Sustain] = @Sustain,
                    [Security] = @Security,
                    [isActive] = @isActive,
                    [DateModified] = @DateModified,
                    [RatingId] = @RatingId
                WHERE [Id] = @Id;
            ";

            updateComment.Id = id;

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, updateComment);
            }
        }
        public DapperContext Context => _context;

    }
}
