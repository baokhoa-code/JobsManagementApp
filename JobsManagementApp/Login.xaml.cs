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
using System.Windows.Shapes;

namespace JobsManagementApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btn_login.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_login_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
