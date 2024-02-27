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
                
                {
                    MessageBox.Show("Some error occured");
                }
            }
           
        }
        public bool DoesExist(String Query)
        {
            try
            {
                using (SqlConnection conn = connection.GenrateConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(Query, conn))
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

        public bool InsertNewProject(String Code,String Name,DateTime StartingDate ,DateTime EndingDate,List<int>TechnologiesId)
        {
            if (!this.DoesExist($"Select * from EmsTblProject where Code = '{Code}'"))
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
                return true;
            }
            else
            {
                MessageBox.Show($"There is Already Project With The Code {Code}");
                return false;
            }
            
    
        }

        public bool InsertNewProject(string Code, string Name, DateTime StartingDate, List<int> TechnologiesId)
        {
            if (!this.DoesExist($"Select * from EmsTblProject where Code = '{Code}' "))
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
                return true;
            }
            else
            {
                MessageBox.Show($"There is Already Project With The Code {Code}");
                return false;
            }
        }
        public void InsertEmployeeToProject(String ProjectCode,String EmployeeCode, string EmployeeName)
        {
            if (!this.DoesExist($"select * from EmsTblEmployeeAssociatedToProject where ProjectCode ='{ProjectCode}' AND EmployeeCode ='{EmployeeCode}'"))
            {
                string Query = $"Insert into EmsTblEmployeeAssociatedToProject (EmployeeCode,ProjectCode) Values ('{EmployeeCode}','{ProjectCode}')";
                this.executeQuery(Query);
            }
            else
            {
                MessageBox.Show($"{EmployeeName} is already added to this project","Alert",MessageBoxButton.OK,MessageBoxImage.None,MessageBoxResult.OK,MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        public void InsertTechnology (String TechnologyName)
        {
            if(!DoesExist($"select * from EmsTblTechnology where Name like '{TechnologyName}'"))
            {
                string Query = $"Insert into EmsTblTechnology (Name) Values ('{TechnologyName}')";
                this.executeQuery(Query);
            }
            else
            {
                MessageBox.Show($"{TechnologyName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        public void InsertSkill(String SkillName)
        {
            if (!DoesExist($"select * from EmsTblSkill where Name like '{SkillName}'"))
            {
                string Query = $"Insert into EmsTblSkill (Name) Values ('{SkillName}')";
                this.executeQuery(Query);
            }
            else
            {
                MessageBox.Show($"{SkillName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
