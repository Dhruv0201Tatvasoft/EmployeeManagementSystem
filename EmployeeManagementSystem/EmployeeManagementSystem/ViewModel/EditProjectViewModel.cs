using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Model;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModel
{
    internal class EditProjectViewModel:IDataErrorInfo, INotifyPropertyChanged
    {

        private GetData getData;
        private UpdateData updateData;
        private DataTable dataTable;
        public event EventHandler? ChangeWindowEvent;
        protected virtual void OnChangeWindowEvent(EventArgs e)
        {
            ChangeWindowEvent?.Invoke(this, e);
        }
        public DataTable DataTable
        {
            get { return dataTable; }
            set { dataTable = value; OnPropertyChanged("dataTable"); }

        }

        private List<int> selectedTechnologyIds = new List<int>();
        public List<int> SelectedTechnologyIds
        {
            get { return selectedTechnologyIds; }
            set { selectedTechnologyIds = value; }
        }
        private DataRowView? selectedTechnologyRow;
        public DataRowView? SelectedTechnologyRow
        {
            get { return selectedTechnologyRow; }
            set
            {
                selectedTechnologyRow = value;
                if (selectedTechnologyRow != null)
                {
                    if (!selectedTechnologyIds.Contains((int)selectedTechnologyRow.Row.ItemArray[1]!))
                    {
                        selectedTechnologyIds.Add((int)selectedTechnologyRow.Row.ItemArray[1]!);
                    }
                    else
                    {
                        selectedTechnologyIds.Remove((int)selectedTechnologyRow.Row.ItemArray[1]!);
                    }
                }
            }
        }

        private string oldCode = string.Empty;
        public string OldCode
        {
            get { return oldCode; }
            set { oldCode = value;
            }
        }
        private string code = string.Empty;
        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }
        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private DateTime startingDate;
        public DateTime StartingDate
        {
            get { return startingDate; }
            set
            {
                startingDate = value;
                OnPropertyChanged("StartingDate");
                OnPropertyChanged("EndingDate");
            }
        }
        private DateTime? endingDate;
        public DateTime? EndingDate
        {
            get { return endingDate; }
            set
            {
                endingDate = value;
                OnPropertyChanged("EndingDate");
                OnPropertyChanged("StartingDate");

            }
        }
        public string Error => string.Empty;

        public string this[string PropertyName]
        {
            get
            {
                string errors = string.Empty;
                switch (PropertyName)
                {
                    case "Code":
                        if (string.IsNullOrEmpty(Code)) errors = "code can not be empty";
                        if (Code.Length > 10) errors = "code can not be more than 10 characters";
                        break;
                    case "Name":
                        if (string.IsNullOrEmpty(Name)) errors = "name can not be empty";
                        if (Name.Length > 40) errors = "name can not be more than 40 characters";
                        break;
                    case "StartingDate":
                        if (!string.IsNullOrEmpty(EndingDate.ToString()) && StartingDate > EndingDate) errors = "starting date can not be greater than ending date";
                        
                        break;
                    case "EndingDate":
                        if (!string.IsNullOrEmpty(StartingDate.ToString()) && StartingDate > EndingDate)
                        {
                            errors = "starting date can not be greater than ending date";
                        }
                        break;
                    default:
                        errors = string.Empty;
                        break;
                }

                return errors;
            }
        }
      


        /// <summary>
        /// To update the existing project.
        /// </summary>
        private ICommand? updateProject;
        public ICommand UpdateProject
        {
            get
            {
                if (updateProject == null)
                {
                    updateProject = new RelayCommand(ExecuteUpdateProject, CanUpdateProjectExecute, false);
                }
                return updateProject;
            }
        }
        private bool CanUpdateProjectExecute(object arg)
        {
            return true;
        }

        private void ExecuteUpdateProject(object obj)
        {
            bool didSave = false;
            ProjectModel project;
            if (EndingDate != null)
            {
                 project = new ProjectModel() {Code = Code, Name = Name, StartingDate = StartingDate, EndingDate = (DateTime)EndingDate,AssociatedTechnologies = SelectedTechnologyIds};
            }
            else
            {
                project = new ProjectModel() { Code = Code, Name = Name, StartingDate = StartingDate, AssociatedTechnologies = SelectedTechnologyIds };
            }
            didSave = updateData.UpdateProject(OldCode, project, EndingDate != null);
            if(didSave) OnChangeWindowEvent(EventArgs.Empty);

        }

        public EditProjectViewModel()
        {
            getData = new GetData();
            dataTable = new DataTable();
            dataTable = getData.GetTechnologyData();
            updateData = new UpdateData();
            OnPropertyChanged("dataTable");
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
