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

namespace JobsManagementApp.View.User.Job
{
    /// <summary>
    /// Interaction logic for JobManagementPageUser.xaml
    /// </summary>
    public partial class JobManagementPageUser : Page
    {
        public Dictionary<string, Predicate<JobsDTO>> filters;
        public CollectionView view;
        public JobManagementPageUser()
        {
            InitializeComponent();
        }
        private void loaded_handle(object sender, RoutedEventArgs e)
        {
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
        private void AddFilterAndRefresh(string name, Predicate<JobsDTO> predicate)
        {
            filters.Add(name, predicate);
            view.Refresh();
        }

        private bool FilterJob(object obj)
        {
            JobsDTO c = (JobsDTO)obj;
            return filters.Values
                .Aggregate(true,
                    (prevValue, predicate) => prevValue && predicate(c));
        }

        private void job_type_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (job_type_cbx.SelectedIndex != -1)
            {
                if (filters == null & view == null)
                {
                    filters = new Dictionary<string, Predicate<JobsDTO>>();
                    view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                    view.Filter = FilterJob;
                }
                ComboBoxItem s = (ComboBoxItem)job_type_cbx.SelectedItem;

                switch (s.Content.ToString())
                {
                    case "ALL JOBS":
                        {
                            RemoveFilter("WAITING");
                            RemoveFilter("PENDING");
                            RemoveFilter("LATE");
                            RemoveFilter("COMPLETE LATE");
                            RemoveFilter("COMPLETE SOON");
                            return;
                        }
                    case "WAITING":
                        {
                            RemoveFilter("PENDING");
                            RemoveFilter("LATE");
                            RemoveFilter("COMPLETE LATE");
                            RemoveFilter("COMPLETE SOON");
                            AddFilterAndRefresh("WAITING", item => item.stage == "WAITING");
                            return;
                        }
                    case "PENDING":
                        {
                            RemoveFilter("WAITING");
                            RemoveFilter("LATE");
                            RemoveFilter("COMPLETE LATE");
                            RemoveFilter("COMPLETE SOON");
                            AddFilterAndRefresh("PENDING", item => item.stage == "PENDING");
                            return;
                        }
                    case "LATE":
                        {
                            RemoveFilter("WAITING");
                            RemoveFilter("PENDING");
                            RemoveFilter("COMPLETE LATE");
                            RemoveFilter("COMPLETE SOON");
                            AddFilterAndRefresh("LATE", item => item.stage == "LATE");
                            return;
                        }
                    case "COMPLETE SOON":
                        {
                            RemoveFilter("WAITING");
                            RemoveFilter("PENDING");
                            RemoveFilter("LATE");
                            RemoveFilter("COMPLETE LATE");
                            AddFilterAndRefresh("COMPLETE SOON", item => item.stage == "COMPLETE SOON");
                            return;
                        }
                    case "COMPLETE LATE":
                        {
                            RemoveFilter("WAITING");
                            RemoveFilter("PENDING");
                            RemoveFilter("LATE");
                            RemoveFilter("COMPLETE SOON");
                            AddFilterAndRefresh("COMPLETE LATE", item => item.stage == "COMPLETE LATE");
                            return;
                        }
                    default:
                        // code block
                        break;
                }
            }

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (filters == null & view == null)
            {
                filters = new Dictionary<string, Predicate<JobsDTO>>();
                view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                view.Filter = FilterJob;
            }
            RemoveFilter("SEARCH");
            AddFilterAndRefresh("SEARCH", item => item.name.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void time_filter_handler(object sender, RoutedEventArgs e)
        {
            if (filters == null & view == null)
            {
                filters = new Dictionary<string, Predicate<JobsDTO>>();
                view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                view.Filter = FilterJob;
            }
            int CurrentYear = DateTime.Now.Year;
            int LastYear = CurrentYear - 1;
            int CurrentMonth = DateTime.Now.Month;
            int LastMonth = CurrentMonth - 1;
            int CurrentDay = DateTime.Now.Day;
            DateTime CurrentDate = new DateTime(CurrentYear, CurrentMonth, CurrentDay);
            DateTime FirstWeek1Day = FirstDayOfWeek(CurrentDate);

            RadioButton checkedValue = panel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);
            string chosenValue = checkedValue?.Content.ToString();
            ComboBoxItem filterField = (ComboBoxItem)date_type_cbx.SelectedItem;

            if (checkedValue != null && chosenValue != null && filterField.Content.ToString() != null && filterField != null && filterField.Content != null)
            {
                ComboBoxItem s = (ComboBoxItem)job_type_cbx.SelectedItem;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                RemoveFilter("THIS WEEK S");
                RemoveFilter("THIS WEEK E");
                RemoveFilter("THIS WEEK D");
                RemoveFilter("THIS MONTH S");
                RemoveFilter("THIS MONTH E");
                RemoveFilter("THIS MONTH D");
                RemoveFilter("THIS YEAR S");
                RemoveFilter("THIS YEAR E");
                RemoveFilter("THIS YEAR D");
                RemoveFilter("DATE RANGE S");
                RemoveFilter("DATE RANGE E");
                RemoveFilter("DATE RANGE D");
                switch (chosenValue)
                {
                    case "This Week":
                        {
                            if (filterField.Content.ToString() == "Start Date")
                            {
                                AddFilterAndRefresh("THIS WEEK S", item =>
                                    DateTime.Compare(FirstWeek1Day, DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                                    DateTime.Compare(CurrentDate, DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0);
                            }
                            if (filterField.Content.ToString() == "Due Date")
                            {
                                AddFilterAndRefresh("THIS WEEK D", item =>
                                    DateTime.Compare(FirstWeek1Day, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                                    DateTime.Compare(CurrentDate, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0);
                            }
                            if (filterField.Content.ToString() == "End Date")
                            {
                                AddFilterAndRefresh("THIS WEEK E", item => item.end_date != "NONE" &&
                                    DateTime.Compare(FirstWeek1Day, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                                    DateTime.Compare(CurrentDate, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0);
                            }
                            tab_control.Visibility = Visibility.Collapsed;
                            popupnhe.IsOpen = !popupnhe.IsOpen;
                            ShadowMask.Visibility = Visibility.Collapsed;
                            annouce_lbl.Content = "";
                            return;
                        }
                    case "This Month":
                        {
                            if (filterField.Content.ToString() == "Start Date")
                            {
                                AddFilterAndRefresh("THIS MONTH S", item => DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Month == CurrentMonth);
                            }
                            if (filterField.Content.ToString() == "Due Date")
                            {
                                AddFilterAndRefresh("THIS MONTH D", item => DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Month == CurrentMonth);
                            }
                            if (filterField.Content.ToString() == "End Date")
                            {
                                AddFilterAndRefresh("THIS MONTH E", item => item.end_date != "NONE" && DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Month == CurrentMonth);
                            }
                            tab_control.Visibility = Visibility.Collapsed;
                            popupnhe.IsOpen = !popupnhe.IsOpen;
                            ShadowMask.Visibility = Visibility.Collapsed;
                            annouce_lbl.Content = "";
                            return;
                        }
                    case "This Year":
                        {
                            if (filterField.Content.ToString() == "Start Date")
                            {
                                AddFilterAndRefresh("THIS YEAR S", item => DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == CurrentYear);
                            }
                            if (filterField.Content.ToString() == "Due Date")
                            {
                                AddFilterAndRefresh("THIS YEAR D", item => DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == CurrentYear);
                            }
                            if (filterField.Content.ToString() == "End Date")
                            {
                                AddFilterAndRefresh("THIS YEAR E", item => item.end_date != "NONE" && DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == CurrentYear);
                            }
                            tab_control.Visibility = Visibility.Collapsed;
                            popupnhe.IsOpen = !popupnhe.IsOpen;
                            ShadowMask.Visibility = Visibility.Collapsed;
                            annouce_lbl.Content = "";
                            return;
                        }
                    case "Date Range":
                        {
                            if (startDate.SelectedDate.HasValue && endDate.SelectedDate.HasValue)
                            {
                                DateTime start = startDate.SelectedDate.Value;
                                DateTime end = endDate.SelectedDate.Value;
                                if (filterField.Content.ToString() == "Start Date")
                                {
                                    AddFilterAndRefresh("DATE RANGE S", item => DateTime.Compare(start, DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                                                                                DateTime.Compare(end, DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0);
                                }
                                if (filterField.Content.ToString() == "Due Date")
                                {
                                    AddFilterAndRefresh("DATE RANGE S", item => DateTime.Compare(start, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                                                                                DateTime.Compare(end, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0);
                                }
                                if (filterField.Content.ToString() == "End Date")
                                {
                                    AddFilterAndRefresh("DATE RANGE S", item => item.end_date != "NONE" && DateTime.Compare(start, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                                                                                DateTime.Compare(end, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0);
                                }
                                tab_control.Visibility = Visibility.Collapsed;
                                popupnhe.IsOpen = !popupnhe.IsOpen;
                                ShadowMask.Visibility = Visibility.Collapsed;
                                annouce_lbl.Content = "";
                            }
                            else
                            {
                                annouce_lbl.Content = "You did not choose date range!";
                            }

                            return;
                        }
                    default:
                        break;
                }

            }
            else
            {
                annouce_lbl.Content = "You did not choose field or options!";
            }
            if (checkedValue != null)
                checkedValue.IsChecked = false;

        }
        private void field_filter_handler(object sender, RoutedEventArgs e)
        {
            if (filters == null & view == null)
            {
                filters = new Dictionary<string, Predicate<JobsDTO>>();
                view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                view.Filter = FilterJob;
            }
            CategoriesDTO cate = (CategoriesDTO)category_cbx.SelectedItem;

            string dependency = (string)dependency_cbx.SelectedValue;
            string assignor = (string)assignor_cbx.SelectedValue;

            if (cate == null && string.IsNullOrEmpty(dependency) && string.IsNullOrEmpty(assignor))
            {
                annouce_lbl2.Content = "You did not choose any option!";

            }
            else
            {
                if (cate != null)
                {
                    RemoveFilter("CATEGORY");
                    AddFilterAndRefresh("CATEGORY", item => item.category == cate.name);
                }
                if (!string.IsNullOrEmpty(dependency))
                {
                    RemoveFilter("DEPENDENCY");
                    AddFilterAndRefresh("DEPENDENCY", item => item.dependency_name == dependency);
                }
                if (!string.IsNullOrEmpty(assignor))
                {
                    string[] split = assignor.Split('-');
                    string a = split[0];
                    string b = split[1];
                    RemoveFilter("ASSIGNOR");
                    AddFilterAndRefresh("ASSIGNOR", item => item.assignor_type == a && item.assignor_name == b);
                }
                popupnhe2.IsOpen = !popupnhe2.IsOpen;
                annouce_lbl2.Content = "";
                ShadowMask.Visibility = Visibility.Collapsed;
            }
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

        private void date_filter_btn_handle(object sender, RoutedEventArgs e)
        {
            popupnhe.IsOpen = !popupnhe.IsOpen;
            if (ShadowMask.Visibility == Visibility.Visible)
                ShadowMask.Visibility = Visibility.Collapsed;
            if (ShadowMask.Visibility == Visibility.Collapsed)
                ShadowMask.Visibility = Visibility.Visible;
        }
        public static DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }

        private void reset_filters_btn_handle(object sender, RoutedEventArgs e)
        {
            if (filters == null & view == null)
            {
                filters = new Dictionary<string, Predicate<JobsDTO>>();
                view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                view.Filter = FilterJob;
            }
            category_cbx.SelectedIndex = -1;
            dependency_cbx.SelectedIndex = -1;
            assignor_cbx.SelectedIndex = -1;
            SearchBox.Text = "";
            ResetFilter();
        }

        private void filter_btn_handle(object sender, RoutedEventArgs e)
        {
            if (filters == null & view == null)
            {
                filters = new Dictionary<string, Predicate<JobsDTO>>();
                view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                view.Filter = FilterJob;
            }
            popupnhe2.IsOpen = !popupnhe2.IsOpen;
            if (ShadowMask.Visibility == Visibility.Visible)
                ShadowMask.Visibility = Visibility.Collapsed;
            if (ShadowMask.Visibility == Visibility.Collapsed)
                ShadowMask.Visibility = Visibility.Visible;
        }

        private void _ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            category_cbx.SelectedIndex = -1;
            dependency_cbx.SelectedIndex = -1;
            assignor_cbx.SelectedIndex = -1;
            SearchBox.Text = "";
            if (filters != null & view != null)
            {
                ResetFilter();
            }
            filters = null;
            view = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            category_cbx.SelectedIndex = -1;
            dependency_cbx.SelectedIndex = -1;
            assignor_cbx.SelectedIndex = -1;
            SearchBox.Text = "";
            if (filters != null & view != null)
            {
                ResetFilter();
            }
            filters = null;
            view = null;
        }

        private void JobManagePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (filters != null & view != null)
            {
                ResetFilter();
            }
            filters = null;
            view = null;
        }

        private void JobManagementUserPage_Loaded(object sender, RoutedEventArgs e)
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
