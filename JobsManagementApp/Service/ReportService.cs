using JobsManagementApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsManagementApp.Service
{
    public class ReportService
    {
        public ReportService()
        {

        }

        private static ReportService? _ins;
        public static ReportService? Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ReportService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        public ReportsDTO GetLatestReport()
        {
            ReportsDTO report = null;
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT* FROM REPORT WHERE ID = (SELECT MAX(ID) FROM REPORT)";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            if (reader.Read())
            {

                report = new ReportsDTO(
                        (int)reader["ID"],
                        (int)reader["JOB_ID"],
                        (string)reader["JOB_NAME"],
                        (string)reader["TILE"],
                        (string)reader["DESCRIPTION"],
                        (string)reader["CREATED_TIME"]
                        );
            }
            dbc.connection.Close();
            return report;
        }
        public async Task<(bool, string)> DeleteReport(int id)
        {
            try
            {
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "DELETE FROM REPORT WHERE ID = @id";
                dbc1.command.CommandText = code1;
                dbc1.command.Parameters.AddWithValue("@id", id);
                dbc1.connection.Open();
                dbc1.command.ExecuteNonQuery();
                dbc1.connection.Close();

                return (true, "Delete Success");
            }
            catch (Exception)
            {
                return (false, "Database Error");

            }
        }
        public async Task<ObservableCollection<ReportsDTO>> GetAllReport()
        {
            ObservableCollection<ReportsDTO> Reports = new ObservableCollection<ReportsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM REPORT";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                Reports.Add(
                    new ReportsDTO(
                        (int)reader["ID"],
                        (int)reader["JOB_ID"],
                        (string)reader["JOB_NAME"],
                        (string)reader["TILE"],
                        (string)reader["DESCRIPTION"],
                        (string)reader["CREATED_TIME"]
                        ));
            }
            dbc.connection.Close();
            return Reports;
        }
        public async Task<(bool, string)> UpdateReport(ReportsDTO report)
        {
            try
            {
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "UPDATE REPORT SET TILE = '" + report.tile + "', DESCRIPTION = '" + report.description + "', CREATED_TIME = '" + report.created_time + "' WHERE ID = " + report.id + " ";
                dbc1.command.CommandText = code1;
                dbc1.connection.Open();
                dbc1.command.ExecuteNonQuery();
                dbc1.connection.Close();

                return (true, "Update Success");
            }
            catch (Exception)
            {
                return (false, "Database Error");
            }
        }
        public async Task<(bool, string)> AddReport(ReportsDTO r)
        {
            try
            {
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "INSERT INTO REPORT(JOB_ID, JOB_NAME, TILE, DESCRIPTION, CREATED_TIME) VALUES(" + r.job_id
                    + ",'" + r.job_name + "','" + r.tile + "','" + r.description + "','" + r.created_time + "')";
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
        public async Task<ObservableCollection<ReportsDTO>> GetAllReportByAssigneeID(string? userType, int assigneeID)
        {
            ObservableCollection<ReportsDTO> Reports = new ObservableCollection<ReportsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM REPORT JOIN JOB ON REPORT.JOB_ID = JOB.ID WHERE ASSIGNEE_TYPE = '" + userType + "' AND ASSIGNEE_ID = " + assigneeID + " ";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                Reports.Add(
                    new ReportsDTO(
                        (int)reader["ID"],
                        (int)reader["JOB_ID"],
                        (string)reader["JOB_NAME"],
                        (string)reader["TILE"],
                        (string)reader["DESCRIPTION"],
                        (string)reader["CREATED_TIME"]
                        ));
            }
            dbc.connection.Close();
            return Reports;
        }
        public async Task<ObservableCollection<ReportsDTO>> GetAllReportByUserID(string? userType, int userID)
        {
            ObservableCollection<ReportsDTO> Reports = new ObservableCollection<ReportsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM REPORT JOIN JOB ON REPORT.JOB_ID = JOB.ID WHERE (ASSIGNEE_TYPE = '" + userType + "' AND ASSIGNEE_ID = " + userID + " ) OR (ASSIGNOR_TYPE = '" + userType + "' AND ASSIGNOR_ID = " + userID + " )";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                Reports.Add(
                    new ReportsDTO(
                        (int)reader["ID"],
                        (int)reader["JOB_ID"],
                        (string)reader["JOB_NAME"],
                        (string)reader["TILE"],
                        (string)reader["DESCRIPTION"],
                        (string)reader["CREATED_TIME"]
                        ));
            }
            dbc.connection.Close();
            return Reports;
        }
        public async Task<ObservableCollection<ReportsDTO>> GetAllReportByJobID(int jobID)
        {
            ObservableCollection<ReportsDTO> Reports = new ObservableCollection<ReportsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM REPORT WHERE JOB_ID = " + jobID + " ";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                Reports.Add(
                    new ReportsDTO(
                        (int)reader["ID"],
                        (int)reader["JOB_ID"],
                        (string)reader["JOB_NAME"],
                        (string)reader["TILE"],
                        (string)reader["DESCRIPTION"],
                        (string)reader["CREATED_TIME"]
                        ));
            }
            dbc.connection.Close();
            return Reports;
        }
        public ReportsDTO GetReport(int reportId)
        {
            ReportsDTO Report = null;
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM REPORT WHERE ID = " + reportId + " ";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            if (reader.Read())
            {

                Report = new ReportsDTO(
                        (int)reader["ID"],
                        (int)reader["JOB_ID"],
                        (string)reader["JOB_NAME"],
                        (string)reader["TILE"],
                        (string)reader["DESCRIPTION"],
                        (string)reader["CREATED_TIME"]
                        );
            }
            dbc.connection.Close();
            return Report;
        }
    }
}