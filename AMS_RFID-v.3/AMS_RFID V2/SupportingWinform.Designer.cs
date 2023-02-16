
namespace AMS_RFID_V2
{
    partial class SupportingWinform
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2DataGridView4 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ForPrint = new Guna.UI2.WinForms.Guna2Button();
            this.RfidTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PmIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PmOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks_AP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.guna2DataGridView4);
            this.guna2Panel1.Location = new System.Drawing.Point(18, 10);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(741, 760);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2DataGridView4
            // 
            this.guna2DataGridView4.AllowUserToAddRows = false;
            this.guna2DataGridView4.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView4.ColumnHeadersHeight = 28;
            this.guna2DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RfidTag,
            this.EmpName,
            this.Date1,
            this.AmIn,
            this.AmOut,
            this.PmIn,
            this.PmOut,
            this.Remarks_AP});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView4.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView4.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView4.Location = new System.Drawing.Point(90, 94);
            this.guna2DataGridView4.Name = "guna2DataGridView4";
            this.guna2DataGridView4.ReadOnly = true;
            this.guna2DataGridView4.RowHeadersVisible = false;
            this.guna2DataGridView4.Size = new System.Drawing.Size(572, 554);
            this.guna2DataGridView4.TabIndex = 3;
            this.guna2DataGridView4.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView4.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView4.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView4.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView4.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView4.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView4.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView4.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView4.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView4.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView4.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView4.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView4.ThemeStyle.HeaderStyle.Height = 28;
            this.guna2DataGridView4.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView4.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView4.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView4.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView4.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView4.ThemeStyle.RowsStyle.Height = 22;
            this.guna2DataGridView4.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView4.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // ForPrint
            // 
            this.ForPrint.Animated = true;
            this.ForPrint.AutoRoundedCorners = true;
            this.ForPrint.BackColor = System.Drawing.Color.Transparent;
            this.ForPrint.BorderRadius = 12;
            this.ForPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ForPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ForPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ForPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ForPrint.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ForPrint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForPrint.ForeColor = System.Drawing.Color.Black;
            this.ForPrint.IndicateFocus = true;
            this.ForPrint.Location = new System.Drawing.Point(699, 776);
            this.ForPrint.Name = "ForPrint";
            this.ForPrint.Size = new System.Drawing.Size(60, 26);
            this.ForPrint.TabIndex = 11;
            this.ForPrint.Text = "Print";
            this.ForPrint.UseTransparentBackground = true;
            this.ForPrint.Click += new System.EventHandler(this.ForPrint_Click);
            // 
            // RfidTag
            // 
            this.RfidTag.DataPropertyName = "EmployeeRfid";
            this.RfidTag.HeaderText = "RfidTag";
            this.RfidTag.Name = "RfidTag";
            this.RfidTag.ReadOnly = true;
            // 
            // EmpName
            // 
            this.EmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EmpName.DataPropertyName = "EmployeeName";
            this.EmpName.HeaderText = "Employee Name";
            this.EmpName.Name = "EmpName";
            this.EmpName.ReadOnly = true;
            this.EmpName.Width = 104;
            // 
            // Date1
            // 
            this.Date1.DataPropertyName = "Date";
            this.Date1.HeaderText = "Date";
            this.Date1.Name = "Date1";
            this.Date1.ReadOnly = true;
            // 
            // AmIn
            // 
            this.AmIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AmIn.DataPropertyName = "Am_In";
            this.AmIn.HeaderText = "AmIn";
            this.AmIn.Name = "AmIn";
            this.AmIn.ReadOnly = true;
            this.AmIn.Width = 56;
            // 
            // AmOut
            // 
            this.AmOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AmOut.DataPropertyName = "Am_Out";
            this.AmOut.HeaderText = "AmOut";
            this.AmOut.Name = "AmOut";
            this.AmOut.ReadOnly = true;
            this.AmOut.Width = 66;
            // 
            // PmIn
            // 
            this.PmIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PmIn.DataPropertyName = "Pm_In";
            this.PmIn.HeaderText = "PmIn";
            this.PmIn.Name = "PmIn";
            this.PmIn.ReadOnly = true;
            this.PmIn.Width = 55;
            // 
            // PmOut
            // 
            this.PmOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PmOut.DataPropertyName = "Pm_Out";
            this.PmOut.HeaderText = "PmOut";
            this.PmOut.Name = "PmOut";
            this.PmOut.ReadOnly = true;
            this.PmOut.Width = 65;
            // 
            // Remarks_AP
            // 
            this.Remarks_AP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Remarks_AP.DataPropertyName = "Remarks_AP";
            this.Remarks_AP.HeaderText = "Remarks_AP";
            this.Remarks_AP.Name = "Remarks_AP";
            this.Remarks_AP.ReadOnly = true;
            this.Remarks_AP.Width = 92;
            // 
            // SupportingWinform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 807);
            this.Controls.Add(this.ForPrint);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SupportingWinform";
            this.Text = "SupportingWinform";
            this.Load += new System.EventHandler(this.SupportingWinform_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView4;
        private Guna.UI2.WinForms.Guna2Button ForPrint;
        private System.Drawing.Printing.PrintDocument printdoc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RfidTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn PmIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PmOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks_AP;
    }
}