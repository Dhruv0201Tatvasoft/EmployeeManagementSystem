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
        public event EventHandler? AddExprienceButtonClickedEvent;
        public event EventHandler? EmployeeUpdatedEvent;
        public event EventHandler? AddEducationRowEvent;
        public event EventHandler? AddExperienceRowEvent;
        public event EventHandler? EditEducationRowEvent;
        public event EventHandler? EditExprienceRowEvent;

        public void OnAddEducationButtonClicked(EventArgs e)
        {
            AddEducationButtonClickedEvent?.Invoke(this, e);
        }
        public void OnAddExprienceButtonClicked(EventArgs e)
        {
            AddExprienceButtonClickedEvent?.Invoke(this, e);
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
            EditExprienceRowEvent?.Invoke(this, e);
        }

        private string oldCode = string.Empty;

        public string OldCode
        {
            get { return oldCode; }
            set { oldCode = value; OnPropertyChanged("OldCode"); }
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

        private string gender = "Male";

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
        private string? selectedmaritalStatus = string.Empty;

        public string? SelectedMaritalStatus
        {
            get { return selectedmaritalStatus; }
            set { selectedmaritalStatus = value; OnPropertyChanged("SelectedMaritalStatus"); }
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
        private ObservableCollection<string> maritalstatus;
        public ObservableCollection<string> MaritalStatus
        {
            get { return maritalstatus; }
            set { maritalstatus = value; OnPropertyChanged("MaritalStatus"); }

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

        private EmployeeExperienceModel? selectedOldEmployeeExprienceModel;

        public EmployeeExperienceModel? SelectedOldEmployeeExprienceModel
        {
            get { return selectedOldEmployeeExprienceModel; }
            set { selectedOldEmployeeExprienceModel = value; }
        }


        ObservableCollection<EmployeeEducationModel> employeeEducationList = new ObservableCollection<EmployeeEducationModel>();
        public ObservableCollection<EmployeeEducationModel> EmployeeEducationList
        { get { return employeeEducationList; } set { employeeEducationList = value; } }

        ObservableCollection<EmployeeExperienceModel> employeeExperienceList = new ObservableCollection<EmployeeExperienceModel>();
        public ObservableCollection<EmployeeExperienceModel> EmployeeExperienceList
        { get { return employeeExperienceList; } set { employeeExperienceList = value; } }

        public string Error => null!;

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
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName)) errors = "FirstName cant be empty";
                        if (FirstName.Length > 20) errors = "FirstName cant be more than 20 characters";
                        break;
                    case "LastName":
                        if (String.IsNullOrEmpty(LastName)) errors = "Last Name cant be Empty";
                        if (LastName.Length > 20) errors = "LastName cant be more than 20 characters";
                        break;
                    case "Email":
                        if (string.IsNullOrEmpty(Email)) errors = "Email cant be Empty";
                        if (!IsValidEmailAddress(Email)) errors = "Not a valid email address";
                        break;
                    case "Password":
                        if (String.IsNullOrEmpty(Password)) errors = "Password cant be empty";
                        if (Password.Length < 8) errors = "Password must be longer than 8 characters";
                        if (password.Length > 20) errors = "Password maximum Limit";
                        break;
                    case "ConfirmPassword":
                        if (!ConfirmPassword.Equals(Password)) errors = "Does not match with your password";
                        break;
                    case "SelectedDesignation":
                        if (String.IsNullOrEmpty(SelectedDesignation) || !Designation.Contains(SelectedDesignation)) errors = "Please select a valid designation";
                        break;
                    case "SelectedDepartment":
                        if (String.IsNullOrEmpty(SelectedDepartment) || !Department.Contains(SelectedDepartment)) errors = "Plaease select valid department";
                        break;
                    case "SelectedMaritalStatus":
                        if (String.IsNullOrEmpty(SelectedMaritalStatus) || !MaritalStatus.Contains(SelectedMaritalStatus)) errors = "Please select valid marital status";
                        break;
                    case "PresentAddress":
                        if (String.IsNullOrEmpty(PresentAddress)) errors = "Present Address cant be empty";
                        break;
                    case "ContactNumber":
                        if (String.IsNullOrEmpty(ContactNumber)) errors = "Contact number cant be empty";
                        if (!IsValidContactNumber(ContactNumber)) errors = "Provide valid contact number";
                        break;
                    case "JoiningDate":
                        if (!string.IsNullOrEmpty(ReleaseDate.ToString()) && JoiningDate > ReleaseDate) errors = "Joining Date cant be greater than Releas date ";
                        break;
                    case "ReleaseDate":
                        if (!string.IsNullOrEmpty(ReleaseDate.ToString()) && JoiningDate > ReleaseDate) errors = "Release Date cant be less than ending date ";
                        break;
                }

                return errors;
            }
        }
        private ICommand? updateEmployee;
        public ICommand UpdateEmployee
        {
            get
            {
                if (updateEmployee == null)
                {
                    updateEmployee = new RelayCommand(ExecuteUpdateEmployee, CanUpdateEmployeeExecute);
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
            bool didsaved = false;
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
            didsaved = updateData.UpdateEmployee(oldCode, employee, ReleaseDate != null);
            if (didsaved)
            {
                OnEmployeeAddedEvent(EventArgs.Empty);
            }
        }
        private ICommand? addBlankRowEducation;
        public ICommand AddBlankRowEducation
        {
            get
            {
                if (addBlankRowEducation == null)
                {
                    addBlankRowEducation = new RelayCommand(ExecuteAddRowEducation, CanAddRowEducationExecute);
                }
                return addBlankRowEducation;
            }
        }
        private void ExecuteAddRowEducation(object obj)
        {
            EmployeeEducationList.Add(new EmployeeEducationModel());
            OnAddEducationButtonClicked(EventArgs.Empty);
            OnPropertyChanged("EmployeeEducationList");
        }

        private bool CanAddRowEducationExecute(object arg)
        {
            return true;
        }


        private ICommand? addBlankRowExperience;
        public ICommand AddBlankRowExperience
        {
            get
            {
                if (addBlankRowExperience == null)
                {
                    addBlankRowExperience = new RelayCommand(ExecuteAddRowExperience, CanAddRowExperienceExecute);
                }
                return addBlankRowExperience;
            }
        }

        private void ExecuteAddRowExperience(object obj)
        {
            EmployeeExperienceList.Add(new EmployeeExperienceModel());
            OnAddExprienceButtonClicked(EventArgs.Empty);
            OnPropertyChanged("EmployeeExperienceList");
        }

        private bool CanAddRowExperienceExecute(object arg)
        {
            return true;
        }
        private ICommand? saveEducationRow;
        public ICommand SaveEducationRow
        {
            get
            {
                if (saveEducationRow == null)
                {
                    saveEducationRow = new RelayCommand(ExecuteSaveEducationRow, CanSaveEducationRowExecute);
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
            if (string.IsNullOrEmpty(selectedEmployeeEducationModel?.BoardUniversity) ||
           string.IsNullOrEmpty(selectedEmployeeEducationModel.Percentage) ||
           string.IsNullOrEmpty(selectedEmployeeEducationModel.State) ||
           string.IsNullOrEmpty(selectedEmployeeEducationModel.Qualification) ||
           string.IsNullOrEmpty(selectedEmployeeEducationModel.InstituteName))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!string.IsNullOrEmpty(selectedEmployeeEducationModel.Percentage) && !IsValidPercentage(selectedEmployeeEducationModel.Percentage))
            {
                MessageBox.Show("Please provide valid vlue for percentage", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!string.IsNullOrEmpty(selectedEmployeeEducationModel.PassingYear) && !IsValidYear(selectedEmployeeEducationModel.PassingYear))
            {
                MessageBox.Show("Please provide valid vlue for Passing Year", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!string.IsNullOrEmpty(selectedEmployeeEducationModel.InstituteName) && (selectedEmployeeEducationModel.InstituteName.Length > 35))
            {
                MessageBox.Show("Maximum character limit reached from Institute Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!string.IsNullOrEmpty(selectedEmployeeEducationModel.Qualification) && (selectedEmployeeEducationModel.Qualification.Length > 10))
            {
                MessageBox.Show("Maximum character limit reached from Qualification Field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!string.IsNullOrEmpty(selectedEmployeeEducationModel.BoardUniversity) && (selectedEmployeeEducationModel.BoardUniversity.Length > 30))
            {
                MessageBox.Show("Maximum character limit reached from Board/Universtiy Field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!string.IsNullOrEmpty(selectedEmployeeEducationModel.State) && (selectedEmployeeEducationModel.State.Length > 15))
            {
                MessageBox.Show("Maximum character limit reached from State Field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                bool didSave = false;
                if (selectedOldEmployeeEducationModel == null)
                {
                    didSave = insertData.InsertEducationDetails(selectedEmployeeEducationModel, Code);
                }
                else
                {
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

        private ICommand? saveExperienceRow;
        public ICommand SaveExperienceRow
        {
            get
            {
                if (saveExperienceRow == null)
                {
                    saveExperienceRow = new RelayCommand(ExecuteSaveExperienceRow, CanSaveExperienceExecute);
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
            if (string.IsNullOrEmpty(selectedEmployeeExperienceModel?.Organization) ||
                string.IsNullOrEmpty(selectedEmployeeExperienceModel.Designation) ||
                selectedEmployeeExperienceModel.FromDate == null ||
                selectedEmployeeExperienceModel.ToDate == null)
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (selectedEmployeeExperienceModel.Duration < 0)
            {
                MessageBox.Show("Please provide valid value for from and to date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!String.IsNullOrEmpty(selectedEmployeeExperienceModel.Organization) && (selectedEmployeeExperienceModel.Organization.Length > 15))
            {
                MessageBox.Show("Maximum character limit reached from Organization  Field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            else
            {
                bool didSave = false;
                if (selectedOldEmployeeExprienceModel == null)
                {
                    didSave = insertData.InsertExperienceDetails(selectedEmployeeExperienceModel, Code);
                }
                else
                {
                    didSave = updateData.UpdateEmployeeExperience(selectedEmployeeExperienceModel, selectedOldEmployeeExprienceModel, code);
                }
                if (didSave)
                {
                    selectedOldEmployeeExprienceModel = null;
                    OnAddExperienceRowEvent(EventArgs.Empty);

                }
            }
            OnPropertyChanged("SelectedEmployeeEducationField");
        }

        private ICommand? editEducationRow;
        public ICommand EditEducationRow
        {
            get
            {
                if (editEducationRow == null)
                {
                    editEducationRow = new RelayCommand(ExecuteEditEducationRow, CanEditEducationRowExecute);
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
            if(SelectedEmployeeEducationModel!=null)
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

        private ICommand? editExperience;
        public ICommand EditExperience
        {
            get
            {
                if (editExperience == null)
                {
                    editExperience = new RelayCommand(ExecuteEditExperience, CanEditExperienceExecute);
                }
                return editExperience;
            }
        }

        private void ExecuteEditExperience(object obj)
        {
            if(selectedEmployeeExperienceModel!=null)
            selectedOldEmployeeExprienceModel = new EmployeeExperienceModel
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

        private ICommand? removeEducationFromList;
        public ICommand RemoveEducationFromList
        {
            get
            {
                if (removeEducationFromList == null)
                {
                    removeEducationFromList = new RelayCommand(ExecuteRemoveEducationFromList, CanRemoveEducationFromListExecute);
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
            if(SelectedEmployeeEducationModel!=null)
            EmployeeEducationList.Remove(SelectedEmployeeEducationModel);
            OnPropertyChanged("EmployeeEducationList");
        }

        private ICommand? removeExperienceFromList;
        public ICommand RemoveExperienceFromList
        {
            get
            {
                if (removeExperienceFromList == null)
                {
                    removeExperienceFromList = new RelayCommand(ExecuteRemoveExperienceFromList, CanRemoveExperienceFromListExecute);
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
            if(selectedEmployeeExperienceModel!=null)
            EmployeeExperienceList.Remove(selectedEmployeeExperienceModel);
            OnPropertyChanged("EmployeeExperienceList");
        }

        private ICommand? removeEducationFromDataBase;
        public ICommand RemoveEducationFromDataBase
        {
            get
            {
                if (removeEducationFromDataBase == null)
                {
                    removeEducationFromDataBase = new RelayCommand(ExecuteRemoveEducationFromDataBase, CanRemoveEducationFromDataBaseExecute);
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
            bool didDelete = false;
            if (selectedEmployeeEducationModel != null)
                didDelete = deleteData.DeleteEducationRow(selectedEmployeeEducationModel, Code);
            if (didDelete)
            {
                if (selectedEmployeeEducationModel != null)
                    employeeEducationList.Remove(selectedEmployeeEducationModel);
            }
            OnPropertyChanged("employeeEducationList");
        }

        private ICommand? removeExperienceFromDataBase;
        public ICommand RemoveExperienceFromDataBase
        {
            get
            {
                if (removeExperienceFromDataBase == null)
                {
                    removeExperienceFromDataBase = new RelayCommand(ExecuteRemoveExperienceFromDataBase, CanRemoveExperienceFromDataBaseExecute);
                }
                return removeExperienceFromDataBase;
            }
        }

        private void ExecuteRemoveExperienceFromDataBase(object obj)
        {
            bool didDelete = false;
            if (selectedEmployeeExperienceModel != null)
                didDelete = deleteData.DeleteExperienceRow(selectedEmployeeExperienceModel, Code);
            if (didDelete)
            {
                if (selectedEmployeeExperienceModel != null)
                    EmployeeExperienceList.Remove(selectedEmployeeExperienceModel);
            }
            OnPropertyChanged("EmployeeExperienceList");
        }

        private bool CanRemoveExperienceFromDataBaseExecute(object arg)
        {
            return true;
        }

        private ICommand? clearEmployeeDetails;
        public ICommand ClearEmployeeDetails
        {
            get
            {
                if (clearEmployeeDetails == null)
                {
                    clearEmployeeDetails = new RelayCommand(ExecuteClearEmployeeDetails, CanClearEmployeeDetailsExecute);
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
            Code = FirstName = LastName = Email = Password = ConfirmPassword = String.Empty;
            SelectedDepartment = SelectedDesignation = null;
            combBoxText = "Select";
            OnPropertyChanged("CombBoxText");
            JoiningDate = DateTime.Now;
            ReleaseDate = null;
            OnPropertyChanged(nameof(ReleaseDate));
        }
        private ICommand? clearPersonalDetalis;
        public ICommand ClearPersonalDetalis
        {
            get
            {
                if (clearPersonalDetalis == null)
                {
                    clearPersonalDetalis = new RelayCommand(ExecuteClearPersonalDetalis, CanClearPersonalDetalisExecute);
                }
                return clearPersonalDetalis;
            }
        }

        private bool CanClearPersonalDetalisExecute(object arg)
        {
            return true;
        }

        private void ExecuteClearPersonalDetalis(object obj)
        {
            DOB = DateTime.Now;
            Gender = "Male";
            ContactNumber = PresentAddress = PermanentAddress = String.Empty;
            SelectedMaritalStatus = null;
            combBoxText = "Select";
            OnPropertyChanged("CombBoxText");
            IsCheckBoxChecked = false;

            OnPropertyChanged(nameof(ReleaseDate));
        }


        public EditEmployeeViewModel()
        {
            designation = new ObservableCollection<string> { "Developer", "Senior Developer", "Team Lead", "Manager" };
            department = new ObservableCollection<string> { "Dotnet", "Java", "PHP", "Mobile", "QA" };
            maritalstatus = new ObservableCollection<string> { "Married", "Single" };
            insertData = new InsertData();
            deleteData = new DeleteData();
            updateData = new UpdateData();
            GetData getData = new GetData();
        }
        public EditEmployeeViewModel(EmployeeModel employeeModel)
        {

            this.OldCode = employeeModel.Code!;
            this.Code = employeeModel.Code!;
            this.FirstName = employeeModel.FirstName!;
            this.LastName = employeeModel.LastName!;
            this.Email = employeeModel.Email!;
            this.Password = employeeModel.Password!;
            this.ConfirmPassword = employeeModel.Password!;
            this.SelectedDepartment = employeeModel.Department;
            this.SelectedDesignation = employeeModel.Designation;
            this.JoiningDate = employeeModel.JoiningDate;
            this.ReleaseDate = employeeModel.ReleaseDate;
            this.DOB = employeeModel.DOB;
            this.ContactNumber = employeeModel.ContactNumber!;
            this.Gender = employeeModel.Gender!;
            this.SelectedMaritalStatus = employeeModel.MaritalStauts;
            this.PresentAddress = employeeModel.PresentAddress!;
            this.PermanentAddress = employeeModel.PermanentAddress!;
            this.EmployeeEducationList = employeeModel.EducationModels;
            this.employeeExperienceList = employeeModel.ExperienceModels;
            designation = new ObservableCollection<string> { "Developer", "Senior Developer", "Team Lead", "Manager" };
            department = new ObservableCollection<string> { "Dotnet", "Java", "PHP", "Mobile", "QA" };
            maritalstatus = new ObservableCollection<string> { "Married", "Single" };
            insertData = new InsertData();
            deleteData = new DeleteData();
            updateData = new UpdateData();
            GetData getData = new GetData();

        }
        private bool IsValidPercentage(string Ipercentage)
        {
            if (decimal.TryParse(Ipercentage, out decimal Opercentage))
            {
                return Opercentage >= 0 && Opercentage <= 100;
            }

            return false;
        }
        private bool IsValidYear(string InputYear)
        {
            if (int.TryParse(InputYear, out int OutputYear))
            {

                return OutputYear >= 1900 && OutputYear <= 3000;
            }

            return false;
        }
        private bool IsValidContactNumber(string ContactNumber)
        {
            string regexPattern = @"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$";
            return Regex.IsMatch(ContactNumber, regexPattern);
        }

        private bool IsValidEmailAddress(string EmailAddress)
        {
            string regexPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(EmailAddress, regexPattern);
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
