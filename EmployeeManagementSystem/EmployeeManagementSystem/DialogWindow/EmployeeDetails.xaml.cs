using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        public EmployeeDetails(Models.EmployeeModel employee)
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
