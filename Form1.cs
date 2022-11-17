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
            peak_traces_hide();
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

        public void peak_traces_hide()
        {
            label_artcode.Visible = false;

            pictureBox_date.Visible = false;                
            label_date.Visible = false;
            label_date_start.Visible = false;
            label_date_stop.Visible = false;
            textBox_date_start.Visible = false;
            textBox_date_stop.Visible = false;
            label_component.Visible = false;
            comboBox_component.Visible = false;

            pictureBox_furier_filter.Visible = false;
            label_furier_filter.Visible = false;
            label_min_frequency.Visible = false;
            label_max_frequency.Visible = false;
            spinEdit_min_frequency.Visible = false;
            spinEdit_max_frequency.Visible = false;
        }
        public void peak_traces_show()
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
        }

        private void peakTracesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            peak_traces_show();
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
                if (seismic_datetime_start_stop[i, 0] > maximum_seismic_datetime_start)
                    { maximum_seismic_datetime_start = seismic_datetime_start_stop[i, 0]; }
                if (seismic_datetime_start_stop[i, 1] > minimum_seismic_datetime_stop)
                { minimum_seismic_datetime_stop = seismic_datetime_start_stop[i, 1]; }
            }

            if (maximum_seismic_datetime_start > minimum_seismic_datetime_stop)
            {
                MessageBox.Show("Время старта одного из датчиков меньше времени конца другого");
                maximum_seismic_datetime_start = new DateTime();
                minimum_seismic_datetime_stop = new DateTime();
            }

            textBox_date_start.Text = maximum_seismic_datetime_start.ToString();
            textBox_date_stop.Text = minimum_seismic_datetime_stop.ToString();
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
