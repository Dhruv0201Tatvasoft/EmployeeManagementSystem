using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModel
{
    internal class EditEmployeeViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private InsertData insertData;
        private DeleteData deleteData;
        private UpdateData updateData;
        public event EventHandler? AddEducationButtonClickedEvent;
        public event EventHandler? AddExperienceButtonClickedEvent;
        public event EventHandler? EmployeeUpdatedEvent;
        public event EventHandler? AddEducationRowEvent;
        public event EventHandler? AddExperienceRowEvent;
        public event EventHandler? EditEducationRowEvent;
        public event EventHandler? EditExperienceRowEvent;

        public void OnAddEducationButtonClicked(EventArgs e)
        {
            AddEducationButtonClickedEvent?.Invoke(this, e);
        }
        public void OnAddExperienceButtonClicked(EventArgs e)
        {
            AddExperienceButtonClickedEvent?.Invoke(this, e);
        }
        public void OnEmployeeAddedEvent(EventArgs e)
        {
            EmployeeUpdatedEvent?.Invoke(this, e);
        }
        public void OnAddEducationRowEvent(EventArgs e)
        {
            AddEducationRowEvent?.Invoke(this, e);
        }
        public void OnEditEducationRowEvent(EventArgs e)
        {
            EditEducationRowEvent?.Invoke(this, e);
        }
        public void OnAddExperienceRowEvent(EventArgs e)
        {
            AddExperienceRowEvent?.Invoke(this, e);
        }
        public void OnEditExperienceRowEvent(EventArgs e)
        {
            EditExperienceRowEvent?.Invoke(this, e);
        }

        private string oldCode = string.Empty;

        public string OldCode
        {
            get { return oldCode; }
            set { oldCode = value; OnPropertyChanged("OldCode"); }
        }

        private string tempCode = string.Empty;
        public string TempCode
        {
            get { return tempCode; }
            set
            {
                tempCode = value;
                OnPropertyChanged("tempCode");
            }
        }
        
        
        private string code = string.Empty;

        public string Code
        {
            get { return code; }
            set { code = value; OnPropertyChanged("Code"); }
        }

        private string firstName = string.Empty;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }

        private string lastName = string.Empty;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }

        private string email = string.Empty;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        private string password = string.Empty;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); OnPropertyChanged("ConfirmPassword"); }
        }

        private string confirmPassword = string.Empty;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; OnPropertyChanged("Password"); OnPropertyChanged("ConfirmPassword"); }
        }

        private string? selectedDepartment = string.Empty;

        public string? SelectedDepartment
        {
            get { return selectedDepartment; }
            set { selectedDepartment = value; OnPropertyChanged("SelectedDepartment"); }
        }

        private string? selectedDesignation = string.Empty;

        public string? SelectedDesignation
        {
            get { return selectedDesignation; }
            set { selectedDesignation = value; OnPropertyChanged("SelectedDesignation"); }
        }

        private DateTime joiningDate = DateTime.Now;

        public DateTime JoiningDate
        {
            get { return joiningDate; }
            set { joiningDate = value; OnPropertyChanged("JoiningDate"); OnPropertyChanged("ReleaseDate"); }
        }

        private DateTime? releaseDate;

        public DateTime? ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; OnPropertyChanged("ReleaseDate"); OnPropertyChanged("JoiningDate"); }
        }

        private DateTime dob = DateTime.Now;

        public DateTime DOB
        {
            get { return dob; }
            set { dob = value; OnPropertyChanged("DOB"); }
        }
        private string contactNumber = string.Empty;

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; OnPropertyChanged("ContactNumber"); }
        }

        private string gender = "Male"; /// by default Male's radio button will be checked.

        public string Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged("Gender"); }
        }



        private string presentAddress = string.Empty;

        public string PresentAddress
        {
            get { return presentAddress; }
            set
            {
                presentAddress = value;
                if (IsCheckBoxChecked)
                {
                    permanentAddress = presentAddress;

                }
                OnPropertyChanged("PresentAddress");
                OnPropertyChanged("PermanentAddress");
            }
        }

        private string permanentAddress = string.Empty;

        public string PermanentAddress
        {
            get { return permanentAddress; }
            set
            {
                permanentAddress = value;

                if (IsCheckBoxChecked)
                {
                    presentAddress = permanentAddress;

                }
                OnPropertyChanged("PresentAddress");
                OnPropertyChanged("PermanentAddress");
            }


        }
        private string? selectedMaritalStatus = string.Empty;

        public string? SelectedMaritalStatus
        {
            get { return selectedMaritalStatus; }
            set { selectedMaritalStatus = value; OnPropertyChanged("SelectedMaritalStatus"); }
        }

       
        private bool isCheckBoxChecked = false;

        public bool IsCheckBoxChecked
        {
            get { return isCheckBoxChecked; }
            set
            {
                isCheckBoxChecked = value;
                if (value)
                {
                    permanentAddress = presentAddress;
                    OnPropertyChanged("PermanentAddress");

                }
                OnPropertyChanged("IsCheckBoxChecked");
            }
        }

        private ObservableCollection<string> designation;

        public ObservableCollection<string> Designation
        {
            get { return designation; }
            set
            {
                designation = value;
                OnPropertyChanged("Designation");
            }
        }

        private string combBoxText = "Select";

        public string CombBoxText
        {
            get { return combBoxText; }
            set { combBoxText = value; OnPropertyChanged("comBoxText"); }
        }

        private ObservableCollection<string> department;

        public ObservableCollection<string> Department
        {
            get { return department; }
            set
            {

                department = value;
                OnPropertyChanged("Department");
            }
        }
        private ObservableCollection<string> maritalStatus;
        public ObservableCollection<string> MaritalStatus
        {
            get { return maritalStatus; }
            set { maritalStatus = value; OnPropertyChanged("MaritalStatus"); }

        }
        private string? maritalStatusCombBoxText = "Select";

        public string MaritalStatusCombBoxText
        {
            get { return combBoxText; }
            set { combBoxText = value; OnPropertyChanged("comBoxText"); }
        }
        private EmployeeEducationModel? selectedEmployeeEducationModel;

        public EmployeeEducationModel? SelectedEmployeeEducationModel
        {
            get { return selectedEmployeeEducationModel; }
            set { selectedEmployeeEducationModel = value; }
        }
        private EmployeeEducationModel? selectedOldEmployeeEducationModel;

        public EmployeeEducationModel? SelectedOldEmployeeEducationModel
        {
            get { return selectedOldEmployeeEducationModel; }
            set { selectedOldEmployeeEducationModel = value; }
        }

        private EmployeeExperienceModel? selectedEmployeeExperienceModel;

        public EmployeeExperienceModel? SelectedEmployeeExperienceModel
        {
            get { return selectedEmployeeExperienceModel; }
            set { selectedEmployeeExperienceModel = value; }
        }

        private EmployeeExperienceModel? selectedOldEmployeeExperienceModel;

        public EmployeeExperienceModel? SelectedOldEmployeeExperienceModel
        {
            get { return selectedOldEmployeeExperienceModel; }
            set { selectedOldEmployeeExperienceModel = value; }
        }


        ObservableCollection<EmployeeEducationModel> employeeEducationList = new ObservableCollection<EmployeeEducationModel>();
        public ObservableCollection<EmployeeEducationModel> EmployeeEducationList
        { get { return employeeEducationList; } set { employeeEducationList = value; } }

        ObservableCollection<EmployeeExperienceModel> employeeExperienceList = new ObservableCollection<EmployeeExperienceModel>();
        public ObservableCollection<EmployeeExperienceModel> EmployeeExperienceList
        { get { return employeeExperienceList; } set { employeeExperienceList = value; } }

        public string Error => string.Empty;

        public string this[string PropertyName]
        {
            get
            {
                string errors = string.Empty;
                switch (PropertyName)
                {
                    case "TempCode":
                        if (string.IsNullOrEmpty(TempCode)) errors = "code can not be empty";
                        if (TempCode.Length > 10) errors = "code cant be more than 10 characters";
                        break;
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName)) errors = "firstname can not be empty";
                        if (FirstName.Length > 20) errors = "firstname can not be more than 20 characters";
                        break;
                    case "LastName":
                        if (String.IsNullOrEmpty(LastName)) errors = "lastname can not be empty";
                        if (LastName.Length > 20) errors = "lastname can not be more than 20 characters";
                        break;
                    case "Email":
                        if (string.IsNullOrEmpty(Email)) errors = "email can not be empty";
                        if (!IsValidEmailAddress(Email)) errors = "not a valid email address";
                        break;
                    case "Password":
                        if (String.IsNullOrEmpty(Password)) errors = "password cant be empty";
                        if (Password.Length < 8) errors = "password must be longer than 8 characters";
                        if (password.Length > 20) errors = "password maximum limit reached";
                        break;
                    case "ConfirmPassword":
                        if (!ConfirmPassword.Equals(Password)) errors = "does not match with your password";
                        break;
                    case "SelectedDesignation":
                        if (String.IsNullOrEmpty(SelectedDesignation) || !Designation.Contains(SelectedDesignation)) errors = "please select a valid designation";
                        break;
                    case "SelectedDepartment":
                        if (String.IsNullOrEmpty(SelectedDepartment) || !Department.Contains(SelectedDepartment)) errors = "plaease select a valid department";
                        break;
                    case "SelectedMaritalStatus":
                        if (String.IsNullOrEmpty(SelectedMaritalStatus) || !MaritalStatus.Contains(SelectedMaritalStatus)) errors = "please a select valid marital status";
                        break;
                    case "PresentAddress":
                        if (String.IsNullOrEmpty(PresentAddress)) errors = "present address can not be empty";
                        break;
                    case "ContactNumber":
                        if (String.IsNullOrEmpty(ContactNumber)) errors = "contact number can not be empty";
                        if (!IsValidContactNumber(ContactNumber)) errors = "provide a valid contact number";
                        break;
                    case "JoiningDate":
                        if (!string.IsNullOrEmpty(ReleaseDate.ToString()) && JoiningDate > ReleaseDate) errors = "joining date can not be greater than release date";
                        break;
                    case "ReleaseDate":
                        if (!string.IsNullOrEmpty(ReleaseDate.ToString()) && JoiningDate > ReleaseDate) errors = "release date can not be less than joining date";
                        break;
                }

                return errors;
            }
        }

        /// <summary>
        /// To update employee to database.
        /// </summary>
        private ICommand? updateEmployee;
        public ICommand UpdateEmployee
        {
            get
            {
                if (updateEmployee == null)
                {
                    updateEmployee = new RelayCommand(ExecuteUpdateEmployee, CanUpdateEmployeeExecute, false);
                }
                return updateEmployee;
            }
        }
        private bool CanUpdateEmployeeExecute(object arg)
        {
            return true;
        }

        private void ExecuteUpdateEmployee(object obj)
        {
            bool didSave = false;
            EmployeeModel employee;
            if (ReleaseDate != null)
            {
                employee = new EmployeeModel
                {
                    Code = TempCode,
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Password = Password,
                    Designation = SelectedDesignation,
                    Department = SelectedDepartment,
                    JoiningDate = JoiningDate,
                    ReleaseDate = ReleaseDate,
                    DOB = DOB,
                    ContactNumber = ContactNumber,
                    Gender = Gender,
                    MaritalStauts = SelectedMaritalStatus,
                    PresentAddress = PresentAddress,
                    PermanentAddress = PermanentAddress
                };

            }
            else
            {
                employee = new EmployeeModel
                {
                    Code = TempCode,
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Password = Password,
                    Designation = SelectedDesignation,
                    Department = SelectedDepartment,
                    JoiningDate = JoiningDate,
                    DOB = DOB,
                    ContactNumber = ContactNumber,
                    Gender = Gender,
                    MaritalStauts = SelectedMaritalStatus,
                    PresentAddress = PresentAddress,
                    PermanentAddress = PermanentAddress
                };
            }
            didSave = updateData.UpdateEmployee(oldCode, employee, ReleaseDate != null);
            if (didSave)
            {
                OnEmployeeAddedEvent(EventArgs.Empty);
                code = tempCode;
            }
        }

        /// <summary>
        /// To add blank row to education list.
        /// </summary>
        private ICommand? addBlankRowEducation;
        public ICommand AddBlankRowEducation
        {
            get
            {
                if (addBlankRowEducation == null)
                {
                    addBlankRowEducation = new RelayCommand(ExecuteAddRowEducation, CanAddRowEducationExecute, false);
                }
                return addBlankRowEducation;
            }
        }
        private void ExecuteAddRowEducation(object obj)
        {
            EmployeeEducationList.Add(new EmployeeEducationModel());///adding new blank model will add blank row.
            OnAddEducationButtonClicked(EventArgs.Empty);
            OnPropertyChanged("EmployeeEducationList");
        }

        private bool CanAddRowEducationExecute(object arg)
        {
            return true;
        }

        /// <summary>
        /// To add blank row to experience list
        /// </summary>
        private ICommand? addBlankRowExperience;
        public ICommand AddBlankRowExperience
        {
            get
            {
                if (addBlankRowExperience == null)
                {
                    addBlankRowExperience = new RelayCommand(ExecuteAddRowExperience, CanAddRowExperienceExecute, false);
                }
                return addBlankRowExperience;
            }
        }

        private void ExecuteAddRowExperience(object obj)
        {
            EmployeeExperienceList.Add(new EmployeeExperienceModel());///adding new blank model will add blank row.
            OnAddExperienceButtonClicked(EventArgs.Empty);
            OnPropertyChanged("EmployeeExperienceList");
        }

        private bool CanAddRowExperienceExecute(object arg)
        {
            return true;
        }

        /// <summary>
        /// To save education field to database.
        /// </summary>
        private ICommand? saveEducationRow;
        public ICommand SaveEducationRow
        {
            get
            {
                if (saveEducationRow == null)
                {
                    saveEducationRow = new RelayCommand(ExecuteSaveEducationRow, CanSaveEducationRowExecute, false);
                }
                return saveEducationRow;
            }
        }

        private bool CanSaveEducationRowExecute(object arg)
        {
            return true;
        }

        private void ExecuteSaveEducationRow(object obj)
        {

            if (selectedEmployeeEducationModel != null && (string.IsNullOrEmpty(selectedEmployeeEducationModel.BoardUniversity) ||
           string.IsNullOrEmpty(selectedEmployeeEducationModel.Percentage) ||
           string.IsNullOrEmpty(selectedEmployeeEducationModel.State) ||
           string.IsNullOrEmpty(selectedEmployeeEducationModel.Qualification) ||
           string.IsNullOrEmpty(selectedEmployeeEducationModel.InstituteName)))  ///to validate field before inserting
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeEducationModel != null && (!string.IsNullOrEmpty(selectedEmployeeEducationModel.Percentage) && !IsValidPercentage(selectedEmployeeEducationModel.Percentage)))/// to validate percentage field.
            {
                MessageBox.Show("Please provide valid value for percentage", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeEducationModel != null && (!string.IsNullOrEmpty(selectedEmployeeEducationModel.PassingYear) && !IsValidYear(selectedEmployeeEducationModel.PassingYear)))/// to validate passing year field.
            {
                MessageBox.Show("Please provide valid value for Passing Year", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeEducationModel != null && (!string.IsNullOrEmpty(selectedEmployeeEducationModel.InstituteName) && (selectedEmployeeEducationModel.InstituteName.Length > 35))) /// to validate institute name field.
            {
                MessageBox.Show("Maximum character limit reached for Institute Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeEducationModel != null && (!string.IsNullOrEmpty(selectedEmployeeEducationModel.Qualification) && (selectedEmployeeEducationModel.Qualification.Length > 10))) /// to validate qualification field.
            {
                MessageBox.Show("Maximum character limit reached for Qualification Field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeEducationModel != null && (!string.IsNullOrEmpty(selectedEmployeeEducationModel.BoardUniversity) && (selectedEmployeeEducationModel.BoardUniversity.Length > 30))) /// to validate Board/University field.
            {
                MessageBox.Show("Maximum character limit reached for Board/University Field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeEducationModel != null && (!string.IsNullOrEmpty(selectedEmployeeEducationModel.State) && (selectedEmployeeEducationModel.State.Length > 15))) /// to validate state field.
            {
                MessageBox.Show("Maximum character limit reached from State Field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                bool didSave = false;
                if (selectedOldEmployeeEducationModel == null && selectedEmployeeEducationModel != null) /// if selectedOldEmployeeEducationModel == null that means we are adding new record. other wise we are updating old record.
                {
                    didSave = insertData.InsertEducationDetails(selectedEmployeeEducationModel, Code);
                }
                else
                {
                    if (selectedEmployeeEducationModel != null && selectedOldEmployeeEducationModel != null)
                        didSave = updateData.UpdateEmployeeEducation(selectedEmployeeEducationModel, selectedOldEmployeeEducationModel, code);
                }
                if (didSave)
                {
                    selectedOldEmployeeEducationModel = null;
                    OnAddEducationRowEvent(EventArgs.Empty);
                }
            }
            OnPropertyChanged("SelectedEmployeeEducationField");
        }


        /// <summary>
        ///  to save experience field to database.
        /// </summary>
        private ICommand? saveExperienceRow;
        public ICommand SaveExperienceRow
        {
            get
            {
                if (saveExperienceRow == null)
                {
                    saveExperienceRow = new RelayCommand(ExecuteSaveExperienceRow, CanSaveExperienceExecute, false);
                }
                return saveExperienceRow;
            }
        }

        private bool CanSaveExperienceExecute(object arg)
        {
            return true;
        }


        private void ExecuteSaveExperienceRow(object obj)
        {

            if (selectedEmployeeExperienceModel != null && (string.IsNullOrEmpty(selectedEmployeeExperienceModel.Organization) ||
                string.IsNullOrEmpty(selectedEmployeeExperienceModel.Designation) ||
                selectedEmployeeExperienceModel.FromDate == null ||
                selectedEmployeeExperienceModel.ToDate == null)) /// to validate all the fields.
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeExperienceModel != null && selectedEmployeeExperienceModel.Duration < 0) /// to validate duration field.
            {
                MessageBox.Show("Please provide valid value for from and to date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                bool didSave = false;
                if (selectedOldEmployeeExperienceModel == null && selectedEmployeeExperienceModel != null) /// if selectedOldEmployeeExperienceModel == null that means we are adding new record otherwise we are updating the old record.
                {
                    didSave = insertData.InsertExperienceDetails(selectedEmployeeExperienceModel, Code);
                }
                else
                {
                    if (selectedEmployeeExperienceModel != null && selectedOldEmployeeExperienceModel != null)
                    {
                        didSave = updateData.UpdateEmployeeExperience(selectedEmployeeExperienceModel, selectedOldEmployeeExperienceModel, code);
                        if(didSave) { selectedOldEmployeeExperienceModel = null; }
                    }
                }
                if (didSave)
                {
                    OnAddExperienceRowEvent(EventArgs.Empty);
                }
            }
            OnPropertyChanged("SelectedEmployeeEducationField");
        }



        /// <summary>
        /// Command triggers on click of edit education row button and sets selectedOldEmployeeEducationModel using selectedEmployeeEducationModel.
        /// </summary>
        private ICommand? editEducationRow;
        public ICommand EditEducationRow
        {
            get
            {
                if (editEducationRow == null)
                {
                    editEducationRow = new RelayCommand(ExecuteEditEducationRow, CanEditEducationRowExecute, false);
                }
                return editEducationRow;
            }


        }

        private bool CanEditEducationRowExecute(object arg)
        {
            return true;

        }

        private void ExecuteEditEducationRow(object obj)
        {
            if (SelectedEmployeeEducationModel != null)
                selectedOldEmployeeEducationModel = new EmployeeEducationModel
                {
                    State = SelectedEmployeeEducationModel.State,
                    Percentage = SelectedEmployeeEducationModel.Percentage,
                    BoardUniversity = SelectedEmployeeEducationModel.BoardUniversity,
                    InstituteName = SelectedEmployeeEducationModel.InstituteName,
                    PassingYear = SelectedEmployeeEducationModel.PassingYear,
                    Qualification = SelectedEmployeeEducationModel.Qualification
                };
            OnEditEducationRowEvent(EventArgs.Empty);
        }

        /// <summary>
        /// Command triggers on click of edit experience row button and sets selectedOldEmployeeExperienceModel using selectedEmployeeExperienceModel.
        /// </summary>
        private ICommand? editExperience;
        public ICommand EditExperience
        {
            get
            {
                if (editExperience == null)
                {
                    editExperience = new RelayCommand(ExecuteEditExperience, CanEditExperienceExecute, false);
                }
                return editExperience;
            }
        }

        private void ExecuteEditExperience(object obj)
        {
            if (selectedEmployeeExperienceModel != null)
                selectedOldEmployeeExperienceModel = new EmployeeExperienceModel
                {
                    Organization = selectedEmployeeExperienceModel.Organization,
                    Duration = selectedEmployeeExperienceModel.Duration,
                    Designation = selectedEmployeeExperienceModel.Designation,
                    ToDate = selectedEmployeeExperienceModel.ToDate,
                    FromDate = selectedEmployeeExperienceModel.FromDate
                };
            OnEditExperienceRowEvent(EventArgs.Empty);
        }

        private bool CanEditExperienceExecute(object arg)
        {
            return true;
        }

        /// <summary>
        /// To remove a row from education List. this does not delete the education field from database.
        /// </summary>
        private ICommand? removeEducationFromList;
        public ICommand RemoveEducationFromList
        {
            get
            {
                if (removeEducationFromList == null)
                {
                    removeEducationFromList = new RelayCommand(ExecuteRemoveEducationFromList, CanRemoveEducationFromListExecute, false);
                }
                return removeEducationFromList;
            }
        }



        private bool CanRemoveEducationFromListExecute(object arg)
        {
            return true;
        }

        private void ExecuteRemoveEducationFromList(object obj)
        {
            if (SelectedEmployeeEducationModel != null)
                EmployeeEducationList.Remove(SelectedEmployeeEducationModel);///this will only remove model from EmployeeEducationList and not from the database.
            OnPropertyChanged("EmployeeEducationList");
        }

        /// <summary>
        /// To remove a row from experience List. this does not delete the experience field from database.
        /// </summary>
        private ICommand? removeExperienceFromList;
        public ICommand RemoveExperienceFromList
        {
            get
            {
                if (removeExperienceFromList == null)
                {
                    removeExperienceFromList = new RelayCommand(ExecuteRemoveExperienceFromList, CanRemoveExperienceFromListExecute, false);
                }
                return removeExperienceFromList;
            }
        }

        private bool CanRemoveExperienceFromListExecute(object arg)
        {
            return true;
        }

        private void ExecuteRemoveExperienceFromList(object obj)
        {
            if (selectedEmployeeExperienceModel != null)
                EmployeeExperienceList.Remove(selectedEmployeeExperienceModel);///this will only remove model from EmployeeEducationList and not from the database.
            OnPropertyChanged("EmployeeExperienceList");
        }

        /// <summary>
        /// To remove education field of an employee from database. 
        /// </summary>
        private ICommand? removeEducationFromDataBase;
        public ICommand RemoveEducationFromDataBase
        {
            get
            {
                if (removeEducationFromDataBase == null)
                {
                    removeEducationFromDataBase = new RelayCommand(ExecuteRemoveEducationFromDataBase, CanRemoveEducationFromDataBaseExecute, false);
                }
                return removeEducationFromDataBase;
            }
        }

        private bool CanRemoveEducationFromDataBaseExecute(object arg)
        {
            return true;

        }

        private void ExecuteRemoveEducationFromDataBase(object obj)
        {
            if (selectedEmployeeEducationModel != null)
            {
                bool didDelete = false;
                didDelete = deleteData.DeleteEducationRow(selectedEmployeeEducationModel, Code);
                if (didDelete)
                {
                    employeeEducationList.Remove(selectedEmployeeEducationModel); /// if didDelete = true means the education field is deleted from database so we also have to delete it from the education list to show changes to UI

                }
                OnPropertyChanged("employeeEducationList");
            }
        }

        /// <summary>
        /// To remove experience field of an employee from database. 
        /// </summary
        private ICommand? removeExperienceFromDataBase;
        public ICommand RemoveExperienceFromDataBase
        {
            get
            {
                if (removeExperienceFromDataBase == null)
                {
                    removeExperienceFromDataBase = new RelayCommand(ExecuteRemoveExperienceFromDataBase, CanRemoveExperienceFromDataBaseExecute, false);
                }
                return removeExperienceFromDataBase;
            }
        }

        private void ExecuteRemoveExperienceFromDataBase(object obj)
        {
            if (selectedEmployeeExperienceModel != null)
            {
                bool didDelete = false;
                didDelete = deleteData.DeleteExperienceRow(selectedEmployeeExperienceModel, Code);
                if (didDelete)
                {
                    EmployeeExperienceList.Remove(selectedEmployeeExperienceModel);///if didDelete = true means the experience field is deleted from database so we also have to delete it from the experience list to show changes to UI
                }
                OnPropertyChanged("EmployeeExperienceList");
            }
        }

        private bool CanRemoveExperienceFromDataBaseExecute(object arg)
        {
            return true;
        }

        /// <summary>
        /// To clear all the details user has put in the input fields. 
        /// </summary>
        private ICommand? clearEmployeeDetails;
        public ICommand ClearEmployeeDetails
        {
            get
            {
                if (clearEmployeeDetails == null)
                {
                    clearEmployeeDetails = new RelayCommand(ExecuteClearEmployeeDetails, CanClearEmployeeDetailsExecute, false);
                }
                return clearEmployeeDetails;
            }
        }

        private bool CanClearEmployeeDetailsExecute(object arg)
        {
            return true;
        }

        private void ExecuteClearEmployeeDetails(object obj)
        {
            TempCode = FirstName = LastName = Email = Password = ConfirmPassword = String.Empty;
            SelectedDepartment = SelectedDesignation = null;
            combBoxText = "Select";
            OnPropertyChanged("CombBoxText");
            JoiningDate = DateTime.Now;
            ReleaseDate = null;
            OnPropertyChanged(nameof(ReleaseDate));
        }

        /// <summary>
        /// to clear all the personal details user has put in the input fields.
        /// </summary>
        private ICommand? clearPersonalDetails;
        public ICommand ClearPersonalDetails
        {
            get
            {
                if (clearPersonalDetails == null)
                {
                    clearPersonalDetails = new RelayCommand(ExecuteClearPersonalDetails, CanClearPersonalDetailsExecute, false);
                }
                return clearPersonalDetails;
            }
        }

        private bool CanClearPersonalDetailsExecute(object arg)
        {
            return true;
        }

        private void ExecuteClearPersonalDetails(object obj)
        {
            DOB = DateTime.Now;
            Gender = "Male";
            ContactNumber = PresentAddress = PermanentAddress = String.Empty;
            SelectedMaritalStatus = null;
            maritalStatusCombBoxText = "Select";
            OnPropertyChanged("MaritalStatusCombBoxText");
            IsCheckBoxChecked = false;

            OnPropertyChanged(nameof(ReleaseDate));
        }


        public EditEmployeeViewModel()
        {
            designation = new ObservableCollection<string> { "Developer", "Senior Developer", "Team Lead", "Manager" };
            department = new ObservableCollection<string> { "Dotnet", "Java", "PHP", "Mobile", "QA" };
            maritalStatus = new ObservableCollection<string> { "Married", "Single" };
            insertData = new InsertData();
            deleteData = new DeleteData();
            updateData = new UpdateData();
            GetData getData = new GetData();
        }
        public EditEmployeeViewModel(EmployeeModel employeeModel)
        {
            this.tempCode = employeeModel.Code!;
            this.OldCode = employeeModel.Code!;
            this.Code = employeeModel.Code!;
            this.FirstName = employeeModel.FirstName!;
            this.LastName = employeeModel.LastName!;
            this.Email = employeeModel.Email!;
            this.Password = employeeModel.Password!;
            this.ConfirmPassword = employeeModel.Password!;
            this.SelectedDepartment = employeeModel.Department!;
            this.SelectedDesignation = employeeModel.Designation!;
            this.JoiningDate = employeeModel.JoiningDate!;
            this.ReleaseDate = employeeModel.ReleaseDate;
            this.DOB = employeeModel.DOB!;
            this.ContactNumber = employeeModel.ContactNumber!;
            this.Gender = employeeModel.Gender!;
            this.SelectedMaritalStatus = employeeModel.MaritalStauts!;
            this.PresentAddress = employeeModel.PresentAddress!;
            this.PermanentAddress = employeeModel.PermanentAddress!;
            this.EmployeeEducationList = employeeModel.EducationModels!;
            this.employeeExperienceList = employeeModel.ExperienceModels!;

            designation = new ObservableCollection<string> { "Developer", "Senior Developer", "Team Lead", "Manager" };
            department = new ObservableCollection<string> { "Dotnet", "Java", "PHP", "Mobile", "QA" };
            maritalStatus = new ObservableCollection<string> { "Married", "Single" };
            insertData = new InsertData();
            deleteData = new DeleteData();
            updateData = new UpdateData();
            GetData getData = new GetData();
        }




        /// <summary>
        /// To check if user has put the valid percentage in the percentage input field.
        /// </summary>
        /// <param name="inputPercentage">percentage added by user.</param>
        /// <returns>true if user has added valid (i.e. Decimal and between 0 and 100) percentage otherwise false.</returns>
        private bool IsValidPercentage(string inputPercentage)
        {
            if (decimal.TryParse(inputPercentage, out decimal outputPercentage))
            {
                return outputPercentage >= 0 && outputPercentage <= 100;
            }

            return false;
        }

        /// <summary>
        /// To check if user has put valid year in year input field.
        /// </summary>
        /// <param name="inputYear">year value added by user.</param>
        /// <returns>true if input value is valid(i.e. integer and between 1900 and 3000) otherwise false.</returns>
        private bool IsValidYear(string inputYear)
        {
            if (int.TryParse(inputYear, out int outputYear))
            {

                return outputYear >= 1900 && outputYear <= 3000;
            }

            return false;
        }

        /// <summary>
        /// To check if user has provided valid phone number in phone number input field.
        /// </summary>
        /// <param name="contactNumber">contact number added by user</param>
        /// <returns>true if value is valid (checks using Regex) otherwise false.</returns>
        private bool IsValidContactNumber(string contactNumber)
        {
            string regexPattern = @"^(\+\d{1,2}\s?)?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$";
            return Regex.IsMatch(contactNumber, regexPattern);
        }

        /// <summary>
        /// To check if user has provided valid email address in email address input field.
        /// </summary>
        /// <param name="EmailAddress">email address provided by user</param>
        /// <returns></returns>
        private bool IsValidEmailAddress(string emailAddress)
        {
            string regexPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(emailAddress, regexPattern);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
