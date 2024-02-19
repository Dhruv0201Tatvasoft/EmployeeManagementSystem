using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace EmployeeManagementSystem.Database
{

    class InsertData
    {
        private GetConnection connection = new GetConnection();
        public void executeQuery(string sql)
        {
            try
            {
                SqlConnection conn = connection.GenrateConnection();
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

        public void InsertNewProject(String Code,String Name,DateTime StartingDate ,DateTime EndingDate,List<int>TechnologiesId)
        {
            this.executeQuery($"Insert into EmsTblProject (Code,Name,StartingDate,EndingDate) values (" +
                $"'{Code}'," +
                $"'{Name}'," +
                $"'{StartingDate.ToString("yyyy-MM-dd")}'," +
                $"'{EndingDate.ToString("yyyy-MM-dd")}')");

            foreach (int i in TechnologiesId)
            {
                this.executeQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{Code}','{i}')");
            }
        }

        public void InsertNewProject(string Code, string Name, DateTime StartingDate, List<int> TechnologiesId)
        {
            this.executeQuery($"Insert into EmsTblProject (Code,Name,StartingDate,EndingDate) values (" +
            $"'{Code}'," +
                $"'{Name}'," +
                $"'{StartingDate.ToString("yyyy-MM-dd")}'," +
                $"NULL)");

            foreach (int i in TechnologiesId)
            {
                this.executeQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{Code}','{i}')");
            }
        }
    }





}
