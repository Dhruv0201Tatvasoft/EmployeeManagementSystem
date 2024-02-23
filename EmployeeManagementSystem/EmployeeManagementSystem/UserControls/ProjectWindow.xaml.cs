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

        public event EventHandler PopupOpenEvent;
        public void OnPopupOpenEvent(EventArgs e)
        {
            PopupOpenEvent?.Invoke(this, e);
        }
        private GetData getData;
       

        public ProjectWindow()
        {
            InitializeComponent();
            ProjectViewModel viewModel = new ProjectViewModel();
            DataContext = viewModel;
            viewModel.EditEvent += ViewModel_EditEvent;
            getData = new GetData();
            this.SizeChanged += sizechanged;


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
                if (mainWindow.ProjectTab != null)
                {
                    ProjectModel pm = getData.GetProjectFromCode((string)((ProjectViewModel)sender).SelectedRow.Row.ItemArray[0]);
                    mainWindow.ProjectTab.Content = new EditWindow(pm) ;
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

        private void OpenEmployeeMapingPopupMethod(object sender, RoutedEventArgs e)
        {
            
            MyPopup.PlacementRectangle = new Rect(new Size(
            SystemParameters.FullPrimaryScreenWidth,
            SystemParameters.FullPrimaryScreenHeight));
            MyPopup.IsOpen = true;
            string projectCode = (string)((DataRowView)((FrameworkElement)e.OriginalSource).DataContext).Row.ItemArray[0];
            ProjectViewModel pw = new ProjectViewModel(this,projectCode);
            this.DataContext = pw;
            OnPopupOpenEvent(EventArgs.Empty);

        }    
        
        private void ClosePopUpClick(object sender, RoutedEventArgs e) { 
            MyPopup.IsOpen=false;
        }
       
    }
}
