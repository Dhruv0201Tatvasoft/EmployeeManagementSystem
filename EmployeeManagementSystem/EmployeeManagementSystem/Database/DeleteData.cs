using EmployeeManagementSystem.Model;
using System.Data.SqlClient;
using System.Windows;

namespace EmployeeManagementSystem.Database
{
    class DeleteData
    {
        private GetConnection connection = new GetConnection();
        public void ExecuteQuery(string sql)
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
                    MessageBox.Show("Same Recoed Already Exist in Data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (ex.Number == 547)
                {
                    MessageBox.Show("Cannot delete the record due to existing references in other Projects.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Some error occured");
                }
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
                string query = $"delete from EmsTblTechnologyForProject where projectCode = '{code}'";
                this.ExecuteQuery(query);
                query = string.Empty;
                query = $"delete from EmsTblProject where code = '{code}' ";
                this.ExecuteQuery(query);
            }
        }

        public void RemoveEmployeeFromProject(String employeeCode, String projectCode)
        {
            
                string query = $"Delete from EmsTblEmployeeAssociatedToProject Where projectCode = '{projectCode} ' AND employeeCode = '{employeeCode}'";
                this.ExecuteQuery(query);
            
        }

        public void DeleteTechnology(String technologyName)
        {

            if (this.DeleteWarningMessage("Remove " + technologyName + " From Data"))
            {
                string query = $"Delete From EmsTblTechnology where name like '{technologyName}'";
                this.ExecuteQuery(query);
            }
        }
        public void DeleteSkill(String skillName)
        {

            if (this.DeleteWarningMessage("Remove " + skillName + " From Data"))
            {
                string query = $"Delete From EmsTblSkill where name like '{skillName}'";
                this.ExecuteQuery(query);
            }
        }

        public bool DeleteEducationRow(EmployeeEducationModel employeeEducationModel, String code)
        {
            if (this.DeleteWarningMessage("Remove this education field form Data"))
            {
                string query = $"Delete from EmsTblEmployeeEducation where employeeCode Like '{code}' and Qualification like " +
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
                string query = $"Delete From EmsTblEmployee where code like '{code}'";
                this.ExecuteQuery(query);
            }
        }

      
    }
}
