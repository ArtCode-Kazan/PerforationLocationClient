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
    public partial class Form_seismic_records : Form
    {
        static string[] station_numbers;

        public Form_seismic_records()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //open file
            FolderBrowserDialog choofdlog = new FolderBrowserDialog(); 

            string path_to_file = "";
            int number = 0;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                path_to_file = folderBrowserDialog1.SelectedPath;
            }

            dataGridView1.Rows.Clear();

            string[] oo_files = Directory.GetFiles(path_to_file, "*.00", SearchOption.AllDirectories);
            string[] xx_files = Directory.GetFiles(path_to_file, "*.xx", SearchOption.AllDirectories);
            string[] bin_files = Directory.GetFiles(path_to_file, "*.bin", SearchOption.AllDirectories);
            
            string[] all_files =  oo_files.Concat(xx_files).ToArray();
            all_files = all_files.Concat(bin_files).ToArray();

            double[,] array = Database.get_stations();

            station_numbers = new string[array.GetLength(0)];

            for (int i = 0; i < station_numbers.Length; i++)
            {
                station_numbers[i] = Convert.ToString(array[i, 0]);
            }
            
            for (int i = 0; i < all_files.Length; i++)
            {
                FileInfo file = new FileInfo(all_files[i]);
                string current_number = file.Name.Substring(0, file.Name.IndexOf('_'));
                if (Int32.TryParse(current_number, out number))
                {
                    if (station_numbers.Contains(current_number))
                    {
                    }
                    else
                    {
                        number = 0;
                    }
                    dataGridView1.Rows.Add(number, file.Name, file.DirectoryName);
                }
                else 
                {
                    dataGridView1.Rows.Add("", file.Name, file.DirectoryName);
                }                
            }
            dataGridView1.Sort(dataGridView1.Columns["number"], ListSortDirection.Ascending);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                string number = Convert.ToString(r.Cells["number"].Value);
                if (number != "")
                {
                    if (station_numbers.Contains(number))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Номера " + number + " нет в таблице");
                        r.Cells["number"].Value = DBNull.Value;
                    }
                }
            }
            dataGridView1.AllowUserToAddRows = true;
        }
    }
}
