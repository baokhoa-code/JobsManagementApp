﻿using JobsManagementApp.Model;
using JobsManagementApp.Service;
using JobsManagementApp.View.Share;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace JobsManagementApp.ViewModel.ShareModel
{
    public class ReportListForSingleAssigneeViewModel : BaseViewModel
    {
        public Admin admin { get; set; }
        public int assigneeid { get; set; }
        public UsersDTO assignee { get; set; }
        private string _assigneeName;
        public string assigneeName
        {
            get { return _assigneeName; }
            set { _assigneeName = value; OnPropertyChanged(); }
        }
        private int _assigneeId;
        public int assigneeId
        {
            get { return _assigneeId; }
            set { _assigneeId = value; OnPropertyChanged(); }
        }
        private bool _IsGettingSource;
        public bool IsGettingSource
        {
            get { return _IsGettingSource; }
            set { _IsGettingSource = value; OnPropertyChanged(); }
        }
        private ObservableCollection<ReportsDTO> _Reports;
        public ObservableCollection<ReportsDTO> Reports
        {
            get { return _Reports; }
            set { _Reports = value; OnPropertyChanged(); }
        }
        private ReportsDTO _SelectedItem;
        public ReportsDTO SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }
        public static Grid MaskName { get; set; }
        public ICommand OpenAddReportWindowCM { get; set; }
        public ICommand OpenEditReportPageCM { get; set; }
        public ICommand DeleteReportCM { get; set; }
        public ICommand MaskNameCM { get; set; }
        public ICommand LoadCM { get; set; }
        public ICommand GoBackCM { get; set; }
        public ReportListForSingleAssigneeViewModel(Admin a, int assignee_id)
        {

            admin = new Admin(a);
            assigneeid = assignee_id;

            //DEFINE COMMAND
            GoBackCM = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                p.NavigationService.GoBack();
            });
            LoadCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                Load();

            });
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });
            OpenAddReportWindowCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {

            });
            OpenEditReportPageCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {

            });
            DeleteReportCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                MessageBoxCustom result = new MessageBoxCustom("Warning", "Do you want to delete this report?", MessageType.Warning, MessageButtons.YesNo);
                result.ShowDialog();

                if (result.DialogResult == true)
                {
                    IsGettingSource = true;

                    (bool isSuccess, string messageFromUpdate) = await ReportService.Ins.DeleteReport((int)SelectedItem.id);

                    IsGettingSource = false;

                    if (isSuccess)
                    {
                        for (int i = 0; i < Reports.Count; i++)
                        {
                            if (Reports[i].id == SelectedItem?.id)
                            {
                                Reports.Remove(Reports[i]);
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
        }
        public async Task Load()
        {
            try
            {
                IsGettingSource = true;
                assignee = await UserService.Ins.GetUser(assigneeid);

                if (assignee != null)
                {
                    Reports = new ObservableCollection<ReportsDTO>(await ReportService.Ins.GetAllReportByAssigneeID("USER", (int)assignee.id));
                    assigneeId = (int)assignee.id;
                    assigneeName = assignee.name;
                }

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
    }
}
