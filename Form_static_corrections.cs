using DevExpress.XtraCharts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seisapp
{
    public partial class Form_static_corrections : Form
    {
        public Form_static_corrections()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            int number = 0;
            double vp = 0;
            foreach (DataGridViewRow r in dataGridViewCorrections.Rows)
            {
                if (r.Cells["number"].Value != null)
                {
                    number = Convert.ToInt32(Convert.ToString(r.Cells["number"].Value).Replace(',', '.'));
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }
                if (r.Cells["latency"].Value != null)
                {
                    string stroka = Convert.ToString(r.Cells["latency"].Value).Replace(',', '.');
                    Double.TryParse(stroka, NumberStyles.Any, CultureInfo.InvariantCulture, out vp);
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }

                Database.AddRowInStaticCorrections(number, vp);
            }
            UpdateCorrectionsDataGrid();
        }
        public void UpdateCorrectionsDataGrid()
        {
            dataGridViewCorrections.Rows.Clear();
            double[,] array = new double[Database.GetAmountRowsStaticCorrections(), 2];
            array = Database.GetStaticCorrection();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                double stationId = array[i, 0];
                double latency = array[i, 1];
                dataGridViewCorrections.Rows.Add(stationId, latency);
            }
        }

        private void buttonGetCorrections_Click(object sender, EventArgs e)
        {
            double[,] stationInfo = Database.GetStationCoordinates();
            double[,] velocityInfo = Database.GetVelocity();

            Hashtable[] stations = new Hashtable[stationInfo.GetLength(0)];

            for (int i = 0; i < stationInfo.GetLength(0); i++)
            {
                var coordinate = new Hashtable();
                coordinate.Add("x", stationInfo[i, 1]);
                coordinate.Add("y", stationInfo[i, 2]);
                coordinate.Add("altitude", stationInfo[i, 3]);

                var station = new Hashtable();
                station.Add("number", stationInfo[i, 0]);
                station.Add("coordinate", coordinate);

                stations[i] = station;
            }

            var observationSystem = new Hashtable();
            observationSystem.Add("stations", stations);

            Hashtable[] layers = new Hashtable[stationInfo.GetLength(0)];

            for (int i = 0; i < velocityInfo.GetLength(0); i++)
            {
                var altitudeInterval = new Hashtable();
                altitudeInterval.Add("min_val", velocityInfo[i, 1]);
                altitudeInterval.Add("max_val", velocityInfo[i, 0]);

                var layer = new Hashtable();
                layer.Add("altitude_interval", altitudeInterval);
                layer.Add("vp", velocityInfo[i, 2]);

                layers[i] = layer;
            }

            var velocityModel = new Hashtable();
            velocityModel.Add("layers", layers);

            var seismicInformation = new Hashtable();
            seismicInformation.Add("observation_system", observationSystem);
            seismicInformation.Add("velocity_model", velocityModel);

            Hashtable desirealize = new Hashtable();

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(seismicInformation, options);

            string test = "{  \"observation_system\": {                \"stations\": [                  {                    \"number\": 1,        \"coordinate\": {                        \"x\": 1,          \"y\": 1,          \"altitude\": 1        }                }    ]  },  \"velocity_model\": {                \"layers\": [                  {                    \"altitude_interval\": {                        \"min_val\": 1,          \"max_val\": 2                    },        \"vp\": 3                  }    ]  }        }";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.1.7:8157/static-corrections");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(test);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                desirealize = JsonSerializer.Deserialize<Hashtable>(result);
            }


            string dataItem = JsonSerializer.Serialize(desirealize["data"], options);
            Hashtable correctionsItem = JsonSerializer.Deserialize<Hashtable>(dataItem);

            string infoItem = JsonSerializer.Serialize(correctionsItem["corrections"], options);
            infoItem = "  {                \"station_number\": 1,    \"value\": 0.0  }";
            Hashtable info = JsonSerializer.Deserialize<Hashtable>(infoItem);


            string[,] calibrationExplosion = new string[Database.GetAmountRowsCalibrationExplosion(), 4];
            calibrationExplosion = Database.GetCalibrationExplosion();
            double xBlowCoordinate = Convert.ToDouble(calibrationExplosion[0, 1]);
            double yBlowCoordinate = Convert.ToDouble(calibrationExplosion[0, 2]);
            double zBlowCoordinate = Convert.ToDouble(calibrationExplosion[0, 3]);

            double[,] stationCoordinates = new double[Database.GetAmountRowsStationCoordinates(), 4];
            stationCoordinates = Database.GetStationCoordinates();            

            double[,] distanceBetweenBlowNStations = new double[stationCoordinates.GetLength(0), 3];
            for (int i = 0; i < stationCoordinates.GetLength(0); i++)
            {
                double number = Convert.ToDouble(stationCoordinates[i, 0]);
                double currentXCoordinate = Convert.ToDouble(stationCoordinates[i, 1]);
                double currentYCoordinate = Convert.ToDouble(stationCoordinates[i, 2]);
                double currentZCoordinate = Convert.ToDouble(stationCoordinates[i, 3]);

                double distance = Math.Pow((Math.Pow((currentXCoordinate - xBlowCoordinate), 2) + Math.Pow((currentYCoordinate - yBlowCoordinate), 2) + Math.Pow((currentZCoordinate - zBlowCoordinate), 2)), 0.5);
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
                complexOfGraph[i].Points.AddPoint(zToSeconds, value);
            }

            this.chartControlGodograph.SeriesSerializable = complexOfGraph;
            XYDiagram xyDiagram = (XYDiagram)chartControlGodograph.Diagram;
            xyDiagram.ZoomingOptions.AxisXMaxZoomPercent = 100000;
            xyDiagram.ZoomingOptions.AxisYMaxZoomPercent = 100000;
            xyDiagram.EnableAxisXZooming = true;
            xyDiagram.EnableAxisXScrolling = true;
            xyDiagram.EnableAxisYZooming = true;
            xyDiagram.EnableAxisYScrolling = true;
            xyDiagram.Rotated = true;
            xyDiagram.AxisX.Reverse = true;
            chartControlGodograph.CrosshairOptions.ShowArgumentLine = true;

            /*IDictionaryEnumerator denum = info.GetEnumerator();
            DictionaryEntry dentry;
            while (denum.MoveNext())
            {
                dentry = (DictionaryEntry)denum.Current;
                MessageBox.Show(Convert.ToString(dentry.Key), Convert.ToString(dentry.Value));
            }*/
        }
    }
}
