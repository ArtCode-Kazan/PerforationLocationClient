﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Microsoft.Data.Sqlite;

namespace seisapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label_artcode.Visible = true;
            comboBox_component.Text = "Z";
            dateTimePicker_start.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dateTimePicker_stop.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            spinEdit_stalta_filter_order.Properties.Mask.EditMask = "f0";   // only int

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
            label_component.Visible = true;
            comboBox_component.Visible = true;

            pictureBox_furier_filter.Visible = true;
            label_furier_filter.Visible = true;
            label_min_frequency.Visible = true;
            label_max_frequency.Visible = true;
            spinEdit_furier_min_frequency.Visible = true;
            spinEdit_furier_max_frequency.Visible = true;

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
                maximum_seismic_datetime_start = DateTime.Now;
                minimum_seismic_datetime_stop = DateTime.Now;
            }

            dateTimePicker_start.Value = maximum_seismic_datetime_start;
            dateTimePicker_stop.Value = minimum_seismic_datetime_stop;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double furier_min_frequency = Convert.ToDouble(spinEdit_furier_min_frequency.Text);
            double furier_max_frequency = Convert.ToDouble(spinEdit_furier_max_frequency.Text);

            DateTime start = dateTimePicker_start.Value;
            DateTime stop = dateTimePicker_stop.Value;

            string[] arrayOfPathToBinaryFiles = new string[Database.get_amount_rows_seismic_records()];
            string[,] seismic_records_array = new string[Database.get_amount_rows_seismic_records(), 6];
            seismic_records_array = Database.get_seismic_records();

            int signalAmount = Database.get_amount_rows_seismic_records();

            for (int i = 0; i < arrayOfPathToBinaryFiles.Length; i++)
            {
                arrayOfPathToBinaryFiles[i] = seismic_records_array[i, 2] + "/" + seismic_records_array[i, 3];
            }

            DevExpress.XtraCharts.Series[] series1 = new DevExpress.XtraCharts.Series[signalAmount];
            DevExpress.XtraCharts.LineSeriesView[] lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView[signalAmount];

            for (int i = 0; i < signalAmount; i++)
            {
                series1[i] = new DevExpress.XtraCharts.Series();
                lineSeriesView1[i] = new DevExpress.XtraCharts.LineSeriesView();

                series1[i].Name = "file=" + Convert.ToString(i);
                series1[i].View = lineSeriesView1[i];

                ((System.ComponentModel.ISupportInitialize)(series1[i])).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(lineSeriesView1[i])).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(lineSeriesView1[i])).EndInit();
                ((System.ComponentModel.ISupportInitialize)(series1[i])).EndInit();


                Binary_File binarySignal = new Binary_File(arrayOfPathToBinaryFiles[i]);
                binarySignal.__resample_frequency = 100;
                binarySignal.__read_date_time_stop = stop;
                binarySignal.__read_date_time_start = start;

                string component = comboBox_component.Text;
                Int32[] signal = binarySignal.read_signal(component);

                Int32 maximumOfSignal = signal.Max();
                double coefNorm = Convert.ToDouble(1) / maximumOfSignal;

                for (int z = 0; z < signal.Length; z++)
                {
                    double value = signal[z] * coefNorm + 1 * i;
                    series1[i].Points.AddPoint(z, value);
                }

            }
            this.chartControl1.SeriesSerializable = series1;

            XYDiagram xyDiagram = (XYDiagram)chartControl1.Diagram;
            xyDiagram.EnableAxisXZooming = true;
            xyDiagram.EnableAxisXScrolling = true;
            xyDiagram.EnableAxisYZooming = true;
            xyDiagram.EnableAxisYScrolling = true;
            xyDiagram.Rotated = true;
        }
    }
}
