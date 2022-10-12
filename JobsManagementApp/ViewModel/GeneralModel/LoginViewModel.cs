using JobsManagementApp.View.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace JobsManagementApp.ViewModel.GeneralModel
{
    public class LoginViewModel : BaseViewModel
    {

        public ICommand LoadLoginPageCM { get; set; }
        public static Frame MainFrame { get; set; }
        public ICommand ForgotPassCM { get; set; }
        public ICommand CancelCM { get; set; }

        public LoginViewModel()
        {
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
        }
    }
}
