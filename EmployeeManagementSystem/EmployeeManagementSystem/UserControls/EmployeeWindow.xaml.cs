using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.DialogWindow;
using EmployeeManagementSystem.EventArg;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.ViewModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : UserControl
    {
        private GetData getData;
        public EmployeeWindow()
        {
            InitializeComponent();
            EmployeeViewModel viewModel = new EmployeeViewModel();
            this.DataContext = viewModel;
            viewModel.AddProjectEvent += RefreshEmployeeDatagrid;
            viewModel.EditEvent += EditEmployee;
            getData = new GetData();
        }

        /// <summary>
        /// Changes content to AddEmployeeWindow
        /// </summary>
        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            if (mainWindow != null)
            {
                mainWindow.mainContent.Content = new AddEmployeeWindow();
            }
        }

        /// <summary>
        /// Changes content to EditEmployeeWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">EmployeeEventAargs, contains employee which is being updated.</param>
        private void EditEmployee(object? sender, EmployeeEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            if (mainWindow != null)
            {
                mainWindow.mainContent.Content = new EditEmployeeWindow(e.emp);
            }
        }

        /// <summary>
        /// Opens Popup ,sets EmployeeNameTextBox to Name fo employee and DataGrid ItemSource.
        /// </summary>
        private void OpenProjectMappingPopup(object sender, RoutedEventArgs e)
        {
            MyPopup.PlacementRectangle = new Rect(new Size(
            SystemParameters.FullPrimaryScreenWidth,
            SystemParameters.FullPrimaryScreenHeight));
            MyPopup.IsOpen = true;
            string EmployeeCode = (string)((DataRowView)((FrameworkElement)e.OriginalSource).DataContext).Row.ItemArray[0]!;
            EmployeeNameTextBox.Text = (string)((DataRowView)((FrameworkElement)e.OriginalSource).DataContext).Row.ItemArray[1]!;
            PopUpDataGird.ItemsSource = getData.GetAssociatedProjectForEmployees(EmployeeCode).DefaultView;

        }

        /// <summary>
        /// Closes popup.
        /// </summary>
        private void ClosePopUpClick(object sender, RoutedEventArgs e)
        {
            MyPopup.IsOpen = false;
            
        }

        /// <summary>
        /// Refreshes PopUpDataGird and clears AutocompleteBox
        /// </summary>
        private void RefreshEmployeeDatagrid(object? sender, EventArgs e)
        {
            PopUpDataGird.ItemsSource = null;
            PopUpDataGird.ItemsSource = getData.GetAssociatedProjectForEmployees((string)((DataRowView)DataGrid.SelectedItem).Row.ItemArray[0]!).DefaultView;
            Autocompletebox.SelectedItem = string.Empty;

        }
    }
}
