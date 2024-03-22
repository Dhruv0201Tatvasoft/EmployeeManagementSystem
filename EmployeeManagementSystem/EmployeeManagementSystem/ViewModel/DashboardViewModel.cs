using EmployeeManagementSystem.Database;
using System.ComponentModel;
using System.Data;

namespace EmployeeManagementSystem.ViewModel
{
    internal class DashboardViewModel : INotifyPropertyChanged
    {
        private GetData getData;

        private DataTable pastSixMonthJoinedEmployee;
        public DataTable PastSixMonthJoinedEmployee
        {
            get
            {
                return pastSixMonthJoinedEmployee;
            }
            set
            {
                pastSixMonthJoinedEmployee = value;
                OnPropertyChanged("pastSixMonthJoinedEmployee");
            }
        }
        private DataTable technologyNames;

        public DataTable TechnologyNames
        {
            get { return technologyNames; }
            set { technologyNames = value; }
        }


        private DataTable pastSixMonthReleaseDataTable;
        public DataTable PastSixMonthReleaseDataTable
        {
            get
            {
                return pastSixMonthReleaseDataTable;
            }
            set
            {
                pastSixMonthReleaseDataTable = value;
                OnPropertyChanged("pastSixMonthReleaseDataTable");
            }
        }

        private DataTable designationWiseEmployee;
            
        public DataTable DesignationWiseEmpmloyee
        {
            get
            {
                return designationWiseEmployee;
            }
            set
            {
                designationWiseEmployee = value;
                OnPropertyChanged("DesignationWiseEmpmloyee");
            }
        }
        private DataTable technologyWiseProject;

        public DataTable TechnologyWiseProject
        {
            get { return technologyWiseProject; }
            set { technologyWiseProject = value; }
        }
        private DataTable skillWiseEmployee;

        public DataTable  SkillWiseEmployee
            {
            get { return skillWiseEmployee; }
            set { skillWiseEmployee = value; }
        }
        private DataTable skillsNames;

        public DataTable SkillsNames
        {
            get { return skillsNames; }
            set { skillsNames = value; }
        }


        public DashboardViewModel()
        {
            getData = new GetData();
            designationWiseEmployee = getData.DesignationWiseEmployee();
            pastSixMonthReleaseDataTable = getData.GetPastSixMonthReleasedEmployee();
            pastSixMonthJoinedEmployee =getData.GetPastSixMonthJoinedEmployee();
            technologyNames = getData.GetTechnologyTable();
            technologyWiseProject = getData.GetTechnologyWiseProject();
            skillWiseEmployee = getData.GetSkillWiseEmployeeCount();
            skillsNames = getData.GetSkillTable();
            

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
   
    

   
}
