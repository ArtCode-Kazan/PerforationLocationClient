﻿using DevExpress.Utils.Extensions;
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
            string[,] array = new string[Database.get_amount_rows_seismic_records(), 3];
            array = Database.get_seismic_records();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                string  number = array[i, 0];
                string name = array[i, 1];
                string path = array[i,2];
                dataGridView1.Rows.Add(number, name, path);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.clear_table(Database.SEISMIC_RECORDS_TABLENAME);
            int number = 0;
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (Int32.TryParse(Convert.ToString(r.Cells["number"].Value), out number))
                {
                    number = Convert.ToInt32(r.Cells["number"].Value);
                    string file = Convert.ToString(r.Cells["file"].Value);
                    string path = Convert.ToString(r.Cells["path"].Value);

                    string full_path = path + "/" + file;

                    Binary_File binfile = new Binary_File(full_path);
                    DateTime datetime_stop = binfile.datetime_stop;
                    DateTime datetime_start = binfile.datetime_start;
                    

                    Database.add_row_in_table_seismic_records(number, file, path, datetime_start, datetime_stop);

                    Binary_File example = new Binary_File(path);
                    //example.

                }                                                
            }
            dataGridView1.AllowUserToAddRows = true;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //open file
            FolderBrowserDialog choofdlog = new FolderBrowserDialog(); 

            string path_to_file = "";
            int number = 0;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                path_to_file = folderBrowserDialog1.SelectedPath;
            }

            dataGridView1.Rows.Clear();

            string[] oo_files = Directory.GetFiles(path_to_file, "*.00", SearchOption.AllDirectories);
            string[] xx_files = Directory.GetFiles(path_to_file, "*.xx", SearchOption.AllDirectories);
            string[] bin_files = Directory.GetFiles(path_to_file, "*.bin", SearchOption.AllDirectories);
            
            string[] all_files =  oo_files.Concat(xx_files).ToArray();
            all_files = all_files.Concat(bin_files).ToArray();

            double[,] array = Database.get_stations();

            string[] station_numbers = new string[array.GetLength(0)];

            for (int i = 0; i < station_numbers.Length; i++)
            {
                station_numbers[i] = Convert.ToString(array[i, 0]);
            }
            
            for (int i = 0; i < all_files.Length; i++)
            {
                FileInfo file = new FileInfo(all_files[i]);
                string current_number = file.Name.Substring(0, file.Name.IndexOf('_'));
                if (Int32.TryParse(current_number, out number))
                {
                    if (station_numbers.Contains(current_number))
                    {
                    }
                    else
                    {
                        number = 0;
                    }
                    dataGridView1.Rows.Add(number, file.Name, file.DirectoryName);
                }
                else 
                {
                    dataGridView1.Rows.Add("", file.Name, file.DirectoryName);
                }                
            }
            dataGridView1.Sort(dataGridView1.Columns["number"], ListSortDirection.Ascending);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                double[,] array = Database.get_stations();
                string[] station_numbers = new string[array.GetLength(0)];

                for (int i = 0; i < station_numbers.Length; i++)
                {
                    station_numbers[i] = Convert.ToString(array[i, 0]);
                }
                string number = Convert.ToString(r.Cells["number"].Value);
                if (number != "")
                {
                    if (station_numbers.Contains(number))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Номера " + number + " нет в таблице");
                        r.Cells["number"].Value = DBNull.Value;
                    }
                }
            }
            dataGridView1.AllowUserToAddRows = true;
        }
    }
}
