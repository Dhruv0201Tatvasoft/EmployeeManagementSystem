using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Models;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementSystem.Database
{
    internal class UpdateData
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

                MessageBox.Show("Some error occured");
                return false;
            }


        }
        public bool DoesExist(string query)
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
                MessageBox.Show($"Error in updating data to dabase");
                return false;
            }
        }
        public void UpdateProject(String OldCode,ProjectModel project)
        {
            try
            {
                if (OldCode == project.Code || (OldCode != project.Code && !this.DoesExist($"Select * from EmsTblProject where Code like '{project.Code}'")))
                {
                    string query = string.Empty;
                    query = $"DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode ='{OldCode}' ";
                    this.ExecuteQuery(query);
                    query = $"UPDATE  EmsTblProject SET " +
                         $"Code = '{project.Code}' ," +
                         $" Name = '{project.Name}' , " +
                         $"StartingDate = '{project.StartingDate.ToString("yyyy-MM-dd")}',  " +
                         $"EndingDate = '{project.EndingDate.Value.ToString("yyyy-MM-dd")}'" +
                         $" WHERE Code ='{OldCode}' ";
                    this.ExecuteQuery(query);
                    foreach (int i in project.AssociatedTechnologies)
                    {
                        this.ExecuteQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{project.Code}','{i}')");
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in updating to database");
            }

        }

        public void UpdateProjectWithoutEndingDate(String OldCode,ProjectModel project)
        {
            try
            {
                if (OldCode == project.Code || (OldCode != project.Code && !this.DoesExist($"Select * from EmsTblProject where Code like '{project.Code}'")))
                {
                    string query = string.Empty;
                    query = $"DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode ='{OldCode}' ";
                    this.ExecuteQuery(query);
                        query = $"UPDATE  EmsTblProject SET " +
                        $"Code = '{project.Code}' ," +
                        $" Name = '{project.Name}' , " +
                        $"StartingDate = '{project.StartingDate.ToString("yyyy-MM-dd")}',  " +
                        $"EndingDate = NULL" +
                        $" WHERE Code like '{OldCode}' ";
                    this.ExecuteQuery(query);
                    foreach (int i in project.AssociatedTechnologies)
                    {
                        this.ExecuteQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{project.Code}','{i}')");
                    }
                }

                else
                {
                    MessageBox.Show($"There is Already Project With The Code {project.Code}");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some Unexpected Error Occured", "Warning");
            }

        }
        public void UpdateTechnologyName(string newTechnologyName, string oldTechnologyName)
        {
            if (!DoesExist($"Select * from EmsTblTechnology where name like '{newTechnologyName}'"))
            {
                string query = $"Update EmsTblTechnology SET Name = '{newTechnologyName}' where name like '{oldTechnologyName}'";
                this.ExecuteQuery(query);
            }
            else
            {
                MessageBox.Show($" {newTechnologyName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }
        public void UpdateSkillName(string newSkillName, string oldSkillName)
        {
            if (!DoesExist($"Select * from EmsTblSkill where name like '{newSkillName}'"))
            {
                string query = $"Update EmsTblSkill SET Name = '{newSkillName}' where name like '{oldSkillName}'";
                this.ExecuteQuery(query);
            }
            else
            {
                MessageBox.Show($" {newSkillName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }
        public bool UpdateEmployeeEducation(EmployeeEducationModel newModel, EmployeeEducationModel oldModel, String code)
        {
            string query = $"Update EmsTblEmployeeEducation SET Qualification = '{newModel.Qualification}' , Board = '{newModel.BoardUniversity}' ," +
                 $"Institute = '{newModel.InstituteName}' , State = '{newModel.State}' , PassingYear = '{newModel.PassingYear}' , Percentage = '{newModel.Percentage}' " +
                 $"Where EmployeeCode like '{code}' AND Qualification like '{oldModel.Qualification}' AND Board like '{oldModel.BoardUniversity}' AND" +
                 $" Institute like '{oldModel.InstituteName}' AND State like '{oldModel.State}' AND PassingYear like '{oldModel.PassingYear}'" +
                 $"AND Percentage like '{oldModel.Percentage}' ";
            bool didExecute = this.ExecuteQuery(query);
            return didExecute;
        }
        public bool UpdateEmployeeExperience(EmployeeExperienceModel newModel, EmployeeExperienceModel oldModel, String code)
        {
            string query = $"Update EmsTblEmployeeExperience SET Organization = '{newModel.Organization}' , FromDate = '{newModel.FromDate.Value.ToString("yyyy-MM-dd")}' ," +
                 $"ToDate = '{newModel.ToDate.Value.ToString("yyyy-MM-dd")}' , Designation = '{newModel.Designation}' " +
                 $"Where EmployeeCode like '{code}' AND Organization like '{oldModel.Organization}' AND FromDate = '{oldModel.FromDate.Value.ToString("yyyy-MM-dd")}' AND" +
                 $" ToDate = '{oldModel.ToDate.Value.ToString("yyyy-MM-dd")}' AND Designation like '{oldModel.Designation}' ";
            bool didExecute = this.ExecuteQuery(query);
            return didExecute;
        }
        public bool UpdateEmployee(string oldCode,EmployeeModel employee)
        {
            if (oldCode == employee.Code || (oldCode != employee.Code && !this.DoesExist($"Select * from EmsTblEmployee where Code like '{employee.Code}'")))
            {
                string Query = $"UPDATE EmsTblEmployee SET Code = '{employee.Code}', FirstName = '{employee.FirstName}', LastName = '{employee.LastName}',Email = '{employee.Email}', " +
                    $"Password = '{employee.Password}', Designation = '{employee.Designation}', Department = '{employee.Department}', JoiningDate = '{employee.JoiningDate.ToString("yyyy-MM-dd")}', " +
                    $"DOB = '{employee.DOB.ToString("yyyy-MM-dd")}', ContactNumber = '{employee.ContactNumber}', Gender = '{employee.Gender}', MaritalStatus = '{employee.MaritalStauts}'," +
                    $" PresentAddress = '{employee.PresentAddress}', PermanentAdress = '{employee.PermanentAddress}' WHERE Code = '{oldCode}'";
                this.ExecuteQuery(Query);
                return true;
            }
            else
            {
                MessageBox.Show($"There is aleady an employee with Employee Code {employee.Code}", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
        }

        public bool UpdateEmployee(String OldCode, String Code, String FirstName, String LastName, String Email, String Password, String Designation, String Department, DateTime JoiningDate,DateTime ReleaseDate ,DateTime DOB, String ContactNumber, String Gender, String MaritalStatus, String PresentAddress, String PermanentAdress)
        {
            if (OldCode == Code || (OldCode != Code && !this.DoesExist($"Select * from EmsTblEmployee where Code like '{Code}'")))
            {
                string Query = $"UPDATE EmsTblEmployee SET Code = '{Code}', FirstName = '{FirstName}', LastName = '{LastName}',Email = '{Email}', " +
                    $"Password = '{Password}', Designation = '{Designation}', Department = '{Department}', JoiningDate = '{JoiningDate.ToString("yyyy-MM-dd")}', " +
                    $"ReleaseDate = '{ReleaseDate.ToString("yyyy-MM-dd")}', DOB = '{DOB.ToString("yyyy-MM-dd")}', ContactNumber = '{ContactNumber}', Gender = '{Gender}', MaritalStatus = '{MaritalStatus}', PresentAddress = '{PresentAddress}', " +
                    $"PermanentAdress = '{PermanentAdress}' WHERE Code = '{OldCode}'";
                this.ExecuteQuery(Query);
                return true;
            }
            else
            {
                MessageBox.Show($"There is aleady an employee with Employee Code {Code}", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
        }
    }
}
