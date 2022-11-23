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
            this.label_calibration_explosion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.dateTimePicker_blow_datetime = new System.Windows.Forms.DateTimePicker();
            this.spinEdit_calibration_y = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_calibration_altitude = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_calibration_x = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_calibration_y.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_calibration_altitude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_calibration_x.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label_calibration_explosion
            // 
            this.label_calibration_explosion.AutoSize = true;
            this.label_calibration_explosion.Location = new System.Drawing.Point(153, 18);
            this.label_calibration_explosion.Name = "label_calibration_explosion";
            this.label_calibration_explosion.Size = new System.Drawing.Size(103, 13);
            this.label_calibration_explosion.TabIndex = 0;
            this.label_calibration_explosion.Text = "Calibration explosion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Blow datetime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Altitude";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(112, 270);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 9;
            this.button_ok.Text = "ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(269, 270);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 10;
            this.button_cancel.Text = "cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker_blow_datetime
            // 
            this.dateTimePicker_blow_datetime.Location = new System.Drawing.Point(144, 75);
            this.dateTimePicker_blow_datetime.Name = "dateTimePicker_blow_datetime";
            this.dateTimePicker_blow_datetime.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_blow_datetime.TabIndex = 11;
            // 
            // spinEdit_calibration_y
            // 
            this.spinEdit_calibration_y.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_calibration_y.Location = new System.Drawing.Point(112, 155);
            this.spinEdit_calibration_y.Name = "spinEdit_calibration_y";
            this.spinEdit_calibration_y.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_calibration_y.Size = new System.Drawing.Size(100, 20);
            this.spinEdit_calibration_y.TabIndex = 25;
            // 
            // spinEdit_calibration_altitude
            // 
            this.spinEdit_calibration_altitude.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_calibration_altitude.Location = new System.Drawing.Point(112, 185);
            this.spinEdit_calibration_altitude.Name = "spinEdit_calibration_altitude";
            this.spinEdit_calibration_altitude.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_calibration_altitude.Size = new System.Drawing.Size(100, 20);
            this.spinEdit_calibration_altitude.TabIndex = 26;
            // 
            // spinEdit_calibration_x
            // 
            this.spinEdit_calibration_x.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_calibration_x.Location = new System.Drawing.Point(112, 125);
            this.spinEdit_calibration_x.Name = "spinEdit_calibration_x";
            this.spinEdit_calibration_x.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_calibration_x.Size = new System.Drawing.Size(100, 20);
            this.spinEdit_calibration_x.TabIndex = 27;
            // 
            // Form_corrections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 384);
            this.Controls.Add(this.spinEdit_calibration_x);
            this.Controls.Add(this.spinEdit_calibration_altitude);
            this.Controls.Add(this.spinEdit_calibration_y);
            this.Controls.Add(this.dateTimePicker_blow_datetime);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_calibration_explosion);
            this.Name = "Form_corrections";
            this.Text = "seisapp";
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_calibration_y.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_calibration_altitude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_calibration_x.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_calibration_explosion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.DateTimePicker dateTimePicker_blow_datetime;
        private DevExpress.XtraEditors.SpinEdit spinEdit_calibration_y;
        private DevExpress.XtraEditors.SpinEdit spinEdit_calibration_altitude;
        private DevExpress.XtraEditors.SpinEdit spinEdit_calibration_x;
    }
}