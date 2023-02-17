using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS_RFID_V2
{
    public partial class EditForm : Form
    {
        //mysql COnnections
        string MyDsql = "Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid; Max Pool Size=1000;Convert Zero Datetime=True";


        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public EditForm()
        {
            InitializeComponent();

            Address.SelectedIndexChanged += Address_SelectedIndexChanged;
            designationNameComboBox.SelectedIndexChanged += designationNameComboBox_SelectedIndexChanged;
            departmentNameComboBox.SelectedIndexChanged += departmentNameComboBox_SelectedIndexChanged;
            reportsToEmployeeComboBox.SelectedIndexChanged += reportsToEmployeeComboBox_SelectedIndexChanged;
            Empcmb.SelectedIndexChanged += Empcmb_SelectedIndexChanged;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ams_rfidDataSetReportsTo.reportsto' table. You can move, or remove it, as needed.
            this.reportstoTableAdapter.Fill(this.ams_rfidDataSetReportsTo.reportsto);
            // TODO: This line of code loads data into the 'ams_rfidDataSet1.designation' table. You can move, or remove it, as needed.
            this.designationTableAdapter.Fill(this.ams_rfidDataSet1.designation);
            // TODO: This line of code loads data into the 'ams_rfidDataSet.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.ams_rfidDataSet.department);
            EmployeeRfidTagTextBox1.Enabled = false;
            EmployeeNameTextBox1.Enabled = false;
            EmployeeAddressTextBox1.Enabled = false;
            EmployeeContactNumberTextBox1.Enabled = false;
            DepartmentNameTextBox1.Enabled = false;
            DesignationNameTextBox2.Enabled = false;
            ReportsToTextBox1.Enabled = false;

            Address.Enabled = false;
            departmentNameComboBox.Enabled = false;
            designationNameComboBox.Enabled = false;
            reportsToEmployeeComboBox.Enabled = false;
            guna2GradientButton1.Enabled = false;
            SaveEdit.Enabled = false;

            EmpTextbx.Focus();

            Mysqlloop();

            label2.Visible = false;
            label3.Visible = false;

        }
        void Mysqlloop()
        {
            using (MySqlConnection mysql = new MySqlConnection(MyDsql))
            {
                string querry = "SELECT EmployeeName FROM employees";
                mysql.Open();
                MySqlCommand cmdO = new MySqlCommand(querry, mysql);
                MySqlDataReader readd = cmdO.ExecuteReader();

                while (readd.Read())

                {
                    Empcmb.Items.Add(readd.GetString("EmployeeName"));
                }
                mysql.Close();
            }
        }
        private void EditForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void EmpTextbx_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        public static Image ToImage(byte[] data)
        {
            if (data == null)
            {
                return null;
            }
            Image img;
            using (MemoryStream stream = new MemoryStream(data))
            {
                using (Image temp = Image.FromStream(stream))
                {
                    img = new Bitmap(temp);
                }
            }
            return img;
        }
        void editTrue()
        {
            EmployeeNameTextBox1.Enabled = true;
            EmployeeAddressTextBox1.Enabled = true;
            EmployeeContactNumberTextBox1.Enabled = true;
            DepartmentNameTextBox1.Enabled = true;
            DesignationNameTextBox2.Enabled = true;
            ReportsToTextBox1.Enabled = true;

            Address.Enabled = true;
            departmentNameComboBox.Enabled = true;
            designationNameComboBox.Enabled = true;
            reportsToEmployeeComboBox.Enabled = true;


            Address.BringToFront();
            departmentNameComboBox.BringToFront();
            designationNameComboBox.BringToFront();
            reportsToEmployeeComboBox.BringToFront();
            guna2GradientButton1.Enabled = true;
            SaveEdit.Enabled = true;


        }
        void EditFalse()
        {
            EmployeeRfidTagTextBox1.Enabled = false;
            EmployeeNameTextBox1.Enabled = false;
            EmployeeAddressTextBox1.Enabled = false;
            EmployeeContactNumberTextBox1.Enabled = false;
            DepartmentNameTextBox1.Enabled = false;
            DesignationNameTextBox2.Enabled = false;
            ReportsToTextBox1.Enabled = false;

            Address.Enabled = false;
            departmentNameComboBox.Enabled = false;
            designationNameComboBox.Enabled = false;
            reportsToEmployeeComboBox.Enabled = false;

            Address.SendToBack();
            departmentNameComboBox.SendToBack();
            designationNameComboBox.SendToBack();
            reportsToEmployeeComboBox.SendToBack();
        }
        private void btnEmpEdit_Click(object sender, EventArgs e)
        {
            if (btnEmpEdit.Text == "Edit")
            {
                if (Empcmb.Text == "")
                {
                    MessageBox.Show("No Selected item in combobox", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    btnEmpEdit.Text = "Cancel";
                    EmpTextbx.Focus();
                    SaveEdit.FillColor = Color.Orange;
                    editTrue();
                    label2.Visible = true;
                    label3.Visible = true;
                }
            }
            else
            {
                if (MessageBox.Show("Discard changes?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    EditFalse();
                    btnEmpEdit.Text = "Edit";
                    SaveEdit.FillColor = Color.Lime;
                    SaveEdit.Enabled = false;
                    guna2GradientButton1.Enabled = false;
                    label2.Visible = false;
                    label3.Visible = false;

                    using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
                    {
                        try
                        {
                            string QuerryRefresh = "SELECT `EmployeeRfidTag`, `EmployeeName`, `EmployeeAddress`, `EmployeeContactNumber`, `DepartmentName`, `DesignationName`, `ReportsTo` FROM employees WHERE EmployeeName= @EmployeeName";
                            MySqlCommand cmd1 = new MySqlCommand(QuerryRefresh, conn1);

                            cmd1.Parameters.AddWithValue("@EmployeeName", EmpTextbx.Text);
                            conn1.Open();
                            MySqlDataReader d1 = cmd1.ExecuteReader();

                            if (d1.Read())
                            {
                                EmployeeRfidTagTextBox1.Text = d1.GetValue(0).ToString();
                                EmployeeNameTextBox1.Text = d1.GetValue(1).ToString();
                                label3.Text = d1.GetValue(2).ToString();
                                EmployeeContactNumberTextBox1.Text = d1.GetValue(3).ToString();
                                DepartmentNameTextBox1.Text = d1.GetValue(4).ToString();
                                DesignationNameTextBox2.Text = d1.GetValue(5).ToString();
                                ReportsToTextBox1.Text = d1.GetValue(6).ToString();
                            }
                            conn1.Close();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }

                    }

                }
            }
        }

        private void Address_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeAddressTextBox1.Text = Address.Text;
        }


        
        private void designationNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DesignationNameTextBox2.Text = designationNameComboBox.Text;
        }

        private void departmentNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentNameTextBox1.Text = departmentNameComboBox.Text;
        }

        private void reportsToEmployeeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportsToTextBox1.Text = reportsToEmployeeComboBox.Text;
        }
        private const string inputFilePath = "./usa.jpg";
        private void brsweBtn_Click(object sender, EventArgs e)
        {
           // OpenFileDialog ofpD = new OpenFileDialog();
            //ofpD.InitialDirectory = @"C:\RFID\EMPSAVEIMG\";
            //ofpD.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            //if (ofpD.ShowDialog() == DialogResult.OK)
            //{
               //empImg1.Image = Image.FromFile(ofpD.FileName);
            //}
            
        }

        private void FrmWebcam12_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofpD = new OpenFileDialog();
            ofpD.InitialDirectory = @"C:\RFID\EMPSAVEIMG\";
            ofpD.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (ofpD.ShowDialog() == DialogResult.OK)
            {
                empImg1.Image = Image.FromFile(ofpD.FileName);
            }
        }

        private void SaveEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
                {
                    //string QuerryRefresh = "SELECT `EmployeeRfidTag`, `EmployeeName`, `EmployeeAddress`, `EmployeeContactNumber`, `DepartmentName`, `DesignationName`, `ReportsTo`, `image` FROM `employees` WHERE EmployeeRfidTag= @EmployeeRfidTag";
                    string QuerryRefresh = "UPDATE `employees` SET " +
                        "EmployeeRfidTag =@EmployeeRfidTag , " +
                        "EmployeeName=@EmployeeName, " +
                        "EmployeeAddress=@EmployeeAddress, " +
                        "EmployeeContactNumber=@EmployeeContactNumber, " +
                        "DepartmentName= @DepartmentName, " +
                        "DesignationName= @DesignationName, " +
                        "ReportsTo=@ReportsTo " +
                        "WHERE " +
                        "EmployeeName= @Emp";
                    MySqlCommand cmd = new MySqlCommand(QuerryRefresh, conn1);
                    //cmd.Parameters.AddWithValue("@EmployeeRfidTag", EmpTextbx.Text);

                    cmd.Parameters.AddWithValue("@Emp", Empcmb.Text);
                    cmd.Parameters.AddWithValue("@EmployeeRfidTag", EmployeeRfidTagTextBox1.Text);
                    cmd.Parameters.AddWithValue("@EmployeeName", EmployeeNameTextBox1.Text);
                    cmd.Parameters.AddWithValue("@EmployeeAddress", EmployeeAddressTextBox1.Text);
                    cmd.Parameters.AddWithValue("@EmployeeContactNumber", EmployeeContactNumberTextBox1.Text);
                    cmd.Parameters.AddWithValue("@DepartmentName", DepartmentNameTextBox1.Text);
                    cmd.Parameters.AddWithValue("@DesignationName", DesignationNameTextBox2.Text);
                    cmd.Parameters.AddWithValue("@ReportsTo", reportsToEmployeeComboBox.Text);

                    conn1.Open();

                    MySqlDataReader d = cmd.ExecuteReader();
                    conn1.Close();

                    MessageBox.Show("Successfully Update Information.", "Message", MessageBoxButtons.OK);
                    EditFalse();
                    guna2GradientButton1.Enabled = false;
                    btnEmpEdit.Text = "Edit";
                    SaveEdit.Enabled = false;
                    EmpTextbx.Focus();

                    label2.Visible = true;
                    label3.Visible = true;
                }
                Empcmb.Items.Clear();
                Mysqlloop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //update image
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
            {
                OpenFileDialog ofpD = new OpenFileDialog();
                ofpD.InitialDirectory = @"C:\RFID\EMPSAVEIMG\";
                ofpD.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";

                if (ofpD.ShowDialog() == DialogResult.OK)
                {
                    empImg1.Image = Image.FromFile(ofpD.FileName);

                    string QuerryRefresh = "UPDATE `employees` SET image = @image WHERE  EmployeeName= @EmployeeName";
                    MySqlCommand cmd = new MySqlCommand(QuerryRefresh, conn1);

                    conn1.Open();
                    cmd.Parameters.AddWithValue("@EmployeeName", EmpTextbx.Text);
                    cmd.Parameters.AddWithValue("@image", File.ReadAllBytes(ofpD.FileName));

                    MySqlDataReader d = cmd.ExecuteReader();
                    conn1.Close();

                    MessageBox.Show("Successfully Update image.", "Message", MessageBoxButtons.OK);
                }
            }
        }

        private void Empcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpTextbx.Text = Empcmb.Text;
        }

        private void EmpTextbx_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
            {
                try
                {
                    string QuerryRefresh = "SELECT `EmployeeRfidTag`, `EmployeeName`, `EmployeeAddress`, `EmployeeContactNumber`, `DepartmentName`, `DesignationName`, `ReportsTo` FROM employees WHERE EmployeeName= @EmployeeName";
                    MySqlCommand cmd = new MySqlCommand(QuerryRefresh, conn1);

                    cmd.Parameters.AddWithValue("@EmployeeName", EmpTextbx.Text);
                    conn1.Open();
                    MySqlDataReader d = cmd.ExecuteReader();

                    if (d.Read())
                    {
                        EmployeeRfidTagTextBox1.Text = d.GetValue(0).ToString();
                        EmployeeNameTextBox1.Text = d.GetValue(1).ToString();
                        EmployeeAddressTextBox1.Text = d.GetValue(2).ToString();
                        EmployeeContactNumberTextBox1.Text = d.GetValue(3).ToString();
                        DepartmentNameTextBox1.Text = d.GetValue(4).ToString();
                        DesignationNameTextBox2.Text = d.GetValue(5).ToString();
                        ReportsToTextBox1.Text = d.GetValue(6).ToString();
                    }
                    conn1.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("No Rfid Recognized");
                }

            }
            try
            {
                using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                {
                    string imges = "SELECT image FROM employees WHERE EmployeeName =@EmployeeName";
                    MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                    cmdO.Parameters.AddWithValue("@EmployeeName", EmpTextbx.Text);
                    //cmdO.Parameters.AddWithValue("@image", empImg1.Image);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                    DataTable tbk = new DataTable();

                    da.Fill(tbk);
                    byte[] img = (byte[])tbk.Rows[0][0];

                    MemoryStream ms1 = new MemoryStream(img);
                    empImg1.Image = Image.FromStream(ms1);

                    da.Dispose();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Image to display");
            }

            
            
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            if (btnEmpEdit.Text == "Cancel")
            {
                if (MessageBox.Show("Discard Changes?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
