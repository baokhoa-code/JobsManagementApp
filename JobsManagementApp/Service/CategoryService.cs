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
    public class CategoryService
    {
        public CategoryService()
        {

        }
        private static CategoryService? _ins;
        public static CategoryService? Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CategoryService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        public List<string> InsertCombobox()
        {
            List<string> combobox = new List<string>();
            ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM CATEGORY";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                combobox.Add((string)reader["NAME"]);
            }
            return combobox;
        }
    }
}
