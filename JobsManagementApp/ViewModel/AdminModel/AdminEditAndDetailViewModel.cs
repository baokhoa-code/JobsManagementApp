//foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
//{
//    string name = descriptor.Name;
//    object value = descriptor.GetValue(obj);
//    Console.WriteLine("{0}={1}", name, value);
//}
using JobsManagementApp.Model;
using JobsManagementApp.ViewModel.AdminModel;
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
using System.Text;

namespace JobsManagementApp.ViewModel.AdminModel
{
    public class AdminEditAndDetailViewModel : BaseViewModel
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
        private string _staffWorkedHour;
        public string staffWorkedHour
        {
            get { return _staffWorkedHour; }
            set { _staffWorkedHour = value; OnPropertyChanged(); }
        }
        private string _staffUserName;
        public string staffUserName
        {
            get { return _staffUserName; }
            set { _staffUserName = value; OnPropertyChanged(); }
        }
        private string _staffGender;
        public string staffGender
        {
            get { return _staffGender; }
            set { _staffGender = value; OnPropertyChanged(); }
        }
        private string _staffQuestion;
        public string staffQuestion
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
        private List<string> _Gender;
        public List<string> Gender
        {
            get { return _Gender; }
            set { _Gender = value; OnPropertyChanged(); }
        }
        private List<string> _Question;
        public List<string> Question
        {
            get { return _Question; }
            set { _Question = value; OnPropertyChanged(); }
        }
        #endregion

