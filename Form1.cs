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
                Database.path = save_file.FileName + ".db";
                using (var connection = new SqliteConnection("Data Source=" + Database.path))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "CREATE TABLE Users(_number INTEGER NOT NULL, x DOUBLE NOT NULL, y DOUBLE NOT NULL, altitude DOUBLE NOT NULL)";
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
                Database.path = save_file.FileName;
            }
        }

        private void stationCoordinatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Database.path == "")
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
    }
    static class Database
    {
        public static string path = "";
    }
}
