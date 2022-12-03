using JobsManagementApp.View.General;
using JobsManagementApp.View.Admin;
using JobsManagementApp.View.User;
using JobsManagementApp.View.Admin.Statistic;
using JobsManagementApp.ViewModel.GeneralModel;
using JobsManagementApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using JobsManagementApp.Model;
using JobsManagementApp.View.Admin.DashBoard;
using JobsManagementApp.View.Admin.Job;
using JobsManagementApp.View.Admin.Report;
using JobsManagementApp.View.Share;
using JobsManagementApp.View.Admin.Staff;
using System.Windows.Navigation;
using JobsManagementApp.ViewModel.AdminModel;
using System.Security.Cryptography;
using JobsManagementApp.ViewModel.ShareModel;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace JobsManagementApp.ViewModel.AdminModel
{
    public class MainWindowAdminViewModel : BaseViewModel
    {
        private Admin _admin;
        public Admin admin
        {
            get { return _admin; }
            set { _admin = value; OnPropertyChanged(); }
        }
        private string _adminName;
        public string adminName
        {
            get { return _adminName; }
            set { _adminName = value; OnPropertyChanged(); }
        }

        private string _adminAddress;
        public string adminAddress
        {
            get { return _adminAddress; }
            set { _adminAddress = value; OnPropertyChanged(); }
        }
        private string _adminAvatar;
        public string adminAvatar
        {
            get { return _adminAvatar; }
            set { _adminAvatar = value; OnPropertyChanged(); }
        }

        public ICommand MouseLeftButtonDownWindowCM { get; set; }
        public ICommand FirstLoadCM { get; set; }
        public ICommand LoadDashBoardPageCM { get; set; }
        public ICommand LoadJobManagementPageCM { get; set; }
        public ICommand LoadStaffManagementPageCM { get; set; }
        public ICommand LoadReportManagementPageCM { get; set; }
        public ICommand LoadStatisticPageCM { get; set; }
        public ICommand LoadUserInfortPageCM { get; set; }
        public ICommand LogoutCM { get; set; }


        public MainWindowAdminViewModel(Admin a)
        {
            admin = a;
            adminName = a.name;
            adminAddress = a.address;
            adminAvatar = a.avatar;
            MouseLeftButtonDownWindowCM = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    p.DragMove();
                }
            });
            LogoutCM = new RelayCommand<FrameworkElement>((p) => { return p == null ? false : true; }, (p) =>
            {
                var w = p as Window;
                if (w != null)
                {
                    w.Hide();
                    LoginWindow w1 = new LoginWindow();
                    w1.ShowDialog();
                    w.Close();
                }
            });
            FirstLoadCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                RadioButton b = (RadioButton) p;
                b.IsChecked = true;
            });
            LoadDashBoardPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (p != null)
                {
                    DashBoardPageAdminViewModel vm = new DashBoardPageAdminViewModel(admin);
                    DashBoardPageAdmin dashboardpage = new DashBoardPageAdmin();
                    dashboardpage.DataContext = vm;
                    p.Content = dashboardpage;
                }
            });
            LoadJobManagementPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (p != null)
                {
                    JobManagementPageAdminViewModel vm = new JobManagementPageAdminViewModel(admin);
                    JobManagementPageAdmin dashboardpage = new JobManagementPageAdmin();
                    dashboardpage.DataContext = vm;
                    p.Content = dashboardpage;
                }

            });
            LoadStaffManagementPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (p != null)
                {
                    StaffManagementPageAdminViewModel vm = new StaffManagementPageAdminViewModel(admin);
                    StaffManagementPageAdmin staffpage = new StaffManagementPageAdmin();
                    staffpage.DataContext = vm;
                    p.Content = staffpage;
                }
            });
            LoadReportManagementPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                ReportManagementPageAdminViewModel vm = new ReportManagementPageAdminViewModel(admin);
                ReportManagementPageAdmin reportMangementPage = new ReportManagementPageAdmin();
                reportMangementPage.DataContext = vm;
                p.Content = reportMangementPage;
            });
            LoadStatisticPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (p != null)
                {
                    p.Content = new StatisticPage();
                }
            });
            LoadUserInfortPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                UserInformationPage dba = new UserInformationPage();
                AdminEditAndDetailViewModel vm = new AdminEditAndDetailViewModel(admin,this);
                dba.DataContext = vm;
                if (p != null)
                    p.Content = dba;
            });
        }
    }
}
