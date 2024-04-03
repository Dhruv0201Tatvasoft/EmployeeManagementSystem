using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using System.ComponentModel;
using System.Data;
using System.IdentityModel.Tokens;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModel
{
    class TechnologyViewModel : INotifyPropertyChanged
    {
        private GetData getData;
        private InsertData insertData;
        private UpdateData updateData;
        private DeleteData deleteData;
        private DataTable? technologyDataTable;
        public DataTable? TechnologyDataTable
        {
            get { return technologyDataTable; }
            set { technologyDataTable = value; }
        }
        private string? oldTechnologyName;

        public string? OldTechnologyName
        {
            get { return oldTechnologyName; }
            set { oldTechnologyName = value; OnPropertyChanged("OldTechnologyName"); }
        }
        private string? technologyName;
        public string? TechnologyName
        {
            get { return technologyName; }
            set
            {
                technologyName = value;
                OnPropertyChanged("TechnologyName");
            }
        }

        private DataRowView? selectedRow;
        public DataRowView? SelectedRow
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



        /// <summary>
        /// To insert new technology to Database.
        /// </summary>
        private ICommand? saveTechnology;
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

        /// <summary>
        /// Determines whether saving a technology can be executed.
        /// </summary>
        /// <returns>
        /// True if the technology name is not null or empty; otherwise, false.
        /// </returns>
        private bool CanSaveTechnologyExecute(object arg)
        {
            if (String.IsNullOrEmpty(TechnologyName))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Executes the action to save a technology.
        /// </summary>
        private void ExecuteSaveTechnology(object obj)
        {
            if (selectedRow != null && !String.IsNullOrEmpty(oldTechnologyName) && !String.IsNullOrEmpty(technologyName))
            {
                updateData.UpdateTechnologyName(technologyName, oldTechnologyName); /// if selectedRow and  oldTechnologyName are not null means we are updating already existing technology.
            }
            else
            {
                if(technologyName != null) 
                insertData.InsertTechnology(technologyName);
            }
            selectedRow = null;
            TechnologyName = String.Empty;
            OldTechnologyName = null;
            technologyDataTable = getData.GetTechnologyData();
            OnPropertyChanged("TechnologyDataTable");
        }

        /// <summary>
        /// To delete selected Technology from Database.
        /// </summary>
        private ICommand? deleteTechnology;
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

        /// <summary>
        /// Executes the deletion of a technology.
        /// </summary>
        private void ExecuteDeleteTechnology(object obj)
        {
            deleteData.DeleteTechnology((string)selectedRow?.Row.ItemArray[0]!); /// first row of selectedRow contains technology name.
            TechnologyName = String.Empty;
            technologyDataTable = getData.GetTechnologyData();
            OnPropertyChanged("TechnologyDataTable");

        }

        /// <summary>
        /// Determines whether the deletion of a technology can be executed.
        /// </summary>
        /// <returns>
        /// True if a row is selected; otherwise, false.
        /// </returns
        private bool CanDeleteTechnologyExecute(object arg)
        {
            if (selectedRow == null) return false;
            return true;
        }

        /// <summary>
        /// To edit already existing technology in the Database.
        /// </summary>
        private ICommand? editTechnology;
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

        /// <summary>
        /// Determines whether editing a technology can be executed.
        /// </summary>
        /// <returns>
        /// True if a row is selected; otherwise, false.
        /// </returns>
        private bool CanEditTechnologyExecute(object arg)
        {
            if (selectedRow == null) return false;

            return true;
        }

        /// <summary>
        /// Executes the action to edit a technology.
        /// </summary>
        private void ExecuteEditTechnology(object obj)
        {
            if (selectedRow != null)
            {
                oldTechnologyName = technologyName = (string)selectedRow.Row[0];///first row of selectedRow is skill name.
                OnPropertyChanged("TechnologyName");
            }
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
