using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

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

        private DateTime? startingDate;
        public DateTime? StartingDate
        {
            get { return startingDate; }
            set
            {

                startingDate = value; OnPropertyChanged("StartingDate");
            }
        }
        private DateTime? endingDate ;
        public DateTime? EndingDate
        {
            get { return endingDate; }
            set
            {
                

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

        private ICommand searchProject;
        public ICommand SearchProject
        {
            get
            {
                if (searchProject == null)
                {
                    searchProject = new RelayCommand(ExecuteSearchProject, CanSearchProjectExecute, false);
                }
                return searchProject;
            }
        }

        private void ExecuteSearchProject(object parameter)
        {
            if(!StartingDate.HasValue) startingDate = DateTime.MinValue; if (!EndingDate.HasValue) endingDate = DateTime.MinValue;
            dataTable = getData.GetProjectSearchData(Code, Name, StartingDate.Value, EndingDate.Value);
            OnPropertyChanged("DataTable");
        }
        private bool CanSearchProjectExecute(object parameter)
        {

            return true;
        }

        private ICommand clearFields;
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
            Code = String.Empty;
            Name = String.Empty;
            StartingDate = null;
            EndingDate = null;
            dataTable = getData.GetProjectData();
            OnPropertyChanged("dataTable");
        }

        private ICommand deleteProject;
        public ICommand DeleteProject
        {
            get
            {
                if (deleteProject == null)
                {
                    deleteProject = new RelayCommand(ExecuteDeleteProject, CanDeleteProjectExecute, false);
                }
                return deleteProject;
            }
        }
        private bool CanDeleteProjectExecute(object arg)
        {
            if (selectedRow != null) return true;
            return false;
        }

        private void ExecuteDeleteProject(object obj)
        {
            deleteData.DeleteProject((string)(SelectedRow.Row.ItemArray[0]));
            ExecuteClearFields(obj);
        }

        private ICommand editProject;
        public ICommand EditProject
        {
            get
            {
                if (editProject == null)
                {
                    editProject = new RelayCommand(ExecuteEditProject, CanEditProjectExecute, true);
                }
                return editProject;
            }
        }

        private bool CanEditProjectExecute(object arg)
        {
            return true;
        }

        private void ExecuteEditProject(object obj)
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

        private ICommand removeEmployeeFromProject;
        public ICommand RemoveEmployeeFromProject
        {
            get
            {
                if(removeEmployeeFromProject == null)
                {
                    removeEmployeeFromProject = new RelayCommand(ExecuteRemoveEmployeeFromProject, CanRemoveEmployeeFromProjectExecute, false);
                }
                return removeEmployeeFromProject;
            }
        }

        private bool CanRemoveEmployeeFromProjectExecute(object arg)
        {
            if(selectedEmployeeRow==null)return false;
            return true;
            
        }

        private void ExecuteRemoveEmployeeFromProject(object obj)
        {
          string projectcode = (String)SelectedRow.Row.ItemArray[0];
          string employeecode = (String)SelectedEmployeeRow.Row.ItemArray[1];
          string employeename = (String)SelectedEmployeeRow.Row.ItemArray[0];
          deleteData.RemoveEmployeeFromProject(employeecode,projectcode);
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
