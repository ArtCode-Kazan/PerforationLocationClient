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
            dateTimePickerBlowDateTime.CustomFormat = "dd.MM.yyyy hh:mm:ss";
        }       
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DateTime blowDatetime = dateTimePickerBlowDateTime.Value;
            double x = Convert.ToDouble(spinEditCalibrationX.Value);
            double y = Convert.ToDouble(spinEditCalibrationY.Value);
            double altitude = Convert.ToDouble(spinEditCalibrationAltitude.Value);

            Database.ClearTable(Database.CalibrationExplosionTableName);            
            Database.AddRowInCalibrationExplosion(blowDatetime, x, y, altitude);
            Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
