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
    }
}