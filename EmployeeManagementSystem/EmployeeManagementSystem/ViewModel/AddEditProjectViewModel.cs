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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
namespace EmployeeManagementSystem.ViewModel
{
    internal class AddEditProjectViewModel:INotifyPropertyChanged,IDataErrorInfo
    {

        private DataTable dataTable;
        public DataTable DataTable
        {
            get { return dataTable; }
            set { dataTable = value; OnPropertyChanged("dataTable"); }

        }
        private GetData getData;
        public event EventHandler ChangeWindowEvent;
        protected virtual void OnChangeWindowEvent(EventArgs e)
        {
            ChangeWindowEvent?.Invoke(this, e);
        }
        private InsertData insertData;

        private bool canSave;
        public bool CanSave
        {
            get { return canSave; }
            set
            {
                canSave = value;
                OnPropertyChanged("CanSave");
            }
        }
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


        private string code = string.Empty;
        public string Code
        {get{return code;}  
            set{
                code = value;
                OnPropertyChanged("Code");
            }
        }

        private string name=string.Empty;
        public string Name { get {  return name;} 
            set {
                name = value;
                OnPropertyChanged("Name");
            } }

        private DateTime startingDate = DateTime.Now ;
        public DateTime StartingDate{ 
            get { return startingDate; } 
            set {
                startingDate = value;
                OnPropertyChanged("StartingDate");}
                }
        private DateTime? endingDate;
        public DateTime? EndingDate{ get { return endingDate; } 
            set {
                endingDate= value;
                OnPropertyChanged("EndingDate");
            } }
        

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

        public void method(String name)
        {
            MessageBox.Show("Hellp");
            this.code = name;
            OnPropertyChanged("Code");
        }

        public string Error => null;

        public string this[string PropertyName]
        {
            get { 
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

        private bool CanSaveExecute(object arg)
        {
             //if(string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name) || Code.Length>10 || Name.Length>40 || (!string.IsNullOrEmpty(EndingDate.ToString()) && EndingDate < StartingDate)) return false;
             return true;
        }

        private void SaveExecute(object obj)
        {
            if (EndingDate != null)
            {
                insertData.InsertNewProject(Code, Name, StartingDate, (DateTime)EndingDate, selectedtechnlogyIds);
            }
            else
            {
                insertData.InsertNewProject(Code, Name, StartingDate, selectedtechnlogyIds);
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
