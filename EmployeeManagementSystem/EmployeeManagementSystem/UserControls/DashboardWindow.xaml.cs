using EmployeeManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;
using EmployeeManagementSystem.Database;
using System.Data;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using System.Windows.Controls.DataVisualization;

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

