using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModel
{
    class TechnologyViewModel : INotifyPropertyChanged
    {
        private GetData getData;
        private InsertData insertData;
        private UpdateData updateData;
        private DeleteData deleteData ;
        private DataTable technologyDataTable;
        public DataTable TechnologyDataTable
        {
            get { return technologyDataTable; }
            set { technologyDataTable = value; }
        }

        private string technologyName;
        public string TechnologyName
        {
            get { return technologyName; }
            set
            {
                technologyName = value;
                OnPropertyChanged("SkillName");
            }
        }

        private DataRowView selectedRow;
        public DataRowView SelectedRow
        {
            get
            {
                return selectedRow;
            }
            set
            {
                selectedRow = value;
                if(value != null)
                {
                    technologyName = (string)selectedRow.Row.ItemArray[0];
                    OnPropertyChanged("SkillName");
                }
                OnPropertyChanged("SelectedRow");
            }
        }




        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(ExecuteSaveCommand, CanSaveCommandExecute, false);
                }
                return saveCommand;
            }
        }
        private bool CanSaveCommandExecute(object arg)
        {
            if (String.IsNullOrEmpty(TechnologyName) || selectedRow != null)
            {
                return false;
            }
            return true;
        }

        private void ExecuteSaveCommand(object obj)
        {
            insertData.InsertTechnology(technologyName);
            TechnologyName = String.Empty;
            technologyDataTable = getData.GetTechnologyData();
            OnPropertyChanged("SkillDataTable");
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(DeleteCommandExecute, CanDeleteCommandExecute, false);
                }
                return deleteCommand;
            }
        }

        private void DeleteCommandExecute(object obj)
        {
            deleteData.DeleteTechnology((string)selectedRow.Row.ItemArray[0]);
            TechnologyName = String.Empty;
            technologyDataTable = getData.GetTechnologyData();
            OnPropertyChanged("SkillDataTable");

        }

        private bool CanDeleteCommandExecute(object arg)
        {
            if (selectedRow == null) return false;
            return true;
        }

        private ICommand editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (editCommand == null)
                {
                    editCommand = new RelayCommand(EditExecute,CanEditExecute, false);
                }
                return editCommand;
            }
        }

        private bool CanEditExecute(object arg)
        {
            if (selectedRow == null) return false;
       
            return true;
        }

        private void EditExecute(object obj)
        {
            string OldTechnologyName =  (string)selectedRow.Row.ItemArray[0];
            if(technologyName == String.Empty)
            {
                MessageBox.Show("Enter some value to update");
                return;
            }
            else
            {
                updateData.UpdateTechnologyName(TechnologyName, OldTechnologyName);
                TechnologyName = String.Empty;
                technologyDataTable = getData.GetTechnologyData();
                OnPropertyChanged("SkillDataTable");
            }
        }

        public TechnologyViewModel()
        {
            getData = new GetData();
            TechnologyDataTable = getData.GetTechnologyTable();
            insertData = new InsertData();
            updateData = new UpdateData();
            deleteData = new DeleteData();
            OnPropertyChanged("SkillDataTable");
        }


     

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
