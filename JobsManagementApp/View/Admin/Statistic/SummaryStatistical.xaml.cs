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

namespace JobsManagementApp.View.Admin.Statistic
{
    /// <summary>
    /// Interaction logic for SummaryStatistical.xaml
    /// </summary>
    public partial class SummaryStatistical : Page
    {
        public SummaryStatistical()
        {
            InitializeComponent();
        }
        private void periodbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem s = (ComboBoxItem)periodbox.SelectedItem;
            switch (s.Content.ToString())
            {
                case "By Years":
                    {
                        GetYearSource(Timebox);
                        return;
                    }
                case "By Months":
                    {
                        GetMonthSource(Timebox);
                        return;
                    }
            }
        }
        private void periodbox_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            GetYearSource(Timebox);
        }
        public void GetYearSource(ComboBox cbb)
        {
            if (cbb is null) return;

            List<string> l = new List<string>();

            for (int i = System.DateTime.Now.Year; i >= 2018 ; i--)
            {
                l.Add(i.ToString());
            }
            cbb.ItemsSource = l;
            cbb.SelectedIndex = 0;
        }
        public void GetMonthSource(ComboBox cbb)
        {
            if (cbb is null) return;

            List<string> l = new List<string>();

            l.Add("12");
            l.Add("11");
            l.Add("10");
            l.Add("9");
            l.Add("8");
            l.Add("7");
            l.Add("6");
            l.Add("5");
            l.Add("4");
            l.Add("3");
            l.Add("2");
            l.Add("1");

            cbb.ItemsSource = l;
            cbb.SelectedIndex = 0;
        }

        private void periodbox_Loaded_1(object sender, RoutedEventArgs e)
        {
            ComboBoxItem s = (ComboBoxItem)periodbox.SelectedItem;
            switch (s.Content.ToString())
            {
                case "By Years":
                    {
                        GetYearSource(Timebox);
                        return;
                    }
                case "By Months":
                    {
                        GetMonthSource(Timebox);
                        return;
                    }
            }
        }
    }
}
