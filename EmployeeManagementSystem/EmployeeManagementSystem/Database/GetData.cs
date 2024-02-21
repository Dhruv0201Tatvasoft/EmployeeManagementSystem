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
                            else project.EndingDate=reader.GetDateTime(3);
                        }
                    }
                }
            }
            project.AssociatedTechnologies = ProjectTechnologies;
            return project;
        }
    }
}