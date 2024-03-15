using System.Data.SqlClient;

namespace EmployeeManagementSystem.Database
{
    public class GetConnection
    {
        private string connectionString;


        public GetConnection()
        {
            connectionString = @"Server=192.168.0.5;Database=dhruvkhoradiya_db;User Id=dhruv4;password=Th3xNXJX;";
        }
        public SqlConnection GenrateConnection()
        {
            return new SqlConnection(connectionString);
        }
        public string GetConnectionString()
        {
            return connectionString;
        }

    }
}
