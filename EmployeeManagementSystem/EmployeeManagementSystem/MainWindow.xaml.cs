using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.UserControls;
using EmployeeManagementSystem.ViewModel;
using System.Collections.ObjectModel;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            mainContent.Content =new TextBlock() { Text = "Dashboard Content" };
            selectedMenuItem = HeaderMenuItem;
            selectedMenuItem.Background = (SolidColorBrush)FindResource("PressedBackGroundColor");
        }




        private MenuItem selectedMenuItem;

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;


            if (selectedMenuItem != null)
            {

                selectedMenuItem.ClearValue(Control.BackgroundProperty);
            }

            switch (menuItem.Header.ToString())
            {
                case "Dashboard":
                    mainContent.Content = new TextBlock() { Text = "Dashboard Content" };
                    selectedMenuItem = menuItem;
                    break;

                case "Project":
                    mainContent.Content = new ProjectWindow();
                    selectedMenuItem = menuItem;
                    break;

                case "Employee":
                    mainContent.Content = new EmployeeWindow();
                    selectedMenuItem = menuItem;
                    break;
                case "Technology":
                    mainContent.Content = new TechnologyWindow();
                    selectedMenuItem = Master;
                    break;
                case "Skill":
                    mainContent.Content = new SkillWindow();
                    selectedMenuItem = Master;
                    break;


            }

            selectedMenuItem.Background = (SolidColorBrush)FindResource("PressedBackGroundColor");
        }

        private void InfoButtonClicked(object sender, RoutedEventArgs e)
        {
            this.MyPopup.IsOpen = true;
        }
        private void ClosePopUpClick(object sender, RoutedEventArgs e)
        {
            MyPopup.IsOpen = false;
        }
    }
}