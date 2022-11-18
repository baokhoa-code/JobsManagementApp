using JobsManagementApp.View.General;
using JobsManagementApp.View.Admin;
using JobsManagementApp.View.User;
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
using JobsManagementApp.View.Admin.JobAssign;
using JobsManagementApp.View.Admin.Report;
using JobsManagementApp.View.Share;
using JobsManagementApp.View.Admin.Staff;
using System.Windows.Navigation;
using JobsManagementApp.ViewModel.AdminModel;

namespace JobsManagementApp.ViewModel.AdminModel
{
    public class MainWindowAdminViewModel : BaseViewModel
    {
        public Admin admin { get; set; }
        private string _SelectedFuncName;
        public string SelectedFuncName
        {
            get { return _SelectedFuncName; }
            set { _SelectedFuncName = value; OnPropertyChanged(); }
        }
        public ICommand MouseLeftButtonDownWindowCM { get; set; }
        public ICommand FirstLoadCM { get; set; }
        public ICommand LoadHomePageCM { get; set; }
        public ICommand LoadJobManagementPageCM { get; set; }
        public ICommand LoadJobAssignManagementPageCM { get; set; }
        public ICommand LoadStaffManagementPageCM { get; set; }
        public ICommand LoadReportManagementPageCM { get; set; }
        public ICommand LoadUserInfortPageCM { get; set; }
        public ICommand LogoutCM { get; set; }


        public MainWindowAdminViewModel()
        {
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
                SelectedFuncName = "Home";
                RadioButton b = (RadioButton) p;
                b.IsChecked = true;
            });
            LoadHomePageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Home";
                if (p != null)
                    p.Content = new HomePageAdmin();
            });
            LoadJobManagementPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Job Management";
                if (p != null)
                {
                    JobManagementPageAdmin jobPage = new JobManagementPageAdmin();
                    JobManagementPageAdminViewModel.admin = admin;
                    p.Content = jobPage;
                }

            });
            LoadJobAssignManagementPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Job Assign Management";
                if (p != null)
                    p.Content = new JobAssignManagementPageAdmin();
            });
            LoadStaffManagementPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Staff Management";
                if (p != null)
                {
                    StaffManagementPageAdmin staffpage = new StaffManagementPageAdmin();
                    StaffManagementPageAdminViewModel.admin = admin;
                    p.Content = staffpage;
                }
            });
            LoadReportManagementPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Report Management";
                ReportManagementPageAdminViewModel.admin = admin;
                if (p != null)
                    p.Content = new ReportManagementPageAdmin();
            });
            LoadUserInfortPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Report Management";
                //if (p != null)
                //    p.Content = new UserInformationPage();
            });
        }
    }
}
