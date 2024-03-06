using EmployeeManagementSystem.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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

                        SqlDataReader reader = command.ExecuteReader();
                        return reader.HasRows;
                    }
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public bool InsertNewProject(String Code, String Name, DateTime StartingDate, DateTime EndingDate, List<int> TechnologiesId)
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
        public void InsertEmployeeToProject(String ProjectCode, String EmployeeCode, string EmployeeName)
        {
            if (!this.DoesExist($"select * from EmsTblEmployeeAssociatedToProject where ProjectCode ='{ProjectCode}' AND EmployeeCode ='{EmployeeCode}'"))
            {
                string Query = $"Insert into EmsTblEmployeeAssociatedToProject (EmployeeCode,ProjectCode) Values ('{EmployeeCode}','{ProjectCode}')";
                this.executeQuery(Query);
            }
            else
            {
                MessageBox.Show($"{EmployeeName} is already added to this project", "Alert", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        public void InsertTechnology(String TechnologyName)
        {
            if (!DoesExist($"select * from EmsTblTechnology where Name like '{TechnologyName}'"))
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

        public bool InsertEmployee(String Code, String FirstName, String LastName, String Email, String Password, String Designation, String Department, DateTime JoiningDate, DateTime ReleaseDate, DateTime DOB, String ContactNumber, String Gender, String MaritalStatus, String PresentAddress, String PermanentAdress)
        {
            if (!DoesExist($"select * from EmsTblEmployee where Code like '{Code}'"))
            {
                string Query = $"INSERT INTO EmsTblEmployee (Code, FirstName, LastName, Email, Password, [Designation], [Department], JoiningDate, ReleaseDate, DOB, ContactNumber, Gender, MaritalStatus, PresentAddress, PermanentAdress) VALUES " +
                    $"('{Code}','{FirstName}','{LastName}','{Email}','{Password}','{Designation}','{Department}','{JoiningDate.ToString("yyyy-MM-dd")}','{ReleaseDate.ToString("yyyy-MM-dd")}','{DOB.ToString("yyyy-MM-dd")}','{ContactNumber}','{Gender}','{MaritalStatus}','{PresentAddress}','{PermanentAdress}')";
                this.executeQuery(Query);
                return true;
            }
            else
            {
                MessageBox.Show($"{Code + " - " + FirstName + LastName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
        }
        public bool InsertEmployee(String Code, String FirstName, String LastName, String Email, String Password, String Designation, String Department, DateTime JoiningDate, DateTime DOB, String ContactNumber, String Gender, String MaritalStatus, String PresentAddress, String PermanentAdress)
        {
            if (!DoesExist($"select * from EmsTblEmployee where Code like '{Code}'"))
            {
                string Query = $"INSERT INTO EmsTblEmployee (Code, FirstName, LastName, Email, Password, [Designation], [Department], JoiningDate, DOB, ContactNumber, Gender, MaritalStatus, PresentAddress, PermanentAdress) VALUES " +
                    $"('{Code}','{FirstName}','{LastName}','{Email}','{Password}','{Designation}','{Department}','{JoiningDate.ToString("yyyy-MM-dd")}','{DOB.ToString("yyyy-MM-dd")}','{ContactNumber}','{Gender}','{MaritalStatus}','{PresentAddress}','{PermanentAdress}')";
                this.executeQuery(Query);
                return true;
            }
            else
            {
                MessageBox.Show($"{Code + " - " + FirstName + LastName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
        }

        public void InsertEducationDetails(EmployeeEducationModel educationModel, String Code)
        {
            string Query = $"insert into EmsTblEmployeeEducation (EmployeeCode,Qualification,Board,Institute,State,PassingYear,Percentage) values " +
                   $"('{Code}','{educationModel.Qualification}','{educationModel.BoardUniversity}','{educationModel.InstituteName}'," +
                   $"'{educationModel.State}','{educationModel.PassingYear}','{educationModel.Percentage}') ";
            this.executeQuery(Query);
        }
        public void InsertExperienceDetails(EmployeeExperienceModel experienceModel, String Code)
        {
            string Query = $"insert into EmsTblEmployeeExperience (EmployeeCode,Organization,FromDate,ToDate,Designation) values " +
                   $"('{Code}','{experienceModel.Organization}','{experienceModel.FromDate.Value.ToString("yyyy-MM-dd")}','{experienceModel.ToDate.Value.ToString("yyyy-MM-dd")}'," +
                   $"'{experienceModel.Designation}') ";
            this.executeQuery(Query);
        }

    }
}
