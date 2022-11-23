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
        public const string PARAMETERS_TABLENAME = "parameters";

        public const string TABLE_STATION_CREATING_COMMAND = "CREATE TABLE " + STATION_COORDINATES_TABLENAME + "(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, number INTEGER NOT NULL, x DOUBLE NOT NULL, y DOUBLE NOT NULL, altitude DOUBLE NOT NULL)";
        public const string TABLE_VELOCITY_CREATING_COMMAND = "CREATE TABLE " + VELOCITY_TABLENAME + "(h_top DOUBLE NOT NULL, h_bottom DOUBLE NOT NULL, vp DOUBLE NOT NULL)";
        public const string TABLE_SETTINGS_CREATING_COMMAND = "CREATE TABLE " + SETTINGS_TABLENAME + "(ip VARCHAR(30) NOT NULL, port INTEGER NOT NULL)";
        public const string TABLE_SEISMIC_RECORDS_CREATING_COMMAND = "CREATE TABLE " + SEISMIC_RECORDS_TABLENAME + "(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, station_id INTEGER NOT NULL, root VARCHAR(140) NOT NULL, file_name VARCHAR(45) NOT NULL, datetime_start VARCHAR(45) NOT NULL, datetime_stop VARCHAR(45) NOT NULL, FOREIGN KEY (station_id) REFERENCES station_coordinates (id), CONSTRAINT UNIQUE_FIELDS UNIQUE (file_name, root))";
        public const string TABLE_PARAMETERS_CREATING_COMMAND = "CREATE TABLE " + PARAMETERS_TABLENAME + "(datetime_graph_start VARCHAR(45) NOT NULL, datetime_graph_stop VARCHAR(45) NOT NULL, component VARCHAR(1) NOT NULL, furier_min_freq DOUBLE NOT NULL, furier_max_freq DOUBLE NOT NULL, stalta_min_window DOUBLE NOT NULL, stalta_max_window DOUBLE NOT NULL, stalta_order INTEGER NOT NULL)";

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
                command.CommandText = TABLE_PARAMETERS_CREATING_COMMAND;
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
        static public void add_row_in_table_station_coordinates(
            int number,
            double x,
            double y,
            double altitude
        )
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
        static public void add_row_in_table_seismic_records(
            int station_id,
            string file_name,
            string root,
            DateTime datetime_start,
            DateTime datetime_stop
        )
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
        static public void refresh_row_in_table_parameters(
            string datetime_graph_start,
            string datetime_graph_stop,
            string component,
            double furier_min_freq,
            double furier_max_freq,
            double stalta_min_window,
            double stalta_max_window,
            int stalta_order)
        {
            string sfurier_min_freq = Convert.ToString(furier_min_freq);
            string sfurier_max_freq = Convert.ToString(furier_max_freq);
            string sstalta_min_window = Convert.ToString(stalta_min_window);
            string sstalta_max_window = Convert.ToString(stalta_max_window);
            string sstalta_order = Convert.ToString(stalta_order);
            using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM " + PARAMETERS_TABLENAME;
                if (Convert.ToInt32(command.ExecuteScalar()) != 0)
                {
                    clear_table(PARAMETERS_TABLENAME);
                }
                command.CommandText = "INSERT INTO " + PARAMETERS_TABLENAME + " (datetime_graph_start, datetime_graph_stop, component, furier_min_freq, furier_max_freq, stalta_min_window, stalta_max_window, stalta_order) VALUES ('" + datetime_graph_start + "', '" + datetime_graph_stop + "', '" + component + "', " + sfurier_min_freq + ", " + sfurier_max_freq + ", " + sstalta_min_window + ", " + sstalta_max_window + ", " + sstalta_order + ")";
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
            string[,] array = new string[get_amount_rows_seismic_records(), 6];

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
                            string id = Convert.ToString(reader.GetValue(0));
                            string station_id = Convert.ToString(reader.GetValue(1));
                            string root = Convert.ToString(reader.GetValue(2));
                            string file_name = Convert.ToString(reader.GetValue(3));
                            string datatime_start = Convert.ToString(reader.GetValue(4));
                            string datatime_stop = Convert.ToString(reader.GetValue(5));

                            array[i, 0] = id;
                            array[i, 1] = station_id;
                            array[i, 2] = root;
                            array[i, 3] = file_name;
                            array[i, 4] = datatime_start;
                            array[i, 5] = datatime_stop;

                            i++;
                        }
                    }
                }
            }
            return array;
        }
        static public dynamic get_parameters(int column_number = 0)
        {
            string datetime_graph_start = "";
            string datetime_graph_stop = "";
            string component = "";
            double furier_min_freq = 0;
            double furier_max_freq = 0;
            double stalta_min_window = 0;
            double stalta_max_window = 0;
            int stalta_order = 0;
            using (var connection_out = new SqliteConnection("Data Source=" + PATH))
            {
                connection_out.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection_out;
                command.CommandText = "SELECT * FROM " + PARAMETERS_TABLENAME;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            datetime_graph_start = Convert.ToString(reader.GetValue(0));
                            datetime_graph_stop = Convert.ToString(reader.GetValue(1));
                            component = Convert.ToString(reader.GetValue(2));
                            furier_min_freq = Convert.ToDouble(reader.GetValue(3));
                            furier_max_freq = Convert.ToDouble(reader.GetValue(4));
                            stalta_min_window = Convert.ToDouble(reader.GetValue(5));
                            stalta_max_window = Convert.ToDouble(reader.GetValue(6));
                            stalta_order = Convert.ToInt32(reader.GetValue(7));
                        }
                    }
                }
            }
            if (column_number == 1)
            { 
                return datetime_graph_start; 
            }
            else if (column_number == 2)
            { 
                return datetime_graph_stop; 
            }
            else if (column_number == 3)
            { 
                return component; 
            }
            else if (column_number == 4)
            { 
                return furier_min_freq; 
            }
            else if (column_number == 5)
            { 
                return furier_max_freq; 
            }
            else if (column_number == 6)
            { 
                return stalta_min_window; 
            }
            else if (column_number == 7)
            { 
                return stalta_max_window; 
            }
            else if (column_number == 8)
            {
                return stalta_order;
            }
            else
            {
                return (datetime_graph_start,
                    datetime_graph_stop,
                    component,
                    furier_min_freq,
                    furier_max_freq,
                    stalta_min_window,
                    stalta_max_window,
                    stalta_order);
            }
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
