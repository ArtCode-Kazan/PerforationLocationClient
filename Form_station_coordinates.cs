using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seisapp
{
    public partial class Form_station_coordinates : Form
    {
        public Form_station_coordinates()
        {
            InitializeComponent();
            this.ControlBox = false;
            dataGridView1.AllowUserToAddRows = true;

            double[,] array = new double[Database.GetAmountRowsStationCoordinates(), 4];
            array = Database.GetStations();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int number = Convert.ToInt32(array[i, 0]);
                double x = array[i, 1];
                double y = array[i, 2];
                double altitude = array[i, 3];
                dataGridView1.Rows.Add(number, x, y, altitude);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dont click at labels");
        }


        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_open_file_Click(object sender, EventArgs e)
        {
            //open file
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Txt file (*.*)|*.txt*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;
            string path_to_file = "";
            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = choofdlog.FileName;
                path_to_file = choofdlog.FileName;
            }
            //grid table clearing
            dataGridView1.Rows.Clear();
            //parsing txt
            StreamReader reader = File.OpenText(path_to_file);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split('\t');
                if (Int32.TryParse(items[0], out int result) == true)
                {
                    int number = int.Parse(items[0]);
                    double x = double.Parse(items[1]);
                    double y = double.Parse(items[2]);
                    double altitude = double.Parse(items[3]);
                    dataGridView1.Rows.Add(number, x, y, altitude);
                }
                else
                {
                }
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Database.ClearTable(Database.StationCoordinatesTableName);

            int number = 0;
            double x = 0;
            double y = 0;
            double altitude = 0;            

            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Cells["number"].Value != null)
                {
                    number = Convert.ToInt32(r.Cells["number"].Value);
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }
                if (r.Cells["x"].Value != null)
                {
                    string stroka = Convert.ToString(r.Cells["x"].Value).Replace(',', '.');                                        
                    Double.TryParse(stroka, NumberStyles.Any, CultureInfo.InvariantCulture, out x);
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }
                if (r.Cells["y"].Value != null)
                {                   
                    string stroka = Convert.ToString(r.Cells["y"].Value).Replace(',', '.');
                    Double.TryParse(stroka, NumberStyles.Any, CultureInfo.InvariantCulture, out y);
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }
                if (r.Cells["altitude"].Value != null)
                {                    
                    string stroka = Convert.ToString(r.Cells["altitude"].Value).Replace(',', '.');
                    Double.TryParse(stroka, NumberStyles.Any, CultureInfo.InvariantCulture, out altitude);
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }

                Database.AddRowInStationCoordinates(number, x, y, altitude);
            }
            Close();
        }
    }
}
