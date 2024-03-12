using EmployeeManagementSystem.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginViewModel loginViewModel = new LoginViewModel();
            this.DataContext = loginViewModel;
        }

        private void PART_ShowHideButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Visibility == Visibility.Collapsed)
            {
                passwordBox.Visibility = System.Windows.Visibility.Collapsed;
                textBox.Visibility = System.Windows.Visibility.Visible;

                textBox.Focus();
            }
            else
            {
                // Show password box and hide plain text box
                passwordBox.Visibility = System.Windows.Visibility.Visible;
                textBox.Visibility = System.Windows.Visibility.Collapsed;

                passwordBox.Focus();
            }
        }
    }
}
