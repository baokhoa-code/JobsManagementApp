using JobsManagementApp.Model;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for ReportManagementPageAdmin.xaml
    /// </summary>
    public partial class ReportListForSingleAssignee : Page
    {
        public Dictionary<string, Predicate<ReportsDTO>> filters;
        public CollectionView view;
        public ReportListForSingleAssignee()
        {
            InitializeComponent();
        }
        public void ClearFilters()
        {
            filters.Clear();
            view.Refresh();
        }

        public void RemoveFilter(string filterName)
        {
            if (filters.Remove(filterName))
            {
                view.Refresh();
            }
        }
        public void ResetFilter()
        {
            filters.Clear();
            view.Refresh();

        }
        private void AddFilterAndRefresh(string name, Predicate<ReportsDTO> predicate)
        {
            filters.Add(name, predicate);
            view.Refresh();
        }

        private bool FilterJob(object obj)
        {
            ReportsDTO c = (ReportsDTO)obj;
            return filters.Values
                .Aggregate(true,
                    (prevValue, predicate) => prevValue && predicate(c));
        }

        private void date_filter_btn_handle(object sender, RoutedEventArgs e)
        {
            if (filters == null & view == null)
            {
                filters = new Dictionary<string, Predicate<ReportsDTO>>();
                view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                view.Filter = FilterJob;
            }
            popupnhe.IsOpen = true;
            if (ShadowMask.Visibility == Visibility.Visible)
                ShadowMask.Visibility = Visibility.Collapsed;
            if (ShadowMask.Visibility == Visibility.Collapsed)
                ShadowMask.Visibility = Visibility.Visible;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (filters == null & view == null)
            {
                filters = new Dictionary<string, Predicate<ReportsDTO>>();
                view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                view.Filter = FilterJob;
            }
            RemoveFilter("SEARCH");
            AddFilterAndRefresh("SEARCH", item => item.tile.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0 || item.job_name.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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
        public static DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }
        private void time_filter_handler(object sender, RoutedEventArgs e)
        {
            int CurrentYear = DateTime.Now.Year;
            int LastYear = CurrentYear - 1;
            int CurrentMonth = DateTime.Now.Month;
            int LastMonth = CurrentMonth - 1;
            int CurrentDay = DateTime.Now.Day;
            DateTime CurrentDate = new DateTime(CurrentYear, CurrentMonth, CurrentDay);
            DateTime FirstWeek1Day = FirstDayOfWeek(CurrentDate);

            RadioButton checkedValue = panel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);
            string chosenValue = checkedValue?.Content.ToString();

            if (checkedValue != null && chosenValue != null)
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                RemoveFilter("THIS WEEK");
                RemoveFilter("THIS MONTH");
                RemoveFilter("THIS YEAR");
                RemoveFilter("DATE RANGE");
                switch (chosenValue)
                {
                    case "This Week":
                        {
                            AddFilterAndRefresh("THIS WEEK", item =>
                                DateTime.Compare(FirstWeek1Day, DateTime.ParseExact(item.created_time, "dd-MM-yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                                DateTime.Compare(CurrentDate, DateTime.ParseExact(item.created_time, "dd-MM-yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture)) >= 0);
                            tab_control.Visibility = Visibility.Collapsed;
                            popupnhe.IsOpen = !popupnhe.IsOpen;
                            ShadowMask.Visibility = Visibility.Collapsed;
                            annouce_lbl.Content = "";
                            return;
                        }
                    case "This Month":
                        {
                            AddFilterAndRefresh("THIS MONTH", item => DateTime.ParseExact(item.created_time, "dd-MM-yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture).Month == CurrentMonth);
                            tab_control.Visibility = Visibility.Collapsed;
                            popupnhe.IsOpen = !popupnhe.IsOpen;
                            ShadowMask.Visibility = Visibility.Collapsed;
                            annouce_lbl.Content = "";
                            return;
                        }
                    case "This Year":
                        {
                            AddFilterAndRefresh("THIS YEAR", item => DateTime.ParseExact(item.created_time, "dd-MM-yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture).Year == CurrentYear);
                            tab_control.Visibility = Visibility.Collapsed;
                            popupnhe.IsOpen = !popupnhe.IsOpen;
                            ShadowMask.Visibility = Visibility.Collapsed;
                            annouce_lbl.Content = "";
                            return;
                        }
                    case "Date Range":
                        {
                            if (startDate.SelectedDate.HasValue && endDate.SelectedDate.HasValue && start_picker.SelectedTime.HasValue && end_picker.SelectedTime.HasValue)
                            {
                                string start_day = startDate.SelectedDate.Value.ToString("dd-MM-yyy");
                                string end_day = endDate.SelectedDate.Value.ToString("dd-MM-yyy");
                                DateTime datea = DateTime.ParseExact(start_picker.SelectedTime.Value.ToShortTimeString(), "h:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                                DateTime dateb = DateTime.ParseExact(end_picker.SelectedTime.Value.ToShortTimeString(), "h:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                                string start_time = dateb.ToString("hh:mm tt");
                                string end_time = datea.ToString("hh:mm tt");
                                DateTime start = DateTime.ParseExact(start_day + " " + start_time, "dd-MM-yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                                DateTime end = DateTime.ParseExact(end_day + " " + end_time, "dd-MM-yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                                AddFilterAndRefresh("DATE RANGE", item => DateTime.Compare(start, DateTime.ParseExact(item.created_time, "dd-MM-yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                                                                                DateTime.Compare(end, DateTime.ParseExact(item.created_time, "dd-MM-yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture)) >= 0);
                                tab_control.Visibility = Visibility.Collapsed;
                                popupnhe.IsOpen = !popupnhe.IsOpen;
                                ShadowMask.Visibility = Visibility.Collapsed;
                                annouce_lbl.Content = "";
                                startDate.SelectedDate = null;
                                startDate.DisplayDate = DateTime.Today;
                                endDate.SelectedDate = null;
                                endDate.DisplayDate = DateTime.Today;
                                start_picker.SelectedTime = null;
                                end_picker.SelectedTime = null;

                            }
                            else
                            {
                                annouce_lbl.Content = "You did not choose date and time range!";
                            }

                            return;
                        }
                    default:
                        break;
                }

            }
            else
            {
                annouce_lbl.Content = "You did not choose any options!";
            }
            if (checkedValue != null)
                checkedValue.IsChecked = false;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            SearchBox.Text = "";
            month_rbtn.IsChecked = false;
            year_rbtn.IsChecked = false;
            day_range_rbtn.IsChecked = false;
            week_rbtn.IsChecked = false;
            if (filters != null && view != null)
            {
                ResetFilter();
            }
            else
            {
                filters = new Dictionary<string, Predicate<ReportsDTO>>();
                view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                view.Filter = FilterJob;
            }
        }

        private void ReportListForSingleAssigneePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (filters != null & view != null)
            {
                ResetFilter();
            }
            filters = null;
            view = null;
        }
    }
}
