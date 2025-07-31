using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperDayProject.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration _configuration)
        {
          _configuration = _configuration;
          _connectionString = _configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
     

    }
}
