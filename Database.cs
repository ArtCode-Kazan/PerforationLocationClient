using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
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
        public const string SEISMIC_RECORDS_TABLENAME = "seismic_records";

        public const string TABLE_STATION_CREATING_COMMAND = "CREATE TABLE " + STATION_COORDINATES_TABLENAME + "(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, number INTEGER NOT NULL, x DOUBLE NOT NULL, y DOUBLE NOT NULL, altitude DOUBLE NOT NULL)";
        public const string TABLE_VELOCITY_CREATING_COMMAND = "CREATE TABLE " + VELOCITY_TABLENAME + "(h_top DOUBLE NOT NULL, h_bottom DOUBLE NOT NULL, vp DOUBLE NOT NULL)";
        public const string TABLE_SETTINGS_CREATING_COMMAND = "CREATE TABLE " + SETTINGS_TABLENAME + "(ip VARCHAR(30) NOT NULL, port INTEGER NOT NULL)";
        public const string TABLE_SEISMIC_RECORDS_CREATING_COMMAND = "CREATE TABLE " + SEISMIC_RECORDS_TABLENAME + "(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, station_id INTEGER NOT NULL, root VARCHAR(140) NOT NULL, file_name VARCHAR(45) NOT NULL, datetime_start VARCHAR(45) NOT NULL, datetime_stop VARCHAR(45) NOT NULL, FOREIGN KEY (station_id) REFERENCES station_coordinates (id), CONSTRAINT UNIQUE_FIELDS UNIQUE (file_name, root))";        

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
                command.CommandText = TABLE_SEISMIC_RECORDS_CREATING_COMMAND;
                command.ExecuteNonQuery();               
            }
        }        
        static public void add_row_in_table_velocity(double h_top, double h_bottom, double vp)
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
        static public void add_row_in_table_station_coordinates(int number, double x, double y, double altitude)
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
        static public void add_row_in_table_seismic_records(int station_id, string file_name, string root, DateTime datetime_start, DateTime datetime_stop)
        {
            string sid = Convert.ToString(station_id);
            string sdatetime_start = datetime_start.ToString();
            string sdatetime_stop = datetime_stop.ToString();

            using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO " + SEISMIC_RECORDS_TABLENAME + " (station_id, file_name, root, datetime_start, datetime_stop) VALUES (" + sid + ", '" + file_name + "', '" + root + "', '" + sdatetime_start + "', '" + sdatetime_stop + "')";
                command.ExecuteNonQuery();
            }
        }
        static public void refresh_row_in_table_settings(string ip, int port)
        {            
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
                command.CommandText = "INSERT INTO " + SETTINGS_TABLENAME + " (ip, port) VALUES ('" + ip + "', " + Convert.ToString(port) + ")";
                command.ExecuteNonQuery();
            }
        }
        static public double[,] get_velocity()
        {
            double[,] array = new double[get_amount_rows_velocity(), 3];

            using (var connection_out = new SqliteConnection("Data Source=" + Database.PATH))
            {
                int i = 0;
                connection_out.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection_out;
                command.CommandText = "SELECT * FROM " + VELOCITY_TABLENAME;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var h_top = Convert.ToDouble(reader.GetValue(0));
                            var h_bottom = Convert.ToDouble(reader.GetValue(1));
                            var vp = Convert.ToDouble(reader.GetValue(2));
                            array[i, 0] = h_top;
                            array[i, 1] = h_bottom;
                            array[i, 2] = vp;
                            i++;
                        }
                    }
                }
            }
            return array;
        }
        static public double[,] get_stations()
        {
            double[,] array = new double[get_amount_rows_station_coordinates(), 4];

            using (var connection_out = new SqliteConnection("Data Source=" + Database.PATH))
            {
                int i = 0;
                connection_out.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection_out;
                command.CommandText = "SELECT * FROM " + STATION_COORDINATES_TABLENAME;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var number = Convert.ToDouble(reader.GetValue(0));
                            var x = Convert.ToDouble(reader.GetValue(1));
                            var y = Convert.ToDouble(reader.GetValue(2));
                            var altitude = Convert.ToDouble(reader.GetValue(3));
                            array[i, 0] = number;
                            array[i, 1] = x;
                            array[i, 2] = y;
                            array[i, 3] = altitude;
                            i++;
                        }
                    }
                }
            }
            return array;
        }
        static public string[,] get_seismic_records()
        {
            string[,] array = new string[get_amount_rows_seismic_records(), 3];

            using (var connection_out = new SqliteConnection("Data Source=" + PATH))
            {
                int i = 0;
                connection_out.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection_out;
                command.CommandText = "SELECT * FROM " + SEISMIC_RECORDS_TABLENAME;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            string number = Convert.ToString(reader.GetValue(1));
                            string x = Convert.ToString(reader.GetValue(2));
                            string y = Convert.ToString(reader.GetValue(3));                            
                            array[i, 0] = number;
                            array[i, 1] = x;
                            array[i, 2] = y;                            
                            i++;
                        }
                    }
                }
            }
            return array;
        }
        static public int get_amount_rows_velocity()
        {
            using (var connection_out = new SqliteConnection("Data Source=" + Database.PATH))
            {                
                connection_out.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection_out;
                command.CommandText = "SELECT COUNT(*) FROM " + Database.VELOCITY_TABLENAME;                                                            
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        static public int get_amount_rows_station_coordinates()
        {
            using (var connection_out = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection_out.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection_out;
                command.CommandText = "SELECT COUNT(*) FROM " + STATION_COORDINATES_TABLENAME;
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        static public int get_amount_rows_seismic_records()
        {
            using (var connection_out = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection_out.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection_out;
                command.CommandText = "SELECT COUNT(*) FROM " + SEISMIC_RECORDS_TABLENAME;
                return Convert.ToInt32(command.ExecuteScalar());
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
            using (var connection = new SqliteConnection("Data Source=" + PATH))
            {
                connection.Open();
                SqliteCommand command_del = new SqliteCommand("DELETE  FROM " + table_name, connection);
                command_del.ExecuteNonQuery(); ;
            }
        }
    }
}
