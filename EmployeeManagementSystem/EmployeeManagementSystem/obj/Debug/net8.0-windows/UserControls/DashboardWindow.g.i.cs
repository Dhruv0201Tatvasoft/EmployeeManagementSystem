﻿#pragma checksum "..\..\..\..\UserControls\DashboardWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67B076BA4E54F2618AC99590C3DFE1B158C16815"
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
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization.Charting.Primitives;
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
    /// DashboardWindow
    /// </summary>
    public partial class DashboardWindow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\UserControls\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\UserControls\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.Chart employeeChart;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\UserControls\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.Chart DesignationWiseEmployee;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\..\UserControls\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.Chart TechnologyWiseProject;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\..\..\UserControls\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.PieSeries TecnologyWiseProjectChart;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\..\..\UserControls\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.Chart SkillWiseEmployee;
        
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
            System.Uri resourceLocater = new System.Uri("/EmployeeManagementSystem;component/usercontrols/dashboardwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\DashboardWindow.xaml"
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
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.employeeChart = ((System.Windows.Controls.DataVisualization.Charting.Chart)(target));
            return;
            case 3:
            this.DesignationWiseEmployee = ((System.Windows.Controls.DataVisualization.Charting.Chart)(target));
            return;
            case 4:
            this.TechnologyWiseProject = ((System.Windows.Controls.DataVisualization.Charting.Chart)(target));
            return;
            case 5:
            this.TecnologyWiseProjectChart = ((System.Windows.Controls.DataVisualization.Charting.PieSeries)(target));
            return;
            case 6:
            this.SkillWiseEmployee = ((System.Windows.Controls.DataVisualization.Charting.Chart)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

