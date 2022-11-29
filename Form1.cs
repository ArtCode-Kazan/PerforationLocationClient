using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts;

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
            spinEdit_frequency.Properties.Mask.EditMask = "f0";   // only int
            spinEdit_frequency.Value = 200;
            this.chartControlSignals.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartControl1_MouseDown);
            chartControlSignals.SeriesTemplate.CrosshairLabelPattern = "{S}: {A:F0}";
            Database.Path = "C://Users//user//Desktop/budda.db";
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
                Database.Path = save_file.FileName + ".db";
                Database.CreateTable();
            }
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog save_file = new OpenFileDialog();
            save_file.Filter = "Database (*.db*)|*.db*";
            save_file.FilterIndex = 1;

            if (save_file.ShowDialog() == DialogResult.OK)
            {
                Database.Path = save_file.FileName;
            }
        }

        private void stationCoordinatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Database.Path == "")
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
            if (Database.Path == "")
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
            if (Database.Path == "")
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
            if (Database.Path == "")
            {
                MessageBox.Show("Choose file");
            }
            else
            {
                Database.ClearTable(Database.VelocityTableName);
                Database.ClearTable(Database.SettingsTableName);
                Database.ClearTable(Database.StationCoordinatesTableName);
            }
        }

        private void correctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Database.Path == "")
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

            string[,] seismic_records_array = new string[Database.GetAmountRowsSeismicRecords(), 6];
            seismic_records_array = Database.GetSeismicRecords();

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

            string[] arrayOfPathToBinaryFiles = new string[Database.GetAmountRowsSeismicRecords()];
            string[,] seismic_records_array = new string[Database.GetAmountRowsSeismicRecords(), 6];
            seismic_records_array = Database.GetSeismicRecords();

            int signalAmount = Database.GetAmountRowsSeismicRecords();

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

                BinarySeismicFile binarySignal = new BinarySeismicFile(arrayOfPathToBinaryFiles[i]);
                binarySignal.__ResampleFrequency = Convert.ToInt32(spinEdit_frequency.Value);
                binarySignal.__ReadDatetimeStop = stop;
                binarySignal.__ReadDatetimeStart = start;

                string component = comboBox_component.Text;
                Int32[] signal = binarySignal.ReadSignal(component);

                Int32 maximumOfSignal = signal.Max();
                Int32 minimumOfSignal = signal.Min();



                double coefNorm = Convert.ToDouble(2) / (maximumOfSignal - minimumOfSignal);
                double max = 0;
                double min = 1999;
                for (int z = 0; z < signal.Length; z++)
                {
                    double value = signal[z] * coefNorm - minimumOfSignal * coefNorm + 2 * i;
                    series1[i].Points.AddPoint(z, value);
                    if (max < value) { max = value; }
                    if (min > value) { min = value; }
                }

                dataGridViewLatency.Rows.Add(i, "0");

            }
            this.chartControlSignals.SeriesSerializable = series1;

            XYDiagram xyDiagram = (XYDiagram)chartControlSignals.Diagram;
            xyDiagram.EnableAxisXZooming = true;
            xyDiagram.EnableAxisXScrolling = true;
            xyDiagram.EnableAxisYZooming = true;
            xyDiagram.EnableAxisYScrolling = true;
            xyDiagram.Rotated = true;
            xyDiagram.AxisX.Reverse = true;
            /*
            chartControlSignals.CrosshairOptions.ShowArgumentLine = true;
            chartControlSignals.CrosshairOptions.ShowArgumentLabels = true;
            chartControlSignals.CrosshairOptions.ShowValueLine = false;
            chartControlSignals.CrosshairOptions.ShowValueLabels = false;
            chartControlSignals.CrosshairOptions.ShowCrosshairLabels = true;
            chartControlSignals.CrosshairOptions.ShowGroupHeaders = true;
            chartControlSignals.CrosshairOptions.GroupHeaderPattern = "{A:F0}";
            chartControlSignals.SeriesTemplate.CrosshairLabelPattern = "{S}: {A:F0}";
            ((XYDiagram)chartControlSignals.Diagram).AxisY.CrosshairAxisLabelOptions.Pattern = "{V:F0}";*/

        }

        private void chartControl1_Click(object sender, EventArgs e)
        {




        }
        private void chartControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {            
            Point position = new Point(e.Location.X, e.Location.Y);            
            ChartHitInfo hitInfo = chartControlSignals.CalcHitInfo(position);
            
            if (hitInfo.SeriesPoint != null)
            {
                string[] seriesName = Convert.ToString(hitInfo.Series).Split(new char[] { '=' }, 2);
                
                Int32.TryParse(Convert.ToString(seriesName[1]), out int number);
                Double.TryParse(hitInfo.SeriesPoint.Argument, out double value);
                foreach (DataGridViewRow r in dataGridViewLatency.Rows)
                {
                    if (Convert.ToInt32(r.Cells["number"].Value) == number)
                    {
                        r.Cells["latency"].Value = value;
                    }
                }
            }
        }
    }
}
