﻿#pragma checksum "..\..\..\..\UserControls\AddEmployeeWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93D5720EC5FCB3FEEB19F4CCC0D4803E1397F428"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EmployeeManagementSystem.Converter;
using EmployeeManagementSystem.UserControls;
using EmployeeManagementSystem.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace EmployeeManagementSystem.UserControls {
    
    
    /// <summary>
    /// AddEmployeeWindow
    /// </summary>
    public partial class AddEmployeeWindow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 29 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl TabControl;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem EmployeeDetailsTabItem;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Code;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstName;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastName;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Password;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ConfirmPassword;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Department;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Designation;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker JoiningDate;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ReleaseDate;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EmployeeDetailsNextBtn;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem PersonalDetailsTabItem;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DOB;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ContactNumber;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MaritalStatus;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PresentAddress;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PermanentAddress;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PersonalDetailsNextBtn;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGrid;
        
        #line default
        #line hidden
        
        
        #line 373 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ExperienceDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EmployeeManagementSystem;V1.0.0.0;component/usercontrols/addemployeewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
            this.BackBtn.Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 3:
            this.EmployeeDetailsTabItem = ((System.Windows.Controls.TabItem)(target));
            return;
            case 4:
            this.Code = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.FirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.LastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.ConfirmPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.Department = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.Designation = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.JoiningDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 13:
            this.ReleaseDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 14:
            this.EmployeeDetailsNextBtn = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
            this.EmployeeDetailsNextBtn.Click += new System.Windows.RoutedEventHandler(this.EmployeeDetailsNextBtn_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.PersonalDetailsTabItem = ((System.Windows.Controls.TabItem)(target));
            return;
            case 16:
            this.DOB = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 17:
            this.ContactNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 18:
            this.MaritalStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 19:
            this.PresentAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 20:
            this.PermanentAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 21:
            this.PersonalDetailsNextBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 22:
            this.DGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 230 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
            this.DGrid.AddingNewItem += new System.EventHandler<System.Windows.Controls.AddingNewItemEventArgs>(this.DGrid_AddingNewItem);
            
            #line default
            #line hidden
            return;
            case 25:
            this.ExperienceDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 23:
            
            #line 308 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            break;
            case 24:
            
            #line 320 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            break;
            case 26:
            
            #line 428 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExpereinceEditbuttonClick);
            
            #line default
            #line hidden
            break;
            case 27:
            
            #line 440 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtoExpereinceAddButtonClick);
            
            #line default
            #line hidden
            break;
            case 28:
            
            #line 442 "..\..\..\..\UserControls\AddEmployeeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExpereinceDeleteButtonClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