        #region Internal Vairables
        private Admin _admin;
        public Admin admin
        {
            get { return _admin; }
            set { _admin = value; OnPropertyChanged(); }
        }
        private Admin _Backupadmin;
        public Admin Backupadmin
        {
            get { return _Backupadmin; }
            set { _Backupadmin = value; OnPropertyChanged(); }
        }
        private DateTime _currentDate;
        public DateTime currentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; OnPropertyChanged(); }
        }
        public Grid Mask { get; set; }

        static MainWindowAdminViewModel mainw { get; set; }
        #endregion

        #region Command
        public ICommand LoadCM { get; set; }
        public ICommand EditStaffCM { get; set; }
        public ICommand OrganizationChangeCM { get; set; }
        public ICommand StaffDOBChangeCM { get; set; }
        public ICommand UpLoadImageCM { get; set; }
        public ICommand MoveToJobListCM { get; set; }
        public ICommand MoveToReportListCM { get; set; }
        public ICommand GoBackCM { get; set; }
        #endregion

        public AdminEditAndDetailViewModel(Admin a, MainWindowAdminViewModel main)
        {
            admin = new Admin();
            Backupadmin = a;
            mainw = main;
            currentDate = DateTime.Now;
            Gender = new List<string>();
            Gender.Add("NAM"); Gender.Add("NU"); Gender.Add("KHAC");
            Question = new List<string>();
            Question.Add("WHAT IS YOUR FAVORITE FOOD?"); Question.Add("WHAT IS THE NAME OF THE TOWN WHERE YOU WERE BORN?");
            Question.Add("WHAT IS THE NAME OF YOUR FIRST PET?"); Question.Add("WHAT WAS YOUR CHILDHOOD NICKNAME?");

            //DEFINE COMMAND
            LoadCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                Load();

            });
            EditStaffCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {

                if (string.IsNullOrEmpty(staffUserName))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin username cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    admin = new Admin();
                }
                else
                {
                    if (AdminService.Ins.CheckExisted(staffUserName) && staffUserName != Backupadmin.username)
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin username already existed!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        admin = new Admin();
                    }
                    else
                    {
                        admin.username = staffUserName;
                        if (string.IsNullOrEmpty(staffName.Trim()))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin name cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            admin = new Admin();
                        }
                        else
                        {
                            admin.name = staffName.Trim();
                            if (string.IsNullOrEmpty(staffEmail.Trim()))
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin email cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                admin = new Admin();
                            }
                            else
                            {
                                if (!IsValid(staffEmail.Trim()))
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin email is not valid!", MessageType.Error, MessageButtons.OK);
                                    mb.ShowDialog();
                                    admin = new Admin();
                                }
                                else
                                {
                                    admin.email = staffEmail.Trim();
                                    if (string.IsNullOrEmpty(staffPhone.Trim()))
                                    {
                                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin phone cannot be empty!", MessageType.Error, MessageButtons.OK);
                                        mb.ShowDialog();
                                        admin = new Admin();
                                    }
                                    else
                                    {
                                        if (!IsPhoneNbr(staffPhone.Trim()))
                                        {
                                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin phone is not valid!", MessageType.Error, MessageButtons.OK);
                                            mb.ShowDialog();
                                            admin = new Admin();
                                        }
                                        else
                                        {
                                            admin.phone = staffPhone.Trim();
                                            if (string.IsNullOrEmpty(staffAddress.Trim()))
                                            {
                                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin address cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                mb.ShowDialog();
                                                admin = new Admin();
                                            }
                                            else
                                            {
                                                admin.address = staffAddress.Trim();
                                                if (string.IsNullOrEmpty(staffGender))
                                                {
                                                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin gender cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                    mb.ShowDialog();
                                                    admin = new Admin();
                                                }
                                                else
                                                {
                                                    admin.gender = staffGender;
                                                    if (string.IsNullOrEmpty(staffQuestion))
                                                    {
                                                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin question cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                        mb.ShowDialog();
                                                        admin = new Admin();
                                                    }
                                                    else
                                                    {
                                                        admin.question = staffQuestion;
                                                        if (string.IsNullOrEmpty(staffAnswer.Trim()))
                                                        {
                                                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin answer cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                            mb.ShowDialog();
                                                            admin = new Admin();
                                                        }
                                                        else
                                                        {
                                                            admin.answer = staffAnswer.Trim();
                                                            if (string.IsNullOrEmpty(staffAvatar))
                                                            {
                                                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin avatar cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                                mb.ShowDialog();
                                                                admin = new Admin();
                                                            }
                                                            else
                                                            {
                                                                admin.avatar = staffAvatar;
                                                                if (staffDob == null)
                                                                {
                                                                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin day of birth cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                                    mb.ShowDialog();
                                                                    admin = new Admin();
                                                                }
                                                                else
                                                                {
                                                                    admin.dob = staffDob.ToString("dd-MM-yyyy");
                                                                    if (staffOrganization == null)
                                                                    {
                                                                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin organization cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                                        mb.ShowDialog();
                                                                        admin = new Admin();
                                                                    }
                                                                    else
                                                                    {
                                                                        admin.organization = staffOrganization.name;
                                                                        if (string.IsNullOrEmpty(staffWorkedHour))
                                                                        {
                                                                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin worked hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                                            mb.ShowDialog();
                                                                            admin = new Admin();
                                                                        }
                                                                        else
                                                                        {
                                                                            admin.total_working_hour = Int16.Parse(staffWorkedHour);
                                                                            if (staffPosition == null)
                                                                            {
                                                                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Admin position cannot be empty!", MessageType.Error, MessageButtons.OK);
                                                                                mb.ShowDialog();
                                                                                admin = new Admin();
                                                                            }
                                                                            else
                                                                            {
                                                                                admin.id = Backupadmin.id;
                                                                                admin.position = staffPosition.name;
                                                                                admin.pass = Backupadmin.pass;
                                                                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to update your admin profile?", MessageType.Warning, MessageButtons.YesNo);
                                                                                result.ShowDialog();

                                                                                if (result.DialogResult == true)
                                                                                {
                                                                                    try
                                                                                    {
                                                                                        (bool isSuccess, string messageFromUpdate) = await AdminService.Ins.UpdateAdmin(admin);
                                                                                        if (isSuccess)
                                                                                        {
                                                                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                                                                            mb.ShowDialog();
                                                                                            main.adminName = admin.name;
                                                                                            main.adminAvatar = admin.avatar;
                                                                                            main.adminAddress = admin.address;
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
            OrganizationChangeCM = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                ReloadPostion();
            });
            StaffDOBChangeCM = new RelayCommand<DatePicker>((p) => { return currentDate.Year - staffDob.Year < 20; }, async (p) =>
            {
                staffDob = DateTime.ParseExact(Backupadmin.dob, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);

            });
            UpLoadImageCM = new RelayCommand<DatePicker>((p) => { return true; }, (p) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    staffAvatar = openFileDialog.FileName;
                }
            });
            GoBackCM = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                p.NavigationService.GoBack();
            });
        }

        public async Task Load()
        {
            staffName = Backupadmin.name;
            staffAddress = Backupadmin.address;
            staffEmail = Backupadmin.email;
            staffPhone = Backupadmin.phone;
            staffAddress = Backupadmin.address;
            staffUserName = Backupadmin.username;
            staffAnswer = Backupadmin.answer;
            staffAvatar = Backupadmin.avatar;
            staffWorkedHour = Backupadmin.total_working_hour.ToString();
            staffDob = DateTime.ParseExact(Backupadmin.dob, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);

            try
            {
                OrganizationSource = new ObservableCollection<OrganizationsDTO>(await OrganizationAndPositionService.Ins.GetAllOrganization());
                for (int i = 0; i < OrganizationSource.Count; i++)
                {
                    if (OrganizationSource[i].name == Backupadmin.organization)
                    {
                        staffOrganization = OrganizationSource[i];
                        i = OrganizationSource.Count;
                    }
                }
                PositionSource = new ObservableCollection<PositionsDTO>(await OrganizationAndPositionService.Ins.GetAllPositionByOrganName(Backupadmin.organization));
                for (int i = 0; i < PositionSource.Count; i++)
                {
                    if (PositionSource[i].name == Backupadmin.position)
                    {
                        staffPosition = PositionSource[i];
                        i = PositionSource.Count;
                    }
                }
                for (int i = 0; i < Gender.Count; i++)
                {
                    if (Gender[i] == Backupadmin.gender)
                    {
                        staffGender = Gender[i];
                        i = Gender.Count;
                    }
                }
                for (int i = 0; i < Question.Count; i++)
                {
                    if (Question[i] == Backupadmin.question)
                    {
                        staffQuestion = Question[i];
                        i = Question.Count;
                    }
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
