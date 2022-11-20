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
using JobsManagementApp.View.Admin.Report;
using JobsManagementApp.View.Share;
using JobsManagementApp.View.Admin.Staff;
using System.Windows.Navigation;
using JobsManagementApp.ViewModel.AdminModel;
using System.Security.Cryptography;
using JobsManagementApp.ViewModel.ShareModel;

namespace JobsManagementApp.ViewModel.AdminModel
{
    public class MainWindowAdminViewModel : BaseViewModel
    {
        public Admin admin { get; set; }

        public ICommand MouseLeftButtonDownWindowCM { get; set; }
        public ICommand FirstLoadCM { get; set; }
        public ICommand LoadDashBoardPageCM { get; set; }
        public ICommand LoadJobManagementPageCM { get; set; }
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
                    //JobListForSingleAssigneeViewModel vm = new JobListForSingleAssigneeViewModel(admin,1);
                    //JobListForSingleAssignee jobforsingleassignee = new JobListForSingleAssignee();
                    //jobforsingleassignee.DataContext = vm;
                    //p.Content = jobforsingleassignee;
                    JobManagementPageAdmin jobPage = new JobManagementPageAdmin();
                    JobManagementPageAdminViewModel.admin = admin;
                    p.Content = jobPage;
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
                //ReportListForSingleAssigneeViewModel vm = new ReportListForSingleAssigneeViewModel(admin, 1);
                //ReportListForSingleAssignee reportListForSingleAssignee = new ReportListForSingleAssignee();
                //reportListForSingleAssignee.DataContext = vm;
                //p.Content = reportListForSingleAssignee;
                ReportManagementPageAdminViewModel.admin = admin;
                if (p != null)
                    p.Content = new ReportManagementPageAdmin();
            });
            LoadUserInfortPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                //if (p != null)
                //    p.Content = new UserInformationPage();
            });
        }
    }
}
