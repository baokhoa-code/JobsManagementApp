//using JobsManagementApp.Model;
//using JobsManagementApp.Service;
//using JobsManagementApp.View.Admin;
//using JobsManagementApp.View.Admin.DashBoard;
//using JobsManagementApp.View.Admin.Staff;
//using JobsManagementApp.View.Admin.Job;
//using JobsManagementApp.View.Admin.JobAssign;
//using JobsManagementApp.View.Admin.Report;
//using JobsManagementApp.View.Share;
//using JobsManagementApp.View.General;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Input;
//using System.Windows.Navigation;
//using System.Collections.ObjectModel;
//using MySql.Data.MySqlClient;
//using System.Linq;
//using System.Windows.Documents;
//using System.Data;
//using System.Linq.Expressions;
//using System.Collections;
//using MaterialDesignThemes.Wpf;
//using System.ComponentModel;
//using MySql.Data.MySqlClient;

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
using JobsManagementApp.ViewModel.ShareModel;

namespace JobsManagementApp.ViewModel.AdminModel
{
    public class JobManagementPageAdminViewModel : BaseViewModel
    {
        public Admin admin { get; set; }
        private bool _IsGettingSource;
        public bool IsGettingSource
        {
            get { return _IsGettingSource; }
            set { _IsGettingSource = value; OnPropertyChanged(); }
        }
        private ObservableCollection<CategoriesDTO> _CategorySource;
        public ObservableCollection<CategoriesDTO> CategorySource
        {
            get { return _CategorySource; }
            set { _CategorySource = value; OnPropertyChanged(); }
        }
        private List<string> _DependencySource;
        public List<string> DependencySource
        {
            get { return _DependencySource; }
            set { _DependencySource = value; OnPropertyChanged(); }
        }
        private List<string> _AssignorSource;
        public List<string> AssignorSource
        {
            get { return _AssignorSource; }
            set { _AssignorSource = value; OnPropertyChanged(); }
        }
        private List<string> _AssigneeSource;
        public List<string> AssigneeSource
        {
            get { return _AssigneeSource; }
            set { _AssigneeSource = value; OnPropertyChanged(); }
        }
        private ComboBoxItem _SelectedType;
        public ComboBoxItem SelectedType
        {
            get { return _SelectedType; }
            set { _SelectedType = value; OnPropertyChanged(); }
        }
        public string _CurrentYear;
        public string CurrentYear
        {
            get { return _CurrentYear; }
            set { _CurrentYear = value; OnPropertyChanged(); }
        }
        public string _CurrentMonth;
        public string CurrentMonth
        {
            get { return _CurrentMonth; }
            set { _CurrentMonth = value; OnPropertyChanged(); }
        }
        public string _CurrentDate;
        public string CurrentDate
        {
            get { return _CurrentDate; }
            set { _CurrentDate = value; OnPropertyChanged(); }
        }
        public string _CurrentWeekRange;
        public string CurrentWeekRange
        {
            get { return _CurrentWeekRange; }
            set { _CurrentWeekRange = value; OnPropertyChanged(); }
        }
        private Page _CurrentPage;
        public Page CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; OnPropertyChanged(); }
        }
        public ListView listView;
        public static Grid MaskName { get; set; }
        private List<string> _ListWeekRage;
        public List<string> ListWeekRage
        {
            get { return _ListWeekRage; }
            set { _ListWeekRage = value; OnPropertyChanged(); }
        }

        private List<string> _ListMonth;
        public List<string> ListMonth
        {
            get { return _ListMonth; }
            set { _ListMonth = value; OnPropertyChanged(); }
        }
        private List<string> _ListYear;
        public List<string> ListYear
        {
            get { return _ListYear; }
            set { _ListYear = value; OnPropertyChanged(); }
        }
        private int _WeekPending;
        public int WeekPending
        {
            get { return _WeekPending; }
            set { _WeekPending = value; OnPropertyChanged(); }
        }
        private int _WeekLate;
        public int WeekLate
        {
            get { return _WeekLate; }
            set { _WeekLate = value; OnPropertyChanged(); }
        }
        private int _WeekCompleteSoon;
        public int WeekCompleteSoon
        {
            get { return _WeekCompleteSoon; }
            set { _WeekCompleteSoon = value; OnPropertyChanged(); }
        }
        private int _WeekCompleteLate;
        public int WeekCompleteLate
        {
            get { return _WeekCompleteLate; }
            set { _WeekCompleteLate = value; OnPropertyChanged(); }
        }
        private int _MonthPending;
        public int MonthPending
        {
            get { return _MonthPending; }
            set { _MonthPending = value; OnPropertyChanged(); }
        }
        private int _MonthLate;
        public int MonthLate
        {
            get { return _MonthLate; }
            set { _MonthLate = value; OnPropertyChanged(); }
        }
        private int _MonthCompleteSoon;
        public int MonthCompleteSoon
        {
            get { return _MonthCompleteSoon; }
            set { _MonthCompleteSoon = value; OnPropertyChanged(); }
        }
        private int _MonthCompleteLate;
        public int MonthCompleteLate
        {
            get { return _MonthCompleteLate; }
            set { _MonthCompleteLate = value; OnPropertyChanged(); }
        }
        private int _YearPending;
        public int YearPending
        {
            get { return _YearPending; }
            set { _YearPending = value; OnPropertyChanged(); }
        }
        private int _YearLate;
        public int YearLate
        {
            get { return _YearLate; }
            set { _YearLate = value; OnPropertyChanged(); }
        }
        private int _YearCompleteSoon;
        public int YearCompleteSoon
        {
            get { return _YearCompleteSoon; }
            set { _YearCompleteSoon = value; OnPropertyChanged(); }
        }
        private int _YearCompleteLate;
        public int YearCompleteLate
        {
            get { return _YearCompleteLate; }
            set { _YearCompleteLate = value; OnPropertyChanged(); }
        }
        private CategoriesDTO _SelectedItem2;
        public CategoriesDTO SelectedItem2
        {
            get { return _SelectedItem2; }
            set { _SelectedItem2 = value; OnPropertyChanged(); }
        }
        private int _SelectedIndexnhe;
        public int SelectedIndexnhe
        {
            get { return _SelectedIndexnhe; }
            set { _SelectedIndexnhe = value; OnPropertyChanged(); }
        }
        public ICommand AddCategoryCM { get; set; }
        public ICommand DeleteCategoryCM { get; set; }
        public ICommand OpenAddJobWindowCM { get; set; }
        public ICommand OpenAddStaffWindowCM { get; set; }
        public ICommand OpenEditJobCM { get; set; }
        public ICommand DeleteJobCM { get; set; }
        public ICommand SaveCurrentPageCM { get; set; }
        public ICommand MaskNameCM { get; set; }
        public ICommand ListWeekRageChangeCM { get; set; }
        public ICommand ListMonthChangeCM { get; set; }
        public ICommand ListYearChangeCM { get; set; }
        public ICommand LoadFilterCbxCM { get; set; }
        public ICommand LoadCM { get; set; }
        public ICommand LoadCM2 { get; set; }

        private ObservableCollection<JobsDTO> _Jobs;
        public ObservableCollection<JobsDTO> Jobs
        {

            get => _Jobs;
            set
            {
                _Jobs = value;
                OnPropertyChanged();
            }
        }
        private JobsDTO _SelectedItem;
        public JobsDTO SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }
        private ObservableCollection<JobsDTO> _JobsStore;
        public ObservableCollection<JobsDTO> JobsStore
        {

            get => _JobsStore;
            set
            {
                _JobsStore = value;
                OnPropertyChanged();
            }
        }
        public JobManagementPageAdminViewModel(Admin a)
        {
            admin = new Admin(a);
            CategorySource = new ObservableCollection<CategoriesDTO>();
            DependencySource = new List<string>();
            AssignorSource = new List<string>();
            AssigneeSource = new List<string>();
            //GET CURRENT TIME
            CurrentYear = DateTime.Now.Year.ToString();
            CurrentMonth = DateTime.Now.Month.ToString();
            CurrentDate = DateTime.Now.Day.ToString();
            SelectedIndexnhe = -1;

            //DEFINE COMMANDS
            LoadCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                Load();

            });
            LoadCM2 = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                
                Load2();

            });
            OpenAddJobWindowCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                JobAddWindow dba = new JobAddWindow();
                JobAddViewModel vm = new JobAddViewModel(admin, this);
                MaskName.Visibility = Visibility.Visible;
                vm.Mask = MaskName;
                dba.DataContext = vm;
                dba.ShowDialog();

            });
            OpenEditJobCM = new RelayCommand<Page>((p) => { return SelectedItem != null; }, (p) =>
            {
                JobDetailViewModel vm = new JobDetailViewModel(admin, SelectedItem);
                JobDetailPage dashboardpage = new JobDetailPage();
                dashboardpage.DataContext = vm;
                p.NavigationService.Navigate(dashboardpage);

            });
            AddCategoryCM = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                TextBox temp = (p as TextBox);
                if (temp != null)
                {
                    string s = temp.Text;
                    if (s != null && s != "")
                    {
                        int c = CategorySource.Count(x => x.name == s);
                        if (c > 0)
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Category must be unique!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();

                        }
                        else
                        {
                            MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to insert this category?", MessageType.Warning, MessageButtons.YesNo);
                            result.ShowDialog();

                            if (result.DialogResult == true)
                            {
                                InsertCategory(s);
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
            DeleteCategoryCM = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this category and all its related data?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();

                if (result.DialogResult == true)
                {

                    (bool isSuccess, string messageFromUpdate) = await CategoryService.Ins.DeleteCategory(SelectedItem2.name);


                    if (isSuccess)
                    {
                        Jobs = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
                        InsertCategoryCombobox();
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
            LoadFilterCbxCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
 
                    InsertCategoryCombobox();
                    InsertAssignorCombobox();
                    InsertAssigneeCombobox();
                    InsertDependencyCombobox();
                
                

            });
            DeleteJobCM = new RelayCommand<Window>((p) => { return SelectedItem != null; }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this Job and it related reports?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();

                if (result.DialogResult == true)
                {
                    IsGettingSource = true;

                    (bool isSuccess, string messageFromUpdate) = await JobService.Ins.DeleteJob((int) SelectedItem.id);

                    IsGettingSource = false;

                    if (isSuccess)
                    {
                        for (int i = 0; i < Jobs.Count; i++)
                        {
                            if (Jobs[i].id == SelectedItem?.id)
                            {
                                Jobs.Remove(Jobs[i]);
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
            SaveCurrentPageCM = new RelayCommand<Page>((p) => { return true; }, async (p) =>
            {
                CurrentPage = p;
            });
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });
            ListWeekRageChangeCM = new RelayCommand<ListView>((p) => { return CurrentWeekRange!=null; }, (p) =>
            {
                //UPDATE WEEK JOB AMOUNT
                InsertWeekJobAmount();
            });
            ListMonthChangeCM = new RelayCommand<ListView>((p) => { return CurrentMonth != null; }, (p) =>
            {
                var firstDayOfMonth = new DateTime(Int16.Parse(CurrentYear), Int16.Parse(CurrentMonth), 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                CurrentDate = lastDayOfMonth.Day.ToString();
                //UPDATE WEEK COMBOBOX
                InsertWeekCombobox();
                //UPDATE MONTH JOB AMOUNT
                InsertMonthJobAmount();
            });
            ListYearChangeCM = new RelayCommand<ListView>((p) => { return CurrentYear != null; }, (p) =>
            {
                //UPDATE MONTH COMBOBOX
                InsertMonthCombobox("12");
                var firstDayOfMonth = new DateTime(Int16.Parse(CurrentYear), Int16.Parse(CurrentMonth), 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                CurrentDate = lastDayOfMonth.Day.ToString();
                //UPDATE WEEK COMBOBOX
                InsertWeekCombobox();
                //UPDATE YEAR JOB AMOUNT
                InsertYearJobAmount();
            });
        }
        //INTERNAL FUNCTIONS
        public async Task Load2()
        {
            SelectedIndexnhe = -1;
            try
            {
   
                Jobs = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
                JobsStore = new ObservableCollection<JobsDTO>(Jobs);

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
                Jobs = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
                JobsStore = new ObservableCollection<JobsDTO>(Jobs);
                InsertCategoryCombobox();

                //INSERT COMBOBOXES
                InsertWeekCombobox();
                InsertMonthCombobox(CurrentMonth);
                InsertYearCombobox();

                //GET CURRENT WEEK, MONTH, YEAR JOB AMOUNT
                InsertWeekJobAmount();
                InsertMonthJobAmount();
                InsertYearJobAmount();
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
        public void InsertWeekCombobox()
        {
            ListWeekRage = null;
            ListWeekRage = new List<string>();
            DateTime d = new DateTime(Int16.Parse(CurrentYear), Int16.Parse(CurrentMonth), Int16.Parse(CurrentDate));
            DateTime d_plus = FirstDayOfWeek(d);
            ListWeekRage.Add(d_plus.ToString("dd/MM/yyyy") + "-" + d.ToString("dd/MM/yyyy"));
            CurrentWeekRange = d_plus.ToString("dd/MM/yyyy") + "-" + d.ToString("dd/MM/yyyy");
            while (d_plus.Month == Int16.Parse(CurrentMonth) && d_plus.AddDays(-7).Month == Int16.Parse(CurrentMonth))
            {
                ListWeekRage.Add(d_plus.AddDays(-7).ToString("dd/MM/yyyy") + "-" + d_plus.ToString("dd/MM/yyyy"));
                d_plus = d_plus.AddDays(-7);
            }
        }
        public void InsertMonthCombobox(string month)
        {
            ListMonth = null;
            ListMonth = new List<string>();
            CurrentMonth = month;
            for (int i = Int16.Parse(CurrentMonth); i >= 1; i--)
            {
                ListMonth.Add(i.ToString());
            }
            CurrentMonth = month;
        }
        public void InsertYearCombobox()
        {
            ListYear = new List<string>();
            for(int i = Int16.Parse(CurrentYear); i > Int16.Parse(CurrentYear) - 8; i--)
            {
                ListYear.Add(i.ToString());
            }
        }
        public async Task InsertCategoryCombobox()
        {

            CategorySource = new ObservableCollection<CategoriesDTO>(await CategoryService.Ins.GetAllCategory());
        }
        public void InsertDependencyCombobox()
        {
            
            DependencySource = JobService.Ins.InsertDependencyCombobox();
        }
        public void InsertAssignorCombobox()
        {
            
            AssignorSource = JobService.Ins.InsertAssignorCombobox();
        }
        public void InsertAssigneeCombobox()
        {
            
            AssigneeSource = JobService.Ins.InsertAssigneeCombobox();
        }
        public void InsertWeekJobAmount()
        {
            //GET WEEK JOB AMOUNT
            string temp = new String(CurrentWeekRange);
            string[] years = temp.Split('-');
            DateTime a = DateTime.ParseExact(years[0], "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            DateTime b = DateTime.ParseExact(years[1], "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture);

            WeekPending = Jobs.Where(
                item => item.stage == "PENDING" &&
                DateTime.Compare(a, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                DateTime.Compare(b, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                ).Count();
            WeekLate = Jobs.Where(
                item => item.stage == "LATE" &&
                DateTime.Compare(a, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                DateTime.Compare(b, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                ).Count();
            WeekCompleteSoon = Jobs.Where(
                item => item.stage == "COMPLETE SOON" &&
                DateTime.Compare(a, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                DateTime.Compare(b, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                ).Count();
            WeekCompleteLate = Jobs.Where(
                item => item.stage == "COMPLETE LATE" &&
                DateTime.Compare(a, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                DateTime.Compare(b, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                ).Count();
        }
        public void InsertMonthJobAmount()
        {
            //GET MONTH JOB AMOUNT
            MonthPending = Jobs.Where(item => item.stage == "PENDING" &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Month.ToString() == CurrentMonth &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            MonthLate = Jobs.Where(item => item.stage == "LATE" &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Month.ToString() == CurrentMonth &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            MonthCompleteSoon = Jobs.Where(item => item.stage == "COMPLETE SOON" &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Month.ToString() == CurrentMonth &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            MonthCompleteLate = Jobs.Where(item => item.stage == "COMPLETE LATE" &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Month.ToString() == CurrentMonth &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
        }
        public void InsertYearJobAmount()
        {
            //GET YEAR JOB AMOUNT
            YearPending = Jobs.Where(item => item.stage == "PENDING" &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            YearLate = Jobs.Where(item => item.stage == "LATE" &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            YearCompleteSoon = Jobs.Where(item => item.stage == "COMPLETE SOON" &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            YearCompleteLate = Jobs.Where(item => item.stage == "COMPLETE LATE" &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
        }
        public static DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }
        public async Task InsertCategory(string s)
        {
            try
            {
                (bool isSuccess, string messageFromUpdate) = await CategoryService.Ins.InsertCategory(s);
                if (isSuccess)
                {
                    CategorySource.Add(new CategoriesDTO(s));
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
