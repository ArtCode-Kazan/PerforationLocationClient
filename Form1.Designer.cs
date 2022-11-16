﻿namespace seisapp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stationCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seismicRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proccessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peakTracesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_artcode = new System.Windows.Forms.Label();
            this.pictureBox_date = new System.Windows.Forms.PictureBox();
            this.label_date_start = new System.Windows.Forms.Label();
            this.label_date_stop = new System.Windows.Forms.Label();
            this.textBox_date_start = new System.Windows.Forms.TextBox();
            this.textBox_date_stop = new System.Windows.Forms.TextBox();
            this.label_component = new System.Windows.Forms.Label();
            this.comboBox_component = new System.Windows.Forms.ComboBox();
            this.label_date = new System.Windows.Forms.Label();
            this.pictureBox_furier_filter = new System.Windows.Forms.PictureBox();
            this.label_furier_filter = new System.Windows.Forms.Label();
            this.spinEdit_min_frequency = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_max_frequency = new DevExpress.XtraEditors.SpinEdit();
            this.label_min_frequency = new System.Windows.Forms.Label();
            this.label_max_frequency = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_furier_filter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_min_frequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_max_frequency.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.proccessingToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1096, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openProjectToolStripMenuItem.Text = "New project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveProjectToolStripMenuItem.Text = "Open project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stationCoordinatesToolStripMenuItem,
            this.seismicRecordsToolStripMenuItem,
            this.clearDataToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // stationCoordinatesToolStripMenuItem
            // 
            this.stationCoordinatesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.stationCoordinatesToolStripMenuItem.Name = "stationCoordinatesToolStripMenuItem";
            this.stationCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.stationCoordinatesToolStripMenuItem.Text = "Station coordinates";
            this.stationCoordinatesToolStripMenuItem.Click += new System.EventHandler(this.stationCoordinatesToolStripMenuItem_Click);
            // 
            // seismicRecordsToolStripMenuItem
            // 
            this.seismicRecordsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.seismicRecordsToolStripMenuItem.Name = "seismicRecordsToolStripMenuItem";
            this.seismicRecordsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.seismicRecordsToolStripMenuItem.Text = "Seismic records";
            this.seismicRecordsToolStripMenuItem.Click += new System.EventHandler(this.seismicRecordsToolStripMenuItem_Click);
            // 
            // clearDataToolStripMenuItem
            // 
            this.clearDataToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.clearDataToolStripMenuItem.Name = "clearDataToolStripMenuItem";
            this.clearDataToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.clearDataToolStripMenuItem.Text = "Clear data";
            this.clearDataToolStripMenuItem.Click += new System.EventHandler(this.clearDataToolStripMenuItem_Click);
            // 
            // proccessingToolStripMenuItem
            // 
            this.proccessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peakTracesToolStripMenuItem});
            this.proccessingToolStripMenuItem.Name = "proccessingToolStripMenuItem";
            this.proccessingToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.proccessingToolStripMenuItem.Text = "Proccessing";
            // 
            // peakTracesToolStripMenuItem
            // 
            this.peakTracesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.peakTracesToolStripMenuItem.Name = "peakTracesToolStripMenuItem";
            this.peakTracesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.peakTracesToolStripMenuItem.Text = "Peak traces";
            this.peakTracesToolStripMenuItem.Click += new System.EventHandler(this.peakTracesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speedModelToolStripMenuItem,
            this.correctionsToolStripMenuItem,
            this.connectionToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Settings";
            // 
            // speedModelToolStripMenuItem
            // 
            this.speedModelToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.speedModelToolStripMenuItem.Name = "speedModelToolStripMenuItem";
            this.speedModelToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.speedModelToolStripMenuItem.Text = "Speed model";
            this.speedModelToolStripMenuItem.Click += new System.EventHandler(this.speedModelToolStripMenuItem_Click);
            // 
            // correctionsToolStripMenuItem
            // 
            this.correctionsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.correctionsToolStripMenuItem.Name = "correctionsToolStripMenuItem";
            this.correctionsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.correctionsToolStripMenuItem.Text = "Corrections";
            this.correctionsToolStripMenuItem.Click += new System.EventHandler(this.correctionsToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // label_artcode
            // 
            this.label_artcode.AutoSize = true;
            this.label_artcode.Font = new System.Drawing.Font("Kelly Slab", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_artcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.label_artcode.Location = new System.Drawing.Point(162, 202);
            this.label_artcode.Name = "label_artcode";
            this.label_artcode.Size = new System.Drawing.Size(778, 242);
            this.label_artcode.TabIndex = 1;
            this.label_artcode.Text = "ArtCode";
            // 
            // pictureBox_date
            // 
            this.pictureBox_date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.pictureBox_date.Location = new System.Drawing.Point(12, 36);
            this.pictureBox_date.Name = "pictureBox_date";
            this.pictureBox_date.Size = new System.Drawing.Size(505, 94);
            this.pictureBox_date.TabIndex = 2;
            this.pictureBox_date.TabStop = false;
            // 
            // label_date_start
            // 
            this.label_date_start.AutoSize = true;
            this.label_date_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.label_date_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_date_start.Location = new System.Drawing.Point(23, 85);
            this.label_date_start.Name = "label_date_start";
            this.label_date_start.Size = new System.Drawing.Size(32, 15);
            this.label_date_start.TabIndex = 3;
            this.label_date_start.Text = "Start";
            this.label_date_start.Click += new System.EventHandler(this.label_date_start_Click);
            // 
            // label_date_stop
            // 
            this.label_date_stop.AutoSize = true;
            this.label_date_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.label_date_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_date_stop.Location = new System.Drawing.Point(200, 85);
            this.label_date_stop.Name = "label_date_stop";
            this.label_date_stop.Size = new System.Drawing.Size(32, 15);
            this.label_date_stop.TabIndex = 4;
            this.label_date_stop.Text = "Stop";
            this.label_date_stop.Click += new System.EventHandler(this.label_date_stop_Click);
            // 
            // textBox_date_start
            // 
            this.textBox_date_start.Location = new System.Drawing.Point(58, 84);
            this.textBox_date_start.Name = "textBox_date_start";
            this.textBox_date_start.Size = new System.Drawing.Size(136, 20);
            this.textBox_date_start.TabIndex = 5;
            // 
            // textBox_date_stop
            // 
            this.textBox_date_stop.Location = new System.Drawing.Point(236, 84);
            this.textBox_date_stop.Name = "textBox_date_stop";
            this.textBox_date_stop.Size = new System.Drawing.Size(141, 20);
            this.textBox_date_stop.TabIndex = 6;
            // 
            // label_component
            // 
            this.label_component.AutoSize = true;
            this.label_component.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.label_component.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_component.Location = new System.Drawing.Point(391, 85);
            this.label_component.Name = "label_component";
            this.label_component.Size = new System.Drawing.Size(71, 15);
            this.label_component.TabIndex = 7;
            this.label_component.Text = "Component";
            this.label_component.Click += new System.EventHandler(this.label_component_Click);
            // 
            // comboBox_component
            // 
            this.comboBox_component.FormattingEnabled = true;
            this.comboBox_component.Location = new System.Drawing.Point(463, 83);
            this.comboBox_component.Name = "comboBox_component";
            this.comboBox_component.Size = new System.Drawing.Size(42, 21);
            this.comboBox_component.TabIndex = 8;
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.label_date.Location = new System.Drawing.Point(232, 43);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(30, 13);
            this.label_date.TabIndex = 9;
            this.label_date.Text = "Date";
            // 
            // pictureBox_furier_filter
            // 
            this.pictureBox_furier_filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.pictureBox_furier_filter.Location = new System.Drawing.Point(882, 36);
            this.pictureBox_furier_filter.Name = "pictureBox_furier_filter";
            this.pictureBox_furier_filter.Size = new System.Drawing.Size(202, 94);
            this.pictureBox_furier_filter.TabIndex = 10;
            this.pictureBox_furier_filter.TabStop = false;
            // 
            // label_furier_filter
            // 
            this.label_furier_filter.AutoSize = true;
            this.label_furier_filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.label_furier_filter.Location = new System.Drawing.Point(940, 43);
            this.label_furier_filter.Name = "label_furier_filter";
            this.label_furier_filter.Size = new System.Drawing.Size(104, 13);
            this.label_furier_filter.TabIndex = 11;
            this.label_furier_filter.Text = "Furier bandpass filter";
            // 
            // spinEdit_min_frequency
            // 
            this.spinEdit_min_frequency.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_min_frequency.Location = new System.Drawing.Point(975, 61);
            this.spinEdit_min_frequency.Name = "spinEdit_min_frequency";
            this.spinEdit_min_frequency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_min_frequency.Size = new System.Drawing.Size(100, 20);
            this.spinEdit_min_frequency.TabIndex = 12;
            // 
            // spinEdit_max_frequency
            // 
            this.spinEdit_max_frequency.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_max_frequency.Location = new System.Drawing.Point(975, 100);
            this.spinEdit_max_frequency.Name = "spinEdit_max_frequency";
            this.spinEdit_max_frequency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_max_frequency.Size = new System.Drawing.Size(100, 20);
            this.spinEdit_max_frequency.TabIndex = 13;
            // 
            // label_min_frequency
            // 
            this.label_min_frequency.AutoSize = true;
            this.label_min_frequency.Location = new System.Drawing.Point(890, 64);
            this.label_min_frequency.Name = "label_min_frequency";
            this.label_min_frequency.Size = new System.Drawing.Size(73, 13);
            this.label_min_frequency.TabIndex = 14;
            this.label_min_frequency.Text = "min frequency";
            // 
            // label_max_frequency
            // 
            this.label_max_frequency.AutoSize = true;
            this.label_max_frequency.Location = new System.Drawing.Point(890, 103);
            this.label_max_frequency.Name = "label_max_frequency";
            this.label_max_frequency.Size = new System.Drawing.Size(76, 13);
            this.label_max_frequency.TabIndex = 15;
            this.label_max_frequency.Text = "max frequency";
            this.label_max_frequency.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(198)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1096, 592);
            this.Controls.Add(this.label_max_frequency);
            this.Controls.Add(this.label_min_frequency);
            this.Controls.Add(this.spinEdit_max_frequency);
            this.Controls.Add(this.spinEdit_min_frequency);
            this.Controls.Add(this.label_furier_filter);
            this.Controls.Add(this.pictureBox_furier_filter);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.comboBox_component);
            this.Controls.Add(this.label_component);
            this.Controls.Add(this.textBox_date_stop);
            this.Controls.Add(this.textBox_date_start);
            this.Controls.Add(this.label_date_stop);
            this.Controls.Add(this.label_date_start);
            this.Controls.Add(this.pictureBox_date);
            this.Controls.Add(this.label_artcode);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "seisapp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_furier_filter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_min_frequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_max_frequency.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stationCoordinatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seismicRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proccessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peakTracesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem correctionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.Label label_artcode;
        private System.Windows.Forms.PictureBox pictureBox_date;
        private System.Windows.Forms.Label label_date_start;
        private System.Windows.Forms.Label label_date_stop;
        private System.Windows.Forms.TextBox textBox_date_start;
        private System.Windows.Forms.TextBox textBox_date_stop;
        private System.Windows.Forms.Label label_component;
        private System.Windows.Forms.ComboBox comboBox_component;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.PictureBox pictureBox_furier_filter;
        private System.Windows.Forms.Label label_furier_filter;
        private DevExpress.XtraEditors.SpinEdit spinEdit_min_frequency;
        private DevExpress.XtraEditors.SpinEdit spinEdit_max_frequency;
        private System.Windows.Forms.Label label_min_frequency;
        private System.Windows.Forms.Label label_max_frequency;
    }
}

