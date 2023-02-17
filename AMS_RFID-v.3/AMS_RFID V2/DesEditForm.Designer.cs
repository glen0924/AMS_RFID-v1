
namespace AMS_RFID_V2
{
    partial class DesEditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesEditForm));
			this.emp = new System.Windows.Forms.Label();
			this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.DesTxtbx = new MetroFramework.Controls.MetroTextBox();
			this.btnSave = new Guna.UI2.WinForms.Guna2Button();
			this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
			this.DesComboSelect = new MetroFramework.Controls.MetroComboBox();
			this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
			this.SuspendLayout();
			// 
			// emp
			// 
			this.emp.AutoSize = true;
			this.emp.BackColor = System.Drawing.Color.Transparent;
			this.emp.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.emp.Location = new System.Drawing.Point(12, 12);
			this.emp.Name = "emp";
			this.emp.Size = new System.Drawing.Size(149, 19);
			this.emp.TabIndex = 38;
			this.emp.Text = "EDIT DESIGNATION";
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
			this.guna2ControlBox1.TabIndex = 37;
			this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
			// 
			// guna2Panel1
			// 
			this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
			this.guna2Panel1.BorderRadius = 15;
			this.guna2Panel1.BorderThickness = 2;
			this.guna2Panel1.Controls.Add(this.DesTxtbx);
			this.guna2Panel1.Controls.Add(this.btnSave);
			this.guna2Panel1.Controls.Add(this.btnEdit);
			this.guna2Panel1.Controls.Add(this.DesComboSelect);
			this.guna2Panel1.Controls.Add(this.guna2PictureBox5);
			this.guna2Panel1.Location = new System.Drawing.Point(16, 37);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(352, 232);
			this.guna2Panel1.TabIndex = 39;
			// 
			// DesTxtbx
			// 
			// 
			// 
			// 
			this.DesTxtbx.CustomButton.Image = null;
			this.DesTxtbx.CustomButton.Location = new System.Drawing.Point(202, 1);
			this.DesTxtbx.CustomButton.Name = "";
			this.DesTxtbx.CustomButton.Size = new System.Drawing.Size(23, 23);
			this.DesTxtbx.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.DesTxtbx.CustomButton.TabIndex = 1;
			this.DesTxtbx.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.DesTxtbx.CustomButton.UseSelectable = true;
			this.DesTxtbx.CustomButton.Visible = false;
			this.DesTxtbx.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.DesTxtbx.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
			this.DesTxtbx.Lines = new string[0];
			this.DesTxtbx.Location = new System.Drawing.Point(61, 47);
			this.DesTxtbx.MaxLength = 32767;
			this.DesTxtbx.Name = "DesTxtbx";
			this.DesTxtbx.PasswordChar = '\0';
			this.DesTxtbx.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.DesTxtbx.SelectedText = "";
			this.DesTxtbx.SelectionLength = 0;
			this.DesTxtbx.SelectionStart = 0;
			this.DesTxtbx.ShortcutsEnabled = true;
			this.DesTxtbx.Size = new System.Drawing.Size(226, 25);
			this.DesTxtbx.Style = MetroFramework.MetroColorStyle.Brown;
			this.DesTxtbx.TabIndex = 35;
			this.DesTxtbx.TabStop = false;
			this.DesTxtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.DesTxtbx.UseCustomForeColor = true;
			this.DesTxtbx.UseSelectable = true;
			this.DesTxtbx.UseStyleColors = true;
			this.DesTxtbx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.DesTxtbx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
			this.btnSave.Location = new System.Drawing.Point(189, 183);
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
			this.btnEdit.Location = new System.Drawing.Point(256, 183);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 34);
			this.btnEdit.TabIndex = 33;
			this.btnEdit.Text = "Edit";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// DesComboSelect
			// 
			this.DesComboSelect.FormattingEnabled = true;
			this.DesComboSelect.IntegralHeight = false;
			this.DesComboSelect.ItemHeight = 23;
			this.DesComboSelect.Location = new System.Drawing.Point(61, 101);
			this.DesComboSelect.Name = "DesComboSelect";
			this.DesComboSelect.Size = new System.Drawing.Size(226, 29);
			this.DesComboSelect.TabIndex = 3;
			this.DesComboSelect.UseCustomBackColor = true;
			this.DesComboSelect.UseCustomForeColor = true;
			this.DesComboSelect.UseSelectable = true;
			this.DesComboSelect.UseStyleColors = true;
			// 
			// guna2PictureBox5
			// 
			this.guna2PictureBox5.BackColor = System.Drawing.Color.Transparent;
			this.guna2PictureBox5.Image = global::AMS_RFID_V2.Properties.Resources.logo;
			this.guna2PictureBox5.ImageRotate = 0F;
			this.guna2PictureBox5.Location = new System.Drawing.Point(71, 15);
			this.guna2PictureBox5.Name = "guna2PictureBox5";
			this.guna2PictureBox5.Size = new System.Drawing.Size(205, 149);
			this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.guna2PictureBox5.TabIndex = 51;
			this.guna2PictureBox5.TabStop = false;
			this.guna2PictureBox5.UseTransparentBackground = true;
			// 
			// DesEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(383, 282);
			this.Controls.Add(this.emp);
			this.Controls.Add(this.guna2ControlBox1);
			this.Controls.Add(this.guna2Panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(383, 282);
			this.MinimumSize = new System.Drawing.Size(383, 282);
			this.Name = "DesEditForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DesEditForm";
			this.Load += new System.EventHandler(this.DesEditForm_Load);
			this.guna2Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emp;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private MetroFramework.Controls.MetroTextBox DesTxtbx;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private MetroFramework.Controls.MetroComboBox DesComboSelect;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
    }
}