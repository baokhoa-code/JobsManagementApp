using JobsManagementApp.View.Admin;
using JobsManagementApp.View.User;
using JobsManagementApp.View.Share; 
using JobsManagementApp.View.General;
using JobsManagementApp.Model;
using JobsManagementApp.ViewModel.AdminModel;
using JobsManagementApp.ViewModel.UserModel;
using JobsManagementApp.Service;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
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
        public ICommand ForgotPasswordChangedCM { get; set; }
        public ICommand UserNameChangedCM { get; set; }
        public ICommand ChangePasswordCM { get; set; }

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
        private string _userForgotName;
        public string userForgotName
        {
            get { return _userForgotName; }
            set { _userForgotName = value; OnPropertyChanged(); }
        }
        private string _userForgotQuestion;
        public string userForgotQuestion
        {
            get { return _userForgotQuestion; }
            set { _userForgotQuestion = value; OnPropertyChanged(); }
        }
        private string _userForgotAnswer;
        public string userForgotAnswer
        {
            get { return _userForgotAnswer; }
            set { _userForgotAnswer = value; OnPropertyChanged(); }
        }
        private string _userForgotNewPassword;
        public string userForgotNewPassword
        {
            get { return _userForgotNewPassword; }
            set { _userForgotNewPassword = value; OnPropertyChanged(); }
        }
        private Admin _forgotAdmin;
        public Admin forgotAdmin
        {
            get { return _forgotAdmin; }
            set { _forgotAdmin = value; OnPropertyChanged(); }
        }
        private UsersDTO _forgotUser;
        public UsersDTO forgotUser
        {
            get { return _forgotUser; }
            set { _forgotUser = value; OnPropertyChanged(); }
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
                forgotAdmin = null;
                forgotUser = null;
                userForgotAnswer = "";
                userForgotNewPassword = "";
                userForgotName = "";
                userForgotQuestion = "";
                SelectedRole = null;
                LoginViewModel.MainFrame.Content = new LoginPage();
            });
            LoadLoginPageCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame = p;
                p.Content = new LoginPage();
            });
            ForgotPassCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (SelectedRole is null)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Warning", "Please choose your role!", MessageType.Warning, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    MainFrame.Content = new ForgotPage();
                }
                
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
            ForgotPasswordChangedCM = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                userForgotNewPassword = p.Password;
            });
            UserNameChangedCM = new RelayCommand<TextBox>((p) => { return true; }, async (p) =>
            {
                userForgotName = p.Text;
                if (SelectedRole.Content.ToString() == "Admin")
                {
                    forgotAdmin = null;
                    forgotUser = null;
                    userForgotAnswer = "";
                    userForgotNewPassword = "";
                    if (!string.IsNullOrEmpty(userForgotName))
                    {
                        try
                        {
                            forgotAdmin = await AdminService.Ins.GetAdminByUsername(userForgotName);
                        if (forgotAdmin is null)
                            userForgotQuestion = "Username is not exist, question cannot found!";
                        else
                            userForgotQuestion = forgotAdmin.question;
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
                    else
                        userForgotQuestion = "";
                }
                else
                {
                    forgotAdmin = null;
                    forgotUser = null;
                    userForgotAnswer = "";
                    userForgotNewPassword = "";

                    if (!string.IsNullOrEmpty(userForgotName))
                    {
                        try
                        {
                            forgotUser = await UserService.Ins.GetUserByUsername(userForgotName);
                            if (forgotUser is null)
                                userForgotQuestion = "Username is not exist, question cannot found!";
                            else
                                userForgotQuestion = forgotUser.question;
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
                    else
                        userForgotQuestion = "";
                }
                
            }); 
            ChangePasswordCM = new RelayCommand<object>((p) => { return userForgotQuestion != "Username is not exist, question cannot found!"; }, async (p) =>
            {

                if (string.IsNullOrEmpty(userForgotName))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Username cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    if (userForgotQuestion.Equals("Username is not exist, question cannot found!"))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Username is not exist!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(userForgotQuestion))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Question cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(userForgotAnswer))
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Answer cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                            }
                            else
                            {
                                if ((forgotAdmin != null && !forgotAdmin.answer.Equals(userForgotAnswer)) || (forgotUser != null && !forgotUser.answer.Equals(userForgotAnswer)))
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Incorrect answer!", MessageType.Error, MessageButtons.OK);
                                    mb.ShowDialog();
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(userForgotNewPassword))
                                    {
                                        MessageBoxCustom mb = new MessageBoxCustom("Error", "New password cannot be empty!", MessageType.Error, MessageButtons.OK);
                                        mb.ShowDialog();
                                    }
                                    else
                                    {
                                        MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you really want to change your password?", MessageType.Warning, MessageButtons.YesNo);
                                        result.ShowDialog();

                                        if (result.DialogResult == true)
                                        {
                                            try
                                            {
                                                bool isSuccess = false;
                                                string messageFromUpdate = "Error";

                                                if (SelectedRole.Content.ToString() == "Admin")
                                                {
                                                    string M5Pass = GetMD5Password(userForgotNewPassword);
                                                    userForgotNewPassword = M5Pass;
                                                    (isSuccess, messageFromUpdate) = await AdminService.Ins.ChangePassword(userForgotName, userForgotNewPassword);
                                                }
                                                else
                                                {
                                                    string M5Pass = GetMD5Password(userForgotNewPassword);
                                                    userForgotNewPassword = M5Pass;
                                                    (isSuccess, messageFromUpdate) = await UserService.Ins.ChangePassword(userForgotName, userForgotNewPassword);
                                                }
                                                if (isSuccess)
                                                {
                                                    MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                                    mb.ShowDialog();
                                                }
                                                else
                                                {
                                                    MessageBoxCustom mb = new MessageBoxCustom("Error", messageFromUpdate, MessageType.Error, MessageButtons.OK);
                                                    mb.ShowDialog();
                                                }
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

                                
                            }
                        }
                    }
                    
                }
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
                        string M5Pass = GetMD5Password(pwr);
                        try
                        {
                            (admin, message) = AdminService.Ins.Login(usn, M5Pass);
                            if (admin == null)
                            {
                                lbl.Content = message;
                                return;
                            }
                            else
                            {
                                MainWindowAdmin dba = new MainWindowAdmin();
                                MainWindowAdminViewModel vm = new MainWindowAdminViewModel(admin);
                                dba.DataContext = vm;
                                dba.Show();
                                Password = "";
                                Username = "";
                                SelectedRole = null;
                                LoginWindow.Close();
                                return;
                            }
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
                    else
                    {
                        UsersDTO user;
                        string message;
                        string M5Pass = GetMD5Password(pwr);
                        try
                        {
                            (user, message) = UserService.Ins.Login(usn, M5Pass);
                            if (user == null)
                            {
                                lbl.Content = message;
                                return;
                            }
                            else
                            {
                                MainWindowUser dba = new MainWindowUser();
                                MainWindowUserViewModel vm = new MainWindowUserViewModel(user);
                                dba.DataContext = vm;
                                dba.Show();
                                Password = "";
                                Username = "";
                                SelectedRole = null;
                                LoginWindow.Close();
                                return;
                            }
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
        }

        public string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
        public string GetMD5Password(string s)
        {
            byte[] tmpHash_t;
            string pass = "";
            tmpHash_t = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(s));
            pass = ByteArrayToString(tmpHash_t);
            return pass;
        }
    }
}
