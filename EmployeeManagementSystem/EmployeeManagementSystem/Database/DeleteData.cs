using EmployeeManagementSystem.Model;
using System.Data.SqlClient;
using System.Windows;

namespace EmployeeManagementSystem.Database
{
    class DeleteData
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
            catch (SqlException)
            {
                {
                    MessageBox.Show("Error in deleting data from database");
                    return false;
                }
            }

        }

        /// <summary>
        /// Checks if the result exists in database.
        /// </summary>
        /// <param name="command">sqlCommand to check if result exists in database.</param>
        /// <returns>true if result exists in database otherwise false.</returns>
        public bool DoesExist(SqlCommand command)
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
         /// Shows MessageBox of warning before deleting the entry form database.
         /// </summary>
         /// <param name="warning">Warning to show to user.</param>
         /// <returns>true if user presses yes (i.e. gives permission to delete the entry) otherwise false.</returns>
        private bool DeleteWarningMessage(string warning)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to " + warning, "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Cancel, MessageBoxOptions.DefaultDesktopOnly);
            return result == MessageBoxResult.Yes;
        }


        /// <summary>
        /// Deletes project from database.
        /// </summary>
        /// <param name="code">code of project to be deleted.</param>
        public void DeleteProject(string code)
        {

            if (this.DeleteWarningMessage("delete this project?"))
            {

                String query = "DELETE from EmsTblProject where Code LIKE @Code";
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;
                command.Parameters.AddWithValue("@Code", code);
                ExecuteQuery(command);
            }
        }

        /// <summary>
        /// Removes employee form certain project.
        /// </summary>
        /// <param name="employeeCode">code of employee to be removed.</param>
        /// <param name="projectCode">code of project from which employee is being removed.</param>
        public void RemoveEmployeeFromProject(String employeeCode, String projectCode)
        {
            string query = "DELETE from EmsTblEmployeeAssociatedToProject where ProjectCode LIKE @ProjectCode AND EmployeeCode LIKE @EmployeeCode";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ProjectCode", projectCode);
            command.Parameters.AddWithValue("@EmployeeCode", employeeCode);
            ExecuteQuery(command); ;

        }

        /// <summary>
        /// Deletes technology from database.
        /// </summary>
        /// <param name="technologyName">name of technology to be deleted.</param>
        public void DeleteTechnology(String technologyName)
        {

            if (this.DeleteWarningMessage("delete this technology?"))
            {
                string query = "DELETE from EmsTblTechnology where Name LIKE @TechnologyName";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@TechnologyName", technologyName);
                ExecuteQuery(command);
            }
        }

        /// <summary>
        /// Deletes skill from database.
        /// </summary>
        /// <param name="skillName">name of skill to be deleted.</param>
        public void DeleteSkill(String skillName)
        {

            if (this.DeleteWarningMessage("delete this skill?"))
            {
                string query = "DELETE from EmsTblSkill where Name LIKE @SkillName";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@SkillName", skillName);
                ExecuteQuery(command);
            }
        }

        /// <summary>
        /// Delete employee's education field from database. 
        /// </summary>
        /// <param name="employeeEducationModel">object of employeeEducationModel that needs to be deleted from database.</param>
        /// <param name="code">code of employee whose education field is being removed.</param>
        /// <returns>True if delete query executes successfully otherwise false.</returns>
        public bool DeleteEducationRow(EmployeeEducationModel employeeEducationModel, String code)
        {
            if (this.DeleteWarningMessage("remove this education field?"))
            {
                string query = "DELETE from EmsTblEmployeeEducation where EmployeeCode LIKE @Code " +
                      "AND Qualification LIKE @Qualification " +
                      "AND Board LIKE @Board " +
                      "AND Institute LIKE @Institute " +
                      "AND State LIKE @State " +
                      "AND PassingYear LIKE @PassingYear " +
                      "AND Percentage LIKE @Percentage";

                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@Qualification", employeeEducationModel.Qualification);
                command.Parameters.AddWithValue("@Board", employeeEducationModel.BoardUniversity);
                command.Parameters.AddWithValue("@Institute", employeeEducationModel.InstituteName);
                command.Parameters.AddWithValue("@State", employeeEducationModel.State);
                command.Parameters.AddWithValue("@PassingYear", employeeEducationModel.PassingYear);
                command.Parameters.AddWithValue("@Percentage", employeeEducationModel.Percentage);

                ExecuteQuery(command);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete employee's experience field form database.
        /// </summary>
        /// <param name="employeeExperienceModel">code of employee whose experience field to be removed.</param>
        /// <param name="code">code of employee whose experience to be removed.</param>
        /// <returns>True if delete query executes successfully otherwise false.</returns>
        public bool DeleteExperienceRow(EmployeeExperienceModel employeeExperienceModel, String code)
        {
            if (this.DeleteWarningMessage("remove this experience field?"))
            {
                string query = "DELETE from EmsTblEmployeeExperience where EmployeeCode LIKE @Code " +
                          "AND Organization LIKE @Organization " +
                          "AND FromDate = @FromDate " +
                          "AND ToDate = @ToDate " +
                          "AND Designation LIKE @Designation";

                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@Organization", employeeExperienceModel.Organization);
                command.Parameters.AddWithValue("@FromDate", employeeExperienceModel.FromDate?.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@ToDate", employeeExperienceModel.ToDate?.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Designation", employeeExperienceModel.Designation);

                ExecuteQuery(command);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Delete employee from database.
        /// </summary>
        /// <param name="code">code of employee who needs to be deleted.</param>
        /// <param name="name">name of employee to be deleted.</param>
        public void DeleteEmployee(String code, String name)
        {
            if (this.DeleteWarningMessage($"delete this employee?"))
            {
                string query = "DELETE from EmsTblEmployee where Code LIKE @Code";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@Code", code);
                ExecuteQuery(command);
            }
        }


    }
}
