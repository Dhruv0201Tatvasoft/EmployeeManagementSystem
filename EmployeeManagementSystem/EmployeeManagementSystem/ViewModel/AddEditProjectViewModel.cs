using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Model;
using System;
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

namespace EmployeeManagementSystem.ViewModel
{
    internal class AddEditProjectViewModel:INotifyPropertyChanged
    {

        private DataTable dataTable;
        private GetData getData;
        public event EventHandler ChangeWindowEvent;
        protected virtual void OnChangeWindowEvent(EventArgs e)
        {
            ChangeWindowEvent?.Invoke(this, e);
        }
        private InsertData insertData;
        private List<int> selectedtechNologyIds = new List<int>();
        public List<int> SelectedTechnologyNames
        {
            get { return selectedtechNologyIds; }
            set { selectedtechNologyIds= value; }   
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
                    if (!selectedtechNologyIds.Contains((int)selectedTechnologyRow.Row.ItemArray[0]))
                    {
                        selectedtechNologyIds.Add((int)selectedTechnologyRow.Row.ItemArray[0]);
                    }
                }
            }
        }
        private TechnologyModel selectedTechnology;
        public TechnologyModel SelectedTechnology
        {
            get { return selectedTechnology; }
            set { selectedTechnology = value;
                OnPropertyChanged("selectedTechnology");
            }   
        }
        
        public DataTable DataTable
        {
            get { return dataTable; }
            set { dataTable = value; OnPropertyChanged("DataTable"); }

        }

        private string code;
        public string Code
        {get{return code;}  set{code = value;}
        }

        private string name;
        public string Name { get {  return name;} set { name = value;} }

        private DateTime startingDate = DateTime.Now;
        public DateTime StartingDate{ get { return startingDate; } set { startingDate = value; } }
        private DateTime endingDate=DateTime.Now;
        public DateTime EndingDate{ get { return endingDate; } set { endingDate= value; } }

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

        private bool CanSaveExecute(object arg)
        {
            return true;
        }

        private void SaveExecute(object obj)
        {
            //insertData.InsertNewProject(Code, Name, StartingDate, EndingDate,selectedtechNologyIds);
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
