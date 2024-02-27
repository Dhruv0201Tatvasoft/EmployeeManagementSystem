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

                MessageBox.Show("Some error occured");
            }


        }
        public bool DoesExist(string Query)
        {
            try
            {
                using (SqlConnection conn = connection.GenrateConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(Query, conn))
                    {

                        SqlDataReader reader = command.ExecuteReader();
                        return reader.HasRows;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Something Went Wrong");
                return false;
            }
        }
        public void UpdateProject(String OldCode, String Code, String Name, DateTime StaringDate, DateTime EndingDate, List<int> TechnologiesId)
        {

            try
            {
                if (OldCode == Code)
                {
                    string sqlQuery = string.Empty;
                    sqlQuery = $"DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode ='{OldCode}' ";
                    this.executeQuery(sqlQuery);
                    sqlQuery = $"UPDATE EmsTblProject SET " +
                        $"Code = '{Code}' ," +
                        $" Name = '{Name}' , " +
                        $"StartingDate = '{StaringDate.ToString("yyyy-MM-dd")}',  " +
                        $"EndingDate = '{EndingDate.ToString("yyyy-MM-dd")}'" +
                        $" WHERE Code ='{OldCode}'  ";
                    this.executeQuery(sqlQuery);
                    foreach (int i in TechnologiesId)
                    {
                        this.executeQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{Code}','{i}')");
                    }
                }
                else if (OldCode != Code && !this.DoesExist($"Select * from EmsTblProject where Code like '{Code}'"))
                {

                    string sqlQuery = string.Empty;
                    sqlQuery = $"DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode ='{OldCode}' ";
                    this.executeQuery(sqlQuery);
                    sqlQuery = $"UPDATE EmsTblProject SET " +
                        $"Code = '{Code}' ," +
                        $" Name = '{Name}' , " +
                        $"StartingDate = '{StaringDate.ToString("yyyy-MM-dd")}',  " +
                        $"EndingDate = '{EndingDate.ToString("yyyy-MM-dd")}'" +
                        $" WHERE Code ='{OldCode}'  ";
                    this.executeQuery(sqlQuery);
                    foreach (int i in TechnologiesId)
                    {
                        this.executeQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{Code}','{i}')");
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
                if (OldCode == Code || (OldCode != Code && !this.DoesExist($"Select * from EmsTblProject where Code like '{Code}'")))
                {
                    string sqlQuery = string.Empty;
                    sqlQuery = $"DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode ='{OldCode}' ";
                    this.executeQuery(sqlQuery);
                    sqlQuery = $"UPDATE  EmsTblProject SET " +
                        $"Code = '{Code}' ," +
                        $" Name = '{Name}' , " +
                        $"StartingDate = '{StaringDate.ToString("yyyy-MM-dd")}',  " +
                        $"EndingDate = NULL" +
                        $" WHERE Code ='{OldCode}' ";
                    this.executeQuery(sqlQuery);
                    foreach (int i in TechnologiesId)
                    {
                        this.executeQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{Code}','{i}')");
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
        public void UpdateTechnologyName(string NewTechnologyName, string OldTechnologyName)
        {
            if (!DoesExist($"Select * from EmsTblTechnology where name like '{NewTechnologyName}'"))
            {
                string Query = $"Update EmsTblTechnology SET Name = '{NewTechnologyName}' where name like '{OldTechnologyName}'";
                this.executeQuery(Query);
            }
            else
            {
                MessageBox.Show($" {NewTechnologyName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }
        public void UpdateSkillName(string NewSkillName, string OldSkillName)
        {
            if (!DoesExist($"Select * from EmsTblSkill where name like '{NewSkillName}'"))
            {
                string Query = $"Update EmsTblSkill SET Name = '{NewSkillName}' where name like '{OldSkillName}'";
                this.executeQuery(Query);
            }
            else
            {
                MessageBox.Show($" {NewSkillName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }
    }
}
