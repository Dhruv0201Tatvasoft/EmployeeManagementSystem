using EmployeeManagementSystem.ViewModel;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
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
using Xceed.Wpf.Toolkit.Primitives;

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : UserControl
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
            AddEmployeeViewModel viewModel = new AddEmployeeViewModel();
            this.DataContext =viewModel;
            viewModel.AddEducationButtonClickedEvent += ViewModel_AddButtonClickedEvent;
            viewModel.AddExprienceButtonClickedEvent += ViewModel_AddExprienceButtonClickedEvent;
            viewModel.EmployeeAddedEvent += ViewModel_EmployeeAddedEvent;
            viewModel.AddEducationRowEvent += ViewModel_AddEducationRowEvent;
            viewModel.EditEducationRowEvent += ViewModel_EditEducationRowEvent;
            viewModel.AddExperienceRowEvent += ViewModel_AddExperienceRowEvent;
            viewModel.EditExprienceRowEvent += ViewModel_EditExprienceRowEvent;
        }

        private void ViewModel_EditExprienceRowEvent(object? sender, EventArgs e)
        {
            DataGridRow row = (DataGridRow)ExperienceDataGrid.ItemContainerGenerator.ContainerFromItem(ExperienceDataGrid.CurrentItem);
            ShowCellsEditingTemplateExperience(row);
        }

        private void ViewModel_AddExperienceRowEvent(object? sender, EventArgs e)
        {
            DataGridRow row = (DataGridRow)ExperienceDataGrid.ItemContainerGenerator.ContainerFromItem(ExperienceDataGrid.CurrentItem);
            ShowCellsNormalTemplateExperience(row, true);
        }

        private void ViewModel_EditEducationRowEvent(object? sender, EventArgs e)
        {
            DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.CurrentItem);
            ShowCellsEditingTemplate(row);
        }

        private void ViewModel_AddEducationRowEvent(object? sender, EventArgs e)
        {
            DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.CurrentItem);
            ShowCellsNormalTemplate(row, true);
        }

        private void ViewModel_EmployeeAddedEvent(object? sender, EventArgs e)
        {
            TabControl.SelectedIndex = 2;
            EducationDetailsTabItem.IsEnabled = true;
            ExperienceDetailsTabItem.IsEnabled = true;
            EmployeeDetailsTabItem.IsEnabled = false;
            PersonalDetailsTabItem.IsEnabled = false;
        }

        private void ViewModel_AddExprienceButtonClickedEvent(object? sender, EventArgs e)
        {
            ExperienceDataGrid.SelectedItem = ExperienceDataGrid.Items[ExperienceDataGrid.Items.Count - 1];
            ExperienceDataGrid.UpdateLayout();
            DataGridRow row = (DataGridRow)ExperienceDataGrid.ItemContainerGenerator.ContainerFromItem(ExperienceDataGrid.SelectedItem);
            ShowCellsEditingTemplateExperience(row);
        }

        private void ViewModel_AddButtonClickedEvent(object? sender, EventArgs e)
        {
            DGrid.SelectedItem = DGrid.Items[DGrid.Items.Count-1];
            DGrid.UpdateLayout();
            DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.SelectedItem);
            ShowCellsEditingTemplate(row);
       
        }

        private void EmployeeDetailsNextBtn_Click(object sender, EventArgs e)
        {
            
            TabControl.SelectedIndex = 1;

        }

     
   
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.mainContent.Content = new EmployeeWindow();
        }
        private void ShowCellsEditingTemplate(DataGridRow row)
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

        private void ShowCellsNormalTemplate(DataGridRow row, bool canCommit = false)
        {
            foreach (DataGridColumn col in DGrid.Columns)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                while (parent.GetType().Name != "DataGridCell")
                    parent = VisualTreeHelper.GetParent(parent);

                DataGridCell cell = ((DataGridCell)parent);
                DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                if (col.DisplayIndex != 6)
                {
                    if (canCommit == true)
                        ((TextBox)cell.Content).GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    else
                        ((TextBox)cell.Content).GetBindingExpression(TextBox.TextProperty).UpdateTarget();
                }
                cell.Content = c.CellTemplate.LoadContent();
            }
        }

        private void ShowCellsEditingTemplateExperience(DataGridRow row)
        {
            foreach (DataGridColumn col in ExperienceDataGrid.Columns)
            {
                if (col.DisplayIndex==3) continue;
                DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                while (parent.GetType().Name != "DataGridCell")
                    parent = VisualTreeHelper.GetParent(parent);

                DataGridCell cell = ((DataGridCell)parent);
                DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                if (c.CellEditingTemplate != null)
                    cell.Content = ((DataGridTemplateColumn)col).CellEditingTemplate.LoadContent();
            }
        }

        private void ShowCellsNormalTemplateExperience(DataGridRow row, bool canCommit = false)
        {
            foreach (DataGridColumn col in ExperienceDataGrid.Columns)
            {
                if (col.DisplayIndex == 3) continue;
                DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                while (parent.GetType().Name != "DataGridCell")
                    parent = VisualTreeHelper.GetParent(parent);

                DataGridCell cell = ((DataGridCell)parent);
                DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                if(col.DisplayIndex == 4)
                {
                    if (canCommit == true)
                        ((ComboBox)cell.Content).GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
                    else
                        ((ComboBox)cell.Content).GetBindingExpression(ComboBox.SelectedItemProperty).UpdateTarget();
                }
                if (col.DisplayIndex == 1 || col.DisplayIndex == 2)
                {
                    if (canCommit == true)
                        ((DatePicker)cell.Content).GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
                    else
                        ((DatePicker)cell.Content).GetBindingExpression(DatePicker.SelectedDateProperty).UpdateTarget();
                }
                if (col.DisplayIndex != 5 && col.DisplayIndex != 1 && col.DisplayIndex!=2 && col.DisplayIndex!=3 && col.DisplayIndex!=4)
                {
                    if (canCommit == true)
                        ((TextBox)cell.Content).GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    else
                        ((TextBox)cell.Content).GetBindingExpression(TextBox.TextProperty).UpdateTarget();
                }
                cell.Content = c.CellTemplate.LoadContent();
            }
        }

       
    }
}
