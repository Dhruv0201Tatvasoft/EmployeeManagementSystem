using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.ViewModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditProjectWindow : UserControl
    {
        private GetData getData;
        public EditProjectWindow()
        {
            InitializeComponent();
            getData = new GetData();
            EditProjectViewModel viewModel = new EditProjectViewModel();
            this.DataContext = viewModel;
            viewModel.ChangeWindowEvent += ChangeWindow;

        }

        public EditProjectWindow(ProjectModel project)
        {
            InitializeComponent();
            EditProjectViewModel viewModel = new EditProjectViewModel();
            this.DataContext = viewModel;
            getData = new GetData();
            viewModel.OldCode = project.Code!;
            viewModel.SelectedTechnologyIds = project.AssociatedTechnologies!;
            viewModel.Code = project.Code!;
            viewModel.Name = project.Name!;
            viewModel.StartingDate = project.StartingDate;
            viewModel.EndingDate = project.EndingDate;
            DataTable dt = getData.GetTechnologyData();
            ListBox.ItemsSource = dt.DefaultView;
    
                foreach (DataRowView row in ListBox.Items)
                {
                    int id = Convert.ToInt32(row.Row.ItemArray[1]); /// to get id of the technology.

                    if (project.AssociatedTechnologies!=null &&  project.AssociatedTechnologies.Contains(id)) /// selects technologies that are associated to the project
                    {
                        ListBox.SelectedItems.Add(row);

                    }
                }
            
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
        private void CancelBtnClick(object sender, RoutedEventArgs e)
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
    }
}
