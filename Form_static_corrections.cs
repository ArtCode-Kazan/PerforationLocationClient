using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seisapp
{
    public partial class Form_static_corrections : Form
    {
        public Form_static_corrections()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            int number = 0;
            double vp = 0;
            foreach (DataGridViewRow r in dataGridViewCorrections.Rows)
            {
                if (r.Cells["number"].Value != null)
                {
                    number = Convert.ToInt32(Convert.ToString(r.Cells["number"].Value).Replace(',', '.'));
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }
                if (r.Cells["latency"].Value != null)
                {
                    string stroka = Convert.ToString(r.Cells["latency"].Value).Replace(',', '.');
                    Double.TryParse(stroka, NumberStyles.Any, CultureInfo.InvariantCulture, out vp);
                }
                else
                { MessageBox.Show("ПУСТАЯ ЯЧЕЙКА"); }

                Database.AddRowInLatency(number, vp);
            }
            UpdateCorrectionsDataGrid();
        }
        public void UpdateCorrectionsDataGrid()
        {
            dataGridViewCorrections.Rows.Clear();
            double[,] array = new double[Database.GetAmountRowsLatency(), 2];
            array = Database.GetLatency();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                double stationId = array[i, 0];
                double latency = array[i, 1];
                dataGridViewCorrections.Rows.Add(stationId, latency);
            }
        }
    }
}
