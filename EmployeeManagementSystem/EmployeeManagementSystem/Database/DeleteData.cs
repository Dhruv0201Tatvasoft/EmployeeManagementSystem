using EmployeeManagementSystem.Model;
using System.Data.SqlClient;
using System.Windows;

namespace EmployeeManagementSystem.Database
{
    class DeleteData
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
                    MessageBox.Show("Error in deleting data from database");
                    return false;
                }
            }

        }
        public bool DoesExist(SqlCommand command)
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



        public bool DeleteWarningMessage(string warning)
        {
            MessageBoxResult result = MessageBox.Show("Are You Sure you want to  " + warning, "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Cancel, MessageBoxOptions.DefaultDesktopOnly);
            return result == MessageBoxResult.Yes;
        }

        public void DeleteProject(string code)
        {

            if (this.DeleteWarningMessage("Delete this project?"))
            {

                String query = "DELETE from EmsTblProject where Code LIKE @Code";
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;
                command.Parameters.AddWithValue("@Code", code);
                ExecuteQuery(command);
            }
        }

        public void RemoveEmployeeFromProject(String employeeCode, String projectCode)
        {
            string query = "DELETE from EmsTblEmployeeAssociatedToProject where ProjectCode LIKE @ProjectCode AND EmployeeCode LIKE @EmployeeCode";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ProjectCode", projectCode);
            command.Parameters.AddWithValue("@EmployeeCode", employeeCode);
            ExecuteQuery(command); ;

        }

        public void DeleteTechnology(String technologyName)
        {

            if (this.DeleteWarningMessage("Delete this Technology?"))
            {
                string query = "DELETE from EmsTblTechnology where Name LIKE @TechnologyName";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@TechnologyName", technologyName);
                ExecuteQuery(command);
            }
        }
        public void DeleteSkill(String skillName)
        {

            if (this.DeleteWarningMessage("Delete this Skill?"))
            {
                string query = "DELETE from EmsTblSkill where Name LIKE @SkillName";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@SkillName", skillName);
                ExecuteQuery(command);
            }
        }

        public bool DeleteEducationRow(EmployeeEducationModel employeeEducationModel, String code)
        {
            if (this.DeleteWarningMessage("Remove this education field?"))
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
        public bool DeleteExperienceRow(EmployeeExperienceModel employeeExperienceModel, String code)
        {
            if (this.DeleteWarningMessage("Remove this Experience field?"))
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
        public void DeleteEmployee(String code, String name)
        {
            if (this.DeleteWarningMessage($"Delete this employee?"))
            {
                string query = "DELETE from EmsTblEmployee where Code LIKE @Code";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@Code", code);
                ExecuteQuery(command);
            }
        }


    }
}
