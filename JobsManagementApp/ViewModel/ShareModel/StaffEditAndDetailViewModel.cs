//foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
//{
//    string name = descriptor.Name;
//    object value = descriptor.GetValue(obj);
//    Console.WriteLine("{0}={1}", name, value);
//}
using JobsManagementApp.Model;
using JobsManagementApp.Service;
using JobsManagementApp.View.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using System.Data;
using System.ComponentModel;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace JobsManagementApp.ViewModel.ShareModel
{
    public class StaffEditAndDetailViewModel : BaseViewModel
    {

        #region Binding Varirables

        private string _staffName;
        public string staffName
        {
            get { return _staffName; }
            set { _staffName = value; OnPropertyChanged(); }
        }
        private string _staffEmail;
        public string staffEmail
        {
            get { return _staffEmail; }
            set { _staffEmail = value; OnPropertyChanged(); }
        }
        private string _staffAddress;
        public string staffAddress
        {
            get { return _staffAddress; }
            set { _staffAddress = value; OnPropertyChanged(); }
        }
        private string _staffPhone;
        public string staffPhone
        {
            get { return _staffPhone; }
            set { _staffPhone = value; OnPropertyChanged(); }
        }
        private string _staffUserName;
        public string staffUserName
        {
            get { return _staffUserName; }
            set { _staffUserName = value; OnPropertyChanged(); }
        }
        private ComboBoxItem _staffGender;
        public ComboBoxItem staffGender
        {
            get { return _staffGender; }
            set { _staffGender = value; OnPropertyChanged(); }
        }
        private ComboBoxItem _staffQuestion;
        public ComboBoxItem staffQuestion
        {
            get { return _staffQuestion; }
            set { _staffQuestion = value; OnPropertyChanged(); }
        }
        private string _staffAnswer;
        public string staffAnswer
        {
            get { return _staffAnswer; }
            set { _staffAnswer = value; OnPropertyChanged(); }
        }
        private string _staffAvatar;
        public string staffAvatar
        {
            get { return _staffAvatar; }
            set { _staffAvatar = value; OnPropertyChanged(); }
        }
        private string _staffPas;
        public string staffPas
        {
            get { return _staffPas; }
            set { _staffPas = value; OnPropertyChanged(); }
        }
        private DateTime _staffDob;
        public DateTime staffDob
        {
            get { return _staffDob; }
            set { _staffDob = value; OnPropertyChanged(); }
        }
        private OrganizationsDTO _staffOrganization;
        public OrganizationsDTO staffOrganization
        {
            get { return _staffOrganization; }
            set { _staffOrganization = value; OnPropertyChanged(); }
        }
        private ObservableCollection<OrganizationsDTO> _OrganizationSource;
        public ObservableCollection<OrganizationsDTO> OrganizationSource
        {
            get { return _OrganizationSource; }
            set { _OrganizationSource = value; OnPropertyChanged(); }
        }
        private PositionsDTO _staffPosition;
        public PositionsDTO staffPosition
        {
            get { return _staffPosition; }
            set { _staffPosition = value; OnPropertyChanged(); }
        }
        private ObservableCollection<PositionsDTO> _PositionSource;
        public ObservableCollection<PositionsDTO> PositionSource
        {
            get { return _PositionSource; }
            set { _PositionSource = value; OnPropertyChanged(); }
        }
        #endregion

        #region Internal Vairables
        public Admin admin { get; set; }
        private UsersDTO _staff;
        public UsersDTO staff
        {
            get { return _staff; }
            set { _staff = value; OnPropertyChanged(); }
        }
        private UsersDTO _Storestaff;
        public UsersDTO Storestaff
        {
            get { return _Storestaff; }
            set { _Storestaff = value; OnPropertyChanged(); }
        }
        private DateTime _currentDate;
        public DateTime currentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; OnPropertyChanged(); }
        }
        public Grid Mask { get; set; }
        #endregion

        #region Command
        public ICommand LoadCM { get; set; }
        public ICommand AddStaffCM { get; set; }
        public ICommand StaffCM { get; set; }
        public ICommand BackupInforCM { get; set; }
        public ICommand PasswordChangedCM { get; set; }
        public ICommand OrganizationChangeCM { get; set; }
        public ICommand StaffDOBChangeCM { get; set; }
        public ICommand UpLoadImageCM { get; set; }
        public ICommand CloseWindowCM { get; set; }
        #endregion

        public StaffEditAndDetailViewModel(Admin a, UsersDTO staff_t)
        {
            admin = new Admin(a);
            Storestaff = new UsersDTO(staff_t);
            staff = new UsersDTO();
            currentDate = DateTime.Now;
            


            //DEFINE COMMAND
            LoadCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                Load();

            });
            AddStaffCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(staffUserName))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff username cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    staff = new UsersDTO();
                }
                else
                {
                    if (UserService.Ins.CheckExisted(staffUserName))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff username already existed!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        staff = new UsersDTO();
                    }
                    else
                    {
                        staff.username = staffUserName;
                        if (string.IsNullOrEmpty(staffName.Trim()))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff name cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            staff = new UsersDTO();
                        }
                        else
                        {
                            staff.name = staffName.Trim();
                            if (string.IsNullOrEmpty(staffEmail.Trim()))
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff email cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                staff = new UsersDTO();
                            }
                            else
                            {
                                if (!IsValid(staffEmail.Trim()))
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff email is not valid!", MessageType.Error, MessageButtons.OK);
                                    mb.ShowDialog();
                                    staff = new UsersDTO();
                                }
                                else
                                {
                                    staff.email = staffEmail.Trim();
                                    if (string.IsNullOrEmpty(staffPhone.Trim()))
                                    {
                                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff phone cannot be empty!", MessageType.Error, MessageButtons.OK);
                                        mb.ShowDialog();
                                        staff = new UsersDTO();
                                    }
                                    else
                                    {
                                        if (!IsPhoneNbr(staffPhone.Trim()))
                                        {
                                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff phone is not valid!", MessageType.Error, MessageButtons.OK);
                                            mb.ShowDialog();
                                            staff = new UsersDTO();
                                        }
                                        else
                                        {
                                            staff.phone = staffPhone.Trim();
                                            if (string.IsNullOrEmpty(staffAddress.Trim()))
                                            {
                                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff address cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                mb.ShowDialog();
                                                staff = new UsersDTO();
                                            }
                                            else
                                            {
                                                staff.address = staffAddress.Trim();
                                                if (staffGender == null)
                                                {
                                                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff gender cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                    mb.ShowDialog();
                                                    staff = new UsersDTO();
                                                }
                                                else
                                                {
                                                    staff.gender = (string?)staffGender.Content;
                                                    if (staffQuestion == null)
                                                    {
                                                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff question cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                        mb.ShowDialog();
                                                        staff = new UsersDTO();
                                                    }
                                                    else
                                                    {
                                                        staff.question = (string?)staffQuestion.Content;
                                                        if (string.IsNullOrEmpty(staffAnswer.Trim()))
                                                        {
                                                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff answer cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                            mb.ShowDialog();
                                                            staff = new UsersDTO();
                                                        }
                                                        else
                                                        {
                                                            staff.answer = staffAnswer.Trim();
                                                            if (string.IsNullOrEmpty(staffPas.Trim()))
                                                            {
                                                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff password cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                                mb.ShowDialog();
                                                                staff = new UsersDTO();
                                                            }
                                                            else
                                                            {
                                                                staff.pass = staffPas.Trim();
                                                                if (string.IsNullOrEmpty(staffAvatar))
                                                                {
                                                                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff avatar cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                                    mb.ShowDialog();
                                                                    staff = new UsersDTO();
                                                                }
                                                                else
                                                                {
                                                                    staff.avatar = staffAvatar;
                                                                    if (staffDob == null)
                                                                    {
                                                                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff day of birth cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                                        mb.ShowDialog();
                                                                        staff = new UsersDTO();
                                                                    }
                                                                    else
                                                                    {
                                                                        staff.dob = staffDob.ToString("dd-MM-yyyy");
                                                                        if (staffOrganization == null)
                                                                        {
                                                                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff organization cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                                            mb.ShowDialog();
                                                                            staff = new UsersDTO();
                                                                        }
                                                                        else
                                                                        {
                                                                            staff.organization = staffOrganization.name;
                                                                            if (staffPosition == null)
                                                                            {
                                                                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Staff position cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                                                mb.ShowDialog();
                                                                                staff = new UsersDTO();
                                                                            }
                                                                            else
                                                                            {
                                                                                staff.position = staffPosition.name;
                                                                                staff.total_working_hour = 0;
                                                                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this job?", MessageType.Warning, MessageButtons.YesNo);
                                                                                result.ShowDialog();

                                                                                if (result.DialogResult == true)
                                                                                {
                                                                                    try
                                                                                    {
                                                                                        (bool isSuccess, string messageFromUpdate) = await UserService.Ins.AddUser(staff);
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
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }


                }

            });
            BackupInforCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                staff = new UsersDTO();
                staffName = "";
                staffUserName = "";
                staffName = "";
                staffOrganization = new OrganizationsDTO();
                staffPosition = new PositionsDTO();
                staffEmail = "";
                staffAddress = "";
                staffPhone = "";
                staffAvatar = "";
                staffGender = null;
                staffDob = currentDate.AddYears(-20);
                staffQuestion = null;
                staffAnswer = "";
                staffPas = "";

            });
            CloseWindowCM = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                staff = new UsersDTO();
                staffName = "";
                staffUserName = "";
                staffOrganization = new OrganizationsDTO();
                staffPosition = new PositionsDTO();
                staffEmail = "";
                staffAddress = "";
                staffPhone = "";
                staffAvatar = "";
                staffGender = null;
                staffDob = currentDate.AddYears(-20);
                staffQuestion = null;
                staffAnswer = "";
                staffPas = "";
                if (Mask != null)
                    Mask.Visibility = Visibility.Collapsed;
                p.Close();
            });
            PasswordChangedCM = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                staffPas = p.Password;

            });
            OrganizationChangeCM = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                ReloadPostion();
            });
            StaffDOBChangeCM = new RelayCommand<DatePicker>((p) => { return currentDate.Year - staffDob.Year < 20; }, async (p) =>
            {
                staffDob = currentDate.AddYears(-20);

            });
            UpLoadImageCM = new RelayCommand<DatePicker>((p) => { return true; }, (p) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    staffAvatar = openFileDialog.FileName;
                }
            });
        }

        public async Task Load()
        {
            staffAddress = Storestaff.address;
            staffAnswer = Storestaff.answer;
            staffAvatar = Storestaff.avatar;
            staffDob = DateTime.ParseExact(Storestaff.dob, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            try
            {
                OrganizationSource = new ObservableCollection<OrganizationsDTO>(await OrganizationAndPositionService.Ins.GetAllOrganization());

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
        public async Task ReloadPostion()
        {
            try
            {
                if (staffOrganization != null)
                    PositionSource = new ObservableCollection<PositionsDTO>(await OrganizationAndPositionService.Ins.GetAllPositionByOrganName(staffOrganization.name));
                else
                    PositionSource = new ObservableCollection<PositionsDTO>();

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
        private static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
        public static bool IsPhoneNbr(string number)
        {
            string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            if (number != null) return Regex.IsMatch(number, motif);
            else return false;
        }

    }
}
