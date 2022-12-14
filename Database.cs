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
        public static string Path = "";
        public const string StationCoordinatesTableName = "station_coordinates";
        public const string SeismicRecordsTableName = "seismic_records";
        public const string VelocityTableName = "velocity";
        public const string CalibrationExplosionTableName = "calibration_explosion";
        public const string SettingsTableName = "settings";        
        public const string ParametersTableName = "parameters";
        public const string LatencyTableName = "latency";
        public const string StaticCorrectionsTableName = "static_corrections";

        public const string TableStationCoordinatesCreatingCommand = "CREATE TABLE " + StationCoordinatesTableName + "(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, number INTEGER NOT NULL, x DOUBLE NOT NULL, y DOUBLE NOT NULL, altitude DOUBLE NOT NULL)";
        public const string TableSeismicRecordsCreatingCommand = "CREATE TABLE " + SeismicRecordsTableName + "(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, station_id INTEGER NOT NULL, root VARCHAR(140) NOT NULL, file_name VARCHAR(45) NOT NULL, datetime_start VARCHAR(45) NOT NULL, datetime_stop VARCHAR(45) NOT NULL, FOREIGN KEY (station_id) REFERENCES station_coordinates (id), CONSTRAINT UNIQUE_FIELDS UNIQUE (file_name, root))";
        public const string TableVelocityCreatingCommand = "CREATE TABLE " + VelocityTableName + "(h_top DOUBLE NOT NULL, h_bottom DOUBLE NOT NULL, vp DOUBLE NOT NULL)";
        public const string TableCalibrationExplosionCreatingCommand = "CREATE TABLE " + CalibrationExplosionTableName + "(datetime_blow VARCHAR(45) NOT NULL, x DOUBLE NOT NULL, y DOUBLE NOT NULL, altitude DOUBLE NOT NULL)";
        public const string TableSettingsCreatingCommand = "CREATE TABLE " + SettingsTableName + "(ip VARCHAR(30) NOT NULL, port INTEGER NOT NULL)";        
        public const string TableParametersCreatingCommand = "CREATE TABLE " + ParametersTableName + "(datetime_graph_start VARCHAR(45) NOT NULL, datetime_graph_stop VARCHAR(45) NOT NULL, component VARCHAR(1) NOT NULL, furier_min_freq DOUBLE NOT NULL, furier_max_freq DOUBLE NOT NULL, stalta_min_window DOUBLE NOT NULL, stalta_max_window DOUBLE NOT NULL, stalta_order INTEGER NOT NULL)";
        public const string TableLatencyCreatingCommand = "CREATE TABLE " + LatencyTableName + "(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, station_id INTEGER NOT NULL, latency DOUBLE NOT NULL, FOREIGN KEY (station_id) REFERENCES station_coordinates (id))";
        public const string TableStaticCorrectionsCreatingCommand = "CREATE TABLE " + StaticCorrectionsTableName + "(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, station_id INTEGER NOT NULL, latency_correction DOUBLE NOT NULL, FOREIGN KEY (station_id) REFERENCES station_coordinates (id))";

        static public void CreateTable(string name)
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "CREATE TABLE " + name + "()";
                command.ExecuteNonQuery();
            }
        }
        static public void CreateTable()
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = TableStationCoordinatesCreatingCommand;
                command.ExecuteNonQuery();
                command.CommandText = TableSeismicRecordsCreatingCommand;
                command.ExecuteNonQuery();
                command.CommandText = TableVelocityCreatingCommand;
                command.ExecuteNonQuery();
                command.CommandText = TableCalibrationExplosionCreatingCommand;
                command.ExecuteNonQuery();
                command.CommandText = TableSettingsCreatingCommand;
                command.ExecuteNonQuery();
                command.CommandText = TableParametersCreatingCommand;
                command.ExecuteNonQuery();
                command.CommandText = TableLatencyCreatingCommand;
                command.ExecuteNonQuery();
                command.CommandText = TableStaticCorrectionsCreatingCommand;
                command.ExecuteNonQuery();
            }
        }
        static public void AddRowInVelocity(double hTop, double hBottom, double vp)
        {
            string stringHTop = Convert.ToString(hTop);
            string stringHBottom = Convert.ToString(hBottom);
            string stringVp = Convert.ToString(vp);

            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO " + VelocityTableName + " (h_top, h_bottom, vp) VALUES (" + stringHTop + ", " + stringHBottom + ", " + stringVp + ")";
                command.ExecuteNonQuery();
            }
        }
        static public void AddRowInStationCoordinates(
            int number,
            double x,
            double y,
            double altitude
        )
        {
            string stringNumber = Convert.ToString(number);
            string stringX = Convert.ToString(x).Replace(',', '.');
            string stringY = Convert.ToString(y).Replace(',', '.');
            string stringAltitude = Convert.ToString(altitude).Replace(',', '.');

            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO " + StationCoordinatesTableName + " (number, x, y, altitude) VALUES (" + stringNumber + ", " + stringX + ", " + stringY + ", " + stringAltitude + ")";
                command.ExecuteNonQuery();
            }
        }
        static public void AddRowInSeismicRecords(
            int stationId,
            string fileName,
            string root,
            DateTime datetimeStart,
            DateTime datetimeStop
        )
        {
            string stringStationId = Convert.ToString(stationId);
            string stringDatetimeStart = datetimeStart.ToString();
            string stringDatetimeStop = datetimeStop.ToString();

            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO " + SeismicRecordsTableName + " (station_id, file_name, root, datetime_start, datetime_stop) VALUES (" + stringStationId + ", '" + fileName + "', '" + root + "', '" + stringDatetimeStart + "', '" + stringDatetimeStop + "')";
                command.ExecuteNonQuery();
            }
        }
        static public void AddRowInLatency(int stationId, double latency)
        {
            string stringStationId = Convert.ToString(stationId);
            string stringLatency = Convert.ToString(latency).Replace(',', '.');
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO " + LatencyTableName + " (station_id, latency) VALUES (" + stringStationId + ", " + stringLatency + ")";
                command.ExecuteNonQuery();
            }
        }
        static public void AddRowInStaticCorrections(int stationId, double latencyCorrection)
        {
            string stringStationId = Convert.ToString(stationId);
            string stringLatencyCorrection = Convert.ToString(latencyCorrection).Replace(',', '.');
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO " + StaticCorrectionsTableName + " (station_id, latency_correction) VALUES (" + stringStationId + ", " + stringLatencyCorrection + ")";
                command.ExecuteNonQuery();
            }
        }
        static public void AddRowInCalibrationExplosion(DateTime datetimeBlow, double x, double y, double altitude)
        {            
            string stringDatetimeBlow = datetimeBlow.ToString().Replace(',', '.');
            string stringX = Convert.ToString(x).Replace(',', '.');
            string stringY = Convert.ToString(y).Replace(',', '.');
            string stringAltitude = Convert.ToString(altitude).Replace(',', '.');
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO " + CalibrationExplosionTableName + " (datetime_blow, x, y, altitude) VALUES ('" + stringDatetimeBlow + "', " + stringX + ", " + stringY + ", " + stringAltitude + ")";
                command.ExecuteNonQuery();
            }
        }
        static public void RefreshSettings(string ip, int port)
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM " + SettingsTableName;
                if (Convert.ToInt32(command.ExecuteScalar()) != 0)
                {
                    ClearTable(SettingsTableName);
                }
                command.CommandText = "INSERT INTO " + SettingsTableName + " (ip, port) VALUES ('" + ip + "', " + Convert.ToString(port) + ")";
                command.ExecuteNonQuery();
            }
        }
        static public void RefreshParameters(
            string datetimeGraphStart,
            string datetimeGraphStop,
            string component,
            double furierMinFrequency,
            double furierMaxFrequency,
            double staltaMinWindow,
            double staltaMaxWindow,
            int staltaOrder)
        {
            string stringFurierMinFrequency = Convert.ToString(furierMinFrequency);
            string stringFurierMaxFrequency = Convert.ToString(furierMaxFrequency);
            string stringStaltaMinWindow = Convert.ToString(staltaMinWindow);
            string stringStaltaMaxWindow = Convert.ToString(staltaMaxWindow);
            string stringStaltaOrder = Convert.ToString(staltaOrder);
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM " + ParametersTableName;
                if (Convert.ToInt32(command.ExecuteScalar()) != 0)
                {
                    ClearTable(ParametersTableName);
                }
                command.CommandText = "INSERT INTO " + ParametersTableName + " (datetime_graph_start, datetime_graph_stop, component, furier_min_freq, furier_max_freq, stalta_min_window, stalta_max_window, stalta_order) VALUES ('" + datetimeGraphStart + "', '" + datetimeGraphStop + "', '" + component + "', " + stringFurierMinFrequency + ", " + stringFurierMaxFrequency + ", " + stringStaltaMinWindow + ", " + stringStaltaMaxWindow + ", " + stringStaltaOrder + ")";
                command.ExecuteNonQuery();
            }
        }
        static public double[,] GetVelocity()
        {
            double[,] array = new double[GetAmountRowsVelocity(), 3];

            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                int i = 0;
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM " + VelocityTableName;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var hTop = Convert.ToDouble(reader.GetValue(0));
                            var hBottom = Convert.ToDouble(reader.GetValue(1));
                            var vp = Convert.ToDouble(reader.GetValue(2));
                            array[i, 0] = hTop;
                            array[i, 1] = hBottom;
                            array[i, 2] = vp;
                            i++;
                        }
                    }
                }
            }
            return array;
        }
        static public double[,] GetStationCoordinates()
        {
            double[,] array = new double[GetAmountRowsStationCoordinates(), 4];

            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                int i = 0;
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM " + StationCoordinatesTableName;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            double number = Convert.ToDouble(reader.GetValue(1));
                            double x = Convert.ToDouble(reader.GetValue(2));
                            double y = Convert.ToDouble(reader.GetValue(3));
                            double altitude = Convert.ToDouble(reader.GetValue(4));
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
        static public double[,] GetLatency()
        {
            double[,] latencyArray = new double[GetAmountRowsLatency(), 2];

            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                int i = 0;
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM " + LatencyTableName;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var stationId = Convert.ToDouble(reader.GetValue(1));
                            var latency = Convert.ToDouble(reader.GetValue(2));
                            latencyArray[i, 0] = stationId;
                            latencyArray[i, 1] = latency;
                            i++;
                        }
                    }
                }
            }
            return latencyArray;
        }
        static public double[,] GetStaticCorrection()
        {
            double[,] latencyCorrectionArray = new double[GetAmountRowsStaticCorrections(), 2];

            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                int i = 0;
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM " + StaticCorrectionsTableName;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var stationId = Convert.ToDouble(reader.GetValue(1));
                            var latencyCorrection = Convert.ToDouble(reader.GetValue(2));
                            latencyCorrectionArray[i, 0] = stationId;
                            latencyCorrectionArray[i, 1] = latencyCorrection;
                            i++;
                        }
                    }
                }
            }
            return latencyCorrectionArray;
        }
        static public string[,] GetCalibrationExplosion()
        {
            string[,] CalibrationExplosionArray = new string[GetAmountRowsCalibrationExplosion(), 4];

            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                int i = 0;
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM " + CalibrationExplosionTableName;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            string datetimeBlow = Convert.ToString(reader.GetValue(0));
                            string x = Convert.ToString(reader.GetValue(1));
                            string y = Convert.ToString(reader.GetValue(2));
                            string altitude = Convert.ToString(reader.GetValue(3));

                            CalibrationExplosionArray[i, 0] = datetimeBlow;
                            CalibrationExplosionArray[i, 1] = x;
                            CalibrationExplosionArray[i, 2] = y;
                            CalibrationExplosionArray[i, 3] = altitude;
                            i++;
                        }
                    }
                }
            }
            return CalibrationExplosionArray;
        }
        static public string[,] GetSeismicRecords()
        {
            string[,] array = new string[GetAmountRowsSeismicRecords(), 6];

            using (var connection = new SqliteConnection("Data Source=" + Path))
            {
                int i = 0;
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM " + SeismicRecordsTableName;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            string id = Convert.ToString(reader.GetValue(0));
                            string StationId = Convert.ToString(reader.GetValue(1));
                            string root = Convert.ToString(reader.GetValue(2));
                            string fileName = Convert.ToString(reader.GetValue(3));
                            string datetimeStart = Convert.ToString(reader.GetValue(4));
                            string datetimeStop = Convert.ToString(reader.GetValue(5));

                            array[i, 0] = id;
                            array[i, 1] = StationId;
                            array[i, 2] = root;
                            array[i, 3] = fileName;
                            array[i, 4] = datetimeStart;
                            array[i, 5] = datetimeStop;

                            i++;
                        }
                    }
                }
            }
            return array;
        }
        static public dynamic GetParameters(int columnNumber = 0)
        {
            string datetimeGraphStart = "";
            string datetimeGraphStop = "";
            string component = "";
            double furierMinFrequency = 0;
            double furierMaxFrequency = 0;
            double staltaMinWindow = 0;
            double staltaMaxWindow = 0;
            int staltaOrder = 0;
            using (var connection = new SqliteConnection("Data Source=" + Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM " + ParametersTableName;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            datetimeGraphStart = Convert.ToString(reader.GetValue(0));
                            datetimeGraphStop = Convert.ToString(reader.GetValue(1));
                            component = Convert.ToString(reader.GetValue(2));
                            Double.TryParse(Convert.ToString(reader.GetValue(3)), out furierMinFrequency);
                            Double.TryParse(Convert.ToString(reader.GetValue(4)), out furierMaxFrequency);
                            Double.TryParse(Convert.ToString(reader.GetValue(5)), out staltaMinWindow);
                            Double.TryParse(Convert.ToString(reader.GetValue(6)), out staltaMaxWindow);
                            Int32.TryParse(Convert.ToString(reader.GetValue(7)), out staltaOrder);                            
                        }
                    }
                }
            }
            if (columnNumber == 1)
            { 
                return datetimeGraphStart; 
            }
            else if (columnNumber == 2)
            { 
                return datetimeGraphStop; 
            }
            else if (columnNumber == 3)
            { 
                return component; 
            }
            else if (columnNumber == 4)
            { 
                return furierMinFrequency; 
            }
            else if (columnNumber == 5)
            { 
                return furierMaxFrequency; 
            }
            else if (columnNumber == 6)
            { 
                return staltaMinWindow; 
            }
            else if (columnNumber == 7)
            { 
                return staltaMaxWindow; 
            }
            else if (columnNumber == 8)
            {
                return staltaOrder;
            }
            else
            {
                return (datetimeGraphStart,
                    datetimeGraphStop,
                    component,
                    furierMinFrequency,
                    furierMaxFrequency,
                    staltaMinWindow,
                    staltaMaxWindow,
                    staltaOrder);
            }
        }
        static public int GetAmountRowsVelocity()
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM " + Database.VelocityTableName;
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        static public int GetAmountRowsStationCoordinates()
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM " + StationCoordinatesTableName;
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        static public int GetAmountRowsSeismicRecords()
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM " + SeismicRecordsTableName;
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        static public int GetAmountRowsLatency()
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM " + LatencyTableName;
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        static public int GetAmountRowsStaticCorrections()
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM " + StaticCorrectionsTableName;
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        static public int GetAmountRowsCalibrationExplosion()
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM " + CalibrationExplosionTableName;
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        static public void AddColumn(string tableName, string columnName, string columnParameters)
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.Path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "ALTER TABLE " + tableName + " ADD COLUMN " + columnName + " " + columnParameters + ";";
                command.ExecuteNonQuery();
            }
        }
        static public void ClearTable(string tableName)
        {
            using (var connection = new SqliteConnection("Data Source=" + Path))
            {
                connection.Open();
                SqliteCommand commandDelete = new SqliteCommand("DELETE  FROM " + tableName, connection);
                commandDelete.ExecuteNonQuery(); ;
            }
        }
    }
}
