using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementSystem.Database
{

    class InsertData
    {
        private GetConnection connection = new GetConnection();
        public void executeQuery(string sql)
        {
            try
            {
                SqlConnection conn = connection.GenrateConnection() ;
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                /// Exeption number 2627 belongs to Duplicate primary key exception. 
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Duplicate Data");
                }
                else
                {
                    MessageBox.Show("Some error occured");
                }
            }
        }

        public DataTable GetProjectData()
        {
            DataTable dt = new DataTable();
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand("SELECT * FROM EmsTblProject ", conn))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }
        public DataTable GetProjectSearchData(String Code,String Name,DateTime StartingDate,  DateTime EndingDate)
        {
            DataTable dt = new DataTable();
            string Query = "Select * from EmsTblProject where 1=1";

            if (!String.IsNullOrEmpty(Code))
            {
                Query += $" AND Code like '{Code}%'";
            }
            if (!String.IsNullOrEmpty(Name))
            {
                Query += $" AND Name like '{Name}%' ";
            }
            if (StartingDate.Date != new DateTime(1990, 01, 01))
            {
                Query += $" AND StartingDate='{StartingDate.ToString("yyyy-MM-dd")}'";
            }
            if (EndingDate.Date != DateTime.Now.Date)
            {
                Query += $" AND EndingDate='{EndingDate.ToString("yyyy-MM-dd")}'";
            }
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(Query, conn))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }


    }





}
