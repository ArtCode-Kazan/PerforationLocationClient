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
                command.CommandText = "CREATE TABLE velocity(h_top DOUBLE NOT NULL, h_bottom DOUBLE NOT NULL, vp DOUBLE NOT NULL)";
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
                command.CommandText = "CREATE TABLE settings(ip VARCHAR(30) NOT NULL, port INTEGER NOT NULL)";
                command.ExecuteNonQuery();
            }
        }        
        public void add_row_in_table_setting(string table_name, string column_name, string column_parameters)
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO settings (ip, port) VALUES ('" + ip + "', " + port + ")";
                command.ExecuteNonQuery();
            }        
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
        public void clear_table(string table_name, string column_name, string column_parameters)
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.path))
            {
                connection.Open();
                SqliteCommand command_del = new SqliteCommand("DELETE  FROM velocity", connection);
                command_del.ExecuteNonQuery(); ;
            }
        }
    }
}
