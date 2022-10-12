using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void btn_password_click(object sender, RoutedEventArgs e)
        {
            if (icon_eye.Kind == MaterialDesignThemes.Wpf.PackIconKind.Eye)
            {
                txb_password.Visibility = Visibility.Visible;
                passb_password.Visibility = Visibility.Hidden;
                txb_password.Text = passb_password.Password;
                icon_eye.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOff;
                return;
            }
            else if (icon_eye.Kind == MaterialDesignThemes.Wpf.PackIconKind.EyeOff)
            {
                passb_password.Visibility = Visibility.Visible;
                txb_password.Visibility = Visibility.Hidden;
                passb_password.Password = txb_password.Text;
                icon_eye.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye;
                return;
            }
        }
        private void del_email_click(object sender, RoutedEventArgs e)
        {
            txb_email.Text = "";
        }

        private void del_pass_click(object sender, RoutedEventArgs e)
        {
            txb_password.Text = "";
            passb_password.Password = "";
        }

        public class NotEmptyValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                return string.IsNullOrWhiteSpace((value ?? "").ToString())
                    ? new ValidationResult(false, "Field is required.")
                    : ValidationResult.ValidResult;
            }
        }

        private void forgot_mouse_move_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            forgot_btn.Foreground = (Brush)bc.ConvertFrom("#FFF36565");
        }

        private void forgot_mouse_leave_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            forgot_btn.Foreground = (Brush)bc.ConvertFrom("#FFAAAAAA");
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

        private void btn_del_pass_mouse_move_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_del_pass.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
        }

        private void btn_del_pass_mouse_leave_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_del_pass.Foreground = (Brush)bc.ConvertFrom("#FFAFAFAF");
        }

        private void btn_password_mouse_move_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_eye.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
        }

        private void btn_password_mouse_leave_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            icon_eye.Foreground = (Brush)bc.ConvertFrom("#FFAFAFAF");
        }

        private void btn_login_mouse_move_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            btn_login.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
            btn_login.BorderBrush = (Brush)bc.ConvertFrom("#FF44EE7D");
            btn_login.Background = (Brush)bc.ConvertFrom("#FF44EE7D");
        }

        private void btn_login_mouse_leave_handle(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            btn_login.Foreground = (Brush)bc.ConvertFrom("#DDFFFFFF");
            btn_login.BorderBrush = (Brush)bc.ConvertFrom("#FF40CC6F");
            btn_login.Background = (Brush)bc.ConvertFrom("#FF40CC6F");
        }
    }


}
