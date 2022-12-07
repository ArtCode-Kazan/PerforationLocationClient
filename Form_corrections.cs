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
            // Get calibration explosion coordinates
            string[,] calibrationExplosion = new string[Database.GetAmountRowsCalibrationExplosion(), 4];
            calibrationExplosion = Database.GetCalibrationExplosion();
            spinEditCalibrationX.Value = Convert.ToDecimal(calibrationExplosion[0, 1]);
            spinEditCalibrationY.Value = Convert.ToDecimal(calibrationExplosion[0, 2]);
            spinEditCalibrationAltitude.Value = Convert.ToDecimal(calibrationExplosion[0, 3]);
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
