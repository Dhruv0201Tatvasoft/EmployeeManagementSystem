using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace EmployeeManagementSystem.ViewModel
{
    class AddEmployeeViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private InsertData insertData;
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
        private EmployeeExperienceModel selectedEmployeeExperienceModel;

        public EmployeeExperienceModel SelectedEmployeeExperienceModel
        {
            get { return selectedEmployeeExperienceModel; }
            set { selectedEmployeeExperienceModel = value; }
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
                        if (FirstName.Length > 10) errors = "FirstName cant be more than 10 characters";
                        break;
                    case "LastName":
                        if (String.IsNullOrEmpty(LastName)) errors = "Last Name cant be Empty";
                        if (LastName.Length > 10) errors = "LastName cant be more than 10 characters";
                        break;
                    case "Email":
                        if (!Email.Contains('@')) errors = "Email must contain @";
                        if (Email.Length > 15) errors = "Email cant be more than 15 characters";
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
                        if (ContactNumber.Length < 10) errors = "Provide valid contact number";
                        if (ContactNumber.Length > 13) errors = "Please provide valid contact number";
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
            if (ReleaseDate != null)
            {
                insertData.InsertEmployee(Code, FirstName, LastName, Email, Password, SelectedDesignation, SelectedDepartment, JoiningDate,(DateTime) ReleaseDate, DOB, ContactNumber, Gender, SelectedMaritialStatus, PresentAddress, PermanentAddress);
            }
            else
            {
                insertData.InsertEmployee(Code, FirstName, LastName, Email, Password, SelectedDesignation, SelectedDepartment, JoiningDate, DOB, ContactNumber, Gender, SelectedMaritialStatus, PresentAddress, PermanentAddress);

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
                if(saveEducationRowCommand == null)
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

            insertData.InsertEducationDetails(selectedEmployeeEducationModel, Code);
            OnPropertyChanged("SelectedEmployeeEducationField");
        }


        private ICommand saveExperienceRowCommand;
        public ICommand SaveExperienceRowCommand
        {
            get
            {
                if(saveExperienceRowCommand == null)
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
            insertData.InsertExperienceDetails(selectedEmployeeExperienceModel, Code);
            OnPropertyChanged("SelectedEmployeeEducationField");
        }

        public AddEmployeeViewModel()
        {
            designation = new ObservableCollection<string>(new List<string> { "Developer", "Senior Developer", "Team lead", "Manager" });
            department = new ObservableCollection<string>(new List<String> { "Dotnet", "Java", "Php", "Mobile", "QA" });
            maritalstatus = new ObservableCollection<string>(new List<string> { "Married", "Single" });
            insertData = new InsertData();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
   
}
