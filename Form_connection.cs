using Microsoft.Data.Sqlite;
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
    public partial class Form_connection : Form
    {
        public Form_connection()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string ip = textBox1.Text;
            if (!int.TryParse(textBox2.Text, out int port))
            {
                MessageBox.Show("Введите правильные значения");
                textBox2.Text = "";
            }            
            Database.refresh_row_in_table_settings(ip, port);
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
