using EmployeeManagementSystem.ViewModel;
using System.Windows.Controls;

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for SkillsWindow.xaml
    /// </summary>
    public partial class SkillWindow : UserControl
    {
        public SkillWindow()
        {
            InitializeComponent();
            SkillViewModel viewModel= new SkillViewModel();
            this.DataContext = viewModel;
        }
    }
}
