using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
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
            this.chartControlSignals.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartControl1_MouseMove);
            this.chartControlSignals.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartControl1_MouseDown);
            chartControlSignals.SeriesTemplate.CrosshairLabelPattern = "{S}: {A:F0}";
            
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
            if (Database.Path == "")
            {
                MessageBox.Show("Choose file");
            }
            else
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

            DevExpress.XtraCharts.Series[] complexOfGraph = new DevExpress.XtraCharts.Series[signalAmount];
            
            DevExpress.XtraCharts.LineSeriesView[] lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView[signalAmount];

            for (int i = 0; i < signalAmount; i++)
            {                
                complexOfGraph[i] = new DevExpress.XtraCharts.Series();
                lineSeriesView1[i] = new DevExpress.XtraCharts.LineSeriesView();

                complexOfGraph[i].Name = "file=" + Convert.ToString(i + 1);
                complexOfGraph[i].View = lineSeriesView1[i];

                ((System.ComponentModel.ISupportInitialize)(complexOfGraph[i])).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(lineSeriesView1[i])).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(lineSeriesView1[i])).EndInit();
                ((System.ComponentModel.ISupportInitialize)(complexOfGraph[i])).EndInit();

                BinarySeismicFile binarySignal = new BinarySeismicFile(arrayOfPathToBinaryFiles[i]);
                binarySignal.__ResampleFrequency = Convert.ToInt32(spinEdit_frequency.Value);
                binarySignal.__ReadDatetimeStop = stop;
                binarySignal.__ReadDatetimeStart = start;

                string component = comboBox_component.Text;
                Int32[] signal = binarySignal.ReadSignal(component);

                furierFilter(i, Convert.ToInt32(spinEdit_frequency.Value), signal);

                Int32 maximumOfSignal = signal.Max();
                Int32 minimumOfSignal = signal.Min();

                double coefNorm = Convert.ToDouble(2) / (maximumOfSignal - minimumOfSignal);
                double max = 0;
                double min = 1999;
                for (int z = 0; z < signal.Length; z++)
                {
                    double zToSeconds = Convert.ToDouble(z) / Convert.ToInt32(spinEdit_frequency.Value);
                    double value = signal[z] * coefNorm - minimumOfSignal * coefNorm + 2 * i;
                    complexOfGraph[i].Points.AddPoint(zToSeconds, value);
                    if (max < value) { max = value; }
                    if (min > value) { min = value; }
                }                
            }
            

            if (Database.GetAmountRowsSeismicRecords() == dataGridViewLatency.Rows.Count)
            {

            }
            else
            {
                dataGridViewLatency.Rows.Clear();
                for (int i = 1; i <= Database.GetAmountRowsSeismicRecords(); i++)
                {                    
                    dataGridViewLatency.Rows.Add(i, 0);
                }
            }

            this.chartControlSignals.SeriesSerializable = complexOfGraph;

            XYDiagram xyDiagram = (XYDiagram)chartControlSignals.Diagram;
            xyDiagram.ZoomingOptions.AxisXMaxZoomPercent = 100000;
            xyDiagram.ZoomingOptions.AxisYMaxZoomPercent = 100000;
            xyDiagram.EnableAxisXZooming = true;
            xyDiagram.EnableAxisXScrolling = true;
            xyDiagram.EnableAxisYZooming = true;
            xyDiagram.EnableAxisYScrolling = true;
            xyDiagram.Rotated = true;
            xyDiagram.AxisX.Reverse = true;
            chartControlSignals.CrosshairOptions.ShowArgumentLine = true;
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
            /*
            ChartHitInfo hi = chartControlSignals.CalcHitInfo(e.X, e.Y);

            // Obtain the series point under the test point.
            SeriesPoint point = hi.SeriesPoint;
            DiagramCoordinates coords = ((XYDiagram2D)chartControlSignals.Diagram).PointToDiagram(chartControlSignals.PointToClient(Cursor.Position));*/
        }
        private void chartControl1_MouseMove(object sender, MouseEventArgs e)
        {
            /*// Obtain hit information under the test point.
            ChartHitInfo hi = chartControlSignals.CalcHitInfo(e.X, e.Y);

            // Obtain the series point under the test point.
            SeriesPoint point = hi.SeriesPoint;
            DiagramCoordinates coords = ((XYDiagram2D)chartControlSignals.Diagram).PointToDiagram(chartControlSignals.PointToClient(Cursor.Position));
            // Check whether the series point was clicked or not.
            if (point != null)
            {                                
                string[] seriesName = Convert.ToString(hi.Series).Split(new char[] { '=' }, 2);

                Int32.TryParse(Convert.ToString(seriesName[1]), out int number);
                Double.TryParse(hi.SeriesPoint.Argument, out double value);
                foreach (DataGridViewRow r in dataGridViewLatency.Rows)
                {
                    if (Convert.ToInt32(r.Cells["number"].Value) == number)
                    {
                        r.Cells["latency"].Value = value;
                    }
                }
            }*/
        }

        private void buttonClearLatency_Click(object sender, EventArgs e)
        {            
            double latency = 0;
            foreach (DataGridViewRow r in dataGridViewLatency.Rows)
            {                
                r.Cells["latency"].Value = latency;
            }
        }

        private void buttonSaveLatency_Click(object sender, EventArgs e)
        {            
            int stationId = 0;
            double latency = 0;

            Database.ClearTable(Database.LatencyTableName);

            foreach (DataGridViewRow r in dataGridViewLatency.Rows)
            {
                if (r.Cells["number"].Value != null)
                {
                    stationId = Convert.ToInt32(Convert.ToString(r.Cells["number"].Value).Replace(',', '.'));                    
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }
                if (r.Cells["latency"].Value != null)
                {
                    string stroka = Convert.ToString(r.Cells["latency"].Value).Replace(',', '.');
                    Double.TryParse(stroka, NumberStyles.Any, CultureInfo.InvariantCulture, out latency);
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }                

                Database.AddRowInLatency(stationId, latency);
            }            
            UpdateLatencyDataGrid();
        }

        public void UpdateLatencyDataGrid()
        {
            dataGridViewLatency.Rows.Clear();
            double[,] array = new double[Database.GetAmountRowsLatency(), 2];
            array = Database.GetLatency();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                double stationId = array[i, 0];
                double latency = array[i, 1];
                dataGridViewLatency.Rows.Add(stationId, latency);
            }
        }     

        private void staticCorrectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Database.Path == "")
            {
                MessageBox.Show("Choose file");
            }
            else
            {
                Form static_corrections_form = new Form_static_corrections();
                static_corrections_form.ShowDialog();
            }
        }

        private void furierFilter(int station_number, int frequency, Int32[] signal_array)
        {            
            string component = Database.GetParameters(3);
            double furierMinFrequency = Database.GetParameters(4);
            double furierMaxFrequency = Database.GetParameters(5);
            double staltaMinWindow = Database.GetParameters(6);
            double staltaMaxWindow = Database.GetParameters(7);
            int staltaOrder = Database.GetParameters(8);

            Hashtable[] traces = new Hashtable[200];
            Hashtable trace = new Hashtable();
            trace.Add("station_number", station_number);
            trace.Add("component", component);
            trace.Add("frequency", 200);
            trace.Add("signal", signal_array);
            for (int i = 0; i < 200; i++)
            {
                traces[i] = trace;
            }
            Hashtable signal_traces = new Hashtable();            

            trace = new Hashtable();
            trace.Add("station_number", 1);
            trace.Add("component", component);
            trace.Add("frequency", 0);
            trace.Add("signal_array", signal_array);
            //traces[1] = trace;            
            signal_traces.Add("traces", traces);
            

            Hashtable frequency_limit = new Hashtable();
            frequency_limit.Add("max_val", furierMaxFrequency);
            frequency_limit.Add("min_val", furierMinFrequency);            
            Hashtable bandpass_filter_params = new Hashtable();
            bandpass_filter_params.Add("frequency_limit", frequency_limit);

            Hashtable slta_filter_params = new Hashtable();            
            slta_filter_params.Add("order", staltaOrder);
            slta_filter_params.Add("long_window", staltaMaxWindow);
            slta_filter_params.Add("short_window", staltaMinWindow);

            Hashtable filtration = new Hashtable();
            filtration.Add("slta_filter_params", slta_filter_params);
            filtration.Add("bandpass_filter_params", bandpass_filter_params);
            filtration.Add("signal_traces", signal_traces);
            

                        

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(filtration, options);

            string test = "{  \"signal_traces\": {                \"traces\": [                  {                    \"station_number\": 0,        \"component\": \"string\",      \"frequency\": 0,        \"signal\": [          0                    ]      }    ]  },  \"bandpass_filter_params\": {                \"frequency_limit\": {                    \"min_val\": 0,      \"max_val\": 0                }            },  \"slta_filter_params\": {                \"long_window\": 0,    \"short_window\": 0,    \"order\": 0  }        }";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.1.7:8157/filtration");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
            }

            Hashtable desirealize = new Hashtable();

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                desirealize = JsonSerializer.Deserialize<Hashtable>(result);
            }


            string dataItem = JsonSerializer.Serialize(desirealize["traces"], options);
            Hashtable correctionsItem = JsonSerializer.Deserialize<Hashtable>(dataItem);            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
