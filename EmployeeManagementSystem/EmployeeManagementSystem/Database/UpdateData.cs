using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementSystem.Database
{
    internal class UpdateData
    {
        private GetConnection connection = new GetConnection();
        public void executeQuery(string sql, string model)
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
                    MessageBox.Show($"There is already an entry with Same {model} Code", "Warning");
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

                        SqlDataReader reader = command.ExecuteReader();
                        return reader.HasRows;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"There is already Entry with Code {Code}");
                return false;
            }
        }
        public void UpdateProject(String OldCode, String Code, String Name, DateTime StaringDate, DateTime EndingDate, List<int> TechnologiesId )
        {
            
            try
            {
                if (OldCode == Code)
                {
                    string sqlQuery = string.Empty;
                    sqlQuery = $"DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode ='{OldCode}' ";
                    this.executeQuery(sqlQuery, "Project");
                    sqlQuery = $"UPDATE EmsTblProject SET " +
                        $"Code = '{Code}' ," +
                        $" Name = '{Name}' , " +
                        $"StartingDate = '{StaringDate.ToString("yyyy-MM-dd")}',  " +
                        $"EndingDate = '{EndingDate.ToString("yyyy-MM-dd")}'" +
                        $" WHERE Code ='{OldCode}'  ";
                    this.executeQuery(sqlQuery, "Project");
                    foreach (int i in TechnologiesId)
                    {
                        this.executeQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{Code}','{i}')", "Project");
                    }
                }
               else if ( OldCode != Code && !this.DoesExist(Code, "EmsTblProject", "Code"))
                {

                    string sqlQuery = string.Empty;
                    sqlQuery = $"DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode ='{OldCode}' ";
                    this.executeQuery(sqlQuery, "Project");
                    sqlQuery = $"UPDATE EmsTblProject SET " +
                        $"Code = '{Code}' ," +
                        $" Name = '{Name}' , " +
                        $"StartingDate = '{StaringDate.ToString("yyyy-MM-dd")}',  " +
                        $"EndingDate = '{EndingDate.ToString("yyyy-MM-dd")}'" +
                        $" WHERE Code ='{OldCode}'  ";
                    this.executeQuery(sqlQuery, "Project");
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
            catch (Exception)
            {
                MessageBox.Show("Some Unexpected Error Occured", "Warning");
            }
            
        }

        public void UpdateProject(String OldCode, String Code, String Name, DateTime StaringDate, List<int> TechnologiesId)
        {
            try
            {
                if (OldCode == Code || (OldCode != Code && !this.DoesExist(Code, "EmsTblProject", "Code")))
                {
                    string sqlQuery = string.Empty;
                    sqlQuery = $"DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode ='{OldCode}' ";
                    this.executeQuery(sqlQuery, "Project");
                    sqlQuery = $"UPDATE  EmsTblProject SET " +
                        $"Code = '{Code}' ," +
                        $" Name = '{Name}' , " +
                        $"StartingDate = '{StaringDate.ToString("yyyy-MM-dd")}',  " +
                        $"EndingDate = NULL" +
                        $" WHERE Code ='{OldCode}' ";
                    this.executeQuery(sqlQuery, "Project");
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
            catch (Exception)
            {
                MessageBox.Show("Some Unexpected Error Occured", "Warning");
            }

        }
    }
}
