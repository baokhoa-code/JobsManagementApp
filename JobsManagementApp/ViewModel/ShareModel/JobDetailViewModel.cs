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
using JobsManagementApp.ViewModel.AdminModel;
using JobsManagementApp.View.Admin.DashBoard;

namespace JobsManagementApp.ViewModel.ShareModel
{

    public class JobDetailViewModel : BaseViewModel
    {
        #region Binding Varirables

        private JobsDTO _CurrentJob;
        public JobsDTO CurrentJob
        {
            get { return _CurrentJob; }
            set { _CurrentJob = value; OnPropertyChanged(); }
        }
        private JobsDTO _TreeJob;
        public JobsDTO TreeJob
        {
            get { return _TreeJob; }
            set { _TreeJob = value; OnPropertyChanged(); }
        }
        private JobsDTO _BackupJob;
        public JobsDTO BackupJob
        {
            get { return _BackupJob; }
            set { _BackupJob = value; OnPropertyChanged(); }
        }
        private string _jobAssignor;
        public string jobAssignor
        {
            get { return _jobAssignor; }
            set { _jobAssignor = value; OnPropertyChanged(); }
        }
        private DateTime _jobStartDate;
        public DateTime jobStartDate
        {
            get { return _jobStartDate; }
            set { _jobStartDate = value; OnPropertyChanged(); }
        }
        public DateTime PastStartDate;
        private DateTime _jobDueDate;
        public DateTime jobDueDate
        {
            get { return _jobDueDate; }
            set { _jobDueDate = value; OnPropertyChanged(); }
        }
        public DateTime PastDueDate;
        private DateTime? _jobEndDate;
        public DateTime? jobEndDate
        {
            get { return _jobEndDate; }
            set { _jobEndDate = value; OnPropertyChanged(); }
        }
        public DateTime? PastEndDate;
        private string _jobRequire_hour;
        public string jobRequire_hour
        {
            get { return _jobRequire_hour; }
            set { _jobRequire_hour = value; OnPropertyChanged(); }
        }
        private string _jobWorked_hour;
        public string jobWorked_hour
        {
            get { return _jobWorked_hour; }
            set { _jobWorked_hour = value; OnPropertyChanged(); }
        }
        private int _jobId;
        public int jobId
        {
            get { return _jobId; }
            set { _jobId = value; OnPropertyChanged(); }
        }
        private string _jobDescription;
        public string jobDescription
        {
            get { return _jobDescription; }
            set { _jobDescription = value; OnPropertyChanged(); }
        }
        private bool _IsChangable;
        public bool IsChangable
        {
            get { return _IsChangable; }
            set { _IsChangable = value; OnPropertyChanged(); }
        }
        private Visibility _IsVisible;
        public Visibility IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; OnPropertyChanged(); }
        }
        private bool _IsChangable2;
        public bool IsChangable2
        {
            get { return _IsChangable2; }
            set { _IsChangable2 = value; OnPropertyChanged(); }
        }
        private Visibility _IsVisible2;
        public Visibility IsVisible2
        {
            get { return _IsVisible2; }
            set { _IsVisible2 = value; OnPropertyChanged(); }
        }



        private ObservableCollection<Assignee_AssignorDTO> _AssigneeSource;
        public ObservableCollection<Assignee_AssignorDTO> AssigneeSource
        {
            get { return _AssigneeSource; }
            set { _AssigneeSource = value; OnPropertyChanged(); }
        }
        private Assignee_AssignorDTO _jobAssignee;
        public Assignee_AssignorDTO jobAssignee
        {
            get { return _jobAssignee; }
            set { _jobAssignee = value; OnPropertyChanged(); }
        }
        private string _jobName;
        public string jobName
        {
            get { return _jobName; }
            set { _jobName = value; OnPropertyChanged(); }
        }
        private string _jobStage;
        public string jobStage
        {
            get { return _jobStage; }
            set { _jobStage = value; OnPropertyChanged(); }
        }
        private int _jobPercent;
        public int jobPercent
        {
            get { return _jobPercent; }
            set { _jobPercent = value; OnPropertyChanged(); }
        }
        private ObservableCollection<JobsDTO> _DependencySource;
        public ObservableCollection<JobsDTO> DependencySource
        {
            get { return _DependencySource; }
            set { _DependencySource = value; OnPropertyChanged(); }
        }
        private JobsDTO _jobDependency;
        public JobsDTO jobDependency
        {
            get { return _jobDependency; }
            set { _jobDependency = value; OnPropertyChanged(); }
        }
        private ObservableCollection<CategoriesDTO> _CategorySource;
        public ObservableCollection<CategoriesDTO> CategorySource
        {
            get { return _CategorySource; }
            set { _CategorySource = value; OnPropertyChanged(); }
        }
        private CategoriesDTO _jobCategory;
        public CategoriesDTO jobCategory
        {
            get { return _jobCategory; }
            set { _jobCategory = value; OnPropertyChanged(); }
        }
        private DateTime _Current;
        public DateTime Current
        {
            get { return _Current; }
            set { _Current = value; OnPropertyChanged(); }
        }

        #endregion

        #region Internal Varirables
        public Admin admin { get; set; }
        public UsersDTO user { get; set; }
        public JobsDTO updateJob { get; set; }
        private TreeView _treeview;
        public TreeView treeview
        {
            get { return _treeview; }
            set { _treeview = value; OnPropertyChanged(); }
        }


        #endregion

        #region Command
        public ICommand LoadCM { get; set; }
        public ICommand ChangeJobCM { get; set; }
        public ICommand UpdateJobCM { get; set; }
        public ICommand MoveToReportListCM { get; set; }
        public ICommand GoBackCM { get; set; }
        public ICommand AssgineeChangeCM { get; set; }
        public ICommand SetEndDateNullCM { get; set; }
        public ICommand StartChangeCM { get; set; }
        public ICommand DueChangeCM { get; set; }
        public ICommand EndChangeCM { get; set; }
        public ICommand PercentChangeCM { get; set; }
        public ICommand CheckRequireHourEmptyCM { get; set; }
        public ICommand CheckWorkedHourEmptyCM { get; set; }
        public ICommand MoveToReportDetailCM { get; set; }



        #endregion




        public JobDetailViewModel(Admin a, JobsDTO chosenJob)
        {
            DateTime current_t = DateTime.Now;
            Current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            admin = a;
            IsChangable = true;
            IsVisible = Visibility.Collapsed;
            IsChangable2 = true;
            IsVisible2 = Visibility.Collapsed;
            CurrentJob = new JobsDTO();
            BackupJob = null;

            //DEFINE COMMAND
            GoBackCM = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                p.NavigationService.GoBack();
            });
            MoveToReportDetailCM = new RelayCommand<Page>((p) => { return BackupJob != null; }, (p) =>
            {
                ReportDetailViewModel vm = new ReportDetailViewModel(admin, BackupJob);
                ReportDetailPage dashboardpage = new ReportDetailPage();
                dashboardpage.DataContext = vm;
                p.NavigationService.Navigate(dashboardpage);
            });
            LoadCM = new RelayCommand<TreeView>((p) => { return true; }, async (p) =>
            {
                if(BackupJob != null)
                    CurrentJob = new JobsDTO(BackupJob);
                else
                    CurrentJob = JobService.Ins.GetJob((int)chosenJob.id);
                if (CurrentJob == null)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Chosen job is not exist!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    if (BackupJob == null)
                        BackupJob = chosenJob;
                    //GET ROOT ID OF CHOSEN JOB
                    int rootJobID = JobService.Ins.GetRootJobId((int)CurrentJob.id);
                    //BUILD TREE FROM ROOT ID
                    if(TreeJob != null)
                        treeview.Items.Remove(TreeJob);
                    TreeJob = JobService.Ins.GetJobForTreeBinding(rootJobID, (int)CurrentJob.id);
                    treeview = p;
                    treeview.Items.Add(TreeJob);
                    //SET INITIAL VALUE
                    jobId = (int)CurrentJob.id;
                    jobName = CurrentJob.name;
                    jobAssignor = CurrentJob.assignor_id + "-" + CurrentJob.assignor_type + "-" + CurrentJob.assignor_name;
                    jobDescription = CurrentJob.description;

                    jobStartDate = DateTime.ParseExact(CurrentJob.start_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);
                    jobDueDate = DateTime.ParseExact(CurrentJob.due_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);
                    if (CurrentJob.end_date == "NONE")
                        jobEndDate = null;
                    else
                        jobEndDate = DateTime.ParseExact(CurrentJob.end_date, "dd-MM-yyyy",
                            System.Globalization.CultureInfo.InvariantCulture);
                    PastStartDate = jobStartDate;
                    PastDueDate = jobDueDate;
                    PastEndDate = jobEndDate;
                    jobStage = CurrentJob.stage;
                    jobPercent = (int)CurrentJob.percent;
                    jobRequire_hour = CurrentJob.required_hour.ToString();
                    jobWorked_hour = CurrentJob.worked_hour.ToString();
                    try
                    {
                        AssigneeSource = new ObservableCollection<Assignee_AssignorDTO>(await JobService.Ins.GetAssignee());
                        AssigneeSource.Insert(0, new Assignee_AssignorDTO(-1, "NONE", "NONE"));
                        DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
                        DependencySource.Insert(0, new JobsDTO(-1, "NONE"));
                        CategorySource = new ObservableCollection<CategoriesDTO>(await CategoryService.Ins.GetAllCategory());
                        for (int i = 0; i < AssigneeSource.Count; i++)
                        {
                            if (AssigneeSource[i].id == CurrentJob.assignee_id && AssigneeSource[i].type == CurrentJob.assignee_type)
                            {
                                jobAssignee = AssigneeSource[i];
                                i = AssigneeSource.Count;
                            }
                        }
                        for (int i = 0; i < DependencySource.Count; i++)
                        {
                            if (DependencySource[i].id == jobId)
                            {
                                DependencySource.RemoveAt(i);
                                i = DependencySource.Count;
                            }
                        }
                        for (int i = 0; i < DependencySource.Count; i++)
                        {
                            if (DependencySource[i].id == CurrentJob.dependency_id)
                            {
                                jobDependency = DependencySource[i];
                                i = DependencySource.Count;
                            }
                        }
                        for (int i = 0; i < CategorySource.Count; i++)
                        {
                            if (CategorySource[i].name == CurrentJob.category)
                            {
                                jobCategory = CategorySource[i];
                                i = CategorySource.Count;
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

            });
            UpdateJobCM = new RelayCommand<TreeView>((p) => { return true; }, async (p) =>
            {
                updateJob = new JobsDTO();
                if (string.IsNullOrEmpty(jobName))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Job name cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    updateJob = new JobsDTO();
                }
                else
                {
                    updateJob.name = jobName;
                    if (string.IsNullOrEmpty(jobDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Job description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        updateJob = new JobsDTO();
                    }
                    else
                    {
                        updateJob.description = jobDescription;
                        if (string.IsNullOrEmpty(jobRequire_hour))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Job require hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            updateJob = new JobsDTO();
                        }
                        else
                        {
                            updateJob.required_hour = Int32.Parse(jobRequire_hour);
                            if (string.IsNullOrEmpty(jobWorked_hour))
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Job worked hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                updateJob = new JobsDTO();
                            }
                            else
                            {
                                updateJob.worked_hour = Int32.Parse(jobWorked_hour);
                                if (jobEndDate == null)
                                {
                                    updateJob.end_date = "NONE";
                                }
                                else
                                {
                                    DateTime temp = (DateTime)jobEndDate;
                                    updateJob.end_date = temp.ToString("dd-MM-yyyy");
                                }
                                updateJob.id = CurrentJob.id;
                                updateJob.assignor_id = CurrentJob.assignor_id;
                                updateJob.assignor_type = CurrentJob.assignor_type;
                                updateJob.assignor_name = CurrentJob.assignor_name;
                                updateJob.assignee_id = jobAssignee.id;
                                updateJob.assignee_type = jobAssignee.type;
                                updateJob.assignee_name = jobAssignee.name;
                                updateJob.dependency_id = jobDependency.id;
                                updateJob.dependency_name = jobDependency.name;
                                updateJob.stage = jobStage;
                                updateJob.start_date = jobStartDate.ToString("dd-MM-yyyy");
                                updateJob.due_date = jobDueDate.ToString("dd-MM-yyyy");
                                updateJob.category = jobCategory.name;
                                updateJob.percent = jobPercent;
                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you really want to update this job?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    if ((jobAssignee.type != BackupJob.assignee_type) || (jobAssignee.type == BackupJob.assignee_type && jobAssignee.id != BackupJob.assignee_id))
                                    {
                                        MessageBoxCustom result2 = new MessageBoxCustom("Warning", "You changed assignee, this update will delete all related report, you still want to update this job?", MessageType.Warning, MessageButtons.YesNo);
                                        result2.ShowDialog();
                                        if (result2.DialogResult == true)
                                        {
                                            try
                                            {
                                                (bool isSuccess, string messageFromUpdate) = await JobService.Ins.UpdateJob(updateJob);
                                                if (isSuccess)
                                                {
                                                    MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                                    mb.ShowDialog();
                                                    CurrentJob.id = updateJob.id;
                                                    CurrentJob.name = updateJob.name;
                                                    CurrentJob.end_date = updateJob.end_date;
                                                    CurrentJob.start_date = updateJob.start_date;
                                                    CurrentJob.due_date = updateJob.due_date;
                                                    CurrentJob.category = updateJob.category;
                                                    CurrentJob.description = updateJob.description;
                                                    CurrentJob.percent = updateJob.percent;
                                                    CurrentJob.stage = updateJob.stage;
                                                    CurrentJob.dependency_id = updateJob.dependency_id;
                                                    CurrentJob.dependency_name = updateJob.dependency_name;
                                                    CurrentJob.assignee_id = updateJob.assignee_id;
                                                    CurrentJob.assignee_type = updateJob.assignee_type;
                                                    CurrentJob.assignee_name = updateJob.assignee_name;
                                                    CurrentJob.assignor_id = updateJob.assignor_id;
                                                    CurrentJob.assignor_type = updateJob.assignor_type;
                                                    CurrentJob.assignor_name = updateJob.assignor_name;
                                                    CurrentJob.required_hour = updateJob.required_hour;
                                                    CurrentJob.worked_hour = updateJob.worked_hour;

                                                    BackupJob.id = updateJob.id;
                                                    BackupJob.name = updateJob.name;
                                                    BackupJob.end_date = updateJob.end_date;
                                                    BackupJob.start_date = updateJob.start_date;
                                                    BackupJob.due_date = updateJob.due_date;
                                                    BackupJob.category = updateJob.category;
                                                    BackupJob.description = updateJob.description;
                                                    BackupJob.percent = updateJob.percent;
                                                    BackupJob.stage = updateJob.stage;
                                                    BackupJob.dependency_id = updateJob.dependency_id;
                                                    BackupJob.dependency_name = updateJob.dependency_name;
                                                    BackupJob.assignee_id = updateJob.assignee_id;
                                                    BackupJob.assignee_type = updateJob.assignee_type;
                                                    BackupJob.assignee_name = updateJob.assignee_name;
                                                    BackupJob.assignor_id = updateJob.assignor_id;
                                                    BackupJob.assignor_type = updateJob.assignor_type;
                                                    BackupJob.assignor_name = updateJob.assignor_name;
                                                    BackupJob.required_hour = updateJob.required_hour;
                                                    BackupJob.worked_hour = updateJob.worked_hour;

                                                    chosenJob.id = updateJob.id;
                                                    chosenJob.name = updateJob.name;
                                                    chosenJob.end_date = updateJob.end_date;
                                                    chosenJob.start_date = updateJob.start_date;
                                                    chosenJob.due_date = updateJob.due_date;
                                                    chosenJob.category = updateJob.category;
                                                    chosenJob.description = updateJob.description;
                                                    chosenJob.percent = updateJob.percent;
                                                    chosenJob.stage = jobStage;
                                                    chosenJob.dependency_id = updateJob.dependency_id;
                                                    chosenJob.dependency_name = updateJob.dependency_name;
                                                    chosenJob.assignee_id = updateJob.assignee_id;
                                                    chosenJob.assignee_type = updateJob.assignee_type;
                                                    chosenJob.assignee_name = updateJob.assignee_name;
                                                    chosenJob.assignor_id = updateJob.assignor_id;
                                                    chosenJob.assignor_type = updateJob.assignor_type;
                                                    chosenJob.assignor_name = updateJob.assignor_name;
                                                    chosenJob.required_hour = updateJob.required_hour;
                                                    chosenJob.worked_hour = updateJob.worked_hour;

                                                    //GET ROOT ID OF CHOSEN JOB
                                                    int rootJobID = JobService.Ins.GetRootJobId((int)CurrentJob.id);
                                                    //BUILD TREE FROM ROOT ID
                                                    treeview.Items.Remove(TreeJob);
                                                    TreeJob = JobService.Ins.GetJobForTreeBinding(rootJobID, (int)CurrentJob.id);
                                                    treeview.Items.Add(TreeJob);
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
                                        else
                                        {
                                            updateJob = new JobsDTO();
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            (bool isSuccess, string messageFromUpdate) = await JobService.Ins.UpdateJob(updateJob);
                                            if (isSuccess)
                                            {
                                                MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                                mb.ShowDialog();
                                                CurrentJob.id = updateJob.id;
                                                CurrentJob.name = updateJob.name;
                                                CurrentJob.end_date = updateJob.end_date;
                                                CurrentJob.start_date = updateJob.start_date;
                                                CurrentJob.due_date = updateJob.due_date;
                                                CurrentJob.category = updateJob.category;
                                                CurrentJob.description = updateJob.description;
                                                CurrentJob.percent = updateJob.percent;
                                                CurrentJob.stage = updateJob.stage;
                                                CurrentJob.dependency_id = updateJob.dependency_id;
                                                CurrentJob.dependency_name = updateJob.dependency_name;
                                                CurrentJob.assignee_id = updateJob.assignee_id;
                                                CurrentJob.assignee_type = updateJob.assignee_type;
                                                CurrentJob.assignee_name = updateJob.assignee_name;
                                                CurrentJob.assignor_id = updateJob.assignor_id;
                                                CurrentJob.assignor_type = updateJob.assignor_type;
                                                CurrentJob.assignor_name = updateJob.assignor_name;
                                                CurrentJob.required_hour = updateJob.required_hour;
                                                CurrentJob.worked_hour = updateJob.worked_hour;

                                                BackupJob.id = updateJob.id;
                                                BackupJob.name = updateJob.name;
                                                BackupJob.end_date = updateJob.end_date;
                                                BackupJob.start_date = updateJob.start_date;
                                                BackupJob.due_date = updateJob.due_date;
                                                BackupJob.category = updateJob.category;
                                                BackupJob.description = updateJob.description;
                                                BackupJob.percent = updateJob.percent;
                                                BackupJob.stage = updateJob.stage;
                                                BackupJob.dependency_id = updateJob.dependency_id;
                                                BackupJob.dependency_name = updateJob.dependency_name;
                                                BackupJob.assignee_id = updateJob.assignee_id;
                                                BackupJob.assignee_type = updateJob.assignee_type;
                                                BackupJob.assignee_name = updateJob.assignee_name;
                                                BackupJob.assignor_id = updateJob.assignor_id;
                                                BackupJob.assignor_type = updateJob.assignor_type;
                                                BackupJob.assignor_name = updateJob.assignor_name;
                                                BackupJob.required_hour = updateJob.required_hour;
                                                BackupJob.worked_hour = updateJob.worked_hour;

                                                chosenJob.id = updateJob.id;
                                                chosenJob.name = updateJob.name;
                                                chosenJob.end_date = updateJob.end_date;
                                                chosenJob.start_date = updateJob.start_date;
                                                chosenJob.due_date = updateJob.due_date;
                                                chosenJob.category = updateJob.category;
                                                chosenJob.description = updateJob.description;
                                                chosenJob.percent = updateJob.percent;
                                                chosenJob.stage = updateJob.stage;
                                                chosenJob.dependency_id = updateJob.dependency_id;
                                                chosenJob.dependency_name = updateJob.dependency_name;
                                                chosenJob.assignee_id = updateJob.assignee_id;
                                                chosenJob.assignee_type = updateJob.assignee_type;
                                                chosenJob.assignee_name = updateJob.assignee_name;
                                                chosenJob.assignor_id = updateJob.assignor_id;
                                                chosenJob.assignor_type = updateJob.assignor_type;
                                                chosenJob.assignor_name = updateJob.assignor_name;
                                                chosenJob.required_hour = updateJob.required_hour;
                                                chosenJob.worked_hour = updateJob.worked_hour;

                                                //GET ROOT ID OF CHOSEN JOB
                                                int rootJobID = JobService.Ins.GetRootJobId((int)CurrentJob.id);
                                                //BUILD TREE FROM ROOT ID
                                                treeview.Items.Remove(TreeJob);
                                                TreeJob = JobService.Ins.GetJobForTreeBinding(rootJobID, (int)CurrentJob.id);
                                                treeview.Items.Add(TreeJob);

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


            });
            SetEndDateNullCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                jobEndDate = null;
            });
            AssgineeChangeCM = new RelayCommand<object>((p) => { return BackupJob != null && jobAssignee !=null; }, (p) =>
            {
                if ((jobAssignee.type != BackupJob.assignee_type) || (jobAssignee.type == BackupJob.assignee_type && jobAssignee.id != BackupJob.assignee_id))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Warning", "You are choosing differ assignee, this will delete related reports from the past assignee!", MessageType.Warning, MessageButtons.OK);
                    mb.ShowDialog();
                    MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you still want to change it?!", MessageType.Warning, MessageButtons.YesNo);
                    result.ShowDialog();

                    if (result.DialogResult == false)
                    {

                        for (int i = 0; i < AssigneeSource.Count; i++)
                        {
                            if (AssigneeSource[i].id == BackupJob.assignee_id && AssigneeSource[i].type == BackupJob.assignee_type)
                            {
                                jobAssignee = AssigneeSource[i];
                                i = AssigneeSource.Count;
                            }
                        }
                    }

                }
                if (jobEndDate == null)
                {
                    if (jobPercent == 100)
                    {
                        jobPercent = 40;
                    }
                }
                if (jobEndDate != null)
                {
                    jobPercent = 100;
                    if (jobWorked_hour == "0" || string.IsNullOrEmpty(jobWorked_hour))
                        jobWorked_hour = ((Int32.Parse(jobRequire_hour) * 10) / 100).ToString();
                }
            });
            StartChangeCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (DateTime.Compare((DateTime)jobStartDate, (DateTime)jobDueDate) > 0)
                {
                    TimeSpan result = jobDueDate.Subtract(PastStartDate);
                    jobDueDate = jobStartDate.Add(result);

                }
                if (jobEndDate != null)
                {
                    if (DateTime.Compare((DateTime)jobStartDate, (DateTime)jobEndDate) > 0)
                    {
                        TimeSpan result = jobEndDate.Value.Subtract(PastStartDate);
                        jobEndDate = jobStartDate.Add(result);
                    }
                }
                PastStartDate = jobStartDate;
                setStage();
            });
            DueChangeCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (DateTime.Compare((DateTime)jobStartDate, (DateTime)jobDueDate) > 0)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Warning", "Job due date must be greater or equal to start date!", MessageType.Warning, MessageButtons.OK);
                    mb.ShowDialog();
                    jobDueDate = PastDueDate;

                }
                PastDueDate = jobDueDate;
                setStage();
            });
            EndChangeCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (jobEndDate != null)
                {
                    if (DateTime.Compare((DateTime)jobStartDate, (DateTime)jobEndDate.Value) > 0)
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Warning", "Job end date must be greater or equal to start date!", MessageType.Warning, MessageButtons.OK);
                        mb.ShowDialog();
                        jobEndDate = PastEndDate;

                    }
                }
                PastEndDate = jobEndDate;
                setStage();
            });
            ChangeJobCM = new RelayCommand<TreeView>((p) => { return p.SelectedItem != null; }, async (p) =>
            {

                //SET INITIAL VALUE
                CurrentJob = JobService.Ins.GetJob((int)((JobsDTO)p.SelectedItem).id);
                if (CurrentJob == null)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Chosen job is not exist!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    BackupJob = (JobsDTO)p.SelectedItem;
                    //SET INITIAL VALUE
                    jobId = (int)CurrentJob.id;
                    jobName = CurrentJob.name;
                    jobAssignor = CurrentJob.assignor_id + "-" + CurrentJob.assignor_type + "-" + CurrentJob.assignor_name;
                    jobDescription = CurrentJob.description;

                    jobStartDate = DateTime.ParseExact(CurrentJob.start_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);
                    jobDueDate = DateTime.ParseExact(CurrentJob.due_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);
                    if (CurrentJob.end_date == "NONE")
                        jobEndDate = null;
                    else
                        jobEndDate = DateTime.ParseExact(CurrentJob.end_date, "dd-MM-yyyy",
                            System.Globalization.CultureInfo.InvariantCulture);
                    PastStartDate = jobStartDate;
                    PastDueDate = jobDueDate;
                    PastEndDate = jobEndDate;
                    jobStage = CurrentJob.stage;
                    jobPercent = (int)CurrentJob.percent;
                    jobRequire_hour = CurrentJob.required_hour.ToString();
                    jobWorked_hour = CurrentJob.worked_hour.ToString();
                    for (int i = 0; i < AssigneeSource.Count; i++)
                    {
                        if (AssigneeSource[i].id == CurrentJob.assignee_id && AssigneeSource[i].type == CurrentJob.assignee_type)
                        {
                            jobAssignee = AssigneeSource[i];
                            i = AssigneeSource.Count;
                        }
                    }
                    DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
                    DependencySource.Insert(0, new JobsDTO(-1, "NONE"));
                    for (int i = 0; i < DependencySource.Count; i++)
                    {
                        if (DependencySource[i].id == CurrentJob.id)
                        {
                            DependencySource.RemoveAt(i);
                            i = DependencySource.Count;
                        }
                    }
                    for (int i = 0; i < DependencySource.Count; i++)
                    {
                        if (DependencySource[i].id == CurrentJob.dependency_id)
                        {
                            jobDependency = DependencySource[i];
                            i = DependencySource.Count;
                        }
                    }
                    for (int i = 0; i < CategorySource.Count; i++)
                    {
                        if (CategorySource[i].name == CurrentJob.category)
                        {
                            jobCategory = CategorySource[i];
                            i = CategorySource.Count;
                        }
                    }
                }

            });
            PercentChangeCM = new RelayCommand<Slider>((p) => { return true; }, (p) =>
            {
                int a = (int)p.Value;
                if (a == 100)
                {
                    if (jobEndDate == null)
                    {
                        if (PastEndDate != null)
                            jobEndDate = PastEndDate;
                        else
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Infor", "Job setted to complete, system will choose random end date!", MessageType.Info, MessageButtons.OK);
                            mb.ShowDialog();
                            MessageBoxCustom mb2 = new MessageBoxCustom("Infor", "Please change end date to your desired date!", MessageType.Info, MessageButtons.OK);
                            mb2.ShowDialog();
                            var randomTest = new Random();

                            TimeSpan timeSpan = jobDueDate - jobStartDate;
                            TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
                            jobEndDate = jobStartDate + newSpan;
                        }

                    }
                }
                else
                {
                    if (jobEndDate != null)
                        jobEndDate = null;
                }

            });
            CheckRequireHourEmptyCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(jobRequire_hour) || jobRequire_hour == "0")
                {
                    jobRequire_hour = BackupJob.required_hour.ToString();
                }

            });
            CheckWorkedHourEmptyCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(jobWorked_hour) || jobWorked_hour == "0")
                {
                    if (jobStage == "WAITING")
                    {
                        jobWorked_hour = "0";
                    }
                    else
                    {
                        if (jobPercent != 0)
                            jobWorked_hour = ((Int32.Parse(jobRequire_hour) * 30) / 100).ToString();
                    }
                }

            });
        }

        public JobDetailViewModel(UsersDTO a, JobsDTO chosenJob)
        {
            DateTime current_t = DateTime.Now;
            Current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            user = a;
            IsChangable = true;
            IsVisible = Visibility.Collapsed;
            IsChangable2 = true;
            IsVisible2 = Visibility.Collapsed;
            CurrentJob = new JobsDTO();
            BackupJob = null;

            //DEFINE COMMAND
            GoBackCM = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                p.NavigationService.GoBack();
            });
            MoveToReportDetailCM = new RelayCommand<Page>((p) => { return BackupJob != null; }, (p) =>
            {
                ReportDetailViewModel vm = new ReportDetailViewModel(user, BackupJob);
                ReportDetailPage dashboardpage = new ReportDetailPage();
                dashboardpage.DataContext = vm;
                p.NavigationService.Navigate(dashboardpage);
            });
            LoadCM = new RelayCommand<TreeView>((p) => { return true; }, async (p) =>
            {
                if (BackupJob != null)
                    CurrentJob = new JobsDTO(BackupJob);
                else
                    CurrentJob = JobService.Ins.GetJob((int)chosenJob.id);
                if (CurrentJob == null)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Chosen job is not exist!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    IsChangable = false;
                    IsVisible = Visibility.Collapsed;
                    IsChangable2 = false;
                    IsVisible2 = Visibility.Visible;

                    if (CurrentJob.assignee_type == "USER" && CurrentJob.assignee_id == user.id)
                    {
                        IsChangable = false;
                        IsVisible = Visibility.Visible;
                        IsChangable2 = true;
                        IsVisible2 = Visibility.Collapsed;
                    }
                    if (CurrentJob.assignor_type == "USER" && CurrentJob.assignor_id == user.id)
                    {
                        IsChangable = true;
                        IsVisible = Visibility.Collapsed;
                        IsChangable2 = true;
                        IsVisible2 = Visibility.Collapsed;
                    }
                    if (BackupJob == null)
                        BackupJob = chosenJob;
                    //GET ROOT ID OF CHOSEN JOB
                    int rootJobID = JobService.Ins.GetRootJobId((int)CurrentJob.id);
                    //BUILD TREE FROM ROOT ID
                    if (TreeJob != null)
                        treeview.Items.Remove(TreeJob);
                    TreeJob = JobService.Ins.GetJobForTreeBinding(rootJobID, (int)CurrentJob.id);
                    treeview = p;
                    treeview.Items.Add(TreeJob);
                    //SET INITIAL VALUE
                    jobId = (int)CurrentJob.id;
                    jobName = CurrentJob.name;
                    jobAssignor = CurrentJob.assignor_id + "-" + CurrentJob.assignor_type + "-" + CurrentJob.assignor_name;
                    jobDescription = CurrentJob.description;

                    jobStartDate = DateTime.ParseExact(CurrentJob.start_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);
                    jobDueDate = DateTime.ParseExact(CurrentJob.due_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);
                    if (CurrentJob.end_date == "NONE")
                        jobEndDate = null;
                    else
                        jobEndDate = DateTime.ParseExact(CurrentJob.end_date, "dd-MM-yyyy",
                            System.Globalization.CultureInfo.InvariantCulture);
                    PastStartDate = jobStartDate;
                    PastDueDate = jobDueDate;
                    PastEndDate = jobEndDate;
                    jobStage = CurrentJob.stage;
                    jobPercent = (int)CurrentJob.percent;
                    jobRequire_hour = CurrentJob.required_hour.ToString();
                    jobWorked_hour = CurrentJob.worked_hour.ToString();
                    try
                    {
                        AssigneeSource = new ObservableCollection<Assignee_AssignorDTO>(await JobService.Ins.GetAssignee());
                        AssigneeSource.Insert(0, new Assignee_AssignorDTO(-1, "NONE", "NONE"));
                        DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
                        DependencySource.Insert(0, new JobsDTO(-1, "NONE"));
                        CategorySource = new ObservableCollection<CategoriesDTO>(await CategoryService.Ins.GetAllCategory());
                        for (int i = 0; i < AssigneeSource.Count; i++)
                        {
                            if (AssigneeSource[i].id == CurrentJob.assignee_id && AssigneeSource[i].type == CurrentJob.assignee_type)
                            {
                                jobAssignee = AssigneeSource[i];
                                i = AssigneeSource.Count;
                            }
                        }
                        for (int i = 0; i < DependencySource.Count; i++)
                        {
                            if (DependencySource[i].id == jobId)
                            {
                                DependencySource.RemoveAt(i);
                                i = DependencySource.Count;
                            }
                        }
                        for (int i = 0; i < DependencySource.Count; i++)
                        {
                            if (DependencySource[i].id == CurrentJob.dependency_id)
                            {
                                jobDependency = DependencySource[i];
                                i = DependencySource.Count;
                            }
                        }
                        for (int i = 0; i < CategorySource.Count; i++)
                        {
                            if (CategorySource[i].name == CurrentJob.category)
                            {
                                jobCategory = CategorySource[i];
                                i = CategorySource.Count;
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

            });
            UpdateJobCM = new RelayCommand<TreeView>((p) => { return true; }, async (p) =>
            {
                if (IsChangable || IsChangable2)
                {
                    updateJob = new JobsDTO();
                    if (string.IsNullOrEmpty(jobName))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Job name cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        updateJob = new JobsDTO();
                    }
                    else
                    {
                        updateJob.name = jobName;
                        if (string.IsNullOrEmpty(jobDescription))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Job description cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            updateJob = new JobsDTO();
                        }
                        else
                        {
                            updateJob.description = jobDescription;
                            if (string.IsNullOrEmpty(jobRequire_hour))
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Job require hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                updateJob = new JobsDTO();
                            }
                            else
                            {
                                updateJob.required_hour = Int32.Parse(jobRequire_hour);
                                if (string.IsNullOrEmpty(jobWorked_hour))
                                {
                                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Job worked hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                                    mb.ShowDialog();
                                    updateJob = new JobsDTO();
                                }
                                else
                                {
                                    updateJob.worked_hour = Int32.Parse(jobWorked_hour);
                                    if (jobEndDate == null)
                                    {
                                        updateJob.end_date = "NONE";
                                    }
                                    else
                                    {
                                        DateTime temp = (DateTime)jobEndDate;
                                        updateJob.end_date = temp.ToString("dd-MM-yyyy");
                                    }
                                    updateJob.id = CurrentJob.id;
                                    updateJob.assignor_id = CurrentJob.assignor_id;
                                    updateJob.assignor_type = CurrentJob.assignor_type;
                                    updateJob.assignor_name = CurrentJob.assignor_name;
                                    updateJob.assignee_id = jobAssignee.id;
                                    updateJob.assignee_type = jobAssignee.type;
                                    updateJob.assignee_name = jobAssignee.name;
                                    updateJob.dependency_id = jobDependency.id;
                                    updateJob.dependency_name = jobDependency.name;
                                    updateJob.stage = jobStage;
                                    updateJob.start_date = jobStartDate.ToString("dd-MM-yyyy");
                                    updateJob.due_date = jobDueDate.ToString("dd-MM-yyyy");
                                    updateJob.category = jobCategory.name;
                                    updateJob.percent = jobPercent;
                                    MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you really want to update this job?", MessageType.Warning, MessageButtons.YesNo);
                                    result.ShowDialog();

                                    if (result.DialogResult == true)
                                    {
                                        if ((jobAssignee.type != BackupJob.assignee_type) || (jobAssignee.type == BackupJob.assignee_type && jobAssignee.id != BackupJob.assignee_id))
                                        {
                                            MessageBoxCustom result2 = new MessageBoxCustom("Warning", "You changed assignee, this update will delete all related report, you still want to update this job?", MessageType.Warning, MessageButtons.YesNo);
                                            result2.ShowDialog();
                                            if (result2.DialogResult == true)
                                            {
                                                try
                                                {
                                                    (bool isSuccess, string messageFromUpdate) = await JobService.Ins.UpdateJob(updateJob);
                                                    if (isSuccess)
                                                    {
                                                        MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                                        mb.ShowDialog();
                                                        CurrentJob.id = updateJob.id;
                                                        CurrentJob.name = updateJob.name;
                                                        CurrentJob.end_date = updateJob.end_date;
                                                        CurrentJob.start_date = updateJob.start_date;
                                                        CurrentJob.due_date = updateJob.due_date;
                                                        CurrentJob.category = updateJob.category;
                                                        CurrentJob.description = updateJob.description;
                                                        CurrentJob.percent = updateJob.percent;
                                                        CurrentJob.stage = updateJob.stage;
                                                        CurrentJob.dependency_id = updateJob.dependency_id;
                                                        CurrentJob.dependency_name = updateJob.dependency_name;
                                                        CurrentJob.assignee_id = updateJob.assignee_id;
                                                        CurrentJob.assignee_type = updateJob.assignee_type;
                                                        CurrentJob.assignee_name = updateJob.assignee_name;
                                                        CurrentJob.assignor_id = updateJob.assignor_id;
                                                        CurrentJob.assignor_type = updateJob.assignor_type;
                                                        CurrentJob.assignor_name = updateJob.assignor_name;
                                                        CurrentJob.required_hour = updateJob.required_hour;
                                                        CurrentJob.worked_hour = updateJob.worked_hour;

                                                        BackupJob.id = updateJob.id;
                                                        BackupJob.name = updateJob.name;
                                                        BackupJob.end_date = updateJob.end_date;
                                                        BackupJob.start_date = updateJob.start_date;
                                                        BackupJob.due_date = updateJob.due_date;
                                                        BackupJob.category = updateJob.category;
                                                        BackupJob.description = updateJob.description;
                                                        BackupJob.percent = updateJob.percent;
                                                        BackupJob.stage = updateJob.stage;
                                                        BackupJob.dependency_id = updateJob.dependency_id;
                                                        BackupJob.dependency_name = updateJob.dependency_name;
                                                        BackupJob.assignee_id = updateJob.assignee_id;
                                                        BackupJob.assignee_type = updateJob.assignee_type;
                                                        BackupJob.assignee_name = updateJob.assignee_name;
                                                        BackupJob.assignor_id = updateJob.assignor_id;
                                                        BackupJob.assignor_type = updateJob.assignor_type;
                                                        BackupJob.assignor_name = updateJob.assignor_name;
                                                        BackupJob.required_hour = updateJob.required_hour;
                                                        BackupJob.worked_hour = updateJob.worked_hour;

                                                        chosenJob.id = updateJob.id;
                                                        chosenJob.name = updateJob.name;
                                                        chosenJob.end_date = updateJob.end_date;
                                                        chosenJob.start_date = updateJob.start_date;
                                                        chosenJob.due_date = updateJob.due_date;
                                                        chosenJob.category = updateJob.category;
                                                        chosenJob.description = updateJob.description;
                                                        chosenJob.percent = updateJob.percent;
                                                        chosenJob.stage = jobStage;
                                                        chosenJob.dependency_id = updateJob.dependency_id;
                                                        chosenJob.dependency_name = updateJob.dependency_name;
                                                        chosenJob.assignee_id = updateJob.assignee_id;
                                                        chosenJob.assignee_type = updateJob.assignee_type;
                                                        chosenJob.assignee_name = updateJob.assignee_name;
                                                        chosenJob.assignor_id = updateJob.assignor_id;
                                                        chosenJob.assignor_type = updateJob.assignor_type;
                                                        chosenJob.assignor_name = updateJob.assignor_name;
                                                        chosenJob.required_hour = updateJob.required_hour;
                                                        chosenJob.worked_hour = updateJob.worked_hour;

                                                        //GET ROOT ID OF CHOSEN JOB
                                                        int rootJobID = JobService.Ins.GetRootJobId((int)CurrentJob.id);
                                                        //BUILD TREE FROM ROOT ID
                                                        treeview.Items.Remove(TreeJob);
                                                        TreeJob = JobService.Ins.GetJobForTreeBinding(rootJobID, (int)CurrentJob.id);
                                                        treeview.Items.Add(TreeJob);
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
                                            else
                                            {
                                                updateJob = new JobsDTO();
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                (bool isSuccess, string messageFromUpdate) = await JobService.Ins.UpdateJob(updateJob);
                                                if (isSuccess)
                                                {
                                                    MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                                    mb.ShowDialog();
                                                    CurrentJob.id = updateJob.id;
                                                    CurrentJob.name = updateJob.name;
                                                    CurrentJob.end_date = updateJob.end_date;
                                                    CurrentJob.start_date = updateJob.start_date;
                                                    CurrentJob.due_date = updateJob.due_date;
                                                    CurrentJob.category = updateJob.category;
                                                    CurrentJob.description = updateJob.description;
                                                    CurrentJob.percent = updateJob.percent;
                                                    CurrentJob.stage = updateJob.stage;
                                                    CurrentJob.dependency_id = updateJob.dependency_id;
                                                    CurrentJob.dependency_name = updateJob.dependency_name;
                                                    CurrentJob.assignee_id = updateJob.assignee_id;
                                                    CurrentJob.assignee_type = updateJob.assignee_type;
                                                    CurrentJob.assignee_name = updateJob.assignee_name;
                                                    CurrentJob.assignor_id = updateJob.assignor_id;
                                                    CurrentJob.assignor_type = updateJob.assignor_type;
                                                    CurrentJob.assignor_name = updateJob.assignor_name;
                                                    CurrentJob.required_hour = updateJob.required_hour;
                                                    CurrentJob.worked_hour = updateJob.worked_hour;

                                                    BackupJob.id = updateJob.id;
                                                    BackupJob.name = updateJob.name;
                                                    BackupJob.end_date = updateJob.end_date;
                                                    BackupJob.start_date = updateJob.start_date;
                                                    BackupJob.due_date = updateJob.due_date;
                                                    BackupJob.category = updateJob.category;
                                                    BackupJob.description = updateJob.description;
                                                    BackupJob.percent = updateJob.percent;
                                                    BackupJob.stage = updateJob.stage;
                                                    BackupJob.dependency_id = updateJob.dependency_id;
                                                    BackupJob.dependency_name = updateJob.dependency_name;
                                                    BackupJob.assignee_id = updateJob.assignee_id;
                                                    BackupJob.assignee_type = updateJob.assignee_type;
                                                    BackupJob.assignee_name = updateJob.assignee_name;
                                                    BackupJob.assignor_id = updateJob.assignor_id;
                                                    BackupJob.assignor_type = updateJob.assignor_type;
                                                    BackupJob.assignor_name = updateJob.assignor_name;
                                                    BackupJob.required_hour = updateJob.required_hour;
                                                    BackupJob.worked_hour = updateJob.worked_hour;

                                                    chosenJob.id = updateJob.id;
                                                    chosenJob.name = updateJob.name;
                                                    chosenJob.end_date = updateJob.end_date;
                                                    chosenJob.start_date = updateJob.start_date;
                                                    chosenJob.due_date = updateJob.due_date;
                                                    chosenJob.category = updateJob.category;
                                                    chosenJob.description = updateJob.description;
                                                    chosenJob.percent = updateJob.percent;
                                                    chosenJob.stage = updateJob.stage;
                                                    chosenJob.dependency_id = updateJob.dependency_id;
                                                    chosenJob.dependency_name = updateJob.dependency_name;
                                                    chosenJob.assignee_id = updateJob.assignee_id;
                                                    chosenJob.assignee_type = updateJob.assignee_type;
                                                    chosenJob.assignee_name = updateJob.assignee_name;
                                                    chosenJob.assignor_id = updateJob.assignor_id;
                                                    chosenJob.assignor_type = updateJob.assignor_type;
                                                    chosenJob.assignor_name = updateJob.assignor_name;
                                                    chosenJob.required_hour = updateJob.required_hour;
                                                    chosenJob.worked_hour = updateJob.worked_hour;

                                                    //GET ROOT ID OF CHOSEN JOB
                                                    int rootJobID = JobService.Ins.GetRootJobId((int)CurrentJob.id);
                                                    //BUILD TREE FROM ROOT ID
                                                    treeview.Items.Remove(TreeJob);
                                                    TreeJob = JobService.Ins.GetJobForTreeBinding(rootJobID, (int)CurrentJob.id);
                                                    treeview.Items.Add(TreeJob);

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
                else
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "You do not have permission to change this job!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }


            });
            SetEndDateNullCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                jobEndDate = null;
            });
            AssgineeChangeCM = new RelayCommand<object>((p) => { return BackupJob != null && jobAssignee != null; }, (p) =>
            {
                if ((jobAssignee.type != BackupJob.assignee_type) || (jobAssignee.type == BackupJob.assignee_type && jobAssignee.id != BackupJob.assignee_id))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Warning", "You are choosing differ assignee, this will delete related reports from the past assignee!", MessageType.Warning, MessageButtons.OK);
                    mb.ShowDialog();
                    MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you still want to change it?!", MessageType.Warning, MessageButtons.YesNo);
                    result.ShowDialog();

                    if (result.DialogResult == false)
                    {

                        for (int i = 0; i < AssigneeSource.Count; i++)
                        {
                            if (AssigneeSource[i].id == BackupJob.assignee_id && AssigneeSource[i].type == BackupJob.assignee_type)
                            {
                                jobAssignee = AssigneeSource[i];
                                i = AssigneeSource.Count;
                            }
                        }
                    }

                }
                if (jobEndDate == null)
                {
                    if (jobPercent == 100)
                    {
                        jobPercent = 40;
                    }
                }
                if (jobEndDate != null)
                {
                    jobPercent = 100;
                    if (jobWorked_hour == "0" || string.IsNullOrEmpty(jobWorked_hour))
                        jobWorked_hour = ((Int32.Parse(jobRequire_hour) * 10) / 100).ToString();
                }
            });
            StartChangeCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (DateTime.Compare((DateTime)jobStartDate, (DateTime)jobDueDate) > 0)
                {
                    TimeSpan result = jobDueDate.Subtract(PastStartDate);
                    jobDueDate = jobStartDate.Add(result);

                }
                if (jobEndDate != null)
                {
                    if (DateTime.Compare((DateTime)jobStartDate, (DateTime)jobEndDate) > 0)
                    {
                        TimeSpan result = jobEndDate.Value.Subtract(PastStartDate);
                        jobEndDate = jobStartDate.Add(result);
                    }
                }
                PastStartDate = jobStartDate;
                setStage();
            });
            DueChangeCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (DateTime.Compare((DateTime)jobStartDate, (DateTime)jobDueDate) > 0)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Warning", "Job due date must be greater or equal to start date!", MessageType.Warning, MessageButtons.OK);
                    mb.ShowDialog();
                    jobDueDate = PastDueDate;

                }
                PastDueDate = jobDueDate;
                setStage();
            });
            EndChangeCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (jobEndDate != null)
                {
                    if (DateTime.Compare((DateTime)jobStartDate, (DateTime)jobEndDate.Value) > 0)
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Warning", "Job end date must be greater or equal to start date!", MessageType.Warning, MessageButtons.OK);
                        mb.ShowDialog();
                        jobEndDate = PastEndDate;

                    }
                }
                PastEndDate = jobEndDate;
                setStage();
            });
            ChangeJobCM = new RelayCommand<TreeView>((p) => { return p.SelectedItem != null; }, async (p) =>
            {

                //SET INITIAL VALUE
                CurrentJob = JobService.Ins.GetJob((int)((JobsDTO)p.SelectedItem).id);
                if (CurrentJob == null)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Chosen job is not exist!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    IsChangable = false;
                    IsVisible = Visibility.Collapsed;
                    IsChangable2 = false;
                    IsVisible2 = Visibility.Visible;

                    if (CurrentJob.assignee_type == "USER" && CurrentJob.assignee_id == user.id)
                    {
                        IsChangable = false;
                        IsVisible = Visibility.Visible;
                        IsChangable2 = true;
                        IsVisible2 = Visibility.Collapsed;
                    }
                    if (CurrentJob.assignor_type == "USER" && CurrentJob.assignor_id == user.id)
                    {
                        IsChangable = true;
                        IsVisible = Visibility.Collapsed;
                        IsChangable2 = true;
                        IsVisible2 = Visibility.Collapsed;
                    }
                    BackupJob = (JobsDTO)p.SelectedItem;
                    //SET INITIAL VALUE
                    jobId = (int)CurrentJob.id;
                    jobName = CurrentJob.name;
                    jobAssignor = CurrentJob.assignor_id + "-" + CurrentJob.assignor_type + "-" + CurrentJob.assignor_name;
                    jobDescription = CurrentJob.description;

                    jobStartDate = DateTime.ParseExact(CurrentJob.start_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);
                    jobDueDate = DateTime.ParseExact(CurrentJob.due_date, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);
                    if (CurrentJob.end_date == "NONE")
                        jobEndDate = null;
                    else
                        jobEndDate = DateTime.ParseExact(CurrentJob.end_date, "dd-MM-yyyy",
                            System.Globalization.CultureInfo.InvariantCulture);
                    PastStartDate = jobStartDate;
                    PastDueDate = jobDueDate;
                    PastEndDate = jobEndDate;
                    jobStage = CurrentJob.stage;
                    jobPercent = (int)CurrentJob.percent;
                    jobRequire_hour = CurrentJob.required_hour.ToString();
                    jobWorked_hour = CurrentJob.worked_hour.ToString();
                    for (int i = 0; i < AssigneeSource.Count; i++)
                    {
                        if (AssigneeSource[i].id == CurrentJob.assignee_id && AssigneeSource[i].type == CurrentJob.assignee_type)
                        {
                            jobAssignee = AssigneeSource[i];
                            i = AssigneeSource.Count;
                        }
                    }
                    DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
                    DependencySource.Insert(0, new JobsDTO(-1, "NONE"));
                    for (int i = 0; i < DependencySource.Count; i++)
                    {
                        if (DependencySource[i].id == CurrentJob.id)
                        {
                            DependencySource.RemoveAt(i);
                            i = DependencySource.Count;
                        }
                    }
                    for (int i = 0; i < DependencySource.Count; i++)
                    {
                        if (DependencySource[i].id == CurrentJob.dependency_id)
                        {
                            jobDependency = DependencySource[i];
                            i = DependencySource.Count;
                        }
                    }
                    for (int i = 0; i < CategorySource.Count; i++)
                    {
                        if (CategorySource[i].name == CurrentJob.category)
                        {
                            jobCategory = CategorySource[i];
                            i = CategorySource.Count;
                        }
                    }
                }

            });
            PercentChangeCM = new RelayCommand<Slider>((p) => { return true; }, (p) =>
            {
                int a = (int)p.Value;
                if (a == 100)
                {
                    if (jobEndDate == null)
                    {
                        if (PastEndDate != null)
                            jobEndDate = PastEndDate;
                        else
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Infor", "Job setted to complete, system will choose random end date!", MessageType.Info, MessageButtons.OK);
                            mb.ShowDialog();
                            MessageBoxCustom mb2 = new MessageBoxCustom("Infor", "Please change end date to your desired date!", MessageType.Info, MessageButtons.OK);
                            mb2.ShowDialog();
                            var randomTest = new Random();

                            TimeSpan timeSpan = jobDueDate - jobStartDate;
                            TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
                            jobEndDate = jobStartDate + newSpan;
                        }

                    }
                }
                else
                {
                    if (jobEndDate != null)
                        jobEndDate = null;
                }

            });
            CheckRequireHourEmptyCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(jobRequire_hour) || jobRequire_hour == "0")
                {
                    jobRequire_hour = BackupJob.required_hour.ToString();
                }

            });
            CheckWorkedHourEmptyCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(jobWorked_hour) || jobWorked_hour == "0")
                {
                    if (jobStage == "WAITING")
                    {
                        jobWorked_hour = "0";
                    }
                    else
                    {
                        if (jobPercent != 0)
                            jobWorked_hour = ((Int32.Parse(jobRequire_hour) * 30) / 100).ToString();
                    }
                }

            });
        }

        public void setStage()
        {

            if (DateTime.Compare(jobStartDate, Current) > 0)
            {
                jobStage = "WAITING";
                jobPercent = 0;
                jobWorked_hour = "0";
            }
            else
            {
                if (jobEndDate == null)
                {
                    if (DateTime.Compare(jobDueDate, Current) < 0)
                    {
                        jobStage = "LATE";
                    }
                    else
                    {
                        jobStage = "PENDING";
                    }
                    if (jobPercent == 100)
                    {
                        jobPercent = 30;
                    }
                    if ((jobWorked_hour == "0" || string.IsNullOrEmpty(jobWorked_hour)) && jobPercent != 0)
                    {
                        jobWorked_hour = ((Int32.Parse(jobRequire_hour) * 30) / 100).ToString();
                    }
                }
                else
                {
                    if (DateTime.Compare((DateTime)jobEndDate, jobDueDate) <= 0)
                    {
                        jobStage = "COMPLETE SOON";
                    }
                    else
                    {
                        jobStage = "COMPLETE LATE";
                    }
                    jobPercent = 100;
                    if (jobWorked_hour == "0" || string.IsNullOrEmpty(jobWorked_hour))
                    {
                        jobWorked_hour = ((Int32.Parse(jobRequire_hour) * 30) / 100).ToString();
                    }
                }
            }

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
