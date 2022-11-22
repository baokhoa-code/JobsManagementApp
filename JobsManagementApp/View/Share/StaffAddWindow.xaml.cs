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
using Microsoft.Win32;

namespace JobsManagementApp.View.Share
{
    /// <summary>
    /// Interaction logic for StaffAddWindow.xaml
    /// </summary>
    public partial class StaffAddWindow : Window
    {
        public StaffAddWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void clear_infor_handle(object sender, RoutedEventArgs e)
        {
            staffGender_cbx.SelectedIndex = -1;
            staffOrganization_cbx.SelectedIndex = -1;
            staffPosition_cbx.SelectedIndex = -1;
            staffQuestion_cbx.SelectedIndex = -1;
        }

        private void staffName_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void load_btn_handle(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName); ;
                avatar_img.Source = new BitmapImage(fileUri);
                string sourcefile = openFileDialog.FileName;
                Notification w = new Notification(sourcefile);
                w.ShowDialog();
            }
        }

        private void staffQuestion_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void staffPhone_txt_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StaffAddWindows_Loaded(object sender, RoutedEventArgs e)
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = 1040;
            double windowHeight = 690;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
