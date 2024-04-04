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
    class AddEmployeeViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private InsertData insertData;
        private DeleteData deleteData;
        private UpdateData updateData;
        public event EventHandler? AddFirstEducationRowEvent;
        public event EventHandler? AddFirstExperienceRowEvent;
        public event EventHandler? EmployeeAddedEvent;
        public event EventHandler? AddEducationRowEvent;
        public event EventHandler? AddExperienceRowEvent;
        public event EventHandler? EditEducationRowEvent;
        public event EventHandler? EditExperienceRowEvent;
        public void OnAddEducationButtonClicked(EventArgs e)
        {
            AddFirstEducationRowEvent?.Invoke(this, e);
        }
        public void OnAddExperienceButtonClicked(EventArgs e)
        {
            AddFirstExperienceRowEvent?.Invoke(this, e);
        }
        public void OnEmployeeAddedEvent(EventArgs e)
        {
            EmployeeAddedEvent?.Invoke(this, e);
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


        public bool IsEducationAddEditEnabled = true; /// to stop simultaneously adding or editing more than one education field.
        public bool CanEducationDeleteFromDB = true; /// to delete education field from database after user hit edit button
        public bool IsExperienceAddEditEnabled = true; /// to stop simultaneously adding or editing more than one experience field.
        public bool CanExperienceDeleteFromDB = true; /// to delete experience field from database after user hit edit button

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
        private string combBoxText = "Select"; /// to show placeholder value of comboBox.

        public string CombBoxText
        {
            get { return combBoxText; }
            set { combBoxText = value; OnPropertyChanged("CombBoxText"); }
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

        private string gender = "Male"; ///by default Male's radio button will be checked

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

        private string maritalStatusCombBoxText = "Select"; /// to show placeholder value of comboBox.

        public string MaritalStatusCombBoxText
        {
            get { return maritalStatusCombBoxText; }
            set { maritalStatusCombBoxText = value; OnPropertyChanged("maritalStatusCombBoxText"); }
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
                    case "Code":
                        if (string.IsNullOrEmpty(Code)) errors = "code can not be empty";
                        if (Code.Length > 10) errors = "code can not be more than 10 characters";
                        break;
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName)) errors = "firstname can not be empty";
                        if (FirstName.Length > 20) errors = "firstName can not be more than 20 characters";
                        break;
                    case "LastName":
                        if (String.IsNullOrEmpty(LastName)) errors = "lastname can not be Empty";
                        if (LastName.Length > 20) errors = "lastName can not be more than 20 characters";
                        break;
                    case "Email":
                        if (string.IsNullOrEmpty(Email)) errors = "email can not be Empty";
                        if (!IsValidEmailAddress(Email)) errors = "not a valid email address";
                        break;
                    case "Password":
                        if (String.IsNullOrEmpty(Password)) errors = "password can not be empty";
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
                        if (String.IsNullOrEmpty(SelectedDepartment) || !Department.Contains(SelectedDepartment)) errors = "please select a valid department";
                        break;
                    case "SelectedMaritalStatus":
                        if (String.IsNullOrEmpty(SelectedMaritalStatus) || !MaritalStatus.Contains(SelectedMaritalStatus)) errors = "please select a valid marital status";
                        break;
                    case "PresentAddress":
                        if (String.IsNullOrEmpty(PresentAddress)) errors = "present address can not be empty";
                        break;
                    case "ContactNumber":
                        if (String.IsNullOrEmpty(ContactNumber)) errors = "contact number can not be empty";
                        if (!IsValidContactNumber(ContactNumber)) errors = "provide a valid contact number";
                        break;
                    case "JoiningDate":
                        if (!string.IsNullOrEmpty(ReleaseDate.ToString()) && JoiningDate > ReleaseDate) errors = "joining date can not be greater than release date ";
                        break;
                    case "ReleaseDate":
                        if (!string.IsNullOrEmpty(ReleaseDate.ToString()) && JoiningDate > ReleaseDate) errors = "release date can not be less than joining date ";
                        break;
                }

                return errors;
            }
        }

        /// <summary>
        /// Command to add employee to database.
        /// </summary>
        private ICommand? addEmployee;
        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null)
                {
                    addEmployee = new RelayCommand(ExecuteAddEmployee, CanAddEmployeeExecute, false);
                }
                return addEmployee;
            }
        }

        /// <summary>
        /// Determines whether the AddEmployee  can be executed.
        /// </summary>
        /// <returns>Always return true indicating AddEmployee can be executed .</returns>
        private bool CanAddEmployeeExecute(object arg)
        {
            return true;
        }

        private void ExecuteAddEmployee(object obj)
        {
            bool didSave = false;
            EmployeeModel employee;
            if (ReleaseDate != null)
            {

                employee = new EmployeeModel
                {
                    Code = Code,
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
                    Code = Code,
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
            didSave = insertData.InsertEmployee(employee, ReleaseDate != null);
            if (didSave) /// if project is saved to database than only we raise this event.
            {
                OnEmployeeAddedEvent(EventArgs.Empty);
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
                    addBlankRowEducation = new RelayCommand(ExecuteAddBlankRowEducation, CanAddBlankRowEducationExecute, false);
                }
                return addBlankRowEducation;
            }
        }

        /// <summary>
        /// Adds a new blank row to the list of employee education lsit.
        /// </summary>
        private void ExecuteAddBlankRowEducation(object obj)
        {
            EmployeeEducationList.Add(new EmployeeEducationModel());///adding new blank model will add blank row.
            IsEducationAddEditEnabled = false; /// making IsEducationAddEditEnabled false will disable add blank row and edit education field button
            CanEducationDeleteFromDB = false; /// making CanEducationDeleteFromDB false means newly added row is to be deleted from Education EmployeeEducationList and not from database.
            OnAddEducationButtonClicked(EventArgs.Empty);
            OnPropertyChanged("EmployeeEducationList");
        }


        /// <summary>
        /// Determines whether a new blank row of education can be added.
        /// </summary>
        /// <returns>True if a new blank row of education can be added; otherwise, false.</returns>
        private bool CanAddBlankRowEducationExecute(object arg)
        {
            if (!IsEducationAddEditEnabled) return false; /// means one education row is already being edited in dataGrid.
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


        /// <summary>
        /// Adds a new blank row of experience to the employee experience list.
        /// </summary>
        private void ExecuteAddRowExperience(object obj)
        {
            EmployeeExperienceList.Add(new EmployeeExperienceModel());///adding new blank model will add blank row.
            IsExperienceAddEditEnabled = false; /// making IsExperienceAddEditEnabled false will disable add blank row and edit experience field button
            CanExperienceDeleteFromDB = false; /// making CanExperienceDeleteFromDB false means newly added row is to be deleted from Education EmployeeEducationList and not from database.
            OnAddExperienceButtonClicked(EventArgs.Empty);
            OnPropertyChanged("EmployeeExperienceList");
        }

        /// <summary>
        /// Determines whether a new row of experience can be added to the employee experience list.
        /// </summary>
        /// <returns>True if a new row of experience can be added; otherwise, false.</returns>
        private bool CanAddRowExperienceExecute(object arg)
        {
            if (!IsExperienceAddEditEnabled) return false; /// means one experience row is already being edited in dataGrid.
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

        /// <summary>
        /// Determines whether the current education row can be saved.
        /// </summary>
        /// <returns>Always returns true indicating education row can always be added.</returns>
        private bool CanSaveEducationRowExecute(object arg)
        {
            return true;
        }

        /// <summary>
        /// Executes the saving of the selected employee education row.
        /// </summary>
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
                MessageBox.Show("Provide valid and numerical value for percentage.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeEducationModel != null && (!string.IsNullOrEmpty(selectedEmployeeEducationModel.PassingYear) && !IsValidYear(selectedEmployeeEducationModel.PassingYear)))/// to validate passing year field.
            {
                MessageBox.Show("Please provide valid value for passing year.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeEducationModel != null && (!string.IsNullOrEmpty(selectedEmployeeEducationModel.InstituteName) && (selectedEmployeeEducationModel.InstituteName.Length > 35))) /// to validate institute name field.
            {
                MessageBox.Show("Maximum character limit reached for institute name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeEducationModel != null && (!string.IsNullOrEmpty(selectedEmployeeEducationModel.Qualification) && (selectedEmployeeEducationModel.Qualification.Length > 10))) /// to validate qualification field.
            {
                MessageBox.Show("Maximum character limit reached for qualification field.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeEducationModel != null && (!string.IsNullOrEmpty(selectedEmployeeEducationModel.BoardUniversity) && (selectedEmployeeEducationModel.BoardUniversity.Length > 30))) /// to validate Board/University field.
            {
                MessageBox.Show("Maximum character limit reached for board/university field.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeEducationModel != null && (!string.IsNullOrEmpty(selectedEmployeeEducationModel.State) && (selectedEmployeeEducationModel.State.Length > 15))) /// to validate state field.
            {
                MessageBox.Show("Maximum character limit reached for state field.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                if (didSave) /// only if education row is saved to database we perform this opetations
                {
                    selectedOldEmployeeEducationModel = null;
                    IsEducationAddEditEnabled = true; /// mean education row is added to DB and now we have to enable add and edit button to add new row or to edit existing.
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

        /// <summary>
        /// Determines whether the current experience row can be saved.
        /// </summary>
        /// <returns>Always returns true indicating experience row can always be added.</returns>
        private bool CanSaveExperienceExecute(object arg)
        {
            return true;
        }

        /// <summary>
        /// Executes the saving of the selected employee experience row.
        /// </summaryexperience
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
                    }
                }
                if (didSave) /// only after saving experience row to database we perform the following operations.
                {
                    selectedOldEmployeeExperienceModel = null;
                    IsExperienceAddEditEnabled = true; /// means experience row is added to DB and now we have to enable add and edit button to add new row or to edit existing.
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


        /// <summary>
        /// Determines whether editing an education row is currently enabled.
        /// </summary>
        /// <returns>True if editing an education row is enabled; otherwise, false.</returns>
        private bool CanEditEducationRowExecute(object arg)
        {
            if (!IsEducationAddEditEnabled) return false; /// means one education row is already being added or edited.
            return true;
        }

        /// <summary>
        /// Executes the editing of the selected education row.
        /// </summary>
        private void ExecuteEditEducationRow(object obj)
        {
            if (selectedEmployeeEducationModel != null)
            {
                selectedOldEmployeeEducationModel = new EmployeeEducationModel
                {
                    State = selectedEmployeeEducationModel.State,
                    Percentage = selectedEmployeeEducationModel.Percentage,
                    BoardUniversity = selectedEmployeeEducationModel.BoardUniversity,
                    InstituteName = selectedEmployeeEducationModel.InstituteName,
                    PassingYear = selectedEmployeeEducationModel.PassingYear,
                    Qualification = selectedEmployeeEducationModel.Qualification
                };
                IsEducationAddEditEnabled = false; /// this education row will now go for editing so we have to disable add and edit buttons/
                CanEducationDeleteFromDB = true; /// means we are editing education row which's data is already available in database.
                OnEditEducationRowEvent(EventArgs.Empty);
            }
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

        /// <summary>
        /// Determines whether the user can edit an experience row.
        /// </summary>
        /// <returns>True if the user can edit an experience row; otherwise, false.</returns>
        private bool CanEditExperienceExecute(object arg)
        {
            if (!IsExperienceAddEditEnabled) return false; /// means one experience row is already being added or edited.
            return true;
        }

        /// <summary>
        /// Executes the editing of an experience row.
        /// </summary>
        private void ExecuteEditExperience(object obj)
        {
            if (selectedEmployeeExperienceModel != null)
            {

                selectedOldEmployeeExperienceModel = new EmployeeExperienceModel
                {
                    Organization = selectedEmployeeExperienceModel.Organization,
                    Duration = selectedEmployeeExperienceModel.Duration,
                    Designation = selectedEmployeeExperienceModel.Designation,
                    ToDate = selectedEmployeeExperienceModel.ToDate,
                    FromDate = selectedEmployeeExperienceModel.FromDate
                };
                IsExperienceAddEditEnabled = false; /// this experience row will now go for editing so we have to disable add and edit buttons.
                CanExperienceDeleteFromDB = true; /// means we are editing  row which's data is already available in database.
                OnEditExperienceRowEvent(EventArgs.Empty);
            }

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


        /// <summary>
        /// Determines whether an education row can be removed from the EmployeeEducationList.
        /// </summary>
        /// <returns>Always return true indicating education row can be removed from the EmployeeEducationList</returns>
        private bool CanRemoveEducationFromListExecute(object arg)
        {
            return true;
        }

        /// <summary>
        /// Executes the removal of an education row from the list.
        /// </summary>
        private void ExecuteRemoveEducationFromList(object obj)
        {
            if (SelectedEmployeeEducationModel != null)
            {
                if (CanEducationDeleteFromDB) /// to check if user is trying to remove already existing education row or he is removing a newly added education row that has not been added to database.
                {

                    if (deleteData.DeleteEducationRow(selectedEmployeeEducationModel!, code))
                    {
                        EmployeeEducationList.Remove(SelectedEmployeeEducationModel);///this will only remove model from EmployeeEducationList and not from the database.
                        IsEducationAddEditEnabled = true; /// if delete operation complete means we now can add or edit education row
                    }
                }
                else
                {
                    EmployeeEducationList.Remove(SelectedEmployeeEducationModel);///this will only remove model from EmployeeEducationList and not from the database.
                    IsEducationAddEditEnabled = true; /// if delete operation complete means we now can add or edit education row

                }

            }
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

        /// <summary>
        /// Determines whether an experience row can be removed from the EmployeeExperienceList.
        /// </summary>
        /// <returns>Always return true indicating experience row can be removed from the EmployeeExperienceList</returns>
        private bool CanRemoveExperienceFromListExecute(object arg)
        {
            return true;
        }

        private void ExecuteRemoveExperienceFromList(object obj)
        {
            if (selectedEmployeeExperienceModel != null)
                if (CanExperienceDeleteFromDB) /// to check if user is trying to remove already existing experience row or he is removing a newly added experience row that has not been added to database.
                {

                    if (deleteData.DeleteExperienceRow(selectedEmployeeExperienceModel!, code))
                    {
                        EmployeeExperienceList.Remove(selectedEmployeeExperienceModel!);///this will only remove model from EmployeeExperienceList and not from the database.
                        IsExperienceAddEditEnabled = true; /// if delete operation complete means we now can add or edit experience row
                    }
                }
                else
                {
                    EmployeeExperienceList.Remove(selectedEmployeeExperienceModel);///this will only remove model from EmployeeExperienceList and not from the database.
                    IsExperienceAddEditEnabled = true; /// if delete operation complete means we now can add or edit experience row

                }
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

        /// <summary>
        /// Determines whether the education row can be removed from database.
        /// </summary>
        /// <returns>Always returns true indicating education row can be removed form database.</returns>
        private bool CanRemoveEducationFromDataBaseExecute(object arg)
        {
            return true;

        }

        /// <summary>
        /// Executes the removal of the selected employee education row from the database.
        /// </summary>
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
        /// </summary>
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
        /// <summary>
        /// Determines whether the removal of the selected employee experience from the database can be executed.
        /// </summary>
        /// <returns>Always returns true indicating  selected employee experience can be removed from database. </returns>
        private bool CanRemoveExperienceFromDataBaseExecute(object arg)
        {
            return true;
        }


        /// <summary>
        /// Executes the removal of the selected employee experience from the database.
        /// </summary>
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

        /// <summary>
        /// Determines whether the employee details can be cleared.
        /// </summary>
        /// <returns>Always return true indicating employee details can be cleared</returns>
        private bool CanClearEmployeeDetailsExecute(object arg)
        {
            return true;
        }

        /// <summary>
        /// Clears the employee details to predefined properties.
        /// </summary>
        private void ExecuteClearEmployeeDetails(object obj)
        {
            Code = FirstName = LastName = Email = Password = ConfirmPassword = String.Empty;
            SelectedDepartment = SelectedDesignation = null;
            JoiningDate = DateTime.Now;
            combBoxText = "Select";
            OnPropertyChanged("CombBoxText");
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


        /// <summary>
        /// Determines whether the personal details can be cleared.
        /// </summary>
        /// <returns>Always return true indicating employee details can be cleard</returns>

        private bool CanClearPersonalDetailsExecute(object arg)
        {
            return true;
        }

        /// <summary>
        /// Clears the employee personal details to predefined properties.
        /// </summary>
        private void ExecuteClearPersonalDetails(object obj)
        {
            DOB = DateTime.Now;
            Gender = "Male";
            ContactNumber = PresentAddress = PermanentAddress = String.Empty;
            maritalStatusCombBoxText = "Select";
            OnPropertyChanged("MaritalStatusCombBoxText");
            SelectedMaritalStatus = null;
            IsCheckBoxChecked = false;

            OnPropertyChanged(nameof(ReleaseDate));
        }

        public AddEmployeeViewModel()
        {
            designation = new ObservableCollection<string> { "Developer", "Senior Developer", "Team Lead", "Manager" };
            department = new ObservableCollection<string> { "Dotnet", "Java", "PHP", "Mobile", "QA" };
            maritalStatus = new ObservableCollection<string> { "Married", "Single" };
            insertData = new InsertData();
            deleteData = new DeleteData();
            updateData = new UpdateData();
            GetData? getData = new GetData();
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
