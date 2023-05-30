﻿using _5s.Context;
using _5s.Model;
using Dapper;

namespace _5s.Repositories
{
    public class RedTagRepository : IRedTagRepository
    {
        private readonly DapperContext _context;

        public RedTagRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateRedTag(RedTag redTag)
        {
            var sql = @"
                INSERT INTO [dbo].[RedTags] ([ItemName], [Quantity], [RoomId])
                VALUES (@ItemName, @Quantity, @RoomId);
                SELECT CAST(SCOPE_IDENTITY() AS INT);
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(sql, redTag);
            }
        }

        public async Task DeleteRedTag(int id)
        {
            var sql = @"
                DELETE FROM [dbo].[RedTags]
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<RedTag>> GetAllRedTags()
        {
            var sql = @"
                SELECT * FROM [dbo].[RedTags];
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<RedTag>(sql);
            }
        }

        public async Task<RedTag> GetRedTagById(int id)
        {
            var sql = @"
                SELECT * FROM [dbo].[RedTags]
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<RedTag>(sql, new { Id = id });
            }
        }

        public async Task<RedTag> GetRedTagByName(string name)
        {
            var sql = @"
                SELECT * FROM [dbo].[RedTags]
                WHERE ItemName = @Name;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<RedTag>(sql, new { Name = name });
            }
        }

        public async Task<int> UpdateRedTag(int id, RedTag updatedRedTag)
        {
            var sql = @"
                UPDATE [dbo].[RedTags]
                SET ItemName = @ItemName,
                Quantity = @Quantity,
                RoomId = @RoomId
                WHERE Id = @Id;
            ";

            updatedRedTag.Id = id;

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, updatedRedTag);
            }
        }

        public DapperContext Context => _context;
    }
}
