using JobsManagementApp.Model;
using JobsManagementApp.View.Share;
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

namespace JobsManagementApp.View.Admin.Staff
{
    /// <summary>
    /// Interaction logic for StaffManagementPageAdmin.xaml
    /// </summary>
    public partial class StaffManagementPageAdmin : Page
    {
        public Dictionary<string, Predicate<UsersDTO>> filters;
        public CollectionView view;
        public StaffManagementPageAdmin()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RemoveFilter("SEARCH");
            AddFilterAndRefresh("SEARCH", item => item.name.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >=  0 ||
                                                    item.email.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                    item.username.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void loaded_handle(object sender, RoutedEventArgs e)
        {
            filters = new Dictionary<string, Predicate<UsersDTO>>();
            view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
            view.Filter = FilterJob;
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
        private void AddFilterAndRefresh(string name, Predicate<UsersDTO> predicate)
        {
            filters.Add(name, predicate);
            view.Refresh();
        }

        private bool FilterJob(object obj)
        {
            UsersDTO c = (UsersDTO)obj;
            return filters.Values
                .Aggregate(true,
                    (prevValue, predicate) => prevValue && predicate(c));
        }

        private void organization_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrganizationsDTO a = (OrganizationsDTO )organization_cbx.SelectedItem;
            
            if(a != null)
            {
                string s = a.name;
                if (!string.IsNullOrEmpty(s))
                {
                    RemoveFilter("ORGANIZATION");
                    RemoveFilter("POSITION");
                    AddFilterAndRefresh("ORGANIZATION", item => item.organization == s);
                }
            }
            
        }
        private void position_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PositionsDTO a = (PositionsDTO)position_cbx.SelectedItem;
            if(a != null)
            {
                string s = a.name;
                if (!string.IsNullOrEmpty(s))
                {
                    RemoveFilter("POSITION");
                    AddFilterAndRefresh("POSITION", item => item.position == s);
                }
            }
            
        }

        private void reset_filters_btn_handle(object sender, RoutedEventArgs e)
        {
            ResetFilter();
            organization_cbx.SelectedIndex = -1;
            position_cbx.SelectedIndex = -1;
            SearchBox.Text = "";

        }

        private void organ_popup_btn_handle(object sender, RoutedEventArgs e)
        {
            popupnhe1.IsOpen = !popupnhe1.IsOpen;
            if (ShadowMask.Visibility == Visibility.Visible)
                ShadowMask.Visibility = Visibility.Collapsed;
            if (ShadowMask.Visibility == Visibility.Collapsed)
                ShadowMask.Visibility = Visibility.Visible;
            ResetFilter();
            organization_cbx.SelectedIndex = -1;
            position_cbx.SelectedIndex = -1;
            SearchBox.Text = "";
        }

        private void close_organ_popup(object sender, RoutedEventArgs e)
        {
            popupnhe1.IsOpen = false;
            ShadowMask.Visibility = Visibility.Collapsed;
            ResetFilter();
            organization_cbx.SelectedIndex = -1;
            position_cbx.SelectedIndex = -1;
            SearchBox.Text = "";
        }
        private void close_position_popup(object sender, RoutedEventArgs e)
        {
            popupnhe2.IsOpen = false;
            ShadowMask.Visibility = Visibility.Collapsed;
            ResetFilter();
            organization_cbx.SelectedIndex = -1;
            position_cbx.SelectedIndex = -1;
            SearchBox.Text = "";
        }

        private void position_popup_btn_handle(object sender, RoutedEventArgs e)
        {
            popupnhe2.IsOpen = !popupnhe2.IsOpen;
            if (ShadowMask.Visibility == Visibility.Visible)
                ShadowMask.Visibility = Visibility.Collapsed;
            if (ShadowMask.Visibility == Visibility.Collapsed)
                ShadowMask.Visibility = Visibility.Visible;
            ResetFilter();
            organization_cbx.SelectedIndex = -1;
            position_cbx.SelectedIndex = -1;
            SearchBox.Text = "";
        }

        private void organization_cbx2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
