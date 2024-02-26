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
                    MessageBox.Show("Duplicate Data");
                }
                else
                {
                    MessageBox.Show("Some error occured");
                }
            }
        }


        public bool DeleteWarningMessage(string warning)
        {
            MessageBoxResult result = MessageBox.Show("Are You Sure you want to  " + warning, "Warning", MessageBoxButton.YesNoCancel,MessageBoxImage.Exclamation,MessageBoxResult.Cancel, MessageBoxOptions.DefaultDesktopOnly);
            return result == MessageBoxResult.Yes;
        }

        public void DeleteProject(String Code)
        {

            if (this.DeleteWarningMessage("Delete Project With Code " + Code))
            {
                string Query = $"delete from EmsTblTechnologyForProject where ProjectCode = '{Code}'";
                this.executeQuery(Query);
                Query = string.Empty ;
                Query = $"delete from EmsTblProject where Code = '{Code}' ";
                this.executeQuery(Query);
            }
        }

        public void removeEmployeeFromProject(String EmployeeCode, String ProjectCode, String EmployeeName)
        {
            if (this.DeleteWarningMessage("Remove " + EmployeeName + " From this Project"))
            {
                string query = $"Delete from EmsTblEmployeeAssociatedToProject Where ProjectCode = '{ProjectCode} ' AND EmployeeCode = '{EmployeeCode}'";
                this.executeQuery(query);
            }
        }
    }
}
