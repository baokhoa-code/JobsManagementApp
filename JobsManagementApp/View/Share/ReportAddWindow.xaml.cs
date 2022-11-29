using MaterialDesignColors;
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
using JobsManagementApp.Model;
using JobsManagementApp.Service;
using JobsManagementApp.View.Share;

namespace JobsManagementApp.View.Share
{
    /// <summary>
    /// Interaction logic for ReportAddWindow.xaml
    /// </summary>
    public partial class ReportAddWindow : Window
    {
        public ReportAddWindow()
        {
            InitializeComponent();
        }

        private void create_time_btn_handle(object sender, RoutedEventArgs e)
        {
            if (assgned_jobs.SelectedItem == null)
            {
                MessageBoxCustom mb = new MessageBoxCustom("Error", "You must choose job!", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }
            else
            {
                popupnhe.IsOpen = true;
                if (ShadowMask.Visibility == Visibility.Visible)
                    ShadowMask.Visibility = Visibility.Collapsed;
                if (ShadowMask.Visibility == Visibility.Collapsed)
                    ShadowMask.Visibility = Visibility.Visible;
            }
            
        }

        private void job_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void fill_created_time(object sender, RoutedEventArgs e)
        {
            DateTime current_t = DateTime.Now;
            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            if (date_picker.SelectedDate.HasValue && time_picker.SelectedTime.HasValue )
            {
                DateTime date_pick = DateTime.ParseExact(date_picker.SelectedDate.Value.ToString("dd-MM-yyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.Compare(date_pick, current) < 0)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Created date must greater or equal to current date!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    JobsDTO j = (JobsDTO)assgned_jobs.SelectedItem;
                    if (DateTime.Compare(DateTime.ParseExact(j.start_date, "dd-MM-yyyy",
                            System.Globalization.CultureInfo.InvariantCulture), date_pick) > 0)
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Created date must greater or equal to job start date!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                    else
                    {
                        DateTime date_temp = DateTime.ParseExact(time_picker.SelectedTime.Value.ToShortTimeString(), "h:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                        string time_pick = date_temp.ToString("hh:mm tt");
                        reportCreatedTime_txt.Text = date_pick.ToString("dd-MM-yyy") + " " + time_pick;
                        popupnhe.IsOpen = false;
                        ShadowMask.Visibility = Visibility.Collapsed;
                    }

                }
            }
            else
            {
                MessageBoxCustom mb = new MessageBoxCustom("Error", "You need to choose both field!", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }
        }

        private void clear_infor(object sender, RoutedEventArgs e)
        {
            reportCreatedTime_txt.Text = "";
        }

        private void ReportAddWindowS_Loaded(object sender, RoutedEventArgs e)
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = 580;
            double windowHeight = 500;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
