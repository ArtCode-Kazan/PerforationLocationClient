namespace seisapp
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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.proccessingToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openProjectToolStripMenuItem.Text = "New project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveProjectToolStripMenuItem.Text = "Open project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
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
            this.stationCoordinatesToolStripMenuItem.Name = "stationCoordinatesToolStripMenuItem";
            this.stationCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stationCoordinatesToolStripMenuItem.Text = "Station coordinates";
            this.stationCoordinatesToolStripMenuItem.Click += new System.EventHandler(this.stationCoordinatesToolStripMenuItem_Click);
            // 
            // seismicRecordsToolStripMenuItem
            // 
            this.seismicRecordsToolStripMenuItem.Name = "seismicRecordsToolStripMenuItem";
            this.seismicRecordsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.seismicRecordsToolStripMenuItem.Text = "Seismic records";
            this.seismicRecordsToolStripMenuItem.Click += new System.EventHandler(this.seismicRecordsToolStripMenuItem_Click);
            // 
            // clearDataToolStripMenuItem
            // 
            this.clearDataToolStripMenuItem.Name = "clearDataToolStripMenuItem";
            this.clearDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.peakTracesToolStripMenuItem.Name = "peakTracesToolStripMenuItem";
            this.peakTracesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.peakTracesToolStripMenuItem.Text = "Peak traces";
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
            this.speedModelToolStripMenuItem.Name = "speedModelToolStripMenuItem";
            this.speedModelToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.speedModelToolStripMenuItem.Text = "Speed model";
            this.speedModelToolStripMenuItem.Click += new System.EventHandler(this.speedModelToolStripMenuItem_Click);
            // 
            // correctionsToolStripMenuItem
            // 
            this.correctionsToolStripMenuItem.Name = "correctionsToolStripMenuItem";
            this.correctionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.correctionsToolStripMenuItem.Text = "Corrections";
            this.correctionsToolStripMenuItem.Click += new System.EventHandler(this.correctionsToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "seisapp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

