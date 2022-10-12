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
    /// Interaction logic for DashBoardAdmin.xaml
    /// </summary>
    public partial class DashBoardAdmin : Window
    {
        public DashBoardAdmin()
        {
            InitializeComponent();
            //mainFrame.Navigate(new HomePageAdmin());
            mainFrame.Navigate(new JobsListPageAdmin());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
