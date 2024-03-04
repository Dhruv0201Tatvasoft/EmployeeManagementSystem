using EmployeeManagementSystem.ViewModel;
using System;
using System.CodeDom;
using System.Collections.Generic;
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
            
        }

        private void EmployeeDetailsNextBtn_Click(object sender, RoutedEventArgs e)
        {
            
            TabControl.SelectedIndex = 1;

        }

        private void PersonalDetailsNextBtn_Click(object sender, RoutedEventArgs e)
        {
            TabControl.SelectedIndex =2;
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

        // Cancel
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.CurrentItem);
            _showCellsNormalTemplate(row);
        }

        // Commit
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
                if(c.CellEditingTemplate !=null)
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
            _showCellsEditingTemplate(row);
        }

        // Cancel
        private void ExpereinceDeleteButtonClick(object sender, RoutedEventArgs e)
        {
            DataGridRow row = (DataGridRow)ExperienceDataGrid.ItemContainerGenerator.ContainerFromItem(ExperienceDataGrid.CurrentItem);
            _showCellsNormalTemplateExperience(row);
        }

        // Commit
        private void ButtoExpereinceAddButtonClick(object sender, RoutedEventArgs e)
        {
            DataGridRow row = (DataGridRow)ExperienceDataGrid.ItemContainerGenerator.ContainerFromItem(ExperienceDataGrid.CurrentItem);
            _showCellsNormalTemplateExperience(row, true);
        }

        private void _showCellsNormalTemplateExperience(DataGridRow row)
        {
            foreach (DataGridColumn col in ExperienceDataGrid.Columns)
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

        private void _showCellsNormalTemplateExperience(DataGridRow row, bool canCommit = false)
        {
            foreach (DataGridColumn col in ExperienceDataGrid.Columns)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                while (parent.GetType().Name != "DataGridCell")
                    parent = VisualTreeHelper.GetParent(parent);

                DataGridCell cell = ((DataGridCell)parent);
                DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                if (col.DisplayIndex != 5)
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
