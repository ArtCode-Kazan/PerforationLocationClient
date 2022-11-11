using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }
    }
}
