using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsManagementApp.Model;
using JobsManagementApp.View.Share;
using System.Windows;
using MySql.Data.MySqlClient;
using JobsManagementApp.ViewModel.AdminModel;
using System.Collections.ObjectModel;
using System.Xml.Linq;

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
        public async Task< ObservableCollection<JobsDTO> >GetAllJob()
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
        public async Task<ObservableCollection<JobsDTO>> GetAllJobByAssigneeID(string? userType, int assigneeID)
        {
            ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM JOB WHERE ASSIGNEE_TYPE = '" + userType + "' AND ASSIGNEE_ID = " + assigneeID + " ";
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
        public async Task<ObservableCollection<JobsDTO>> GetAllRelateJobByUserID(string? userType, int userID)
        {
            ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM JOB WHERE (ASSIGNEE_TYPE = '" + userType + "' AND ASSIGNEE_ID = " + userID + ") OR ( ASSIGNOR_TYPE = '" + userType + "' AND ASSIGNOR_ID = " + userID + ")";
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
        public async Task<JobsDTO> GetJobByJobId(int jobId)
        {
            JobsDTO Job = new JobsDTO();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM JOB WHERE ID = " + jobId + " ";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            if (reader.Read())
            {

                Job =    new JobsDTO(
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
                    );
            }
            dbc.connection.Close();
            return Job;
        }
        public async Task<(bool, string)> AddJob(JobsDTO j)
        {
            try
            {
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE, DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT, STAGE, ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME)" 
                    + " VALUES(" + j.dependency_id
                    + ",'" + j.dependency_name + "','"+ j.name+"','" +j.description +"','"+ j.category + "','" + j.start_date+"','"+j.due_date+ "','"+j.end_date + "'," +j.required_hour 
                    + ","+j.worked_hour + "," +j.percent+ ",'" + j.stage + "'," + j.assignor_id+",'" + j.assignor_type + "','" + j.assignor_name +"'," + j.assignee_id + ",'" + j.assignee_type + "','" + j.assignee_name + "')";
                dbc1.command.CommandText = code1;
                dbc1.connection.Open();
                dbc1.command.ExecuteNonQuery();
                dbc1.connection.Close();

                return (true, "Insert Success");
            }
            catch (Exception)
            {
                return (false, "Database Error");
            }
        }
        public async Task<ObservableCollection<JobsDTO>> GetAllAssignedJob()
        {
            ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM JOB WHERE ASSIGNEE_NAME != 'NONE'  ";
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
        public async Task<ObservableCollection<Assignee_AssignorDTO>> GetAssignee()
        {
            ObservableCollection<Assignee_AssignorDTO> Assignees = new ObservableCollection<Assignee_AssignorDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM USER";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                Assignees.Add(
                    new Assignee_AssignorDTO(
                    (int)reader["ID"],
                    "USER",
                    (string)reader["NAME"]
                    ));
            }
            dbc.connection.Close();

            DatabaseConnection dbc1 = new DatabaseConnection();
            string code1 = "";
            MySqlDataReader reader1;

            code1 = "SELECT * FROM ADMIN";
            dbc1.command.CommandText = code1;
            dbc1.connection.Open();
            reader1 = dbc1.command.ExecuteReader();
            while (reader1.Read())
            {
                Assignees.Add(
                    new Assignee_AssignorDTO(
                    (int)reader1["ID"],
                    "ADMIN",
                    (string)reader1["NAME"]
                    ));
            }
            dbc1.connection.Close();
            return Assignees;
        }
        public async Task<(bool, string)> DeleteJob(int id)
        {
            try
            {
                ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "DELETE FROM JOB WHERE ID = @id";
                dbc1.command.CommandText = code1;
                dbc1.command.Parameters.AddWithValue("@id", id);
                dbc1.connection.Open();
                dbc1.command.ExecuteNonQuery();
                dbc1.connection.Close();
                DatabaseConnection dbc2 = new DatabaseConnection();
                string code2 = "";
                code2 = "DELETE FROM REPORT WHERE JOB_ID = @id";
                dbc2.command.CommandText = code2;
                dbc2.command.Parameters.AddWithValue("@id", id);
                dbc2.connection.Open();
                dbc2.command.ExecuteNonQuery();
                dbc2.connection.Close();

                return (true, "Delete Success");
            }
            catch (Exception)
            {
                return (false, "Database Error");
            }
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
                list.Add((string)reader["ASSIGNOR_TYPE"] + "-" + (string)reader["ASSIGNOR_NAME"]);
            }
            return list;
        }
        public List<string> InsertAssignorComboboxByUserID(int id)
        {
            List<string> list = new List<string>();
            ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT DISTINCT ASSIGNOR_TYPE, ASSIGNOR_NAME FROM JOB  WHERE ASSIGNEE_TYPE = 'USER' AND ASSIGNEE_ID = " + id + "  ORDER BY ASSIGNOR_TYPE ASC";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                list.Add((string)reader["ASSIGNOR_TYPE"] + "-" + (string)reader["ASSIGNOR_NAME"]);
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
                list.Add((string)reader["ASSIGNEE_TYPE"] + "-" + (string)reader["ASSIGNEE_NAME"]);
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
        public List<string> InsertDependencyComboboxByUserID(int id)
        {
            List<string> list = new List<string>();
            ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT DISTINCT DEPENDENCY_NAME FROM JOB WHERE DEPENDENCY_ID != -1 AND DEPENDENCY_NAME != 'NONE' AND ASSIGNEE_TYPE = 'USER' AND ASSIGNEE_ID = " + id + " ORDER BY DEPENDENCY_NAME ASC";
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
