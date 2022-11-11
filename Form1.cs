using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;


namespace seisapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_file = new SaveFileDialog();
            save_file.Filter = "Database (*.db*)|*.db*";
            save_file.FilterIndex = 1;

            if (save_file.ShowDialog() == DialogResult.OK)
            {
                Database.PATH = save_file.FileName + ".db";
                using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "CREATE TABLE Users(_number INTEGER NOT NULL, x DOUBLE NOT NULL, y DOUBLE NOT NULL, altitude DOUBLE NOT NULL)";
                    command.ExecuteNonQuery();
                }
                using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "CREATE TABLE velocity(h_top DOUBLE NOT NULL, h_bottom DOUBLE NOT NULL, vp DOUBLE NOT NULL)";
                    command.ExecuteNonQuery();
                }
                using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "CREATE TABLE settings(ip VARCHAR(30) NOT NULL, port INTEGER NOT NULL)";
                    command.ExecuteNonQuery();
                }
            }                    
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog save_file = new OpenFileDialog();
            save_file.Filter = "Database (*.db*)|*.db*";
            save_file.FilterIndex = 1;

            if (save_file.ShowDialog() == DialogResult.OK)
            {
                Database.PATH = save_file.FileName;
            }
        }

        private void stationCoordinatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Database.PATH == "")
            {
                MessageBox.Show("Choose file");
            }
            else
            {
                Form station_coordinates_form = new Form_station_coordinates();
                station_coordinates_form.ShowDialog();
            }
        }

        private void speedModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form speed_model_form = new Form_speed_model();
            speed_model_form.ShowDialog();
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form speed_model_form = new Form_connection();
            speed_model_form.ShowDialog();
        }
    }
}
