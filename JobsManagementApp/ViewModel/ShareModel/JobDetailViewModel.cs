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
        public ICommand LoadCM { get; set; }
        public ICommand ChangeJobCM { get; set; }

        private JobsDTO _Job;
        public JobsDTO Job
        {
            get { return _Job; }
            set { _Job = value; OnPropertyChanged(); }
        }
        public JobDetailViewModel()
        {
            int startJobID = 18;
            int rootJobID = JobService.Ins.GetRootJobId(startJobID);
            Job = JobService.Ins.GetJobForTreeBinding(rootJobID, startJobID);

            LoadCM = new RelayCommand<TreeView>((p) => { return true; }, (p) =>
            {
                p.Items.Add(Job);
            });
            ChangeJobCM = new RelayCommand<TreeView>((p) => { return true; }, (p) =>
            {
                //JobsDTO temp = new JobsDTO();
                //temp = (JobsDTO)p.SelectedItem;
                //Notification w = new Notification(temp.name);
                //w.ShowDialog();
            });
        }

    }
}
