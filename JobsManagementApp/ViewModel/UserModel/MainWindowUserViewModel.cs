using JobsManagementApp.View.General;
using JobsManagementApp.View.Admin;
using JobsManagementApp.View.User;
using JobsManagementApp.View.User.DashBoard;
using JobsManagementApp.View.User.Job;
using JobsManagementApp.View.User.Report;
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

namespace JobsManagementApp.ViewModel.UserModel
{
    public class MainWindowUserViewModel : BaseViewModel
    {
        private UsersDTO _user;
        public UsersDTO user
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }
        private string _userName;
        public string userName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }

        private string _userAddress;
        public string userAddress
        {
            get { return _userAddress; }
            set { _userAddress = value; OnPropertyChanged(); }
        }
        private string _userAvatar;
        public string userAvatar
        {
            get { return _userAvatar; }
            set { _userAvatar = value; OnPropertyChanged(); }
        }

        public ICommand MouseLeftButtonDownWindowCM { get; set; }
        public ICommand FirstLoadCM { get; set; }
        public ICommand LoadDashBoardPageCM { get; set; }
        public ICommand LoadJobManagementPageCM { get; set; }
        public ICommand LoadReportManagementPageCM { get; set; }
        public ICommand LoadUserInfortPageCM { get; set; }
        public ICommand LogoutCM { get; set; }


        public MainWindowUserViewModel(UsersDTO a)
        {
            user = a;
            userName = a.name;
            userAddress = a.address;
            userAvatar = a.avatar;
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
                RadioButton b = (RadioButton)p;
                b.IsChecked = true;
            });
            LoadDashBoardPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (p != null)
                {
                    DashBoardPageUserViewModel vm = new DashBoardPageUserViewModel(user);
                    DashBoardPageUser dashboardpage = new DashBoardPageUser();
                    dashboardpage.DataContext = vm;
                    p.Content = dashboardpage;
                }
            });
            LoadJobManagementPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (p != null)
                {
                    JobManagementPageUser dba = new JobManagementPageUser();
                    JobManagementPageUserViewModel vm = new JobManagementPageUserViewModel(user, (int)user.id);
                    dba.DataContext = vm;
                    p.NavigationService.Navigate(dba);
                }

            });
            LoadReportManagementPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (p != null)
                {
                    ReportManagementPageUser dba = new ReportManagementPageUser();
                    ReportManagementPageUserViewModel vm = new ReportManagementPageUserViewModel(user, (int)user.id);
                    dba.DataContext = vm;
                    p.NavigationService.Navigate(dba);
                }
            });
            LoadUserInfortPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                UserInformationPage dba = new UserInformationPage();
                UserEditAndDetailViewModel vm = new UserEditAndDetailViewModel(user, this);
                dba.DataContext = vm;
                if (p != null)
                    p.Content = dba;
            });
        }
    }
}
