using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModel
{
    class SkillViewModel : INotifyPropertyChanged
    {
        private GetData getData;
        private InsertData insertData;
        private UpdateData updateData;
        private DeleteData deleteData;
        private DataTable skillDataTable;
        public DataTable SkillDataTable
        {
            get { return skillDataTable; }
            set { skillDataTable = value; }
        }

        private string oldSkillName;

        public string OldSKillName
        {
            get { return oldSkillName; }
            set { oldSkillName = value; OnPropertyChanged("OldSKillName"); }
        }

        private string skillName;
        public string SkillName
        {
            get { return skillName; }
            set
            {
                skillName = value;
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
            if (String.IsNullOrEmpty(SkillName))
            {
                return false;
            }
            return true;
        }

        private void ExecuteSaveCommand(object obj)
        {
            if (selectedRow != null && !String.IsNullOrEmpty(oldSkillName))
            {
                updateData.UpdateSkillName(skillName, OldSKillName);
            }
            else
            {
                insertData.InsertSkill(skillName);
            }
            selectedRow = null;
            SkillName = String.Empty;
            skillDataTable = getData.GetSkillTable();
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
            deleteData.DeleteSkill((string)selectedRow.Row.ItemArray[0]);
            SkillName = String.Empty;
            skillDataTable = getData.GetSkillTable();
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
                    editCommand = new RelayCommand(EditExecute, CanEditExecute, false);
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
            oldSkillName = skillName = (string)selectedRow.Row[0];
            OnPropertyChanged("SkillName");
        }

        public SkillViewModel()
        {
            getData = new GetData();
            SkillDataTable = getData.GetSkillTable();
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
