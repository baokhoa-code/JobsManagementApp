using System;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JobsManagementApp.View.General
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void button_close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_minimize_click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void img_Logo_MouseMove(object sender, MouseEventArgs e)
        {
            bd_Logo.Effect = new DropShadowEffect()
            {
                Color = Colors.White,
                Direction = 270,
                BlurRadius = 20,
                ShadowDepth = 1
            };
        }

        private void img_Logo_MouseLeave(object sender, MouseEventArgs e)
        {
            bd_Logo.Effect = new DropShadowEffect()
            {
                Color = Colors.White,
                Direction = 270,
                BlurRadius = 20,
                ShadowDepth = 3
            };
        }
    }
}
