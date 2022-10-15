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

namespace JobsManagementApp.Service
{
    public class AdminService
    {
        public AdminService()
        {

        }

        private static AdminService? _ins;
        public static AdminService? Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new AdminService();
                }
                return _ins;
            }
            private set => _ins = value;
        }

        public (Admin?, string?) Login(string username, string password)
        {
            Admin? admin = null;
            string message = "";
            DatabaseConnection dbc = new DatabaseConnection();
            string code = "";
            MySqlDataReader reader;

                code = "SELECT * FROM ADMIN WHERE USERNAME=@username";
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
                        admin = new Admin(Int16.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9),
                            reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13));
                        message = "Login Success";
                        dbc.connection.Close();
                    }
                    else
                    {
                        admin = null;
                        message = "Your password is inconrect";
                        dbc.connection.Close();
                    }

            }
            else
            {
                admin = null;
                message = "Your username is not exist";
                dbc.connection.Close();
            }


            return (admin, message);
        }

    }
}
