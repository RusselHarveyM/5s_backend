using _5s.Context;
using _5s.Model;
using Dapper;

namespace _5s.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly DapperContext _context;

        public BuildingRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateBuilding(Building building)
        {
            var sql = @"
                INSERT INTO Buildings (BuildingName, BuildingCode)
                VALUES (@BuildingName, @BuildingCode);
                SELECT CAST(SCOPE_IDENTITY() AS INT);
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(sql, building);
            }
        }

        public async Task DeleteBuilding(int id)
        {
            var sql = @"
                DELETE FROM Buildings
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Building>> GetAllBuildings()
        {
            var sql = @"
                SELECT * FROM Buildings;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Building>(sql);
            }
        }

        public async Task<Building> GetBuildingById(int id)
        {
            var sql = @"
                SELECT * FROM Buildings
                WHERE Id = @Id;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Building>(sql, new { Id = id });
            }
        }

        public async Task<Building> GetBuildingByName(string name)
        {
            var sql = @"
                SELECT * FROM Buildings
                WHERE BuildingName = @Name;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Building>(sql, new { Name = name });
            }
        }

        public async Task<Building> GetBuildingByCode(string code)
        {
            var sql = @"
                SELECT * FROM Buildings
                WHERE BuildingCode = @Code;
            ";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Building>(sql, new { Code = code });
            }
        }

        public async Task<int> UpdateBuilding(int id, Building updatedBuilding)
        {
            var sql = @"
                UPDATE Buildings
                SET BuildingName = @BuildingName,
                    BuildingCode = @BuildingCode
                WHERE Id = @Id;
            ";

            updatedBuilding.Id = id;

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, updatedBuilding);
            }
        }

        public DapperContext Context => _context;

    }
}
