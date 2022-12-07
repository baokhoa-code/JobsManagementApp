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
using System.Xml.Linq;
using System.Reflection;
using MaterialDesignColors;
using System.Security.Cryptography;

namespace JobsManagementApp.ViewModel.ShareModel
{
    class ReportDetailViewModel : BaseViewModel
    {
        #region Binding Varirables

        private ObservableCollection<ReportsDTO> _Reports;
        public ObservableCollection<ReportsDTO> Reports
        {
            get { return _Reports; }
            set { _Reports = value; OnPropertyChanged(); }
        }

        private ReportsDTO _BackupReport;
        public ReportsDTO BackupReport
        {
            get { return _BackupReport; }
            set { _BackupReport = value; OnPropertyChanged(); }
        }
        
        private ReportsDTO _CurrentReport;
        public ReportsDTO CurrentReport
        {
            get { return _CurrentReport; }
            set { _CurrentReport = value; OnPropertyChanged(); }
        }
        private bool _AssigneeChanagable;
        public bool AssigneeChanagable
        {
            get { return _AssigneeChanagable; }
            set { _AssigneeChanagable = value; OnPropertyChanged(); }
        }
        private bool _IsChangable;
        public bool IsChangable
        {
            get { return _IsChangable; }
            set { _IsChangable = value; OnPropertyChanged(); }
        }


        #endregion

        #region Internal Varirables
        public Admin admin { get; set; }
        public UsersDTO user { get; set; }
        private JobsDTO _job;
        public JobsDTO job
        {
            get { return _job; }
            set { _job = value; OnPropertyChanged(); }
        }
        public static Grid MaskName { get; set; }

        #endregion

        #region Commands

        public ICommand LoadCM { get; set; }
        public ICommand UpdateReportCM { get; set; }
        public ICommand GoBackCM { get; set; }
        public ICommand UpdateCurrentCM { get; set; }
        public ICommand SaveCreatedTimeCM { get; set; }
        public ICommand DeleteReportCM { get; set; }
        public ICommand OpenAddReportWindowCM { get; set; }
        public ICommand MaskNameCM { get; set; }
        #endregion

