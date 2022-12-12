using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Security.Cryptography;

namespace JobsManagementApp.ViewModel.ShareModel
{
    public class ReportAddViewModel : BaseViewModel
    {
        public Admin admin { get; set; }
        public UsersDTO user { get; set; }
        public int jobId { get; set; }
        private ReportsDTO _report;
        public ReportsDTO report
        {
            get { return _report; }
            set { _report = value; OnPropertyChanged(); }
        }

        private ObservableCollection<JobsDTO> _AssignedJobs;
        public ObservableCollection<JobsDTO> AssignedJobs
        {
            get { return _AssignedJobs; }
            set { _AssignedJobs = value; OnPropertyChanged(); }
        }
        private JobsDTO _SelectedAssignedJob;
        public JobsDTO SelectedAssignedJob
        {
            get { return _SelectedAssignedJob; }
            set { _SelectedAssignedJob = value; OnPropertyChanged(); }
        }
        private int _SelectedIndexAssignedJob;
        public int SelectedIndexAssignedJob
        {
            get { return _SelectedIndexAssignedJob; }
            set { _SelectedIndexAssignedJob = value; OnPropertyChanged(); }
        }
        private string _jobAssignor;
        public string jobAssignor
        {
            get { return _jobAssignor; }
            set { _jobAssignor = value; OnPropertyChanged(); }
        }
        private string _jobAssignee;
        public string jobAssignee
        {
            get { return _jobAssignee; }
            set { _jobAssignee = value; OnPropertyChanged(); }
        }
        private string _reportTile;
        public string reportTile
        {
            get { return _reportTile; }
            set { _reportTile = value; OnPropertyChanged(); }
        }
        private string _reportCreatedTime;
        public string reportCreatedTime
        {
            get { return _reportCreatedTime; }
            set { _reportCreatedTime = value; OnPropertyChanged(); }
        }
        private string _reportDescription;
        public string reportDescription
        {
            get { return _reportDescription; }
            set { _reportDescription = value; OnPropertyChanged(); }
        }
        private string _jobStartDate;
        public string jobStartDate
        {
            get { return _jobStartDate; }
            set { _jobStartDate = value; OnPropertyChanged(); }
        }

        public int assigneeid;
        public Grid Mask { get; set; }

