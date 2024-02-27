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
        private string selectedPRoje;
        public string SelectedPRoje
        {
            get { return selectedPRoje; }
            set
            {
                SelectedPRoje = value;
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
            this.SizeChanged += sizechanged;


        }

        private void refreshEmployeeDatagrid(object? sender, EventArgs e)
        {
            PopUpDataGird.ItemsSource = null;
            PopUpDataGird.ItemsSource = getData.GetAssociatedEmployeesToProject((string)((DataRowView)DataGrid.SelectedItem).Row.ItemArray[0]).DefaultView;


        }

        private void ClosePopup(object? sender, EventArgs e)
        {
          
            this.MyPopup.IsOpen = false;
        }

        private void sizechanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 1180)
            {
                this.DataGridColumnWidth.Width = 0.14 * this.ActualWidth;
         
            }
            else
            {
                this.DataGridColumnWidth.Width = 0.22 * this.ActualWidth;

            }
        }

        private void ViewModel_EditEvent(object? sender, EventArgs e)
        {            
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (mainWindow != null)
            {
                if (mainWindow.mainContent != null)
                {
                    ProjectModel pm = getData.GetProjectFromCode((string)((ProjectViewModel)sender).SelectedRow.Row.ItemArray[0]);
                    mainWindow.mainContent.Content = new EditWindow(pm);
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