        public ReportDetailViewModel(Admin a, JobsDTO job_t)
        {
            admin = a;
            job = new JobsDTO();
            AssigneeChanagable = true;
            Reports = new ObservableCollection<ReportsDTO>();
            BackupReport = new ReportsDTO();
            CurrentReport = new ReportsDTO();
            IsChangable = true;
            //DEFINE COMMANDS
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });
            GoBackCM = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                p.NavigationService.GoBack();
            });
            OpenAddReportWindowCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                ReportAddWindow dba = new ReportAddWindow();
                ReportAddViewModel vm = new ReportAddViewModel(admin, (int)job_t.id, Reports);
                MaskName.Visibility = Visibility.Visible;
                vm.Mask = MaskName;
                dba.DataContext = vm;
                dba.ShowDialog();
            });
            LoadCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                job = JobService.Ins.GetJob((int)job_t.id);
                if (job == null)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Chosen job is not exist!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {

                    try
                    {
                        Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));
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
                    if (Reports.Count <= 0)
                    {
                        MessageBoxCustom result = new MessageBoxCustom("Warning", "The current job do not have any report!", MessageType.Warning, MessageButtons.OK);
                        result.ShowDialog();
                    }
                    else
                    {
                        BackupReport = Reports[0];
                        CurrentReport = new ReportsDTO(BackupReport);

                    }

                }

            });
            UpdateCurrentCM = new RelayCommand<object>((p) => { return BackupReport!=null; }, async (p) =>
            {
                CurrentReport = new ReportsDTO(BackupReport);
            });
            UpdateReportCM = new RelayCommand<object>((p) => { return Reports != null && Reports.Count > 0 ; }, async (p) =>
            {
                if (string.IsNullOrEmpty(CurrentReport.tile))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Report tile cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    if (string.IsNullOrEmpty(CurrentReport.description))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Report description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(CurrentReport.created_time))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Report created time cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                        }
                        else
                        {
                            MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you really want to update this report?", MessageType.Warning, MessageButtons.YesNo);
                            result.ShowDialog();

                            if (result.DialogResult == true)
                            {
                                (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.UpdateReport(CurrentReport);
                                if (isSuccess)
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                    mb.ShowDialog();

                                    Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));

                                    for (int i = 0; i < Reports.Count; i++)
                                    {
                                        if (Reports[i].id == CurrentReport.id)
                                        {
                                            BackupReport = Reports[i];
                                            CurrentReport = new ReportsDTO(BackupReport);
                                            i = Reports.Count;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Error", messageFromUpdate, MessageType.Error, MessageButtons.OK);
                                    mb.ShowDialog();
                                }
                            }
                        }
                    }
                }
            });
            SaveCreatedTimeCM = new RelayCommand<TextBox>((p) => { return true; },  (p) =>
            {
                DateTime temp = DateTime.ParseExact(p.Text, "dd-MM-yyyy hh:mm tt",
                    System.Globalization.CultureInfo.InvariantCulture);
                string temps = temp.ToString("dd-MM-yyyy");

                DateTime NewDate = DateTime.ParseExact(temps, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);

                DateTime job_start_date = DateTime.ParseExact(job.start_date, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);

                if (DateTime.Compare(NewDate, job_start_date) < 0)
                {
                    
                    MessageBoxCustom mb = new MessageBoxCustom("Warning", "Created time must greater than job start date ", MessageType.Warning, MessageButtons.OK);
                    mb.ShowDialog();
                    p.Text = CurrentReport.created_time = BackupReport.created_time;
                }
                if (DateTime.Compare(NewDate, job_start_date) >= 0)
                {
                    CurrentReport.created_time = p.Text;
                }

            });
            DeleteReportCM = new RelayCommand<object>((p) => { return Reports != null && Reports.Count > 0; }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this report?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();

                if (result.DialogResult == true)
                {
                    (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.DeleteReport((int)CurrentReport.id);
                    if (isSuccess)
                    {

                        MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                        mb.ShowDialog();
                        Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));
                        if (Reports.Count <= 0)
                        {
                            MessageBoxCustom result2 = new MessageBoxCustom("Infor", "The current job do not have any report!", MessageType.Info, MessageButtons.OK);
                            result2.ShowDialog();
                        }
                        else
                        {
                            BackupReport = Reports[0];
                            CurrentReport = new ReportsDTO(BackupReport);
                        }
                        
                    }
                    else
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", messageFromUpdate, MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                }
            });
        }

        public ReportDetailViewModel(UsersDTO a, JobsDTO job_t)
        {
            user = a;
            job = new JobsDTO();
            AssigneeChanagable = true;
            Reports = new ObservableCollection<ReportsDTO>();
            BackupReport = new ReportsDTO();
            CurrentReport = new ReportsDTO();

            //DEFINE COMMANDS
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });
            GoBackCM = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                p.NavigationService.GoBack();
            });
            OpenAddReportWindowCM = new RelayCommand<object>((p) => { return ((job.assignee_type == "USER" && job.assignee_id == user.id) || (job.assignor_type == "USER" && job.assignor_id == user.id))
;
            }, async (p) =>
            {
                ReportAddWindow dba = new ReportAddWindow();
                ReportAddViewModel vm = new ReportAddViewModel(user, (int)job_t.id, Reports);
                MaskName.Visibility = Visibility.Visible;
                vm.Mask = MaskName;
                dba.DataContext = vm;
                dba.ShowDialog();
            });
            LoadCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                job = JobService.Ins.GetJob((int)job_t.id);
                if (job == null)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Chosen job is not exist!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    try
                    {
                        Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));
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
                    if (Reports.Count <= 0)
                    {
                        MessageBoxCustom result = new MessageBoxCustom("Warning", "The current job do not have any report!", MessageType.Warning, MessageButtons.OK);
                        result.ShowDialog();
                    }
                    else
                    {
                        BackupReport = Reports[0];
                        CurrentReport = new ReportsDTO(BackupReport);

                    }
                    if (!((job.assignee_type == "USER" && job.assignee_id == user.id) || (job.assignor_type == "USER" && job.assignor_id == user.id)))
                    {
                        IsChangable = false;
                    }
                    else
                    {
                        IsChangable = true;
                    }

                }

            });
            UpdateCurrentCM = new RelayCommand<object>((p) => { return BackupReport != null; }, async (p) =>
            {
                CurrentReport = new ReportsDTO(BackupReport);
            });
            UpdateReportCM = new RelayCommand<object>((p) => { return Reports != null && Reports.Count > 0  && ((job.assignee_type == "USER" && job.assignee_id == user.id) || (job.assignor_type == "USER" && job.assignor_id == user.id));}, async (p) =>
            {
                if (string.IsNullOrEmpty(CurrentReport.tile))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Report tile cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    if (string.IsNullOrEmpty(CurrentReport.description))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Report description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(CurrentReport.created_time))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Report created time cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                        }
                        else
                        {
                            MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you really want to update this report?", MessageType.Warning, MessageButtons.YesNo);
                            result.ShowDialog();

                            if (result.DialogResult == true)
                            {
                                (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.UpdateReport(CurrentReport);
                                if (isSuccess)
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                    mb.ShowDialog();

                                    Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));

                                    for (int i = 0; i < Reports.Count; i++)
                                    {
                                        if (Reports[i].id == CurrentReport.id)
                                        {
                                            BackupReport = Reports[i];
                                            CurrentReport = new ReportsDTO(BackupReport);
                                            i = Reports.Count;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Error", messageFromUpdate, MessageType.Error, MessageButtons.OK);
                                    mb.ShowDialog();
                                }
                            }
                        }
                    }
                }
            });
            SaveCreatedTimeCM = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                DateTime temp = DateTime.ParseExact(p.Text, "dd-MM-yyyy hh:mm tt",
                    System.Globalization.CultureInfo.InvariantCulture);
                string temps = temp.ToString("dd-MM-yyyy");

                DateTime NewDate = DateTime.ParseExact(temps, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);

                DateTime job_start_date = DateTime.ParseExact(job.start_date, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);

                if (DateTime.Compare(NewDate, job_start_date) < 0)
                {

                    MessageBoxCustom mb = new MessageBoxCustom("Warning", "Created time must greater than job start date ", MessageType.Warning, MessageButtons.OK);
                    mb.ShowDialog();
                    p.Text = CurrentReport.created_time = BackupReport.created_time;
                }
                if (DateTime.Compare(NewDate, job_start_date) >= 0)
                {
                    CurrentReport.created_time = p.Text;
                }

            });
            DeleteReportCM = new RelayCommand<object>((p) => { return Reports != null && Reports.Count > 0 && ((job.assignee_type == "USER" && job.assignee_id == user.id) || (job.assignor_type == "USER" && job.assignor_id == user.id))
;
            }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this report?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();

                if (result.DialogResult == true)
                {
                    (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.DeleteReport((int)CurrentReport.id);
                    if (isSuccess)
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                        mb.ShowDialog();
                        Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));
                        if (Reports.Count <= 0)
                        {
                            MessageBoxCustom result2 = new MessageBoxCustom("Infor", "The current job do not have any report!", MessageType.Info, MessageButtons.OK);
                            result2.ShowDialog();
                        }
                        else
                        {
                            BackupReport = Reports[0];
                            CurrentReport = new ReportsDTO(BackupReport);
                        }
                    }
                    else
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", messageFromUpdate, MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                }
            });
        }



        public ReportDetailViewModel(Admin a, ReportsDTO report_t)
        {
            admin = a;
            job = new JobsDTO();
            AssigneeChanagable = true;
            Reports = new ObservableCollection<ReportsDTO>();
            BackupReport = new ReportsDTO();
            CurrentReport = new ReportsDTO();
            IsChangable = true;
            //DEFINE COMMANDS
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });
            GoBackCM = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                p.NavigationService.GoBack();
            });
            OpenAddReportWindowCM = new RelayCommand<object>((p) => { return job != null; }, async (p) =>
            {
                ReportAddWindow dba = new ReportAddWindow();
                ReportAddViewModel vm = new ReportAddViewModel(admin, (int)job.id, Reports);
                MaskName.Visibility = Visibility.Visible;
                vm.Mask = MaskName;
                dba.DataContext = vm;
                dba.ShowDialog();
            });
            LoadCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                ReportsDTO tempr = ReportService.Ins.GetReport((int)report_t.id);
                if (tempr == null)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Chosen report is not exist!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    job = JobService.Ins.GetJob((int)report_t.job_id);
                    try
                    {
                        Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));
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

                    for (int i = 0; i < Reports.Count; i++)
                    {
                        if (Reports[i].id == tempr.id)
                        {
                            BackupReport = Reports[i];
                            CurrentReport = new ReportsDTO(BackupReport);
                            i = Reports.Count;
                        }
                    }

                }

            });
            UpdateCurrentCM = new RelayCommand<object>((p) => { return BackupReport != null; }, async (p) =>
            {
                CurrentReport = new ReportsDTO(BackupReport);
            });
            UpdateReportCM = new RelayCommand<object>((p) => { return Reports != null && Reports.Count > 0 ; }, async (p) =>
            {
                if (string.IsNullOrEmpty(CurrentReport.tile))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Report tile cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    if (string.IsNullOrEmpty(CurrentReport.description))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Report description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(CurrentReport.created_time))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Report created time cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                        }
                        else
                        {
                            MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you really want to update this report?", MessageType.Warning, MessageButtons.YesNo);
                            result.ShowDialog();

                            if (result.DialogResult == true)
                            {
                                (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.UpdateReport(CurrentReport);
                                if (isSuccess)
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                    mb.ShowDialog();

                                    Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));

                                    for (int i = 0; i < Reports.Count; i++)
                                    {
                                        if (Reports[i].id == CurrentReport.id)
                                        {
                                            BackupReport = Reports[i];
                                            CurrentReport = new ReportsDTO(BackupReport);
                                            i = Reports.Count;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Error", messageFromUpdate, MessageType.Error, MessageButtons.OK);
                                    mb.ShowDialog();
                                }
                            }
                        }
                    }
                }
            });
            SaveCreatedTimeCM = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                DateTime temp = DateTime.ParseExact(p.Text, "dd-MM-yyyy hh:mm tt",
                    System.Globalization.CultureInfo.InvariantCulture);
                string temps = temp.ToString("dd-MM-yyyy");

                DateTime NewDate = DateTime.ParseExact(temps, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);

                DateTime job_start_date = DateTime.ParseExact(job.start_date, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);

                if (DateTime.Compare(NewDate, job_start_date) < 0)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Warning", "Created time must greater than job start date ", MessageType.Warning, MessageButtons.OK);
                    mb.ShowDialog();
                    p.Text = CurrentReport.created_time = BackupReport.created_time;
                }
                if (DateTime.Compare(NewDate, job_start_date) >= 0)
                {
                    CurrentReport.created_time = p.Text;
                }

            });
            DeleteReportCM = new RelayCommand<object>((p) => { return Reports != null && Reports.Count > 0 ; }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this report?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();

                if (result.DialogResult == true)
                {
                    (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.DeleteReport((int)CurrentReport.id);
                    if (isSuccess)
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                        mb.ShowDialog();
                        Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));
                        if (Reports.Count <= 0)
                        {
                            MessageBoxCustom result2 = new MessageBoxCustom("Infor", "The current job do not have any report!", MessageType.Info, MessageButtons.OK);
                            result2.ShowDialog();
                        }
                        else
                        {
                            BackupReport = Reports[0];
                            CurrentReport = new ReportsDTO(BackupReport);
                        }
                    }
                    else
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", messageFromUpdate, MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                }
            });
        }

        public ReportDetailViewModel(UsersDTO a, ReportsDTO report_t)
        {
            user = a;
            job = new JobsDTO();
            AssigneeChanagable = true;
            Reports = new ObservableCollection<ReportsDTO>();
            BackupReport = new ReportsDTO();
            CurrentReport = new ReportsDTO();

            //DEFINE COMMANDS
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });
            GoBackCM = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                p.NavigationService.GoBack();
            });
            OpenAddReportWindowCM = new RelayCommand<object>((p) => { return job != null && ((job.assignee_type == "USER" && job.assignee_id == user.id) || (job.assignor_type == "USER" && job.assignor_id == user.id))
;
            }, async (p) =>
            {
                ReportAddWindow dba = new ReportAddWindow();
                ReportAddViewModel vm = new ReportAddViewModel(user, (int)job.id, Reports);
                MaskName.Visibility = Visibility.Visible;
                vm.Mask = MaskName;
                dba.DataContext = vm;
                dba.ShowDialog();
            });
            LoadCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                ReportsDTO tempr = ReportService.Ins.GetReport((int)report_t.id);
                if (tempr == null)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Chosen report is not exist!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    job = JobService.Ins.GetJob((int)report_t.job_id);
                    try
                    {
                        Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));
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
                    if (!((job.assignee_type == "USER" && job.assignee_id == user.id) || (job.assignor_type == "USER" && job.assignor_id == user.id)))
                    {
                        IsChangable = false;
                    }
                    else
                    {
                        IsChangable = true;
                    }
                    for (int i = 0; i < Reports.Count; i++)
                    {
                        if (Reports[i].id == tempr.id)
                        {
                            BackupReport = Reports[i];
                            CurrentReport = new ReportsDTO(BackupReport);
                            i = Reports.Count;
                        }
                    }

                }

            });
            UpdateCurrentCM = new RelayCommand<object>((p) => { return BackupReport != null; }, async (p) =>
            {
                CurrentReport = new ReportsDTO(BackupReport);
            });
            UpdateReportCM = new RelayCommand<object>((p) => { return Reports != null && Reports.Count > 0 && job != null && ((job.assignee_type == "USER" && job.assignee_id == user.id) || (job.assignor_type == "USER" && job.assignor_id == user.id)); }, async (p) =>
            {
                if (string.IsNullOrEmpty(CurrentReport.tile))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Report tile cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    if (string.IsNullOrEmpty(CurrentReport.description))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Report description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(CurrentReport.created_time))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Report created time cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                        }
                        else
                        {
                            MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you really want to update this report?", MessageType.Warning, MessageButtons.YesNo);
                            result.ShowDialog();

                            if (result.DialogResult == true)
                            {
                                (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.UpdateReport(CurrentReport);
                                if (isSuccess)
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                    mb.ShowDialog();

                                    Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));

                                    for (int i = 0; i < Reports.Count; i++)
                                    {
                                        if (Reports[i].id == CurrentReport.id)
                                        {
                                            BackupReport = Reports[i];
                                            CurrentReport = new ReportsDTO(BackupReport);
                                            i = Reports.Count;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Error", messageFromUpdate, MessageType.Error, MessageButtons.OK);
                                    mb.ShowDialog();
                                }
                            }
                        }
                    }
                }
            });
            SaveCreatedTimeCM = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                DateTime temp = DateTime.ParseExact(p.Text, "dd-MM-yyyy hh:mm tt",
                    System.Globalization.CultureInfo.InvariantCulture);
                string temps = temp.ToString("dd-MM-yyyy");

                DateTime NewDate = DateTime.ParseExact(temps, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);

                DateTime job_start_date = DateTime.ParseExact(job.start_date, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);

                if (DateTime.Compare(NewDate, job_start_date) < 0)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Warning", "Created time must greater than job start date ", MessageType.Warning, MessageButtons.OK);
                    mb.ShowDialog();
                    p.Text = CurrentReport.created_time = BackupReport.created_time;
                }
                if (DateTime.Compare(NewDate, job_start_date) >= 0)
                {
                    CurrentReport.created_time = p.Text;
                }

            });
            DeleteReportCM = new RelayCommand<object>((p) => { return Reports != null && Reports.Count > 0 && job != null && ((job.assignee_type == "USER" && job.assignee_id == user.id) || (job.assignor_type == "USER" && job.assignor_id == user.id)); }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this report?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();

                if (result.DialogResult == true)
                {
                    (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.DeleteReport((int)CurrentReport.id);
                    if (isSuccess)
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                        mb.ShowDialog();
                        Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByJobID((int)job.id));
                        if (Reports.Count <= 0)
                        {
                            MessageBoxCustom result2 = new MessageBoxCustom("Infor", "The current job do not have any report!", MessageType.Info, MessageButtons.OK);
                            result2.ShowDialog();
                        }
                        else
                        {
                            BackupReport = Reports[0];
                            CurrentReport = new ReportsDTO(BackupReport);
                        }
                    }
                    else
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", messageFromUpdate, MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                }
            });
        }



        #region Internal functions
        public void innhe(string a)
        {
            Notification w = new Notification(a);
            w.ShowDialog();
        }
        #endregion
    }
}