        public ICommand LoadCM { get; set; }
        public ICommand AddReportCM { get; set; }
        public ICommand ClearInforCM { get; set; }
        public ICommand CloseWindowCM { get; set; }
        public ICommand JobChangedCM { get; set; }
        public ICommand SaveCreatedTimeCM { get; set; }
        public ReportAddViewModel(Admin a, int job_Id, ObservableCollection<ReportsDTO> Reports)
        {
            admin = new Admin(a);
            report = new ReportsDTO();
            jobId = job_Id;
            //DEFINE COMMAND
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();
                
            });
            JobChangedCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                if(SelectedAssignedJob != null)
                {
                    jobAssignor = SelectedAssignedJob.assignor_id + ": "
                        + SelectedAssignedJob.assignor_type + " - " + SelectedAssignedJob.assignor_name;
                    jobAssignee = SelectedAssignedJob.assignee_id + ": "
                        + SelectedAssignedJob.assignee_type + " - " + SelectedAssignedJob.assignee_name;
                    jobStartDate = SelectedAssignedJob.start_date;
                }
                

            });
            AddReportCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(reportTile))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Report tile cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    report = new ReportsDTO();
                }
                else
                {
                    report.tile = reportTile;
                    if (string.IsNullOrEmpty(reportDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Report description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        report = new ReportsDTO();
                    }
                    else
                    {
                        report.description = reportDescription;
                        if (string.IsNullOrEmpty(reportCreatedTime))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Report created time cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            report = new ReportsDTO();
                        }
                        else
                        {
                            report.created_time = reportCreatedTime;
                            if (SelectedAssignedJob == null)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "You must choose specific job!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                report = new ReportsDTO();
                            }
                            else
                            {
                                report.job_id = SelectedAssignedJob.id;
                                report.job_name = SelectedAssignedJob.name;

                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this report?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.AddReport(report);
                                        if (isSuccess)
                                        {
                                            ReportsDTO temp = ReportService.Ins.GetLatestReport();
                                            if (temp != null)
                                            {
                                                Reports.Add(temp);
                                            }
                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                            mb.ShowDialog();
                                            report = new ReportsDTO();
                                            reportTile = "";
                                            reportDescription = "";
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

            });
            ClearInforCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                report = new ReportsDTO();
                reportTile = "";
                reportCreatedTime = "";
                reportDescription = "";

            });
            CloseWindowCM = new RelayCommand<Window>((p) => { return p != null; }, async (p) =>
            {
                report = new ReportsDTO();
                reportTile = "";
                reportCreatedTime = "";
                reportDescription = "";
                SelectedAssignedJob = null;
                AssignedJobs = null;
                if(Mask != null)
                    Mask.Visibility = Visibility.Collapsed;
                p.Close();

            });
            SaveCreatedTimeCM = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                reportCreatedTime =  p.Text.ToString();
            });
        }

        public ReportAddViewModel(UsersDTO a, int job_Id, ObservableCollection<ReportsDTO> Reports)
        {
            user = a;
            report = new ReportsDTO();
            jobId = job_Id;
            //DEFINE COMMAND
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();

            });
            JobChangedCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                if (SelectedAssignedJob != null)
                {
                    jobAssignor = SelectedAssignedJob.assignor_id + ": "
                        + SelectedAssignedJob.assignor_type + " - " + SelectedAssignedJob.assignor_name;
                    jobAssignee = SelectedAssignedJob.assignee_id + ": "
                        + SelectedAssignedJob.assignee_type + " - " + SelectedAssignedJob.assignee_name;
                    jobStartDate = SelectedAssignedJob.start_date;
                }


            });
            AddReportCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(reportTile))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Report tile cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    report = new ReportsDTO();
                }
                else
                {
                    report.tile = reportTile;
                    if (string.IsNullOrEmpty(reportDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Report description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        report = new ReportsDTO();
                    }
                    else
                    {
                        report.description = reportDescription;
                        if (string.IsNullOrEmpty(reportCreatedTime))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Report created time cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            report = new ReportsDTO();
                        }
                        else
                        {
                            report.created_time = reportCreatedTime;
                            if (SelectedAssignedJob == null)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "You must choose specific job!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                report = new ReportsDTO();
                            }
                            else
                            {
                                report.job_id = SelectedAssignedJob.id;
                                report.job_name = SelectedAssignedJob.name;

                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this report?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.AddReport(report);
                                        if (isSuccess)
                                        {
                                            ReportsDTO temp = ReportService.Ins.GetLatestReport();
                                            if (temp != null)
                                            {
                                                Reports.Add(temp);
                                            }
                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                            mb.ShowDialog();
                                            report = new ReportsDTO();
                                            reportTile = "";
                                            reportDescription = "";
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

            });
            ClearInforCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                report = new ReportsDTO();
                reportTile = "";
                reportCreatedTime = "";
                reportDescription = "";

            });
            CloseWindowCM = new RelayCommand<Window>((p) => { return p != null; }, async (p) =>
            {
                report = new ReportsDTO();
                reportTile = "";
                reportCreatedTime = "";
                reportDescription = "";
                SelectedAssignedJob = null;
                AssignedJobs = null;
                if (Mask != null)
                    Mask.Visibility = Visibility.Collapsed;
                p.Close();

            });
            SaveCreatedTimeCM = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                reportCreatedTime = p.Text.ToString();
            });
        }



        public ReportAddViewModel(Admin a, ObservableCollection<ReportsDTO> Reports, int assignee_Id)
        {
            admin = new Admin(a);
            report = new ReportsDTO();
            assigneeid = assignee_Id;
            //DEFINE COMMAND
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, async (p) =>
            {
                UsersDTO temp = await UserService.Ins.GetUser(assigneeid);
                if(temp != null)
                {
                    reportTile = "";
                    reportCreatedTime = "";
                    reportDescription = "";
                    SelectedAssignedJob = new JobsDTO(); ;
                    SelectedIndexAssignedJob = -1;
                    jobAssignor = "";
                    jobAssignee = "";
                    jobStartDate = "";
                    try
                    {
                        AssignedJobs = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJobByAssigneeID("USER", (int)temp.id));
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
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Assignee is not exist!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                

            });
            JobChangedCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                if (SelectedAssignedJob != null)
                {
                    jobAssignor = SelectedAssignedJob.assignor_id + ": "
                        + SelectedAssignedJob.assignor_type + " - " + SelectedAssignedJob.assignor_name;
                    jobAssignee = SelectedAssignedJob.assignee_id + ": "
                        + SelectedAssignedJob.assignee_type + " - " + SelectedAssignedJob.assignee_name;
                    jobStartDate = SelectedAssignedJob.start_date;
                }


            });
            AddReportCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(reportTile))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Report tile cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    report = new ReportsDTO();
                }
                else
                {
                    report.tile = reportTile;
                    if (string.IsNullOrEmpty(reportDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Report description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        report = new ReportsDTO();
                    }
                    else
                    {
                        report.description = reportDescription;
                        if (string.IsNullOrEmpty(reportCreatedTime))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Report created time cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            report = new ReportsDTO();
                        }
                        else
                        {
                            report.created_time = reportCreatedTime;
                            if (SelectedAssignedJob == null)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "You must choose specific job!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                report = new ReportsDTO();
                            }
                            else
                            {
                                report.job_id = SelectedAssignedJob.id;
                                report.job_name = SelectedAssignedJob.name;

                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this report?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.AddReport(report);
                                        if (isSuccess)
                                        {
                                            ReportsDTO temp = ReportService.Ins.GetLatestReport();
                                            if (temp != null)
                                            {
                                                Reports.Add(temp);
                                            }
                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                            mb.ShowDialog();
                                            report = new ReportsDTO();
                                            reportTile = "";
                                            reportCreatedTime = "";
                                            reportDescription = "";
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

            });
            ClearInforCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                report = new ReportsDTO();
                reportTile = "";
                reportCreatedTime = "";
                reportDescription = "";

            });
            CloseWindowCM = new RelayCommand<Window>((p) => { return p != null; }, async (p) =>
            {
                report = new ReportsDTO();
                reportTile = "";
                reportCreatedTime = "";
                reportDescription = "";
                SelectedAssignedJob = null;
                AssignedJobs = null;
                if (Mask != null)
                    Mask.Visibility = Visibility.Collapsed;
                p.Close();

            });
            SaveCreatedTimeCM = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                reportCreatedTime = p.Text.ToString();
            });
        }

        public ReportAddViewModel(UsersDTO a, ObservableCollection<ReportsDTO> Reports, int assignee_Id)
        {
            user = a;
            report = new ReportsDTO();
            assigneeid = assignee_Id;
            //DEFINE COMMAND
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, async (p) =>
            {
                UsersDTO temp = await UserService.Ins.GetUser(assigneeid);
                if (temp != null)
                {
                    reportTile = "";
                    reportCreatedTime = "";
                    reportDescription = "";
                    SelectedAssignedJob = new JobsDTO(); ;
                    SelectedIndexAssignedJob = -1;
                    jobAssignor = "";
                    jobAssignee = "";
                    jobStartDate = "";
                    try
                    {
                        AssignedJobs = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJobByAssigneeID("USER", (int)temp.id));
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
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Assignee is not exist!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }


            });
            JobChangedCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                if (SelectedAssignedJob != null)
                {
                    jobAssignor = SelectedAssignedJob.assignor_id + ": "
                        + SelectedAssignedJob.assignor_type + " - " + SelectedAssignedJob.assignor_name;
                    jobAssignee = SelectedAssignedJob.assignee_id + ": "
                        + SelectedAssignedJob.assignee_type + " - " + SelectedAssignedJob.assignee_name;
                    jobStartDate = SelectedAssignedJob.start_date;
                }


            });
            AddReportCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(reportTile))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Report tile cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    report = new ReportsDTO();
                }
                else
                {
                    report.tile = reportTile;
                    if (string.IsNullOrEmpty(reportDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Report description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        report = new ReportsDTO();
                    }
                    else
                    {
                        report.description = reportDescription;
                        if (string.IsNullOrEmpty(reportCreatedTime))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Report created time cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            report = new ReportsDTO();
                        }
                        else
                        {
                            report.created_time = reportCreatedTime;
                            if (SelectedAssignedJob == null)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "You must choose specific job!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                report = new ReportsDTO();
                            }
                            else
                            {
                                report.job_id = SelectedAssignedJob.id;
                                report.job_name = SelectedAssignedJob.name;

                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this report?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.AddReport(report);
                                        if (isSuccess)
                                        {
                                            ReportsDTO temp = ReportService.Ins.GetLatestReport();
                                            if (temp != null)
                                            {
                                                Reports.Add(temp);
                                            }
                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                            mb.ShowDialog();
                                            report = new ReportsDTO();
                                            reportTile = "";
                                            reportCreatedTime = "";
                                            reportDescription = "";
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

            });
            ClearInforCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                report = new ReportsDTO();
                reportTile = "";
                reportCreatedTime = "";
                reportDescription = "";

            });
            CloseWindowCM = new RelayCommand<Window>((p) => { return p != null; }, async (p) =>
            {
                report = new ReportsDTO();
                reportTile = "";
                reportCreatedTime = "";
                reportDescription = "";
                SelectedAssignedJob = null;
                AssignedJobs = null;
                if (Mask != null)
                    Mask.Visibility = Visibility.Collapsed;
                p.Close();

            });
            SaveCreatedTimeCM = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                reportCreatedTime = p.Text.ToString();
            });
        }

        public async Task Load()
        {
            reportTile = "";
            reportCreatedTime = "";
            reportDescription = "";
            SelectedAssignedJob = new JobsDTO(); ;
            SelectedIndexAssignedJob = -1;
            jobAssignor = "";
            jobAssignee = "";
            jobStartDate = "";
            try
            {
                AssignedJobs = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllAssignedJob());
                if(jobId > 0)
                {
                    SelectedAssignedJob = await JobService.Ins.GetJobByJobId(jobId);
                    for (int i = 0; i < AssignedJobs.Count; i++)
                    {
                        if (AssignedJobs[i].id == SelectedAssignedJob?.id)
                        {
                            SelectedIndexAssignedJob = i;
                            i = AssignedJobs.Count;
                        }
                    }
                    jobAssignor = SelectedAssignedJob.assignor_id + ": "
                        + SelectedAssignedJob.assignor_type + " - " + SelectedAssignedJob.assignor_name;
                    jobAssignee = SelectedAssignedJob.assignee_id + ": "
                        + SelectedAssignedJob.assignee_type + " - " + SelectedAssignedJob.assignee_name;
                    jobStartDate = SelectedAssignedJob.start_date;

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
        public async Task LoadJob(int jobID)
        {
            try
            {
                SelectedAssignedJob = await JobService.Ins.GetJobByJobId(jobID);
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