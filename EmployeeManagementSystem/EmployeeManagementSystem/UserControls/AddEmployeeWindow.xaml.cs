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
        }

        private void ViewModel_EmployeeAddedEvent(object? sender, EventArgs e)
        {
            TabControl.SelectedIndex = 2;
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
            _showCellsEditingTemplate(row);
       
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
 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.CurrentItem);
            _showCellsEditingTemplate(row);
        }


       

     
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.CurrentItem);
            _showCellsNormalTemplate(row, true);
        }

        private void _showCellsEditingTemplate(DataGridRow row)
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

        private void _showCellsNormalTemplate(DataGridRow row, bool canCommit = false)
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

        private void ExpereinceEditbuttonClick(object sender, RoutedEventArgs e)
        {
            DataGridRow row = (DataGridRow)ExperienceDataGrid.ItemContainerGenerator.ContainerFromItem(ExperienceDataGrid.CurrentItem);
            ShowCellsEditingTemplateExperience(row);
        }

        // Cancel
        private void ExpereinceDeleteButtonClick(object sender, RoutedEventArgs e)
        {
            DataGridRow row = (DataGridRow)ExperienceDataGrid.ItemContainerGenerator.ContainerFromItem(ExperienceDataGrid.CurrentItem);
            ShowCellsNormalTemplateExperience(row);
        }

        // Commit
        private void ButtoExpereinceAddButtonClick(object sender, RoutedEventArgs e)
        {
            DataGridRow row = (DataGridRow)ExperienceDataGrid.ItemContainerGenerator.ContainerFromItem(ExperienceDataGrid.CurrentItem);
            ShowCellsNormalTemplateExperience(row, true);
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
                if (col.DisplayIndex == 1 || col.DisplayIndex == 2)
                {
                    if (canCommit == true)
                        ((DatePicker)cell.Content).GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
                    else
                        ((DatePicker)cell.Content).GetBindingExpression(DatePicker.SelectedDateProperty).UpdateTarget();
                }
                if (col.DisplayIndex != 5 && col.DisplayIndex != 1 && col.DisplayIndex!=2 && col.DisplayIndex!=3)
                {
                    if (canCommit == true)
                        ((TextBox)cell.Content).GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    else
                        ((TextBox)cell.Content).GetBindingExpression(TextBox.TextProperty).UpdateTarget();
                }
                cell.Content = c.CellTemplate.LoadContent();
            }
        }

        private void DGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            MessageBox.Show("D");
        }
    }
}
