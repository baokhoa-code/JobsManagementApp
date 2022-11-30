using JobsManagementApp.Model;
using JobsManagementApp.ViewModel.ShareModel;
using JobsManagementApp.Service;
using JobsManagementApp.View.Share;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace JobsManagementApp.ViewModel.AdminModel
{
    public class ReportManagementPageAdminViewModel : BaseViewModel
    {
        public Admin admin { get; set; }
        private bool _IsGettingSource;
        public bool IsGettingSource
        {
            get { return _IsGettingSource; }
            set { _IsGettingSource = value; OnPropertyChanged(); }
        }
        private ObservableCollection<ReportsDTO> _Reports;
        public ObservableCollection<ReportsDTO> Reports
        {
            get { return _Reports; }
            set { _Reports = value; OnPropertyChanged(); }
        }
        private ReportsDTO _SelectedItem;
        public ReportsDTO SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }
        private Page _CurrentPage;
        public Page CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; OnPropertyChanged(); }
        }
        public static Grid MaskName { get; set; }
        public ICommand OpenAddReportWindowCM { get; set; }
        public ICommand OpenEditReportPageCM { get; set; }
        public ICommand DeleteReportCM { get; set; }
        public ICommand MaskNameCM { get; set; }
        public ICommand SaveCurrentPageCM { get; set; }
        public ICommand LoadCM { get; set; }
        public ICommand testCM { get; set; }
        public ReportManagementPageAdminViewModel(Admin a)
        {
            admin = new Admin(a);
            //DEFINE COMMAND
            LoadCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                Load();
            });
            OpenAddReportWindowCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                ReportAddWindow dba = new ReportAddWindow();
                ReportAddViewModel vm = new ReportAddViewModel(admin, -1,Reports);
                MaskName.Visibility = Visibility.Visible;
                vm.Mask = MaskName;
                dba.DataContext = vm;
                dba.ShowDialog();
            });
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });
            SaveCurrentPageCM = new RelayCommand<Page>((p) => { return true; }, async (p) =>
            {
                CurrentPage = p;
            });
            OpenEditReportPageCM = new RelayCommand<Page>((p) => { return SelectedItem != null; }, async (p) =>
            {
                ReportDetailViewModel vm = new ReportDetailViewModel(admin, SelectedItem);
                ReportDetailPage dashboardpage = new ReportDetailPage();
                dashboardpage.DataContext = vm;
                p.NavigationService.Navigate(dashboardpage);
            });
            DeleteReportCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this report?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();

                if (result.DialogResult == true)
                {
                    IsGettingSource = true;

                    (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.DeleteReport((int)SelectedItem.id);

                    IsGettingSource = false;

                    if (isSuccess)
                    {
                        for (int i = 0; i < Reports.Count; i++)
                        {
                            if (Reports[i].id == SelectedItem?.id)
                            {
                                Reports.Remove(Reports[i]);
                                break;
                            }
                        }
                        MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                    else
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", messageFromUpdate, MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                }
            });
        }
        public async Task Load()
        {
            try
            {
                IsGettingSource = true;
                Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReport());
                IsGettingSource = false;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                MessageBoxCustom mb = new MessageBoxCustom("Error", "Can not connect to the database!", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBoxCustom mb = new MessageBoxCustom("Error", "Sytem error!", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }
        }
    }
}
