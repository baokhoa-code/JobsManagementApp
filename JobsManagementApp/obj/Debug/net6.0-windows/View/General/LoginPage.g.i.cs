﻿#pragma checksum "..\..\..\..\..\View\General\LoginPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E13E25F244F5314A3907CD16014827E7CD727B67"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JobsManagementApp.View.General;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
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


namespace JobsManagementApp.View.General {
    
    
    /// <summary>
    /// LoginPage
    /// </summary>
    public partial class LoginPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal JobsManagementApp.View.General.LoginPage loginpage;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx_role;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon account_icon;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_email;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_del_email;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon icon_del_email;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passb_password;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_password;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_password;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon icon_eye;
        
        #line default
        #line hidden
        
        
        #line 247 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_del_pass;
        
        #line default
        #line hidden
        
        
        #line 259 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon icon_del_pass;
        
        #line default
        #line hidden
        
        
        #line 280 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Error;
        
        #line default
        #line hidden
        
        
        #line 294 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button forgot_btn;
        
        #line default
        #line hidden
        
        
        #line 311 "..\..\..\..\..\View\General\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loginbtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JobsManagementApp;component/view/general/loginpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\General\LoginPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.loginpage = ((JobsManagementApp.View.General.LoginPage)(target));
            
            #line 14 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.loginpage.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.mainPage_PreviewKeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbx_role = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.account_icon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 4:
            this.txb_email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btn_del_email = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.btn_del_email.MouseMove += new System.Windows.Input.MouseEventHandler(this.btn_del_email_mouse_move_handle);
            
            #line default
            #line hidden
            
            #line 130 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.btn_del_email.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btn_del_email_mouse_leave_handle);
            
            #line default
            #line hidden
            
            #line 132 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.btn_del_email.Click += new System.Windows.RoutedEventHandler(this.del_email_click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.icon_del_email = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 7:
            this.passb_password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.txb_password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btn_password = ((System.Windows.Controls.Button)(target));
            
            #line 211 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.btn_password.MouseMove += new System.Windows.Input.MouseEventHandler(this.btn_password_mouse_move_handle);
            
            #line default
            #line hidden
            
            #line 212 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.btn_password.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btn_password_mouse_leave_handle);
            
            #line default
            #line hidden
            
            #line 214 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.btn_password.Click += new System.Windows.RoutedEventHandler(this.btn_password_click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.icon_eye = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 11:
            this.btn_del_pass = ((System.Windows.Controls.Button)(target));
            
            #line 245 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.btn_del_pass.MouseMove += new System.Windows.Input.MouseEventHandler(this.btn_del_pass_mouse_move_handle);
            
            #line default
            #line hidden
            
            #line 246 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.btn_del_pass.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btn_del_pass_mouse_leave_handle);
            
            #line default
            #line hidden
            
            #line 248 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.btn_del_pass.Click += new System.Windows.RoutedEventHandler(this.del_pass_click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.icon_del_pass = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 13:
            this.Error = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.forgot_btn = ((System.Windows.Controls.Button)(target));
            
            #line 295 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.forgot_btn.MouseMove += new System.Windows.Input.MouseEventHandler(this.forgot_mouse_move_handle);
            
            #line default
            #line hidden
            
            #line 296 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.forgot_btn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.forgot_mouse_leave_handle);
            
            #line default
            #line hidden
            return;
            case 15:
            this.loginbtn = ((System.Windows.Controls.Button)(target));
            
            #line 325 "..\..\..\..\..\View\General\LoginPage.xaml"
            this.loginbtn.Click += new System.Windows.RoutedEventHandler(this.loginbtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

