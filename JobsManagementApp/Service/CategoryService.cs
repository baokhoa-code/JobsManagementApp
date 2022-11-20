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
        public async Task<ObservableCollection<CategoriesDTO>> GetAllCategory()
        {
            ObservableCollection<CategoriesDTO> Categories = new ObservableCollection<CategoriesDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM CATEGORY";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                Categories.Add(
                    new CategoriesDTO(
                        (string)reader["NAME"]
                    ));
            }
            dbc.connection.Close();
            return Categories;
        }
        public async Task<(bool, string)> InsertCategory(string cname)
        {
            try
            {
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "INSERT INTO CATEGORY(NAME) VALUES('" + cname + "')";
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
        public async Task<(bool, string)> DeleteCategory(string s)
        {
            try
            {
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "DELETE FROM CATEGORY WHERE NAME = '" + s + "'";
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
