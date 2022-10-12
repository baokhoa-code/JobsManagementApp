﻿using System;
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

namespace JobsManagementApp.View.General
{
    /// <summary>
    /// Interaction logic for ForgotPage.xaml
    /// </summary>
    public partial class ForgotPage : Page
    {
        public ForgotPage()
        {
            InitializeComponent();
        }
        private void btn_del_email_mouse_move_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_del_email.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
        }
        private void btn_del_email_mouse_leave_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_del_email.Foreground = (Brush)bc.ConvertFrom("#FFAFAFAF");
        }
        private void btn_del_answer_mouse_move_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_del_answer.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
        }
        private void btn_del_answer_mouse_leave_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_del_answer.Foreground = (Brush)bc.ConvertFrom("#FFAFAFAF");
        }

        private void btn_del_new_pass_mouse_move_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_del_new_pass.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
        }
        private void btn_del_new_pass_mouse_leave_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_del_new_pass.Foreground = (Brush)bc.ConvertFrom("#FFAFAFAF");
        }
        private void btn_new_pass_mouse_move_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_new_pass.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
        }
        private void btn_new_pass_mouse_leave_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_new_pass.Foreground = (Brush)bc.ConvertFrom("#FFAFAFAF");
        }
        private void btn_change_mouse_move_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            btn_change.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
            btn_change.BorderBrush = (Brush)bc.ConvertFrom("#FF44EE7D");
            btn_change.Background = (Brush)bc.ConvertFrom("#FF44EE7D");
        }
        private void btn_change_mouse_leave_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            btn_change.Foreground = (Brush)bc.ConvertFrom("#DDFFFFFF");
            btn_change.BorderBrush = (Brush)bc.ConvertFrom("#FF40CC6F");
            btn_change.Background = (Brush)bc.ConvertFrom("#FF40CC6F");
        }
    }
}
