using EmployeeManagementSystem.Model;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;

namespace EmployeeManagementSystem.Database
{

    class InsertData
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
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            command.Connection = conn;
                            command.Transaction = transaction;

                            command.ExecuteNonQuery();

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error in inserting data to database.", "Error");
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in inserting data to database.", "Error");
                return false;
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
        /// Inserts new project to database.
        /// </summary>
        /// <param name="project">object of ProjectModel class whose project is being added.</param>
        /// <param name="endingDateHasValue">to check if project's ending date has value of it is null.</param>
        /// <returns>true if project is successfully added to database otherwise false.</returns>
        public bool InsertNewProject(ProjectModel project, bool endingDateHasValue)
        {
            string query = $"Select * from EmsTblProject where Code LIKE @Code";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Code", project.Code);
            if (!this.DoesExist(command))
            {
                query = "INSERT INTO EmsTblProject(Code, Name, StartingDate, EndingDate) " +
                 "VALUES (@Code, @Name, @StartingDate, @EndingDate)";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Code", project.Code);
                command.Parameters.AddWithValue("@Name", project.Name);
                command.Parameters.AddWithValue("@StartingDate", project.StartingDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@EndingDate", endingDateHasValue ? project.EndingDate?.ToString("yyyy-MM-dd") : DBNull.Value); ///if endingDateHasValue == true then add Project.EndingDate otherwise null;
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
                SqlCommand command = new SqlCommand(query);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Code", project.Code);
                command.Parameters.AddWithValue("@TechnologyId", technologyId);
                ExecuteQuery(command);

            }
        }

        /// <summary>
        ///  To assign an employee to a project.
        /// </summary>
        /// <param name="projectCode">code of project to which employee is being assigned.</param>
        /// <param name="employeeCode">code of employee who is being assigned to a project.</param>
        /// <param name="employeeName">name of employee who is being assigned to a project.</param>
        public void InsertEmployeeToProject(String projectCode, String employeeCode, string employeeName)
        {
            string query = "SELECT * FROM EmsTblEmployeeAssociatedToProject WHERE ProjectCode = @ProjectCode AND EmployeeCode = @EmployeeCode";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ProjectCode", projectCode);
            command.Parameters.AddWithValue("@EmployeeCode", employeeCode);

            if (!DoesExist(command))
            {
                query = "INSERT INTO EmsTblEmployeeAssociatedToProject (EmployeeCode, ProjectCode) VALUES (@EmployeeCode, @ProjectCode)";
                command.CommandText = query;
                ExecuteQuery(command);
            }
            else
            {
                MessageBox.Show($"{employeeName} is already added to this project", "Erorr", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        /// <summary>
        /// Insert technology to database.
        /// </summary>
        /// <param name="technologyName">name of technology which is being inserted to database.</param>
        public void InsertTechnology(String technologyName)
        {
            if (technologyName.Length > 20)
            {
                MessageBox.Show("Maximum character limit reached for technology name", "Error");
                return;
            }
            string query = "SELECT * FROM EmsTblTechnology WHERE Name LIKE @TechnologyName";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@TechnologyName", technologyName);
            if (!DoesExist(command))
            {
                query = "INSERT INTO EmsTblTechnology (Name) VALUES (@TechnologyName)";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@TechnologyName", technologyName);
                ExecuteQuery(command);
            }
            else
            {
                MessageBox.Show($"{technologyName} already exist in data", "Error");
            }
        }

        /// <summary>
        /// Insert skill to database.
        /// </summary>
        /// <param name="skillName">name of skill which is being inserted to database.</param>
        public void InsertSkill(String skillName)
        {
            if (skillName.Length > 20)
            {
                MessageBox.Show("Maximum character limit reached for skill name", "Error");
                return;
            }
            string query = "SELECT * FROM EmsTblSkill WHERE Name LIKE @SkillName";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@SkillName", skillName);
            if (!DoesExist(command))
            {
                query = "INSERT INTO EmsTblSkill (Name) VALUES (@SkillName)";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@SkillName", skillName);
                ExecuteQuery(command);
            }
            else
            {
                MessageBox.Show($"{skillName} already exist in data", "Error");
            }
        }

        /// <summary>
        /// Insert employee to database.
        /// </summary>
        /// <param name="employee">object of class EmployeeModel which is being inserted to database.</param>
        /// <param name="releaseDateHasValue">to check if employee's releaseDate has value.</param>
        /// <returns>true if employee successfully added to database.</returns>
        public bool InsertEmployee(EmployeeModel employee, bool releaseDateHasValue)
        {
            string query = "SELECT * FROM EmsTblEmployee WHERE Code LIKE @EmployeeCode";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@EmployeeCode", employee.Code);

            if (!DoesExist(command))
            {
                query = "INSERT INTO EmsTblEmployee (Code, FirstName, LastName, Email, Password, [Designation], [Department], JoiningDate, ReleaseDate, DOB, " +
                    "ContactNumber, Gender, MaritalStatus, PresentAddress, PermanentAddress) VALUES " +
                    "(@Code, @FirstName, @LastName, @Email, @Password, @Designation, @Department, @JoiningDate, @ReleaseDate, @DOB, @ContactNumber, " +
                    "@Gender, @MaritalStatus, @PresentAddress, @PermanentAddress)";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Code", employee.Code);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Password", employee.Password);
                command.Parameters.AddWithValue("@Designation", employee.Designation);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@ReleaseDate", releaseDateHasValue ? employee.ReleaseDate?.ToString("yyyy-MM-dd") : DBNull.Value);/// if releaseDateHasValue == true then add the value of releaseDate to Database otherwise null.
                command.Parameters.AddWithValue("@DOB", employee.DOB.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                command.Parameters.AddWithValue("@Gender", employee.Gender);
                command.Parameters.AddWithValue("@MaritalStatus", employee.MaritalStauts);
                command.Parameters.AddWithValue("@PresentAddress", employee.PresentAddress);
                command.Parameters.AddWithValue("@PermanentAddress", employee.PermanentAddress);
                return ExecuteQuery(command);
            }
            else
            {
                MessageBox.Show($"Employee with code {employee.Code} already exist in database.", "Error");
                return false;
            }
        }

        /// <summary>
        /// To insert education details of employee to database.
        /// </summary>
        /// <param name="educationModel">object of class EmployeeEducationModel which is being inserted to database.</param>
        /// <param name="code">code of employee whose education details are being inserted to database. </param>
        /// <returns>true if education details are successfully inserted to database otherwise false.</returns>
        public bool InsertEducationDetails(EmployeeEducationModel educationModel, String code)
        {
            string query = "INSERT INTO EmsTblEmployeeEducation (EmployeeCode, Qualification, Board, Institute, State, PassingYear, Percentage) VALUES " +
        "(@EmployeeCode, @Qualification, @Board, @Institute, @State, @PassingYear, @Percentage)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@EmployeeCode", code);
            command.Parameters.AddWithValue("@Qualification", educationModel.Qualification);
            command.Parameters.AddWithValue("@Board", educationModel.BoardUniversity);
            command.Parameters.AddWithValue("@Institute", educationModel.InstituteName);
            command.Parameters.AddWithValue("@State", educationModel.State);
            command.Parameters.AddWithValue("@PassingYear", educationModel.PassingYear);
            command.Parameters.AddWithValue("@Percentage", educationModel.Percentage);
            return ExecuteQuery(command);
        }

        /// <summary>
        /// To insert Experience details of employee to database.
        /// </summary>
        /// <param name="experienceModel">object of class EmployeeExperienceModel which is being inserted to database.</param>
        /// <param name="code">code of employee whose experience details are being inserted to database.</param>
        /// <returns>true if experience details are successfully inserted to database.</returns>
        public bool InsertExperienceDetails(EmployeeExperienceModel experienceModel, String code)
        {
            string query = "INSERT INTO EmsTblEmployeeExperience (EmployeeCode, Organization, FromDate, ToDate, Designation) VALUES " +
       "(@EmployeeCode, @Organization, @FromDate, @ToDate, @Designation)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@EmployeeCode", code);
            command.Parameters.AddWithValue("@Organization", experienceModel.Organization);
            command.Parameters.AddWithValue("@FromDate", experienceModel.FromDate?.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@ToDate", experienceModel.ToDate?.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Designation", experienceModel.Designation);
            return ExecuteQuery(command);

        }

        /// <summary>
        /// To assign a project to an employee.
        /// </summary>
        /// <param name="projectCode">code of project which is being assigned to an employee.</param>
        /// <param name="projectName">name of project which is being assigned to an employee.</param>
        /// <param name="employeeCode">code of employee who is being assigned to a project.</param>
        public void AssignProjectToEmployee(string projectCode, string projectName, string employeeCode)
        {
            string query = "SELECT * FROM EmsTblEmployeeAssociatedToProject WHERE ProjectCode = @ProjectCode AND EmployeeCode = @EmployeeCode";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ProjectCode", projectCode);
            command.Parameters.AddWithValue("@EmployeeCode", employeeCode);

            if (!DoesExist(command))
            {
                query = "INSERT INTO EmsTblEmployeeAssociatedToProject (EmployeeCode, ProjectCode) VALUES (@EmployeeCode, @ProjectCode)";
                command.CommandText = query;
                ExecuteQuery(command);
            }
            else
            {
                MessageBox.Show($"{projectName} is already assigned to this Employee", "Error", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
