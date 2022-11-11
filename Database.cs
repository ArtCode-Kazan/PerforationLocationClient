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
