using EmployeeManagementSystem.Model;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for EmployeeLoginDetails.xaml
    /// </summary>
    public partial class EmployeeLoginDetails : UserControl
    {
        public EmployeeLoginDetails()
        {
            InitializeComponent();
        }

        public EmployeeLoginDetails(EmployeeModel employee)
        {
            InitializeComponent();
            this.EmployeeCode.Text = employee.Code;
            this.Name.Text = employee.FirstName + " " + employee.LastName;
            this.Email.Text = employee.Email;
            this.Password.Text = employee.Password;
            this.JoiningDate.Text = employee.JoiningDate.ToString("dd-MM-yyyy");
            if (employee.ReleaseDate.HasValue)
            {
                this.ReleaseDate.Text = employee.ReleaseDate.Value.ToString("dd-MM-yyyy");
            }
            else
            {
                this.ReleaseDate.Text =string.Empty;
            }
            this.DateOfBirth.Text = employee.DOB.ToString("dd-MM-yyyy");
            this.ContactNumber.Text = employee.ContactNumber;
            this.Gender.Text = employee.Gender;
            this.MaritalStatus.Text = employee.MaritalStauts;
            this.PresentAddress.Text = employee.PresentAddress;
            this.PermanentAddress.Text = employee.PermanentAddress;
            this.Desigantion.Text = employee.Designation;
            this.Department.Text = employee.Department;
            this.Education.ItemsSource = employee.EducationModels;
            this.Experience.ItemsSource = employee.ExperienceModels;
        }

        /// <summary>
        /// Converts content to login window.
        /// </summary>
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.menuitem.Visibility = Visibility.Visible;
           mainWindow.mainContent.Content = new LoginWindow();
        }
    }
}
