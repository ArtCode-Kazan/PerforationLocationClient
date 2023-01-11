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
            this.staticCorrectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_artcode = new System.Windows.Forms.Label();
            this.pictureBox_date = new System.Windows.Forms.PictureBox();
            this.labelDataStartInDateMenu = new System.Windows.Forms.Label();
            this.labelDataStopInDateMenu = new System.Windows.Forms.Label();
            this.labelComponentInDateMenu = new System.Windows.Forms.Label();
            this.comboBoxChooseComponent = new System.Windows.Forms.ComboBox();
            this.labelDateInDateMenu = new System.Windows.Forms.Label();
            this.pictureBox_furier_filter = new System.Windows.Forms.PictureBox();
            this.labellabelFurierFilterInFurierFilter = new System.Windows.Forms.Label();
            this.spinEdit_furier_min_frequency = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_furier_max_frequency = new DevExpress.XtraEditors.SpinEdit();
            this.labelFurierMinFrequencyInFurierFilter = new System.Windows.Forms.Label();
            this.labelFurierMaxFrequencyInFurierFilter = new System.Windows.Forms.Label();
            this.buttonDrawTraces = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStop = new System.Windows.Forms.DateTimePicker();
            this.pictureBox_stalta_filter = new System.Windows.Forms.PictureBox();
            this.labelStaLtaFilterInStaltaFilterMenu = new System.Windows.Forms.Label();
            this.labelStaltaFilterMinFrequencyInStaLtaFilterMenu = new System.Windows.Forms.Label();
            this.spinEdit_stalta_filter_min_frequency = new DevExpress.XtraEditors.SpinEdit();
            this.labelStaltaFilterMaxFrequencyInStaLtaFilterMenu = new System.Windows.Forms.Label();
            this.spinEdit_stalta_filter_max_frequency = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_stalta_filter_order = new DevExpress.XtraEditors.SpinEdit();
            this.labelStaltaFilterOrderInStaLtaFilterMenu = new System.Windows.Forms.Label();
            this.spinEditSetFrequency = new DevExpress.XtraEditors.SpinEdit();
            this.chartControlSignals = new DevExpress.XtraCharts.ChartControl();
            this.dataGridViewLatency = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSaveLatency = new System.Windows.Forms.Button();
            this.buttonClearLatency = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_furier_filter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_furier_min_frequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_furier_max_frequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stalta_filter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_min_frequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_max_frequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_order.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditSetFrequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlSignals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLatency)).BeginInit();
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
            this.connectionToolStripMenuItem,
            this.staticCorrectionsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Settings";
            // 
            // speedModelToolStripMenuItem
            // 
            this.speedModelToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.speedModelToolStripMenuItem.Name = "speedModelToolStripMenuItem";
            this.speedModelToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.speedModelToolStripMenuItem.Text = "Speed model";
            this.speedModelToolStripMenuItem.Click += new System.EventHandler(this.speedModelToolStripMenuItem_Click);
            // 
            // correctionsToolStripMenuItem
            // 
            this.correctionsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.correctionsToolStripMenuItem.Name = "correctionsToolStripMenuItem";
            this.correctionsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.correctionsToolStripMenuItem.Text = "Corrections";
            this.correctionsToolStripMenuItem.Click += new System.EventHandler(this.correctionsToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // staticCorrectionsToolStripMenuItem
            // 
            this.staticCorrectionsToolStripMenuItem.Name = "staticCorrectionsToolStripMenuItem";
            this.staticCorrectionsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.staticCorrectionsToolStripMenuItem.Text = "Static corrections";
            this.staticCorrectionsToolStripMenuItem.Click += new System.EventHandler(this.staticCorrectionsToolStripMenuItem_Click);
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
            // labelDataStartInDateMenu
            // 
            this.labelDataStartInDateMenu.AutoSize = true;
            this.labelDataStartInDateMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.labelDataStartInDateMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDataStartInDateMenu.Location = new System.Drawing.Point(23, 85);
            this.labelDataStartInDateMenu.Name = "labelDataStartInDateMenu";
            this.labelDataStartInDateMenu.Size = new System.Drawing.Size(32, 15);
            this.labelDataStartInDateMenu.TabIndex = 3;
            this.labelDataStartInDateMenu.Text = "Start";
            // 
            // labelDataStopInDateMenu
            // 
            this.labelDataStopInDateMenu.AutoSize = true;
            this.labelDataStopInDateMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.labelDataStopInDateMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDataStopInDateMenu.Location = new System.Drawing.Point(200, 85);
            this.labelDataStopInDateMenu.Name = "labelDataStopInDateMenu";
            this.labelDataStopInDateMenu.Size = new System.Drawing.Size(32, 15);
            this.labelDataStopInDateMenu.TabIndex = 4;
            this.labelDataStopInDateMenu.Text = "Stop";
            // 
            // labelComponentInDateMenu
            // 
            this.labelComponentInDateMenu.AutoSize = true;
            this.labelComponentInDateMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.labelComponentInDateMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelComponentInDateMenu.Location = new System.Drawing.Point(391, 85);
            this.labelComponentInDateMenu.Name = "labelComponentInDateMenu";
            this.labelComponentInDateMenu.Size = new System.Drawing.Size(71, 15);
            this.labelComponentInDateMenu.TabIndex = 7;
            this.labelComponentInDateMenu.Text = "Component";
            // 
            // comboBoxChooseComponent
            // 
            this.comboBoxChooseComponent.FormattingEnabled = true;
            this.comboBoxChooseComponent.Items.AddRange(new object[] {
            "Z",
            "Y",
            "X"});
            this.comboBoxChooseComponent.Location = new System.Drawing.Point(463, 83);
            this.comboBoxChooseComponent.Name = "comboBoxChooseComponent";
            this.comboBoxChooseComponent.Size = new System.Drawing.Size(42, 21);
            this.comboBoxChooseComponent.TabIndex = 8;
            // 
            // labelDateInDateMenu
            // 
            this.labelDateInDateMenu.AutoSize = true;
            this.labelDateInDateMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.labelDateInDateMenu.Location = new System.Drawing.Point(232, 43);
            this.labelDateInDateMenu.Name = "labelDateInDateMenu";
            this.labelDateInDateMenu.Size = new System.Drawing.Size(30, 13);
            this.labelDateInDateMenu.TabIndex = 9;
            this.labelDateInDateMenu.Text = "Date";
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
            // labellabelFurierFilterInFurierFilter
            // 
            this.labellabelFurierFilterInFurierFilter.AutoSize = true;
            this.labellabelFurierFilterInFurierFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.labellabelFurierFilterInFurierFilter.Location = new System.Drawing.Point(934, 39);
            this.labellabelFurierFilterInFurierFilter.Name = "labellabelFurierFilterInFurierFilter";
            this.labellabelFurierFilterInFurierFilter.Size = new System.Drawing.Size(104, 13);
            this.labellabelFurierFilterInFurierFilter.TabIndex = 11;
            this.labellabelFurierFilterInFurierFilter.Text = "Furier bandpass filter";
            // 
            // spinEdit_furier_min_frequency
            // 
            this.spinEdit_furier_min_frequency.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_furier_min_frequency.Location = new System.Drawing.Point(975, 61);
            this.spinEdit_furier_min_frequency.Name = "spinEdit_furier_min_frequency";
            this.spinEdit_furier_min_frequency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_furier_min_frequency.Size = new System.Drawing.Size(100, 20);
            this.spinEdit_furier_min_frequency.TabIndex = 12;
            // 
            // spinEdit_furier_max_frequency
            // 
            this.spinEdit_furier_max_frequency.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_furier_max_frequency.Location = new System.Drawing.Point(975, 95);
            this.spinEdit_furier_max_frequency.Name = "spinEdit_furier_max_frequency";
            this.spinEdit_furier_max_frequency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_furier_max_frequency.Size = new System.Drawing.Size(100, 20);
            this.spinEdit_furier_max_frequency.TabIndex = 13;
            // 
            // labelFurierMinFrequencyInFurierFilter
            // 
            this.labelFurierMinFrequencyInFurierFilter.AutoSize = true;
            this.labelFurierMinFrequencyInFurierFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.labelFurierMinFrequencyInFurierFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFurierMinFrequencyInFurierFilter.Location = new System.Drawing.Point(890, 64);
            this.labelFurierMinFrequencyInFurierFilter.Name = "labelFurierMinFrequencyInFurierFilter";
            this.labelFurierMinFrequencyInFurierFilter.Size = new System.Drawing.Size(84, 15);
            this.labelFurierMinFrequencyInFurierFilter.TabIndex = 14;
            this.labelFurierMinFrequencyInFurierFilter.Text = "min frequency";
            // 
            // labelFurierMaxFrequencyInFurierFilter
            // 
            this.labelFurierMaxFrequencyInFurierFilter.AutoSize = true;
            this.labelFurierMaxFrequencyInFurierFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.labelFurierMaxFrequencyInFurierFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFurierMaxFrequencyInFurierFilter.Location = new System.Drawing.Point(890, 98);
            this.labelFurierMaxFrequencyInFurierFilter.Name = "labelFurierMaxFrequencyInFurierFilter";
            this.labelFurierMaxFrequencyInFurierFilter.Size = new System.Drawing.Size(87, 15);
            this.labelFurierMaxFrequencyInFurierFilter.TabIndex = 15;
            this.labelFurierMaxFrequencyInFurierFilter.Text = "max frequency";
            // 
            // buttonDrawTraces
            // 
            this.buttonDrawTraces.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.buttonDrawTraces.Location = new System.Drawing.Point(483, 613);
            this.buttonDrawTraces.Name = "buttonDrawTraces";
            this.buttonDrawTraces.Size = new System.Drawing.Size(139, 39);
            this.buttonDrawTraces.TabIndex = 17;
            this.buttonDrawTraces.Text = "LESGO";
            this.buttonDrawTraces.UseVisualStyleBackColor = false;
            this.buttonDrawTraces.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(58, 84);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(136, 20);
            this.dateTimePickerStart.TabIndex = 19;
            // 
            // dateTimePickerStop
            // 
            this.dateTimePickerStop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStop.Location = new System.Drawing.Point(235, 84);
            this.dateTimePickerStop.Name = "dateTimePickerStop";
            this.dateTimePickerStop.Size = new System.Drawing.Size(141, 20);
            this.dateTimePickerStop.TabIndex = 20;
            // 
            // pictureBox_stalta_filter
            // 
            this.pictureBox_stalta_filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.pictureBox_stalta_filter.Location = new System.Drawing.Point(665, 36);
            this.pictureBox_stalta_filter.Name = "pictureBox_stalta_filter";
            this.pictureBox_stalta_filter.Size = new System.Drawing.Size(202, 94);
            this.pictureBox_stalta_filter.TabIndex = 21;
            this.pictureBox_stalta_filter.TabStop = false;
            // 
            // labelStaLtaFilterInStaltaFilterMenu
            // 
            this.labelStaLtaFilterInStaltaFilterMenu.AutoSize = true;
            this.labelStaLtaFilterInStaltaFilterMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.labelStaLtaFilterInStaltaFilterMenu.Location = new System.Drawing.Point(720, 39);
            this.labelStaLtaFilterInStaltaFilterMenu.Name = "labelStaLtaFilterInStaltaFilterMenu";
            this.labelStaLtaFilterInStaltaFilterMenu.Size = new System.Drawing.Size(73, 13);
            this.labelStaLtaFilterInStaltaFilterMenu.TabIndex = 22;
            this.labelStaLtaFilterInStaltaFilterMenu.Text = "STA LTA filter";
            // 
            // labelStaltaFilterMinFrequencyInStaLtaFilterMenu
            // 
            this.labelStaltaFilterMinFrequencyInStaLtaFilterMenu.AutoSize = true;
            this.labelStaltaFilterMinFrequencyInStaLtaFilterMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.labelStaltaFilterMinFrequencyInStaLtaFilterMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStaltaFilterMinFrequencyInStaLtaFilterMenu.Location = new System.Drawing.Point(670, 58);
            this.labelStaltaFilterMinFrequencyInStaLtaFilterMenu.Name = "labelStaltaFilterMinFrequencyInStaLtaFilterMenu";
            this.labelStaltaFilterMinFrequencyInStaLtaFilterMenu.Size = new System.Drawing.Size(79, 15);
            this.labelStaltaFilterMinFrequencyInStaLtaFilterMenu.TabIndex = 24;
            this.labelStaltaFilterMinFrequencyInStaLtaFilterMenu.Text = "short window";
            // 
            // spinEdit_stalta_filter_min_frequency
            // 
            this.spinEdit_stalta_filter_min_frequency.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_stalta_filter_min_frequency.Location = new System.Drawing.Point(758, 57);
            this.spinEdit_stalta_filter_min_frequency.Name = "spinEdit_stalta_filter_min_frequency";
            this.spinEdit_stalta_filter_min_frequency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_stalta_filter_min_frequency.Size = new System.Drawing.Size(100, 20);
            this.spinEdit_stalta_filter_min_frequency.TabIndex = 23;
            // 
            // labelStaltaFilterMaxFrequencyInStaLtaFilterMenu
            // 
            this.labelStaltaFilterMaxFrequencyInStaLtaFilterMenu.AutoSize = true;
            this.labelStaltaFilterMaxFrequencyInStaLtaFilterMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.labelStaltaFilterMaxFrequencyInStaLtaFilterMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStaltaFilterMaxFrequencyInStaLtaFilterMenu.Location = new System.Drawing.Point(670, 82);
            this.labelStaltaFilterMaxFrequencyInStaLtaFilterMenu.Name = "labelStaltaFilterMaxFrequencyInStaLtaFilterMenu";
            this.labelStaltaFilterMaxFrequencyInStaLtaFilterMenu.Size = new System.Drawing.Size(76, 15);
            this.labelStaltaFilterMaxFrequencyInStaLtaFilterMenu.TabIndex = 25;
            this.labelStaltaFilterMaxFrequencyInStaLtaFilterMenu.Text = "long window";
            // 
            // spinEdit_stalta_filter_max_frequency
            // 
            this.spinEdit_stalta_filter_max_frequency.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_stalta_filter_max_frequency.Location = new System.Drawing.Point(758, 81);
            this.spinEdit_stalta_filter_max_frequency.Name = "spinEdit_stalta_filter_max_frequency";
            this.spinEdit_stalta_filter_max_frequency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_stalta_filter_max_frequency.Size = new System.Drawing.Size(100, 20);
            this.spinEdit_stalta_filter_max_frequency.TabIndex = 26;
            // 
            // spinEdit_stalta_filter_order
            // 
            this.spinEdit_stalta_filter_order.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_stalta_filter_order.Location = new System.Drawing.Point(758, 106);
            this.spinEdit_stalta_filter_order.Name = "spinEdit_stalta_filter_order";
            this.spinEdit_stalta_filter_order.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_stalta_filter_order.Size = new System.Drawing.Size(100, 20);
            this.spinEdit_stalta_filter_order.TabIndex = 27;
            // 
            // labelStaltaFilterOrderInStaLtaFilterMenu
            // 
            this.labelStaltaFilterOrderInStaLtaFilterMenu.AutoSize = true;
            this.labelStaltaFilterOrderInStaLtaFilterMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.labelStaltaFilterOrderInStaLtaFilterMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStaltaFilterOrderInStaLtaFilterMenu.Location = new System.Drawing.Point(670, 107);
            this.labelStaltaFilterOrderInStaLtaFilterMenu.Name = "labelStaltaFilterOrderInStaLtaFilterMenu";
            this.labelStaltaFilterOrderInStaLtaFilterMenu.Size = new System.Drawing.Size(36, 15);
            this.labelStaltaFilterOrderInStaLtaFilterMenu.TabIndex = 28;
            this.labelStaltaFilterOrderInStaLtaFilterMenu.Text = "order";
            // 
            // spinEditSetFrequency
            // 
            this.spinEditSetFrequency.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditSetFrequency.Location = new System.Drawing.Point(533, 87);
            this.spinEditSetFrequency.Name = "spinEditSetFrequency";
            this.spinEditSetFrequency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditSetFrequency.Size = new System.Drawing.Size(100, 20);
            this.spinEditSetFrequency.TabIndex = 29;
            this.spinEditSetFrequency.EditValueChanged += new System.EventHandler(this.spinEdit_frequency_EditValueChanged);
            // 
            // chartControlSignals
            // 
            this.chartControlSignals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartControlSignals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chartControlSignals.BorderOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chartControlSignals.BorderOptions.Thickness = 2;
            this.chartControlSignals.CrosshairOptions.CrosshairLabelMode = DevExpress.XtraCharts.CrosshairLabelMode.ShowForNearestSeries;
            this.chartControlSignals.CrosshairOptions.GroupHeaderPattern = "{S}";
            this.chartControlSignals.CrosshairOptions.ShowArgumentLabels = true;
            this.chartControlSignals.CrosshairOptions.ShowGroupHeaders = false;
            this.chartControlSignals.CrosshairOptions.ShowOutOfRangePoints = true;
            this.chartControlSignals.Location = new System.Drawing.Point(12, 170);
            this.chartControlSignals.Name = "chartControlSignals";
            this.chartControlSignals.PaletteName = "Палитра1";
            this.chartControlSignals.PaletteRepository.Add("Палитра1", new DevExpress.XtraCharts.Palette("Палитра1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(65)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(65)))), ((int)(((byte)(71))))))}));
            this.chartControlSignals.RuntimeHitTesting = true;
            this.chartControlSignals.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControlSignals.Size = new System.Drawing.Size(821, 413);
            this.chartControlSignals.TabIndex = 16;
            this.chartControlSignals.Click += new System.EventHandler(this.chartControl1_Click);
            // 
            // dataGridViewLatency
            // 
            this.dataGridViewLatency.AllowUserToAddRows = false;
            this.dataGridViewLatency.AllowUserToDeleteRows = false;
            this.dataGridViewLatency.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.dataGridViewLatency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLatency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.latency});
            this.dataGridViewLatency.Location = new System.Drawing.Point(844, 170);
            this.dataGridViewLatency.Name = "dataGridViewLatency";
            this.dataGridViewLatency.RowHeadersVisible = false;
            this.dataGridViewLatency.Size = new System.Drawing.Size(240, 368);
            this.dataGridViewLatency.TabIndex = 30;
            // 
            // number
            // 
            this.number.HeaderText = "number";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 118;
            // 
            // latency
            // 
            this.latency.HeaderText = "latency";
            this.latency.Name = "latency";
            this.latency.ReadOnly = true;
            this.latency.Width = 119;
            // 
            // buttonSaveLatency
            // 
            this.buttonSaveLatency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.buttonSaveLatency.Location = new System.Drawing.Point(844, 544);
            this.buttonSaveLatency.Name = "buttonSaveLatency";
            this.buttonSaveLatency.Size = new System.Drawing.Size(116, 39);
            this.buttonSaveLatency.TabIndex = 32;
            this.buttonSaveLatency.Text = "Save";
            this.buttonSaveLatency.UseVisualStyleBackColor = false;
            this.buttonSaveLatency.Click += new System.EventHandler(this.buttonSaveLatency_Click);
            // 
            // buttonClearLatency
            // 
            this.buttonClearLatency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.buttonClearLatency.Location = new System.Drawing.Point(968, 544);
            this.buttonClearLatency.Name = "buttonClearLatency";
            this.buttonClearLatency.Size = new System.Drawing.Size(116, 39);
            this.buttonClearLatency.TabIndex = 33;
            this.buttonClearLatency.Text = "Clear";
            this.buttonClearLatency.UseVisualStyleBackColor = false;
            this.buttonClearLatency.Click += new System.EventHandler(this.buttonClearLatency_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(805, 629);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(198)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1096, 664);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonClearLatency);
            this.Controls.Add(this.buttonSaveLatency);
            this.Controls.Add(this.dataGridViewLatency);
            this.Controls.Add(this.chartControlSignals);
            this.Controls.Add(this.spinEditSetFrequency);
            this.Controls.Add(this.labelStaltaFilterOrderInStaLtaFilterMenu);
            this.Controls.Add(this.spinEdit_stalta_filter_order);
            this.Controls.Add(this.spinEdit_stalta_filter_max_frequency);
            this.Controls.Add(this.labelStaltaFilterMaxFrequencyInStaLtaFilterMenu);
            this.Controls.Add(this.labelStaltaFilterMinFrequencyInStaLtaFilterMenu);
            this.Controls.Add(this.spinEdit_stalta_filter_min_frequency);
            this.Controls.Add(this.labelStaLtaFilterInStaltaFilterMenu);
            this.Controls.Add(this.pictureBox_stalta_filter);
            this.Controls.Add(this.dateTimePickerStop);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.buttonDrawTraces);
            this.Controls.Add(this.labelFurierMaxFrequencyInFurierFilter);
            this.Controls.Add(this.labelFurierMinFrequencyInFurierFilter);
            this.Controls.Add(this.spinEdit_furier_max_frequency);
            this.Controls.Add(this.spinEdit_furier_min_frequency);
            this.Controls.Add(this.labellabelFurierFilterInFurierFilter);
            this.Controls.Add(this.pictureBox_furier_filter);
            this.Controls.Add(this.labelDateInDateMenu);
            this.Controls.Add(this.comboBoxChooseComponent);
            this.Controls.Add(this.labelComponentInDateMenu);
            this.Controls.Add(this.labelDataStopInDateMenu);
            this.Controls.Add(this.labelDataStartInDateMenu);
            this.Controls.Add(this.pictureBox_date);
            this.Controls.Add(this.label_artcode);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "seisapp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_furier_filter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_furier_min_frequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_furier_max_frequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stalta_filter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_min_frequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_max_frequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_order.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditSetFrequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlSignals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLatency)).EndInit();
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
        private System.Windows.Forms.Label labelDataStartInDateMenu;
        private System.Windows.Forms.Label labelDataStopInDateMenu;
        private System.Windows.Forms.Label labelComponentInDateMenu;
        private System.Windows.Forms.ComboBox comboBoxChooseComponent;
        private System.Windows.Forms.Label labelDateInDateMenu;
        private System.Windows.Forms.PictureBox pictureBox_furier_filter;
        private System.Windows.Forms.Label labellabelFurierFilterInFurierFilter;
        private DevExpress.XtraEditors.SpinEdit spinEdit_furier_min_frequency;
        private DevExpress.XtraEditors.SpinEdit spinEdit_furier_max_frequency;
        private System.Windows.Forms.Label labelFurierMinFrequencyInFurierFilter;
        private System.Windows.Forms.Label labelFurierMaxFrequencyInFurierFilter;
        private System.Windows.Forms.Button buttonDrawTraces;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerStop;
        private System.Windows.Forms.PictureBox pictureBox_stalta_filter;
        private System.Windows.Forms.Label labelStaLtaFilterInStaltaFilterMenu;
        private System.Windows.Forms.Label labelStaltaFilterMinFrequencyInStaLtaFilterMenu;
        private DevExpress.XtraEditors.SpinEdit spinEdit_stalta_filter_min_frequency;
        private System.Windows.Forms.Label labelStaltaFilterMaxFrequencyInStaLtaFilterMenu;
        private DevExpress.XtraEditors.SpinEdit spinEdit_stalta_filter_max_frequency;
        private DevExpress.XtraEditors.SpinEdit spinEdit_stalta_filter_order;
        private System.Windows.Forms.Label labelStaltaFilterOrderInStaLtaFilterMenu;
        private DevExpress.XtraEditors.SpinEdit spinEditSetFrequency;
        private DevExpress.XtraCharts.ChartControl chartControlSignals;
        private System.Windows.Forms.DataGridView dataGridViewLatency;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn latency;
        private System.Windows.Forms.Button buttonSaveLatency;
        private System.Windows.Forms.Button buttonClearLatency;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem staticCorrectionsToolStripMenuItem;
    }
}

