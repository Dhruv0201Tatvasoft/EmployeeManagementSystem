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

        private DataTable dataTable;
        public DataTable DataTable
        {
            get { return dataTable; }
            set { dataTable = value; OnPropertyChanged("dataTable"); }

        }
        private List<DataRowView> list;
        public List<DataRowView> List { get { return list; } set { list = value; } }
        private GetData getData;
        public event EventHandler ChangeWindowEvent;
        protected virtual void OnChangeWindowEvent(EventArgs e)
        {
            ChangeWindowEvent?.Invoke(this, e);
        }
        private InsertData insertData;

        private List<int> selectedtechnlogyIds = new List<int>();
        public List<int> SelectedTechnologyIds
        {
            get { return selectedtechnlogyIds; }
            set { selectedtechnlogyIds = value; }
        }
        private DataRowView selectedTechnologyRow;
        public DataRowView SelectedTechnologyRow
        {
            get { return selectedTechnologyRow; }
            set
            {
                selectedTechnologyRow = value;
                if (selectedTechnologyRow != null)
                {
                    if (!selectedtechnlogyIds.Contains((int)selectedTechnologyRow.Row.ItemArray[1]))
                    {
                        selectedtechnlogyIds.Add((int)selectedTechnologyRow.Row.ItemArray[1]);
                    }
                    else
                    {
                        selectedtechnlogyIds.Remove((int)selectedTechnologyRow.Row.ItemArray[1]);
                    }
                }
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

        public string Error => null;

        public string this[string PropertyName]
        {
            get
            {
                string errors = string.Empty;
                switch (PropertyName)
                {
                    case "Code":
                        if (string.IsNullOrEmpty(Code)) errors = "Code cant be empty";
                        if (Code.Length > 10) errors = "Code cant be more than 10 characters";
                        break;
                    case "Name":
                        if (string.IsNullOrEmpty(Name)) errors = "Name cant be empty";
                        if (Name.Length > 40) errors = "Name cant be more than 40 characters";
                        break;
                    case "StartingDate":
                        if (!string.IsNullOrEmpty(EndingDate.ToString()) && StartingDate > EndingDate) errors = "Starting Date cant be greater than ending date ";
                        break;
                    case "EndingDate":
                        if (!string.IsNullOrEmpty(EndingDate.ToString()) && EndingDate < StartingDate) errors = "Ending Date cant be less than ending date ";
                        break;
                }

                return errors;
            }
        }




        private ICommand saveProject;
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




        private bool CanSaveProjectExecute(object arg)
        {
            return true;
        }

        private void ExecuteSaveProject(object obj)
        {
            bool didSaved = false;
            if (EndingDate != null)
            {
                ProjectModel project = new ProjectModel() { Code = Code, Name = Name, EndingDate = (DateTime)EndingDate,StartingDate=StartingDate,AssociatedTechnologies = SelectedTechnologyIds};
                didSaved = insertData.InsertNewProject(project);
            }
            else
            {
                ProjectModel project = new ProjectModel() { Code = Code, Name = Name, StartingDate = StartingDate, AssociatedTechnologies = SelectedTechnologyIds };

                didSaved = insertData.InsertNewProjectWithOutEndingDate(project);
            }
            if (didSaved)
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
