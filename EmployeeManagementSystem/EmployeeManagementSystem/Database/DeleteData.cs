using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementSystem.Database
{
    class DeleteData
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

        public void DeleteProject(String Code)
        {

            if (this.DeleteWarningMessage("Delete Project With Code " + Code))
            {
                string Query = $"delete from EmsTblTechnologyForProject where ProjectCode = '{Code}'";
                this.executeQuery(Query);
                Query = string.Empty;
                Query = $"delete from EmsTblProject where Code = '{Code}' ";
                this.executeQuery(Query);
            }
        }

        public void RemoveEmployeeFromProject(String EmployeeCode, String ProjectCode)
        {
            
                string query = $"Delete from EmsTblEmployeeAssociatedToProject Where ProjectCode = '{ProjectCode} ' AND EmployeeCode = '{EmployeeCode}'";
                this.executeQuery(query);
            
        }

        public void DeleteTechnology(String TechnologyName)
        {

            if (this.DeleteWarningMessage("Remove " + TechnologyName + " From Data"))
            {
                string Query = $"Delete From EmsTblTechnology where Name like '{TechnologyName}'";
                this.executeQuery(Query);
            }
        }
        public void DeleteSkill(String SkillName)
        {

            if (this.DeleteWarningMessage("Remove " + SkillName + " From Data"))
            {
                string Query = $"Delete From EmsTblSkill where Name like '{SkillName}'";
                this.executeQuery(Query);
            }
        }

        public bool DeleteEducationRow(EmployeeEducationModel EmployeeEducationModel, String Code)
        {
            if (this.DeleteWarningMessage("Remove this education field form Data"))
            {
                string Query = $"Delete from EmsTblEmployeeEducation where EmployeeCode Like '{Code}' and Qualification like " +
                    $"'{EmployeeEducationModel.Qualification}' AND Board Like '{EmployeeEducationModel.BoardUniversity}' AND Institute like '{EmployeeEducationModel.InstituteName}' AND State Like '{EmployeeEducationModel.State}' AND " +
                    $"PassingYear like '{EmployeeEducationModel.PassingYear}' AND Percentage like '{EmployeeEducationModel.Percentage}'";
                this.executeQuery(Query);
                return true;
            }
            return false;
        }
        public bool DeleteExperienceRow(EmployeeExperienceModel EmployeeExperienceModel, String Code)
        {
            if (this.DeleteWarningMessage("Remove this Experience field form Data"))
            {
                string Query = $"Delete from EmsTblEmployeeExperience where EmployeeCode Like '{Code}' and Organization like " +
                    $"'{EmployeeExperienceModel.Organization}' AND FromDate = '{EmployeeExperienceModel.FromDate.Value.ToString("yyyy-MM-dd")}'" +
                    $" AND ToDate = '{EmployeeExperienceModel.ToDate.Value.ToString("yyyy-MM-dd")}' " +
                    $"AND Designation Like '{EmployeeExperienceModel.Designation}'";
                this.executeQuery(Query);
                return true;
            }
            return false;
        }
        public void DeleteEmployee(String Code ,String Name)
        {
            if(this.DeleteWarningMessage($"Delete {Name} From Data"))
            {
                string Query = $"Delete From EmsTblEmployee where code like '{Code}'";
                this.executeQuery(Query);
            }
        }

      
    }
}
