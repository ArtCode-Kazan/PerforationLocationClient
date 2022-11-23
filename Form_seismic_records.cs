using DevExpress.Utils.Extensions;
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
using static seisapp.Operations;

namespace seisapp
{
    public partial class Form_seismic_records : Form
    {        
        public Form_seismic_records()
        {
            InitializeComponent();            
            string[,] array = new string[Database.get_amount_rows_seismic_records(), 6];
            array = Database.get_seismic_records();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                string number = array[i, 1];
                string name = array[i, 3];
                string path = array[i,2];
                dataGridViewSeismicRecords.Rows.Add(number, name, path);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Database.clear_table(Database.SEISMIC_RECORDS_TABLENAME);
            int number = 0;
            dataGridViewSeismicRecords.AllowUserToAddRows = false;
            foreach (DataGridViewRow r in dataGridViewSeismicRecords.Rows)
            {
                if (Int32.TryParse(Convert.ToString(r.Cells["number"].Value), out number))
                {
                    number = Convert.ToInt32(r.Cells["number"].Value);
                    string file = Convert.ToString(r.Cells["file"].Value);
                    string path = Convert.ToString(r.Cells["path"].Value);
                    

                    Binary_File binFile = new Binary_File(path + "/" + file);
                    DateTime datetimeStop = binFile.datetime_stop;
                    DateTime datetimeStart = binFile.datetime_start;
                    
                    Database.add_row_in_table_seismic_records(number, file, path, datetimeStart, datetimeStop);
                }                                                
            }
            dataGridViewSeismicRecords.AllowUserToAddRows = true;
            Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            //open file
            FolderBrowserDialog choofdlog = new FolderBrowserDialog(); 

            string pathToFile = "";
            int number = 0;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxLoadFromFolder.Text = folderBrowserDialog1.SelectedPath;
                pathToFile = folderBrowserDialog1.SelectedPath;
            }

            dataGridViewSeismicRecords.Rows.Clear();

            string[] ooFiles = Directory.GetFiles(pathToFile, "*.00", SearchOption.AllDirectories);
            string[] xxFiles = Directory.GetFiles(pathToFile, "*.xx", SearchOption.AllDirectories);
            string[] binFiles = Directory.GetFiles(pathToFile, "*.bin", SearchOption.AllDirectories);
            
            string[] allFiles =  ooFiles.Concat(xxFiles).ToArray();
            allFiles = allFiles.Concat(binFiles).ToArray();

            double[,] array = Database.get_stations();

            string[] stationNumbers = new string[array.GetLength(0)];

            for (int i = 0; i < stationNumbers.Length; i++)
            {
                stationNumbers[i] = Convert.ToString(array[i, 0]);
            }
            
            for (int i = 0; i < allFiles.Length; i++)
            {
                FileInfo file = new FileInfo(allFiles[i]);
                string currentNumber = file.Name.Substring(0, file.Name.IndexOf('_'));
                if (Int32.TryParse(currentNumber, out number))
                {
                    if (stationNumbers.Contains(currentNumber))
                    {
                    }
                    else
                    {
                        number = 0;
                    }
                    dataGridViewSeismicRecords.Rows.Add(number, file.Name, file.DirectoryName);
                }
                else 
                {
                    dataGridViewSeismicRecords.Rows.Add("", file.Name, file.DirectoryName);
                }                
            }
            dataGridViewSeismicRecords.Sort(dataGridViewSeismicRecords.Columns["number"], ListSortDirection.Ascending);
        }

        private void dataGridViewSeismicRecords_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewSeismicRecords.AllowUserToAddRows = false;
            foreach (DataGridViewRow r in dataGridViewSeismicRecords.Rows)
            {

                double[,] array = Database.get_stations();
                string[] stationNumbers = new string[array.GetLength(0)];

                for (int i = 0; i < stationNumbers.Length; i++)
                {
                    stationNumbers[i] = Convert.ToString(array[i, 0]);
                }
                string number = Convert.ToString(r.Cells["number"].Value);
                if (number != "")
                {
                    if (stationNumbers.Contains(number))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Номера " + number + " нет в таблице");
                        r.Cells["number"].Value = DBNull.Value;
                    }
                }
            }
            dataGridViewSeismicRecords.AllowUserToAddRows = true;
        }
    }
}
