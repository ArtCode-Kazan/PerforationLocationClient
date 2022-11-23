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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
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
            this.label_component = new System.Windows.Forms.Label();
            this.comboBox_component = new System.Windows.Forms.ComboBox();
            this.label_date = new System.Windows.Forms.Label();
            this.pictureBox_furier_filter = new System.Windows.Forms.PictureBox();
            this.label_furier_filter = new System.Windows.Forms.Label();
            this.spinEdit_furier_min_frequency = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_furier_max_frequency = new DevExpress.XtraEditors.SpinEdit();
            this.label_min_frequency = new System.Windows.Forms.Label();
            this.label_max_frequency = new System.Windows.Forms.Label();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_stop = new System.Windows.Forms.DateTimePicker();
            this.pictureBox_stalta_filter = new System.Windows.Forms.PictureBox();
            this.label_stalta_filter = new System.Windows.Forms.Label();
            this.label_stalta_filter_min_frequency = new System.Windows.Forms.Label();
            this.spinEdit_stalta_filter_min_frequency = new DevExpress.XtraEditors.SpinEdit();
            this.label_stalta_filter_max_frequency = new System.Windows.Forms.Label();
            this.spinEdit_stalta_filter_max_frequency = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_stalta_filter_order = new DevExpress.XtraEditors.SpinEdit();
            this.label_stalta_filter_order = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_furier_filter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_furier_min_frequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_furier_max_frequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stalta_filter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_min_frequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_max_frequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_order.Properties)).BeginInit();
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
            // 
            // comboBox_component
            // 
            this.comboBox_component.FormattingEnabled = true;
            this.comboBox_component.Items.AddRange(new object[] {
            "Z",
            "Y",
            "X"});
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
            this.label_furier_filter.Location = new System.Drawing.Point(934, 39);
            this.label_furier_filter.Name = "label_furier_filter";
            this.label_furier_filter.Size = new System.Drawing.Size(104, 13);
            this.label_furier_filter.TabIndex = 11;
            this.label_furier_filter.Text = "Furier bandpass filter";
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
            // label_min_frequency
            // 
            this.label_min_frequency.AutoSize = true;
            this.label_min_frequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.label_min_frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_min_frequency.Location = new System.Drawing.Point(890, 64);
            this.label_min_frequency.Name = "label_min_frequency";
            this.label_min_frequency.Size = new System.Drawing.Size(84, 15);
            this.label_min_frequency.TabIndex = 14;
            this.label_min_frequency.Text = "min frequency";
            // 
            // label_max_frequency
            // 
            this.label_max_frequency.AutoSize = true;
            this.label_max_frequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.label_max_frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_max_frequency.Location = new System.Drawing.Point(890, 98);
            this.label_max_frequency.Name = "label_max_frequency";
            this.label_max_frequency.Size = new System.Drawing.Size(87, 15);
            this.label_max_frequency.TabIndex = 15;
            this.label_max_frequency.Text = "max frequency";
            // 
            // chartControl1
            // 
            this.chartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartControl1.CrosshairOptions.ShowOutOfRangePoints = true;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXZooming = true;
            xyDiagram1.EnableAxisYZooming = true;
            xyDiagram1.Rotated = true;
            xyDiagram1.ZoomingOptions.AxisXMaxZoomPercent = 100000D;
            xyDiagram1.ZoomingOptions.AxisYMaxZoomPercent = 100000D;
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.BottomToTop;
            this.chartControl1.Location = new System.Drawing.Point(0, 14);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "signal";
            series1.View = lineSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(745, 336);
            this.chartControl1.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.button1.Location = new System.Drawing.Point(475, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 39);
            this.button1.TabIndex = 17;
            this.button1.Text = "LESGO";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chartControl1);
            this.groupBox1.Location = new System.Drawing.Point(72, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 351);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_start.Location = new System.Drawing.Point(58, 84);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(136, 20);
            this.dateTimePicker_start.TabIndex = 19;
            // 
            // dateTimePicker_stop
            // 
            this.dateTimePicker_stop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_stop.Location = new System.Drawing.Point(235, 84);
            this.dateTimePicker_stop.Name = "dateTimePicker_stop";
            this.dateTimePicker_stop.Size = new System.Drawing.Size(141, 20);
            this.dateTimePicker_stop.TabIndex = 20;
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
            // label_stalta_filter
            // 
            this.label_stalta_filter.AutoSize = true;
            this.label_stalta_filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.label_stalta_filter.Location = new System.Drawing.Point(720, 39);
            this.label_stalta_filter.Name = "label_stalta_filter";
            this.label_stalta_filter.Size = new System.Drawing.Size(73, 13);
            this.label_stalta_filter.TabIndex = 22;
            this.label_stalta_filter.Text = "STA LTA filter";
            // 
            // label_stalta_filter_min_frequency
            // 
            this.label_stalta_filter_min_frequency.AutoSize = true;
            this.label_stalta_filter_min_frequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.label_stalta_filter_min_frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_stalta_filter_min_frequency.Location = new System.Drawing.Point(673, 60);
            this.label_stalta_filter_min_frequency.Name = "label_stalta_filter_min_frequency";
            this.label_stalta_filter_min_frequency.Size = new System.Drawing.Size(84, 15);
            this.label_stalta_filter_min_frequency.TabIndex = 24;
            this.label_stalta_filter_min_frequency.Text = "min frequency";
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
            // label_stalta_filter_max_frequency
            // 
            this.label_stalta_filter_max_frequency.AutoSize = true;
            this.label_stalta_filter_max_frequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.label_stalta_filter_max_frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_stalta_filter_max_frequency.Location = new System.Drawing.Point(673, 82);
            this.label_stalta_filter_max_frequency.Name = "label_stalta_filter_max_frequency";
            this.label_stalta_filter_max_frequency.Size = new System.Drawing.Size(87, 15);
            this.label_stalta_filter_max_frequency.TabIndex = 25;
            this.label_stalta_filter_max_frequency.Text = "max frequency";
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
            // label_stalta_filter_order
            // 
            this.label_stalta_filter_order.AutoSize = true;
            this.label_stalta_filter_order.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.label_stalta_filter_order.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_stalta_filter_order.Location = new System.Drawing.Point(673, 107);
            this.label_stalta_filter_order.Name = "label_stalta_filter_order";
            this.label_stalta_filter_order.Size = new System.Drawing.Size(36, 15);
            this.label_stalta_filter_order.TabIndex = 28;
            this.label_stalta_filter_order.Text = "order";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(198)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1096, 592);
            this.Controls.Add(this.label_stalta_filter_order);
            this.Controls.Add(this.spinEdit_stalta_filter_order);
            this.Controls.Add(this.spinEdit_stalta_filter_max_frequency);
            this.Controls.Add(this.label_stalta_filter_max_frequency);
            this.Controls.Add(this.label_stalta_filter_min_frequency);
            this.Controls.Add(this.spinEdit_stalta_filter_min_frequency);
            this.Controls.Add(this.label_stalta_filter);
            this.Controls.Add(this.pictureBox_stalta_filter);
            this.Controls.Add(this.dateTimePicker_stop);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_max_frequency);
            this.Controls.Add(this.label_min_frequency);
            this.Controls.Add(this.spinEdit_furier_max_frequency);
            this.Controls.Add(this.spinEdit_furier_min_frequency);
            this.Controls.Add(this.label_furier_filter);
            this.Controls.Add(this.pictureBox_furier_filter);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.comboBox_component);
            this.Controls.Add(this.label_component);
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
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_furier_min_frequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_furier_max_frequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stalta_filter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_min_frequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_max_frequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_stalta_filter_order.Properties)).EndInit();
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
        private System.Windows.Forms.Label label_component;
        private System.Windows.Forms.ComboBox comboBox_component;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.PictureBox pictureBox_furier_filter;
        private System.Windows.Forms.Label label_furier_filter;
        private DevExpress.XtraEditors.SpinEdit spinEdit_furier_min_frequency;
        private DevExpress.XtraEditors.SpinEdit spinEdit_furier_max_frequency;
        private System.Windows.Forms.Label label_min_frequency;
        private System.Windows.Forms.Label label_max_frequency;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_stop;
        private System.Windows.Forms.PictureBox pictureBox_stalta_filter;
        private System.Windows.Forms.Label label_stalta_filter;
        private System.Windows.Forms.Label label_stalta_filter_min_frequency;
        private DevExpress.XtraEditors.SpinEdit spinEdit_stalta_filter_min_frequency;
        private System.Windows.Forms.Label label_stalta_filter_max_frequency;
        private DevExpress.XtraEditors.SpinEdit spinEdit_stalta_filter_max_frequency;
        private DevExpress.XtraEditors.SpinEdit spinEdit_stalta_filter_order;
        private System.Windows.Forms.Label label_stalta_filter_order;
    }
}

