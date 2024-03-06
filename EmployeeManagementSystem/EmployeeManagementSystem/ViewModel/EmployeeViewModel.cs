using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace EmployeeManagementSystem.ViewModel
{
    class EmployeeViewModel : INotifyPropertyChanged
    {
        private GetData getData;
        private DeleteData deleteData;
        private DataRowView selectedEmployee;

        public DataRowView SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; OnPropertyChanged("SelectedEmployee"); }
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

        private string code;
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        
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


        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if(clearCommand == null)
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
            Code = String.Empty; Name = String.Empty; SelectedDepartment = null; SelectedDesignation = null;
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

        private void ExecuteSearch(object obj)
        {
            employeeDataTable = getData.GetEmployeeSearchData(Code, Name, selectedDepartment, selectedDesignation);
            Code = String.Empty; Name =String.Empty; SelectedDepartment= null; SelectedDesignation=null;
            OnPropertyChanged("EmployeeDataTable");
        }

        private bool CanSearchExecute(object arg)
        {
            return true;
        }

        public EmployeeViewModel()
        {
            getData = new GetData();
            deleteData = new DeleteData();
            EmployeeDatatable = getData.GetEmployeeTable();
            designation = new ObservableCollection<string>(new List<string> { "Developer", "Senior Developer", "Team lead", "Manager" });
            department = new ObservableCollection<string>(new List<String> { "Dotnet", "Java", "PHP", "Mobile", "QA" });
            OnPropertyChanged("EmployeeDataTable");
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}