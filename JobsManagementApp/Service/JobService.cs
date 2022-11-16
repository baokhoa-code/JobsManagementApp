using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsManagementApp.Model;
using System.Windows;
using JobsManagementApp.Model;
using MySql.Data.MySqlClient;
using JobsManagementApp.ViewModel.AdminModel;
using System.Collections.ObjectModel;

namespace JobsManagementApp.Service
{
    public class JobService
    {
        public JobService()
        {

        }
        private static JobService? _ins;
        public static JobService? Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new JobService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        public ObservableCollection<JobsDTO> GetAllJob()
        {
            ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM JOB";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                Jobs.Add(
                    new JobsDTO(
                    (int)reader["ID"], 
                    (int)reader["DEPENDENCY_ID"], 
                    (string)reader["DEPENDENCY_NAME"],
                    (string)reader["NAME"],
                    (string)reader["DESCRIPTION"],
                    (string)reader["CATEGORY"],
                    (string)reader["START_DATE"],
                    (string)reader["DUE_DATE"],
                    (string)reader["END_DATE"],
                    (int)reader["REQUIRED_HOUR"],
                    (int)reader["WORKED_HOUR"],
                    (int)reader["PERCENT"],
                    (string)reader["STAGE"],
                    (int)reader["ASSIGNOR_ID"],
                    (string)reader["ASSIGNOR_TYPE"],
                    (string)reader["ASSIGNOR_NAME"],
                    (int)reader["ASSIGNEE_ID"],
                    (string)reader["ASSIGNEE_TYPE"],
                    (string)reader["ASSIGNEE_NAME"]
                    ));
            }
            dbc.connection.Close();
            return Jobs;
        }
        public List<string> InsertAssignorCombobox()
        {
            List<string> list = new List<string>();
            ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT DISTINCT ASSIGNOR_TYPE, ASSIGNOR_NAME FROM JOB ORDER BY ASSIGNOR_TYPE ASC";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                list.Add((string)reader["ASSIGNOR_TYPE"] + ": " + (string)reader["ASSIGNOR_NAME"]);
            }
            return list;
        }
        public List<string> InsertAssigneeCombobox()
        {
            List<string> list = new List<string>();
            ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT DISTINCT ASSIGNEE_TYPE, ASSIGNEE_NAME FROM JOB WHERE ASSIGNEE_ID != -1 AND ASSIGNEE_NAME != 'NONE'  ORDER BY ASSIGNOR_TYPE ASC";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                list.Add((string)reader["ASSIGNEE_TYPE"] + ": " + (string)reader["ASSIGNEE_NAME"]);
            }
            return list;
        }
        public List<string> InsertDependencyCombobox()
        {
            List<string> list = new List<string>();
            ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT DISTINCT DEPENDENCY_NAME FROM JOB WHERE DEPENDENCY_ID != -1 AND DEPENDENCY_NAME != 'NONE'  ORDER BY DEPENDENCY_NAME ASC";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                list.Add((string)reader["DEPENDENCY_NAME"]);
            }
            return list;
        }
    }
}
