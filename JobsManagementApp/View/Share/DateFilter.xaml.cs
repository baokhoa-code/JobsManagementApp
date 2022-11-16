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
    /// Interaction logic for DateFilter.xaml
    /// </summary>
    public partial class DateFilter : Window
    {
        public DateFilter()
        {
            InitializeComponent();
            tab_control.Visibility = Visibility.Collapsed;
        }

        private void filter_handler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void date_range_checked_handler(object sender, RoutedEventArgs e)
        {
            if (tab_control.Visibility == Visibility.Collapsed)
            {
                tab_control.Visibility = Visibility.Visible;
            }
        }

        private void date_range_unchecked_handler(object sender, RoutedEventArgs e)
        {
            if (tab_control.Visibility == Visibility.Visible)
            {
                tab_control.Visibility = Visibility.Collapsed;
            }
        }
    }
}
