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
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                path_to_file = folderBrowserDialog1.SelectedPath;
            }



            string[] oo_files = Directory.GetFiles(path_to_file, "*.00", SearchOption.AllDirectories);
            string[] xx_files = Directory.GetFiles(path_to_file, "*.xx", SearchOption.AllDirectories);
            string[] bin_files = Directory.GetFiles(path_to_file, "*.bin", SearchOption.AllDirectories);
            
            string[] all_files =  oo_files.Concat(xx_files).ToArray();
            all_files = all_files.Concat(bin_files).ToArray();

            for (int i = 0; i < all_files.Length; i++)
            {
                dataGridView1.Rows.Add("1", all_files[i]);
            }
        } 
    }
}
