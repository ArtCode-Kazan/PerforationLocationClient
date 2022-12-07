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
using System.Web.Script.Serialization;
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

        public class ServerOutputData
        {
            public bool status { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public Correction[] corrections { get; set; }
        }

        public class Correction
        {
            public int station_number { get; set; }
            public float value { get; set; }
        }


        private void buttonGetCorrections_Click(object sender, EventArgs e)
        {
            // Get station coordinate
            double[,] stationCoordinates = new double[Database.GetAmountRowsStationCoordinates(), 4];
            stationCoordinates = Database.GetStationCoordinates();
            int stationAmount = stationCoordinates.GetLength(0);
            // Get calibration explosion coordinates
            string[,] calibrationExplosion = new string[Database.GetAmountRowsCalibrationExplosion(), 4];
            calibrationExplosion = Database.GetCalibrationExplosion();
            double xBlowCoordinate = Convert.ToDouble(calibrationExplosion[0, 1]);
            double yBlowCoordinate = Convert.ToDouble(calibrationExplosion[0, 2]);
            double zBlowCoordinate = Convert.ToDouble(calibrationExplosion[0, 3]);
            // Get latencys
            double[,] latencyArray = new double[Database.GetAmountRowsLatency(), 2];
            latencyArray = Database.GetLatency();
            // Get velocity
            double[,] velocityArray = new double[Database.GetAmountRowsVelocity(), 3];
            velocityArray = Database.GetVelocity();

            Hashtable[] stations = new Hashtable[stationCoordinates.GetLength(0)];

            for (int i = 0; i < stationCoordinates.GetLength(0); i++)
            {
                var coordinate = new Hashtable();
                coordinate.Add("x", stationCoordinates[i, 1]);
                coordinate.Add("y", stationCoordinates[i, 2]);
                coordinate.Add("altitude", stationCoordinates[i, 3]);

                var station = new Hashtable();
                station.Add("number", stationCoordinates[i, 0]);
                station.Add("coordinate", coordinate);

                stations[i] = station;
            }

            var observationSystem = new Hashtable();
            observationSystem.Add("stations", stations);

            Hashtable[] layers = new Hashtable[velocityArray.GetLength(0)];

            for (int i = 0; i < velocityArray.GetLength(0); i++)
            {
                var altitudeInterval = new Hashtable();
                altitudeInterval.Add("min_val", velocityArray[i, 1]);
                altitudeInterval.Add("max_val", velocityArray[i, 0]);

                var layer = new Hashtable();
                layer.Add("altitude_interval", altitudeInterval);
                layer.Add("vp", velocityArray[i, 2]);

                layers[i] = layer;
            }

            var velocityModel = new Hashtable();
            velocityModel.Add("layers", layers);

            var seismicInformation = new Hashtable();
            seismicInformation.Add("observation_system", observationSystem);
            seismicInformation.Add("velocity_model", velocityModel);


            var options = new JsonSerializerOptions { WriteIndented = true, MaxDepth = 10 };
            string jsonString = JsonSerializer.Serialize(seismicInformation, options);


            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.1.7:8157/static-corrections");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
            }

            ServerOutputData output;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                output = JsonSerializer.Deserialize<ServerOutputData>(result);
            }

            double[,] distanceBetweenBlowNStations = new double[stationAmount, 3];
            // Fill distances array
            for (int i = 0; i < stationAmount; i++)
            {
                double number = Convert.ToDouble(stationCoordinates[i, 0]);
                double currentXCoordinate = Convert.ToDouble(stationCoordinates[i, 1]);
                double currentYCoordinate = Convert.ToDouble(stationCoordinates[i, 2]);
                double currentZCoordinate = Convert.ToDouble(stationCoordinates[i, 3]);

                double distance = Math.Pow((Math.Pow((currentXCoordinate - xBlowCoordinate), 2) + Math.Pow((currentYCoordinate - yBlowCoordinate), 2) + Math.Pow((currentZCoordinate - zBlowCoordinate), 2)), 0.5);

                distanceBetweenBlowNStations[i, 0] = number;
                distanceBetweenBlowNStations[i, 1] = distance;
                distanceBetweenBlowNStations[i, 2] = latencyArray[i, 1];
            }

            Series rawCollection = chartControlGodograph.Series["Raw"];
            for (int i = 0; i < stationAmount; i++)
            {
                rawCollection.Points.AddPoint(distanceBetweenBlowNStations[i, 1], distanceBetweenBlowNStations[i, 2]);
            }
            
            Series correctedCollection = chartControlGodograph.Series["Corrected"];
            int o = 0;
            foreach (Correction x in output.data.corrections)
            {
                correctedCollection.Points.AddPoint(distanceBetweenBlowNStations[o, 1], x.value);
                
                o++;
            }


            XYDiagram xyDiagram = (XYDiagram)chartControlGodograph.Diagram;
            xyDiagram.ZoomingOptions.AxisXMaxZoomPercent = 100000;
            xyDiagram.ZoomingOptions.AxisYMaxZoomPercent = 100000;
            xyDiagram.EnableAxisXZooming = true;
            xyDiagram.EnableAxisXScrolling = true;
            xyDiagram.EnableAxisYZooming = true;
            xyDiagram.EnableAxisYScrolling = true;
            xyDiagram.Rotated = false;            
            chartControlGodograph.CrosshairOptions.ShowArgumentLine = true;            
        }
    }
}
