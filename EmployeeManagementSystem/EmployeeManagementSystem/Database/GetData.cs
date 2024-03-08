﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmployeeManagementSystem.Models;
using System.Data.Common;
using System.Windows.Media.Animation;
using System.Collections.ObjectModel;
using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Database
{
    internal class GetData
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
                /// Exeption number 2627 belongs to Duplicate primary key exception. 
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Duplicate Data");
                }
                else
                {
                    MessageBox.Show("Some error occured");
                }
            }
        }

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
        public DataTable GetProjectSearchData(String Code, String Name, DateTime StartingDate, DateTime EndingDate)
        {
            DataTable dt = new DataTable();
            string Query = "Select * from EmsTblProject where 1=1";

            if (!String.IsNullOrEmpty(Code))
            {
                Query += $" AND Code like '{Code}%'";
            }
            if (!String.IsNullOrEmpty(Name))
            {
                Query += $" AND Name like '{Name}%' ";
            }
            if (StartingDate.Date != new DateTime(1990, 01, 01))
            {
                Query += $" AND StartingDate='{StartingDate.ToString("yyyy-MM-dd")}'";
            }
            if (EndingDate.Date != DateTime.Now.Date)
            {
                Query += $" AND EndingDate='{EndingDate.ToString("yyyy-MM-dd")}'";
            }
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(Query, conn))
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

        public ProjectModel GetProjectFromCode(String Code)
        {
            List<int> ProjectTechnologies = new List<int>();
            ProjectModel project = new ProjectModel();


            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                conn.Open();


                string SelectQueryForEmsTbltechnologyForProjectTable = $"SELECT TechnologyId FROM EmsTblTechnologyForProject where ProjectCode = '{Code}'";
                using (SqlCommand command = new SqlCommand(SelectQueryForEmsTbltechnologyForProjectTable, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int value = reader.GetInt32(0);
                            ProjectTechnologies.Add(value);
                        }
                    }
                }
                string SelectQueryForEmsTblProject = $"SELECT * from EmsTblProject where Code = '{Code}'";
                using (SqlCommand command = new SqlCommand(SelectQueryForEmsTblProject, conn))
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
            project.AssociatedTechnologies = ProjectTechnologies;
            return project;
        }

        public List<String> AllEmployeeNames()
        {

            string Query = $"Select Code,Firstname, Lastname from EmsTblEmployee";
            List<string> Result = new List<string>();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(Query, conn))
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
                        Result.Add(name);
                        name = string.Empty;
                    }
                }
            }
            return Result;
        }
        public DataTable GetAssociatedEmployeesToProject(string ProjectCode)
        {
            string Query = $"Select CONCAT(Firstname,' ',Lastname) As FullName,EmsTblEmployee.code " +
                $"from EmsTblEmployeeAssociatedToProject inner join EmsTblEmployee on " +
                $"EmsTblEmployeeAssociatedToProject.EmployeeCode = EmsTblEmployee.Code " +
                $"where EmsTblEmployeeAssociatedToProject.ProjectCode = '{ProjectCode}'";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(Query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }

                }
            }
            return dt;
        }
        public DataTable GetAssociatedProjectForEmployees(string EmployeeCode)
        {
            string Query = $"select Name,ProjectCode from EmsTblEmployeeAssociatedToProject inner join EmsTblProject On ProjectCode = Code where EmployeeCode Like '{EmployeeCode}'";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(Query, conn))
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
            string Query = "select * from EmsTblTechnology";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(Query, conn))
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
            string Query = "select * from EmsTblSkill";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(Query, conn))
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
            string Query = "select Code,CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) AS Name,Email,Designation,Department,JoiningDate,ReleaseDate from EmsTblEmployee";
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(Query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable GetEmployeeSearchData(String Code, String Name, String Department, String Designation)
        {
            DataTable dt = new DataTable();
            string Query = "Select *,CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) AS Name from EmsTblEmployee where 1=1";

            if (!String.IsNullOrEmpty(Code))
            {
                Query += $" AND Code like '{Code}%'";
            }
            if (!String.IsNullOrEmpty(Name))
            {
                Query += $" AND  CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) LIKE '%{Name}%'";
            }
            if (!String.IsNullOrEmpty(Department))
            {
                Query += $" AND Department like '{Department}'";
            }
            if (!String.IsNullOrEmpty(Designation))
            {
                Query += $" AND Designation like '{Designation}'";
            }
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(Query, conn))
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
        public EmployeeModel GetEmployeeModelFromCode(String Code)
        {
            EmployeeModel employee = new EmployeeModel();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                conn.Open();


                string Query = $"SELECT * from EmsTblEmployee where Code = '{Code}'";
                using (SqlCommand command = new SqlCommand(Query, conn))
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
                Query = $"Select * from  EmsTblEmployeeEducation where EmployeeCode like '{Code}'";
                using (SqlCommand command = new SqlCommand(Query, conn))
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
                                InstituteName= reader["Institute"].ToString(),
                                State= reader["State"].ToString(),
                                PassingYear= reader["PassingYear"].ToString(),
                                Percentage= reader["Percentage"].ToString(),
                            };
                            employee.EducationModels.Add(employeeEducation);
                        }
                    }
                }
                Query = $"Select * from  EmsTblEmployeeExperience where EmployeeCode like '{Code}'";
                using (SqlCommand command = new SqlCommand(Query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int count = reader.FieldCount;
                        while (reader.Read())
                        {
                            EmployeeExperienceModel employeeExperienceModel= new EmployeeExperienceModel
                            {
                                Organization = reader["Organization"].ToString(),
                                FromDate= (DateTime)reader["FromDate"],
                                ToDate = (DateTime)reader["ToDate"],
                                Designation= reader["Designation"].ToString(),
                                
                            };
                            employee.ExperienceModels.Add(employeeExperienceModel);
                        }
                    }
                }

            }
            return employee;
        }
        public DataTable GetEmployeeCountInTechnology()
        {
            string Query = $"select Name,count(*) as TotalEmployee from EmsTblSkillForEmployee inner join EmsTblSkill On SkillId=id inner join EmsTblEmployee On EmployeeCode = code group by Name";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(Query, conn))
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
            string Query = $"Select Code,Name from EmsTblProject";
            List<string> Result = new List<string>();
            using (SqlConnection conn = new SqlConnection(connection.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(Query, conn))
                {
                    string name = string.Empty;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader.GetString(0);
                        name += "-";
                        name += reader.GetString(1);
                        Result.Add(name);
                        name = string.Empty;
                    }
                }
            }
            return Result;
        }
    }
}
