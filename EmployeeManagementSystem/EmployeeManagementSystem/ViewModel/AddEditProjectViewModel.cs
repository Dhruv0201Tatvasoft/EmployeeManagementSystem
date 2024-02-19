using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace EmployeeManagementSystem.ViewModel
{
    internal class AddEditProjectViewModel:INotifyPropertyChanged,INotifyDataErrorInfo
    {

        private DataTable dataTable;
        private GetData getData;
        public event EventHandler ChangeWindowEvent;
        protected virtual void OnChangeWindowEvent(EventArgs e)
        {
            ChangeWindowEvent?.Invoke(this, e);
        }
        private InsertData insertData;
        private List<int> selectedtechnlogyIds = new List<int>();
        public List<int> SelectedTechnologyNames
        {
            get { return selectedtechnlogyIds; }
            set { selectedtechnlogyIds= value; }   
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
                    if (!selectedtechnlogyIds.Contains((int)selectedTechnologyRow.Row.ItemArray[0]))
                    {
                        selectedtechnlogyIds.Add((int)selectedTechnologyRow.Row.ItemArray[0]);
                    }
                    else
                    {
                        selectedtechnlogyIds.Remove((int)selectedTechnologyRow.Row.ItemArray[0]);
                    }
                }
            }
        }
       
        public DataTable DataTable
        {
            get { return dataTable; }
            set { dataTable = value; OnPropertyChanged("DataTable"); }

        }

        private string code;
        public string Code
        {get{return code;}  
            set{
                code = value;
                ClearErrors("Code");
                ValidateYourProperty("Code");
                OnPropertyChanged("Code");
            }
        }

        private string name;
        public string Name { get {  return name;} 
            set { name = value;
                ClearErrors("Name");
                ValidateYourProperty("Name");
                OnPropertyChanged("Name");
            } }

        private DateTime startingDate = DateTime.Now ;
        public DateTime StartingDate{ 
            get { return startingDate; } 
            set { startingDate = value;
                ClearErrors("StartingDate");
                OnPropertyChanged("StartingDate");}
                }
        private DateTime? endingDate;
        public DateTime? EndingDate{ get { return endingDate; } 
            set {
                endingDate= value;
                ClearErrors("EndingDate");
                OnPropertyChanged("EndingDate");
            } }

        private bool isValidationEnabled = true;
        public bool IsValidationEnabled
        {
            get { return isValidationEnabled; }
            set { isValidationEnabled = value; OnPropertyChanged("isValidationEnabled"); }
        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(SaveExecute, CanSaveExecute, false);
                }
                return saveCommand;
            }
        }
        private readonly Dictionary<string, List<string>> errorsList = new Dictionary<string, List<string>>();

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !errorsList.ContainsKey(propertyName))
                return null;

            return errorsList[propertyName];
        }

        public bool HasErrors => errorsList.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ValidateYourProperty(string propertyName)
        {
            List<string> errors = new List<string>();
            string error = null;

            switch (propertyName)
            {
                case "Code":
                    if (isValidationEnabled && string.IsNullOrEmpty(Code))
                        error = "Project Code is Required";
                    if (isValidationEnabled && Code.Length > 10)
                        error = "Code can't be more than 10 characters";
                    break;

                case "Name":
                    if (isValidationEnabled && string.IsNullOrEmpty(Name))
                        error = "Project Name is Required";
                    if (isValidationEnabled && Name.Length > 40)
                        error = "Project Name can't be more than 40 characters";
                    break;

              

                default:
                    break;
            }

            if (!string.IsNullOrEmpty(error))
            {
                errors.Add(error);
            }

            errorsList[propertyName] = errors;
            OnErrorsChanged(propertyName);

        }
        private void ClearErrors(string propertyName)
        {
            if (errorsList.ContainsKey(propertyName))
            {
                errorsList.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        public string Error => null;

        public string this[string PropertyName]
        {
            get
            {
                string error = null;
                    switch (PropertyName)
                    {
                        case "Code":
                            if (isValidationEnabled && String.IsNullOrEmpty(Code)) error = "Project Code is Required";
                            if (isValidationEnabled && Code.Length > 10) error = "Code cant be more than 10 characters";
                            break;
                        case "Name":
                            if (isValidationEnabled && String.IsNullOrEmpty(Name)) error = "Project Name is Required";
                            if (isValidationEnabled && Name.Length > 40) error = "Project Name cant be more than 40 characters";
                            break;
                        case "StartingDate":
                            if (isValidationEnabled && StartingDate < EndingDate) error = "Starting Date cant be less than Ending Date";
                            break;
                        default:
                            break;
                    }
                    return error;
            }
        }

        private bool CanSaveExecute(object arg)
        {
             if(HasErrors) return false;
            return true;
        }

        private void SaveExecute(object obj)
        {
            if (EndingDate != null)
            {
                //insertData.InsertNewProject(Code, Name, StartingDate, (DateTime)EndingDate, selectedtechnlogyIds);
            }
            else
            {
                //insertData.InsertNewProject(Code, Name, StartingDate, selectedtechnlogyIds);
            }
            OnChangeWindowEvent(EventArgs.Empty);   
        }

        public AddEditProjectViewModel()
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
