﻿using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.DialogWindow;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModel;
using System;
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

namespace EmployeeManagementSystem.UserControls
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : UserControl
    {
        private GetData getData;
        public EmployeeWindow()
        {
            InitializeComponent();
            EmployeeViewModel viewmodel = new EmployeeViewModel();
            this.DataContext = viewmodel;
            viewmodel.AddProjectEvent += refreshEmployeeDatagrid;
            getData = new GetData();
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            if (mainWindow != null)
            {
                mainWindow.mainContent.Content = new AddEmployeeWindow();
            }
        }

        private void EditEmployeeBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            if (mainWindow != null)
            {
                EmployeeModel employeeModel = getData.GetEmployeeModelFromCode((string)((System.Data.DataRowView)DataGrid.SelectedItem).Row.ItemArray[0]);
                mainWindow.mainContent.Content = new EditEmployeeWindow(employeeModel);

            }
        }

        private void OpenProjectMappingPopup(object sender, RoutedEventArgs e)
        {
            MyPopup.PlacementRectangle = new Rect(new Size(
            SystemParameters.FullPrimaryScreenWidth,
            SystemParameters.FullPrimaryScreenHeight));
            MyPopup.IsOpen = true;
            string EmployeeCode = (string)((DataRowView)((FrameworkElement)e.OriginalSource).DataContext).Row.ItemArray[0];
            EmployeeNameTextBox.Text = (string)((DataRowView)((FrameworkElement)e.OriginalSource).DataContext).Row.ItemArray[1];
            PopUpDataGird.ItemsSource = getData.GetAssociatedProjectForEmployees(EmployeeCode).DefaultView;

        }
        private void ClosePopUpClick(object sender, RoutedEventArgs e)
        {
            MyPopup.IsOpen = false;
            
        }

        private void refreshEmployeeDatagrid(object? sender, EventArgs e)
        {
            PopUpDataGird.ItemsSource = null;
            PopUpDataGird.ItemsSource = getData.GetAssociatedProjectForEmployees((string)((DataRowView)DataGrid.SelectedItem).Row.ItemArray[0]).DefaultView;
            Autocompletebox.SelectedItem = "";

        }

        private void ViewEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeDetails employee = new EmployeeDetails();
            employee.Show();
        }
    }
}
