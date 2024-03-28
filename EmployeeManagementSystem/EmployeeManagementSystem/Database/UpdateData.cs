using EmployeeManagementSystem.Model;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Input;

namespace EmployeeManagementSystem.Database
{
    internal class UpdateData
    {
        private GetConnection connection = new GetConnection();

        /// <summary>
        /// Performs/Executes queries on database.
        /// </summary>
        /// <param name="command">SqlCommand to be executed.</param>
        /// <returns>true if query has successfully executed otherwise false.</returns>
        private bool ExecuteQuery(SqlCommand command)
        {
            try
            {
                using (SqlConnection conn = connection.GenerateConnection())
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

        /// <summary>
        /// Checks if the result exists in database.
        /// </summary>
        /// <param name="command">SqlCommand to check if result exists in database.</param>
        /// <returns>true if result exists in database false otherwise.</returns>
        private bool DoesExist(SqlCommand command)
        {
            try
            {
                using (SqlConnection conn = connection.GenerateConnection())
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
        
        /// <summary>
        /// To update project that exist in database.
        /// </summary>
        /// <param name="oldCode">old code of project which is being updated.</param>
        /// <param name="project">new object of class ProjectModel which will replace the old model. </param>
        /// <param name="endingDateHasValue">to check if project's endingDate has value.</param>
        /// <returns>true if project gets updated successfully otherwise false.</returns>
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
                command.Parameters.AddWithValue("@EndingDate", endingDateHasValue ? project.EndingDate?.ToString("yyyy-MM-dd") : DBNull.Value); ///if endingDateHasValue == true then add Project.EndingDate otherwise null;
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

        /// <summary>
        /// Insert technologies that are associated with the project.
        /// </summary>
        /// <param name="project">object of class ProjectModel to which technologies are associated.</param>
        private void InsertAssociatedTechnologies(ProjectModel project)
        {
            string query = "INSERT INTO EmsTblTechnologyForProject(ProjectCode, TechnologyId) " +
                           "VALUES (@Code, @TechnologyId)";
            foreach (int technologyId in project.AssociatedTechnologies!)
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

        /// <summary>
        /// To update technology name that is already exist in database.
        /// </summary>
        /// <param name="newTechnologyName">new technology name to update the old technology.</param>
        /// <param name="oldTechnologyName">technology name that is to be updated.</param>
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

        /// <summary>
        ///  To update skill name that is already exist in database.
        /// </summary>
        /// <param name="newSkillName">new skill name to update the old skill.</param>
        /// <param name="oldSkillName">skill name that is being updated.</param>
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

        /// <summary>
        /// To update education field of an employee.
        /// </summary>
        /// <param name="newModel">new EmployeeEducationModel to update the old EmployeeEducationModel.</param>
        /// <param name="oldModel">old EmployeeEducationModel that is being updated.</param>
        /// <param name="code">code of employee whose EmployeeEducationModel is being updated.</param>
        /// <returns>true if it successfully updates EmployeeEducationModel otherwise false.</returns>
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

        /// <summary>
        /// To update experience field of an employee
        /// </summary>
        /// <param name="newModel">new EmployeeExperienceModel to update the old EmployeeExperienceModel</param>
        /// <param name="oldModel">old EmployeeExperienceModel that is being updated.</param>
        /// <param name="code">code of employee whose EmployeeExperienceModel is being updated.</param>
        /// <returns>true if it successfully updates EmployeeExperienceModel otherwise false.</returns>
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

        /// <summary>
        /// To update an employee.
        /// </summary>
        /// <param name="oldCode">old code of employee who is being updated.</param>
        /// <param name="employee">object of class EmployeeModel which will replace the old employee.</param>
        /// <param name="releaseDateHasValue">to check if employee's releaseDate has value.</param>
        /// <returns>true if it successfully updates employee otherwise false.</returns>
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
                MessageBox.Show($"There is already an employee with Employee Code {employee.Code}", "Error");
                return false;
            }
        }
    }
}
