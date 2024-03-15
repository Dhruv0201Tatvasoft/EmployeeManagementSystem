using EmployeeManagementSystem.ViewModel;
using System.Windows.Controls;

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : UserControl
    {
        public DashboardWindow()
        {
            InitializeComponent();
            DashboardViewModel viewModel = new DashboardViewModel();
            this.DataContext = viewModel;
        }

    }
}

