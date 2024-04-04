using EmployeeManagementSystem.Model;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Windows;

namespace EmployeeManagementSystem.Database
{
    internal class GetData
    {
        protected GetConnection connection = new GetConnection();

        /// <summary>
        /// Gives Information of project stored in database.
        /// </summary>
        /// <returns>DataTable of projects stored</returns>
        public DataTable GetProjectData()
        {
            DataTable dt = new DataTable();
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand("SELECT * from EmsTblProject ", conn))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database","Error");
            }
            return dt;
        }

        /// <summary>
        /// Gives filtered dataTable of project based on input given by user.
        /// </summary>
        /// <param name="code">project code</param>
        /// <param name="name">project name </param>
        /// <param name="startingDate">project starting date</param>
        /// <param name="endingDate">project ending date</param>
        public DataTable GetProjectSearchData(String code, String name, DateTime startingDate, DateTime endingDate)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * from EmsTblProject WHERE 1=1";

            if (!String.IsNullOrEmpty(code))
            {
                query += " AND Code LIKE @Code";
            }
            if (!String.IsNullOrEmpty(name))
            {
                query += " AND Name LIKE @Name";
            }
            if (startingDate.Date != DateTime.MinValue)
            {
                query += " AND StartingDate = @StartingDate";
            }
            if (endingDate.Date != DateTime.MinValue)
            {
                query += " AND EndingDate = @EndingDate";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        if (!String.IsNullOrEmpty(code))
                        {
                            command.Parameters.AddWithValue("@Code", $"{code}%");
                        }
                        if (!String.IsNullOrEmpty(name))
                        {
                            command.Parameters.AddWithValue("@Name", $"{name}%");
                        }
                        if (startingDate.Date != DateTime.MinValue)
                        {
                            command.Parameters.AddWithValue("@StartingDate", startingDate.ToString("yyyy-MM-dd"));
                        }
                        if (endingDate.Date != DateTime.MinValue)
                        {
                            command.Parameters.AddWithValue("@EndingDate", endingDate.ToString("yyyy-MM-dd"));
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database: ");
                return new DataTable();
            }
        }

        /// <summary>
        /// Gives information of all technologies stored in database.
        /// </summary>
        /// <returns></returns>
        public DataTable GetTechnologyData()
        {
            DataTable dt = new DataTable();
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand("SELECT * from EmsTblTechnology", conn))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }


        /// <summary>
        /// Searches in project table using project code and returns an object of ProjectModel class. 
        /// </summary>
        /// <param name="code">project code</param>
        public ProjectModel GetProjectFromCode(String code)
        {
            List<int> projectTechnologies = new List<int>();
            ProjectModel project = new ProjectModel();
            try
            {


                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    string query = $"SELECT TechnologyId from EmsTblTechnologyForProject where ProjectCode like @Code";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Code", code);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int value = reader.GetInt32(0);
                                projectTechnologies.Add(value);
                            }
                        }
                    }
                    query = $"SELECT * from EmsTblProject where code like @Code";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Code", code);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int count = reader.FieldCount;
                            while (reader.Read())
                            {
                                project.Code = reader.GetString(0);
                                project.Name = reader.GetString(1);
                                project.StartingDate = reader.GetDateTime(2);
                                if (reader.IsDBNull(3))
                                {
                                    project.EndingDate = null;
                                }
                                else project.EndingDate = reader.GetDateTime(3);
                            }
                        }
                    }
                }
                project.AssociatedTechnologies = projectTechnologies;
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return project;
        }

        /// <summary>
        /// Returns list of all employees form Database
        /// </summary>
        public List<String> AllEmployeeNames()
        {

            List<string> result = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    conn.Open();
                    string query = $"SELECT Code,Firstname, Lastname from EmsTblEmployee";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        string name = string.Empty;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            name = reader.GetString(0);
                            name += "-";
                            name += reader.GetString(1);
                            name += " ";
                            name += reader.GetString(2);
                            result.Add(name);
                            name = string.Empty;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return result;
        }

        /// <summary>
        /// Gives DataTable of Employees which are associated to a project.
        /// </summary>
        /// <param name="projectCode">code of project</param>
        public DataTable GetAssociatedEmployeesToProject(string projectCode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    conn.Open();
                    string query = "SELECT CONCAT(Firstname, ' ', Lastname) AS FullName, EmsTblEmployee.code " +
                           "from EmsTblEmployeeAssociatedToProject " +
                           "INNER JOIN EmsTblEmployee ON EmsTblEmployeeAssociatedToProject.EmployeeCode = EmsTblEmployee.Code " +
                           "where EmsTblEmployeeAssociatedToProject.ProjectCode = @ProjectCode";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@ProjectCode", projectCode);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }

        /// <summary>
        /// Gives DataTable of Projects which are assigned to an employee.
        /// </summary>
        /// <param name="employeeCode"> code of an employee </param>
        public DataTable GetAssociatedProjectForEmployees(string employeeCode)
        {

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                try
                {
                    {
                        conn.Open();
                        string query = "SELECT Name, ProjectCode " +
                          "from EmsTblEmployeeAssociatedToProject " +
                          "INNER JOIN EmsTblProject ON EmsTblEmployeeAssociatedToProject.ProjectCode = EmsTblProject.Code " +
                          "where EmsTblEmployeeAssociatedToProject.EmployeeCode LIKE @EmployeeCode";

                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@EmployeeCode", employeeCode);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error in Fetching data from database");
                }
            return dt;
        }



        /// <summary>
        /// Gives DataTable of all the technologies stored in database.
        /// </summary>
        public DataTable GetTechnologyTable()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    string query = "SELECT * from EmsTblTechnology";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }


        /// <summary>
        /// Gives DataTable of all the skills stored in database.
        /// </summary>
        public DataTable GetSkillTable()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    string query = "SELECT * from EmsTblSkill";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }

        /// <summary>
        /// Gives DataTable of all the Employees stored in database.
        /// </summary>
        public DataTable GetEmployeeTable()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    string query = "SELECT Code,CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) AS Name,Email,Designation,Department,JoiningDate,ReleaseDate from EmsTblEmployee";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }


        /// <summary>
        /// Gives filtered employee DataTable based on email name department and designation.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="designation"></param>
        public DataTable GetEmployeeSearchData(String email, String name, String department, String designation)
        {
            DataTable dt = new DataTable();
            string query = "SELECT *, CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) AS Name from EmsTblEmployee where 1=1";

            if (!String.IsNullOrEmpty(email))
            {
                query += " AND Email like @Email";
            }
            if (!String.IsNullOrEmpty(name))
            {
                query += " AND CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) LIKE @Name";
            }
            if (!String.IsNullOrEmpty(department))
            {
                query += " AND Department like @Department";
            }
            if (!String.IsNullOrEmpty(designation))
            {
                query += " AND Designation like @Designation";
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        if (!String.IsNullOrEmpty(email))
                        {
                            command.Parameters.AddWithValue("@Email", $"{email}%");
                        }
                        if (!String.IsNullOrEmpty(name))
                        {
                            command.Parameters.AddWithValue("@Name", $"{name}%");
                        }
                        if (!String.IsNullOrEmpty(department))
                        {
                            command.Parameters.AddWithValue("@Department", $"{department}%");
                        }
                        if (!String.IsNullOrEmpty(designation))
                        {
                            command.Parameters.AddWithValue("@Designation", $"{designation}%");
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error in fetching data from database");
            }
            return dt;
        }


        /// <summary>
        /// Searches in employee table using employee code and returns an object of EmployeeModel class. 
        /// </summary>
        /// <param name="code">Employee code</param>
        public EmployeeModel GetEmployeeFromCode(String code)
        {
            EmployeeModel employee = new EmployeeModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    conn.Open();
                    string query = $"SELECT * from EmsTblEmployee where Code LIKE @Code";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Code", code);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int count = reader.FieldCount;
                            while (reader.Read())
                            {
                                employee.Code = reader.GetString(0);
                                employee.FirstName = reader.GetString(1);
                                employee.LastName = reader.GetString(2);
                                employee.Email = reader.GetString(3);
                                employee.Password = reader.GetString(4);
                                employee.JoiningDate = reader.GetDateTime(5);
                                if (reader.IsDBNull(6))
                                {
                                    employee.ReleaseDate = null;
                                }
                                else employee.ReleaseDate = reader.GetDateTime(6);
                                employee.DOB = reader.GetDateTime(7);
                                employee.ContactNumber = reader.GetString(8);
                                employee.Gender = reader.GetString(9);
                                employee.MaritalStauts = reader.GetString(10);
                                employee.PresentAddress = reader.GetString(11);
                                employee.PermanentAddress = reader.GetString(12);
                                employee.Designation = reader.GetString(13);
                                employee.Department = reader.GetString(14);
                            }
                        }
                    }
                    employee.EducationModels = GetEmployeeEducationModels(code);
                    employee.ExperienceModels = GetEmployeeExperienceModels(code);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in fetching data from database");
            }
            return employee;
        }

        /// <summary>
        /// Gives Collection of ExperienceModel of an employee from experience table 
        /// </summary>
        /// <param name="code">Code of employee whose ExperienceModel models we want to find</param>
        private ObservableCollection<EmployeeExperienceModel> GetEmployeeExperienceModels(string code)
        {
            ObservableCollection<EmployeeExperienceModel> employeeExperienceModels = new ObservableCollection<EmployeeExperienceModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    string query = $"SELECT * from  EmsTblEmployeeExperience where EmployeeCode like @Code";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Code", code);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                EmployeeExperienceModel employeeExperienceModel = new EmployeeExperienceModel
                                {
                                    Organization = reader["Organization"].ToString(),
                                    FromDate = (DateTime)reader["FromDate"],
                                    ToDate = (DateTime)reader["ToDate"],
                                    Designation = reader["designation"].ToString(),

                                };
                                employeeExperienceModels.Add(employeeExperienceModel);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in fetching data from database");
            }
            return employeeExperienceModels;
        }


        /// <summary>
        /// Gives Collection EducationModel of an employee from Education table. 
        /// </summary>
        /// <param name="code">Code of employee whose EducationModels models we want to find</param>
        private ObservableCollection<EmployeeEducationModel> GetEmployeeEducationModels(string code)
        {
            ObservableCollection<EmployeeEducationModel> educationModels = new ObservableCollection<EmployeeEducationModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    string query = $"SELECT * from  EmsTblEmployeeEducation where EmployeeCode like @Code";
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Code", code);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeEducationModel employeeEducation = new EmployeeEducationModel
                                {
                                    Qualification = reader["Qualification"].ToString(),
                                    BoardUniversity = reader["Board"].ToString(),
                                    InstituteName = reader["Institute"].ToString(),
                                    State = reader["State"].ToString(),
                                    PassingYear = reader["PassingYear"].ToString(),
                                    Percentage = reader["Percentage"].ToString(),
                                };
                                educationModels.Add(employeeEducation);
                            }
                        }
                    }


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in fetching data from database");
            }
            return educationModels;
        }


        /// <summary>
        /// Gives count of employee filtered by Designation.
        /// </summary>
        public DataTable DesignationWiseEmployee()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    string query = $"SELECT COUNT(*) as Count, Designation  from EmsTblEmployee GROUP BY Designation   ";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in fetching data from database");
            }
            return dt;
        }
        /// <summary>
        /// Gives List of  names of all projects from DataBase.
        /// </summary>
        public List<string> GetProjectNames()
        {
            List<string> result = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    string query = $"SELECT Code,Name from EmsTblProject";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        string name = string.Empty;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            name = reader.GetString(0);
                            name += "-";
                            name += reader.GetString(1);
                            result.Add(name);
                            name = string.Empty;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in fetching data from database");
            }
            return result;
        }

        /// <summary>
        /// Gives information of employees who joined in past six months.
        /// </summary>
        public DataTable GetPastSixMonthJoinedEmployee()
        {
            string query = "SELECT " +
                                "COUNT(*) AS Count,MONTH(JoiningDate) AS MonthNumber, DATENAME(month, JoiningDate) AS Month " +
                            "from " +
                                "EmsTblEmployee" +
                            " where " +
                                "JoiningDate between DATEADD(month,-6, DATEADD(day,-DAY(GETDATE())+1,GETDATE())) AND EOMONTH(GETDATE(),-1)" +
                            "GROUP BY " +
                                "MONTH(JoiningDate), DATENAME(month, JoiningDate) " +
                            "ORDER BY " +
                            "(MONTH(GETDATE()) - MONTH(JoiningDate) + 12) % 12;";
            DataTable dt = new DataTable();
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }

        /// <summary>
        /// Gives information of employees who released  in past six months.
        /// </summary>
        public DataTable GetPastSixMonthReleasedEmployee()
        {
            string query = "SELECT " +
                                "COUNT(*) AS Count,MONTH(ReleaseDate) AS MonthNumber, DATENAME(month, ReleaseDate) AS Month " +
                            "from " +
                                "EmsTblEmployee" +
                            " where " +
                                "ReleaseDate between DATEADD(month,-6, DATEADD(day,-DAY(GETDATE())+1,GETDATE())) AND EOMONTH(GETDATE(),-1)" +
                            "GROUP BY " +
                                "MONTH(ReleaseDate), DATENAME(month, ReleaseDate) " +
                            "ORDER BY " +
                            "(MONTH(GETDATE()) - MONTH(ReleaseDate) + 12) % 12;";
            DataTable dt = new DataTable();
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }

        /// <summary>
        /// Gives count of project group by technologies.
        /// </summary>
        public DataTable GetTechnologyWiseProject()
        {
            string query = "SELECT EmsTblTechnology.Id,COUNT(projectCode)as Count,EmsTblTechnology.Name from EmsTblTechnology " +
                "LEFT JOIN EmsTblTechnologyForProject ON " +
                "EmsTblTechnology.Id = EmsTblTechnologyForProject.TechnologyID GROUP BY EmsTblTechnology.Name,EmsTblTechnology.Id;";
            DataTable dt = new DataTable();
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }

        /// <summary>
        /// Gives Employee count group by Skills.
        /// </summary>
        /// <returns></returns>
        public DataTable GetSkillWiseEmployeeCount()
        {
            string query = "SELECT COUNT(*) as Count,SkillId,Name from" +
                " EmsTblSkill LEFT  JOIN EmsTblSkillForEmployee  On EmsTblSkillForEmployee.SkillId = EmsTblSkill.Id group by EmsTblSkillForEmployee.SkillId ,EmsTblSkill.Name";
            DataTable dt = new DataTable();
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }

        /// <summary>
        /// Checks if user has entered the correct username and password.
        /// </summary>
        /// <param name="username">email id of user.</param>
        /// <param name="password">password of user.</param>
        /// <returns>Employee code of employee.</returns>
        public String ExecuteLogin(string username, string password)
        {
            string query = $"SELECT Code from EmsTblEmployee where Email LIKE @Email COLLATE Latin1_General_CS_AS AND Password LIKE @Password COLLATE Latin1_General_CS_AS ";
            string code = String.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Email", username);
                        command.Parameters.AddWithValue("@Password", password);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                code = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                            }
                        }
                    }
                }
                return code!;
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
                return string.Empty;
            }
        }
    }
}
