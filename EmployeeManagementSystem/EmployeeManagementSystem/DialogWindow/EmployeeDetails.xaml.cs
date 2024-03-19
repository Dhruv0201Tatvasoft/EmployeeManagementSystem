using EmployeeManagementSystem.Model;
using System.Windows;

namespace EmployeeManagementSystem.DialogWindow
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EmployeeDetails : Window
    {
        public EmployeeDetails()
        {
            InitializeComponent();
        }
        public EmployeeDetails(EmployeeModel employee)
        {
            InitializeComponent();
            Code.Text = employee.Code;
            Name.Text = employee.FirstName + " " + employee.LastName;
            Email.Text = employee.Email;
            JoiningDate.Text = employee.JoiningDate.ToString("dd-MM-yyyy");
            Department.Text = employee.Department;
            Designation.Text = employee.Designation;
            Experience.ItemsSource = employee.ExperienceModels;
        }
    }
}
