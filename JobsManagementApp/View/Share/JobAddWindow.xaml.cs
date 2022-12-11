using MaterialDesignColors;
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
using System.Windows.Shapes;

namespace JobsManagementApp.View.Share
{
    /// <summary>
    /// Interaction logic for JobAddWindow.xaml
    /// </summary>
    public partial class JobAddWindow : Window
    {
        public JobAddWindow()
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

        private void clear_infor(object sender, RoutedEventArgs e)
        {
            //DateTime current_t = DateTime.Now;
            //DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
            //    System.Globalization.CultureInfo.InvariantCulture);
            //job_assignee.SelectedIndex = -1;
            //job_assignee.SelectedItem = null;
            //job_category.SelectedIndex = -1;
            //job_category.SelectedItem = null;
            //job_dependency.SelectedIndex = -1;
            //job_dependency.SelectedItem = null;
            //job_require_hour.Text = string.Empty;
            //job_name.Text = string.Empty;
            //job_description.Text = string.Empty;
            //job_start_date.SelectedDate = current;
            //job_start_date.DisplayDate = current;
            //job_due_date.SelectedDate = current;
            //job_due_date.DisplayDate = current;

        }

        private void check_valid_due_date(object sender, SelectionChangedEventArgs e)
        {
            if(job_start_date.SelectedDate != null)
            {
                DateTime start = job_start_date?.SelectedDate ?? DateTime.Now;
                DateTime due = job_due_date?.SelectedDate ?? DateTime.Now;
                if (DateTime.Compare(start, due) > 0)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Due date must greater or equal to start!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    job_due_date.SelectedDate = start;
                    job_due_date.DisplayDate = start;
                }
            }
        }

        private void check_valid_start_date(object sender, SelectionChangedEventArgs e)
        {
            if (job_start_date.SelectedDate != null)
            {
                
                DateTime start_t = job_start_date?.SelectedDate ?? DateTime.Now;
                DateTime current_t = DateTime.Now;
                DateTime start = DateTime.ParseExact(start_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.Compare(start, current) < 0)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Start date must greater or equal to current date!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    job_start_date.SelectedDate = current;
                    job_start_date.DisplayDate = current;
                }
                else
                {
                    job_due_date.SelectedDate = start;
                    job_due_date.DisplayDate = start;
                }
                
            }
        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
