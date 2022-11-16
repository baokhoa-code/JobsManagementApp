﻿using JobsManagementApp.Model;
using JobsManagementApp.Service;
using JobsManagementApp.View.Admin;
using JobsManagementApp.View.Admin.DashBoard;
using JobsManagementApp.View.Admin.Staff;
using JobsManagementApp.View.Admin.Job;
using JobsManagementApp.View.Admin.JobAssign;
using JobsManagementApp.View.Admin.Report;
using JobsManagementApp.View.Share;
using JobsManagementApp.View.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Windows.Documents;
using System.Data;
using System.Linq.Expressions;
using System.Collections;
using MaterialDesignThemes.Wpf;
using System.ComponentModel;

namespace JobsManagementApp.ViewModel.AdminModel
{
    public class JobManagementPageAdminViewModel : BaseViewModel
    {
        private ComboBoxItem _SelectedType;
        public ComboBoxItem SelectedType
        {
            get { return _SelectedType; }
            set { _SelectedType = value; OnPropertyChanged(); }
        }
        public Admin admin { get; set; }
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
        public Page CurrentPage { get; set; }
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
        public ICommand OpenAddJobWindowCM { get; set; }
        public ICommand OpenCategoryWindowCM { get; set; }
        public ICommand SaveCurrentPageCM { get; set; }
        public ICommand MaskNameCM { get; set; }
        public ICommand GetJobListCM { get; set; }
        public ICommand ListWeekRageChangeCM { get; set; }
        public ICommand ListMonthChangeCM { get; set; }
        public ICommand ListYearChangeCM { get; set; }
        public ObservableCollection<JobsDTO> Jobs { get; set; }
        public ObservableCollection<JobsDTO> JobsStore { get; set; }
        public JobManagementPageAdminViewModel()
        {
            //GET CURRENT TIME
            CurrentYear = DateTime.Now.Year.ToString();
            CurrentMonth = DateTime.Now.Month.ToString();
            CurrentDate = DateTime.Now.Day.ToString();

            //GET ALL JOB
            Jobs = JobService.Ins.GetAllJob();
            JobsStore = new ObservableCollection<JobsDTO>(Jobs);

            //INSERT WEEK, MONTH, YEAR COMBOBOX
            InsertWeekCombobox();
            InsertMonthCombobox(CurrentMonth);
            InsertYearCombobox();

            //GET CURRENT WEEK, MONTH, YEAR JOB AMOUNT
            InsertWeekJobAmount();
            InsertMonthJobAmount();
            InsertYearJobAmount();

            GetJobListCM = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                listView = p;
            });
            SaveCurrentPageCM = new RelayCommand<Page>((p) => { return true; }, async (p) =>
            {
                CurrentPage = p;
            });
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });
            OpenAddJobWindowCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                //JobAddWindow wd = new JobAddWindow();
                //MaskName.Visibility = Visibility.Visible;
                //wd.ShowDialog();
            });
            OpenCategoryWindowCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                ShowTableToChoose wd = new ShowTableToChoose();
                MaskName.Visibility = Visibility.Visible;
                wd.ShowDialog();
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
    }
}