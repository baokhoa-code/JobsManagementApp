using JobsManagementApp.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JobsManagementApp.View.Share
{
    /// <summary>
    /// Interaction logic for ReportDetailPage.xaml
    /// </summary>
    public partial class ReportDetailPage : Page
    {
        public ReportDetailPage()
        {
            InitializeComponent();
        }
        private void create_time_btn_handle(object sender, RoutedEventArgs e)
        {

            popupnhe.IsOpen = true;
            if (ShadowMask.Visibility == Visibility.Visible)
                ShadowMask.Visibility = Visibility.Collapsed;
            if (ShadowMask.Visibility == Visibility.Collapsed)
                ShadowMask.Visibility = Visibility.Visible;

        }

        private void job_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void fill_created_time(object sender, RoutedEventArgs e)
        {
            if (date_picker.SelectedDate.HasValue && time_picker.SelectedTime.HasValue)
            {
                DateTime date_pick = DateTime.ParseExact(date_picker.SelectedDate.Value.ToString("dd-MM-yyy"), "dd-MM-yyyy",
                                                            System.Globalization.CultureInfo.InvariantCulture);
                DateTime date_temp = DateTime.ParseExact(time_picker.SelectedTime.Value.ToShortTimeString(), "h:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                string time_pick = date_temp.ToString("hh:mm tt");
                reportCreatedTime_txt.Text = date_pick.ToString("dd-MM-yyy") + " " + time_pick;
                popupnhe.IsOpen = false;
                ShadowMask.Visibility = Visibility.Collapsed;
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
    }
}
