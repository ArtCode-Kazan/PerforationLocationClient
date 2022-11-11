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
    public partial class Form_corrections : Form
    {
        public Form_corrections()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime blow_datetime = new DateTime();
            double x = Convert.ToDouble(textBox2.Text);
            double y = Convert.ToDouble(textBox3.Text);
            double altitude = Convert.ToDouble(textBox4.Text);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
