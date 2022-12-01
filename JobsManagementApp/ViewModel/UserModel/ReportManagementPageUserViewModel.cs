using JobsManagementApp.Model;
using JobsManagementApp.Service;
using JobsManagementApp.View.Share;
using JobsManagementApp.ViewModel.ShareModel;
using JobsManagementApp.ViewModel.AdminModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace JobsManagementApp.ViewModel.UserModel
{
    public class ReportManagementPageUserViewModel : BaseViewModel
    {
        public UsersDTO user { get; set; }
        public int assigneeid { get; set; }
        public UsersDTO assignee { get; set; }
        private string _assigneeName;
        public string assigneeName
        {
            get { return _assigneeName; }
            set { _assigneeName = value; OnPropertyChanged(); }
        }
        private int _assigneeId;
        public int assigneeId
        {
            get { return _assigneeId; }
            set { _assigneeId = value; OnPropertyChanged(); }
        }
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
        public static Grid MaskName { get; set; }
        public ICommand OpenAddReportWindowCM { get; set; }
        public ICommand OpenEditReportPageCM { get; set; }
        public ICommand DeleteReportCM { get; set; }
        public ICommand MaskNameCM { get; set; }
        public ICommand LoadCM { get; set; }
        public ICommand GoBackCM { get; set; }
        public ReportManagementPageUserViewModel(UsersDTO a, int assignee_id)
        {

            user = new UsersDTO(a);
            assigneeid = assignee_id;

            //DEFINE COMMAND
            GoBackCM = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                p.NavigationService.GoBack();
            });
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();

            });
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });
            OpenAddReportWindowCM = new RelayCommand<object>((p) => { return assignee != null; }, async (p) =>
            {
                ReportAddWindow dba = new ReportAddWindow();
                ReportAddViewModel vm = new ReportAddViewModel(user, Reports, (int)assignee.id);
                MaskName.Visibility = Visibility.Visible;
                vm.Mask = MaskName;
                dba.DataContext = vm;
                dba.ShowDialog();
            });
            OpenEditReportPageCM = new RelayCommand<Page>((p) => { return SelectedItem != null; }, async (p) =>
            {
                ReportDetailViewModel vm = new ReportDetailViewModel(user, SelectedItem);
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
                assignee = await UserService.Ins.GetUser(assigneeid);

                if (assignee != null)
                {
                    Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByUserID("USER", (int)assignee.id));
                    assigneeId = (int)assignee.id;
                    assigneeName = assignee.name;
                }
                else
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Chosen staff is not exist!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }

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
