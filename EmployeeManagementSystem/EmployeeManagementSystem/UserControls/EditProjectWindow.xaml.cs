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
        private GetData GetData;
        public EditProjectWindow()
        {
            InitializeComponent();
            EditProjectViewModel viewModel = new EditProjectViewModel();
            this.DataContext = viewModel;
           
        }

        public EditProjectWindow(ProjectModel project)
        {
            InitializeComponent();
            EditProjectViewModel viewModel = new EditProjectViewModel();
            this.DataContext = viewModel;
            GetData = new GetData();
            viewModel.OldCode = project.Code;
            viewModel.SelectedTechnologyIds = project.AssociatedTechnologies;
            viewModel.Code = project.Code;
            viewModel.Name = project.Name;
            viewModel.StartingDate = project.StartingDate;
            viewModel.EndingDate = project.EndingDate;
            DataTable dt = GetData.GetTechnologyData();
            myListBox.ItemsSource = dt.DefaultView;
    
                foreach (DataRowView row in myListBox.Items)
                {
                    int id = Convert.ToInt32(row.Row.ItemArray[1]);

                    if (project.AssociatedTechnologies.Contains(id))
                    {
                        myListBox.SelectedItems.Add(row);

                    }
                }
            
            viewModel.ChangeWindowEvent += ChangeWindow;
            
        }
     
        public void ChangeWindow(object sender, EventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
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
