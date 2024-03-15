using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Models;
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
        public event EventHandler AddEducationButtonClickedEvent;
        public event EventHandler AddExprienceButtonClickedEvent;
        public event EventHandler EmployeeAddedEvent;
        public event EventHandler AddEducationRowEvent;
        public event EventHandler AddExperienceRowEvent;
        public event EventHandler EditEducationRowEvent;
        public event EventHandler EditExprienceRowEvent;
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
            EditExprienceRowEvent.Invoke(this, e);
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

        private string selectedDepartment = string.Empty;

        public string SelectedDepartment
        {
            get { return selectedDepartment; }
            set { selectedDepartment = value; OnPropertyChanged("SelectedDepartment"); }
        }

        private string selectedDesignation = string.Empty;

        public string SelectedDesignation
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


                OnPropertyChanged("PermanentAddress");
            }


        }
        private string selectedmaritalStatus = string.Empty;

        public string SelectedMaritialStatus
        {
            get { return selectedmaritalStatus; }
            set { selectedmaritalStatus = value; OnPropertyChanged("SelectedMaritialStatus"); }
        }
        private bool isCheckBoxChecked;

        public bool IsCheckBoxChecked
        {
            get { return isCheckBoxChecked; }
            set
            {
                isCheckBoxChecked = value;
                if (value != null && value)
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
        private ObservableCollection<string> maritalstatus;
        public ObservableCollection<string> MaritalStatus
        {
            get { return maritalstatus; }
            set { maritalstatus = value; OnPropertyChanged("MaritalStatus"); }

        }
        private EmployeeEducationModel selectedEmployeeEducationModel;

        public EmployeeEducationModel SelectedEmployeeEducationModel
        {
            get { return selectedEmployeeEducationModel; }
            set { selectedEmployeeEducationModel = value; }
        }
        private EmployeeEducationModel selectedOldEmployeeEducationModel;

        public EmployeeEducationModel SelectedOldEmployeeEducationModel
        {
            get { return selectedOldEmployeeEducationModel; }
            set { selectedOldEmployeeEducationModel = value; }
        }

        private EmployeeExperienceModel selectedEmployeeExperienceModel;

        public EmployeeExperienceModel SelectedEmployeeExperienceModel
        {
            get { return selectedEmployeeExperienceModel; }
            set { selectedEmployeeExperienceModel = value; }
        }

        private EmployeeExperienceModel selectedOldEmployeeExprienceModel;

        public EmployeeExperienceModel SelectedOldEmployeeExprienceModel
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
                    case "SelectedMaritialStatus":
                        if (String.IsNullOrEmpty(SelectedMaritialStatus) || !MaritalStatus.Contains(SelectedMaritialStatus)) errors = "Please select valid marital status";
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

        private ICommand addEmployeeCommand;
        public ICommand AddEmployeeCommand
        {
            get
            {
                if (addEmployeeCommand == null)
                {
                    addEmployeeCommand = new RelayCommand(AddEmployeeExecute, CanAddEmployeeExecute, false);
                }
                return addEmployeeCommand;
            }
        }

        private bool CanAddEmployeeExecute(object arg)
        {
            return true;
        }

        private void AddEmployeeExecute(object obj)
        {
            bool didsaved = false;
            if (ReleaseDate != null)
            {
                //MessageBoxResult result = MessageBox.Show($"You Are Adding Employee With \nEmployyeCode: {Code}\nName: {FirstName} {LastName}\nEmail: {Email}\n" +
                //     $"Password: {Password}\nDesignation: {SelectedDesignation}\nDepartment: {SelectedDepartment}\nJoinning Date: {JoiningDate.ToString("yyyy-MM-dd")}\n" +
                //     $"Release Date: {ReleaseDate}\nBirth Date: {DOB.ToString("yyyy-MM-dd")}\nContact Number:{ContactNumber}\nGender:{Gender}\n" +
                //     $"Maritial Status: {SelectedMaritialStatus}\nPresent Address: {PresentAddress}\nPermanent Address :{PermanentAddress} ", "Alert", MessageBoxButton.OKCancel, MessageBoxImage.None, MessageBoxResult.Cancel);
                //if (result == MessageBoxResult.OK)
                //{
                EmployeeModel employee = new EmployeeModel
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
                    MaritalStauts = SelectedMaritialStatus,
                    PresentAddress = PresentAddress,
                    PermanentAddress = PermanentAddress
                };
                didsaved = insertData.InsertEmployee(employee);
                //}
            }
            else
            {
                //MessageBoxResult result = MessageBox.Show($"You Are Adding Employee With \nEmployyeCode: {Code}\nName: {FirstName} {LastName}\nEmail: {Email}\n" +
                //      $"Password: {Password}\nDesignation: {SelectedDesignation}\nDepartment: {SelectedDepartment}\nJoinning Date: {JoiningDate.ToString("yyyy-MM-dd")}\n" +
                //      $"Birth Date: {DOB.ToString("yyyy-MM-dd")}\nContact Number:{ContactNumber}\nGender:{Gender}\n" +
                //      $"Maritial Status: {SelectedMaritialStatus}\nPresent Address: {PresentAddress}\nPermanent Address :{PermanentAddress} ", "Alert", MessageBoxButton.OKCancel, MessageBoxImage.None, MessageBoxResult.Cancel);
                //if (result == MessageBoxResult.OK)
                //{
                //{
                EmployeeModel employee = new EmployeeModel
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
                    MaritalStauts = SelectedMaritialStatus,
                    PresentAddress = PresentAddress,
                    PermanentAddress = PermanentAddress
                };
                didsaved = insertData.InsertEmployeeWithoutReleaseDate(employee);
                //}
            }
            if (didsaved)
            {
                OnEmployeeAddedEvent(EventArgs.Empty);
            }
        }

        private ICommand addBlankRowEducation;
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
            EmployeeEducationList.Add(new EmployeeEducationModel());
            OnAddEducationButtonClicked(EventArgs.Empty);
            OnPropertyChanged("EmployeeEducationList");
        }

        private bool CanAddRowEducationExecute(object arg)
        {
            return true;
        }


        private ICommand addBlankRowExperience;
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
            EmployeeExperienceList.Add(new EmployeeExperienceModel());
            OnAddExprienceButtonClicked(EventArgs.Empty);
            OnPropertyChanged("EmployeeExperienceList");
        }

        private bool CanAddRowExperienceExecute(object arg)
        {
            return true;
        }
        private ICommand saveEducationRowCommand;
        public ICommand SaveEducationRowCommand
        {
            get
            {
                if (saveEducationRowCommand == null)
                {
                    saveEducationRowCommand = new RelayCommand(SaveEducationRowExecute, CanSaveEducationRowExecute, false);
                }
                return saveEducationRowCommand;
            }
        }

        private bool CanSaveEducationRowExecute(object arg)
        {
            return true;
        }

        private void SaveEducationRowExecute(object obj)
        {
            if (string.IsNullOrEmpty(selectedEmployeeEducationModel.BoardUniversity) ||
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
            else
            {
                bool didSave = false;
                if (selectedOldEmployeeEducationModel == null)
                {
                    didSave = insertData.InsertEducationDetails(selectedEmployeeEducationModel, Code);
                }
                else
                {
                    didSave = updateData.UpdateEmployeeEducation(selectedEmployeeEducationModel, SelectedOldEmployeeEducationModel, code);
                }
                if (didSave)
                {
                    selectedOldEmployeeEducationModel = null;
                    OnAddEducationRowEvent(EventArgs.Empty);
                }
            }
            OnPropertyChanged("SelectedEmployeeEducationField");
        }

        private ICommand saveExperienceRowCommand;
        public ICommand SaveExperienceRowCommand
        {
            get
            {
                if (saveExperienceRowCommand == null)
                {
                    saveExperienceRowCommand = new RelayCommand(SaveExperienceRowExecute, CanSaveExperienceExecute, false);
                }
                return saveExperienceRowCommand;
            }
        }

        private bool CanSaveExperienceExecute(object arg)
        {
            return true;
        }


        private void SaveExperienceRowExecute(object obj)
        {
            if (string.IsNullOrEmpty(selectedEmployeeExperienceModel.Organization) ||
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
            else
            {
                bool didsave = false;
                if (selectedOldEmployeeExprienceModel == null)
                {
                    didsave = insertData.InsertExperienceDetails(selectedEmployeeExperienceModel, Code);
                }
                else
                {
                    didsave = updateData.UpdateEmployeeExperience(selectedEmployeeExperienceModel, selectedOldEmployeeExprienceModel, code);
                }
                if (didsave)
                {
                    selectedOldEmployeeExprienceModel = null;
                    OnAddExperienceRowEvent(EventArgs.Empty);
                }
            }
            OnPropertyChanged("SelectedEmployeeEducationField");
        }

        private ICommand editEducationRowCommand;
        public ICommand EditEducationRowCommand
        {
            get
            {
                if (editEducationRowCommand == null)
                {
                    editEducationRowCommand = new RelayCommand(ExecuteEditEducationRowCommand, CanEditEducationRowCommandExecute, false);
                }
                return editEducationRowCommand;
            }


        }

        private bool CanEditEducationRowCommandExecute(object arg)
        {
            return true;

        }

        private void ExecuteEditEducationRowCommand(object obj)
        {
            selectedOldEmployeeEducationModel = new EmployeeEducationModel();

            selectedOldEmployeeEducationModel.State = SelectedEmployeeEducationModel.State;
            selectedOldEmployeeEducationModel.Percentage = SelectedEmployeeEducationModel.Percentage;
            selectedOldEmployeeEducationModel.BoardUniversity = SelectedEmployeeEducationModel.BoardUniversity;
            selectedOldEmployeeEducationModel.InstituteName = SelectedEmployeeEducationModel.InstituteName;
            selectedOldEmployeeEducationModel.PassingYear = SelectedEmployeeEducationModel.PassingYear;
            selectedOldEmployeeEducationModel.Qualification = selectedEmployeeEducationModel.Qualification;
            OnEditEducationRowEvent(EventArgs.Empty);
        }

        private ICommand editExperienceCommand;
        public ICommand EditExperienceCommand
        {
            get
            {
                if (editExperienceCommand == null)
                {
                    editExperienceCommand = new RelayCommand(ExecuteEditExperienceCommand, CanEditExperienceCommandExecute, false);
                }
                return editExperienceCommand;
            }
        }

        private void ExecuteEditExperienceCommand(object obj)
        {
            selectedOldEmployeeExprienceModel = new EmployeeExperienceModel();
            selectedOldEmployeeExprienceModel.Organization = selectedEmployeeExperienceModel.Organization;
            selectedOldEmployeeExprienceModel.Duration = selectedEmployeeExperienceModel.Duration;
            selectedOldEmployeeExprienceModel.Designation = selectedEmployeeExperienceModel.Designation;
            selectedOldEmployeeExprienceModel.ToDate = selectedEmployeeExperienceModel.ToDate;
            selectedOldEmployeeExprienceModel.FromDate = selectedEmployeeExperienceModel.FromDate;
            OnEditExperienceRowEvent(EventArgs.Empty);
        }

        private bool CanEditExperienceCommandExecute(object arg)
        {
            return true;
        }

        private ICommand removeEducationFromListCommand;
        public ICommand RemoveEducationFromListCommand
        {
            get
            {
                if (removeEducationFromListCommand == null)
                {
                    removeEducationFromListCommand = new RelayCommand(ExecuteRemoveEducationFromList, CanRemoveEducationFromListCommandExecute, false);
                }
                return removeEducationFromListCommand;
            }
        }



        private bool CanRemoveEducationFromListCommandExecute(object arg)
        {
            return true;
        }

        private void ExecuteRemoveEducationFromList(object obj)
        {
            EmployeeEducationList.Remove(SelectedEmployeeEducationModel);
            OnPropertyChanged("EmployeeEducationList");
        }

        private ICommand removeExperienceFromList;
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
            EmployeeExperienceList.Remove(selectedEmployeeExperienceModel);
            OnPropertyChanged("EmployeeExperienceList");
        }

        private ICommand removeEducationFromDataBaseCommand;
        public ICommand RemoveEducationFromDataBaseCommand
        {
            get
            {
                if (removeEducationFromDataBaseCommand == null)
                {
                    removeEducationFromDataBaseCommand = new RelayCommand(RemoveEducationFromDataBaseCommandExecute, CanRemoveEducationFromDataBaseCommandExecute, false);
                }
                return removeEducationFromDataBaseCommand;
            }
        }

        private bool CanRemoveEducationFromDataBaseCommandExecute(object arg)
        {
            return true;

        }

        private void RemoveEducationFromDataBaseCommandExecute(object obj)
        {
            bool didDelete = false;
            didDelete = deleteData.DeleteEducationRow(selectedEmployeeEducationModel, Code);
            if (didDelete)
            {
                employeeEducationList.Remove(selectedEmployeeEducationModel);

            }
            OnPropertyChanged("employeeEducationList");
        }

        private ICommand removeExperienceFromDataBaseCommand;
        public ICommand RemoveExperienceFromDataBaseCommand
        {
            get
            {
                if (removeExperienceFromDataBaseCommand == null)
                {
                    removeExperienceFromDataBaseCommand = new RelayCommand(ExecuteRemoveExperienceFromDataBaseCommand, CanRemoveExperienceFromDataBaseCommandExecute, false);
                }
                return removeExperienceFromDataBaseCommand;
            }
        }

        private void ExecuteRemoveExperienceFromDataBaseCommand(object obj)
        {
            bool didDelete = false;
            didDelete = deleteData.DeleteExperienceRow(selectedEmployeeExperienceModel, Code);
            if (didDelete)
            {
                EmployeeExperienceList.Remove(selectedEmployeeExperienceModel);
            }
            OnPropertyChanged("EmployeeExperienceList");
        }

        private bool CanRemoveExperienceFromDataBaseCommandExecute(object arg)
        {
            return true;
        }

        private ICommand clearEmployeeDetailsCommand;
        public ICommand ClearEmployeeDetailsCommand
        {
            get
            {
                if (clearEmployeeDetailsCommand == null)
                {
                    clearEmployeeDetailsCommand = new RelayCommand(ExecuteclearEmployeeDetailsCommand, CanclearEmployeeDetailsCommandExecute, false);
                }
                return clearEmployeeDetailsCommand;
            }
        }

        private bool CanclearEmployeeDetailsCommandExecute(object arg)
        {
            return true;
        }

        private void ExecuteclearEmployeeDetailsCommand(object obj)
        {
            Code = FirstName = LastName = Email = Password = ConfirmPassword = String.Empty;
            SelectedDepartment = SelectedDesignation = null;
            JoiningDate = DateTime.Now;
            ReleaseDate = null;
            OnPropertyChanged(nameof(ReleaseDate));
        }
        private ICommand clearPersonlaDetalisCommand;
        public ICommand ClearPersonlaDetalisCommand
        {
            get
            {
                if (clearPersonlaDetalisCommand == null)
                {
                    clearPersonlaDetalisCommand = new RelayCommand(ExecuteClearPersonlaDetalisCommand, CanClearPersonlaDetalisCommandExecute, false);
                }
                return clearPersonlaDetalisCommand;
            }
        }

        private bool CanClearPersonlaDetalisCommandExecute(object arg)
        {
            return true;
        }

        private void ExecuteClearPersonlaDetalisCommand(object obj)
        {
            DOB = DateTime.Now;
            Gender = "Male";
            ContactNumber = PresentAddress = PermanentAddress = String.Empty;
            SelectedMaritialStatus = null;
            IsCheckBoxChecked = false;

            OnPropertyChanged(nameof(ReleaseDate));
        }

        public AddEmployeeViewModel()
        {
            designation = new ObservableCollection<string>(new List<string> { "Developer", "Senior Developer", "Team Lead", "Manager" });
            department = new ObservableCollection<string>(new List<string> { "Dotnet", "Java", "PHP", "Mobile", "QA" });
            maritalstatus = new ObservableCollection<string>(new List<string> { "Married", "Single" });
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
        private bool IsValidYear(string IYear)
        {
            if (int.TryParse(IYear, out int OYear))
            {

                return OYear >= 1900 && OYear <= 3000;
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
