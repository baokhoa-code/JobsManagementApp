//foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
//{
//    string name = descriptor.Name;
//    object value = descriptor.GetValue(obj);
//    Console.WriteLine("{0}={1}", name, value);
//}
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
using JobsManagementApp.ViewModel.AdminModel;
using JobsManagementApp.ViewModel.UserModel;

namespace JobsManagementApp.ViewModel.ShareModel
{
    public class JobAddViewModel : BaseViewModel
    {
        public Admin admin { get; set; }
        public UsersDTO user { get; set; }
        private JobsDTO _job;
        public JobsDTO job
        {
            get { return _job; }
            set { _job = value; OnPropertyChanged(); }
        }
        private bool _IsAssigneeChanagable;
        public bool IsAssigneeChanagable
        {
            get { return _IsAssigneeChanagable; }
            set { _IsAssigneeChanagable = value; OnPropertyChanged(); }
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
            get { return _jobStartDate ; }
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

        public Grid Mask { get; set; }

        public ICommand LoadCM { get; set; }
        public ICommand AddJobCM { get; set; }
        public ICommand ClearInforCM { get; set; }
        public ICommand CloseWindowCM { get; set; }

        public JobAddViewModel(Admin a,   JobManagementPageAdminViewModel dbpa)
        {

            admin = new Admin(a);
            job = new JobsDTO();
            jobAssignor = a.id + "-" + "ADMIN" + "-" + a.name;
            jobName = "";
            jobRequire_hour = "";
            jobDescription = "";
            IsAssigneeChanagable = true;
            DateTime current_t = DateTime.Now;
            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            jobStartDate = current;
            jobDueDate = current;
            //DEFINE COMMAND
            CloseWindowCM = new RelayCommand<Window>((p) => { return p != null; }, async (p) =>
            {
                job = new JobsDTO();
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobAssignee = null;
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;
                Mask.Visibility = Visibility.Collapsed;
                p.Close();

            });
            ClearInforCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobAssignee = null;
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;

            });
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();

            });
            AddJobCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(jobName))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Job name cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    job = new JobsDTO();
                }
                else
                {
                    job.name = jobName;
                    if (string.IsNullOrEmpty(jobDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Job description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        job = new JobsDTO();
                    }
                    else
                    {
                        job.description = jobDescription;
                        if (string.IsNullOrEmpty(jobRequire_hour))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Job require hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            job = new JobsDTO();
                        }
                        else
                        {
                            job.required_hour = Int32.Parse(jobRequire_hour);
                            if (jobCategory == null)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Job category cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                job = new JobsDTO();
                            }
                            else
                            {
                                job.category = jobCategory.name;
                                if (jobAssignee == null)
                                {
                                    job.assignee_id = -1;
                                    job.assignee_type = "NONE";
                                    job.assignee_name = "NONE";
                                }
                                if (jobAssignee != null)
                                {
                                    job.assignee_id = jobAssignee.id;
                                    job.assignee_type = jobAssignee.type;
                                    job.assignee_name = jobAssignee.name;
                                }
                                job.category = jobCategory.name;
                                if (jobDependency == null)
                                {
                                    job.dependency_id = -1;
                                    job.dependency_name = "NONE";
                                }
                                if (jobDependency != null)
                                {
                                    job.dependency_id = jobDependency.id;
                                    job.dependency_name = jobDependency.name;
                                }
                                if (admin != null)
                                {
                                    job.assignor_id = admin.id;
                                    job.assignor_type = "ADMIN";
                                    job.assignor_name = admin.name;
                                }
                                if (user != null)
                                {
                                    job.assignor_id = user.id;
                                    job.assignor_type = "USER";
                                    job.assignor_name = user.name;
                                }
                                job.percent = 0;
                                job.worked_hour = 0;
                                job.stage = "WAITING";
                                job.end_date = "NONE";
                                job.start_date = jobStartDate.ToString("dd-MM-yyy");
                                job.due_date = jobDueDate.ToString("dd-MM-yyy");

                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this job?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await JobService.Ins.AddJob(job);


                                        if (isSuccess)
                                        {
                                            dbpa.Load2();

                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                            mb.ShowDialog();
                                            job = new JobsDTO();
                                            jobName = "";
                                            jobRequire_hour = "";
                                            jobDescription = "";
                                            jobAssignee = null;
                                            jobCategory = null;
                                            jobDependency = null;
                                            DateTime current_t = DateTime.Now;
                                            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                                                System.Globalization.CultureInfo.InvariantCulture);
                                            jobStartDate = current;
                                            jobDueDate = current;
                                            DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
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
        }

        public JobAddViewModel(Admin a, JobListForSingleAssigneeViewModel dbpa)
        {

            admin = new Admin(a);
            job = new JobsDTO();
            jobAssignor = a.id + "-" + "ADMIN" + "-" + a.name;
            jobName = "";
            jobRequire_hour = "";
            jobDescription = "";
            IsAssigneeChanagable = false;
            DateTime current_t = DateTime.Now;
            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            jobStartDate = current;
            jobDueDate = current;
            //DEFINE COMMAND
            CloseWindowCM = new RelayCommand<Window>((p) => { return p != null; }, async (p) =>
            {
                job = new JobsDTO();
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobAssignee = null;
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;
                Mask.Visibility = Visibility.Collapsed;
                p.Close();

            });
            ClearInforCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;

            });
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();
                if(dbpa.assignee != null)
                {
                    for (int i = 0; i < AssigneeSource.Count; i++)
                    {
                        if (AssigneeSource[i].id == dbpa.assignee.id && AssigneeSource[i].type == "USER")
                        {
                            jobAssignee = AssigneeSource[i];
                            i = AssigneeSource.Count;
                        }
                    }
                }
                

            });
            AddJobCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(jobName))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Job name cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    job = new JobsDTO();
                }
                else
                {
                    job.name = jobName;
                    if (string.IsNullOrEmpty(jobDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Job description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        job = new JobsDTO();
                    }
                    else
                    {
                        job.description = jobDescription;
                        if (string.IsNullOrEmpty(jobRequire_hour))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Job require hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            job = new JobsDTO();
                        }
                        else
                        {
                            job.required_hour = Int32.Parse(jobRequire_hour);
                            if (jobCategory == null)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Job category cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                job = new JobsDTO();
                            }
                            else
                            {
                                job.category = jobCategory.name;
                                if (jobAssignee == null)
                                {
                                    job.assignee_id = -1;
                                    job.assignee_type = "NONE";
                                    job.assignee_name = "NONE";
                                }
                                if (jobAssignee != null)
                                {
                                    job.assignee_id = jobAssignee.id;
                                    job.assignee_type = jobAssignee.type;
                                    job.assignee_name = jobAssignee.name;
                                }
                                job.category = jobCategory.name;
                                if (jobDependency == null)
                                {
                                    job.dependency_id = -1;
                                    job.dependency_name = "NONE";
                                }
                                if (jobDependency != null)
                                {
                                    job.dependency_id = jobDependency.id;
                                    job.dependency_name = jobDependency.name;
                                }
                                if (admin != null)
                                {
                                    job.assignor_id = admin.id;
                                    job.assignor_type = "ADMIN";
                                    job.assignor_name = admin.name;
                                }
                                if (user != null)
                                {
                                    job.assignor_id = user.id;
                                    job.assignor_type = "USER";
                                    job.assignor_name = user.name;
                                }
                                job.percent = 0;
                                job.worked_hour = 0;
                                job.stage = "WAITING";
                                job.end_date = "NONE";
                                job.start_date = jobStartDate.ToString("dd-MM-yyy");
                                job.due_date = jobDueDate.ToString("dd-MM-yyy");

                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this job?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await JobService.Ins.AddJob(job);


                                        if (isSuccess)
                                        {
                                            dbpa.Load2();

                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                            mb.ShowDialog();
                                            job = new JobsDTO();
                                            jobName = "";
                                            jobRequire_hour = "";
                                            jobDescription = "";
                                            jobCategory = null;
                                            jobDependency = null;
                                            DateTime current_t = DateTime.Now;
                                            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                                                System.Globalization.CultureInfo.InvariantCulture);
                                            jobStartDate = current;
                                            jobDueDate = current;
                                            DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
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
        }

        public JobAddViewModel(UsersDTO a, JobManagementPageUserViewModel dbpa)
        {

            user = a;
            job = new JobsDTO();
            jobAssignor = a.id + "-" + "USER" + "-" + a.name;
            jobName = "";
            jobRequire_hour = "";
            jobDescription = "";
            IsAssigneeChanagable = true;
            DateTime current_t = DateTime.Now;
            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            jobStartDate = current;
            jobDueDate = current;
            //DEFINE COMMAND
            CloseWindowCM = new RelayCommand<Window>((p) => { return p != null; }, async (p) =>
            {
                job = new JobsDTO();
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobAssignee = null;
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;
                Mask.Visibility = Visibility.Collapsed;
                p.Close();

            });
            ClearInforCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobAssignee = null;
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;

            });
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();
                for (int i = 0; i < AssigneeSource.Count; i++)
                {
                    if (AssigneeSource[i].type == "ADMIN")
                    {
                        AssigneeSource.RemoveAt(i);
                    }
                }
            });
            AddJobCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(jobName))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Job name cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    job = new JobsDTO();
                }
                else
                {
                    job.name = jobName;
                    if (string.IsNullOrEmpty(jobDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Job description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        job = new JobsDTO();
                    }
                    else
                    {
                        job.description = jobDescription;
                        if (string.IsNullOrEmpty(jobRequire_hour))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Job require hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            job = new JobsDTO();
                        }
                        else
                        {
                            job.required_hour = Int32.Parse(jobRequire_hour);
                            if (jobCategory == null)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Job category cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                job = new JobsDTO();
                            }
                            else
                            {
                                job.category = jobCategory.name;
                                if (jobAssignee == null)
                                {
                                    job.assignee_id = -1;
                                    job.assignee_type = "NONE";
                                    job.assignee_name = "NONE";
                                }
                                if (jobAssignee != null)
                                {
                                    job.assignee_id = jobAssignee.id;
                                    job.assignee_type = jobAssignee.type;
                                    job.assignee_name = jobAssignee.name;
                                }
                                job.category = jobCategory.name;
                                if (jobDependency == null)
                                {
                                    job.dependency_id = -1;
                                    job.dependency_name = "NONE";
                                }
                                if (jobDependency != null)
                                {
                                    job.dependency_id = jobDependency.id;
                                    job.dependency_name = jobDependency.name;
                                }
                                if (admin != null)
                                {
                                    job.assignor_id = admin.id;
                                    job.assignor_type = "ADMIN";
                                    job.assignor_name = admin.name;
                                }
                                if (user != null)
                                {
                                    job.assignor_id = user.id;
                                    job.assignor_type = "USER";
                                    job.assignor_name = user.name;
                                }
                                job.percent = 0;
                                job.worked_hour = 0;
                                job.stage = "WAITING";
                                job.end_date = "NONE";
                                job.start_date = jobStartDate.ToString("dd-MM-yyy");
                                job.due_date = jobDueDate.ToString("dd-MM-yyy");

                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this job?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await JobService.Ins.AddJob(job);


                                        if (isSuccess)
                                        {
                                            dbpa.Load2();

                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                            mb.ShowDialog();
                                            job = new JobsDTO();
                                            jobName = "";
                                            jobRequire_hour = "";
                                            jobDescription = "";
                                            jobAssignee = null;
                                            jobCategory = null;
                                            jobDependency = null;
                                            DateTime current_t = DateTime.Now;
                                            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                                                System.Globalization.CultureInfo.InvariantCulture);
                                            jobStartDate = current;
                                            jobDueDate = current;
                                            DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
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
        }
        public JobAddViewModel(Admin a, ObservableCollection<JobsDTO> JobsPie, ObservableCollection<JobsDTO> JobsLine, ObservableCollection<JobsDTO> Jobs, DashBoardPageAdminViewModel dbpa)
        {

            admin = new Admin(a);
            job = new JobsDTO();
            jobAssignor = a.id + "-" + "ADMIN" + "-" + a.name;
            jobName = "";
            jobRequire_hour = "";
            jobDescription = "";
            IsAssigneeChanagable = false;
            DateTime current_t = DateTime.Now;
            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            jobStartDate = current;
            jobDueDate = current;
            //DEFINE COMMAND
            CloseWindowCM = new RelayCommand<Window>((p) => { return p != null; }, async (p) =>
            {
                job = new JobsDTO();
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobAssignee = null;
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;
                Mask.Visibility = Visibility.Collapsed;
                p.Close();

            });
            ClearInforCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;

            });
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();
                if (dbpa.admin != null)
                {
                    for (int i = 0; i < AssigneeSource.Count; i++)
                    {
                        if (AssigneeSource[i].id == dbpa.admin.id && AssigneeSource[i].type == "ADMIN")
                        {
                            jobAssignee = AssigneeSource[i];
                            i = AssigneeSource.Count;
                        }
                    }
                }
            });
            AddJobCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(jobName))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Job name cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    job = new JobsDTO();
                }
                else
                {
                    job.name = jobName;
                    if (string.IsNullOrEmpty(jobDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Job description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        job = new JobsDTO();
                    }
                    else
                    {
                        job.description = jobDescription;
                        if (string.IsNullOrEmpty(jobRequire_hour))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Job require hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            job = new JobsDTO();
                        }
                        else
                        {
                            job.required_hour = Int32.Parse(jobRequire_hour);
                            if (jobCategory == null)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Job category cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                job = new JobsDTO();
                            }
                            else
                            {
                                job.category = jobCategory.name;
                                if (jobAssignee == null)
                                {
                                    job.assignee_id = -1;
                                    job.assignee_type = "NONE";
                                    job.assignee_name = "NONE";
                                }
                                if (jobAssignee != null)
                                {
                                    job.assignee_id = jobAssignee.id;
                                    job.assignee_type = jobAssignee.type;
                                    job.assignee_name = jobAssignee.name;
                                }
                                job.category = jobCategory.name;
                                if (jobDependency == null)
                                {
                                    job.dependency_id = -1;
                                    job.dependency_name = "NONE";
                                }
                                if (jobDependency != null)
                                {
                                    job.dependency_id = jobDependency.id;
                                    job.dependency_name = jobDependency.name;
                                }
                                if (admin != null)
                                {
                                    job.assignor_id = admin.id;
                                    job.assignor_type = "ADMIN";
                                    job.assignor_name = admin.name;
                                }
                                if (user != null)
                                {
                                    job.assignor_id = user.id;
                                    job.assignor_type = "USER";
                                    job.assignor_name = user.name;
                                }
                                job.percent = 0;
                                job.worked_hour = 0;
                                job.stage = "WAITING";
                                job.end_date = "NONE";
                                job.start_date = jobStartDate.ToString("dd-MM-yyy");
                                job.due_date = jobDueDate.ToString("dd-MM-yyy");

                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this job?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await JobService.Ins.AddJob(job);
                                        

                                        if (isSuccess)
                                        {
                                            dbpa.Load();
                                            dbpa.PieSelectionChanged();
                                            if (dbpa.LineStage == "WEEK")
                                            {
                                                dbpa.LoadLineByWeek();
                                            }
                                            if (dbpa.LineStage == "MONTH")
                                            {
                                                dbpa.LoadLineByMonth();
                                            }
                                            if (dbpa.LineStage == "YEAR")
                                            {
                                                dbpa.LoadLineByYear();
                                            }
                                            
                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                            mb.ShowDialog();
                                            job = new JobsDTO();
                                            jobName = "";
                                            jobRequire_hour = "";
                                            jobDescription = "";
                                            jobCategory = null;
                                            jobDependency = null;
                                            DateTime current_t = DateTime.Now;
                                            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                                                System.Globalization.CultureInfo.InvariantCulture);
                                            jobStartDate = current;
                                            jobDueDate = current;
                                            DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
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
        }

        public JobAddViewModel(UsersDTO a, ObservableCollection<JobsDTO> JobsPie, ObservableCollection<JobsDTO> JobsLine, ObservableCollection<JobsDTO> Jobs, DashBoardPageUserViewModel dbpa)
        {

            user = new UsersDTO(a);
            job = new JobsDTO();
            jobAssignor = a.id + "-" + "USER" + "-" + a.name;
            jobName = "";
            jobRequire_hour = "";
            jobDescription = "";
            IsAssigneeChanagable = false;
            DateTime current_t = DateTime.Now;
            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            jobStartDate = current;
            jobDueDate = current;
            //DEFINE COMMAND
            CloseWindowCM = new RelayCommand<Window>((p) => { return p != null; }, async (p) =>
            {
                job = new JobsDTO();
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;
                Mask.Visibility = Visibility.Collapsed;
                p.Close();

            });
            ClearInforCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;

            });
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();
                for (int i = 0; i < AssigneeSource.Count; i++)
                {
                    if (AssigneeSource[i].type == "ADMIN")
                    {
                        AssigneeSource.RemoveAt(i);
                    }
                }
                if (dbpa.user != null)
                {
                    for (int i = 0; i < AssigneeSource.Count; i++)
                    {
                        if (AssigneeSource[i].id == dbpa.user.id && AssigneeSource[i].type == "USER")
                        {
                            jobAssignee = AssigneeSource[i];
                            i = AssigneeSource.Count;
                        }
                    }
                }
            });
            AddJobCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(jobName))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Job name cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    job = new JobsDTO();
                }
                else
                {
                    job.name = jobName;
                    if (string.IsNullOrEmpty(jobDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Job description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        job = new JobsDTO();
                    }
                    else
                    {
                        job.description = jobDescription;
                        if (string.IsNullOrEmpty(jobRequire_hour))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Job require hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            job = new JobsDTO();
                        }
                        else
                        {
                            job.required_hour = Int32.Parse(jobRequire_hour);
                            if (jobCategory == null)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Job category cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                job = new JobsDTO();
                            }
                            else
                            {
                                job.category = jobCategory.name;
                                if (jobAssignee == null)
                                {
                                    job.assignee_id = -1;
                                    job.assignee_type = "NONE";
                                    job.assignee_name = "NONE";
                                }
                                if (jobAssignee != null)
                                {
                                    job.assignee_id = jobAssignee.id;
                                    job.assignee_type = jobAssignee.type;
                                    job.assignee_name = jobAssignee.name;
                                }
                                job.category = jobCategory.name;
                                if (jobDependency == null)
                                {
                                    job.dependency_id = -1;
                                    job.dependency_name = "NONE";
                                }
                                if (jobDependency != null)
                                {
                                    job.dependency_id = jobDependency.id;
                                    job.dependency_name = jobDependency.name;
                                }
                                if (admin != null)
                                {
                                    job.assignor_id = admin.id;
                                    job.assignor_type = "ADMIN";
                                    job.assignor_name = admin.name;
                                }
                                if (user != null)
                                {
                                    job.assignor_id = user.id;
                                    job.assignor_type = "USER";
                                    job.assignor_name = user.name;
                                }
                                job.percent = 0;
                                job.worked_hour = 0;
                                job.stage = "WAITING";
                                job.end_date = "NONE";
                                job.start_date = jobStartDate.ToString("dd-MM-yyy");
                                job.due_date = jobDueDate.ToString("dd-MM-yyy");

                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this job?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await JobService.Ins.AddJob(job);


                                        if (isSuccess)
                                        {
                                            dbpa.Load();
                                            dbpa.PieSelectionChanged();
                                            if (dbpa.LineStage == "WEEK")
                                            {
                                                dbpa.LoadLineByWeek();
                                            }
                                            if (dbpa.LineStage == "MONTH")
                                            {
                                                dbpa.LoadLineByMonth();
                                            }
                                            if (dbpa.LineStage == "YEAR")
                                            {
                                                dbpa.LoadLineByYear();
                                            }

                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                            mb.ShowDialog();
                                            job = new JobsDTO();
                                            jobName = "";
                                            jobRequire_hour = "";
                                            jobDescription = "";
                                            jobCategory = null;
                                            jobDependency = null;
                                            DateTime current_t = DateTime.Now;
                                            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                                                System.Globalization.CultureInfo.InvariantCulture);
                                            jobStartDate = current;
                                            jobDueDate = current;
                                            DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
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
        }


        public JobAddViewModel(Admin a)
        {

            admin = new Admin(a);
            job = new JobsDTO();
            jobAssignor = a.id + "-" + "ADMIN" + "-" + a.name;
            jobName = "";
            jobRequire_hour = "";
            jobDescription = "";
            DateTime current_t = DateTime.Now;
            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            jobStartDate = current;
            jobDueDate = current;
            //DEFINE COMMAND
            CloseWindowCM = new RelayCommand<Window>((p) => { return p!=null; }, async (p) =>
            {
                job = new JobsDTO();
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobAssignee = null;
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;
                Mask.Visibility = Visibility.Collapsed;
                p.Close();
                
            });
            ClearInforCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobAssignee = null;
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;

            });
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();

            });
            AddJobCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(jobName))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Job name cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    job = new JobsDTO();
                }
                else
                {
                    job.name = jobName;
                    if (string.IsNullOrEmpty(jobDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Job description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        job = new JobsDTO();
                    }
                    else
                    {
                        job.description = jobDescription;
                        if (string.IsNullOrEmpty(jobRequire_hour))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Job require hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            job = new JobsDTO();
                        }
                        else
                        {
                            job.required_hour = Int32.Parse(jobRequire_hour);
                            if (jobCategory == null)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Job category cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                job = new JobsDTO();
                            }
                            else
                            {
                                job.category = jobCategory.name;
                                if (jobAssignee == null)
                                {
                                    job.assignee_id = -1;
                                    job.assignee_type = "NONE";
                                    job.assignee_name = "NONE";
                                }
                                if (jobAssignee != null)
                                {
                                    job.assignee_id = jobAssignee.id;
                                    job.assignee_type = jobAssignee.type;
                                    job.assignee_name = jobAssignee.name;
                                }
                                job.category = jobCategory.name;
                                if (jobDependency == null)
                                {
                                    job.dependency_id = -1;
                                    job.dependency_name = "NONE";
                                }
                                if (jobDependency != null)
                                {
                                    job.dependency_id = jobDependency.id;
                                    job.dependency_name = jobDependency.name;
                                }
                                if (admin != null)
                                {
                                    job.assignor_id = admin.id;
                                    job.assignor_type = "ADMIN";
                                    job.assignor_name = admin.name;
                                }
                                if (user != null)
                                {
                                    job.assignor_id = user.id;
                                    job.assignor_type = "USER";
                                    job.assignor_name = user.name;
                                }
                                job.percent = 0;
                                job.worked_hour = 0;
                                job.stage = "WAITING";
                                job.end_date = "NONE";
                                job.start_date = jobStartDate.ToString("dd-MM-yyy");
                                job.due_date = jobDueDate.ToString("dd-MM-yyy");

                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this job?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await JobService.Ins.AddJob(job);
                                        if (isSuccess)
                                        {
                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                            mb.ShowDialog();
                                            job = new JobsDTO();
                                            jobName = "";
                                            jobRequire_hour = "";
                                            jobDescription = "";
                                            jobAssignee = null;
                                            jobCategory = null;
                                            jobDependency = null;
                                            DateTime current_t = DateTime.Now;
                                            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                                                System.Globalization.CultureInfo.InvariantCulture);
                                            jobStartDate = current;
                                            jobDueDate = current;
                                            DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
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
        }
        public JobAddViewModel(UsersDTO u)
        {

            user = new UsersDTO(u);
            job = new JobsDTO();
            jobAssignor = user.id + "-" + "USER" + "-" + user.name;
            jobName = "";
            jobRequire_hour = "";
            jobDescription = "";
            DateTime current_t = DateTime.Now;
            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            jobStartDate = current;
            jobDueDate = current;
            //DEFINE COMMAND
            ClearInforCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                jobName = "";
                jobRequire_hour = "";
                jobDescription = "";
                jobAssignee = null;
                jobCategory = null;
                jobDependency = null;
                DateTime current_t = DateTime.Now;
                DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                jobStartDate = current;
                jobDueDate = current;

            });
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();

            });
            AddJobCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(jobName))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Error", "Job name cannot be empty!", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                    job = new JobsDTO();
                }
                else
                {
                    job.name = jobName;
                    if (string.IsNullOrEmpty(jobDescription))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Error", "Job description cannot be empty!", MessageType.Error, MessageButtons.OK);
                        mb.ShowDialog();
                        job = new JobsDTO();
                    }
                    else
                    {
                        job.description = jobDescription;
                        if (string.IsNullOrEmpty(jobRequire_hour))
                        {
                            MessageBoxCustom mb = new MessageBoxCustom("Error", "Job require hour cannot be empty!", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            job = new JobsDTO();
                        }
                        else
                        {
                            job.required_hour = Int16.Parse(jobRequire_hour);
                            if (jobCategory == null)
                            {
                                MessageBoxCustom mb = new MessageBoxCustom("Error", "Job category cannot be empty!", MessageType.Error, MessageButtons.OK);
                                mb.ShowDialog();
                                job = new JobsDTO();
                            }
                            else
                            {
                                job.category = jobCategory.name;
                                if (jobAssignee == null)
                                {
                                    job.assignee_id = -1;
                                    job.assignee_type = "NONE";
                                    job.assignee_name = "NONE";
                                }
                                if (jobAssignee != null)
                                {
                                    job.assignee_id = jobAssignee.id;
                                    job.assignee_type = jobAssignee.type;
                                    job.assignee_name = jobAssignee.name;
                                }
                                job.category = jobCategory.name;
                                if (jobDependency == null)
                                {
                                    job.dependency_id = -1;
                                    job.dependency_name = "NONE";
                                }
                                if (jobDependency != null)
                                {
                                    job.dependency_id = jobDependency.id;
                                    job.dependency_name = jobDependency.name;
                                }
                                if (admin != null)
                                {
                                    job.assignor_id = admin.id;
                                    job.assignor_type = "ADMIN";
                                    job.assignor_name = admin.name;
                                }
                                if (user != null)
                                {
                                    job.assignor_id = user.id;
                                    job.assignor_type = "USER";
                                    job.assignor_name = user.name;
                                }
                                job.percent = 0;
                                job.worked_hour = 0;
                                job.stage = "WAITING";
                                job.end_date = "NONE";
                                job.start_date = jobStartDate.ToString("dd-MM-yyy");
                                job.due_date = jobDueDate.ToString("dd-MM-yyy");

                                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to add this job?", MessageType.Warning, MessageButtons.YesNo);
                                result.ShowDialog();

                                if (result.DialogResult == true)
                                {
                                    try
                                    {
                                        (bool isSuccess, string messageFromUpdate) = await JobService.Ins.AddJob(job);
                                        if (isSuccess)
                                        {
                                            MessageBoxCustom mb = new MessageBoxCustom("Annouce", messageFromUpdate, MessageType.Success, MessageButtons.OK);
                                            mb.ShowDialog();
                                            job = new JobsDTO();
                                            jobName = "";
                                            jobRequire_hour = "";
                                            jobDescription = "";
                                            jobAssignee = null;
                                            jobCategory = null;
                                            jobDependency = null;
                                            DateTime current_t = DateTime.Now;
                                            DateTime current = DateTime.ParseExact(current_t.ToString("dd-MM-yyyy"), "dd-MM-yyyy",
                                                System.Globalization.CultureInfo.InvariantCulture);
                                            jobStartDate = current;
                                            jobDueDate = current;
                                            DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
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
        }
        //INTERNAL FUNCTIONS
        public async Task Load()
        {
            try
            {
                AssigneeSource = new ObservableCollection<Assignee_AssignorDTO>(await JobService.Ins.GetAssignee());
                DependencySource = new ObservableCollection<JobsDTO>(await JobService.Ins.GetAllJob());
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
