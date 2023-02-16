
namespace AMS_RFID_V2
{
    partial class DEptDel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DEptDel));
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeptCombobx = new MetroFramework.Controls.MetroComboBox();
            this.btnEmpDelete = new Guna.UI2.WinForms.Guna2Button();
            this.DeptNameLocator = new MetroFramework.Controls.MetroTextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.DepName = new MetroFramework.Controls.MetroTextBox();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(326, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(29, 29);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "DELETE DEPARTMENT";
            // 
            // DeptCombobx
            // 
            this.DeptCombobx.FormattingEnabled = true;
            this.DeptCombobx.ItemHeight = 23;
            this.DeptCombobx.Location = new System.Drawing.Point(33, 85);
            this.DeptCombobx.Name = "DeptCombobx";
            this.DeptCombobx.Size = new System.Drawing.Size(264, 29);
            this.DeptCombobx.Style = MetroFramework.MetroColorStyle.Brown;
            this.DeptCombobx.TabIndex = 2;
            this.DeptCombobx.UseCustomBackColor = true;
            this.DeptCombobx.UseCustomForeColor = true;
            this.DeptCombobx.UseSelectable = true;
            this.DeptCombobx.UseStyleColors = true;
            this.DeptCombobx.SelectedIndexChanged += new System.EventHandler(this.DeptCombobx_SelectedIndexChanged);
            // 
            // btnEmpDelete
            // 
            this.btnEmpDelete.AutoRoundedCorners = true;
            this.btnEmpDelete.BorderRadius = 15;
            this.btnEmpDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEmpDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEmpDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEmpDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEmpDelete.FillColor = System.Drawing.Color.Firebrick;
            this.btnEmpDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEmpDelete.ForeColor = System.Drawing.Color.White;
            this.btnEmpDelete.Location = new System.Drawing.Point(248, 146);
            this.btnEmpDelete.Name = "btnEmpDelete";
            this.btnEmpDelete.Size = new System.Drawing.Size(62, 32);
            this.btnEmpDelete.TabIndex = 37;
            this.btnEmpDelete.Text = "Delete";
            this.btnEmpDelete.Click += new System.EventHandler(this.btnEmpDelete_Click);
            // 
            // DeptNameLocator
            // 
            // 
            // 
            // 
            this.DeptNameLocator.CustomButton.Image = null;
            this.DeptNameLocator.CustomButton.Location = new System.Drawing.Point(139, 1);
            this.DeptNameLocator.CustomButton.Name = "";
            this.DeptNameLocator.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.DeptNameLocator.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.DeptNameLocator.CustomButton.TabIndex = 1;
            this.DeptNameLocator.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.DeptNameLocator.CustomButton.UseSelectable = true;
            this.DeptNameLocator.CustomButton.Visible = false;
            this.DeptNameLocator.Lines = new string[0];
            this.DeptNameLocator.Location = new System.Drawing.Point(80, 179);
            this.DeptNameLocator.MaxLength = 32767;
            this.DeptNameLocator.Name = "DeptNameLocator";
            this.DeptNameLocator.PasswordChar = '\0';
            this.DeptNameLocator.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DeptNameLocator.SelectedText = "";
            this.DeptNameLocator.SelectionLength = 0;
            this.DeptNameLocator.SelectionStart = 0;
            this.DeptNameLocator.ShortcutsEnabled = true;
            this.DeptNameLocator.Size = new System.Drawing.Size(161, 23);
            this.DeptNameLocator.TabIndex = 40;
            this.DeptNameLocator.TabStop = false;
            this.DeptNameLocator.UseCustomBackColor = true;
            this.DeptNameLocator.UseCustomForeColor = true;
            this.DeptNameLocator.UseSelectable = true;
            this.DeptNameLocator.UseStyleColors = true;
            this.DeptNameLocator.Visible = false;
            this.DeptNameLocator.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.DeptNameLocator.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.DeptNameLocator.TextChanged += new System.EventHandler(this.DeptNameLocator_TextChanged);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.DepName);
            this.guna2Panel1.Controls.Add(this.DeptNameLocator);
            this.guna2Panel1.Controls.Add(this.btnEmpDelete);
            this.guna2Panel1.Controls.Add(this.DeptCombobx);
            this.guna2Panel1.Location = new System.Drawing.Point(14, 37);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(326, 195);
            this.guna2Panel1.TabIndex = 42;
            // 
            // DepName
            // 
            // 
            // 
            // 
            this.DepName.CustomButton.Image = null;
            this.DepName.CustomButton.Location = new System.Drawing.Point(197, 2);
            this.DepName.CustomButton.Name = "";
            this.DepName.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.DepName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.DepName.CustomButton.TabIndex = 1;
            this.DepName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.DepName.CustomButton.UseSelectable = true;
            this.DepName.CustomButton.Visible = false;
            this.DepName.Enabled = false;
            this.DepName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.DepName.Lines = new string[0];
            this.DepName.Location = new System.Drawing.Point(56, 37);
            this.DepName.MaxLength = 32767;
            this.DepName.Name = "DepName";
            this.DepName.PasswordChar = '\0';
            this.DepName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DepName.SelectedText = "";
            this.DepName.SelectionLength = 0;
            this.DepName.SelectionStart = 0;
            this.DepName.ShortcutsEnabled = true;
            this.DepName.Size = new System.Drawing.Size(227, 32);
            this.DepName.Style = MetroFramework.MetroColorStyle.Brown;
            this.DepName.TabIndex = 41;
            this.DepName.TabStop = false;
            this.DepName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DepName.UseCustomBackColor = true;
            this.DepName.UseCustomForeColor = true;
            this.DepName.UseSelectable = true;
            this.DepName.UseStyleColors = true;
            this.DepName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.DepName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // DEptDel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 243);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(356, 243);
            this.MinimumSize = new System.Drawing.Size(356, 243);
            this.Name = "DEptDel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DEptDel";
            this.Load += new System.EventHandler(this.DEptDel_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox DeptCombobx;
        private Guna.UI2.WinForms.Guna2Button btnEmpDelete;
        private MetroFramework.Controls.MetroTextBox DeptNameLocator;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private MetroFramework.Controls.MetroTextBox DepName;
    }
}