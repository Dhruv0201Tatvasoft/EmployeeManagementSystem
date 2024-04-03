using EmployeeManagementSystem.EventArg;
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

        /// <summary>
        /// On correct login changes MainWindow content to EmployeeLoginDetails and hides menuitem.
        /// </summary>
        private void LoginViewModel_CorrectLoginEvent(object? sender, EmployeeEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.menuitem.Visibility = Visibility.Collapsed;
            mainWindow.mainContent.Content = new EmployeeLoginDetails(e.emp);

        }

        /// <summary>
        /// Whenever TextBox gets focused clears txtBlock to String.Empty which is used to show Incorrect Login error.
        /// </summary>
        private void Username_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlock.Text = string.Empty;
        }


        /// <summary>
        /// Whenever the user enters incorrect credentials it set txtBlock content to "Incorrect username or password" warning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginViewModel_IncorrectLoginEvent(object? sender, EventArgs e)
        {
            txtBlock.Text = "Incorrect username or password";
        }




        /// <summary>
        /// Makes PasswordBox invisible and normal Textbox visible
        /// </summary>
        private void ShowPasswordCharsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Collapsed;
            textBox.Visibility = Visibility.Visible;
            
        }

        /// <summary>
        /// Makes PasswordBox visible and normal Textbox invisible
        /// </summary>
        private void ShowPasswordCharsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Visible;
            textBox.Visibility = Visibility.Collapsed;
            passwordBox.Password = textBox.Text;
        }

        /// <summary>
        /// sets Password stirng in DataContext to the password entered by user
        /// </summary>
        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((dynamic)this.DataContext).Password = passwordBox.Password;
           
        }

     
    }
}
