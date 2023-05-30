using Microsoft.Data.SqlClient;
using System.Data;

namespace _5s.Context
{
    public class DapperContext
    {
        private string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer")
                 ?? throw new ArgumentNullException(nameof(configuration), "Connection string is null.");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
