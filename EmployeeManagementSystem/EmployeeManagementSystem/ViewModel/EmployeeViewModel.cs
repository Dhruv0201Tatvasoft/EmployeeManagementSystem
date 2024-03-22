using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.DialogWindow;
using EmployeeManagementSystem.EventArg;
using EmployeeManagementSystem.Model;
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

        public event EventHandler? AddProjectEvent;
        private void OnAddProjectEvent(EventArgs empty)
        {
            AddProjectEvent?.Invoke(this, empty);
        }
        private DataRowView? selectedEmployee;
        public DataRowView? SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; OnPropertyChanged("SelectedEmployee"); }
        }

        private DataRowView? selectedProjectRow;

        public DataRowView? SelectedProjectRow
        {
            get { return selectedProjectRow; }
            set { selectedProjectRow = value; OnPropertyChanged("SelectedProjectRow"); }
        }
        public event EventHandler<EmployeeEventArgs>? EditEvent;
        public void OnEditEvent(EmployeeModel employee)
        {
            var e = new EmployeeEventArgs(employee);
            EditEvent?.Invoke(this, e);
        }


        private DataTable? employeeDataTable;
        public DataTable? EmployeeDatatable
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

        private string? name;
        public string? Name
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

        private string? email;
        public string? Email
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

        private string? selectedDesignation;
        public string? SelectedDesignation
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
        private string? selectedDepartment;
        public string? SelectedDepartment
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

        private List<String>? projectNames;

        public List<String>? ProjectNames
        {
            get { return projectNames; }
            set
            {
                projectNames = value;
                OnPropertyChanged("ProjectNames");
            }
        }

        private String? projectName;

        public String? ProjectName
        {
            get { return projectName; }
            set
            {
                projectName = value;
                OnPropertyChanged("ProjectName");
            }
        }


        private ICommand? clearFields;
        public ICommand ClearFields
        {
            get
            {
                if (clearFields == null)
                {
                    clearFields = new RelayCommand(ExecuteClearFields, CanClearFieldsExecute, false);
                }
                return clearFields;
            }
        }

        private bool CanClearFieldsExecute(object arg)
        {
            return true;
        }

        private void ExecuteClearFields(object obj)
        {
            email = String.Empty; Name = String.Empty; SelectedDepartment = null; SelectedDesignation = null;
            CombTextDepartment = "Select Department";
            CombTextDesignation = "Select Designation";
            employeeDataTable = getData.GetEmployeeTable();
            OnPropertyChanged("EmployeeDataTable");
        }

        private ICommand? searchEmployee;
        public ICommand SearchEmployee
        {
            get
            {
                if (searchEmployee == null)
                {
                    searchEmployee = new RelayCommand(ExecuteSearchEmployee, CanSearchEmployeeExecute, false);
                }
                return searchEmployee;
            }
        }
        private void ExecuteSearchEmployee(object obj)
        {
            employeeDataTable = getData.GetEmployeeSearchData(Email!, Name!, selectedDepartment!, selectedDesignation!);
            OnPropertyChanged("EmployeeDataTable");
        }

        private bool CanSearchEmployeeExecute(object arg)
        {
            return true;
        }

        private ICommand? deleteEmployee;
        public ICommand DeleteEmployee
        {
            get
            {
                if (deleteEmployee == null)
                {
                    deleteEmployee = new RelayCommand(ExecuteDeleteEmployee, CanDeleteEmployeeExecute, false);
                }
                return deleteEmployee;
            }
        }

        private bool CanDeleteEmployeeExecute(object arg)
        {
            return true;
        }

        private void ExecuteDeleteEmployee(object obj)
        {
            string EmployeeCode = selectedEmployee?[0].ToString()!;
            string Name = selectedEmployee?[1].ToString()!;
            deleteData.DeleteEmployee(EmployeeCode, Name);
            employeeDataTable = getData.GetEmployeeTable();
            OnPropertyChanged("EmployeeDataTable");
        }


        private ICommand? addEmployeeToProject;
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
            string EmployeeCode = (String)selectedEmployee?.Row.ItemArray[0]!;
            if (projectName != null)
            {
                string ProjectCode = projectName.Split('-')[0];
                string ProjectName = projectName.Split('-')[1];
                insertData.InsertProjectToEmployee(ProjectCode, ProjectName, EmployeeCode);
            }
            OnAddProjectEvent(EventArgs.Empty);
        }

        private ICommand? editEmployee;
        public ICommand EditEmployee
        {
            get
            {
                if (editEmployee == null)
                {
                    editEmployee = new RelayCommand(ExecuteEditEmployee, CanEditEmployeeExecute, false);
                }
                return editEmployee;
            }
        }

        private bool CanEditEmployeeExecute(object arg)
        {
            return true;
        }

        private void ExecuteEditEmployee(object obj)
        {
            if (selectedEmployee != null)
            {
               EmployeeModel employee = getData.GetEmployeeFromCode(selectedEmployee.Row[0].ToString()!);
                OnEditEvent(employee);
            }
        }

        private ICommand? removeEmployeeFromProject;
        public ICommand RemoveEmployeeFromProject
        {
            get
            {
                if (removeEmployeeFromProject == null)
                {
                    removeEmployeeFromProject = new RelayCommand(ExecuteRemoveEmployeeFromProject, CanRemoveEmployeeFromProjectExecute, false);
                }
                return removeEmployeeFromProject;
            }
        }

        private bool CanRemoveEmployeeFromProjectExecute(object arg)
        {
            if (selectedProjectRow == null) return false;
            return true;

        }

        private void ExecuteRemoveEmployeeFromProject(object obj)
        {
            string EmployeeCode = (String)selectedEmployee?.Row.ItemArray[0]!;
            string ProjectCode = (String)selectedProjectRow?.Row.ItemArray[1]!;
            deleteData.RemoveEmployeeFromProject(EmployeeCode, ProjectCode);
            OnAddProjectEvent(EventArgs.Empty);
        }
        private ICommand? viewEmployeeDetails;
        public ICommand ViewEmployeeDetails
        {
            get
            {
                if (viewEmployeeDetails == null)
                {
                    viewEmployeeDetails = new RelayCommand(ExecuteViewEmployeeDetails, CanViewEmployeeDetailsExecute, false);
                }
                return viewEmployeeDetails;
            }

        }

        private bool CanViewEmployeeDetailsExecute(object arg)
        {
            if (selectedEmployee == null) return false;
            return true;
        }

        private void ExecuteViewEmployeeDetails(object obj)
        {
            string EmployeeCode = (string)selectedEmployee?.Row.ItemArray[0]!;
            EmployeeModel employee = getData.GetEmployeeFromCode(EmployeeCode);
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
            designation = new ObservableCollection<string> { "Developer", "Senior Developer", "Team Lead", "Manager" };
            department = new ObservableCollection<string> { "Dotnet", "Java", "PHP", "Mobile", "QA" };
            OnPropertyChanged("EmployeeDataTable");
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}