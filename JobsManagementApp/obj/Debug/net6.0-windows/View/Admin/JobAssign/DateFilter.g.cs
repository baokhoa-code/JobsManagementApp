﻿#pragma checksum "..\..\..\..\..\..\View\Admin\JobAssign\DateFilter.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A74101083957CA457660B67BF37FC0804B8782ED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JobsManagementApp.View.Admin.JobAssign;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace JobsManagementApp.View.Admin.JobAssign {
    
    
    /// <summary>
    /// DateFilter
    /// </summary>
    public partial class DateFilter : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\..\..\..\View\Admin\JobAssign\DateFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tab_control;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JobsManagementApp;component/view/admin/jobassign/datefilter.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\View\Admin\JobAssign\DateFilter.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 18 "..\..\..\..\..\..\View\Admin\JobAssign\DateFilter.xaml"
            ((JobsManagementApp.View.Admin.JobAssign.DateFilter)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 55 "..\..\..\..\..\..\View\Admin\JobAssign\DateFilter.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.date_range_unchecked_handler);
            
            #line default
            #line hidden
            
            #line 55 "..\..\..\..\..\..\View\Admin\JobAssign\DateFilter.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.date_range_checked_handler);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tab_control = ((System.Windows.Controls.TabControl)(target));
            return;
            case 4:
            
            #line 171 "..\..\..\..\..\..\View\Admin\JobAssign\DateFilter.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.filter_handler);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

