using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Model;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;
namespace EmployeeManagementSystem.ViewModel
{
    internal class AddProjectViewModel : INotifyPropertyChanged, IDataErrorInfo
    {

        private GetData getData;
        private InsertData insertData;
        public event EventHandler? ChangeWindowEvent;
        protected virtual void OnChangeWindowEvent(EventArgs e)
        {
            ChangeWindowEvent?.Invoke(this, e);
        }
        private DataTable dataTable;
        public DataTable DataTable
        {
            get { return dataTable; }
            set { dataTable = value; OnPropertyChanged("DataTable"); }
        }
        private List<int> selectedTechnologyIds = new List<int>();
        public List<int> SelectedTechnologyIds
        {
            get { return selectedTechnologyIds; }
            set { selectedTechnologyIds = value; OnPropertyChanged("SelectedTechnologyIds"); }
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
                OnPropertyChanged("SelectedTechnologyRow");
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

        private DateTime startingDate = DateTime.Now;
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
                        if (!string.IsNullOrEmpty(EndingDate.ToString()) && StartingDate > EndingDate) errors = "starting date can not be greater than ending date ";
                        break;
                    case "EndingDate":
                        if (!string.IsNullOrEmpty(EndingDate.ToString()) && EndingDate < StartingDate) errors = "ending Date can not be less than ending date ";
                        break;
                    default:
                        errors = string.Empty;
                        break;
                }

                return errors;
            }
        }



        /// <summary>
        /// To add new project to database.
        /// </summary>
        private ICommand? saveProject;
        public ICommand SaveProject
        {
            get
            {
                if (saveProject == null)
                {
                    saveProject = new RelayCommand(ExecuteSaveProject, CanSaveProjectExecute, false);

                }
                return saveProject;
            }
        }



        /// <summary>
        /// Determines whether Save Project action can be executed.
        /// </summary>
        /// <returns>Always returns true, indicating that the Save Project action can always be executed.</returns>
        private bool CanSaveProjectExecute(object arg)
        {
            return true;
        }

        /// <summary>
        /// Executes the Save Project action .
        /// </summary>
        private void ExecuteSaveProject(object obj)
        {
            bool didSave = false;
            ProjectModel project;

            if (EndingDate != null)
            {
                project = new ProjectModel() { Code = Code, Name = Name, EndingDate = EndingDate, StartingDate = StartingDate, AssociatedTechnologies = SelectedTechnologyIds };
            }
            else
            {
                project = new ProjectModel() { Code = Code, Name = Name, StartingDate = StartingDate, AssociatedTechnologies = SelectedTechnologyIds };
            }
            didSave = insertData.InsertNewProject(project, EndingDate != null);
            if (didSave) /// if project is saved to database only after that we change the window.
            {
                OnChangeWindowEvent(EventArgs.Empty);
            }
        }


        public AddProjectViewModel()
        {
            getData = new GetData();
            dataTable = new DataTable();
            dataTable = getData.GetTechnologyData();
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
