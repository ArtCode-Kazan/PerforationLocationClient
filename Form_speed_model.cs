using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Microsoft.Data.Sqlite;

namespace seisapp
{
    public partial class Form_speed_model : Form
    {
        public Form_speed_model()
        {
            InitializeComponent();
            Database.get_amount_rows_velocity();
            this.ControlBox = false;
            dataGridView1.AllowUserToAddRows = true;
            string sqlExpression = "SELECT * FROM velocity";
            using (var connection_out = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection_out.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection_out);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var h_top = reader.GetValue(0);                            
                            var vp = reader.GetValue(2);
                            dataGridView1.Rows.Add(h_top, vp);
                        }
                    }
                }
            }
            update_graph();
        }

        public void update_graph()
        {
            Series xy_collection = chartControl1.Series["xy_collection"];
            xy_collection.Points.Clear();
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                var h_top = r.Cells["h_top"].Value;
                var vp = r.Cells["vp"].Value;
                xy_collection.Points.AddPoint(Convert.ToInt32(h_top), Convert.ToInt32(vp));
            }
            dataGridView1.AllowUserToAddRows = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {            
            update_graph();
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
            string line;
            int count = 0;

            StreamReader reader = File.OpenText(path_to_file);
            var line_count = File.ReadLines(path_to_file).Count();

            double[,] array_txt = new double[line_count, 2];

            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split('\t');
                Double.TryParse(items[0], out array_txt[count, 0]);
                Double.TryParse(items[1], out array_txt[count, 1]);               
                count++;
            }

            for (int i = 0; i < array_txt.GetLength(0) - 1; i++)
            {
                double alt_top = array_txt[i, 0];
                double alt_bottom = array_txt[i + 1, 0];
                double vp = array_txt[i, 1];
                dataGridView1.Rows.Add(alt_top, alt_bottom, vp);
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection("Data Source=" + Database.PATH))
            {
                connection.Open();

                SqliteCommand command_del = new SqliteCommand("DELETE  FROM velocity", connection);
                command_del.ExecuteNonQuery();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                string h_top = "0";
                string h_bottom = "0";
                string vp = "0";

                dataGridView1.AllowUserToAddRows = false;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.Cells["h_top"].Value != null)
                    {
                        h_top = r.Cells["h_top"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("ПУСТАЯ ЯЧЕЙКА");
                    }
                    if (r.Cells["vp"].Value != null)
                    {
                        vp = r.Cells["vp"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("ПУСТАЯ ЯЧЕЙКА");
                    }

                    command.CommandText = "INSERT INTO velocity (h_top, h_bottom, vp) VALUES (" + h_top + ", " + h_bottom + "," + vp + ")";
                    command.ExecuteNonQuery();
                }
            }
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
