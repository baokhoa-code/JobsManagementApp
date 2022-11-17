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
    public class UserService
    {
        public UserService()
        {

        }

        private static UserService? _ins;
        public static UserService? Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new UserService();
                }
                return _ins;
            }
            private set => _ins = value;
        }

        public async Task<(bool, string)> DeleteUser(int id)
        {
            try
            {
                ObservableCollection<JobsDTO> Jobs = new ObservableCollection<JobsDTO>();
                DatabaseConnection dbc1 = new DatabaseConnection();
                string code1 = "";
                code1 = "DELETE FROM USER WHERE ID = @id";
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
        public (UsersDTO?, string?) Login(string username, string password)
        {
            UsersDTO? user = null;
            string message = "";
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM USER WHERE USERNAME=@username";
            dbc.command.CommandText = code;
            dbc.command.Parameters.AddWithValue("@username", username);

            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string? r_pass = reader["PASS"].ToString();
                if (password.Equals(r_pass))
                {
                    user = new UsersDTO(Int16.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9),
                        reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), Int16.Parse(reader.GetString(15)));
                    message = "Login Success";
                    dbc.connection.Close();
                }
                else
                {
                    user = null;
                    message = "Your password is inconrect";
                    dbc.connection.Close();
                }

            }
            else
            {
                user = null;
                message = "Your username is not exist";
                dbc.connection.Close();
            }


            return (user, message);
        }
        public async Task<ObservableCollection<UsersDTO>> GetAllUser()
        {
            ObservableCollection<UsersDTO> Users = new ObservableCollection<UsersDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM USER";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                Users.Add(
                    new UsersDTO(Int16.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9),
                        reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), Int16.Parse(reader.GetString(15))));
            }
            dbc.connection.Close();
            return Users;
        }
        public  ObservableCollection<UsersDTO> GetAllUser1()
        {
            ObservableCollection<UsersDTO> Users = new ObservableCollection<UsersDTO>();
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

            code = "SELECT * FROM USER";
            dbc.command.CommandText = code;
            dbc.connection.Open();
            reader = dbc.command.ExecuteReader();
            while (reader.Read())
            {
                Users.Add(
                    new UsersDTO(Int16.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9),
                        reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), Int16.Parse(reader.GetString(15))));
            }
            dbc.connection.Close();
            return Users;
        }

    }
}
