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
using System.Windows.Controls.Primitives;
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
    /// 

    public partial class ProjectWindow : UserControl
    {
        private string selectedProject;
        public string SelectedProject
        {
            get { return selectedProject; }
            set
            {
                SelectedProject = value;
            }
        }
      
        private GetData getData;
       

        public ProjectWindow()
        {
            InitializeComponent();
            ProjectViewModel viewModel = new ProjectViewModel();
            DataContext = viewModel;
            viewModel.EditEvent += ViewModel_EditEvent;
            getData = new GetData();
            viewModel.AddEmployeeEvent += refreshEmployeeDatagrid;


        }

        private void refreshEmployeeDatagrid(object? sender, EventArgs e)
        {
            PopUpDataGird.ItemsSource = null;
            PopUpDataGird.ItemsSource = getData.GetAssociatedEmployeesToProject((string)((DataRowView)DataGrid.SelectedItem).Row.ItemArray[0]).DefaultView;
            Autocompletebox.SelectedItem ="";

        }

      

   
        private void ViewModel_EditEvent(object? sender, EventArgs e)
        {            
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (mainWindow != null)
            {
                if (mainWindow.mainContent != null)
                {
                    ProjectModel pm = getData.GetProjectFromCode((string)((ProjectViewModel)sender).SelectedRow.Row.ItemArray[0]);
                    mainWindow.mainContent.Content = new EditProjectWindow(pm);
                }
            }
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddProject addEditProject = new AddProject();

            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (mainWindow != null)
            {
                if (mainWindow.mainContent != null)
                {
                    mainWindow.mainContent.Content = addEditProject;
                }
            }
        }

        private void OpenEmployeeMapingPopupMethod(object sender, RoutedEventArgs e)
        {
            
            MyPopup.PlacementRectangle = new Rect(new Size(
            SystemParameters.FullPrimaryScreenWidth,
            SystemParameters.FullPrimaryScreenHeight));
            MyPopup.IsOpen = true;
            string projectCode = (string)((DataRowView)((FrameworkElement)e.OriginalSource).DataContext).Row.ItemArray[0];
            ProjectNameTextBox.Text = (string)((DataRowView)((FrameworkElement)e.OriginalSource).DataContext).Row.ItemArray[1];
            PopUpDataGird.ItemsSource=getData.GetAssociatedEmployeesToProject(projectCode).DefaultView;

        }    
        
        private void ClosePopUpClick(object sender, RoutedEventArgs e) { 
            MyPopup.IsOpen=false;
        }
       
    }
}
