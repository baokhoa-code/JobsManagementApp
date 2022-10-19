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

namespace JobsManagementApp.View.Admin
{
    /// <summary>
    /// Interaction logic for MainWindowAdmin.xaml
    /// </summary>
    public partial class MainWindowAdmin : Window
    {
        public MainWindowAdmin()
        {
            InitializeComponent();
            mainFrame.Navigate(new HomePageAdmin());
            //mainFrame.Navigate(new JobsListPageAdmin());
        }
        private void switchpagehandle1(object sender, RoutedEventArgs e)
        {
            btn1.IsChecked = true;
            btn2.IsChecked = btn3.IsChecked = btn4.IsChecked = btn5.IsChecked = btn6.IsChecked = btn7.IsChecked = false;

        }
        private void switchpagehandle2(object sender, RoutedEventArgs e)
        {
            btn2.IsChecked = true;
            btn1.IsChecked = btn3.IsChecked = btn4.IsChecked = btn5.IsChecked = btn6.IsChecked = btn7.IsChecked = false;

        }
        private void switchpagehandle3(object sender, RoutedEventArgs e)
        {
            btn3.IsChecked = true;
            btn1.IsChecked = btn2.IsChecked = btn4.IsChecked = btn5.IsChecked = btn6.IsChecked = btn7.IsChecked = false;

        }
        private void switchpagehandle4(object sender, RoutedEventArgs e)
        {
            btn4.IsChecked = true;
            btn1.IsChecked = btn2.IsChecked = btn3.IsChecked = btn5.IsChecked = btn6.IsChecked = btn7.IsChecked = false;

        }
        private void switchpagehandle5(object sender, RoutedEventArgs e)
        {
            btn5.IsChecked = true;
            btn1.IsChecked = btn2.IsChecked = btn3.IsChecked = btn4.IsChecked = btn6.IsChecked = btn7.IsChecked = false;

        }
        private void switchpagehandle6(object sender, RoutedEventArgs e)
        {
            btn6.IsChecked = true;
            btn1.IsChecked = btn2.IsChecked = btn3.IsChecked = btn4.IsChecked = btn5.IsChecked = btn7.IsChecked = false;

        }
        private void switchpagehandle7(object sender, RoutedEventArgs e)
        {
            btn6.IsChecked = true;
            btn1.IsChecked = btn2.IsChecked = btn3.IsChecked = btn4.IsChecked = btn5.IsChecked = btn6.IsChecked = false;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_minimize_click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
