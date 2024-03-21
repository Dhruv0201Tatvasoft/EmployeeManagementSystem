﻿using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Model;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModel
{
    internal class EditProjectViewModel:IDataErrorInfo, INotifyPropertyChanged
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
        private UpdateData updateData;

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

        private string oldCode;
        public string OldCode
        {
            get { return oldCode; }
            set { oldCode = value;
            }
        }
        private string code;
        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }
        private string name;
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
                        if (!string.IsNullOrEmpty(StartingDate.ToString()) && StartingDate > EndingDate)
                        {
                            errors = "Starting Date cant be greater than ending date ";
                        }
                        

                        break;
                }

                return errors;
            }
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

        private ICommand updateProject;
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
            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name) || Code.Length > 10 || Name.Length > 40 || (!string.IsNullOrEmpty(EndingDate.ToString()) && EndingDate < StartingDate)) return false;
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

    }
}
