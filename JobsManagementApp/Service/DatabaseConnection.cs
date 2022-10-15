using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace JobsManagementApp.Service
{
    public class DatabaseConnection
    {
        public MySqlConnection connection;
        public MySqlCommand command;
        string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=job";

        public DatabaseConnection()
        {
            connection = new MySqlConnection(MySQLConnectionString);
            command = new MySqlCommand();
            command.Connection = connection;
        }
    }
}
