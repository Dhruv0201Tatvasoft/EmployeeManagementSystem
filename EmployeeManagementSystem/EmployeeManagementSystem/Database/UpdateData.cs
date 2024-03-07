using EmployeeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementSystem.Database
{
    internal class UpdateData
    {
        private GetConnection connection = new GetConnection();
        public bool executeQuery(string sql)
        {
            try
            {

                SqlConnection conn = connection.GenrateConnection();
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Some error occured");
                return false;
            }


        }
        public bool DoesExist(string Query)
        {
            try
            {
                using (SqlConnection conn = connection.GenrateConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(Query, conn))
                    {

                        SqlDataReader reader = command.ExecuteReader();
                        return reader.HasRows;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Something Went Wrong");
                return false;
            }
        }
        public void UpdateProject(String OldCode, String Code, String Name, DateTime StaringDate, DateTime EndingDate, List<int> TechnologiesId)
        {

            try
            {
                if (OldCode == Code)
                {
                    string sqlQuery = string.Empty;
                    sqlQuery = $"DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode ='{OldCode}' ";
                    this.executeQuery(sqlQuery);
                    sqlQuery = $"UPDATE EmsTblProject SET " +
                        $"Code = '{Code}' ," +
                        $" Name = '{Name}' , " +
                        $"StartingDate = '{StaringDate.ToString("yyyy-MM-dd")}',  " +
                        $"EndingDate = '{EndingDate.ToString("yyyy-MM-dd")}'" +
                        $" WHERE Code ='{OldCode}'  ";
                    this.executeQuery(sqlQuery);
                    foreach (int i in TechnologiesId)
                    {
                        this.executeQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{Code}','{i}')");
                    }
                }
                else if (OldCode != Code && !this.DoesExist($"Select * from EmsTblProject where Code like '{Code}'"))
                {

                    string sqlQuery = string.Empty;
                    sqlQuery = $"DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode ='{OldCode}' ";
                    this.executeQuery(sqlQuery);
                    sqlQuery = $"UPDATE EmsTblProject SET " +
                        $"Code = '{Code}' ," +
                        $" Name = '{Name}' , " +
                        $"StartingDate = '{StaringDate.ToString("yyyy-MM-dd")}',  " +
                        $"EndingDate = '{EndingDate.ToString("yyyy-MM-dd")}'" +
                        $" WHERE Code ='{OldCode}'  ";
                    this.executeQuery(sqlQuery);
                    foreach (int i in TechnologiesId)
                    {
                        this.executeQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{Code}','{i}')");
                    }
                }

                else
                {
                    MessageBox.Show($"There is Already Project With The Code {Code}");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Some Unexpected Error Occured", "Warning");
            }

        }

        public void UpdateProject(String OldCode, String Code, String Name, DateTime StaringDate, List<int> TechnologiesId)
        {
            try
            {
                if (OldCode == Code || (OldCode != Code && !this.DoesExist($"Select * from EmsTblProject where Code like '{Code}'")))
                {
                    string sqlQuery = string.Empty;
                    sqlQuery = $"DELETE FROM EmsTblTechnologyForProject WHERE ProjectCode ='{OldCode}' ";
                    this.executeQuery(sqlQuery);
                    sqlQuery = $"UPDATE  EmsTblProject SET " +
                        $"Code = '{Code}' ," +
                        $" Name = '{Name}' , " +
                        $"StartingDate = '{StaringDate.ToString("yyyy-MM-dd")}',  " +
                        $"EndingDate = NULL" +
                        $" WHERE Code ='{OldCode}' ";
                    this.executeQuery(sqlQuery);
                    foreach (int i in TechnologiesId)
                    {
                        this.executeQuery($"Insert into EmsTblTechnologyForProject (ProjectCode,TechnologyId) values ('{Code}','{i}')");
                    }
                }

                else
                {
                    MessageBox.Show($"There is Already Project With The Code {Code}");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some Unexpected Error Occured", "Warning");
            }

        }
        public void UpdateTechnologyName(string NewTechnologyName, string OldTechnologyName)
        {
            if (!DoesExist($"Select * from EmsTblTechnology where name like '{NewTechnologyName}'"))
            {
                string Query = $"Update EmsTblTechnology SET Name = '{NewTechnologyName}' where name like '{OldTechnologyName}'";
                this.executeQuery(Query);
            }
            else
            {
                MessageBox.Show($" {NewTechnologyName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }
        public void UpdateSkillName(string NewSkillName, string OldSkillName)
        {
            if (!DoesExist($"Select * from EmsTblSkill where name like '{NewSkillName}'"))
            {
                string Query = $"Update EmsTblSkill SET Name = '{NewSkillName}' where name like '{OldSkillName}'";
                this.executeQuery(Query);
            }
            else
            {
                MessageBox.Show($" {NewSkillName} already exist in data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }
        public bool UpdateEmployeeEducation(EmployeeEducationModel newModel, EmployeeEducationModel oldModel, String Code)
        {
            string Query = $"Update EmsTblEmployeeEducation SET Qualification = '{newModel.Qualification}' , Board = '{newModel.BoardUniversity}' ," +
                 $"Institute = '{newModel.InstituteName}' , State = '{newModel.State}' , PassingYear = '{newModel.PassingYear}' , Percentage = '{newModel.Percentage}' " +
                 $"Where EmployeeCode like '{Code}' AND Qualification like '{oldModel.Qualification}' AND Board like '{oldModel.BoardUniversity}' AND" +
                 $" Institute like '{oldModel.InstituteName}' AND State like '{oldModel.State}' AND PassingYear like '{oldModel.PassingYear}'" +
                 $"AND Percentage like '{oldModel.Percentage}' ";
            bool didExecute = this.executeQuery(Query);
            return didExecute;
        }
        public bool UpdateEmployeeExperience(EmployeeExperienceModel newModel, EmployeeExperienceModel oldModel, String Code)
        {
            string Query = $"Update EmsTblEmployeeExperience SET Organization = '{newModel.Organization}' , FromDate = '{newModel.FromDate.Value.ToString("yyyy-MM-dd")}' ," +
                 $"ToDate = '{newModel.ToDate.Value.ToString("yyyy-MM-dd")}' , Designation = '{newModel.Designation}' " +
                 $"Where EmployeeCode like '{Code}' AND Organization like '{oldModel.Organization}' AND FromDate = '{oldModel.FromDate.Value.ToString("yyyy-MM-dd")}' AND" +
                 $" ToDate = '{oldModel.ToDate.Value.ToString("yyyy-MM-dd")}' AND Designation like '{oldModel.Designation}' ";
            bool didExecute = this.executeQuery(Query);
            return didExecute;
        }
        public bool UpdateEmployee(String OldCode, String Code, String FirstName, String LastName, String Email, String Password, String Designation, String Department, DateTime JoiningDate, DateTime DOB, String ContactNumber, String Gender, String MaritalStatus, String PresentAddress, String PermanentAdress)
        {
            if (OldCode == Code || (OldCode != Code && !this.DoesExist($"Select * from EmsTblEmployee where Code like '{Code}'")))
            {
                string Query = $"UPDATE EmsTblEmployee SET Code = '{Code}', FirstName = '{FirstName}', LastName = '{LastName}',Email = '{Email}', " +
                    $"Password = '{Password}', Designation = '{Designation}', Department = '{Department}', JoiningDate = '{JoiningDate.ToString("yyyy-MM-dd")}', " +
                    $"DOB = '{DOB.ToString("yyyy-MM-dd")}', ContactNumber = '{ContactNumber}', Gender = '{Gender}', MaritalStatus = '{MaritalStatus}', PresentAddress = '{PresentAddress}', " +
                    $"PermanentAdress = '{PermanentAdress}' WHERE Code = '{OldCode}'";
                this.executeQuery(Query);
                return true;
            }
            else
            {
                MessageBox.Show($"There is aleady an employee with Employee Code {Code}", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
        }

        public bool UpdateEmployee(String OldCode, String Code, String FirstName, String LastName, String Email, String Password, String Designation, String Department, DateTime JoiningDate,DateTime ReleaseDate ,DateTime DOB, String ContactNumber, String Gender, String MaritalStatus, String PresentAddress, String PermanentAdress)
        {
            if (OldCode == Code || (OldCode != Code && !this.DoesExist($"Select * from EmsTblEmployee where Code like '{Code}'")))
            {
                string Query = $"UPDATE EmsTblEmployee SET Code = '{Code}', FirstName = '{FirstName}', LastName = '{LastName}',Email = '{Email}', " +
                    $"Password = '{Password}', Designation = '{Designation}', Department = '{Department}', JoiningDate = '{JoiningDate.ToString("yyyy-MM-dd")}', " +
                    $"ReleaseDate = '{ReleaseDate.ToString("yyyy-MM-dd")}', DOB = '{DOB.ToString("yyyy-MM-dd")}', ContactNumber = '{ContactNumber}', Gender = '{Gender}', MaritalStatus = '{MaritalStatus}', PresentAddress = '{PresentAddress}', " +
                    $"PermanentAdress = '{PermanentAdress}' WHERE Code = '{OldCode}'";
                this.executeQuery(Query);
                return true;
            }
            else
            {
                MessageBox.Show($"There is aleady an employee with Employee Code {Code}", "Warning", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
        }
    }
}
