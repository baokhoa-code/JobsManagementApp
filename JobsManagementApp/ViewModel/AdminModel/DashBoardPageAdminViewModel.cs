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
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView.Painting.ImageFilters;
using Org.BouncyCastle.Ocsp;
using LiveChartsCore.Measure;
using MaterialDesignThemes.Wpf;
using JobsManagementApp.View.Admin.DashBoard;
using JobsManagementApp.ViewModel.ShareModel;
using System.Security.Cryptography;

namespace JobsManagementApp.ViewModel.AdminModel
{
    public class DashBoardPageAdminViewModel : BaseViewModel
    {

        public Admin admin { get; set; }
        private List<string> _CategorySource;
        public List<string> CategorySource
        {
            get { return _CategorySource; }
            set { _CategorySource = value; OnPropertyChanged(); }
        }
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
        private ObservableCollection<JobsDTO> _JobsPie;
        public ObservableCollection<JobsDTO> JobsPie
        {

            get => _JobsPie;
            set
            {
                _JobsPie = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<JobsDTO> _JobsLine;
        public ObservableCollection<JobsDTO> JobsLine
        {

            get => _JobsLine;
            set
            {
                _JobsLine = value;
                OnPropertyChanged();
            }
        }
        private JobsDTO _SelectedItem;
        public JobsDTO SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }
        private ObservableCollection<JobsDTO> _JobsOverAll;
        public ObservableCollection<JobsDTO> JobsOverAll
        {

            get => _JobsOverAll;
            set
            {
                _JobsOverAll = value;
                OnPropertyChanged();
            }
        }
        public string LineStage;
        private ComboBoxItem _PieSelectedType;
        public ComboBoxItem PieSelectedType
        {
            get { return _PieSelectedType; }
            set { _PieSelectedType = value; OnPropertyChanged(); }
        }
        private IEnumerable<ISeries> _Pies;
        public IEnumerable<ISeries> Pies
        {
            get { return _Pies; }
            set { _Pies = value; OnPropertyChanged(); }
        }
        private IEnumerable<ISeries> _Lines;
        public IEnumerable<ISeries> Lines
        {
            get { return _Lines; }
            set { _Lines = value; OnPropertyChanged(); }
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
        public string _ShowAleartRange;
        public string ShowAleartRange
        {
            get { return _ShowAleartRange; }
            set { _ShowAleartRange = value; OnPropertyChanged(); }
        }
        public string _YearAlertRange;
        public string YearAlertRange
        {
            get { return _YearAlertRange; }
            set { _YearAlertRange = value; OnPropertyChanged(); }
        }
        public string _MonthAlertRange;
        public string MonthAlertRange
        {
            get { return _MonthAlertRange; }
            set { _MonthAlertRange = value; OnPropertyChanged(); }
        }
        public string _WeekAlertRange;
        public string WeekAlertRange
        {
            get { return _WeekAlertRange; }
            set { _WeekAlertRange = value; OnPropertyChanged(); }
        }

  
        public static Grid MaskName { get; set; }

        public ICommand OpenAddJobWindowCM { get; set; }
        public ICommand OpenEditJobCM { get; set; }
        public ICommand DeleteJobCM { get; set; }
        public ICommand PieSelectionChangedCM { get; set; }
        public ICommand LineByWeekCM { get; set; }
        public ICommand LineByMonthCM { get; set; }
        public ICommand LineByYearCM { get; set; }
        public ICommand MaskNameCM { get; set; }
        public ICommand LoadCM { get; set; }
        public ICommand RefreshCM { get; set; }
        public DashBoardPageAdminViewModel(Admin a)
        {

            CategorySource = new List<string>();

            //GET CURRENT TIME
            CurrentYear = DateTime.Now.Year.ToString();
            CurrentMonth = DateTime.Now.Month.ToString();
            CurrentDate = DateTime.Now.Day.ToString();
            DateTime d = new DateTime(Int16.Parse(CurrentYear), Int16.Parse(CurrentMonth), Int16.Parse(CurrentDate));
            DateTime d_plus = FirstDayOfWeek(d);
            CurrentWeekRange = d_plus.ToString("dd/MM/yyyy") + "-" + d_plus.AddDays(7).ToString("dd/MM/yyyy");
            
            //DEFINE ALERT
            YearAlertRange = "Start from "+ (Int16.Parse(CurrentYear) - 4) +  " to " + CurrentYear;
            MonthAlertRange = "Start from 1 to " + CurrentMonth;
            WeekAlertRange = "Start from " + d.AddDays(-35).ToString("dd/MM/yyyy") + " to " + d.ToString("dd/MM/yyyy");
            ShowAleartRange = WeekAlertRange;
            //LOAD REQUIRED INFORMATION
            admin = new Admin(a);

            //DEFINE COMMANDS
            LoadCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                Load();
                LoadLineByWeek();
                LineStage = "WEEK";

            });
            RefreshCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                Load();
                PieSelectionChanged();
                if (LineStage == "WEEK")
                {
                    LoadLineByWeek();
                }
                if (LineStage == "MONTH")
                {
                    LoadLineByMonth();
                }
                if (LineStage == "YEAR")
                {
                    LoadLineByYear();
                }

            });
            MaskNameCM = new RelayCommand<Grid>((p) => { return p !=null; }, (p) =>
            {
                MaskName = p;

            });
            OpenAddJobWindowCM = new RelayCommand<object>((p) => { return true; }, async(p) =>
            {
                JobAddWindow dba = new JobAddWindow();
                JobAddViewModel vm = new JobAddViewModel(admin, JobsPie, JobsLine, Jobs, this);
                MaskName.Visibility = Visibility.Visible;
                vm.Mask = MaskName;
                dba.DataContext = vm;
                dba.ShowDialog();
  
            });
            OpenEditJobCM = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                JobDetailViewModel vm = new JobDetailViewModel(admin, SelectedItem);
                JobDetailPage dashboardpage = new JobDetailPage();
                dashboardpage.DataContext = vm;
                p.NavigationService.Navigate(dashboardpage);

            });
            DeleteJobCM = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this Job and it related reports?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();

                if (result.DialogResult == true)
                {


                    (bool isSuccess, string messageFromUpdate) = await JobService.Ins.DeleteJob((int)SelectedItem.id);



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
                        JobsLine = JobsPie = Jobs;
                        PieSelectionChanged();
                        if(LineStage == "WEEK")
                        {
                            LoadLineByWeek();
                        }
                        if (LineStage == "MONTH")
                        {
                            LoadLineByMonth();
                        }
                        if (LineStage == "YEAR")
                        {
                            LoadLineByYear();
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
            PieSelectionChangedCM = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await PieSelectionChanged();
            });
            LineByWeekCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                await LoadLineByWeek();
                LineStage = "WEEK";
            });
            LineByMonthCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                await LoadLineByMonth();
                LineStage = "MONTH";
            });
            LineByYearCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                await LoadLineByYear();
                LineStage = "YEAR";
            });
        }
        public async Task Load()
        {
            try
            {
                CategorySource = CategoryService.Ins.InsertCombobox();
                Jobs = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJobByAssigneeID("ADMIN", (int)admin.id));
                JobsPie = JobsLine = Jobs;

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
        public async Task PieSelectionChanged()
        {
            if (PieSelectedType != null)
            {
                switch (PieSelectedType.Content.ToString())
                {
                    case "This Week":
                        {
                            await LoadPieByWeek();

                            return;
                        }
                    case "This Month":
                        {
   
                            await LoadPieByMonth();

                            return;
                        }
                    case "This Year":
                        {

                            await LoadPieByYear();
                            
                            return;
                        }
                }
            }
        }

        public async Task LoadPieByWeek()
        {
            var pending = 0;
            var waiting = 0;
            var complete_late = 0;
            var complete_soon = 0;
            var late = 0;

            string temp = new String(CurrentWeekRange);
            string[] years = temp.Split('-');
            DateTime a = DateTime.ParseExact(years[0], "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            DateTime b = DateTime.ParseExact(years[1], "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture);

            waiting = JobsPie.Where(
                item => item.stage == "WAITING" &&
                DateTime.Compare(a, DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) < 0 &&
                DateTime.Compare(b, DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) > 0
                ).Count();

            pending = JobsPie.Where(
                item => item.stage == "PENDING" &&
                DateTime.Compare(a, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                DateTime.Compare(b, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                ).Count();
            late = JobsPie.Where(
                item => item.stage == "LATE" &&
                DateTime.Compare(a, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                DateTime.Compare(b, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                ).Count();
            complete_soon = JobsPie.Where(
                item => item.stage == "COMPLETE SOON" &&
                DateTime.Compare(a, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                DateTime.Compare(b, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                ).Count();
            complete_late = JobsPie.Where(
                item => item.stage == "COMPLETE LATE" &&
                DateTime.Compare(a, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                DateTime.Compare(b, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                ).Count();
            


            Pies = new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "WAITING",
                    Values = new double[] { waiting },
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                },
                new PieSeries<double>
                {
                    Name = "PENDING",
                    Values = new double[] { pending },
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                },
                new PieSeries<double>
                {
                    Name = "LATE      ",
                    Values = new double[] { late },
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                },
                new PieSeries<double>
                {
                    Name = "COMPLETE",
                    Values = new double[] { complete_late + complete_soon },
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",

                },
            };
        }
        public async Task LoadPieByMonth()
        {
            var pending = 0;
            var waiting = 0;
            var complete_late = 0;
            var complete_soon = 0;
            var late = 0;

            waiting = JobsPie.Where(item => item.stage == "WAITING" &&
                DateTime.ParseExact(item.start_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Month.ToString() == CurrentMonth &&
                DateTime.ParseExact(item.start_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            pending = JobsPie.Where(item => item.stage == "PENDING" &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Month.ToString() == CurrentMonth &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            late = JobsPie.Where(item => item.stage == "LATE" &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Month.ToString() == CurrentMonth &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            complete_soon = JobsPie.Where(item => item.stage == "COMPLETE SOON" &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Month.ToString() == CurrentMonth &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            complete_late = JobsPie.Where(item => item.stage == "COMPLETE LATE" &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Month.ToString() == CurrentMonth &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();

            Pies = new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "WAITING",
                    Values = new double[] { waiting },
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                },
                new PieSeries<double>
                {
                    Name = "PENDING",
                    Values = new double[] { pending },
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                },
                new PieSeries<double>
                {
                    Name = "LATE      ",
                    Values = new double[] { late },
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                },
                new PieSeries<double>
                {
                    Name = "COMPLETE",
                    Values = new double[] { complete_late + complete_soon},
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",

                },
            };
        }
        public async Task LoadPieByYear()
        {
            var pending = 0;
            var waiting = 0;
            var complete_late = 0;
            var complete_soon = 0;
            var late = 0;

            waiting = JobsPie.Where(item => item.stage == "WAITING" &&
                DateTime.ParseExact(item.start_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            pending = JobsPie.Where(item => item.stage == "PENDING" &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            late = JobsPie.Where(item => item.stage == "LATE" &&
                DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            complete_soon = JobsPie.Where(item => item.stage == "COMPLETE SOON" &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            complete_late = JobsPie.Where(item => item.stage == "COMPLETE LATE" &&
                DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();

            Pies = new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "WAITING",
                    Values = new double[] { waiting },
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                },
                new PieSeries<double>
                {
                    Name = "PENDING",
                    Values = new double[] { pending },
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                },
                new PieSeries<double>
                {
                    Name = "LATE       ",
                    Values = new double[] { late },
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                },
                new PieSeries<double>
                {
                    Name = "COMPLETE",
                    Values = new double[] { complete_late + complete_soon },
                    DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",

                },
            };
        }
        public async Task LoadLineByWeek()
        {
            ShowAleartRange = WeekAlertRange;
            double[] pending = new double[5];
            double[] late = new double[5];
            double[] complete = new double[5];
            DateTime d = new DateTime(Int16.Parse(CurrentYear), Int16.Parse(CurrentMonth), Int16.Parse(CurrentDate));
            DateTime d_plus = FirstDayOfWeek(d);
            CurrentWeekRange = d_plus.ToString("dd/MM/yyyy") + "-" + d_plus.AddDays(7).ToString("dd/MM/yyyy");
            for(int i = 0; i < 5; i++)
            {
                pending[i] = JobsLine.Where(
                    item => item.stage == "PENDING" &&
                    DateTime.Compare(d_plus, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                    DateTime.Compare(d, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                    ).Count();
                late[i] = JobsLine.Where(
                    item => item.stage == "LATE" &&
                    DateTime.Compare(d_plus, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                    DateTime.Compare(d, DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                    ).Count();
                complete[i] = JobsLine.Where(
                    item => item.stage == "COMPLETE LATE" &&
                    DateTime.Compare(d_plus, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                    DateTime.Compare(d, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                    ).Count() + JobsLine.Where(
                    item => item.stage == "COMPLETE SOON" &&
                    DateTime.Compare(d_plus, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) <= 0 &&
                    DateTime.Compare(d, DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)) >= 0
                    ).Count();
   
                d_plus = d_plus.AddDays(-7);
            }
            Lines = new ISeries[]
               {
                     new LineSeries<double>
                    {

                        Name = "PENDING",
                        Values = pending,
                        Fill = null
                    },
                     new LineSeries<double>
                    {

                        Name = "LATE",
                        Values = late,
                        Fill = null
                    },
                       new LineSeries<double>
                    {

                        Name = "COMPLETE",
                        Values = complete,
                        Fill = null,
                        DataLabelsSize = 12,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),

                    },
               };
        } 
        public async Task LoadLineByMonth()
        {
            ShowAleartRange = MonthAlertRange;
            double[] pending = new double[Int16.Parse(CurrentMonth)];
            double[] late = new double[Int16.Parse(CurrentMonth)];
            double[] complete = new double[Int16.Parse(CurrentMonth)];

            for (int i = 0; i < Int16.Parse(CurrentMonth); i++)
            {
                pending[i] = JobsLine.Where(item => item.stage == "PENDING" &&
                    DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture).Month == i + 1 &&
                    DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
                late[i] = JobsLine.Where(item => item.stage == "LATE" &&
                    DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture).Month == i + 1 &&
                    DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
                complete[i] = JobsLine.Where(item => item.stage == "COMPLETE SOON" &&
                        DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Month == i + 1 &&
                        DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count() +
                    JobsLine.Where(item => item.stage == "COMPLETE LATE" &&
                        DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Month == i + 1 &&
                        DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year.ToString() == CurrentYear).Count();
            }
            Lines = new ISeries[]
               {
                     new LineSeries<double>
                    {

                        Name = "PENDING",
                        Values = pending,
                        Fill = null
                    },
                     new LineSeries<double>
                    {

                        Name = "LATE",
                        Values = late,
                        Fill = null
                    },
                       new LineSeries<double>
                    {

                        Name = "COMPLETE",
                        Values = complete,
                        Fill = null,
                        DataLabelsSize = 12,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),

                    },
               };
        }
        public async Task LoadLineByYear()
        {
            ShowAleartRange = YearAlertRange;
            double[] pending = new double[5];
            double[] late = new double[5];
            double[] complete = new double[5];
            int start_year = Int16.Parse(CurrentYear) - 4;
            int loop_year = start_year;
            int end_year = Int16.Parse(CurrentYear);
            for (int i = 0; i < 5; i++)
            {
                pending[i] = JobsLine.Where(item => item.stage == "PENDING" &&
                        DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == loop_year).Count();

                late[i] = JobsLine.Where(item => item.stage == "LATE" && 
                        DateTime.ParseExact(item.due_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == loop_year).Count();

                complete[i] = JobsLine.Where(item => item.stage == "COMPLETE SOON" &&
                        DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == loop_year).Count() +
                                JobsLine.Where(item => item.stage == "COMPLETE LATE" &&
                        DateTime.ParseExact(item.end_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == loop_year).Count();
                loop_year++;
            }
            Lines = new ISeries[]
               {
                     new LineSeries<double>
                    {
                        Name = "PENDING",
                        Values = pending,
                        Fill = null
                    },
                     new LineSeries<double>
                    {

                        Name = "LATE",
                        Values = late,
                        Fill = null
                    },
                       new LineSeries<double>
                    {

                        Name = "COMPLETE",
                        Values = complete,
                        Fill = null,
                        DataLabelsSize = 12,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),

                    },
               };
        }
        public static DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }
    }
}
