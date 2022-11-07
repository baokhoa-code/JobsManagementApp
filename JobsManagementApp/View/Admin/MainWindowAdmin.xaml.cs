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
using JobsManagementApp.View.Admin.DashBoard;

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
            //mainFrame.Navigate(new HomePageAdmin());
            //mainFrame.Navigate(new JobsListPageAdmin());
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
