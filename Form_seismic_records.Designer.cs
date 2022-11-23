namespace seisapp
{
    partial class Form_seismic_records
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControlSeismicRecords = new DevExpress.XtraEditors.LabelControl();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelLoadFromFolder = new System.Windows.Forms.Label();
            this.textBoxLoadFromFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.dataGridViewSeismicRecords = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeismicRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControlSeismicRecords
            // 
            this.labelControlSeismicRecords.Location = new System.Drawing.Point(194, 13);
            this.labelControlSeismicRecords.Name = "labelControlSeismicRecords";
            this.labelControlSeismicRecords.Size = new System.Drawing.Size(73, 13);
            this.labelControlSeismicRecords.TabIndex = 0;
            this.labelControlSeismicRecords.Text = "Seismic records";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(144, 448);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(281, 447);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelLoadFromFolder
            // 
            this.labelLoadFromFolder.AutoSize = true;
            this.labelLoadFromFolder.Location = new System.Drawing.Point(20, 60);
            this.labelLoadFromFolder.Name = "labelLoadFromFolder";
            this.labelLoadFromFolder.Size = new System.Drawing.Size(86, 13);
            this.labelLoadFromFolder.TabIndex = 3;
            this.labelLoadFromFolder.Text = "Load from folder:";
            // 
            // textBoxLoadFromFolder
            // 
            this.textBoxLoadFromFolder.Location = new System.Drawing.Point(103, 57);
            this.textBoxLoadFromFolder.Name = "textBoxLoadFromFolder";
            this.textBoxLoadFromFolder.Size = new System.Drawing.Size(275, 20);
            this.textBoxLoadFromFolder.TabIndex = 4;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(376, 55);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 5;
            this.buttonBrowse.Text = "browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // dataGridViewSeismicRecords
            // 
            this.dataGridViewSeismicRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeismicRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.file,
            this.path});
            this.dataGridViewSeismicRecords.Location = new System.Drawing.Point(32, 102);
            this.dataGridViewSeismicRecords.Name = "dataGridViewSeismicRecords";
            this.dataGridViewSeismicRecords.RowHeadersVisible = false;
            this.dataGridViewSeismicRecords.Size = new System.Drawing.Size(418, 321);
            this.dataGridViewSeismicRecords.TabIndex = 6;
            this.dataGridViewSeismicRecords.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeismicRecords_CellValueChanged);
            // 
            // number
            // 
            this.number.HeaderText = "number";
            this.number.Name = "number";
            this.number.Width = 55;
            // 
            // file
            // 
            this.file.HeaderText = "file";
            this.file.Name = "file";
            this.file.ReadOnly = true;
            this.file.Width = 150;
            // 
            // path
            // 
            this.path.HeaderText = "path";
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.Width = 360;
            // 
            // Form_seismic_records
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 495);
            this.Controls.Add(this.dataGridViewSeismicRecords);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxLoadFromFolder);
            this.Controls.Add(this.labelLoadFromFolder);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelControlSeismicRecords);
            this.Name = "Form_seismic_records";
            this.Text = "seisapp";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeismicRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControlSeismicRecords;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelLoadFromFolder;
        private System.Windows.Forms.TextBox textBoxLoadFromFolder;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.DataGridView dataGridViewSeismicRecords;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn file;
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
    }
}