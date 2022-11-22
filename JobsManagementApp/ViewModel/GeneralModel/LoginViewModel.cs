using JobsManagementApp.View.General;
using JobsManagementApp.View.Admin;
using JobsManagementApp.View.User;
using JobsManagementApp.Service;
using JobsManagementApp.ViewModel.AdminModel;
using JobsManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using JobsManagementApp.View.Share;
using JobsManagementApp.ViewModel.ShareModel;

namespace JobsManagementApp.ViewModel.GeneralModel
{
    public class LoginViewModel : BaseViewModel
    {
        public Button LoginBtn { get; set; }

        public ICommand LoadLoginPageCM { get; set; }
        public ICommand MouseLeftButtonDownWindowCM { get; set; }
        public Window LoginWindow { get; set; }
        public static Frame? MainFrame { get; set; }
        public ICommand ForgotPassCM { get; set; }
        public ICommand CancelCM { get; set; }
        public ICommand SaveLoginBtnCM { get; set; }
        public ICommand LoginCM { get; set; }
        public ICommand PasswordChangedCM { get; set; }
        public ICommand SaveLoginWindowNameCM { get; set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }
        private bool isloadding;
        public bool IsLoading
        {
            get { return isloadding; }
            set { isloadding = value; OnPropertyChanged(); }
        }

        private ComboBoxItem _SelectedRole;

        public ComboBoxItem SelectedRole
        {
            get { return _SelectedRole; }
            set { _SelectedRole = value; OnPropertyChanged(); }
        }

        public LoginViewModel()
        {
            MouseLeftButtonDownWindowCM = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    p.DragMove();
                }
            });
            CancelCM = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                LoginViewModel.MainFrame.Content = new LoginPage();
            });
            LoadLoginPageCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame = p;
                p.Content = new LoginPage();
            });
            ForgotPassCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                MainFrame.Content = new ForgotPage();
            });
            SaveLoginBtnCM = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                LoginBtn = p;
            });
            SaveLoginWindowNameCM = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                LoginWindow = p;
            });
            PasswordChangedCM = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;
            });
            LoginCM = new RelayCommand<Label>((p) => { return true; }, async (p) =>
            {
                string username = Username;
                string password = Password;

                IsLoading = true;

                CheckValidateAccount(username, password, p);

                IsLoading = false;
            });
        }
        public void CheckValidateAccount(string usn, string pwr, Label lbl)
        {

            if (string.IsNullOrEmpty(usn) || string.IsNullOrEmpty(pwr))
            {
                lbl.Content = "Please enter all field";
                return;
            }
            else
            {
                if (SelectedRole is null)
                {
                    lbl.Content = "Please choose your role";
                    return;
                }
                else
                {
                    if (SelectedRole.Content.ToString() == "Admin") 
                    {

                        Admin admin;
                        string message;
                        (admin, message) = AdminService.Ins.Login(usn, pwr);
                        if (admin == null)
                        {
                            lbl.Content = message;
                            return;
                        }
                        else
                        {
                            MainWindowAdmin dba = new MainWindowAdmin();
                            MainWindowAdminViewModel vm = new MainWindowAdminViewModel();
                            vm.admin = admin;
                            dba.DataContext = vm;
                            dba.img_avatar.ImageSource = new BitmapImage(new Uri(admin.avatar, UriKind.Relative));
                            dba.Show();
                            LoginWindow.Close();
                            return;
                        }

                    }
                    else
                    {
                        UsersDTO user;
                        string message;
                        (user, message) = UserService.Ins.Login(usn, pwr);
                        if (user == null)
                        {
                            lbl.Content = message;
                            return;
                        }
                        else
                        {
                            LoginWindow.Hide();
                            DashBoardUser dbu = new DashBoardUser();
                            dbu.Show();
                            LoginWindow.Close();
                            return;
                        }
                    }
                }

               
            }
        }
    }
}
