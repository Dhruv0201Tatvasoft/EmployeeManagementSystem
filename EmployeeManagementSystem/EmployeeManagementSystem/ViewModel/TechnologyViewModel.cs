using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModel
{
    class TechnologyViewModel : INotifyPropertyChanged
    {
        private GetData getData;
        private InsertData insertData;
        private UpdateData updateData;
        private DeleteData deleteData;
        private DataTable technologyDataTable;
        public DataTable TechnologyDataTable
        {
            get { return technologyDataTable; }
            set { technologyDataTable = value; }
        }
        private string oldTechnologyName;

        public string OldTecnologyName
        {
            get { return oldTechnologyName; }
            set { oldTechnologyName = value; OnPropertyChanged("OldTecnologyName"); }
        }
        private string technologyName;
        public string TechnologyName
        {
            get { return technologyName; }
            set
            {
                technologyName = value;
                OnPropertyChanged("TechnologyName");
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
                OnPropertyChanged("SelectedRow");
            }
        }




        private ICommand saveTechnology;
        public ICommand SaveTechnology
        {
            get
            {
                if (saveTechnology == null)
                {
                    saveTechnology = new RelayCommand(ExecuteSaveTechnology, CanSaveTechnologyExecute, false);
                }
                return saveTechnology;
            }
        }
        private bool CanSaveTechnologyExecute(object arg)
        {
            if (String.IsNullOrEmpty(TechnologyName))
            {
                return false;
            }
            return true;
        }

        private void ExecuteSaveTechnology(object obj)
        {
            if (selectedRow != null && !String.IsNullOrEmpty(OldTecnologyName))
            {
                updateData.UpdateTechnologyName(technologyName, oldTechnologyName);
            }
            else
            {
                insertData.InsertTechnology(technologyName);
            }
            selectedRow = null;
            TechnologyName = String.Empty;
            technologyDataTable = getData.GetTechnologyData();
            OnPropertyChanged("TechnologyDataTable");
        }

        private ICommand deleteTechnology;
        public ICommand DeleteTechnology
        {
            get
            {
                if (deleteTechnology == null)
                {
                    deleteTechnology = new RelayCommand(ExecuteDeleteTechnology, CanDeleteTechnologyExecute, false);
                }
                return deleteTechnology;
            }
        }

        private void ExecuteDeleteTechnology(object obj)
        {
            deleteData.DeleteTechnology((string)selectedRow.Row.ItemArray[0]);
            TechnologyName = String.Empty;
            technologyDataTable = getData.GetTechnologyData();
            OnPropertyChanged("TechnologyDataTable");

        }

        private bool CanDeleteTechnologyExecute(object arg)
        {
            if (selectedRow == null) return false;
            return true;
        }

        private ICommand editTechnology;
        public ICommand EditTechnology
        {
            get
            {
                if (editTechnology == null)
                {
                    editTechnology = new RelayCommand(ExecuteEditTechnology, CanEditTechnologyExecute, false);
                }
                return editTechnology;
            }
        }

        private bool CanEditTechnologyExecute(object arg)
        {
            if (selectedRow == null) return false;

            return true;
        }

        private void ExecuteEditTechnology(object obj)
        {
            oldTechnologyName = technologyName = (string)selectedRow.Row[0];
            OnPropertyChanged("TechnologyName");
        }

        public TechnologyViewModel()
        {
            getData = new GetData();
            TechnologyDataTable = getData.GetTechnologyTable();
            insertData = new InsertData();
            updateData = new UpdateData();
            deleteData = new DeleteData();
            OnPropertyChanged("TechnologyDataTable");
        }




        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
