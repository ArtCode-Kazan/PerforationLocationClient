using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using BinReader;

namespace seisapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label_artcode.Visible = true;
            comboBoxChooseComponent.Text = "Z";
            dateTimePickerStart.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dateTimePickerStop.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            spinEdit_stalta_filter_order.Properties.Mask.EditMask = "f0";   // only int
            spinEdit_stalta_filter_min_frequency.Properties.Mask.EditMask = "f0";   // only int
            spinEdit_stalta_filter_max_frequency.Properties.Mask.EditMask = "f0";   // only int
            spinEditSetFrequency.Properties.Mask.EditMask = "f0";   // only int
            spinEditSetFrequency.Value = 100;
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
                labelDateInDateMenu.Visible = true;
                labelDataStartInDateMenu.Visible = true;
                labelDataStopInDateMenu.Visible = true;
                labelComponentInDateMenu.Visible = true;
                comboBoxChooseComponent.Visible = true;

                pictureBox_furier_filter.Visible = true;
                labellabelFurierFilterInFurierFilter.Visible = true;
                labelFurierMinFrequencyInFurierFilter.Visible = true;
                labelFurierMaxFrequencyInFurierFilter.Visible = true;
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

                dateTimePickerStart.Value = maximum_seismic_datetime_start;
                dateTimePickerStop.Value = minimum_seismic_datetime_stop;


                if (Database.GetAmountRowsLatency() != 0 & dataGridViewLatency.RowCount == 0)
                {
                    // Get latencys
                    double[,] latencyArray = new double[Database.GetAmountRowsLatency(), 2];
                    latencyArray = Database.GetLatency();
                    for (int i = 0; i < latencyArray.GetLength(0); i++)
                    {
                        dataGridViewLatency.Rows.Add(latencyArray[i, 0], latencyArray[i, 1]);
                    }
                }
                else
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.RefreshParameters(
                Convert.ToString(dateTimePickerStart.Value),
                Convert.ToString(dateTimePickerStop.Value),
                comboBoxChooseComponent.Text,
                Convert.ToDouble(spinEdit_furier_min_frequency.Value),
                Convert.ToDouble(spinEdit_furier_max_frequency.Value),
                Convert.ToDouble(spinEdit_stalta_filter_min_frequency.Value),
                Convert.ToDouble(spinEdit_stalta_filter_max_frequency.Value),
                Convert.ToInt32(spinEdit_stalta_filter_order.Value)
                );

            double furierMinFrequency = Convert.ToDouble(spinEdit_furier_min_frequency.Text);
            double furierMaxFrequency = Convert.ToDouble(spinEdit_furier_max_frequency.Text);

            DateTime start = dateTimePickerStart.Value;
            DateTime stop = dateTimePickerStop.Value;

            string[] arrayOfPathToBinaryFiles = new string[Database.GetAmountRowsSeismicRecords()];
            string[,] seismicRecordsArray = new string[Database.GetAmountRowsSeismicRecords(), 6];
            seismicRecordsArray = Database.GetSeismicRecords();

            int signalAmount = Database.GetAmountRowsSeismicRecords();

            for (int i = 0; i < arrayOfPathToBinaryFiles.Length; i++)
            {
                arrayOfPathToBinaryFiles[i] = seismicRecordsArray[i, 2] + "/" + seismicRecordsArray[i, 3];
            }

            DevExpress.XtraCharts.Series[] complexOfGraph = new DevExpress.XtraCharts.Series[signalAmount];

            DevExpress.XtraCharts.LineSeriesView[] lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView[signalAmount];

            for (int i = 0; i < signalAmount; i++)
            {
                complexOfGraph[i] = new DevExpress.XtraCharts.Series();
                lineSeriesView1[i] = new DevExpress.XtraCharts.LineSeriesView();

                complexOfGraph[i].Name = "file=" + Convert.ToString(seismicRecordsArray[i, 1]);
                complexOfGraph[i].View = lineSeriesView1[i];

                ((System.ComponentModel.ISupportInitialize)(complexOfGraph[i])).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(lineSeriesView1[i])).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(lineSeriesView1[i])).EndInit();
                ((System.ComponentModel.ISupportInitialize)(complexOfGraph[i])).EndInit();

                BinarySeismicFile binarySignal = new BinarySeismicFile(arrayOfPathToBinaryFiles[i]);
                binarySignal._ResampleFrequency = Convert.ToInt32(spinEditSetFrequency.Value);
                binarySignal._ReadDatetimeStop = stop;
                binarySignal._ReadDatetimeStart = start;                

                string component = comboBoxChooseComponent.Text;
                Int32[] signal = binarySignal.ReadSignal(component);

                double[] filtered_signal = new double[signal.Length];
                
                filtered_signal = furierFilter(i, Convert.ToInt32(spinEditSetFrequency.Value), signal);







                double maximumOfSignal = filtered_signal.Max();
                double minimumOfSignal = filtered_signal.Min();

                double coefNorm = Convert.ToDouble(2) / (maximumOfSignal - minimumOfSignal);
                double max = 0;
                double min = 1999;
                for (int z = 0; z < filtered_signal.Length; z++)
                {
                    double zToSeconds = Convert.ToDouble(z) / Convert.ToInt32(spinEditSetFrequency.Value);
                    double value = filtered_signal[z] * coefNorm - minimumOfSignal * coefNorm + 2 * i;
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
                string[,] seisRecords = new string[Database.GetAmountRowsSeismicRecords(), 6];
                seisRecords = Database.GetSeismicRecords();
                dataGridViewLatency.Rows.Clear();
                for (int i = 1; i <= Database.GetAmountRowsSeismicRecords(); i++)
                {
                    dataGridViewLatency.Rows.Add(seisRecords[i - 1, 1], 0);
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
            DiagramCoordinates coords = ((XYDiagram2D)chartControlSignals.Diagram).PointToDiagram(chartControlSignals.PointToClient(Cursor.Position));
            */
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

        private double[] furierFilter(int station_number, int frequency, Int32[] signal_array)
        {
            string component = Database.GetParameters(3);
            double furierMinFrequency = Database.GetParameters(4);
            double furierMaxFrequency = Database.GetParameters(5);
            double staltaMinWindow = Database.GetParameters(6);
            double staltaMaxWindow = Database.GetParameters(7);
            int staltaOrder = Database.GetParameters(8);

            Hashtable[] traces = new Hashtable[1];
            Hashtable trace = new Hashtable();
            trace.Add("station_number", station_number);
            trace.Add("component", component);
            trace.Add("frequency", 200);
            trace.Add("signal", signal_array);
            traces[0] = trace;

            Hashtable signal_traces = new Hashtable();
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

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.1.7:8157/filtration");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            double[] filteredSignalArrays = new double[signal_array.Length];
            for (int i = 0; i < signal_array.Length; i++)
            {
                filteredSignalArrays[i] = signal_array[i];
            }

            HttpWebResponse httpResponse = null;
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonString);
                }

                Hashtable desirealize = new Hashtable();                

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    desirealize = JsonSerializer.Deserialize<Hashtable>(result);
                }

                string dataItem = JsonSerializer.Serialize(desirealize["traces"], options);
                string dataItemForSerialize = dataItem.Substring(1, dataItem.Length - 2);
                Hashtable correctionsItem = JsonSerializer.Deserialize<Hashtable>(dataItemForSerialize);

                JavaScriptSerializer js = new JavaScriptSerializer();
                filteredSignalArrays = js.Deserialize<double[]>(JsonSerializer.Serialize(correctionsItem["signal"], options));
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    httpResponse = (HttpWebResponse)e.Response;
                    MessageBox.Show("Errorcode: " + Convert.ToString(httpResponse.StatusCode));
                }
                else
                {
                    MessageBox.Show("Error: " + Convert.ToString(e.Message));
                }
            }

            if (httpResponse != null)
            {
                httpResponse.Close();
            }

            return filteredSignalArrays;
        }
        /*
        private List<double[]> furierFilter(int station_number, int frequency, List<Int32[]> signal_arrays)
        {            
            string component = Database.GetParameters(3);
            double furierMinFrequency = Database.GetParameters(4);
            double furierMaxFrequency = Database.GetParameters(5);
            double staltaMinWindow = Database.GetParameters(6);
            double staltaMaxWindow = Database.GetParameters(7);
            int staltaOrder = Database.GetParameters(8);

            Hashtable[] traces = new Hashtable[signal_arrays.Count];

            for (int i = 0; i < signal_arrays.Count; i++)
            {
                Hashtable trace = new Hashtable();
                trace.Add("station_number", station_number);
                trace.Add("component", component);
                trace.Add("frequency", 200);
                trace.Add("signal", signal_arrays[i]);
                for (int j = 0; j < 200; j++)
                {
                    traces[j] = trace;
                }
            }
            Hashtable signal_traces = new Hashtable();                        
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


            List<double[]> filteredSignalArrays = new List<double[]>();

            IDictionaryEnumerator denum = correctionsItem.GetEnumerator();
            DictionaryEntry dentry;
            while (denum.MoveNext())
            {
                dentry = (DictionaryEntry)denum.Current;
                filteredSignalArrays.Add((double[])dentry.Value);                
            }            

            return filteredSignalArrays;
        }
        */
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void spinEdit_frequency_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
