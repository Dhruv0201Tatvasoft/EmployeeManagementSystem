using EmployeeManagementSystem.Model;
using System.Data.SqlClient;
using System.Windows;

namespace EmployeeManagementSystem.Database
{

    class InsertData
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
            catch (SqlException)
            {
                {
                    MessageBox.Show("Error in inserting data to database", "Error");
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
        public bool InsertNewProject(ProjectModel project, bool endingDateHasValue = true)
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
                command.Parameters.AddWithValue("@EndingDate", endingDateHasValue ? project.EndingDate?.ToString("yyyy-MM-dd") : DBNull.Value);
                bool didsave = ExecuteQuery(command);
                if (didsave) InsertAssociatedTechnologies(project);
                return didsave;

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
                MessageBox.Show($"{employeeName} is already added to this project", "Alert", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        public void InsertTechnology(String technologyName)
        {
            string query = "SELECT * FROM EmsTblTechnology WHERE Name LIKE @TechnologyName";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@TechnologyName", technologyName);
            if (!DoesExist(command))
            {
                query = "INSERT INTO EmsTblTechnology (Name) VALUES (@TechnologyName)";
                command.CommandText = query;
                ExecuteQuery(command);
            }
            else
            {
                MessageBox.Show($"{technologyName} already exist in data", "Error");
            }
        }
        public void InsertSkill(String skillName)
        {
            string query = "SELECT * FROM EmsTblSkill WHERE Name LIKE @SkillName";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@SkillName", skillName);
            if (!DoesExist(command))
            {
                query = "INSERT INTO EmsTblSkill (Name) VALUES (@SkillName)";
                command.CommandText = query;
                ExecuteQuery(command);
            }
            else
            {
                MessageBox.Show($"{skillName} already exist in data", "Error");
            }
        }

        public bool InsertEmployee(EmployeeModel employee, bool realeaseDateHasValue = true)
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
                command.Parameters.AddWithValue("@ReleaseDate", realeaseDateHasValue ? employee.ReleaseDate?.ToString("yyyy-MM-dd") : DBNull.Value);
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

        public void InsertProjectToEmployee(string projectCode, string projectName, string employeeCode)
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
                MessageBox.Show($"{projectName} is already assigned to this Employee", "Alert", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
