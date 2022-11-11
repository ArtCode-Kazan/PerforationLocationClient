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
            int port = int.Parse(textBox2.Text);
            using (var connection = new SqliteConnection("Data Source=" + Database.path))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;              
                command.CommandText = "INSERT INTO settings (ip, port) VALUES ('" + ip + "', " + port + ")";
                command.ExecuteNonQuery();
            }
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
