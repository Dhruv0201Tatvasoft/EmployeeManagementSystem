using EmployeeManagementSystem.Model;
using System.Data.SqlClient;
using System.Windows;

namespace EmployeeManagementSystem.Database
{
    class DeleteData
    {
        private GetConnection connection = new GetConnection();
        public bool ExecuteQuery(string query)
        {
            try
            {

                SqlConnection conn = connection.GenrateConnection();
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error in deleting data from database.", "Error");
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

            if (this.DeleteWarningMessage("Delete Project With code " + code))
            {
                string query = $"delete from EmsTblTechnologyForProject where ProjectCode = '{code}'";
                this.ExecuteQuery(query);
                query = $"delete from EmsTblProject where code = '{code}' ";
                this.ExecuteQuery(query);
            }
        }

        public void RemoveEmployeeFromProject(String employeeCode, String projectCode)
        {
            
                string query = $"delete from EmsTblEmployeeAssociatedToProject where ProjectCode = '{projectCode} ' AND EmployeeCode = '{employeeCode}'";
                this.ExecuteQuery(query);
            
        }

        public void DeleteTechnology(String technologyName)
        {

            if (this.DeleteWarningMessage("Remove " + technologyName + " From Data"))
            {
                string query = $"delete From EmsTblTechnology where name like '{technologyName}'";
                this.ExecuteQuery(query);
            }
        }
        public void DeleteSkill(String skillName)
        {

            if (this.DeleteWarningMessage("Remove " + skillName + " From Data"))
            {
                string query = $"delete From EmsTblSkill where name like '{skillName}'";
                this.ExecuteQuery(query);
            }
        }

        public bool DeleteEducationRow(EmployeeEducationModel employeeEducationModel, String code)
        {
            if (this.DeleteWarningMessage("Remove this education field form Data"))
            {
                string query = $"delete from EmsTblEmployeeEducation where employeeCode Like '{code}' and Qualification like " +
                    $"'{employeeEducationModel.Qualification}' AND Board Like '{employeeEducationModel.BoardUniversity}' AND Institute like '{employeeEducationModel.InstituteName}' AND State Like '{employeeEducationModel.State}' AND " +
                    $"PassingYear like '{employeeEducationModel.PassingYear}' AND Percentage like '{employeeEducationModel.Percentage}'";
                this.ExecuteQuery(query);
                return true;
            }
            return false;
        }
        public bool DeleteExperienceRow(EmployeeExperienceModel employeeExperienceModel, String code)
        {
            if (this.DeleteWarningMessage("Remove this Experience field form Data"))
            {
                string query = $"Delete from EmsTblEmployeeExperience where employeeCode Like '{code}' and Organization like " +
                    $"'{employeeExperienceModel.Organization}' AND FromDate = '{employeeExperienceModel.FromDate.Value.ToString("yyyy-MM-dd")}'" +
                    $" AND ToDate = '{employeeExperienceModel.ToDate.Value.ToString("yyyy-MM-dd")}' " +
                    $"AND Designation Like '{employeeExperienceModel.Designation}'";
                this.ExecuteQuery(query);
                return true;
            }
            return false;
        }
        public void DeleteEmployee(String code ,String name)
        {
            if(this.DeleteWarningMessage($"Delete {name} From Data"))
            {
                string query = $"delete From EmsTblEmployee where code like '{code}'";
                this.ExecuteQuery(query);
            }
        }

      
    }
}
