﻿using System.Data.SqlClient;
using System.Data;
using System.Windows;
using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Database
{
    internal class GetData
    {
        private GetConnection connection = new GetConnection();


        public DataTable GetProjectData()
        {
            DataTable dt = new DataTable();
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand("SELECT * FROM EmsTblProject ", conn))
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
            string query = "Select * from EmsTblProject where 1=1";

            if (!String.IsNullOrEmpty(code))
            {
                query += $" AND code like '{code}%'";
            }
            if (!String.IsNullOrEmpty(name))
            {
                query += $" AND name like '{name}%' ";
            }
            if (startingDate.Date != DateTime.MinValue)
            {
                query += $" AND startingDate='{startingDate.ToString("yyyy-MM-dd")}'";
            }
            if (endingDate.Date != DateTime.MinValue)
            {
                query += $" AND endingDate='{endingDate.ToString("yyyy-MM-dd")}'";
            }
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
                return dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
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
                        using (SqlCommand command = new SqlCommand("select * from EmsTblTechnology", conn))
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
                string query = $"SELECT TechnologyId FROM EmsTblTechnologyForProject where ProjectCode like '{code}'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int value = reader.GetInt32(0);
                            projectTechnologies.Add(value);
                        }
                    }
                }
                query = $"SELECT * from EmsTblProject where code = '{code}'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
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

            string query = $"Select code,Firstname, Lastname from EmsTblEmployee";
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
            string query = $"Select CONCAT(Firstname,' ',Lastname) As FullName,EmsTblEmployee.code " +
                $"from EmsTblEmployeeAssociatedToProject inner join EmsTblEmployee on " +
                $"EmsTblEmployeeAssociatedToProject.employeeCode = EmsTblEmployee.code " +
                $"where EmsTblEmployeeAssociatedToProject.ProjectCode = '{projectCode}'";
            DataTable dt = new DataTable();
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
            return dt;
        }
        public DataTable GetAssociatedProjectForEmployees(string employeeCode)
        {
            string query = $"select Name,ProjectCode from EmsTblEmployeeAssociatedToProject inner join EmsTblProject On ProjectCode = Code where EmployeeCode Like '{employeeCode}'";
            DataTable dt = new DataTable();
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
            return dt;
        }

        public DataTable GetTechnologyTable()
        {
            string query = "select * from EmsTblTechnology";
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
            string query = "select * from EmsTblSkill";
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
            string query = "select Code,CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) AS Name,Email,Designation,Department,JoiningDate,ReleaseDate from EmsTblEmployee";
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
            string query = "Select *,CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) AS Name from EmsTblEmployee where 1=1";

            if (!String.IsNullOrEmpty(email))
            {
                query += $" AND Email like '{email}%'";
            }
            if (!String.IsNullOrEmpty(name))
            {
                query += $" AND  CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) LIKE '%{name}%'";
            }
            if (!String.IsNullOrEmpty(department))
            {
                query += $" AND Department like '{department}'";
            }
            if (!String.IsNullOrEmpty(designation))
            {
                query += $" AND Designation like '{designation}'";
            }
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


                string query = $"SELECT * from EmsTblEmployee where Code Like '{code}'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
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
                query = $"Select * from  EmsTblEmployeeEducation where EmployeeCode like '{code}'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
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
                query = $"Select * from  EmsTblEmployeeExperience where EmployeeCode like '{code}'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
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
            string query = $"select COUNT(*) as Count, Designation from EmsTblEmployee Group BY Designation";
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
            string query = $"select Name as Technology,count(*) as Count from EmsTblSkillForEmployee inner join EmsTblSkill On SkillId=id inner join EmsTblEmployee On EmployeeCode = Code group by Name";
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
            string query = $"Select Code,Name from EmsTblProject";
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
                            "FROM " +
                                "EmsTblEmployee" +
                            " WHERE " +
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
                            "FROM " +
                                "EmsTblEmployee" +
                            " WHERE " +
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
            string query = "SELECT Id,COUNT(projectCode)as Count,Name FROM EmsTblTechnology " +
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
            string query = "select COUNT(*) as Count,SkillId,Name from EmsTblSkillForEmployee inner join EmsTblSkill On EmsTblSkillForEmployee.SkillId = EmsTblSkill.Id group by SkillId ,Name";
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
            string query = $"select Code from EmsTblEmployee Where Email like '{username}' COLLATE Latin1_General_CS_AS AND Password like '{password}' COLLATE Latin1_General_CS_AS ";
            string Code = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Code = reader.IsDBNull(0) ? null : reader.GetString(0);
                            }
                        }
                    }
                }
                return Code;
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
                return string.Empty;
            }
        }
    }
}
