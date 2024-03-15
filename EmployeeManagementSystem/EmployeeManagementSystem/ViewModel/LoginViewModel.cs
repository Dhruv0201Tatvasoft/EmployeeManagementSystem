using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event EventHandler IncorrectLoginEvent;
        private void OnIncorrectLoginEvent(EventArgs empty)
        {
            IncorrectLoginEvent?.Invoke(this, empty);
        }
        public event EventHandler<EmployeeEventArgs> CorrectLoginEvent;
        private void OnCorrectLoginEvent(EmployeeModel employee)
        {
            var eventArgs = new EmployeeEventArgs(employee);
            CorrectLoginEvent?.Invoke(this, eventArgs);
        }
        private GetData getData;
        private string username;

        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("UserName");
            }
        }

        private String password;

        public String Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private ICommand loginCommnad;
        public ICommand LoginCommnad
        {
            get
            {
                if (loginCommnad == null)
                {
                    loginCommnad = new RelayCommand(ExecuteLoginCommand, CanLoginCommandExecute, false);
                }
                return loginCommnad;
            }
        }

        private bool CanLoginCommandExecute(object arg)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)) return false;
            return true;
        }

        private void ExecuteLoginCommand(object obj)
        {
            string code = getData.ExecuteLogin(UserName, Password);
            if (!String.IsNullOrEmpty(code))
            {
                EmployeeModel emp = getData.GetEmployeeModelFromCode(code);
                OnCorrectLoginEvent(emp);
            }
            else
            {
                OnIncorrectLoginEvent(EventArgs.Empty);
            }

        }
        public LoginViewModel()
        {
            getData = new GetData();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class EmployeeEventArgs : EventArgs
    {
        public EmployeeModel emp { get; }
        public EmployeeEventArgs(EmployeeModel emp)
        {
            this.emp = emp;
        }
    }
}
