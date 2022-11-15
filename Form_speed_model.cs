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
            this.ControlBox = false;
            dataGridView1.AllowUserToAddRows = true;

            double[,] db_array = new double[Database.get_amount_rows_velocity(), 3];
            db_array = Database.get_velocity();

            for (int i = 0; i < db_array.GetLength(0); i++)
            {
                dataGridView1.Rows.Add(db_array[i, 0], db_array[i, 2]);
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
            Database.clear_table(Database.VELOCITY_TABLENAME);

            double h_top = 0;
            double h_bottom = 0;
            double vp = 0;
            int i = 0;

            dataGridView1.AllowUserToAddRows = false;

            double[,] array_grid = new double[dataGridView1.RowCount, 2];

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Cells["h_top"].Value != null)
                {
                    h_top = Convert.ToDouble(r.Cells["h_top"].Value.ToString());
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }
                if (r.Cells["vp"].Value != null)
                {
                    vp = Convert.ToDouble(r.Cells["vp"].Value.ToString());
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }

                array_grid[i, 0] = h_top;
                array_grid[i, 1] = vp;
                i++;
            }

            for (i = 0; i < array_grid.GetLength(0); i++)
            {
                if (i == array_grid.GetLength(0) - 1)
                {
                    h_top = array_grid[i, 0];
                    h_bottom = array_grid[i, 0] - 1;
                    vp = array_grid[i, 1];
                }
                else 
                {
                    h_top = array_grid[i, 0];
                    h_bottom = array_grid[i + 1, 0];
                    vp = array_grid[i, 1];
                }                
                Database.add_row_in_table_velocity(h_top, h_bottom, vp);
            }
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
