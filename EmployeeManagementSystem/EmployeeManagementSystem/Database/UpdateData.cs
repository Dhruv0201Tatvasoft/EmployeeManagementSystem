using EmployeeManagementSystem.Model;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Automation.Peers;

namespace EmployeeManagementSystem.Database
{
    internal class UpdateData
    {
        private GetConnection connection = new GetConnection();
        private bool ExecuteQuery(SqlCommand command)
        {
            try
            {
                using (SqlConnection conn = connection.GenrateConnection())
                {
                    command.Connection = conn;
                    conn.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException )
            {
                {
                    MessageBox.Show("Error in updating data to database");
                    return false;
                }
                
            }

        }
        private bool DoesExist(SqlCommand command)
        {
            try
            {
                using (SqlConnection conn = connection.GenrateConnection())
                {
                    command.Connection = conn;
                    conn.Open();
                    using (command)
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        return reader.HasRows;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong", "Error");
                return false;
            }
        }
        
        public bool UpdateProject(String oldCode, ProjectModel project, bool endingDateHasValue = true)
        {
            string query = $"Select * from EmsTblProject where Code LIKE @Code";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Code", project.Code);
            if (oldCode == project.Code || (oldCode != project.Code && !this.DoesExist(command)))
            {
                query = "DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode = @OldCode"; 
                command.CommandText = query;
                command.Parameters.AddWithValue("@OldCode", oldCode);
                ExecuteQuery(command);             
                query = "UPDATE EmsTblProject SET Code = @Code, Name = @Name, StartingDate = @StartingDate, EndingDate = " +
                    "@EndingDate WHERE Code = @OldCode";
                command.Parameters.Clear();
                command.CommandText = query;
                command.Parameters.AddWithValue("@Code", project.Code);
                command.Parameters.AddWithValue("@Name", project.Name);
                command.Parameters.AddWithValue("@StartingDate", project.StartingDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@EndingDate", endingDateHasValue ? project.EndingDate?.ToString("yyyy-MM-dd") : DBNull.Value);
                command.Parameters.AddWithValue("@OldCode", oldCode);
                bool didSave = ExecuteQuery(command);
                if (didSave) InsertAssociatedTechnologies(project);
                return didSave;
            }
            else
            {
                MessageBox.Show($"Project with code {project.Code} already exist in database.", "Error");
                return false;
            }
        }
        private void InsertAssociatedTechnologies(ProjectModel project)
        {
            string query = "INSERT INTO EmsTblTechnologyForProject(ProjectCode, TechnologyId) " +
                           "VALUES (@Code, @TechnologyId)";
            foreach (int technologyId in project.AssociatedTechnologies)
            {
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Code", project.Code);
                    command.Parameters.AddWithValue("@TechnologyId", technologyId);
                    ExecuteQuery(command);
                }
            }
        }
        public void UpdateTechnologyName(string newTechnologyName, string oldTechnologyName)
        {
            string query = "SELECT * FROM EmsTblTechnology WHERE Name LIKE @TechnologyName";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@TechnologyName", newTechnologyName);
            if (!DoesExist(command))
            {
                query = "UPDATE EmsTblTechnology SET Name = @NewTechnologyName WHERE Name LIKE @OldTechnologyName";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@NewTechnologyName", newTechnologyName);
                command.Parameters.AddWithValue("@OldTechnologyName", oldTechnologyName);
                ExecuteQuery(command);
            }
            else
            {
                MessageBox.Show($" {newTechnologyName} already exist in data", "Error");

            }
        }
        public void UpdateSkillName(string newSkillName, string oldSkillName)
        {
            string query = "SELECT * FROM EmsTblSkill WHERE Name LIKE @SkillName";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@SkillName", newSkillName);
            if (!DoesExist(command))
            {
                query = $"Update EmsTblSkill SET Name = @NewSkillName where Name LIKE @OldSkillName";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@NewSkillName", newSkillName);
                command.Parameters.AddWithValue("@OldSkillName", oldSkillName);
                ExecuteQuery(command);
            }
            else
            {
                MessageBox.Show($" {newSkillName} already exist in data", "Error");

            }
        }
        public bool UpdateEmployeeEducation(EmployeeEducationModel newModel, EmployeeEducationModel oldModel, String code)
        {
            string query = "UPDATE EmsTblEmployeeEducation SET " +
                       "Qualification = @NewQualification, " +
                       "Board = @NewBoardUniversity, " +
                       "Institute = @NewInstituteName, " +
                       "State = @NewState, " +
                       "PassingYear = @NewPassingYear, " +
                       "Percentage = @NewPercentage " +
                       "WHERE EmployeeCode = @EmployeeCode " +
                       "AND Qualification = @OldQualification " +
                       "AND Board = @OldBoardUniversity " +
                       "AND Institute = @OldInstituteName " +
                       "AND State = @OldState " +
                       "AND PassingYear = @OldPassingYear " +
                       "AND Percentage = @OldPercentage";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@NewQualification", newModel.Qualification);
            command.Parameters.AddWithValue("@NewBoardUniversity", newModel.BoardUniversity);
            command.Parameters.AddWithValue("@NewInstituteName", newModel.InstituteName);
            command.Parameters.AddWithValue("@NewState", newModel.State);
            command.Parameters.AddWithValue("@NewPassingYear", newModel.PassingYear);
            command.Parameters.AddWithValue("@NewPercentage", newModel.Percentage);
            command.Parameters.AddWithValue("@EmployeeCode", code);
            command.Parameters.AddWithValue("@OldQualification", oldModel.Qualification);
            command.Parameters.AddWithValue("@OldBoardUniversity", oldModel.BoardUniversity);
            command.Parameters.AddWithValue("@OldInstituteName", oldModel.InstituteName);
            command.Parameters.AddWithValue("@OldState", oldModel.State);
            command.Parameters.AddWithValue("@OldPassingYear", oldModel.PassingYear);
            command.Parameters.AddWithValue("@OldPercentage", oldModel.Percentage);

            return ExecuteQuery(command);
        }
        public bool UpdateEmployeeExperience(EmployeeExperienceModel newModel, EmployeeExperienceModel oldModel, String code)
        {
            string query = "UPDATE EmsTblEmployeeExperience SET " +
                        "Organization = @NewOrganization, " +
                        "FromDate = @NewFromDate, " +
                        "ToDate = @NewToDate, " +
                        "Designation = @NewDesignation " +
                        "WHERE EmployeeCode = @EmployeeCode " +
                        "AND Organization = @OldOrganization " +
                        "AND FromDate = @OldFromDate " +
                        "AND ToDate = @OldToDate " +
                        "AND Designation = @OldDesignation";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@NewOrganization", newModel.Organization);
            command.Parameters.AddWithValue("@NewFromDate", newModel.FromDate?.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@NewToDate", newModel.ToDate?.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@NewDesignation", newModel.Designation);
            command.Parameters.AddWithValue("@EmployeeCode", code);
            command.Parameters.AddWithValue("@OldOrganization", oldModel.Organization);
            command.Parameters.AddWithValue("@OldFromDate", oldModel.FromDate?.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@OldToDate", oldModel.ToDate?.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@OldDesignation", oldModel.Designation);

            return ExecuteQuery(command);
        }

        public bool UpdateEmployee(string oldCode, EmployeeModel employee, bool releaseDateHasValue = true)
        {
            string query = "SELECT * FROM EmsTblEmployee WHERE Code LIKE @EmployeeCode";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@EmployeeCode", employee.Code);
            if (oldCode == employee.Code || (oldCode != employee.Code && !this.DoesExist(command)))
            {
                query = "UPDATE EmsTblEmployee SET " +
                           "Code = @Code, " +
                           "FirstName = @FirstName, " +
                           "LastName = @LastName, " +
                           "Email = @Email, " +
                           "Password = @Password, " +
                           "Designation = @Designation, " +
                           "Department = @Department, " +
                           "JoiningDate = @JoiningDate, " +
                           "ReleaseDate = @ReleaseDate, " +
                           "DOB = @DOB, " +
                           "ContactNumber = @ContactNumber, " +
                           "Gender = @Gender, " +
                           "MaritalStatus = @MaritalStatus, " +
                           "PresentAddress = @PresentAddress, " +
                           "PermanentAddress = @PermanentAddress " +
                           "WHERE Code = @OldCode";
                command = new SqlCommand(query);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Code", employee.Code);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Password", employee.Password);
                command.Parameters.AddWithValue("@Designation", employee.Designation);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@ReleaseDate", releaseDateHasValue ? employee.ReleaseDate?.ToString("yyyy-MM-dd") : DBNull.Value);
                command.Parameters.AddWithValue("@DOB", employee.DOB.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                command.Parameters.AddWithValue("@Gender", employee.Gender);
                command.Parameters.AddWithValue("@MaritalStatus", employee.MaritalStauts);
                command.Parameters.AddWithValue("@PresentAddress", employee.PresentAddress);
                command.Parameters.AddWithValue("@PermanentAddress", employee.PermanentAddress);
                command.Parameters.AddWithValue("@OldCode", oldCode);

                return ExecuteQuery(command);
            }
            else
            {
                MessageBox.Show($"There is aleady an employee with Employee Code {employee.Code}", "Error");
                return false;
            }
        }
    }
}
