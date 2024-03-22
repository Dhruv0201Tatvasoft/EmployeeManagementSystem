using EmployeeManagementSystem.Model;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace EmployeeManagementSystem.Database
{
    internal class GetData
    {
        protected GetConnection connection = new GetConnection();


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
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }
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
            catch (Exception ex)
            {
                MessageBox.Show("Error in Fetching data from database: " + ex.Message);
                return new DataTable();
            }
        }


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

        public ProjectModel GetProjectFromCode(String code)
        {
            List<int> projectTechnologies = new List<int>();
            ProjectModel project = new ProjectModel();


            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                conn.Open();
                string query = $"SELECT TechnologyId from EmsTblTechnologyForProject where ProjectCode like @Code";
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
            return project;
        }

        public List<String> AllEmployeeNames()
        {

            string query = $"SELECT Code,Firstname, Lastname from EmsTblEmployee";
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
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
                        name += " ";
                        name += reader.GetString(2);
                        result.Add(name);
                        name = string.Empty;
                    }
                }
            }
            return result;
        }
        public DataTable GetAssociatedEmployeesToProject(string projectCode)
        {
            string query = "SELECT CONCAT(Firstname, ' ', Lastname) AS FullName, EmsTblEmployee.code " +
                           "from EmsTblEmployeeAssociatedToProject " +
                           "INNER JOIN EmsTblEmployee ON EmsTblEmployeeAssociatedToProject.EmployeeCode = EmsTblEmployee.Code " +
                           "where EmsTblEmployeeAssociatedToProject.ProjectCode = @ProjectCode";
            DataTable dt = new DataTable();


            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@ProjectCode", projectCode);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable GetAssociatedProjectForEmployees(string employeeCode)
        {
            string query = "SELECT Name, ProjectCode " +
                           "from EmsTblEmployeeAssociatedToProject " +
                           "INNER JOIN EmsTblProject ON EmsTblEmployeeAssociatedToProject.ProjectCode = ProjectCode.Code " +
                           "where EmsTblEmployeeAssociatedToProject.EmployeeCode LIKE @EmployeeCode";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmployeeCode", employeeCode);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }




        public DataTable GetTechnologyTable()
        {
            string query = "SELECT * from EmsTblTechnology";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public DataTable GetSkillTable()
        {
            string query = "SELECT * from EmsTblSkill";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable GetEmployeeTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Code,CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) AS Name,Email,Designation,Department,JoiningDate,ReleaseDate from EmsTblEmployee";
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

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
                            command.Parameters.AddWithValue("@Name", $"%{name}%");
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

        public EmployeeModel GetEmployeeModelFromCode(String code)
        {
            EmployeeModel employee = new EmployeeModel();
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
                query = $"SELECT * from  EmsTblEmployeeEducation where EmployeeCode like @Code";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Code", code);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int count = reader.FieldCount;
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
                            employee.EducationModels.Add(employeeEducation);
                        }
                    }
                }
                query = $"SELECT * from  EmsTblEmployeeExperience where EmployeeCode like @Code";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Code", code);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int count = reader.FieldCount;
                        while (reader.Read())
                        {
                            EmployeeExperienceModel employeeExperienceModel = new EmployeeExperienceModel
                            {
                                Organization = reader["Organization"].ToString(),
                                FromDate = (DateTime)reader["FromDate"],
                                ToDate = (DateTime)reader["ToDate"],
                                Designation = reader["designation"].ToString(),

                            };
                            employee.ExperienceModels.Add(employeeExperienceModel);
                        }
                    }
                }

            }
            return employee;
        }
        public DataTable DesignationWiseEmployeeCount()
        {
            string query = $"SELECT COUNT(*) as Count, Designation from EmsTblEmployee GROUP BY Designation";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public DataTable TechnologyWiseEmployeeCount()
        {
            string query = $"SELECT Name as Technology,count(*) as Count from EmsTblSkillForEmployee INNER JOIN" +
                $" EmsTblSkill On EmsTblSkillForEmployee.SkillId = EmsTblSkill.Id INNER JOIN EmsTblEmployee ON " +
                $"EmsTblSkillForEmployee.EmployeeCode = EmsTblEmployee.Code GROUP BY Name";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public List<string> GetProjectNames()
        {
            string query = $"SELECT Code,Name from EmsTblProject";
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
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
            return result;
        }
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
        public DataTable GetTechnologyWiseProject()
        {
            string query = "SELECT Id,COUNT(projectCode)as Count,Name from EmsTblTechnology " +
                "LEFT JOIN EmsTblTechnologyForProject ON " +
                "EmsTblTechnology.Id = EmsTblTechnologyForProject.TechnologyID GROUP BY EmsTblTechnology.Name,Id;";
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
        public DataTable GetSkillWiseEmployeeCount()
        {
            string query = "SELECT COUNT(*) as Count,SkillId,Name from" +
                " EmsTblSkillForEmployee INNER  JOIN EmsTblSkill On EmsTblSkillForEmployee.SkillId = EmsTblSkill.Id group by SkillId ,Name";
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
