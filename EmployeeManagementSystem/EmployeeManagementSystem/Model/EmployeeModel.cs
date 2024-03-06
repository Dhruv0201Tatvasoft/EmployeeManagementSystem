using EmployeeManagementSystem.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EmployeeManagementSystem.Models
{
  public  class EmployeeModel : INotifyPropertyChanged
    {
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; OnPropertyChanged("Code"); }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }

        private string lastName;
        public String LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set {  password = value; OnPropertyChanged("Password"); }
        }
        
        private String designation;
        public String Designation
        {
            get { return designation; }
            set { designation = value; OnPropertyChanged("Designation"); }
        }

        private string department;
        public string Department
        {
            get { return department; }
            set { department = value; OnPropertyChanged("Department");}
        }
        private DateTime joiningDate;
        public DateTime JoiningDate
        {
            get { return joiningDate;}
            set { joiningDate = value;OnPropertyChanged("JoiningDate"); }
        }

        private DateTime? releaseDate;
        public DateTime? ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate= value; OnPropertyChanged("ReleaseDate"); }
        }

        private DateTime dob;
        public DateTime DOB
        {
            get { return dob; }
            set { dob = value; OnPropertyChanged("DOB"); }
        }


        private string contactNumber;
        public string ContactNumber
        {
            get { return contactNumber;} 
            set
            {
                contactNumber = value;
                OnPropertyChanged("ContactNumber");
            }
        }

        private string gender;
        public string Gender
        {
            get { return gender;}
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private string maritalStauts;
        public string MaritalStauts
        {
            get { return maritalStauts;}
            set { maritalStauts = value; OnPropertyChanged("MaritalStatus"); }
        }

        private string presentAddress;
        public string PresentAddress
        {
            get { return presentAddress; }
            set { presentAddress = value; OnPropertyChanged("PresentAddress"); }
        }

        private string permenentAddress;
        public string PermanentAddress
        {
            get { return permenentAddress; }
            set { permenentAddress = value; OnPropertyChanged("PermanentAddress"); }
        }
        private ObservableCollection<EmployeeEducationModel> educationModels = new ObservableCollection<EmployeeEducationModel>();

        public ObservableCollection<EmployeeEducationModel> EducationModels
        {
            get { return educationModels; }
            set { educationModels = value; }
        }
        private ObservableCollection<EmployeeExperienceModel> experienceModels = new ObservableCollection<EmployeeExperienceModel>();

        public ObservableCollection<EmployeeExperienceModel> ExperienceModels
        {
            get { return experienceModels; }
            set { experienceModels = value; }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
