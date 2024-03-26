using EmployeeManagementSystem.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for AddEditProject.xaml
    /// </summary>
    public partial class AddProject : UserControl
    {
        public AddProject()
        {
            InitializeComponent();
            AddProjectViewModel viewModel = new AddProjectViewModel();
            DataContext = viewModel;
            viewModel.ChangeWindowEvent += ChangeWindow;
        }

        /// <summary>
        /// Changes MainWindow's content to projectWindow, called after saving project
        /// </summary>
        public void ChangeWindow(object? sender, EventArgs e)
        {
            ProjectWindow projectWindow = new ProjectWindow();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            
            if (mainWindow != null)
            {
                if (mainWindow.mainContent != null)
                {
                    mainWindow.mainContent.Content = projectWindow;
                }
            }

        }

        /// <summary>
        /// Changes MainWindow's content to projectWindow, called after clicking cancel button.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProjectWindow projectWindow = new ProjectWindow();
            MainWindow mainWindow = (MainWindow) Window.GetWindow(this);

            if (mainWindow != null)
            {
                if (mainWindow.mainContent != null)
                {
                    mainWindow.mainContent.Content = projectWindow;
                }
            }

        }
    }
}
