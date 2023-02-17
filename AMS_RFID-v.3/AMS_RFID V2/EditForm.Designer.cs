
namespace AMS_RFID_V2
{
    partial class EditForm
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
			System.Windows.Forms.Label employeeRfidTagLabel;
			System.Windows.Forms.Label employeeNameLabel;
			System.Windows.Forms.Label employeeAddressLabel;
			System.Windows.Forms.Label employeeContactNumberLabel;
			System.Windows.Forms.Label departmentNameLabel1;
			System.Windows.Forms.Label designationNameLabel;
			System.Windows.Forms.Label reportsToLabel;
			System.Windows.Forms.Label label1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
			this.EmpTextbx = new MetroFramework.Controls.MetroTextBox();
			this.SaveEdit = new Guna.UI2.WinForms.Guna2Button();
			this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
			this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
			this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
			this.empImg1 = new System.Windows.Forms.PictureBox();
			this.btnEmpEdit = new Guna.UI2.WinForms.Guna2Button();
			this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
			this.ReportsToTextBox1 = new MetroFramework.Controls.MetroTextBox();
			this.DesignationNameTextBox2 = new MetroFramework.Controls.MetroTextBox();
			this.DepartmentNameTextBox1 = new MetroFramework.Controls.MetroTextBox();
			this.reportsToEmployeeComboBox = new MetroFramework.Controls.MetroComboBox();
			this.reportstoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ams_rfidDataSetReportsTo = new AMS_RFID_V2.ams_rfidDataSetReportsTo();
			this.designationNameComboBox = new MetroFramework.Controls.MetroComboBox();
			this.designationBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ams_rfidDataSet1 = new AMS_RFID_V2.ams_rfidDataSet1();
			this.EmployeeContactNumberTextBox1 = new MetroFramework.Controls.MetroTextBox();
			this.EmployeeRfidTagTextBox1 = new MetroFramework.Controls.MetroTextBox();
			this.NA = new Guna.UI2.WinForms.Guna2Button();
			this.EmployeeNameTextBox1 = new MetroFramework.Controls.MetroTextBox();
			this.emplabel = new System.Windows.Forms.Label();
			this.departmentNameComboBox = new MetroFramework.Controls.MetroComboBox();
			this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ams_rfidDataSet = new AMS_RFID_V2.ams_rfidDataSet();
			this.EmployeeAddressTextBox1 = new MetroFramework.Controls.MetroTextBox();
			this.Address = new MetroFramework.Controls.MetroComboBox();
			this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.departmentTableAdapter = new AMS_RFID_V2.ams_rfidDataSetTableAdapters.departmentTableAdapter();
			this.designationTableAdapter = new AMS_RFID_V2.ams_rfidDataSet1TableAdapters.designationTableAdapter();
			this.reportstoTableAdapter = new AMS_RFID_V2.ams_rfidDataSetReportsToTableAdapters.reportstoTableAdapter();
			this.Empcmb = new MetroFramework.Controls.MetroComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			employeeRfidTagLabel = new System.Windows.Forms.Label();
			employeeNameLabel = new System.Windows.Forms.Label();
			employeeAddressLabel = new System.Windows.Forms.Label();
			employeeContactNumberLabel = new System.Windows.Forms.Label();
			departmentNameLabel1 = new System.Windows.Forms.Label();
			designationNameLabel = new System.Windows.Forms.Label();
			reportsToLabel = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			this.guna2Panel7.SuspendLayout();
			this.guna2Panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.empImg1)).BeginInit();
			this.guna2Panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.reportstoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ams_rfidDataSetReportsTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.designationBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ams_rfidDataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ams_rfidDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// employeeRfidTagLabel
			// 
			employeeRfidTagLabel.AutoSize = true;
			employeeRfidTagLabel.ForeColor = System.Drawing.Color.Brown;
			employeeRfidTagLabel.Location = new System.Drawing.Point(34, 49);
			employeeRfidTagLabel.Name = "employeeRfidTagLabel";
			employeeRfidTagLabel.Size = new System.Drawing.Size(71, 18);
			employeeRfidTagLabel.TabIndex = 18;
			employeeRfidTagLabel.Text = "Rfid Tag";
			// 
			// employeeNameLabel
			// 
			employeeNameLabel.AutoSize = true;
			employeeNameLabel.ForeColor = System.Drawing.Color.Brown;
			employeeNameLabel.Location = new System.Drawing.Point(34, 115);
			employeeNameLabel.Name = "employeeNameLabel";
			employeeNameLabel.Size = new System.Drawing.Size(52, 18);
			employeeNameLabel.TabIndex = 20;
			employeeNameLabel.Text = "Name";
			// 
			// employeeAddressLabel
			// 
			employeeAddressLabel.AutoSize = true;
			employeeAddressLabel.ForeColor = System.Drawing.Color.Brown;
			employeeAddressLabel.Location = new System.Drawing.Point(34, 167);
			employeeAddressLabel.Name = "employeeAddressLabel";
			employeeAddressLabel.Size = new System.Drawing.Size(69, 18);
			employeeAddressLabel.TabIndex = 22;
			employeeAddressLabel.Text = "Address";
			// 
			// employeeContactNumberLabel
			// 
			employeeContactNumberLabel.AutoSize = true;
			employeeContactNumberLabel.ForeColor = System.Drawing.Color.Brown;
			employeeContactNumberLabel.Location = new System.Drawing.Point(34, 237);
			employeeContactNumberLabel.Name = "employeeContactNumberLabel";
			employeeContactNumberLabel.Size = new System.Drawing.Size(131, 18);
			employeeContactNumberLabel.TabIndex = 24;
			employeeContactNumberLabel.Text = "Contact Number";
			// 
			// departmentNameLabel1
			// 
			departmentNameLabel1.AutoSize = true;
			departmentNameLabel1.ForeColor = System.Drawing.Color.Brown;
			departmentNameLabel1.Location = new System.Drawing.Point(34, 282);
			departmentNameLabel1.Name = "departmentNameLabel1";
			departmentNameLabel1.Size = new System.Drawing.Size(144, 18);
			departmentNameLabel1.TabIndex = 26;
			departmentNameLabel1.Text = "Department Name";
			// 
			// designationNameLabel
			// 
			designationNameLabel.AutoSize = true;
			designationNameLabel.ForeColor = System.Drawing.Color.Brown;
			designationNameLabel.Location = new System.Drawing.Point(31, 333);
			designationNameLabel.Name = "designationNameLabel";
			designationNameLabel.Size = new System.Drawing.Size(146, 18);
			designationNameLabel.TabIndex = 28;
			designationNameLabel.Text = "Designation Name";
			// 
			// reportsToLabel
			// 
			reportsToLabel.AutoSize = true;
			reportsToLabel.ForeColor = System.Drawing.Color.Brown;
			reportsToLabel.Location = new System.Drawing.Point(34, 384);
			reportsToLabel.Name = "reportsToLabel";
			reportsToLabel.Size = new System.Drawing.Size(93, 18);
			reportsToLabel.TabIndex = 30;
			reportsToLabel.Text = "Reports To";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
			label1.ForeColor = System.Drawing.Color.Brown;
			label1.Location = new System.Drawing.Point(389, 325);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(131, 18);
			label1.TabIndex = 77;
			label1.Text = "Employee Name";
			// 
			// EmpTextbx
			// 
			// 
			// 
			// 
			this.EmpTextbx.CustomButton.Image = null;
			this.EmpTextbx.CustomButton.Location = new System.Drawing.Point(130, 1);
			this.EmpTextbx.CustomButton.Name = "";
			this.EmpTextbx.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.EmpTextbx.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.EmpTextbx.CustomButton.TabIndex = 1;
			this.EmpTextbx.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.EmpTextbx.CustomButton.UseSelectable = true;
			this.EmpTextbx.CustomButton.Visible = false;
			this.EmpTextbx.Lines = new string[0];
			this.EmpTextbx.Location = new System.Drawing.Point(407, 349);
			this.EmpTextbx.MaxLength = 32767;
			this.EmpTextbx.Name = "EmpTextbx";
			this.EmpTextbx.PasswordChar = '\0';
			this.EmpTextbx.ReadOnly = true;
			this.EmpTextbx.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.EmpTextbx.SelectedText = "";
			this.EmpTextbx.SelectionLength = 0;
			this.EmpTextbx.SelectionStart = 0;
			this.EmpTextbx.ShortcutsEnabled = true;
			this.EmpTextbx.Size = new System.Drawing.Size(152, 23);
			this.EmpTextbx.TabIndex = 86;
			this.EmpTextbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.EmpTextbx.UseSelectable = true;
			this.EmpTextbx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.EmpTextbx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.EmpTextbx.TextChanged += new System.EventHandler(this.EmpTextbx_TextChanged);
			// 
			// SaveEdit
			// 
			this.SaveEdit.AutoRoundedCorners = true;
			this.SaveEdit.BorderRadius = 18;
			this.SaveEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.SaveEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.SaveEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.SaveEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.SaveEdit.FillColor = System.Drawing.Color.Lime;
			this.SaveEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.SaveEdit.ForeColor = System.Drawing.Color.Black;
			this.SaveEdit.Location = new System.Drawing.Point(456, 429);
			this.SaveEdit.Name = "SaveEdit";
			this.SaveEdit.Size = new System.Drawing.Size(65, 38);
			this.SaveEdit.TabIndex = 85;
			this.SaveEdit.Text = "Save";
			this.SaveEdit.Click += new System.EventHandler(this.SaveEdit_Click);
			// 
			// guna2Panel7
			// 
			this.guna2Panel7.BackColor = System.Drawing.Color.Transparent;
			this.guna2Panel7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.guna2Panel7.BorderRadius = 1;
			this.guna2Panel7.Controls.Add(this.guna2GradientButton1);
			this.guna2Panel7.Controls.Add(this.guna2Panel4);
			this.guna2Panel7.CustomBorderColor = System.Drawing.Color.Black;
			this.guna2Panel7.CustomBorderThickness = new System.Windows.Forms.Padding(0, 2, 0, 3);
			this.guna2Panel7.Location = new System.Drawing.Point(375, 36);
			this.guna2Panel7.Name = "guna2Panel7";
			this.guna2Panel7.Size = new System.Drawing.Size(219, 224);
			this.guna2Panel7.TabIndex = 84;
			// 
			// guna2GradientButton1
			// 
			this.guna2GradientButton1.Animated = true;
			this.guna2GradientButton1.AutoRoundedCorners = true;
			this.guna2GradientButton1.BorderRadius = 12;
			this.guna2GradientButton1.DefaultAutoSize = true;
			this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
			this.guna2GradientButton1.Location = new System.Drawing.Point(98, 187);
			this.guna2GradientButton1.Name = "guna2GradientButton1";
			this.guna2GradientButton1.Size = new System.Drawing.Size(105, 27);
			this.guna2GradientButton1.TabIndex = 89;
			this.guna2GradientButton1.Text = "Update Photo";
			this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
			// 
			// guna2Panel4
			// 
			this.guna2Panel4.Controls.Add(this.empImg1);
			this.guna2Panel4.CustomBorderColor = System.Drawing.Color.Brown;
			this.guna2Panel4.CustomBorderThickness = new System.Windows.Forms.Padding(0, 2, 0, 2);
			this.guna2Panel4.Location = new System.Drawing.Point(17, 18);
			this.guna2Panel4.Name = "guna2Panel4";
			this.guna2Panel4.Size = new System.Drawing.Size(186, 156);
			this.guna2Panel4.TabIndex = 2;
			// 
			// empImg1
			// 
			this.empImg1.Location = new System.Drawing.Point(0, 3);
			this.empImg1.Name = "empImg1";
			this.empImg1.Size = new System.Drawing.Size(186, 150);
			this.empImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.empImg1.TabIndex = 1;
			this.empImg1.TabStop = false;
			// 
			// btnEmpEdit
			// 
			this.btnEmpEdit.AutoRoundedCorners = true;
			this.btnEmpEdit.BorderRadius = 18;
			this.btnEmpEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnEmpEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnEmpEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnEmpEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnEmpEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.btnEmpEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnEmpEdit.ForeColor = System.Drawing.Color.Black;
			this.btnEmpEdit.Location = new System.Drawing.Point(529, 429);
			this.btnEmpEdit.Name = "btnEmpEdit";
			this.btnEmpEdit.Size = new System.Drawing.Size(65, 38);
			this.btnEmpEdit.TabIndex = 83;
			this.btnEmpEdit.Text = "Edit";
			this.btnEmpEdit.Click += new System.EventHandler(this.btnEmpEdit_Click);
			// 
			// guna2Panel5
			// 
			this.guna2Panel5.BackColor = System.Drawing.Color.Cornsilk;
			this.guna2Panel5.BorderColor = System.Drawing.Color.White;
			this.guna2Panel5.Controls.Add(this.label3);
			this.guna2Panel5.Controls.Add(this.label2);
			this.guna2Panel5.Controls.Add(this.ReportsToTextBox1);
			this.guna2Panel5.Controls.Add(this.DesignationNameTextBox2);
			this.guna2Panel5.Controls.Add(this.DepartmentNameTextBox1);
			this.guna2Panel5.Controls.Add(this.reportsToEmployeeComboBox);
			this.guna2Panel5.Controls.Add(this.designationNameComboBox);
			this.guna2Panel5.Controls.Add(this.EmployeeContactNumberTextBox1);
			this.guna2Panel5.Controls.Add(this.EmployeeRfidTagTextBox1);
			this.guna2Panel5.Controls.Add(this.NA);
			this.guna2Panel5.Controls.Add(this.EmployeeNameTextBox1);
			this.guna2Panel5.Controls.Add(this.emplabel);
			this.guna2Panel5.Controls.Add(employeeRfidTagLabel);
			this.guna2Panel5.Controls.Add(employeeNameLabel);
			this.guna2Panel5.Controls.Add(employeeAddressLabel);
			this.guna2Panel5.Controls.Add(employeeContactNumberLabel);
			this.guna2Panel5.Controls.Add(departmentNameLabel1);
			this.guna2Panel5.Controls.Add(designationNameLabel);
			this.guna2Panel5.Controls.Add(reportsToLabel);
			this.guna2Panel5.Controls.Add(this.departmentNameComboBox);
			this.guna2Panel5.Controls.Add(this.EmployeeAddressTextBox1);
			this.guna2Panel5.Controls.Add(this.Address);
			this.guna2Panel5.CustomBorderColor = System.Drawing.Color.DarkRed;
			this.guna2Panel5.CustomBorderThickness = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.guna2Panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
			this.guna2Panel5.Location = new System.Drawing.Point(12, 8);
			this.guna2Panel5.Name = "guna2Panel5";
			this.guna2Panel5.Size = new System.Drawing.Size(341, 461);
			this.guna2Panel5.TabIndex = 82;
			// 
			// ReportsToTextBox1
			// 
			this.ReportsToTextBox1.BackColor = System.Drawing.Color.Cornsilk;
			// 
			// 
			// 
			this.ReportsToTextBox1.CustomButton.Image = null;
			this.ReportsToTextBox1.CustomButton.Location = new System.Drawing.Point(163, 1);
			this.ReportsToTextBox1.CustomButton.Name = "";
			this.ReportsToTextBox1.CustomButton.Size = new System.Drawing.Size(27, 27);
			this.ReportsToTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.ReportsToTextBox1.CustomButton.TabIndex = 1;
			this.ReportsToTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.ReportsToTextBox1.CustomButton.UseSelectable = true;
			this.ReportsToTextBox1.CustomButton.Visible = false;
			this.ReportsToTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.ReportsToTextBox1.ForeColor = System.Drawing.Color.Brown;
			this.ReportsToTextBox1.Lines = new string[0];
			this.ReportsToTextBox1.Location = new System.Drawing.Point(78, 404);
			this.ReportsToTextBox1.MaxLength = 32767;
			this.ReportsToTextBox1.Name = "ReportsToTextBox1";
			this.ReportsToTextBox1.PasswordChar = '\0';
			this.ReportsToTextBox1.PromptText = "Reports To";
			this.ReportsToTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.ReportsToTextBox1.SelectedText = "";
			this.ReportsToTextBox1.SelectionLength = 0;
			this.ReportsToTextBox1.SelectionStart = 0;
			this.ReportsToTextBox1.ShortcutsEnabled = true;
			this.ReportsToTextBox1.Size = new System.Drawing.Size(191, 29);
			this.ReportsToTextBox1.Style = MetroFramework.MetroColorStyle.Red;
			this.ReportsToTextBox1.TabIndex = 6;
			this.ReportsToTextBox1.UseCustomBackColor = true;
			this.ReportsToTextBox1.UseCustomForeColor = true;
			this.ReportsToTextBox1.UseSelectable = true;
			this.ReportsToTextBox1.UseStyleColors = true;
			this.ReportsToTextBox1.WaterMark = "Reports To";
			this.ReportsToTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.ReportsToTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// DesignationNameTextBox2
			// 
			this.DesignationNameTextBox2.BackColor = System.Drawing.Color.Cornsilk;
			// 
			// 
			// 
			this.DesignationNameTextBox2.CustomButton.Image = null;
			this.DesignationNameTextBox2.CustomButton.Location = new System.Drawing.Point(163, 1);
			this.DesignationNameTextBox2.CustomButton.Name = "";
			this.DesignationNameTextBox2.CustomButton.Size = new System.Drawing.Size(27, 27);
			this.DesignationNameTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.DesignationNameTextBox2.CustomButton.TabIndex = 1;
			this.DesignationNameTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.DesignationNameTextBox2.CustomButton.UseSelectable = true;
			this.DesignationNameTextBox2.CustomButton.Visible = false;
			this.DesignationNameTextBox2.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.DesignationNameTextBox2.ForeColor = System.Drawing.Color.Brown;
			this.DesignationNameTextBox2.Lines = new string[0];
			this.DesignationNameTextBox2.Location = new System.Drawing.Point(78, 353);
			this.DesignationNameTextBox2.MaxLength = 32767;
			this.DesignationNameTextBox2.Name = "DesignationNameTextBox2";
			this.DesignationNameTextBox2.PasswordChar = '\0';
			this.DesignationNameTextBox2.PromptText = "Designation Name";
			this.DesignationNameTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.DesignationNameTextBox2.SelectedText = "";
			this.DesignationNameTextBox2.SelectionLength = 0;
			this.DesignationNameTextBox2.SelectionStart = 0;
			this.DesignationNameTextBox2.ShortcutsEnabled = true;
			this.DesignationNameTextBox2.Size = new System.Drawing.Size(191, 29);
			this.DesignationNameTextBox2.Style = MetroFramework.MetroColorStyle.Red;
			this.DesignationNameTextBox2.TabIndex = 5;
			this.DesignationNameTextBox2.UseCustomBackColor = true;
			this.DesignationNameTextBox2.UseCustomForeColor = true;
			this.DesignationNameTextBox2.UseSelectable = true;
			this.DesignationNameTextBox2.UseStyleColors = true;
			this.DesignationNameTextBox2.WaterMark = "Designation Name";
			this.DesignationNameTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.DesignationNameTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// DepartmentNameTextBox1
			// 
			this.DepartmentNameTextBox1.BackColor = System.Drawing.Color.Cornsilk;
			// 
			// 
			// 
			this.DepartmentNameTextBox1.CustomButton.Image = null;
			this.DepartmentNameTextBox1.CustomButton.Location = new System.Drawing.Point(163, 1);
			this.DepartmentNameTextBox1.CustomButton.Name = "";
			this.DepartmentNameTextBox1.CustomButton.Size = new System.Drawing.Size(27, 27);
			this.DepartmentNameTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.DepartmentNameTextBox1.CustomButton.TabIndex = 1;
			this.DepartmentNameTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.DepartmentNameTextBox1.CustomButton.UseSelectable = true;
			this.DepartmentNameTextBox1.CustomButton.Visible = false;
			this.DepartmentNameTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.DepartmentNameTextBox1.ForeColor = System.Drawing.Color.Brown;
			this.DepartmentNameTextBox1.Lines = new string[0];
			this.DepartmentNameTextBox1.Location = new System.Drawing.Point(78, 302);
			this.DepartmentNameTextBox1.MaxLength = 32767;
			this.DepartmentNameTextBox1.Name = "DepartmentNameTextBox1";
			this.DepartmentNameTextBox1.PasswordChar = '\0';
			this.DepartmentNameTextBox1.PromptText = "Department Name";
			this.DepartmentNameTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.DepartmentNameTextBox1.SelectedText = "";
			this.DepartmentNameTextBox1.SelectionLength = 0;
			this.DepartmentNameTextBox1.SelectionStart = 0;
			this.DepartmentNameTextBox1.ShortcutsEnabled = true;
			this.DepartmentNameTextBox1.Size = new System.Drawing.Size(191, 29);
			this.DepartmentNameTextBox1.Style = MetroFramework.MetroColorStyle.Red;
			this.DepartmentNameTextBox1.TabIndex = 4;
			this.DepartmentNameTextBox1.UseCustomBackColor = true;
			this.DepartmentNameTextBox1.UseCustomForeColor = true;
			this.DepartmentNameTextBox1.UseSelectable = true;
			this.DepartmentNameTextBox1.UseStyleColors = true;
			this.DepartmentNameTextBox1.WaterMark = "Department Name";
			this.DepartmentNameTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.DepartmentNameTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// reportsToEmployeeComboBox
			// 
			this.reportsToEmployeeComboBox.BackColor = System.Drawing.Color.Cornsilk;
			this.reportsToEmployeeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportstoBindingSource, "ReportsToEmployee", true));
			this.reportsToEmployeeComboBox.DataSource = this.reportstoBindingSource;
			this.reportsToEmployeeComboBox.DisplayMember = "ReportsToEmployee";
			this.reportsToEmployeeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.reportsToEmployeeComboBox.ForeColor = System.Drawing.Color.Brown;
			this.reportsToEmployeeComboBox.FormattingEnabled = true;
			this.reportsToEmployeeComboBox.ItemHeight = 23;
			this.reportsToEmployeeComboBox.Location = new System.Drawing.Point(78, 404);
			this.reportsToEmployeeComboBox.MaxDropDownItems = 100;
			this.reportsToEmployeeComboBox.Name = "reportsToEmployeeComboBox";
			this.reportsToEmployeeComboBox.Size = new System.Drawing.Size(191, 29);
			this.reportsToEmployeeComboBox.Style = MetroFramework.MetroColorStyle.Red;
			this.reportsToEmployeeComboBox.TabIndex = 76;
			this.reportsToEmployeeComboBox.UseCustomBackColor = true;
			this.reportsToEmployeeComboBox.UseCustomForeColor = true;
			this.reportsToEmployeeComboBox.UseSelectable = true;
			this.reportsToEmployeeComboBox.UseStyleColors = true;
			this.reportsToEmployeeComboBox.ValueMember = "ReportsToEmployee";
			this.reportsToEmployeeComboBox.SelectedIndexChanged += new System.EventHandler(this.reportsToEmployeeComboBox_SelectedIndexChanged);
			// 
			// reportstoBindingSource
			// 
			this.reportstoBindingSource.DataMember = "reportsto";
			this.reportstoBindingSource.DataSource = this.ams_rfidDataSetReportsTo;
			// 
			// ams_rfidDataSetReportsTo
			// 
			this.ams_rfidDataSetReportsTo.DataSetName = "ams_rfidDataSetReportsTo";
			this.ams_rfidDataSetReportsTo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// designationNameComboBox
			// 
			this.designationNameComboBox.BackColor = System.Drawing.Color.Cornsilk;
			this.designationNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.designationBindingSource, "designationName", true));
			this.designationNameComboBox.DataSource = this.designationBindingSource;
			this.designationNameComboBox.DisplayMember = "designationName";
			this.designationNameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.designationNameComboBox.ForeColor = System.Drawing.Color.Brown;
			this.designationNameComboBox.FormattingEnabled = true;
			this.designationNameComboBox.ItemHeight = 23;
			this.designationNameComboBox.Location = new System.Drawing.Point(78, 353);
			this.designationNameComboBox.MaxDropDownItems = 100;
			this.designationNameComboBox.Name = "designationNameComboBox";
			this.designationNameComboBox.Size = new System.Drawing.Size(191, 29);
			this.designationNameComboBox.Style = MetroFramework.MetroColorStyle.Red;
			this.designationNameComboBox.TabIndex = 75;
			this.designationNameComboBox.UseCustomBackColor = true;
			this.designationNameComboBox.UseCustomForeColor = true;
			this.designationNameComboBox.UseSelectable = true;
			this.designationNameComboBox.UseStyleColors = true;
			this.designationNameComboBox.ValueMember = "designationName";
			this.designationNameComboBox.SelectedIndexChanged += new System.EventHandler(this.designationNameComboBox_SelectedIndexChanged);
			// 
			// designationBindingSource
			// 
			this.designationBindingSource.DataMember = "designation";
			this.designationBindingSource.DataSource = this.ams_rfidDataSet1;
			// 
			// ams_rfidDataSet1
			// 
			this.ams_rfidDataSet1.DataSetName = "ams_rfidDataSet1";
			this.ams_rfidDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// EmployeeContactNumberTextBox1
			// 
			this.EmployeeContactNumberTextBox1.BackColor = System.Drawing.Color.Cornsilk;
			// 
			// 
			// 
			this.EmployeeContactNumberTextBox1.CustomButton.Image = null;
			this.EmployeeContactNumberTextBox1.CustomButton.Location = new System.Drawing.Point(100, 1);
			this.EmployeeContactNumberTextBox1.CustomButton.Name = "";
			this.EmployeeContactNumberTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.EmployeeContactNumberTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.EmployeeContactNumberTextBox1.CustomButton.TabIndex = 1;
			this.EmployeeContactNumberTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.EmployeeContactNumberTextBox1.CustomButton.UseSelectable = true;
			this.EmployeeContactNumberTextBox1.CustomButton.Visible = false;
			this.EmployeeContactNumberTextBox1.ForeColor = System.Drawing.Color.Brown;
			this.EmployeeContactNumberTextBox1.Lines = new string[0];
			this.EmployeeContactNumberTextBox1.Location = new System.Drawing.Point(78, 257);
			this.EmployeeContactNumberTextBox1.MaxLength = 11;
			this.EmployeeContactNumberTextBox1.Name = "EmployeeContactNumberTextBox1";
			this.EmployeeContactNumberTextBox1.PasswordChar = '\0';
			this.EmployeeContactNumberTextBox1.PromptText = "Contact No.";
			this.EmployeeContactNumberTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.EmployeeContactNumberTextBox1.SelectedText = "";
			this.EmployeeContactNumberTextBox1.SelectionLength = 0;
			this.EmployeeContactNumberTextBox1.SelectionStart = 0;
			this.EmployeeContactNumberTextBox1.ShortcutsEnabled = true;
			this.EmployeeContactNumberTextBox1.Size = new System.Drawing.Size(122, 23);
			this.EmployeeContactNumberTextBox1.Style = MetroFramework.MetroColorStyle.Red;
			this.EmployeeContactNumberTextBox1.TabIndex = 3;
			this.EmployeeContactNumberTextBox1.UseCustomBackColor = true;
			this.EmployeeContactNumberTextBox1.UseCustomForeColor = true;
			this.EmployeeContactNumberTextBox1.UseSelectable = true;
			this.EmployeeContactNumberTextBox1.UseStyleColors = true;
			this.EmployeeContactNumberTextBox1.WaterMark = "Contact No.";
			this.EmployeeContactNumberTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.EmployeeContactNumberTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// EmployeeRfidTagTextBox1
			// 
			this.EmployeeRfidTagTextBox1.BackColor = System.Drawing.Color.Cornsilk;
			// 
			// 
			// 
			this.EmployeeRfidTagTextBox1.CustomButton.Image = null;
			this.EmployeeRfidTagTextBox1.CustomButton.Location = new System.Drawing.Point(104, 1);
			this.EmployeeRfidTagTextBox1.CustomButton.Name = "";
			this.EmployeeRfidTagTextBox1.CustomButton.Size = new System.Drawing.Size(27, 27);
			this.EmployeeRfidTagTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.EmployeeRfidTagTextBox1.CustomButton.TabIndex = 1;
			this.EmployeeRfidTagTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.EmployeeRfidTagTextBox1.CustomButton.UseSelectable = true;
			this.EmployeeRfidTagTextBox1.CustomButton.Visible = false;
			this.EmployeeRfidTagTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.EmployeeRfidTagTextBox1.ForeColor = System.Drawing.Color.Brown;
			this.EmployeeRfidTagTextBox1.Lines = new string[0];
			this.EmployeeRfidTagTextBox1.Location = new System.Drawing.Point(116, 77);
			this.EmployeeRfidTagTextBox1.MaxLength = 32767;
			this.EmployeeRfidTagTextBox1.Name = "EmployeeRfidTagTextBox1";
			this.EmployeeRfidTagTextBox1.PasswordChar = '\0';
			this.EmployeeRfidTagTextBox1.PromptText = "RFID TAG";
			this.EmployeeRfidTagTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.EmployeeRfidTagTextBox1.SelectedText = "";
			this.EmployeeRfidTagTextBox1.SelectionLength = 0;
			this.EmployeeRfidTagTextBox1.SelectionStart = 0;
			this.EmployeeRfidTagTextBox1.ShortcutsEnabled = true;
			this.EmployeeRfidTagTextBox1.Size = new System.Drawing.Size(132, 29);
			this.EmployeeRfidTagTextBox1.Style = MetroFramework.MetroColorStyle.Red;
			this.EmployeeRfidTagTextBox1.TabIndex = 0;
			this.EmployeeRfidTagTextBox1.UseCustomBackColor = true;
			this.EmployeeRfidTagTextBox1.UseCustomForeColor = true;
			this.EmployeeRfidTagTextBox1.UseSelectable = true;
			this.EmployeeRfidTagTextBox1.UseStyleColors = true;
			this.EmployeeRfidTagTextBox1.WaterMark = "RFID TAG";
			this.EmployeeRfidTagTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.EmployeeRfidTagTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// NA
			// 
			this.NA.Animated = true;
			this.NA.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.NA.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.NA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.NA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.NA.FillColor = System.Drawing.Color.Silver;
			this.NA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
			this.NA.ForeColor = System.Drawing.Color.White;
			this.NA.Location = new System.Drawing.Point(208, 258);
			this.NA.Name = "NA";
			this.NA.PressedColor = System.Drawing.Color.Silver;
			this.NA.Size = new System.Drawing.Size(61, 20);
			this.NA.TabIndex = 16;
			this.NA.Text = "N/A";
			this.NA.Visible = false;
			// 
			// EmployeeNameTextBox1
			// 
			this.EmployeeNameTextBox1.BackColor = System.Drawing.Color.Cornsilk;
			// 
			// 
			// 
			this.EmployeeNameTextBox1.CustomButton.Image = null;
			this.EmployeeNameTextBox1.CustomButton.Location = new System.Drawing.Point(163, 1);
			this.EmployeeNameTextBox1.CustomButton.Name = "";
			this.EmployeeNameTextBox1.CustomButton.Size = new System.Drawing.Size(27, 27);
			this.EmployeeNameTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.EmployeeNameTextBox1.CustomButton.TabIndex = 1;
			this.EmployeeNameTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.EmployeeNameTextBox1.CustomButton.UseSelectable = true;
			this.EmployeeNameTextBox1.CustomButton.Visible = false;
			this.EmployeeNameTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.EmployeeNameTextBox1.ForeColor = System.Drawing.Color.Brown;
			this.EmployeeNameTextBox1.Lines = new string[0];
			this.EmployeeNameTextBox1.Location = new System.Drawing.Point(78, 136);
			this.EmployeeNameTextBox1.MaxLength = 32767;
			this.EmployeeNameTextBox1.Name = "EmployeeNameTextBox1";
			this.EmployeeNameTextBox1.PasswordChar = '\0';
			this.EmployeeNameTextBox1.PromptText = "Name";
			this.EmployeeNameTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.EmployeeNameTextBox1.SelectedText = "";
			this.EmployeeNameTextBox1.SelectionLength = 0;
			this.EmployeeNameTextBox1.SelectionStart = 0;
			this.EmployeeNameTextBox1.ShortcutsEnabled = true;
			this.EmployeeNameTextBox1.Size = new System.Drawing.Size(191, 29);
			this.EmployeeNameTextBox1.Style = MetroFramework.MetroColorStyle.Red;
			this.EmployeeNameTextBox1.TabIndex = 1;
			this.EmployeeNameTextBox1.UseCustomBackColor = true;
			this.EmployeeNameTextBox1.UseCustomForeColor = true;
			this.EmployeeNameTextBox1.UseSelectable = true;
			this.EmployeeNameTextBox1.UseStyleColors = true;
			this.EmployeeNameTextBox1.WaterMark = "Name";
			this.EmployeeNameTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.EmployeeNameTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			// 
			// emplabel
			// 
			this.emplabel.AutoSize = true;
			this.emplabel.BackColor = System.Drawing.Color.Transparent;
			this.emplabel.Font = new System.Drawing.Font("Malgun Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.emplabel.ForeColor = System.Drawing.Color.Brown;
			this.emplabel.Location = new System.Drawing.Point(84, 0);
			this.emplabel.Name = "emplabel";
			this.emplabel.Size = new System.Drawing.Size(182, 45);
			this.emplabel.TabIndex = 58;
			this.emplabel.Text = "EMPLOYEE";
			// 
			// departmentNameComboBox
			// 
			this.departmentNameComboBox.BackColor = System.Drawing.Color.Cornsilk;
			this.departmentNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.departmentBindingSource, "DepartmentName", true));
			this.departmentNameComboBox.DataSource = this.departmentBindingSource;
			this.departmentNameComboBox.DisplayMember = "DepartmentName";
			this.departmentNameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.departmentNameComboBox.ForeColor = System.Drawing.Color.Brown;
			this.departmentNameComboBox.FormattingEnabled = true;
			this.departmentNameComboBox.ItemHeight = 23;
			this.departmentNameComboBox.Location = new System.Drawing.Point(78, 302);
			this.departmentNameComboBox.MaxDropDownItems = 100;
			this.departmentNameComboBox.Name = "departmentNameComboBox";
			this.departmentNameComboBox.Size = new System.Drawing.Size(191, 29);
			this.departmentNameComboBox.Style = MetroFramework.MetroColorStyle.Red;
			this.departmentNameComboBox.TabIndex = 74;
			this.departmentNameComboBox.UseCustomBackColor = true;
			this.departmentNameComboBox.UseCustomForeColor = true;
			this.departmentNameComboBox.UseSelectable = true;
			this.departmentNameComboBox.UseStyleColors = true;
			this.departmentNameComboBox.ValueMember = "DepartmentName";
			this.departmentNameComboBox.SelectedIndexChanged += new System.EventHandler(this.departmentNameComboBox_SelectedIndexChanged);
			// 
			// departmentBindingSource
			// 
			this.departmentBindingSource.DataMember = "department";
			this.departmentBindingSource.DataSource = this.ams_rfidDataSet;
			// 
			// ams_rfidDataSet
			// 
			this.ams_rfidDataSet.DataSetName = "ams_rfidDataSet";
			this.ams_rfidDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// EmployeeAddressTextBox1
			// 
			this.EmployeeAddressTextBox1.BackColor = System.Drawing.Color.Cornsilk;
			// 
			// 
			// 
			this.EmployeeAddressTextBox1.CustomButton.Image = null;
			this.EmployeeAddressTextBox1.CustomButton.Location = new System.Drawing.Point(196, 1);
			this.EmployeeAddressTextBox1.CustomButton.Name = "";
			this.EmployeeAddressTextBox1.CustomButton.Size = new System.Drawing.Size(27, 27);
			this.EmployeeAddressTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.EmployeeAddressTextBox1.CustomButton.TabIndex = 1;
			this.EmployeeAddressTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.EmployeeAddressTextBox1.CustomButton.UseSelectable = true;
			this.EmployeeAddressTextBox1.CustomButton.Visible = false;
			this.EmployeeAddressTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.EmployeeAddressTextBox1.ForeColor = System.Drawing.Color.Brown;
			this.EmployeeAddressTextBox1.Lines = new string[0];
			this.EmployeeAddressTextBox1.Location = new System.Drawing.Point(78, 206);
			this.EmployeeAddressTextBox1.MaxLength = 32767;
			this.EmployeeAddressTextBox1.Name = "EmployeeAddressTextBox1";
			this.EmployeeAddressTextBox1.PasswordChar = '\0';
			this.EmployeeAddressTextBox1.PromptText = "Address";
			this.EmployeeAddressTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.EmployeeAddressTextBox1.SelectedText = "";
			this.EmployeeAddressTextBox1.SelectionLength = 0;
			this.EmployeeAddressTextBox1.SelectionStart = 0;
			this.EmployeeAddressTextBox1.ShortcutsEnabled = true;
			this.EmployeeAddressTextBox1.Size = new System.Drawing.Size(224, 29);
			this.EmployeeAddressTextBox1.Style = MetroFramework.MetroColorStyle.Red;
			this.EmployeeAddressTextBox1.TabIndex = 2;
			this.EmployeeAddressTextBox1.UseCustomBackColor = true;
			this.EmployeeAddressTextBox1.UseCustomForeColor = true;
			this.EmployeeAddressTextBox1.UseSelectable = true;
			this.EmployeeAddressTextBox1.UseStyleColors = true;
			this.EmployeeAddressTextBox1.WaterMark = "Address";
			this.EmployeeAddressTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.EmployeeAddressTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// Address
			// 
			this.Address.BackColor = System.Drawing.Color.Cornsilk;
			this.Address.ForeColor = System.Drawing.Color.Brown;
			this.Address.FormattingEnabled = true;
			this.Address.ItemHeight = 23;
			this.Address.Items.AddRange(new object[] {
            "Alucao, Sta.Teresita, Cagayan",
            "Aridawen, Sta.Teresita, Cagayan",
            "Buyun, Sta.Teresita, Cagayan",
            "Caniugan, Sta.Teresita, Cagayan",
            "Centro East , Sta.Teresita, Cagayan",
            "Centro West , Sta.Teresita, Cagayan",
            "Dungeg, Sta.Teresita, Cagayan",
            "Luga , Sta.Teresita, Cagayan",
            "Masi , Sta.Teresita, Cagayan",
            "Mission, Sta.Teresita, Cagayan",
            "Simbaluca , Sta.Teresita, Cagayan",
            "Simpatuyo, Sta.Teresita, Cagayan",
            "VIlla , Sta.Teresita, Cagayan"});
			this.Address.Location = new System.Drawing.Point(78, 206);
			this.Address.MaxDropDownItems = 14;
			this.Address.Name = "Address";
			this.Address.Size = new System.Drawing.Size(224, 29);
			this.Address.Style = MetroFramework.MetroColorStyle.Red;
			this.Address.TabIndex = 69;
			this.Address.Theme = MetroFramework.MetroThemeStyle.Light;
			this.Address.UseCustomBackColor = true;
			this.Address.UseCustomForeColor = true;
			this.Address.UseSelectable = true;
			this.Address.UseStyleColors = true;
			this.Address.SelectedIndexChanged += new System.EventHandler(this.Address_SelectedIndexChanged);
			// 
			// guna2ControlBox1
			// 
			this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.guna2ControlBox1.CustomClick = true;
			this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
			this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new System.Drawing.Point(583, 1);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.Size = new System.Drawing.Size(30, 30);
			this.guna2ControlBox1.TabIndex = 81;
			this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
			// 
			// departmentTableAdapter
			// 
			this.departmentTableAdapter.ClearBeforeFill = true;
			// 
			// designationTableAdapter
			// 
			this.designationTableAdapter.ClearBeforeFill = true;
			// 
			// reportstoTableAdapter
			// 
			this.reportstoTableAdapter.ClearBeforeFill = true;
			// 
			// Empcmb
			// 
			this.Empcmb.FormattingEnabled = true;
			this.Empcmb.ItemHeight = 23;
			this.Empcmb.Location = new System.Drawing.Point(392, 346);
			this.Empcmb.Name = "Empcmb";
			this.Empcmb.Size = new System.Drawing.Size(198, 29);
			this.Empcmb.TabIndex = 89;
			this.Empcmb.UseCustomBackColor = true;
			this.Empcmb.UseCustomForeColor = true;
			this.Empcmb.UseSelectable = true;
			this.Empcmb.UseStyleColors = true;
			this.Empcmb.SelectedIndexChanged += new System.EventHandler(this.Empcmb_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(39, 190);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 77;
			this.label2.Text = "Current :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(100, 190);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(202, 13);
			this.label3.TabIndex = 78;
			this.label3.Text = "Simbaluca, Sta. Teresita ,cagayan";
			// 
			// EditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(614, 481);
			this.Controls.Add(this.Empcmb);
			this.Controls.Add(label1);
			this.Controls.Add(this.EmpTextbx);
			this.Controls.Add(this.SaveEdit);
			this.Controls.Add(this.guna2Panel7);
			this.Controls.Add(this.btnEmpEdit);
			this.Controls.Add(this.guna2Panel5);
			this.Controls.Add(this.guna2ControlBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(614, 481);
			this.MinimumSize = new System.Drawing.Size(614, 481);
			this.Name = "EditForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "EditForm";
			this.Load += new System.EventHandler(this.EditForm_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditForm_MouseDown);
			this.guna2Panel7.ResumeLayout(false);
			this.guna2Panel7.PerformLayout();
			this.guna2Panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.empImg1)).EndInit();
			this.guna2Panel5.ResumeLayout(false);
			this.guna2Panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.reportstoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ams_rfidDataSetReportsTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.designationBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ams_rfidDataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ams_rfidDataSet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox EmpTextbx;
        private Guna.UI2.WinForms.Guna2Button SaveEdit;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private System.Windows.Forms.PictureBox empImg1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Button btnEmpEdit;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private MetroFramework.Controls.MetroTextBox ReportsToTextBox1;
        private MetroFramework.Controls.MetroTextBox DesignationNameTextBox2;
        private MetroFramework.Controls.MetroTextBox DepartmentNameTextBox1;
        private MetroFramework.Controls.MetroComboBox reportsToEmployeeComboBox;
        private MetroFramework.Controls.MetroComboBox designationNameComboBox;
        private MetroFramework.Controls.MetroTextBox EmployeeContactNumberTextBox1;
        private MetroFramework.Controls.MetroTextBox EmployeeRfidTagTextBox1;
        private Guna.UI2.WinForms.Guna2Button NA;
        private MetroFramework.Controls.MetroTextBox EmployeeNameTextBox1;
        private System.Windows.Forms.Label emplabel;
        private MetroFramework.Controls.MetroComboBox departmentNameComboBox;
        private MetroFramework.Controls.MetroTextBox EmployeeAddressTextBox1;
        private MetroFramework.Controls.MetroComboBox Address;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private ams_rfidDataSet ams_rfidDataSet;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private ams_rfidDataSetTableAdapters.departmentTableAdapter departmentTableAdapter;
        private ams_rfidDataSet1 ams_rfidDataSet1;
        private System.Windows.Forms.BindingSource designationBindingSource;
        private ams_rfidDataSet1TableAdapters.designationTableAdapter designationTableAdapter;
        private ams_rfidDataSetReportsTo ams_rfidDataSetReportsTo;
        private System.Windows.Forms.BindingSource reportstoBindingSource;
        private ams_rfidDataSetReportsToTableAdapters.reportstoTableAdapter reportstoTableAdapter;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private MetroFramework.Controls.MetroComboBox Empcmb;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}