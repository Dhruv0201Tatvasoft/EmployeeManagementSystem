using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Models;
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
        public bool ExecuteQuery(string query)
        {
            try
            {

                SqlConnection conn = connection.GenrateConnection();
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                {
                    MessageBox.Show("Error in inserting data to database");
                    return false;
                }
            }

        }
        public bool DoesExist(String query)
        {
            try
            {
                using (SqlConnection conn = connection.GenrateConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
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

        public bool InsertNewProject(ProjectModel project)
        {
            if (!this.DoesExist($"Select * from EmsTblProject where code = '{project.Code}'"))
            {
                this.ExecuteQuery($"Insert into EmsTblProject (code,name,StartingDate,EndingDate) values ("
                    + $"'{project.Code}',"
                    + $"'{project.Name}',"
                    + $"'{project.StartingDate.ToString("yyyy-MM-dd")}',"
                    + $"'{project.EndingDate.Value.ToString("yyyy-MM-dd")}')");

                foreach (int i in project.AssociatedTechnologies)
                {
                    this.ExecuteQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{project.Code}','{i}')");
                }
                return true;
            }
            else
            {
                MessageBox.Show($"There is Already Project With The code {project.Code}");
                return false;
            }


        }

        public bool InsertNewProjectWithOutEndingDate(ProjectModel project)
        {
            if (!this.DoesExist($"Select * from EmsTblProject where code = '{project.Code}' "))
            {
                string query = $"Insert into EmsTblProject (code,name,StartingDate,EndingDate) values (" +
                $"'{project.Code}'," +
                $"'{project.Name}'," +
                $"'{project.StartingDate.ToString("yyyy-MM-dd")}'," +
                $"NULL)";

                this.ExecuteQuery(query);
                foreach (int i in project.AssociatedTechnologies)
                {
                    this.ExecuteQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{project.Code}','{i}')");
                }
                return true;
            }
            else
            {
                MessageBox.Show($"There is Already Project With The code {project.Code}");
                return false;
            }
        }
        public void InsertEmployeeToProject(String projectCode, String employeeCode, string employeeName)
        {
            if (!this.DoesExist($"select * from EmsTblEmployeeAssociatedToProject where ProjectCode ='{projectCode}' AND EmployeeCode ='{employeeCode}'"))
            {
                string query = $"Insert into EmsTblEmployeeAssociatedToProject (EmployeeCode,ProjectCode) Values ('{employeeCode}','{projectCode}')";
                this.ExecuteQuery(query);
            }
            else
            {
                MessageBox.Show($"{employeeName} is already added to this project", "Alert", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        public void InsertTechnology(String technologyName)
        {
            if (!DoesExist($"select * from EmsTblTechnology where Name like '{technologyName}'"))
            {
                string query = $"Insert into EmsTblTechnology (Name) Values ('{technologyName}')";
                this.ExecuteQuery(query);
            }
            else
            {
                MessageBox.Show($"{technologyName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        public void InsertSkill(String skillName)
        {
            if (!DoesExist($"select * from EmsTblSkill where Name like '{skillName}'"))
            {
                string query = $"Insert into EmsTblSkill (Name) Values ('{skillName}')";
                this.ExecuteQuery(query);
            }
            else
            {
                MessageBox.Show($"{skillName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        public bool InsertEmployee(EmployeeModel employee)
        {
            if (!DoesExist($"select * from EmsTblEmployee where Code like '{employee.Code}'"))
            {
                string query = $"INSERT INTO EmsTblEmployee (Code, FirstName, LastName, Email, Password, [Designation], [Department], JoiningDate, ReleaseDate, DOB, ContactNumber, Gender, " +
                    $"MaritalStatus, PresentAddress, PermanentAdress) VALUES " +
                 $"('{employee.Code}','{employee.FirstName}','{employee.LastName}','{employee.Email}','{employee.Password}','{employee.Designation}','{employee.Department}','" +
                 $"{employee.JoiningDate.ToString("yyyy-MM-dd")}','{employee.ReleaseDate?.ToString("yyyy-MM-dd")}','{employee.DOB.ToString("yyyy-MM-dd")}','{employee.ContactNumber}'," +
                 $"'{employee.Gender}','{employee.MaritalStauts}','{employee.PresentAddress}','{employee.PermanentAddress}')";
                this.ExecuteQuery(query);
                return true;

            }
            else
            {
                MessageBox.Show($"There is aleady an employee with Employee Code {employee.Code}", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
        }
        public bool InsertEmployeeWithoutReleaseDate(EmployeeModel employee)
        {
            if (!DoesExist($"select * from EmsTblEmployee where Code like '{employee.Code}'"))
            {
                string query = $"INSERT INTO EmsTblEmployee (Code, FirstName, LastName, Email, Password, [Designation], [Department], JoiningDate, DOB, ContactNumber, Gender, " +
                    $"MaritalStatus, PresentAddress, PermanentAdress) VALUES " +
                 $"('{employee.Code}','{employee.FirstName}','{employee.LastName}','{employee.Email}','{employee.Password}','{employee.Designation}','{employee.Department}','" +
                 $"{employee.JoiningDate.ToString("yyyy-MM-dd")}','{employee.ReleaseDate?.ToString("yyyy-MM-dd")}','{employee.ContactNumber}'," +
                 $"'{employee.Gender}','{employee.MaritalStauts}','{employee.PresentAddress}','{employee.PermanentAddress}')";
                this.ExecuteQuery(query);
                return true;
            }
            else
            {
                MessageBox.Show($"There is aleady an employee with Employee Code {employee.Code}", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
        }

        public bool InsertEducationDetails(EmployeeEducationModel educationModel, String code)
        {
            string query = $"insert into EmsTblEmployeeEducation (EmployeeCode,Qualification,Board,Institute,State,PassingYear,Percentage) values " +
                   $"('{code}','{educationModel.Qualification}','{educationModel.BoardUniversity}','{educationModel.InstituteName}'," +
                   $"'{educationModel.State}','{educationModel.PassingYear}','{educationModel.Percentage}') ";
            bool didExecute = this.ExecuteQuery(query);
            return didExecute;
        }
        public bool InsertExperienceDetails(EmployeeExperienceModel experienceModel, String code)
        {
            string Query = $"insert into EmsTblEmployeeExperience (EmployeeCode,Organization,FromDate,ToDate,Designation) values " +
                   $"('{code}','{experienceModel.Organization}','{experienceModel.FromDate.Value.ToString("yyyy-MM-dd")}','{experienceModel.ToDate.Value.ToString("yyyy-MM-dd")}'," +
                   $"'{experienceModel.Designation}') ";
            bool didExecute = this.ExecuteQuery(Query);
            return didExecute;

        }

        public void InsertProjectToEmployee(string projectCode, string projectName, string employeeCode)
        {
            if (!this.DoesExist($"select * from EmsTblEmployeeAssociatedToProject where ProjectCode ='{projectCode}' AND EmployeeCode ='{employeeCode}'"))
            {
                string Query = $"Insert into EmsTblEmployeeAssociatedToProject (EmployeeCode,ProjectCode) Values ('{employeeCode}','{projectCode}')";
                this.ExecuteQuery(Query);
            }
            else
            {
                MessageBox.Show($"{projectName} is already assigned to this Employee", "Alert", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
