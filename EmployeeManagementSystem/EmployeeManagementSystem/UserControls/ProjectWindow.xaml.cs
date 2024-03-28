using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.EventArg;
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

        /// <summary>
        /// Refreshes EmployeeDataGird and sets Autocompletebox selected item to empty 
        /// </summary>
        private void RefreshEmployeeDatagrid(object? sender, EventArgs e)
        {
            PopUpDataGird.ItemsSource = null;
            PopUpDataGird.ItemsSource = getData.GetAssociatedEmployeesToProject((string)((DataRowView)DataGrid.SelectedItem).Row.ItemArray[0]!).DefaultView;
            Autocompletebox.SelectedItem =string.Empty;
        }


        /// <summary>
        /// Changes MainWindow's content to EditProjectWindow with selected project.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">ProjectEventArgs, contains selected project which is being edited.</param>
        private void ViewModel_EditEvent(object? sender, ProjectEventArgs e)
        {            
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (mainWindow != null)
            {
                if (mainWindow.mainContent != null)
                {
                    mainWindow.mainContent.Content = new EditProjectWindow(e.project);
                }
            }
        }


        /// <summary>
        /// Changes MainWindow's content to AddProject.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddProject addProject = new AddProject();

            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (mainWindow != null)
            {
                if (mainWindow.mainContent != null)
                {
                    mainWindow.mainContent.Content = addProject;
                }
            }
        }


        /// <summary>
        /// Opens popup to map employee to project, sets ProjectNameTextBox with selected project's name and sets PopUpDataGird's item source.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenEmployeeMapingPopupMethod(object sender, RoutedEventArgs e)
        {
            MyPopup.IsOpen = true;
            string projectCode = (string)((DataRowView)((FrameworkElement)e.OriginalSource).DataContext).Row.ItemArray[0]!;
            ProjectNameTextBox.Text = (string)((DataRowView)((FrameworkElement)e.OriginalSource).DataContext).Row.ItemArray[1]!;
            PopUpDataGird.ItemsSource=getData.GetAssociatedEmployeesToProject(projectCode).DefaultView;

        }    
        
        /// <summary>
        /// Closes Popup.
        /// </summary>
        private void ClosePopUpClick(object sender, RoutedEventArgs e) { 
            MyPopup.IsOpen=false;
        }
       
    }
}
