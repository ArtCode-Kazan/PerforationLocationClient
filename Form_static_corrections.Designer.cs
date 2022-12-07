namespace seisapp
{
    partial class Form_static_corrections
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dataGridViewCorrections = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonGetCorrections = new System.Windows.Forms.Button();
            this.chartControlGodograph = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCorrections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlGodograph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(209, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Static corrections";
            // 
            // dataGridViewCorrections
            // 
            this.dataGridViewCorrections.AllowUserToAddRows = false;
            this.dataGridViewCorrections.AllowUserToDeleteRows = false;
            this.dataGridViewCorrections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCorrections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.vp});
            this.dataGridViewCorrections.Location = new System.Drawing.Point(96, 71);
            this.dataGridViewCorrections.Name = "dataGridViewCorrections";
            this.dataGridViewCorrections.ReadOnly = true;
            this.dataGridViewCorrections.RowHeadersVisible = false;
            this.dataGridViewCorrections.Size = new System.Drawing.Size(303, 393);
            this.dataGridViewCorrections.TabIndex = 1;
            // 
            // number
            // 
            this.number.HeaderText = "number";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 150;
            // 
            // vp
            // 
            this.vp.HeaderText = "vp";
            this.vp.Name = "vp";
            this.vp.ReadOnly = true;
            this.vp.Width = 150;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(255, 514);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(149, 514);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 14;
            this.buttonOk.Text = "ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonGetCorrections
            // 
            this.buttonGetCorrections.Location = new System.Drawing.Point(33, 16);
            this.buttonGetCorrections.Name = "buttonGetCorrections";
            this.buttonGetCorrections.Size = new System.Drawing.Size(75, 23);
            this.buttonGetCorrections.TabIndex = 16;
            this.buttonGetCorrections.Text = "get corrections";
            this.buttonGetCorrections.UseVisualStyleBackColor = true;
            this.buttonGetCorrections.Click += new System.EventHandler(this.buttonGetCorrections_Click);
            // 
            // chartControlGodograph
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControlGodograph.Diagram = xyDiagram1;
            this.chartControlGodograph.Location = new System.Drawing.Point(465, 71);
            this.chartControlGodograph.Name = "chartControlGodograph";
            series1.Name = "Сырой";
            series1.View = lineSeriesView1;
            series2.Name = "Коррекция";
            series2.View = lineSeriesView2;
            this.chartControlGodograph.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartControlGodograph.Size = new System.Drawing.Size(380, 393);
            this.chartControlGodograph.TabIndex = 17;
            // 
            // Form_static_corrections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 562);
            this.Controls.Add(this.chartControlGodograph);
            this.Controls.Add(this.buttonGetCorrections);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.dataGridViewCorrections);
            this.Controls.Add(this.labelControl1);
            this.Name = "Form_static_corrections";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_static_corrections";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCorrections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlGodograph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DataGridView dataGridViewCorrections;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn vp;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonGetCorrections;
        private DevExpress.XtraCharts.ChartControl chartControlGodograph;
    }
}