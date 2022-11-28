using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace JobsManagementApp.View.Share
{
    /// <summary>
    /// Interaction logic for JobDetailPage.xaml
    /// </summary>
    public partial class JobDetailPage : Page
    {
        public JobDetailPage()
        {
            InitializeComponent();
        }

        private void job_assignor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void job_assignor_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void job_assignee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void job_assignee_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void job_dependency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void job_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void job_require_hour_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void check_valid_due_date(object sender, SelectionChangedEventArgs e)
        {
        }

        private void check_valid_start_date(object sender, SelectionChangedEventArgs e)
        {
        }
        private void check_valid_end_date(object sender, SelectionChangedEventArgs e)
        {



        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {

        }




        private void job_dependency_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void job_name_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void job_assignee_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
