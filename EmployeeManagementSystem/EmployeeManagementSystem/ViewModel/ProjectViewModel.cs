using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO.Packaging;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup.Localizer;

namespace EmployeeManagementSystem.ViewModel
{
    internal class ProjectViewModel : INotifyPropertyChanged
    {
        public event EventHandler AddEmployeeEvent;
        public void OnAddEmployeeEvent(EventArgs e)
        {
            AddEmployeeEvent?.Invoke(this, e);
        }
       
        public event EventHandler EditEvent;
        public void OnEditEvent(EventArgs e)
        {
            EditEvent?.Invoke(this, e);
        }
        private DeleteData deleteData;
        private DataRowView selectedRow;
        private InsertData insertData;
        public DataRowView SelectedRow
        {
            get { return selectedRow; }
            set { selectedRow = value; OnPropertyChanged("SelectedRow"); }
        }
        private DataRowView selectedEmployeeRow;
        public DataRowView SelectedEmployeeRow
        {
            get
            {
                return selectedEmployeeRow;
            }
            set
            {
                selectedEmployeeRow = value;
            }
        }
        private DataTable dataTable;
        public DataTable DataTable
        {
            get { return dataTable; }
            set { dataTable = value; OnPropertyChanged("dataTable"); }

        }

    
        private GetData getData;
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; OnPropertyChanged("Code"); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private DateTime? startingDate = new DateTime(1990, 01, 01);
        public DateTime? StartingDate
        {
            get { return startingDate; }
            set
            {

                startingDate = value; OnPropertyChanged("StartingDate");
            }
        }
        private DateTime? endingDate = DateTime.Now.Date;
        public DateTime? EndingDate
        {
            get { return endingDate; }
            set
            {
                if (value == null)
                {
                    endingDate = DateTime.Now;
                }

                endingDate = value; OnPropertyChanged("EndingDate");
            }
        }

        private List<string> employeeNames;
        public List<string> EmployeeNames
        {
            get
            {
                return employeeNames;
            }
            set
            {
                employeeNames = value;
                OnPropertyChanged("EmployeeNames");
            }
        }

        private string employeeName;
        public string EmployeeName
        {
            get { return employeeName; }
            set
            {
                employeeName = value;
                OnPropertyChanged("EmployeeName");
            }
        }

        private ICommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new RelayCommand(searchExecute, canSearchExecute, false);
                }
                return searchCommand;
            }
        }

        private void searchExecute(object parameter)
        {
            dataTable = getData.GetProjectSearchData(Code, Name, (DateTime)StartingDate, (DateTime)EndingDate);
            OnPropertyChanged("DataTable");
        }
        private bool canSearchExecute(object parameter)
        {

            return true;
        }

        private ICommand clearSearchFieldsCommand;
        public ICommand ClearSearhFieldsCommand
        {
            get
            {
                if (clearSearchFieldsCommand == null)
                {
                    clearSearchFieldsCommand = new RelayCommand(ClearFieldsExecute, CanClearFieldsExecute, false);

                }
                return clearSearchFieldsCommand;
            }
        }

        private bool CanClearFieldsExecute(object arg)
        {
            return true;
        }
        private void ClearFieldsExecute(object obj)
        {
            Code = String.Empty;
            Name = String.Empty;
            StartingDate = new DateTime(1990, 01, 01);
            EndingDate = DateTime.Now;
            dataTable = getData.GetProjectData();
            OnPropertyChanged("dataTable");
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(DeleteExecute, CanDeleteExecute, false);
                }
                return deleteCommand;
            }
        }
        private bool CanDeleteExecute(object arg)
        {
            if (selectedRow != null) return true;
            return false;
        }

        private void DeleteExecute(object obj)
        {
            deleteData.DeleteProject((string)(SelectedRow.Row.ItemArray[0]));
            ClearFieldsExecute(obj);
        }

        private ICommand editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (editCommand == null)
                {
                    editCommand = new RelayCommand(EditExecute, CanEditExecute, true);
                }
                return editCommand;
            }
        }

        private bool CanEditExecute(object arg)
        {
            return true;
        }

        private void EditExecute(object obj)
        {
            OnEditEvent(EventArgs.Empty);
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
            if (String.IsNullOrEmpty(employeeName)) return false;
            return true;
        }

        private void ExecuteAddEmployeeToProject(object obj)
        {
            string ProjectCode = (String)SelectedRow.Row.ItemArray[0];
            string EmployeeCode = employeeName.Split('-')[0];
            string EmployeeName = employeeName.Split('-')[1];
            insertData.InsertEmployeeToProject(ProjectCode, EmployeeCode,EmployeeName);
            OnAddEmployeeEvent(EventArgs.Empty);
           
        }

        private ICommand deleteEmployeeFromProject;
        public ICommand DeleteEmployeeFromProject
        {
            get
            {
                if(deleteEmployeeFromProject == null)
                {
                    deleteEmployeeFromProject = new RelayCommand(DeleteEmployeeFromProjectExecute, CanDeleteEmployeeFromProjectExecute, false);
                }
                return deleteEmployeeFromProject;
            }
        }

        private bool CanDeleteEmployeeFromProjectExecute(object arg)
        {
            if(selectedEmployeeRow==null)return false;
            return true;
            
        }

        private void DeleteEmployeeFromProjectExecute(object obj)
        {
          string projectcode = (String)SelectedRow.Row.ItemArray[0];
          string employeecode = (String)SelectedEmployeeRow.Row.ItemArray[1];
          string employeename = (String)SelectedEmployeeRow.Row.ItemArray[0];
          deleteData.RemoveEmployeeFromProject(employeecode,projectcode, employeename);
          OnAddEmployeeEvent(EventArgs.Empty);
        }

        public ProjectViewModel()
        {

            dataTable = new DataTable();
            getData = new GetData();
            dataTable = getData.GetProjectData();
            employeeNames = getData.AllEmployeeNames();
            deleteData = new DeleteData();
            insertData = new InsertData();
            OnPropertyChanged("dataTable");

        }

      




        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
