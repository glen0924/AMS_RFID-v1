
namespace AMS_RFID_V2
{
    partial class FullLogForm
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
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.AttendanceToggle = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.datePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.attendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ams_rfidDataSetAttendance = new AMS_RFID_V2.ams_rfidDataSetAttendance();
            this.attendanceTableAdapter = new AMS_RFID_V2.ams_rfidDataSetAttendanceTableAdapters.attendanceTableAdapter();
            this.FullLogTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ams_rfidDataSetAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.PeachPuff;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.Location = new System.Drawing.Point(804, 1);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(25, 27);
            this.guna2ControlBox1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.guna2ControlBox1, "Close");
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.White;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(5);
            this.guna2Panel1.Location = new System.Drawing.Point(12, 34);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(807, 728);
            this.guna2Panel1.TabIndex = 1;
            // 
            // AttendanceToggle
            // 
            this.AttendanceToggle.Animated = true;
            this.AttendanceToggle.AutoRoundedCorners = true;
            this.AttendanceToggle.BackColor = System.Drawing.Color.Transparent;
            this.AttendanceToggle.Checked = true;
            this.AttendanceToggle.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.AttendanceToggle.CheckedState.BorderThickness = 1;
            this.AttendanceToggle.CheckedState.FillColor = System.Drawing.Color.LightGoldenrodYellow;
            this.AttendanceToggle.CheckedState.InnerBorderColor = System.Drawing.Color.Black;
            this.AttendanceToggle.CheckedState.InnerBorderThickness = 1;
            this.AttendanceToggle.CheckedState.InnerColor = System.Drawing.Color.Black;
            this.AttendanceToggle.Location = new System.Drawing.Point(170, 6);
            this.AttendanceToggle.Name = "AttendanceToggle";
            this.AttendanceToggle.Size = new System.Drawing.Size(35, 20);
            this.AttendanceToggle.TabIndex = 49;
            this.toolTip1.SetToolTip(this.AttendanceToggle, "Auto Refresh Database");
            this.AttendanceToggle.UncheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.AttendanceToggle.UncheckedState.FillColor = System.Drawing.Color.Black;
            this.AttendanceToggle.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.AttendanceToggle.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.AttendanceToggle.UseTransparentBackground = true;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.AttendanceToggle);
            this.guna2Panel2.Controls.Add(this.datePicker);
            this.guna2Panel2.Controls.Add(this.label25);
            this.guna2Panel2.Location = new System.Drawing.Point(11, 685);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(779, 30);
            this.guna2Panel2.TabIndex = 51;
            // 
            // datePicker
            // 
            this.datePicker.Animated = true;
            this.datePicker.AutoRoundedCorners = true;
            this.datePicker.BackColor = System.Drawing.Color.Transparent;
            this.datePicker.BorderRadius = 11;
            this.datePicker.BorderThickness = 1;
            this.datePicker.Checked = true;
            this.datePicker.CustomFormat = "yyyy/MM/dd";
            this.datePicker.CustomizableEdges.BottomRight = false;
            this.datePicker.CustomizableEdges.TopLeft = false;
            this.datePicker.FillColor = System.Drawing.Color.DimGray;
            this.datePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.datePicker.ForeColor = System.Drawing.Color.Cornsilk;
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(237, 3);
            this.datePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.datePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(121, 24);
            this.datePicker.TabIndex = 51;
            this.toolTip1.SetToolTip(this.datePicker, "Date Look Up");
            this.datePicker.Value = new System.DateTime(2023, 1, 7, 21, 56, 18, 192);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(11, 7);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(153, 15);
            this.label25.TabIndex = 50;
            this.label25.Text = "Auto Refresh Attendance";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2Panel3.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Panel3.Location = new System.Drawing.Point(22, 22);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(768, 657);
            this.guna2Panel3.TabIndex = 2;
            // 
            // attendanceBindingSource
            // 
            this.attendanceBindingSource.DataMember = "attendance";
            this.attendanceBindingSource.DataSource = this.ams_rfidDataSetAttendance;
            // 
            // ams_rfidDataSetAttendance
            // 
            this.ams_rfidDataSetAttendance.DataSetName = "ams_rfidDataSetAttendance";
            this.ams_rfidDataSetAttendance.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // attendanceTableAdapter
            // 
            this.attendanceTableAdapter.ClearBeforeFill = true;
            // 
            // FullLogTimer
            // 
            this.FullLogTimer.Enabled = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            // 
            // FullLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(831, 774);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "FullLogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FullLogForm";
            this.Load += new System.EventHandler(this.FullLogForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ams_rfidDataSetAttendance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private ams_rfidDataSetAttendance ams_rfidDataSetAttendance;
        private System.Windows.Forms.BindingSource attendanceBindingSource;
        private ams_rfidDataSetAttendanceTableAdapters.attendanceTableAdapter attendanceTableAdapter;
        private System.Windows.Forms.Timer FullLogTimer;
        private System.Windows.Forms.Label label25;
        private Guna.UI2.WinForms.Guna2ToggleSwitch AttendanceToggle;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DateTimePicker datePicker;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}