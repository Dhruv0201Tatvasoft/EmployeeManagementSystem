using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditProjectWindow : UserControl
    {
        private GetData GetData;
        public EditProjectWindow()
        {
            InitializeComponent();
            EditProjectViewModel editProjectViewModel = new EditProjectViewModel();
            this.DataContext = editProjectViewModel;
           
        }

        public EditProjectWindow(ProjectModel project)
        {
            InitializeComponent();
            EditProjectViewModel editProjectViewModel = new EditProjectViewModel();
            this.DataContext = editProjectViewModel;
            GetData = new GetData();
            editProjectViewModel.OldCode = project.Code;
            editProjectViewModel.SelectedTechnologyNames = project.AssociatedTechnologies;
            editProjectViewModel.Code = project.Code;
            editProjectViewModel.Name = project.Name;
            editProjectViewModel.StartingDate = project.StartingDate;
            editProjectViewModel.EndingDate = project.EndingDate;
            DataTable dt = GetData.GetTechnologyData();
            myListBox.ItemsSource = dt.DefaultView;
            foreach(var items in project.AssociatedTechnologies)
            {
                myListBox.SelectedItems.Add(myListBox.Items[items-1]);
            }
            editProjectViewModel.ChangeWindowEvent += ChangeWindow;
            
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
