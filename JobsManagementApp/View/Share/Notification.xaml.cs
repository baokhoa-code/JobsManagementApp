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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JobsManagementApp.View.Share
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : Window
    {
        public Notification(string notification)
        {
            InitializeComponent();

            txbl_notification.Text = notification;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ColorZone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btn_confirm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
