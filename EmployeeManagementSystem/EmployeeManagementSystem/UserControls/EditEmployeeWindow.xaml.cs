using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : UserControl
    {
        public EditEmployeeWindow()
        {
            InitializeComponent();
            EditEmployeeViewModel viewModel = new EditEmployeeViewModel();
            this.DataContext = viewModel;
            viewModel.AddFirstEducationRowEvent += AddFirstEducationRow;
            viewModel.AddFirstExperienceRowEvent += AddFirstExperienceRow;
            viewModel.EmployeeUpdatedEvent += EmployeeUpdated;
            viewModel.AddEducationRowEvent += AddEducationRow;
            viewModel.EditEducationRowEvent += EditEducationRow;
            viewModel.AddExperienceRowEvent += AddExperienceRow;
            viewModel.EditExperienceRowEvent += EditExperienceRow;
        }


        public EditEmployeeWindow(EmployeeModel employeeModel)
        {
            InitializeComponent();
            EditEmployeeViewModel viewModel = new EditEmployeeViewModel(employeeModel);
            this.DataContext = viewModel;
            viewModel.AddFirstEducationRowEvent += AddFirstEducationRow;
            viewModel.AddFirstExperienceRowEvent += AddFirstExperienceRow;
            viewModel.EmployeeUpdatedEvent += EmployeeUpdated;
            viewModel.AddEducationRowEvent += AddEducationRow;
            viewModel.EditEducationRowEvent += EditEducationRow;
            viewModel.AddExperienceRowEvent += AddExperienceRow;
            viewModel.EditExperienceRowEvent += EditExperienceRow;
        }
        /// <summary>
        /// Method called When user starts to edit Experience Row and calls ShowCellsEditingTemplateExperience with selected row .
        /// </summary>
        private void EditExperienceRow(object? sender, EventArgs e)
        {
            DataGridRow row = (DataGridRow)ExperienceDataGrid.ItemContainerGenerator.ContainerFromItem(ExperienceDataGrid.CurrentItem);
            ShowCellsEditingTemplateExperience(row);
        }

        /// <summary>
        /// Method called When user adds new Experience Row and calls ShowCellsNormalTemplateExperience with selected row .
        /// </summary>
        private void AddExperienceRow(object? sender, EventArgs e)
        {
            DataGridRow row = (DataGridRow)ExperienceDataGrid.ItemContainerGenerator.ContainerFromItem(ExperienceDataGrid.CurrentItem);
            ShowCellsNormalTemplateExperience(row, true);
        }

        /// <summary>
        /// Method called When user starts to edit Education Row and calls ShowCellsEditingTemplateExperience with selected row .
        /// </summary>
        private void EditEducationRow(object? sender, EventArgs e)
        {
            DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.CurrentItem);
            ShowCellsEditingTemplateEducation(row);
        }


        /// <summary>
        /// Method called When user adds new Education Row and calls ShowCellsNormalTemplateExperience with selected row .
        /// </summary>
        private void AddEducationRow(object? sender, EventArgs e)
        {
            DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.CurrentItem);
            ShowCellsNormalTemplateEducation(row, true);
        }


        /// <summary>
        /// Method is called whenever first row is added to Experience List and this method calls ShowCellsEditingTemplateExperience with selectedRow.
        /// </summary>
        private void AddFirstExperienceRow(object? sender, EventArgs e)
        {
            ExperienceDataGrid.SelectedItem = ExperienceDataGrid.Items[ExperienceDataGrid.Items.Count - 1];
            ExperienceDataGrid.UpdateLayout();
            DataGridRow row = (DataGridRow)ExperienceDataGrid.ItemContainerGenerator.ContainerFromItem(ExperienceDataGrid.SelectedItem);
            ShowCellsEditingTemplateExperience(row);
        }

        /// <summary>
        /// set selected tab to Education details tab, disables first two tabs.
        /// </summary>
        private void EmployeeUpdated(object? sender, EventArgs e)
        {
            TabControl.SelectedIndex = 2;
            EmployeeDetailsTabItem.IsEnabled = false;
            PersonalDetailsTabItem.IsEnabled = false;
        }

        /// <summary>
        /// Method is called whenever first row is added to Experience List and this method calls ShowCellsEditingTemplateExperience with selectedRow.
        /// </summary>
        private void AddFirstEducationRow(object? sender, EventArgs e)
        {
            DGrid.SelectedItem = DGrid.Items[DGrid.Items.Count - 1];
            DGrid.UpdateLayout();
            DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.SelectedItem);
            ShowCellsEditingTemplateEducation(row);

        }

        /// <summary>
        /// Method is called when first tab's next button is clicked and it sets current tab to second tab (i.e. tab with index 1)
        /// </summary
        private void EmployeeDetailsNextBtn_Click(object sender, EventArgs e)
        {
            TabControl.SelectedIndex = 1;
        }


        /// <summary>
        /// Converts cells of Education DataGrid from Normal template to editing template.
        /// </summary>
        /// <param name="row">Row who is being converted to editing template from normal template.</param>
        private void ShowCellsEditingTemplateEducation(DataGridRow row)
        {
            foreach (DataGridColumn col in DGrid.Columns)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                while (parent.GetType().Name != "DataGridCell")
                    parent = VisualTreeHelper.GetParent(parent);

                DataGridCell cell = ((DataGridCell)parent);
                DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                if (c.CellEditingTemplate != null)
                    cell.Content = ((DataGridTemplateColumn)col).CellEditingTemplate.LoadContent();
            }
        }


        /// <summary>
        ///  Converts cells of Education DataGrid from editing template to normal template.
        /// </summary>
        /// <param name="row">row which is being converted from editing template to normal template</param>
        /// <param name="canCommit">To check if Changes can commit</param>
        private void ShowCellsNormalTemplateEducation(DataGridRow row, bool canCommit = false)
        {
            foreach (DataGridColumn col in DGrid.Columns)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                while (parent.GetType().Name != "DataGridCell")
                    parent = VisualTreeHelper.GetParent(parent);

                DataGridCell cell = ((DataGridCell)parent);
                DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                cell.Content = c.CellTemplate.LoadContent();
            }
        }


        /// <summary>
        /// Converts cells of Experience DataGrid from Normal template to editing template.
        /// </summary>
        /// <param name="row">Row who is being converted to editing template from normal template.</param>
        private void ShowCellsEditingTemplateExperience(DataGridRow row)
        {
            foreach (DataGridColumn col in ExperienceDataGrid.Columns)
            {
                if (col.DisplayIndex == 3) continue;/// row with index 3 is read only row
                DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                while (parent.GetType().Name != "DataGridCell")
                    parent = VisualTreeHelper.GetParent(parent);

                DataGridCell cell = ((DataGridCell)parent);
                DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                if (c.CellEditingTemplate != null)
                    cell.Content = ((DataGridTemplateColumn)col).CellEditingTemplate.LoadContent();
            }
        }

        /// <summary>
        ///  Converts cells of Experience DataGrid from editing template to normal template.
        /// </summary>
        /// <param name="row">row which is being converted from editing template to normal template</param>
        /// <param name="canCommit">To check if Changes can commit</param>
        private void ShowCellsNormalTemplateExperience(DataGridRow row, bool canCommit = false)
        {
            foreach (DataGridColumn col in ExperienceDataGrid.Columns)
            {
                if (col.DisplayIndex == 3) continue;/// row with index 3 is read only row
                DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                while (parent.GetType().Name != "DataGridCell")
                    parent = VisualTreeHelper.GetParent(parent);

                DataGridCell cell = ((DataGridCell)parent);
                DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                cell.Content = c.CellTemplate.LoadContent();
            }
        }

        /// <summary>
        /// Method is called whenever back button is clicked this sets content to EmployeeWindow.
        /// </summary>
        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.mainContent.Content = new EmployeeWindow();
        }
    }
}
