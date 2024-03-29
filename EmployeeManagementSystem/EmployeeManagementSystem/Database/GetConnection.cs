﻿using System.Data.SqlClient;

namespace EmployeeManagementSystem.Database
{
    public class GetConnection
    {
        private string connectionString;


        public GetConnection()
        {
            connectionString = @"Server=192.168.0.5;Database=dhruvkhoradiya_db;User Id=dhruv4;password=Th3xNXJX;";
        }

        /// <summary>
        /// Generates connection to database.
        /// </summary
        public SqlConnection GenerateConnection()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// return connection string to connect to database.
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return connectionString;
        }

    }
}
