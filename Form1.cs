﻿using System;
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
            label_artcode.Visible = true;




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
                Database.create_table();
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
            if (Database.PATH == "")
            {
                MessageBox.Show("Choose file");
            }
            else
            {
                Form speed_model_form = new Form_speed_model();
                speed_model_form.ShowDialog();
            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form speed_model_form = new Form_connection();
            speed_model_form.ShowDialog();
        }

        private void seismicRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Database.PATH == "")
            {
                MessageBox.Show("Choose file");
            }
            else
            {
                Form seismic_records_form = new Form_seismic_records();
                seismic_records_form.ShowDialog();
            }
        }

        private void clearDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Database.PATH == "")
            {
                MessageBox.Show("Choose file");
            }
            else
            {
                Database.clear_table(Database.VELOCITY_TABLENAME);
                Database.clear_table(Database.SETTINGS_TABLENAME);
                Database.clear_table(Database.STATION_COORDINATES_TABLENAME);
            }
        }

        private void correctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Database.PATH == "")
            {
                MessageBox.Show("Choose file");
            }
            else
            {
                Form corrections_form = new Form_corrections();
                corrections_form.ShowDialog();
            }
        }



        private void peakTracesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label_artcode.Visible = false;

            pictureBox_date.Visible = true;
            label_date.Visible = true;
            label_date_start.Visible = true;
            label_date_stop.Visible = true;
            textBox_date_start.Visible = true;
            textBox_date_stop.Visible = true;
            label_component.Visible = true;
            comboBox_component.Visible = true;

            pictureBox_furier_filter.Visible = true;
            label_furier_filter.Visible = true;
            label_min_frequency.Visible = true;
            label_max_frequency.Visible = true;
            spinEdit_min_frequency.Visible = true;
            spinEdit_max_frequency.Visible = true;

            string[,] seismic_records_array = new string[Database.get_amount_rows_seismic_records(), 6];
            seismic_records_array = Database.get_seismic_records();

            DateTime[,] seismic_datetime_start_stop = new DateTime[seismic_records_array.GetLength(0), 2];

            for (int i = 0; i < seismic_records_array.GetLength(0); i++)
            {
                seismic_datetime_start_stop[i, 0] = DateTime.Parse(seismic_records_array[i, 4]);
                seismic_datetime_start_stop[i, 1] = DateTime.Parse(seismic_records_array[i, 5]);
            }

            DateTime maximum_seismic_datetime_start = seismic_datetime_start_stop[0, 0];
            DateTime minimum_seismic_datetime_stop = seismic_datetime_start_stop[0, 1];

            for (int i = 0; i < seismic_datetime_start_stop.GetLength(0); i++)
            {
                int start_compare = DateTime.Compare(seismic_datetime_start_stop[i, 0], maximum_seismic_datetime_start);
                int stop_compare = DateTime.Compare(seismic_datetime_start_stop[i, 1], minimum_seismic_datetime_stop);

                if (start_compare >= 0)
                {
                    maximum_seismic_datetime_start = seismic_datetime_start_stop[i, 0];
                }

                if (stop_compare <= 0)
                {
                    minimum_seismic_datetime_stop = seismic_datetime_start_stop[i, 1]; 
                }                
            }

            if (DateTime.Compare(maximum_seismic_datetime_start, minimum_seismic_datetime_stop) >= 0)
            {
                MessageBox.Show("Время старта одного из датчиков меньше или равно времени конца другого");
                maximum_seismic_datetime_start = new DateTime();
                minimum_seismic_datetime_stop = new DateTime();
            }

            textBox_date_start.Text = Convert.ToString(DateTime.Now);
            textBox_date_stop.Text = Convert.ToString(DateTime.Now);

            Binary_File signal = new Binary_File("D:/Binaryfiles/HF_0004_2019-08-08_11-51-37_064_132.xx");
            signal._get_component_signal();
        }

        private void label_component_Click(object sender, EventArgs e)
        {

        }

        private void label_date_start_Click(object sender, EventArgs e)
        {

        }

        private void label_date_stop_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
