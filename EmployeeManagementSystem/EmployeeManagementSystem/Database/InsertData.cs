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
        public void executeQuery(string sql,string model)
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
                if (ex.Number == 2627)
                {
                    MessageBox.Show($"There is already an entry with Same {model} Code","Warning");
                }
                else
                {
                    MessageBox.Show("Some error occured");
                }
            }
           
        }
        public bool DoesExist(String Code, String TblName, string columnName)
        {
            string SqlQuery = $"Select * from  {TblName} where {columnName} = '{Code}' ";
            try
            {
                using (SqlConnection conn = connection.GenrateConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(SqlQuery, conn))
                    {

                        SqlDataReader reader =command.ExecuteReader(); 
                        return reader.HasRows;
                    }
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public void InsertNewProject(String Code,String Name,DateTime StartingDate ,DateTime EndingDate,List<int>TechnologiesId)
        {
            if (!this.DoesExist(Code, "EmsTblProject", "Code"))
            {
                this.executeQuery($"Insert into EmsTblProject (Code,Name,StartingDate,EndingDate) values (" +
                $"'{Code}'," +
                $"'{Name}'," +
                $"'{StartingDate.ToString("yyyy-MM-dd")}'," +
                $"'{EndingDate.ToString("yyyy-MM-dd")}')", "Project");

                foreach (int i in TechnologiesId)
                {
                    this.executeQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{Code}','{i}')", "Project");
                }
            }
            else
            {
                MessageBox.Show($"There is Already Project With The Code {Code}");
            }
            
    
        }

        public void InsertNewProject(string Code, string Name, DateTime StartingDate, List<int> TechnologiesId)
        {
            if (!this.DoesExist(Code, "EmsTblProject", "Code"))
            {
                this.executeQuery($"Insert into EmsTblProject (Code,Name,StartingDate,EndingDate) values (" +
            $"'{Code}'," +
                $"'{Name}'," +
                $"'{StartingDate.ToString("yyyy-MM-dd")}'," +
                $"NULL)", "Project");

                foreach (int i in TechnologiesId)
                {
                    this.executeQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{Code}','{i}')", "Project");
                }
            }
            else
            {
                MessageBox.Show($"There is Already Project With The Code {Code}");
            }
        }
    }





}
