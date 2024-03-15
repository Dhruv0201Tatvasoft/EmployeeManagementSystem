using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.DialogWindow;
using EmployeeManagementSystem.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModel
{
    class EmployeeViewModel : INotifyPropertyChanged
    {
        private GetData getData;
        private DeleteData deleteData;
        private InsertData insertData;
        private DataRowView selectedEmployee;

        public event EventHandler AddProjectEvent;
        private void OnAddProjectEvent(EventArgs empty)
        {
            AddProjectEvent?.Invoke(this, empty);
        }
        public DataRowView SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; OnPropertyChanged("SelectedEmployee"); }
        }

        private DataRowView selectedProjectRow;

        public DataRowView SelectedProjectRow
        {
            get { return selectedProjectRow; }
            set { selectedProjectRow = value; OnPropertyChanged("SelectedProjectRow"); }
        }


        private DataTable employeeDataTable;
        public DataTable EmployeeDatatable
        {
            get
            {
                return employeeDataTable;
            }
            set
            {
                employeeDataTable = value;
                OnPropertyChanged("EmployeeDataTable");
            }
        }
        private ObservableCollection<string> designation;

        public ObservableCollection<string> Designation
        {
            get { return designation; }
            set
            {
                designation = value;
                OnPropertyChanged("Designation");
            }
        }
        private ObservableCollection<string> department;

        public ObservableCollection<string> Department
        {
            get { return department; }
            set
            {
                department = value;
                OnPropertyChanged("Department");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }

        }
        private string combTextDesignation = "Select Designation";

        public string CombTextDesignation
        {
            get { return combTextDesignation; }
            set { combTextDesignation = value; OnPropertyChanged("CombTextDesignation"); }
        }

        private string selectedDesignation;
        public string SelectedDesignation
        {
            get
            {
                return selectedDesignation;
            }
            set
            {
                selectedDesignation = value;
                OnPropertyChanged("SelectedDesignation");
            }
        }

        private string combTextDepartment = "Select Department";

        public string CombTextDepartment
        {
            get { return combTextDepartment; }
            set
            {
                combTextDepartment = value;

                OnPropertyChanged("CombTextDepartment");
            }
        }
        private string selectedDepartment;
        public string SelectedDepartment
        {
            get
            {
                return selectedDepartment;
            }
            set
            {
                selectedDepartment = value;
                OnPropertyChanged("SelectedDepartment");
            }
        }

        private List<String> projectNames;

        public List<String> ProjectNames
        {
            get { return projectNames; }
            set
            {
                projectNames = value;
                OnPropertyChanged("ProjectNames");
            }
        }

        private String projectName;

        public String ProjectName
        {
            get { return projectName; }
            set
            {
                projectName = value;
                OnPropertyChanged("ProjectName");
            }
        }


        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(ClearExecute, CanClearExecute, false);
                }
                return clearCommand;
            }
        }

        private bool CanClearExecute(object arg)
        {
            return true;
        }

        private void ClearExecute(object obj)
        {
            email = String.Empty; Name = String.Empty; SelectedDepartment = null; SelectedDesignation = null;
            employeeDataTable = getData.GetEmployeeTable();
            OnPropertyChanged("EmployeeDataTable");
        }

        private ICommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new RelayCommand(ExecuteSearch, CanSearchExecute, false);
                }
                return searchCommand;
            }
        }
        private void ExecuteSearch(object obj)
        {
            employeeDataTable = getData.GetEmployeeSearchData(Email, Name, selectedDepartment, selectedDesignation);
            Email = String.Empty; Name = String.Empty; SelectedDepartment = null; SelectedDesignation = null;
            CombTextDepartment = "Select Department";
            CombTextDesignation = "Select Designation";
            OnPropertyChanged("EmployeeDataTable");
        }

        private bool CanSearchExecute(object arg)
        {
            return true;
        }

        private ICommand deleteEmployeeCommand;
        public ICommand DeleteEmployeeCommand
        {
            get
            {
                if (deleteEmployeeCommand == null)
                {
                    deleteEmployeeCommand = new RelayCommand(DeleteEmployeeCommandExecute, CanDeleteEmployeeCommandExecute, false);
                }
                return deleteEmployeeCommand;
            }
        }

        private bool CanDeleteEmployeeCommandExecute(object arg)
        {
            return true;
        }

        private void DeleteEmployeeCommandExecute(object obj)
        {
            string EmployeeCode = selectedEmployee[0].ToString();
            string Name = selectedEmployee[1].ToString();
            deleteData.DeleteEmployee(EmployeeCode, Name);
            employeeDataTable = getData.GetEmployeeTable();
            OnPropertyChanged("EmployeeDataTable");
        }

        
        private ICommand addEmployeeToProject;
        public ICommand AddEmployeeToProject
        {
            get
            {
                if (addEmployeeToProject == null)
                {
                    addEmployeeToProject = new RelayCommand(ExecuteAddEmployeeToProject, CanAddEmployeeToProjectExecute, false);

                }
                return addEmployeeToProject;
            }
        }

        private bool CanAddEmployeeToProjectExecute(object arg)
        {
            if (String.IsNullOrEmpty(projectName)) return false;
            return true;
        }

        private void ExecuteAddEmployeeToProject(object obj)
        {
            string EmployeeCode = (String)selectedEmployee.Row.ItemArray[0];
            string ProjectCode = projectName.Split('-')[0];
            string ProjectName = projectName.Split('-')[1];
            insertData.InsertProjectToEmployee(ProjectCode, ProjectName, EmployeeCode);
            OnAddProjectEvent(EventArgs.Empty);
        }

        private ICommand deleteEmployeeFromProject;
        public ICommand DeleteEmployeeFromProject
        {
            get
            {
                if (deleteEmployeeFromProject == null)
                {
                    deleteEmployeeFromProject = new RelayCommand(DeleteEmployeeFromProjectExecute, CanDeleteEmployeeFromProjectExecute, false);
                }
                return deleteEmployeeFromProject;
            }
        }

        private bool CanDeleteEmployeeFromProjectExecute(object arg)
        {
            if (selectedProjectRow == null) return false;
            return true;

        }

        private void DeleteEmployeeFromProjectExecute(object obj)
        {
            string EmployeeCode = (String)selectedEmployee.Row.ItemArray[0];
            string ProjectCode = (String)selectedProjectRow.Row.ItemArray[1];
            deleteData.RemoveEmployeeFromProject(EmployeeCode, ProjectCode);
            OnAddProjectEvent(EventArgs.Empty);
        }
        private ICommand viewEmployeeDetailsCommand;
        public ICommand ViewEmployeeDetailsCommand
        {
            get
            {
                if (viewEmployeeDetailsCommand == null)
                {
                    viewEmployeeDetailsCommand = new RelayCommand(ExecuteViewEmployeeDetailsCommand, CanViewEmployeeDetailsCommandExecute, false);
                }
                return viewEmployeeDetailsCommand;
            }

        }

        private bool CanViewEmployeeDetailsCommandExecute(object arg)
        {
            if (selectedEmployee == null) return false;
            return true;
        }

        private void ExecuteViewEmployeeDetailsCommand(object obj)
        {
            string EmployeeCode = (string)selectedEmployee.Row.ItemArray[0];
            EmployeeModel employee = getData.GetEmployeeModelFromCode(EmployeeCode);
            EmployeeDetails employeeDetails = new EmployeeDetails(employee);
            employeeDetails.ShowDialog();
        }

        public EmployeeViewModel()
        {
            getData = new GetData();
            deleteData = new DeleteData();
            insertData = new InsertData();
            EmployeeDatatable = getData.GetEmployeeTable();
            projectNames = getData.GetProjectNames();
            designation = new ObservableCollection<string>(new List<string> { "Developer", "Senior Developer", "Team Lead", "Manager" });
            department = new ObservableCollection<string>(new List<string> { "Dotnet", "Java", "PHP", "Mobile", "QA" });
            OnPropertyChanged("EmployeeDataTable");
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}