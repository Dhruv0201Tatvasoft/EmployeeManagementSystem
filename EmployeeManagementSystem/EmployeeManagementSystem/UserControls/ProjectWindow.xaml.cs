using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : UserControl
    {

        private GetData getData;
        public ProjectWindow()
        {
            InitializeComponent();
            ProjectViewModel viewModel = new ProjectViewModel();
            DataContext = viewModel;
            viewModel.EditEvent += ViewModel_EditEvent;
            getData = new GetData();
        }

        private void ViewModel_EditEvent(object? sender, EventArgs e)
        {
            AddEditProject addEditProject = new AddEditProject();
            
            
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (mainWindow != null)
            {
                if (mainWindow.ProjectTab != null)
                {
                    
                    mainWindow.ProjectTab.Content = addEditProject;
                    ProjectModel pm = getData.GetProjectFromCode((string)((ProjectViewModel)sender).SelectedRow.Row.ItemArray[0]);
                    addEditProject.setText(pm);
                    List<int> selected = new List<int> { 0, 2, 4 };
                  
                }
            }
        }

     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEditProject addEditProject = new AddEditProject();

            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (mainWindow != null)
            {
                if (mainWindow.ProjectTab != null)
                {
                    mainWindow.ProjectTab.Content = addEditProject;
                }
            }
        }
    }
}
