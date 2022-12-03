using JobsManagementApp.Model;
using JobsManagementApp.Service;
using JobsManagementApp.View.Share;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using JobsManagementApp.ViewModel.ShareModel;

namespace JobsManagementApp.ViewModel.AdminModel
{
    public class StaffManagementPageAdminViewModel : BaseViewModel
    {
        public Admin admin { get; set; }
        private bool _IsGettingSource;
        public bool IsGettingSource
        {
            get { return _IsGettingSource; }
            set { _IsGettingSource = value; OnPropertyChanged(); }
        }
        private ObservableCollection<OrganizationsDTO> _OrganizationSource;
        public ObservableCollection<OrganizationsDTO> OrganizationSource
        {
            get { return _OrganizationSource; }
            set { _OrganizationSource = value; OnPropertyChanged(); }
        }
        private ObservableCollection<PositionsDTO> _PositionSource;
        public ObservableCollection<PositionsDTO> PositionSource
        {
            get { return _PositionSource; }
            set { _PositionSource = value; OnPropertyChanged(); }
        }
        public static Grid MaskName { get; set; }
        private ObservableCollection<UsersDTO> _Staffs;
        public ObservableCollection<UsersDTO> Staffs
        {

            get => _Staffs;
            set
            {
                _Staffs = value;
                OnPropertyChanged();
            }
        }
        private UsersDTO _SelectedItem;
        public UsersDTO SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }
        private OrganizationsDTO _SelectedItem2;
        public OrganizationsDTO SelectedItem2
        {
            get { return _SelectedItem2; }
            set { _SelectedItem2 = value; OnPropertyChanged(); }
        }
        private PositionsDTO _SelectedItem3;
        public PositionsDTO SelectedItem3
        {
            get { return _SelectedItem3; }
            set { _SelectedItem3 = value; OnPropertyChanged(); }
        }
        private OrganizationsDTO _CurrentOrganization;
        public OrganizationsDTO CurrentOrganization
        {
            get { return _CurrentOrganization; }
            set { _CurrentOrganization = value; OnPropertyChanged(); }
        }
        public ObservableCollection<UsersDTO> StaffsStore { get; set; }
        private Page _CurrentPage;
        public Page CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; OnPropertyChanged(); }
        }
        public ICommand MaskNameCM { get; set; }
        public ICommand OpenAddStaffWindowCM { get; set; }
        public ICommand OpenEditStaffCM { get; set; }
        public ICommand OrganizationChangeCM { get; set; }
        public ICommand DeleteStaffCM { get; set; }
        public ICommand DeleteOrganizationCM { get; set; }
        public ICommand DeletePositionCM { get; set; }
        public ICommand AddPositionCM { get; set; }
        public ICommand AddOrganizationCM { get; set; }
        public ICommand SaveCurrentPageCM { get; set; }
        public ICommand LoadCM { get; set; }
        public ICommand RefreshCM { get; set; }
        public StaffManagementPageAdminViewModel(Admin a)
        {
            admin = new Admin(a);
            OrganizationSource = new ObservableCollection<OrganizationsDTO>();
            PositionSource = new ObservableCollection<PositionsDTO>();

            //DEFINE COMMAND
            OpenAddStaffWindowCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                StaffAddWindow dba = new StaffAddWindow();
                StaffAddViewModel vm = new StaffAddViewModel(admin, Staffs);
                vm.Mask = MaskName;
                MaskName.Visibility = Visibility.Visible;
                dba.DataContext = vm;
                dba.ShowDialog();

            });
            OpenEditStaffCM = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                StaffEditAndDetailPage dba = new StaffEditAndDetailPage();
                StaffEditAndDetailViewModel vm = new StaffEditAndDetailViewModel(admin, SelectedItem);
                dba.DataContext = vm;
                p.NavigationService.Navigate(dba);
            });
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();
            });
            RefreshCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {

                Load2();



            });
            DeleteStaffCM = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this user and all his/her related data?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();

                if (result.DialogResult == true)
                {
                    IsGettingSource = true;

                    (bool isSuccess, string messageFromUpdate) = await UserService.Ins.DeleteUser((int)SelectedItem.id);

                    IsGettingSource = false;

                    if (isSuccess)
                    {
                        for (int i = 0; i < Staffs.Count; i++)
                        {
                            if (Staffs[i].id == SelectedItem?.id)
                            {
                                Staffs.Remove(Staffs[i]);
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
            OrganizationChangeCM = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                ReloadPostion();
            });
            AddOrganizationCM = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                TextBox temp = (p as TextBox);
                if (temp != null)
                {
                    string s = temp.Text;
                    if (s != null && s != "")
                    {
                        int c = OrganizationSource.Count(x => x.name == s);
                        if (c > 0)
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Organization name must be unique!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();

                        }
                        else
                        {
                            MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to insert this organization?", MessageType.Warning, MessageButtons.YesNo);
                            result.ShowDialog();

                            if (result.DialogResult == true)
                            {
                                InsertOrgan(s);
                                temp.Text = "";
                            }

                        }

                    }
                    if (s == null || s == "")
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Organization name can not be emptied!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                }

            });
            DeleteOrganizationCM = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this organization and all its related data?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();

                if (result.DialogResult == true)
                {

                    (bool isSuccess, string messageFromUpdate) = await OrganizationAndPositionService.Ins.DeleteOrganization(SelectedItem2.name);


                    if (isSuccess)
                    {
                        Load();
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
            AddPositionCM = new RelayCommand<TextBox>((p) => { return true; }, async (p) =>
            {
                TextBox temp = (p as TextBox);
                if (temp != null)
                {
                    string s = temp.Text;
                    if (s != null && s != "")
                    {
                        if (CurrentOrganization != null)
                        {
                            int c = PositionSource.Count(x => x.name == s);
                            if (c > 0)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Position name must be unique!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();

                            }
                            else
                            {
                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to insert this position in" + CurrentOrganization.name + "?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await OrganizationAndPositionService.Ins.InsertPosition(CurrentOrganization.name, s);
                                        if (isSuccess)
                                        {
                                            OrganizationSource = new ObservableCollection<OrganizationsDTO>(await OrganizationAndPositionService.Ins.GetAllOrganization());
                                            CurrentOrganization = null;
                                            ReloadPostion();
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
                                    temp.Text = "";
                                }

                            }
                        }
                        else
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "You did not choose organization!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                        }


                    }
                    if (s == null || s == "")
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Position name can not be emptied!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                }
            });
            DeletePositionCM = new RelayCommand<TextBox>((p) => { return true; }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this position and all its related data?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();
                if (result.DialogResult == true)
                {
                    (bool isSuccess, string messageFromUpdate) = await OrganizationAndPositionService.Ins.DeletePosition(SelectedItem3.organization, SelectedItem3.name);


                    if (isSuccess)
                    {
                        for (int i = 0; i < PositionSource.Count; i++)
                        {
                            if (PositionSource[i].organization == SelectedItem3?.organization && PositionSource[i].name == SelectedItem3?.name)
                            {
                                PositionSource.Remove(PositionSource[i]);
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
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });
            SaveCurrentPageCM = new RelayCommand<Page>((p) => { return true; }, async (p) =>
            {
                CurrentPage = p;
            });
        }
        public async Task ReloadPostion()
        {
            try
            {
                if (CurrentOrganization != null)
                    PositionSource = new ObservableCollection<PositionsDTO>(await OrganizationAndPositionService.Ins.GetAllPositionByOrganName(CurrentOrganization.name));
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
        public async Task Load2()
        {
            try
            {
                Staffs = new ObservableCollection<UsersDTO>(await UserService.Ins.GetAllUser());
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
        public async Task Load()
        {
            try
            {
                IsGettingSource = true;
                Staffs = new ObservableCollection<UsersDTO>(await UserService.Ins.GetAllUser());
                OrganizationSource = new ObservableCollection<OrganizationsDTO>(await OrganizationAndPositionService.Ins.GetAllOrganization());

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
        public async Task InsertOrgan(string s)
        {
            try
            {
                (bool isSuccess, string messageFromUpdate) = await OrganizationAndPositionService.Ins.InsertOrganization(s);
                if (isSuccess)
                {
                    OrganizationSource.Add(new OrganizationsDTO(s));
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