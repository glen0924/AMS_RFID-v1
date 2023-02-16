
namespace AMS_RFID_V2
{
    partial class EmployeeDelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeDelForm));
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.empcombobx = new MetroFramework.Controls.MetroComboBox();
            this.btnEmpDelete = new Guna.UI2.WinForms.Guna2Button();
            this.Namess = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(267, 5);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(34, 29);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "DELETE";
            // 
            // empcombobx
            // 
            this.empcombobx.FormattingEnabled = true;
            this.empcombobx.ItemHeight = 23;
            this.empcombobx.Location = new System.Drawing.Point(46, 103);
            this.empcombobx.Name = "empcombobx";
            this.empcombobx.Size = new System.Drawing.Size(199, 29);
            this.empcombobx.TabIndex = 2;
            this.empcombobx.UseSelectable = true;
            this.empcombobx.SelectedIndexChanged += new System.EventHandler(this.empcombobx_SelectedIndexChanged);
            // 
            // btnEmpDelete
            // 
            this.btnEmpDelete.AutoRoundedCorners = true;
            this.btnEmpDelete.BorderRadius = 16;
            this.btnEmpDelete.CustomizableEdges.BottomLeft = false;
            this.btnEmpDelete.CustomizableEdges.TopRight = false;
            this.btnEmpDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEmpDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEmpDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEmpDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEmpDelete.FillColor = System.Drawing.Color.Firebrick;
            this.btnEmpDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEmpDelete.ForeColor = System.Drawing.Color.White;
            this.btnEmpDelete.Location = new System.Drawing.Point(99, 175);
            this.btnEmpDelete.Name = "btnEmpDelete";
            this.btnEmpDelete.Size = new System.Drawing.Size(83, 34);
            this.btnEmpDelete.TabIndex = 36;
            this.btnEmpDelete.Text = "Delete";
            this.btnEmpDelete.Click += new System.EventHandler(this.btnEmpDelete_Click);
            // 
            // Namess
            // 
            // 
            // 
            // 
            this.Namess.CustomButton.Image = null;
            this.Namess.CustomButton.Location = new System.Drawing.Point(139, 1);
            this.Namess.CustomButton.Name = "";
            this.Namess.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.Namess.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Namess.CustomButton.TabIndex = 1;
            this.Namess.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Namess.CustomButton.UseSelectable = true;
            this.Namess.CustomButton.Visible = false;
            this.Namess.Enabled = false;
            this.Namess.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.Namess.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.Namess.Lines = new string[0];
            this.Namess.Location = new System.Drawing.Point(66, 51);
            this.Namess.MaxLength = 32767;
            this.Namess.Name = "Namess";
            this.Namess.PasswordChar = '\0';
            this.Namess.ReadOnly = true;
            this.Namess.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Namess.SelectedText = "";
            this.Namess.SelectionLength = 0;
            this.Namess.SelectionStart = 0;
            this.Namess.ShortcutsEnabled = true;
            this.Namess.Size = new System.Drawing.Size(161, 23);
            this.Namess.Style = MetroFramework.MetroColorStyle.Brown;
            this.Namess.TabIndex = 38;
            this.Namess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Namess.UseCustomBackColor = true;
            this.Namess.UseCustomForeColor = true;
            this.Namess.UseSelectable = true;
            this.Namess.UseStyleColors = true;
            this.Namess.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Namess.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 40;
            this.label2.Text = "Employee RFID";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.Namess);
            this.guna2Panel1.Controls.Add(this.btnEmpDelete);
            this.guna2Panel1.Controls.Add(this.empcombobx);
            this.guna2Panel1.Location = new System.Drawing.Point(11, 39);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(285, 247);
            this.guna2Panel1.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(69, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 19);
            this.label3.TabIndex = 41;
            this.label3.Text = "Sta. Teresita, Cagayan";
            // 
            // EmployeeDelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 306);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(306, 306);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(306, 306);
            this.Name = "EmployeeDelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EmployeeDelForm";
            this.Load += new System.EventHandler(this.EmployeeDelForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DelForm_MouseDown);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnEmpDelete;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public MetroFramework.Controls.MetroTextBox Namess;
        public MetroFramework.Controls.MetroComboBox empcombobx;
        private System.Windows.Forms.Label label3;
    }
}