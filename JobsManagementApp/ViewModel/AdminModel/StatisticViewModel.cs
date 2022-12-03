using JobsManagementApp.View.Admin.Statistic;
using JobsManagementApp.View.Share;
using MaterialDesignThemes.Wpf;
using JobsManagementApp.Model;
using JobsManagementApp.Service;
using System.ComponentModel;
using System;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;
using System.Threading.Tasks;

using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace JobsManagementApp.ViewModel.AdminModel
{
    class StatisticViewModel : BaseViewModel
    {
        public Frame mainFrame { get; set; }
        public Card ButtonView { get; set; }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(); }
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
        private ComboBoxItem _SelectedType;
        public ComboBoxItem SelectedType
        {
            get { return _SelectedType; }
            set { _SelectedType = value; OnPropertyChanged(); }
        }
        private ComboBoxItem _SelectedType1;
        public ComboBoxItem SelectedType1
        {
            get { return _SelectedType1; }
            set { _SelectedType1 = value; OnPropertyChanged(); }
        }

        private string _SelectedIncomeTime;
        public string SelectedIncomeTime
        {
            get { return _SelectedIncomeTime; }
            set { _SelectedIncomeTime = value; OnPropertyChanged(); }
        }
        private string _SelectedIncomeTime1;
        public string SelectedIncomeTime1
        {
            get { return _SelectedIncomeTime1; }
            set { _SelectedIncomeTime1 = value; OnPropertyChanged(); }
        }

        private int selectedYear;
        public int SelectedYear
        {
            get { return selectedYear; }
            set { selectedYear = value; }
        }
        private int selectedYear1;
        public int SelectedYear1
        {
            get { return selectedYear1; }
            set { selectedYear1 = value; }
        }
        private int selectedMonth;
        public int SelectedMonth
        {
            get { return selectedMonth; }
            set { selectedMonth = value; }
        }
        private int selectedMonth1;
        public int SelectedMonth1
        {
            get { return selectedMonth1; }
            set { selectedMonth1 = value; }
        }

        private ISeries[] _Lines;
        public ISeries[] Lines
        {
            get { return _Lines; }
            set { _Lines = value; OnPropertyChanged(); }
        }

        private Axis[] _LinesXAxes;
        public Axis[] LinesXAxes
        {
            get { return _LinesXAxes; }
            set { _LinesXAxes = value; OnPropertyChanged(); }
        }
        
        private Axis[] _LinesYAxes;
        public Axis[] LinesYAxes
        {
            get { return _LinesYAxes; }
            set { _LinesYAxes = value; OnPropertyChanged(); }
        }
        private string _jobPendingQuantity;
        public string jobPendingQuantity
        {
            get { return _jobPendingQuantity; }
            set { _jobPendingQuantity = value; OnPropertyChanged(); }
        }
        private string _jobPendingPercent;
        public string jobPendingPercent
        {
            get { return _jobPendingPercent; }
            set { _jobPendingPercent = value; OnPropertyChanged(); }
        }
        private string _jobLateQuantity;
        public string jobLateQuantity
        {
            get { return _jobLateQuantity; }
            set { _jobLateQuantity = value; OnPropertyChanged(); }
        }
        private string _jobLatePercent;
        public string jobLatePercent
        {
            get { return _jobLatePercent; }
            set { _jobLatePercent = value; OnPropertyChanged(); }
        }
        private string _jobCompletedSoonQuantity;
        public string jobCompletedSoonQuantity
        {
            get { return _jobCompletedSoonQuantity; }
            set { _jobCompletedSoonQuantity = value; OnPropertyChanged(); }
        }
        private string _jobCompletedSoonPercent;
        public string jobCompletedSoonPercent
        {
            get { return _jobCompletedSoonPercent; }
            set { _jobCompletedSoonPercent = value; OnPropertyChanged(); }
        }
        private string _jobCompletedLateQuantity;
        public string jobCompletedLateQuantity
        {
            get { return _jobCompletedLateQuantity; }
            set { _jobCompletedLateQuantity = value; OnPropertyChanged(); }
        }
        private string _jobCompletedLatePercent;
        public string jobCompletedLatePercent
        {
            get { return _jobCompletedLatePercent; }
            set { _jobCompletedLatePercent = value; OnPropertyChanged(); }
        }
        private string _AssignedJobQuantity;
        public string AssignedJobQuantity
        {
            get { return _AssignedJobQuantity; }
            set { _AssignedJobQuantity = value; OnPropertyChanged(); }
        }
        private string _CompletedJobQuantity;
        public string CompletedJobQuantity
        {
            get { return _CompletedJobQuantity; }
            set { _CompletedJobQuantity = value; OnPropertyChanged(); }
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
        private ObservableCollection<UsersDTOMore> _Staffs;
        public ObservableCollection<UsersDTOMore> Staffs
        {

            get => _Staffs;
            set
            {
                _Staffs = value;
                OnPropertyChanged();
            }
        }

        public ISeries[] Series { get; set; } =
        {
            new ColumnSeries<double> { Values = new double[] { 426, 583, 104 } },
            new LineSeries<double>   { Values = new double[] { 200, 558, 458 }, Fill = null }
        };
        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Name = "Assigned/Completed Job",
                        NamePaint = new SolidColorPaint { Color = SKColors.Red },
                        Labels = new string[] { "1", "2", "3"  },
                        LabelsPaint = new SolidColorPaint
                        {
                            Color = SKColors.Black,
                        }
            }
        };

        public Axis[] YAxes { get; set; } =
        {
            new Axis
            {
                Name = "Sales amount",
                NamePadding = new LiveChartsCore.Drawing.Padding(0, 15),
                Labeler = Labelers.Currency
            }
        };

        private IEnumerable<ISeries> _Pies1;
        public IEnumerable<ISeries> Pies1
        {
            get { return _Pies1; }
            set { _Pies1 = value; OnPropertyChanged(); }
        }

        private IEnumerable<ISeries> _Pies2;
        public IEnumerable<ISeries> Pies2
        {
            get { return _Pies2; }
            set { _Pies2 = value; OnPropertyChanged(); }
        }


        public ICommand LoadViewCM { get; set; }
        public ICommand LoadCM { get; set; }
        public ICommand StoreButtonNameCM { get; set; }
        public ICommand LoadAllStatisticalCM { get; set; }
        public ICommand LoadRankStatisticalCM { get; set; }
        public ICommand ChangeTimeCM { get; set; }
        public ICommand ChangeTime1CM { get; set; }

        

        public StatisticViewModel()
        {

            LoadViewCM = new RelayCommand<Frame>((p) => { return true; },async (p) =>
            {
                mainFrame = p;
            });
            LoadCM = new RelayCommand<Frame>((p) => { return true; },async (p) =>
            {
                Load();
            });
            StoreButtonNameCM = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                ButtonView = p;
                p.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#fafafa");
                p.SetValue(ShadowAssist.ShadowDepthProperty, ShadowDepth.Depth0);

            });
            LoadAllStatisticalCM = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                ChangeView(p);
                mainFrame.Content = new SummaryStatistical();
            });
            LoadRankStatisticalCM = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                ChangeView(p);
                mainFrame.Content = new RankingStatistic();
            });
            ChangeTimeCM = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                IsLoading = true;
                await ChangeType();
                IsLoading = false;
            });
            ChangeTime1CM = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                IsLoading = true;
                await ChangeType1();
                IsLoading = false;
            });
        }

        public async Task Load()
        {
            try
            {
                Staffs = new ObservableCollection<UsersDTOMore>(await UserService.Ins.GetTop5User());
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
        public void ChangeView(Card p)
        {
            ButtonView.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#f0f2f5");
            ButtonView.SetValue(ShadowAssist.ShadowDepthProperty, ShadowDepth.Depth2);
            ButtonView = p;
            p.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#fafafa");
            p.SetValue(ShadowAssist.ShadowDepthProperty, ShadowDepth.Depth0);
        }

        public async Task ChangeType()
        {
            if (SelectedType != null)
            {
                switch (SelectedType.Content.ToString())
                {
                    case "By Years":
                        {
                            if (SelectedIncomeTime != null)
                            {
                                SelectedYear = int.Parse(SelectedIncomeTime);
                                await LoadJobByYear();
                            }
                            return;
                        }
                    case "By Months":
                        {
                            if (SelectedIncomeTime != null)
                            {
                                SelectedMonth = int.Parse(SelectedIncomeTime);
                                await LoadJobByMonth();
                            }
                            return;
                        }
                }
            }
        }

        public async Task ChangeType1()
        {
            if (SelectedType1 != null)
            {
                switch (SelectedType1.Content.ToString())
                {
                    case "By Years":
                        {
                            if (SelectedIncomeTime1 != null)
                            {
                                SelectedYear1 = int.Parse(SelectedIncomeTime1);
                                await LoadAllByYear();
                            }
                            return;
                        }
                    case "By Months":
                        {
                            if (SelectedIncomeTime1 != null)
                            {
                                SelectedMonth1 = int.Parse(SelectedIncomeTime1);
                                await LoadAllByMonth();
                            }
                            return;
                        }
                }
            }
        }
        public async Task LoadAllByYear()
        {
            try
            {
                Staffs = new ObservableCollection<UsersDTOMore>(await UserService.Ins.GetTop5UserByYear(SelectedYear1));
                if (Staffs.Count > 0)
                {
                    JobsPie = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJobByAssigneeID("USER", (int)Staffs[0].id));
                    var pending = 0;
                    var waiting = 0;
                    var complete_late = 0;
                    var complete_soon = 0;
                    var late = 0;

                    waiting = JobsPie.Where(item => item.stage == "WAITING" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year == SelectedYear1).Count();
                    pending = JobsPie.Where(item => item.stage == "PENDING" &&
                        DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year == SelectedYear1).Count();
                    late = JobsPie.Where(item => item.stage == "LATE" &&
                        DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year == SelectedYear1).Count();
                    complete_soon = JobsPie.Where(item => item.stage == "COMPLETE SOON" &&
                        DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year == SelectedYear1).Count();
                    complete_late = JobsPie.Where(item => item.stage == "COMPLETE LATE" &&
                        DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year == SelectedYear1).Count();

                    Pies1 = new ISeries[]
                    {
                        new PieSeries<double>
                        {
                            Name = "WAITING",
                            Values = new double[] { waiting },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "PENDING",
                            Values = new double[] { pending },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "LATE       ",
                            Values = new double[] { late },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "COMPLETE",
                            Values = new double[] { complete_late + complete_soon },
                            InnerRadius = 100

                        },
                    };
                    if (Staffs.Count == 1)
                    {
                        Pies2 = new ISeries[]
                        {
                            new PieSeries<double>
                            {
                                Name = Staffs[0].id + " - " + Staffs[0].name,
                                Values = new double[] { (double) Staffs[0].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                        };
                    }
                    if (Staffs.Count == 2)
                    {
                        Pies2 = new ISeries[]
                        {
                           new PieSeries<double>
                            {
                                Name = Staffs[0].id + " - " + Staffs[0].name,
                                Values = new double[] { (double) Staffs[0].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[1].id + " - " + Staffs[1].name,
                                Values = new double[] { (double) Staffs[1].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                        };
                    }
                    if (Staffs.Count == 3)
                    {
                        Pies2 = new ISeries[]
                        {
                            new PieSeries<double>
                            {
                                Name = Staffs[0].id + " - " + Staffs[0].name,
                                Values = new double[] { (double) Staffs[0].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[1].id + " - " + Staffs[1].name,
                                Values = new double[] { (double) Staffs[1].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[2].id + " - " + Staffs[2].name,
                                Values = new double[] { (double) Staffs[2].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                        };
                    }
                    if (Staffs.Count == 4)
                    {
                        Pies2 = new ISeries[]
                        {
                            new PieSeries<double>
                            {
                                Name = Staffs[0].id + " - " + Staffs[0].name,
                                Values = new double[] { (double) Staffs[0].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[1].id + " - " + Staffs[1].name,
                                Values = new double[] { (double) Staffs[1].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[2].id + " - " + Staffs[2].name,
                                Values = new double[] { (double) Staffs[2].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[3].id + " - " + Staffs[3].name,
                                Values = new double[] { (double) Staffs[3].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                        };
                    }
                    if (Staffs.Count == 5)
                    {
                        Pies2 = new ISeries[]
                        {
                            new PieSeries<double>
                            {
                                Name = Staffs[0].id + " - " + Staffs[0].name,
                                Values = new double[] { (double) Staffs[0].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[1].id + " - " + Staffs[1].name,
                                Values = new double[] { (double) Staffs[1].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[2].id + " - " + Staffs[2].name,
                                Values = new double[] { (double) Staffs[2].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[3].id + " - " + Staffs[3].name,
                                Values = new double[] { (double) Staffs[3].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[4].id + " - " + Staffs[4].name,
                                Values = new double[] { (double) Staffs[4].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                        };
                    }
                }
                else
                {
                    Pies1 = new ISeries[]
                    {
                        new PieSeries<double>
                        {
                            Name = "WAITING",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "PENDING",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "LATE       ",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "COMPLETE",
                            Values = new double[] { 0},
                            InnerRadius = 100

                        },
                    };
                    Pies2 = new ISeries[]
                    {
                        new PieSeries<double>
                        {
                            Name = "WAITING",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "PENDING",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "LATE       ",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "COMPLETE",
                            Values = new double[] { 0},
                            InnerRadius = 100

                        },
                    };
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
        public async Task LoadAllByMonth()
        {
            try
            {
                Staffs = new ObservableCollection<UsersDTOMore>(await UserService.Ins.GetTop5UserByMonth(SelectedMonth1));
                if (Staffs.Count > 0)
                {
                    JobsPie = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJobByAssigneeID("USER", (int)Staffs[0].id));
                    var pending = 0;
                    var waiting = 0;
                    var complete_late = 0;
                    var complete_soon = 0;
                    var late = 0;

                    waiting = JobsPie.Where(item => item.stage == "WAITING" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Month == SelectedMonth1 &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year).Count();
                    pending = JobsPie.Where(item => item.stage == "PENDING" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Month == SelectedMonth1 &&
                        DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year).Count();
                    late = JobsPie.Where(item => item.stage == "LATE" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Month == SelectedMonth1 &&
                        DateTime.ParseExact(item.due_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year).Count();
                    complete_soon = JobsPie.Where(item => item.stage == "COMPLETE SOON" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Month == SelectedMonth1 &&
                        DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year).Count();
                    complete_late = JobsPie.Where(item => item.stage == "COMPLETE LATE" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Month == SelectedMonth1 &&
                        DateTime.ParseExact(item.end_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year).Count();

                    Pies1 = new ISeries[]
                    {
                        new PieSeries<double>
                        {
                            Name = "WAITING",
                            Values = new double[] { waiting },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "PENDING",
                            Values = new double[] { pending },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "LATE       ",
                            Values = new double[] { late },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "COMPLETE",
                            Values = new double[] { complete_late + complete_soon },
                            InnerRadius = 100

                        },
                    };
                    if (Staffs.Count == 1)
                    {
                        Pies2 = new ISeries[]
                        {
                            new PieSeries<double>
                            {
                                Name = Staffs[0].id + " - " + Staffs[0].name,
                                Values = new double[] { (double) Staffs[0].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                        };
                    }
                    if (Staffs.Count == 2)
                    {
                        Pies2 = new ISeries[]
                        {
                           new PieSeries<double>
                            {
                                Name = Staffs[0].id + " - " + Staffs[0].name,
                                Values = new double[] { (double) Staffs[0].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[1].id + " - " + Staffs[1].name,
                                Values = new double[] { (double) Staffs[1].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                        };
                    }
                    if (Staffs.Count == 3)
                    {
                        Pies2 = new ISeries[]
                        {
                            new PieSeries<double>
                            {
                                Name = Staffs[0].id + " - " + Staffs[0].name,
                                Values = new double[] { (double) Staffs[0].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[1].id + " - " + Staffs[1].name,
                                Values = new double[] { (double) Staffs[1].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[2].id + " - " + Staffs[2].name,
                                Values = new double[] { (double) Staffs[2].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                        };
                    }
                    if (Staffs.Count == 4)
                    {
                        Pies2 = new ISeries[]
                        {
                            new PieSeries<double>
                            {
                                Name = Staffs[0].id + " - " + Staffs[0].name,
                                Values = new double[] { (double) Staffs[0].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[1].id + " - " + Staffs[1].name,
                                Values = new double[] { (double) Staffs[1].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[2].id + " - " + Staffs[2].name,
                                Values = new double[] { (double) Staffs[2].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[3].id + " - " + Staffs[3].name,
                                Values = new double[] { (double) Staffs[3].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                        };
                    }
                    if (Staffs.Count == 5)
                    {
                        Pies2 = new ISeries[]
                        {
                            new PieSeries<double>
                            {
                                Name = Staffs[0].id + " - " + Staffs[0].name,
                                Values = new double[] { (double) Staffs[0].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[1].id + " - " + Staffs[1].name,
                                Values = new double[] { (double) Staffs[1].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[2].id + " - " + Staffs[2].name,
                                Values = new double[] { (double) Staffs[2].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[3].id + " - " + Staffs[3].name,
                                Values = new double[] { (double) Staffs[3].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                           new PieSeries<double>
                            {
                                Name = Staffs[4].id + " - " + Staffs[4].name,
                                Values = new double[] { (double) Staffs[4].completedJobQuantity },
                                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                                DataLabelsSize = 12,
                                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                                DataLabelsFormatter =  p => $"{p.StackedValue.Share:P2}",
                            },
                        };
                    }
                }
                else
                {
                    Pies1 = new ISeries[]
                    {
                        new PieSeries<double>
                        {
                            Name = "WAITING",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "PENDING",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "LATE       ",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "COMPLETE",
                            Values = new double[] { 0},
                            InnerRadius = 100

                        },
                    };
                    Pies2 = new ISeries[]
                    {
                        new PieSeries<double>
                        {
                            Name = "WAITING",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "PENDING",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "LATE       ",
                            Values = new double[] { 0 },
                            InnerRadius = 100
                        },
                        new PieSeries<double>
                        {
                            Name = "COMPLETE",
                            Values = new double[] { 0},
                            InnerRadius = 100

                        },
                    };
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
        public async Task LoadJobByYear()
        {
            try
            {
                Jobs = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
                double pendingQuantity = 0;
                double lateQuantity = 0;
                double completeSoonQuantity = 0;
                double completeLateQuantity = 0;
                double assignedQuantity = 0;
                double completedQuantity = 0;


                pendingQuantity = Jobs.Where(item =>
                        item.stage == "PENDING" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == SelectedYear
                        ).Count();
                lateQuantity = Jobs.Where(item =>
                        item.stage == "LATE" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == SelectedYear
                        ).Count();
                completeSoonQuantity = Jobs.Where(item =>
                        item.stage == "COMPLETE SOON" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == SelectedYear
                        ).Count();
                completeLateQuantity = Jobs.Where(item =>
                        item.stage == "COMPLETE LATE" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == SelectedYear
                        ).Count();
                assignedQuantity = pendingQuantity + lateQuantity + completeSoonQuantity + completeLateQuantity;
                completedQuantity = assignedQuantity - pendingQuantity - lateQuantity;
                if(assignedQuantity > 0)
                {
                    jobPendingQuantity = pendingQuantity.ToString();
                    jobPendingPercent = Math.Round(((pendingQuantity / assignedQuantity) * 100), 2).ToString() + "%";
                    jobLateQuantity = lateQuantity.ToString();
                    jobLatePercent = Math.Round(((lateQuantity / assignedQuantity) * 100), 2).ToString() + "%";
                    jobCompletedSoonQuantity = completeSoonQuantity.ToString();
                    jobCompletedSoonPercent = Math.Round(((completeSoonQuantity / assignedQuantity) * 100), 2).ToString() + "%";
                    jobCompletedLateQuantity = completeLateQuantity.ToString();
                    jobCompletedLatePercent = Math.Round(((completeLateQuantity / assignedQuantity) * 100), 2).ToString() + "%";
                }
                else
                {
                    jobPendingQuantity = "0";
                    jobPendingPercent = "0" + "%";
                    jobLateQuantity = "0";
                    jobLatePercent = "0" + "%";
                    jobCompletedSoonQuantity = "0";
                    jobCompletedSoonPercent = "0" + "%";
                    jobCompletedLateQuantity = "0";
                    jobCompletedLatePercent = "0" + "%";
                }
                

                AssignedJobQuantity = assignedQuantity.ToString(); 
                CompletedJobQuantity= completedQuantity.ToString();

                double[] assignedJob = new double[12];
                double[] completedJob = new double[12];
                for (int i = 0; i < 12; i++)
                {
                    assignedJob[i] = Jobs.Where(item =>
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Month == i + 1 &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == SelectedYear
                        ).Count();
                    completedJob[i] = Jobs.Where(item => (item.stage == "COMPLETE LATE" || item.stage == "COMPLETE SOON") &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Month == i + 1 &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == SelectedYear 
                        ).Count();
                }


                Lines = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Name = "Assigned Job",
                        Values = assignedJob,
                    },
                    new LineSeries<double>
                    {
                        Name = "Completed Job",
                        Values = completedJob,
                        Fill = null
                    },
                };
                LinesXAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Assigned/Completed Job",
                        NamePaint = new SolidColorPaint { Color = SKColors.Red },
                        Labels = new string[] { "1", "2", "3" , "4" , "5" , "6" , "7" , "8" , "9" , "10", "11" , "12"  },
                        MaxLimit= 12,
                        LabelsPaint = new SolidColorPaint
                        {
                            Color = SKColors.Black,
                        }
                    }
                };
                LinesYAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Job Quantity",
                        NamePadding = new LiveChartsCore.Drawing.Padding(0),
                        
                        Labeler = Labelers.Default
                    }
                };
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
        public async Task LoadJobByMonth()
        {
            try
            {
                Jobs = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
                double pendingQuantity = 0;
                double lateQuantity = 0;
                double completeSoonQuantity = 0;
                double completeLateQuantity = 0;
                double assignedQuantity = 0;
                double completedQuantity = 0;


                pendingQuantity = Jobs.Where(item =>
                        item.stage == "PENDING" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Month == SelectedMonth &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year
                        ).Count();
                lateQuantity = Jobs.Where(item =>
                        item.stage == "LATE" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Month == SelectedMonth &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year
                        ).Count();
                completeSoonQuantity = Jobs.Where(item =>
                        item.stage == "COMPLETE SOON" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Month == SelectedMonth &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year
                        ).Count();
                completeLateQuantity = Jobs.Where(item =>
                        item.stage == "COMPLETE LATE" &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Month == SelectedMonth &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year
                        ).Count();
                assignedQuantity = pendingQuantity + lateQuantity + completeSoonQuantity + completeLateQuantity;
                completedQuantity = assignedQuantity - pendingQuantity - lateQuantity;
                if (assignedQuantity > 0)
                {
                    jobPendingQuantity = pendingQuantity.ToString();
                    jobPendingPercent = Math.Round(((pendingQuantity / assignedQuantity) * 100), 2).ToString() + "%";
                    jobLateQuantity = lateQuantity.ToString();
                    jobLatePercent = Math.Round(((lateQuantity / assignedQuantity) * 100), 2).ToString() + "%";
                    jobCompletedSoonQuantity = completeSoonQuantity.ToString();
                    jobCompletedSoonPercent = Math.Round(((completeSoonQuantity / assignedQuantity) * 100), 2).ToString() + "%";
                    jobCompletedLateQuantity = completeLateQuantity.ToString();
                    jobCompletedLatePercent = Math.Round(((completeLateQuantity / assignedQuantity) * 100), 2).ToString() + "%";
                }
                else
                {
                    jobPendingQuantity = "0";
                    jobPendingPercent = "0" + "%";
                    jobLateQuantity = "0";
                    jobLatePercent = "0" + "%";
                    jobCompletedSoonQuantity = "0";
                    jobCompletedSoonPercent = "0" + "%";
                    jobCompletedLateQuantity = "0";
                    jobCompletedLatePercent = "0" + "%";
                }


                AssignedJobQuantity = assignedQuantity.ToString();
                CompletedJobQuantity = completedQuantity.ToString();

                int lasdayofmonth = DateTime.DaysInMonth(DateTime.Now.Year, SelectedMonth);
                double[] assignedJob = new double[lasdayofmonth];
                double[] completedJob = new double[lasdayofmonth];
                string[] labelnhe = new string[lasdayofmonth];
                for (int i = 0; i < lasdayofmonth; i++)
                {
                    assignedJob[i] = Jobs.Where(item =>
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Day == i +1  &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Month == SelectedMonth &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year
                        ).Count();
                    completedJob[i] = Jobs.Where(item => (item.stage == "COMPLETE LATE" || item.stage == "COMPLETE SOON") &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Day == i + 1 &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Month == SelectedMonth &&
                        DateTime.ParseExact(item.start_date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year
                        ).Count();
                    labelnhe[i] = (i + 1).ToString();
                }


                Lines = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Name = "Assigned Job",
                        Values = assignedJob,
                    },
                    new LineSeries<double>
                    {
                        Name = "Completed Job",
                        Values = completedJob,
                        Fill = null
                    },
                };
                LinesXAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Assigned/Completed Job",
                        NamePaint = new SolidColorPaint { Color = SKColors.Red },
                        Labels = labelnhe,
                        MaxLimit= lasdayofmonth ,
                        LabelsPaint = new SolidColorPaint
                        {
                            Color = SKColors.Black,
                        }
                    }
                };
                LinesYAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Job Quantity",
                        NamePadding = new LiveChartsCore.Drawing.Padding(0),

                        Labeler = Labelers.Default
                    }
                };
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

        public void innhe(string a)
        {
            Notification w = new Notification(a);
            w.ShowDialog();
        }
    }
}
