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

namespace seisapp
{
    public partial class Form_speed_model : Form
    {
        public Form_speed_model()
        {
            InitializeComponent();
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
                if (Int32.TryParse(items[0], out int result) == true)
                {
                    array_txt[count, 0] = double.Parse(items[0]);
                    array_txt[count, 1] = double.Parse(items[1]);
                }
                else
                {

                }
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
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
