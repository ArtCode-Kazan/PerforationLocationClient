using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seisapp
{
    internal class Database
    {
        public static string path = "";
        public static string SETTINGS = "settings";
        public static string VELOCITY = "velocity";
        public static string STATION_COORDINATES = "station_coordinates";

        public void create_table(string name) 
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;                
                command.CommandText = "CREATE TABLE " + name + "()";
                command.ExecuteNonQuery();                
            }
        }
        public void create_table_users()
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "CREATE TABLE Users(_number INTEGER NOT NULL, x DOUBLE NOT NULL, y DOUBLE NOT NULL, altitude DOUBLE NOT NULL)";
                command.ExecuteNonQuery();                
            }
        }
        public void create_table_velocity()
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "CREATE TABLE " + VELOCITY + "(h_top DOUBLE NOT NULL, h_bottom DOUBLE NOT NULL, vp DOUBLE NOT NULL)";
                command.ExecuteNonQuery();
            }
        }
        public void create_table_settings()
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "CREATE TABLE " + SETTINGS + "(ip VARCHAR(30) NOT NULL, port INTEGER NOT NULL)";
                command.ExecuteNonQuery();
            }
        }
        private void add_row_in_table_settings(string ip, int port)
        {
            string sport = Convert.ToString(port);
            using (var connection = new SqliteConnection("Data Source=" + Database.path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO " + SETTINGS + " (ip, port) VALUES ('" + ip + "', " + sport + ")";
                command.ExecuteNonQuery();
            }
        }
        private void add_row_in_table_velocity(double h_top, double h_bottom, double vp)
        {
            string sh_top = Convert.ToString(h_top);
            string sh_bottom = Convert.ToString(h_bottom);
            string svp = Convert.ToString(vp);

            using (var connection = new SqliteConnection("Data Source=" + Database.path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO " + VELOCITY + " (h_top, h_bottom, vp) VALUES (" + sh_top + ", " + sh_bottom + "," + svp + ")";
                command.ExecuteNonQuery();
            }
        }
        public void refresh_row_in_table_settings(string ip, int port)
        {

            clear_table(SETTINGS);
            add_row_in_table_settings(ip, port);
        }
        public void add_column(string table_name, string column_name, string column_parameters)
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "ALTER TABLE " + table_name + " ADD COLUMN " + column_name + " " + column_parameters + ";";
                command.ExecuteNonQuery();
            }
        }
        public void clear_table(string table_name)
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.path))
            {
                connection.Open();
                SqliteCommand command_del = new SqliteCommand("DELETE  FROM " + table_name, connection);
                command_del.ExecuteNonQuery(); ;
            }
        }
    }
}
