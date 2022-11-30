using JobsManagementApp.View.Share;
using JobsManagementApp.Model;
using JobsManagementApp.ViewModel.AdminModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Org.BouncyCastle.Crmf;
using Org.BouncyCastle.Bcpg.OpenPgp;
using MySqlX.XDevAPI.Relational;

namespace JobsManagementApp.View.Admin.DashBoard
{
    /// <summary>
    /// Interaction logic for DashBoardPageAdmin.xaml
    /// </summary>
    public partial class DashBoardPageAdmin : Page
    {
        public Dictionary<string, Predicate<JobsDTO>> filters;
        public CollectionView view;
        public DashBoardPageAdmin()
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
            if(filters != null && view != null)
            {
                filters.Clear();
                view.Refresh();
            }
            

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


  

        private void handle_tab_change(object sender, SelectionChangedEventArgs e)
        {
            
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;

            category_cbx.SelectedIndex = -1;
            category_cbx.SelectedItem = null;
            date_field_cbx.SelectedIndex = -1;
            date_field_cbx.SelectedItem = null;
            start_dpk.SelectedDate = null;
            start_dpk.DisplayDate = DateTime.Today;
            end_dpk.SelectedDate = null;
            end_dpk.DisplayDate = DateTime.Today;
            start_dpk.IsEnabled = true;
            end_dpk.IsEnabled = true;
            date_field_cbx.IsEnabled = true;
            start_dpk.Visibility = Visibility.Visible;
            end_dpk.Visibility = Visibility.Visible;
            date_field_cbx.Visibility = Visibility.Visible;
            Thickness margin1 = category_cbx.Margin;
            margin1.Top = 15;
            category_cbx.Margin = margin1;
            ResetFilter();
            switch (tabItem)
            {
                case "All":
                    {
                        if (filters != null & view != null)
                        {
                            ResetFilter();
                        }
                        break;
                    }
                case "Today":
                    {

                        if (filters == null & view == null)
                        {
                            filters = new Dictionary<string, Predicate<JobsDTO>>();
                            view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                            view.Filter = FilterJob;
                        }
                        start_dpk.IsEnabled = false;
                        end_dpk.IsEnabled = false;
                        date_field_cbx.IsEnabled = false;
                        start_dpk.Visibility = Visibility.Collapsed;
                        end_dpk.Visibility = Visibility.Collapsed;
                        date_field_cbx.Visibility = Visibility.Collapsed;
                        Thickness margin = category_cbx.Margin;
                        margin.Top = 80;
                        category_cbx.Margin = margin;
                        ResetFilter();
                        AddFilterAndRefresh("TODAY", item =>
                                    DateTime.Compare(DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                                    DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) == 0
                                    );
                        break;
                    }
                case "Waiting":
                    {
                        if (filters == null & view == null)
                        {
                            filters = new Dictionary<string, Predicate<JobsDTO>>();
                            view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                            view.Filter = FilterJob;
                        }
                        ResetFilter();
                        AddFilterAndRefresh("WAITING", item => item.stage == "WAITING");
                        break;
                    }
                case "Pending":
                    {
                        if (filters == null & view == null)
                        {
                            filters = new Dictionary<string, Predicate<JobsDTO>>();
                            view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                            view.Filter = FilterJob;
                        }
                        ResetFilter();
                        AddFilterAndRefresh("PENDING", item => item.stage == "PENDING");
                        break;
                    }
                case "Late":
                    {
                        if (filters == null & view == null)
                        {
                            filters = new Dictionary<string, Predicate<JobsDTO>>();
                            view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                            view.Filter = FilterJob;
                        }
                        ResetFilter();
                        AddFilterAndRefresh("LATE", item => item.stage == "LATE");
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
        }





        private void test_click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filter_btn_handle(object sender, RoutedEventArgs e)
        {

            if (filters == null & view == null)
            {
                filters = new Dictionary<string, Predicate<JobsDTO>>();
                view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                view.Filter = FilterJob;
            }


            if (category_cbx.SelectedValue == null && date_field_cbx.SelectedValue == null && ! start_dpk.SelectedDate.HasValue && !end_dpk.SelectedDate.HasValue)
            {
                annouce_lbl2.Visibility = Visibility.Visible;
                annouce_lbl2.Content = "You did not choose any option!";

            }else
            {
                if (date_field_cbx.SelectedValue != null)
                {
                    string field = ((ComboBoxItem)date_field_cbx.SelectedItem).Content.ToString();

                    if (!start_dpk.SelectedDate.HasValue || !end_dpk.SelectedDate.HasValue)
                    {

                        annouce_lbl2.Content = "You must choose both start and end date!";
                    }
                    else
                    {
                        DateTime start = start_dpk.SelectedDate.Value;
                        DateTime end = end_dpk.SelectedDate.Value;
                        if (DateTime.Compare(start, end) >= 0)
                        {
                            annouce_lbl2.Visibility = Visibility.Visible;
                            annouce_lbl2.Content = "Start date  must be greater than end date!";
                        }
                        else
                        {
                            RemoveFilter("DATE RANGE");
                            switch (field)
                            {
                                case "Start Date":
                                    {

                                        AddFilterAndRefresh("DATE RANGE", item =>
                                                DateTime.Compare(start,
                                                    DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                                                DateTime.Compare(end,
                                                    DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                                                );
                                        break;
                                    }
                                case "End Date":
                                    {
                                        AddFilterAndRefresh("DATE RANGE", item => item.end_date != "NONE" &&
                                                DateTime.Compare(start,
                                                    DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                                                DateTime.Compare(end,
                                                    DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                                                );
                                        break;
                                    }
                                case "Due Date":
                                    {
                                        AddFilterAndRefresh("DATE RANGE", item =>
                                                DateTime.Compare(start,
                                                    DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                                                DateTime.Compare(end,
                                                    DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                                                );
                                        break;
                                    }
                                default:
                                    break;
                            }
                            annouce_lbl2.Visibility = Visibility.Collapsed;
                            annouce_lbl2.Content = "";

                        }
                    }
                }
                else
                {
                    if (category_cbx.SelectedValue != null)
                    {
                        string category = (string)category_cbx.SelectedValue;
                        RemoveFilter("CATEGORY");
                        AddFilterAndRefresh("CATEGORY", item => item.category == category );
                        annouce_lbl2.Visibility = Visibility.Collapsed;
                        annouce_lbl2.Content = "";
                    }
                }
            }

        }

        private void clear_filter_btn_handle(object sender, RoutedEventArgs e)
        {
            if (filters == null & view == null)
            {
                filters = new Dictionary<string, Predicate<JobsDTO>>();
                view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                view.Filter = FilterJob;
            }
            annouce_lbl2.Visibility = Visibility.Collapsed;
            annouce_lbl2.Content = "";
            category_cbx.SelectedIndex = -1;
            category_cbx.SelectedItem = null;
            date_field_cbx.SelectedIndex = -1;
            date_field_cbx.SelectedItem = null;
            start_dpk.SelectedDate = null;
            start_dpk.DisplayDate = DateTime.Today;
            end_dpk.SelectedDate = null;
            end_dpk.DisplayDate = DateTime.Today;
            ResetFilter();
        }

        private void pie_loaded_handle(object sender, RoutedEventArgs e)
        {
            pieType.SelectedIndex = 0;
        }

        private void btn_Weekly_click(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            weekly_lbl.Foreground = (Brush?)bc.ConvertFrom("#1EA7FF");
            monthly_lbl.Foreground = (Brush?)bc.ConvertFrom("#232360");
            yearly_lbl.Foreground = (Brush?)bc.ConvertFrom("#232360");
        }
        private void btn_Monthly_click(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            weekly_lbl.Foreground = (Brush?)bc.ConvertFrom("#232360");
            monthly_lbl.Foreground = (Brush?)bc.ConvertFrom("#1EA7FF");
            yearly_lbl.Foreground = (Brush?)bc.ConvertFrom("#232360");
        }
        private void btn_Yearly_click(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            weekly_lbl.Foreground = (Brush?)bc.ConvertFrom("#232360");
            monthly_lbl.Foreground = (Brush?)bc.ConvertFrom("#232360");
            yearly_lbl.Foreground = (Brush?)bc.ConvertFrom("#1EA7FF");
        }

        private void pieType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() => tabct.SelectedIndex = 0));
            category_cbx.SelectedIndex = -1;
            category_cbx.SelectedItem = null;
            date_field_cbx.SelectedIndex = -1;
            date_field_cbx.SelectedItem = null;
            start_dpk.SelectedDate = null;
            start_dpk.DisplayDate = DateTime.Today;
            end_dpk.SelectedDate = null;
            end_dpk.DisplayDate = DateTime.Today;
            if (filters != null & view != null)
            {
                ResetFilter();
            }
            filters = null;
            view = null;
            var btn = sender as Button;
            btn.Command.Execute(null);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() => tabct.SelectedIndex = 0));
            category_cbx.SelectedIndex = -1;
            category_cbx.SelectedItem = null;
            date_field_cbx.SelectedIndex = -1;
            date_field_cbx.SelectedItem = null;
            start_dpk.SelectedDate = null;
            start_dpk.DisplayDate = DateTime.Today;
            end_dpk.SelectedDate = null;
            end_dpk.DisplayDate = DateTime.Today;
            if (filters != null & view != null)
            {
                ResetFilter();
            }
            filters = null;
            view = null;
        }


        private void tabct_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void _ListView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(filters!= null)
            {
                view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
                view.Filter = FilterJob;
            }
            
        }

        private void DashBoardPageAd_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() => tabct.SelectedIndex = 0));
            category_cbx.SelectedIndex = -1;
            category_cbx.SelectedItem = null;
            date_field_cbx.SelectedIndex = -1;
            date_field_cbx.SelectedItem = null;
            start_dpk.SelectedDate = null;
            start_dpk.DisplayDate = DateTime.Today;
            end_dpk.SelectedDate = null;
            end_dpk.DisplayDate = DateTime.Today;
            if (filters != null & view != null)
            {
                ResetFilter();
            }
            filters = null;
            view = null;
        }

        private void DashBoardPageAd_Loaded(object sender, RoutedEventArgs e)
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
