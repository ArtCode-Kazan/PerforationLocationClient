namespace seisapp
{
    partial class Form_corrections
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
            this.labelCalibrationExplosion = new System.Windows.Forms.Label();
            this.labelBlowDateTime = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelAltitude = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePickerBlowDateTime = new System.Windows.Forms.DateTimePicker();
            this.spinEditCalibrationY = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditCalibrationAltitude = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditCalibrationX = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCalibrationY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCalibrationAltitude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCalibrationX.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCalibrationExplosion
            // 
            this.labelCalibrationExplosion.AutoSize = true;
            this.labelCalibrationExplosion.Location = new System.Drawing.Point(153, 18);
            this.labelCalibrationExplosion.Name = "labelCalibrationExplosion";
            this.labelCalibrationExplosion.Size = new System.Drawing.Size(103, 13);
            this.labelCalibrationExplosion.TabIndex = 0;
            this.labelCalibrationExplosion.Text = "Calibration explosion";
            // 
            // labelBlowDateTime
            // 
            this.labelBlowDateTime.AutoSize = true;
            this.labelBlowDateTime.Location = new System.Drawing.Point(54, 81);
            this.labelBlowDateTime.Name = "labelBlowDateTime";
            this.labelBlowDateTime.Size = new System.Drawing.Size(73, 13);
            this.labelBlowDateTime.TabIndex = 1;
            this.labelBlowDateTime.Text = "Blow datetime";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(54, 128);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(12, 13);
            this.labelX.TabIndex = 6;
            this.labelX.Text = "x";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(54, 158);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(12, 13);
            this.labelY.TabIndex = 7;
            this.labelY.Text = "y";
            // 
            // labelAltitude
            // 
            this.labelAltitude.AutoSize = true;
            this.labelAltitude.Location = new System.Drawing.Point(54, 188);
            this.labelAltitude.Name = "labelAltitude";
            this.labelAltitude.Size = new System.Drawing.Size(42, 13);
            this.labelAltitude.TabIndex = 8;
            this.labelAltitude.Text = "Altitude";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(112, 270);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 9;
            this.buttonOk.Text = "ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(269, 270);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePickerBlowDateTime
            // 
            this.dateTimePickerBlowDateTime.Location = new System.Drawing.Point(144, 75);
            this.dateTimePickerBlowDateTime.Name = "dateTimePickerBlowDateTime";
            this.dateTimePickerBlowDateTime.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBlowDateTime.TabIndex = 11;
            // 
            // spinEditCalibrationY
            // 
            this.spinEditCalibrationY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditCalibrationY.Location = new System.Drawing.Point(112, 155);
            this.spinEditCalibrationY.Name = "spinEditCalibrationY";
            this.spinEditCalibrationY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCalibrationY.Size = new System.Drawing.Size(100, 20);
            this.spinEditCalibrationY.TabIndex = 25;
            // 
            // spinEditCalibrationAltitude
            // 
            this.spinEditCalibrationAltitude.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditCalibrationAltitude.Location = new System.Drawing.Point(112, 185);
            this.spinEditCalibrationAltitude.Name = "spinEditCalibrationAltitude";
            this.spinEditCalibrationAltitude.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCalibrationAltitude.Size = new System.Drawing.Size(100, 20);
            this.spinEditCalibrationAltitude.TabIndex = 26;
            // 
            // spinEditCalibrationX
            // 
            this.spinEditCalibrationX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditCalibrationX.Location = new System.Drawing.Point(112, 125);
            this.spinEditCalibrationX.Name = "spinEditCalibrationX";
            this.spinEditCalibrationX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCalibrationX.Size = new System.Drawing.Size(100, 20);
            this.spinEditCalibrationX.TabIndex = 27;
            // 
            // Form_corrections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 384);
            this.Controls.Add(this.spinEditCalibrationX);
            this.Controls.Add(this.spinEditCalibrationAltitude);
            this.Controls.Add(this.spinEditCalibrationY);
            this.Controls.Add(this.dateTimePickerBlowDateTime);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelAltitude);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelBlowDateTime);
            this.Controls.Add(this.labelCalibrationExplosion);
            this.Name = "Form_corrections";
            this.Text = "seisapp";
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCalibrationY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCalibrationAltitude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCalibrationX.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCalibrationExplosion;
        private System.Windows.Forms.Label labelBlowDateTime;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelAltitude;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DateTimePicker dateTimePickerBlowDateTime;
        private DevExpress.XtraEditors.SpinEdit spinEditCalibrationY;
        private DevExpress.XtraEditors.SpinEdit spinEditCalibrationAltitude;
        private DevExpress.XtraEditors.SpinEdit spinEditCalibrationX;
    }
}