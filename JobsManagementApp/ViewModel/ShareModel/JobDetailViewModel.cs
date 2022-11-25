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
        private DateTime _jobDueDate;
        public DateTime jobDueDate
        {
            get { return _jobDueDate; }
            set { _jobDueDate = value; OnPropertyChanged(); }
        }
        private string _jobRequire_hour;
        public string jobRequire_hour
        {
            get { return _jobRequire_hour; }
            set { _jobRequire_hour = value; OnPropertyChanged(); }
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

        #endregion

        #region Internal Varirables
        public Admin admin { get; set; }
        public UsersDTO user { get; set; }
        public Grid Mask { get; set; }
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
        public ICommand MoveToReportListCM { get; set; }
        public ICommand GoBackCM { get; set; }


        #endregion




        public JobDetailViewModel(Admin a, JobsDTO chosenJob)
        {
            admin = a;
            IsChangable = true;
            IsVisible = Visibility.Collapsed;
            BackupJob = chosenJob;
            CurrentJob = new JobsDTO( chosenJob );

            int rootJobID = JobService.Ins.GetRootJobId((int)CurrentJob.id);

            TreeJob = JobService.Ins.GetJobForTreeBinding(rootJobID,(int)CurrentJob.id);

            LoadCM = new RelayCommand<TreeView>((p) => { return true; }, (p) =>
            {
                treeview = p;
                treeview.Items.Add(TreeJob);
                Load();
                
            });
            ChangeJobCM = new RelayCommand<TreeView>((p) => { return true; }, (p) =>
            {
                //JobsDTO temp = new JobsDTO();
                //temp = (JobsDTO)p.SelectedItem;
                //Notification w = new Notification(temp.name);
                //w.ShowDialog();
            });
        }
        public JobDetailViewModel()
        {
            //int startJobID = 18;
            //int rootJobID = JobService.Ins.GetRootJobId(startJobID);
            //CurrentJob = JobService.Ins.GetJobForTreeBinding(rootJobID, startJobID);

            //LoadCM = new RelayCommand<TreeView>((p) => { return true; }, (p) =>
            //{
            //    treeview = p;
            //    treeview.Items.Add(CurrentJob);
            //});
            //ChangeJobCM = new RelayCommand<TreeView>((p) => { return true; }, (p) =>
            //{
            //    //JobsDTO temp = new JobsDTO();
            //    //temp = (JobsDTO)p.SelectedItem;
            //    //Notification w = new Notification(temp.name);
            //    //w.ShowDialog();
            //});
        }


        public async Task Load()
        {
            try
            {
                //AssigneeSource = new ObservableCollection<Assignee_AssignorDTO>(await JobService.Ins.GetAssignee());
                //DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
                CategorySource = new ObservableCollection<CategoriesDTO>(await CategoryService.Ins.GetAllCategory());
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
