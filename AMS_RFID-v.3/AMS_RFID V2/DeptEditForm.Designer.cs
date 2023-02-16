
namespace AMS_RFID_V2
{
    partial class DeptEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeptEditForm));
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.emp = new System.Windows.Forms.Label();
            this.DeptComboSelect = new MetroFramework.Controls.MetroComboBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.DeptTxtbx = new MetroFramework.Controls.MetroTextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.CustomClick = true;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(350, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(31, 29);
            this.guna2ControlBox1.TabIndex = 0;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // emp
            // 
            this.emp.AutoSize = true;
            this.emp.BackColor = System.Drawing.Color.Transparent;
            this.emp.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emp.Location = new System.Drawing.Point(12, 12);
            this.emp.Name = "emp";
            this.emp.Size = new System.Drawing.Size(147, 19);
            this.emp.TabIndex = 2;
            this.emp.Text = "EDIT DEPARTMENT";
            // 
            // DeptComboSelect
            // 
            this.DeptComboSelect.FormattingEnabled = true;
            this.DeptComboSelect.IntegralHeight = false;
            this.DeptComboSelect.ItemHeight = 23;
            this.DeptComboSelect.Location = new System.Drawing.Point(59, 103);
            this.DeptComboSelect.Name = "DeptComboSelect";
            this.DeptComboSelect.Size = new System.Drawing.Size(226, 29);
            this.DeptComboSelect.TabIndex = 3;
            this.DeptComboSelect.UseCustomBackColor = true;
            this.DeptComboSelect.UseCustomForeColor = true;
            this.DeptComboSelect.UseSelectable = true;
            this.DeptComboSelect.UseStyleColors = true;
            this.DeptComboSelect.SelectedIndexChanged += new System.EventHandler(this.DeptComboSelect_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 16;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.Lime;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(199, 183);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 34);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoRoundedCorners = true;
            this.btnEdit.BorderRadius = 16;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(266, 183);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(69, 34);
            this.btnEdit.TabIndex = 33;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // DeptTxtbx
            // 
            // 
            // 
            // 
            this.DeptTxtbx.CustomButton.Image = null;
            this.DeptTxtbx.CustomButton.Location = new System.Drawing.Point(202, 1);
            this.DeptTxtbx.CustomButton.Name = "";
            this.DeptTxtbx.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.DeptTxtbx.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.DeptTxtbx.CustomButton.TabIndex = 1;
            this.DeptTxtbx.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.DeptTxtbx.CustomButton.UseSelectable = true;
            this.DeptTxtbx.CustomButton.Visible = false;
            this.DeptTxtbx.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.DeptTxtbx.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.DeptTxtbx.Lines = new string[0];
            this.DeptTxtbx.Location = new System.Drawing.Point(59, 54);
            this.DeptTxtbx.MaxLength = 32767;
            this.DeptTxtbx.Name = "DeptTxtbx";
            this.DeptTxtbx.PasswordChar = '\0';
            this.DeptTxtbx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DeptTxtbx.SelectedText = "";
            this.DeptTxtbx.SelectionLength = 0;
            this.DeptTxtbx.SelectionStart = 0;
            this.DeptTxtbx.ShortcutsEnabled = true;
            this.DeptTxtbx.Size = new System.Drawing.Size(226, 25);
            this.DeptTxtbx.Style = MetroFramework.MetroColorStyle.Brown;
            this.DeptTxtbx.TabIndex = 35;
            this.DeptTxtbx.TabStop = false;
            this.DeptTxtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DeptTxtbx.UseCustomForeColor = true;
            this.DeptTxtbx.UseSelectable = true;
            this.DeptTxtbx.UseStyleColors = true;
            this.DeptTxtbx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.DeptTxtbx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.DeptTxtbx);
            this.guna2Panel1.Controls.Add(this.btnSave);
            this.guna2Panel1.Controls.Add(this.btnEdit);
            this.guna2Panel1.Controls.Add(this.DeptComboSelect);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox5);
            this.guna2Panel1.Location = new System.Drawing.Point(16, 37);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(352, 232);
            this.guna2Panel1.TabIndex = 36;
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox5.Image = global::AMS_RFID_V2.Properties.Resources.logo;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(70, 28);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.Size = new System.Drawing.Size(205, 149);
            this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox5.TabIndex = 50;
            this.guna2PictureBox5.TabStop = false;
            this.guna2PictureBox5.UseTransparentBackground = true;
            // 
            // DeptEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 282);
            this.Controls.Add(this.emp);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(383, 282);
            this.MinimumSize = new System.Drawing.Size(383, 282);
            this.Name = "DeptEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DeptEditForm";
            this.Load += new System.EventHandler(this.DeptEditForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeptEditForm_MouseDown);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label emp;
        private MetroFramework.Controls.MetroComboBox DeptComboSelect;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private MetroFramework.Controls.MetroTextBox DeptTxtbx;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
    }
}