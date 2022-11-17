using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows;
using JobsManagementApp.Model;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using JobsManagementApp.View.Share;

namespace JobsManagementApp.Service
{
    public class OrganizationAndPositionService
    {
        public OrganizationAndPositionService()
        {

        }

        private static OrganizationAndPositionService? _ins;
        public static OrganizationAndPositionService? Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new OrganizationAndPositionService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        public async Task<ObservableCollection<OrganizationsDTO>> GetAllOrganization()
        {
            ObservableCollection<OrganizationsDTO> Organs = new ObservableCollection<OrganizationsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM ORGANIZATION";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                Organs.Add(
                    new OrganizationsDTO(
                    (string)reader["NAME"]
                    ));
            }
            dbc.connection.Close();
            return Organs;
        }
        public async Task<ObservableCollection<PositionsDTO>> GetAllPositionByOrganName(string? organization)
        {
            ObservableCollection<PositionsDTO> Positions = new ObservableCollection<PositionsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM ORGANIZATION_POSITION WHERE ORGANIZATION_NAME = '" + organization + "'";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                Positions.Add(
                    new PositionsDTO(
                    (string)reader["ORGANIZATION_NAME"],
                    (string)reader["NAME"]
                    ));
            }
            dbc.connection.Close();
            return Positions;
        }
        public List<string> InsertOrganizationCombobox()
        {
            List<string> list = new List<string>();
            ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT *  FROM ORGANIZATION";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                list.Add((string)reader["NAME"]);
            }
            return list;
        }
        public List<string> InsertPositionCombobox(string organization_s)
        {
            List<string> list = new List<string>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT *  FROM ORGANIZATION_POSITION WHERE ORGANIZATION_NAME = '" + organization_s + "'";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                list.Add((string)reader["NAME"]);
            }

            dbc.connection.Close();
            return list;
        }
        public async Task<(bool, string)> InsertOrganization(string oname)
        {
            try
            {
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "INSERT INTO ORGANIZATION(NAME) VALUES('" + oname + "')";
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
        public async Task<(bool, string)> DeleteOrganization(string s)
        {
            try
            {
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "DELETE FROM ORGANIZATION WHERE NAME = '" + s + "'";
                dbc1.command.CommandText = code1;
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
        public async Task<(bool, string)> InsertPosition(string oname,string pname)
        {
            try
            {
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "INSERT INTO ORGANIZATION_POSITION(ORGANIZATION_NAME,NAME) VALUES('" + oname + "','" + pname + "')";
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
        public async Task<(bool, string)> DeletePosition(string oname, string pname)
        {
            try
            {
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "DELETE FROM ORGANIZATION_POSITION WHERE ORGANIZATION_NAME = '" + oname + "' AND NAME = '" + pname + "'";
                dbc1.command.CommandText = code1;
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
    }
}
