using EmployeeManagementSystem.ViewModel;
using System.Windows;
using System.Windows.Controls;

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
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.IncorrectLoginEvent += LoginViewModel_IncorrectLoginEvent;
            viewModel.CorrectLoginEvent += LoginViewModel_CorrectLoginEvent;
            username.GotFocus += Username_GotFocus;
            passwordBox.GotFocus += Username_GotFocus;
            textBox.GotFocus += Username_GotFocus;
            this.DataContext = viewModel;
        }

        private void LoginViewModel_CorrectLoginEvent(object? sender, EmployeeEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.menuitem.Visibility = Visibility.Collapsed;
            mainWindow.mainContent.Content = new EmployeeLoginDetails(e.emp);

        }

        private void Username_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlock.Text = string.Empty;
        }

        private void LoginViewModel_IncorrectLoginEvent(object? sender, EventArgs e)
        {
            txtBlock.Text = "Incorrect username or password";
        }





        private void ShowPasswordCharsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Collapsed;
            textBox.Visibility = Visibility.Visible;
        }
        private void ShowPasswordCharsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Visible;
            textBox.Visibility = Visibility.Collapsed;
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((dynamic)this.DataContext).Password = passwordBox.Password;
        }


    }
}
