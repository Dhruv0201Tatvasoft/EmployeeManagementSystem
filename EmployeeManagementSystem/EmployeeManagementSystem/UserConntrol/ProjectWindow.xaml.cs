using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EmployeeManagementSystem.UserConntrol
{
    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : UserControl
    {
        public class Project
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
        public ObservableCollection<Project> FakeData { get; set; }
        public ProjectWindow()
        {
            InitializeComponent();
            InitializeData();
            DataGrid.ItemsSource = FakeData;
        }
        private void InitializeData()
        {
            FakeData = new ObservableCollection<Project>
            {
                new Project { Code = "001", Name = "Item 1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7) },
                new Project { Code = "002", Name = "Item 2", StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(14) },
                new Project { Code = "003", Name = "Item 3", StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(21) },
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEditProject addEditProject = new AddEditProject();

            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if(mainWindow != null)
            {
                if(mainWindow.ProjectTab != null)
                {
                    mainWindow.ProjectTab.Content = addEditProject;
                }
            }
        }
    }
}
