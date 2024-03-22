using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.ViewModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    /// 

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
            viewModel.AddEmployeeEvent += RefreshEmployeeDatagrid;
        }

        private void RefreshEmployeeDatagrid(object? sender, EventArgs e)
        {
            PopUpDataGird.ItemsSource = null;
            PopUpDataGird.ItemsSource = getData.GetAssociatedEmployeesToProject((string)((DataRowView)DataGrid.SelectedItem).Row.ItemArray[0]!).DefaultView;
            Autocompletebox.SelectedItem ="";
        }

      

   
        private void ViewModel_EditEvent(object? sender, EventArgs e)
        {            
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (mainWindow != null)
            {
                if (mainWindow.mainContent != null)
                {
                    ProjectModel pm = getData.GetProjectFromCode((string)((ProjectViewModel)sender!).SelectedRow?.Row.ItemArray[0]!);
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
            string projectCode = (string)((DataRowView)((FrameworkElement)e.OriginalSource).DataContext).Row.ItemArray[0]!;
            ProjectNameTextBox.Text = (string)((DataRowView)((FrameworkElement)e.OriginalSource).DataContext).Row.ItemArray[1]!;
            PopUpDataGird.ItemsSource=getData.GetAssociatedEmployeesToProject(projectCode).DefaultView;

        }    
        
        private void ClosePopUpClick(object sender, RoutedEventArgs e) { 
            MyPopup.IsOpen=false;
        }
       
    }
}
