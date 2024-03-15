using EmployeeManagementSystem.ViewModel;
using System.Windows.Controls;

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for TechnologyWindow.xaml
    /// </summary>
    public partial class TechnologyWindow : UserControl
    {
        public TechnologyWindow()
        {
            InitializeComponent();
            TechnologyViewModel viewModel = new TechnologyViewModel();
            this.DataContext = viewModel;
        }
    }
}
