using JobsManagementApp.Model;
using JobsManagementApp.Service;
using JobsManagementApp.View.Share;
using MySql.Data.MySqlClient;
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

namespace JobsManagementApp.View.Admin.Job
{
    /// <summary>
    /// Interaction logic for JobManagementPageAdmin.xaml
    /// </summary>
    public partial class JobManagementPageAdmin : Page
    {
        //public ObservableCollection<ItemBinding> Items { get; set; }
        public JobManagementPageAdmin()
        {
            InitializeComponent();
        }
        private void job_type_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem s = (ComboBoxItem)job_type_cbx.SelectedItem;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
            switch (s.Content.ToString())
            {
                case "ALL JOBS":
                    {
                        view.Filter = null;
                        CollectionViewSource.GetDefaultView(_ListView.ItemsSource).Refresh();
                        return;
                    }
                case "WAITING":
                    {
                        view.Filter = FilterWaiting;
                        CollectionViewSource.GetDefaultView(_ListView.ItemsSource).Refresh();
                        return;
                    }
                case "PENDING":
                    {
                        view.Filter = FilterPending;
                        CollectionViewSource.GetDefaultView(_ListView.ItemsSource).Refresh();
                        return;
                    }
                case "LATE":
                    {
                        view.Filter = FilterLate;
                        CollectionViewSource.GetDefaultView(_ListView.ItemsSource).Refresh();
                        return;
                    }
                case "COMPLETE SOON":
                    {
                        view.Filter = FilterCompleteSoon;
                        CollectionViewSource.GetDefaultView(_ListView.ItemsSource).Refresh();
                        return;
                    }
                case "COMPLETE LATE":
                    {
                        view.Filter = FilterCompleteLate;
                        CollectionViewSource.GetDefaultView(_ListView.ItemsSource).Refresh();
                        return;
                    }
                default:
                    // code block
                    break;
            }
        }
        private bool FilterWaiting(object item)
        {
            return (item as JobsDTO).stage == "WAITING";
        }
        private bool FilterPending(object item)
        {
            return (item as JobsDTO).stage == "PENDING";
        }
        private bool FilterLate(object item)
        {
            return (item as JobsDTO).stage == "LATE";
        }
        private bool FilterCompleteLate(object item)
        {
            return (item as JobsDTO).stage == "COMPLETE LATE";
        }
        private bool FilterCompleteSoon(object item)
        {
            return (item as JobsDTO).stage == "COMPLETE SOON";
        }
        private bool FilterSearch(object item)
        {
            return ((item as JobsDTO).name.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
            view.Filter = FilterSearch;
            CollectionViewSource.GetDefaultView(_ListView.ItemsSource).Refresh();
        }
        private void filter_handler(object sender, RoutedEventArgs e)
        {
            tab_control.Visibility = Visibility.Collapsed;
            popupnhe.IsOpen = !popupnhe.IsOpen;
            ShadowMask.Visibility = Visibility.Collapsed;
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
    }
}
