using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seisapp
{
    internal class Database
    {
        public static string PATH = "";
        public const string SETTINGS_TABLENAME = "settings";
        public const string VELOCITY_TABLENAME = "velocity";
        public const string STATION_COORDINATES_TABLENAME = "station_coordinates";

        public const string TABLE_STATION_CREATING_COMMAND = "CREATE TABLE " + STATION_COORDINATES_TABLENAME + "(number INTEGER NOT NULL, x DOUBLE NOT NULL, y DOUBLE NOT NULL, altitude DOUBLE NOT NULL)";
        public const string TABLE_VELOCITY_CREATING_COMMAND = "CREATE TABLE " + VELOCITY_TABLENAME + "(h_top DOUBLE NOT NULL, h_bottom DOUBLE NOT NULL, vp DOUBLE NOT NULL)";
        public const string TABLE_SETTINGS_CREATING_COMMAND = "CREATE TABLE " + SETTINGS_TABLENAME + "(ip VARCHAR(30) NOT NULL, port INTEGER NOT NULL)";

        static public void create_table(string name) 
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;                
                command.CommandText = "CREATE TABLE " + name + "()";
                command.ExecuteNonQuery();                
            }
        }
        static public void create_table()
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = TABLE_SETTINGS_CREATING_COMMAND;
                command.ExecuteNonQuery();
                command.CommandText = TABLE_STATION_CREATING_COMMAND;
                command.ExecuteNonQuery();
                command.CommandText = TABLE_VELOCITY_CREATING_COMMAND;
                command.ExecuteNonQuery();
            }
        }        
        static private void add_row_in_table_velocity(double h_top, double h_bottom, double vp)
        {
            string sh_top = Convert.ToString(h_top);
            string sh_bottom = Convert.ToString(h_bottom);
            string svp = Convert.ToString(vp);

            using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO " + VELOCITY_TABLENAME + " (h_top, h_bottom, vp) VALUES (" + sh_top + ", " + sh_bottom + ", " + svp + ")";
                command.ExecuteNonQuery();
            }
        }
        static private void add_row_in_table_station_coordinates(int number, double x, double y, double altitude)
        {
            string snumber = Convert.ToString(number);            
            string sx = Convert.ToString(x);
            string sy = Convert.ToString(y);
            string saltitude = Convert.ToString(altitude);

            using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO " + STATION_COORDINATES_TABLENAME + " (number, x, y, altitude) VALUES (" + snumber + ", " + sx + ", " + sy + ", " + saltitude + ")";
                command.ExecuteNonQuery();
            }
        }
        static public void refresh_row_in_table_settings(string ip, int port)
        {
            string sport = Convert.ToString(port);
            using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
            {                
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM " + SETTINGS_TABLENAME;                
                if (Convert.ToInt32(command.ExecuteScalar()) != 0)
                {
                    clear_table(SETTINGS_TABLENAME);
                }
                command.CommandText = "INSERT INTO " + SETTINGS_TABLENAME + " (ip, port) VALUES ('" + ip + "', " + sport + ")";
                command.ExecuteNonQuery();
            }
        }
        static public void add_column(string table_name, string column_name, string column_parameters)
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "ALTER TABLE " + table_name + " ADD COLUMN " + column_name + " " + column_parameters + ";";
                command.ExecuteNonQuery();
            }
        }
        static public void clear_table(string table_name)
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection.Open();
                SqliteCommand command_del = new SqliteCommand("DELETE  FROM " + table_name, connection);
                command_del.ExecuteNonQuery(); ;
            }
        }
    }
}
