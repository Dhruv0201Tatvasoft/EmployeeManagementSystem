﻿using EmployeeManagementSystem.Commands;
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
        private DataTable? skillDataTable;
        public DataTable? SkillDataTable
        {
            get { return skillDataTable; }
            set { skillDataTable = value; }
        }

        private string? oldSkillName;

        public string? OldSKillName
        {
            get { return oldSkillName; }
            set { oldSkillName = value; OnPropertyChanged("OldSKillName"); }
        }

        private string? skillName;
        public string? SkillName
        {
            get { return skillName; }
            set
            {
                skillName = value;
                OnPropertyChanged("SkillName");
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
        /// To insert new skill in Database.
        /// </summary>
        private ICommand? saveSkill;
        public ICommand SaveSkill
        {
            get
            {
                if (saveSkill == null)
                {
                    saveSkill = new RelayCommand(ExecuteSaveSkill, CanSaveSkillExecute, false);
                }
                return saveSkill;
            }
        }

        /// <summary>
        /// Determines whether saving a skill can be executed.
        /// </summary
        /// <returns>
        /// True if the skill name is not null or empty; otherwise, false.
        /// </returns>
        private bool CanSaveSkillExecute(object arg)
        {
            if (String.IsNullOrEmpty(SkillName))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Executes the action to save a skill.
        /// </summary>
        private void ExecuteSaveSkill(object obj)
        {
            if (selectedRow != null && !String.IsNullOrEmpty(oldSkillName) && !String.IsNullOrEmpty(skillName))
            {
                updateData.UpdateSkillName(skillName, oldSkillName); ///  if oldSkill name is not null that means we are updating the already existing skill.
            }
            else
            {
                if (skillName != null)
                {
                    insertData.InsertSkill(skillName);
                }
            }
            selectedRow = null;
            SkillName = String.Empty;
            OldSKillName = null;
            skillDataTable = getData.GetSkillTable();
            OnPropertyChanged("SkillDataTable");
        }


        /// <summary>
        /// To remove skill from Database.
        /// </summary>
        private ICommand? deleteSkill;
        public ICommand DeleteSkill
        {
            get
            {
                if (deleteSkill == null)
                {
                    deleteSkill = new RelayCommand(ExecuteDeleteSkill, CanDeleteSkillExecute, false);
                }
                return deleteSkill;
            }
        }

        /// <summary>
        /// Executes the deletion of a skill.
        /// </summary>
        private void ExecuteDeleteSkill(object obj)
        {
            deleteData.DeleteSkill((string)selectedRow?.Row.ItemArray[0]!);///first row of selectedRow is skill name.
            SkillName = String.Empty; 
            skillDataTable = getData.GetSkillTable();
            OnPropertyChanged("SkillDataTable");

        }

        /// <summary>
        /// Determines whether the deletion of a skill can be executed.
        /// </summary>
        /// <returns>
        /// True if a row is selected; otherwise, false.
        /// </returns>
        private bool CanDeleteSkillExecute(object arg)
        {
            if (selectedRow == null) return false;
            return true;
        }

        /// <summary>
        /// To edit selected skill.
        /// </summary>
        private ICommand? editSkill;
        public ICommand EditSkill
        {
            get
            {
                if (editSkill == null)
                {
                    editSkill = new RelayCommand(ExecuteEditSkill, CanEditSkillExecute, false);
                }
                return editSkill;
            }
        }

        /// <summary>
        /// Determines whether editing a skill can be executed.
        /// </summary>
        /// <returns>
        /// True if a row is selected; otherwise, false.
        /// </returns>
        private bool CanEditSkillExecute(object arg)
        {
            if (selectedRow == null) return false;

            return true;
        }

        /// <summary>
        /// Executes the action to edit a skill.
        /// </summary>
        private void ExecuteEditSkill(object obj)
        {
            if (selectedRow != null)
            {
                oldSkillName = skillName = (string)selectedRow.Row[0]; ///first row of selectedRow contains skill name.
                OnPropertyChanged("SkillName");
            }
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
