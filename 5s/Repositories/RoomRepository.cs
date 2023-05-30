using _5s.Context;
using _5s.Model;
using Dapper;

namespace _5s.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DapperContext _context;

        public RoomRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateRoom(Room room)
        {
            var sql = @"
                INSERT INTO [dbo].[Rooms] ([BuildingId], [RoomNumber], [Image])
                VALUES ( @BuildingId, @RoomNumber, @Image);
                SELECT CAST(SCOPE_IDENTITY() AS INT);
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(sql, room);
            }
        }

        public async Task DeleteRoom(int id)
        {
            var sql = @"
                DELETE FROM [dbo].[Rooms]
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var sql = @"
                SELECT * FROM [dbo].[Rooms];
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Room>(sql);
            }
        }

        public async Task<Room> GetRoomById(int id)
        {
            var sql = @"
                SELECT * FROM [dbo].[Rooms]
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Room>(sql, new { Id = id });
            }
        }

        public async Task<Room> GetRoomByRoomNumber(string roomNumber)
        {
            var sql = @"
                SELECT * FROM [dbo].[Rooms]
                WHERE RoomNumber = @RoomNumber;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Room>(sql, new { RoomNumber = roomNumber });
            }
        }

        public async Task<int> UpdateRoom(int id, Room updatedRoom)
        {
            var sql = @"
                UPDATE [dbo].[Rooms]
                SET RoomNumber = @RoomNumber,
                Image = @Image
                WHERE Id = @Id;
            ";

            updatedRoom.Id = id;

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, updatedRoom);
            }
        }

        public DapperContext Context => _context;
    }
}
