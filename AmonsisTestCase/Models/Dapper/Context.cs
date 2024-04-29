using Microsoft.Data.SqlClient;
using System.Data;

namespace AmonsisTestCase.Models.Dapper
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            // SQLString'i burada almış olduk.
            _connectionString = _configuration.GetConnectionString("connection");
        }

        // SQL connection nesnemizi oluşturalım
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
