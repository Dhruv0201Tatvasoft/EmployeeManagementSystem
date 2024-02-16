using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModel
{
    internal class ProjectViewModel : INotifyPropertyChanged
    {
        private ProjectModel project;
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

        private DateTime startingDate = new DateTime(1990, 01, 01);
        public DateTime StartingDate
        {
            get { return startingDate; }
            set
            {

                startingDate = value; OnPropertyChanged("StartingDate");
            }
        }
        private DateTime endingDate = DateTime.Now.Date;
        public DateTime EndingDate
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
            dataTable = getData.GetProjectSearchData(Code, Name, StartingDate, EndingDate);
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

        public ProjectViewModel()
        {
            project = new ProjectModel();
            dataTable = new DataTable();
            getData = new GetData();
            dataTable = getData.GetProjectData();
            OnPropertyChanged("dataTable");

        }




























        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
