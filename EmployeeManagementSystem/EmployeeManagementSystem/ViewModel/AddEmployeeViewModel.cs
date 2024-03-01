using EmployeeManagementSystem.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace EmployeeManagementSystem.ViewModel
{
    class AddEmployeeViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
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

        private DateTime joiningDate;

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

        private DateTime dob;

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


        private ICommand addBlankRow;
        public ICommand AddBlankRow
        {
            get
            {
                if (addBlankRow == null)
                {
                    addBlankRow = new RelayCommand(ExecuteAddRow, CanAddRowExecute, false);
                }
                return addBlankRow;
            }
        }

        private void ExecuteAddRow(object obj)
        {
            Persons.Add(new Person());
            OnPropertyChanged("Persons");
        }

        private bool CanAddRowExecute(object arg)
        {
            return true;
        }

        private bool isBlank =true;
        public bool IsBlank
        {
            get { return isBlank; }
            set
            {
                if (isBlank != value)
                {
                    isBlank = value;
                    OnPropertyChanged(nameof(IsBlank)); // Implement OnPropertyChanged if needed
                }
            }
        }
        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if(saveCommand == null)
                {
                    saveCommand = new RelayCommand(SaveExecute, CanSaveExecute, false);
                }
                return saveCommand;
            }
        }

        private bool CanSaveExecute(object arg)
        {
            return true;
        }

        private void SaveExecute(object obj)
        {
            selectedPerson.IsBlind = !selectedPerson.IsBlind;
            OnPropertyChanged("SelectedPerson");
        }

        private Person selectedPerson;
        public Person SelectedPerson {
            get
            {
                return selectedPerson;
            }
            set
            {
                selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
            }
        
        }
        public ObservableCollection<Person> Persons { get; set; }
        private ICommand editCommnad;
        public ICommand EditCommand
        {
            get
            {
                if(editCommnad == null)
                {
                    editCommnad = new RelayCommand(EditExecute, CanEditExecute, false);
                }
                return editCommnad;
            }
        }

        private bool CanEditExecute(object arg)
        {
            return true;
        }

        private void EditExecute(object obj)
        {
            SelectedPerson.IsBlind =!SelectedPerson.IsBlind;
            OnPropertyChanged("SelectedPerson");
        }

        public AddEmployeeViewModel()
        {
            designation = new ObservableCollection<string>(new List<string> { "Developer", "Senior Developer", "Team lead", "Manager" });
            department = new ObservableCollection<string>(new List<String> { "Dotnet", "Java", "Php", "Mobile", "QA" });
            maritalstatus = new ObservableCollection<string>(new List<string> { "Married", "Single" });
            Persons = new ObservableCollection<Person>
        {
            new Person { Name = "John", Description = "Engineer", IsBlind = true },
            new Person { Name = "Jane", Description = "Teacher", IsBlind = false },
            new Person { Name = "Bob", Description = "Doctor", IsBlind = true },
            // Add more sample data as needed
        };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    public class Person : INotifyPropertyChanged
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }



        private bool isBlind;

        public bool IsBlind
        {
            get { return isBlind; }
            set { isBlind = value;
                OnPropertyChanged("IsBlind");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
