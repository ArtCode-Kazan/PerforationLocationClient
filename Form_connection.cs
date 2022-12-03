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
        static bool CheckIp(string address)
        {
            var nums = address.Split('.');            
            return nums.Length == 4 && nums.All(n => int.TryParse(n, out int x)) &&
                   nums.Select(int.Parse).All(n => n < 256);
        }
        static bool CheckPort(string port)
        {
            return !int.TryParse(port, out int x);
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            string ip = textBoxIpAddress.Text;
            string port = textBoxPort.Text;
            
            if (CheckIp(ip) == false)
            {
                MessageBox.Show("Введите правильное значение ip");
                textBoxIpAddress.Text = "";
            }
            
            if (CheckPort(port) == false)
            {
                MessageBox.Show("Введите правильное значение порта");
                textBoxPort.Text = "";
            }
            
            Database.RefreshSettings(ip, Convert.ToInt32(port));
            Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
