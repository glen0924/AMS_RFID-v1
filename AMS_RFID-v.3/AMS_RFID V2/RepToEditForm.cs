using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS_RFID_V2
{
    public partial class RepToEditForm : Form
    {
        //mysql COnnections
        string MyDsql = "Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid; Max Pool Size=1000;Convert Zero Datetime=True";

        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public RepToEditForm()
        {
            InitializeComponent();

            ReportsTocombo.SelectedIndexChanged += ReportsTocombo_SelectedIndexChanged;
        }
        private void RepToEditForm_Load(object sender, EventArgs e)
        {
            EditFalse();
            Mysqlloop();
        }
        private void btnRepEdit_Click(object sender, EventArgs e)
        {
            if (EditCombobx.Text == "")
            {
                MessageBox.Show("No selected item in Combobox","Error",MessageBoxButtons.OK);
            }
            else if (btnRepEdit.Text == "Edit")
            {
                EditTrue();
                btnRepEdit.Text = "Cancel";
                ReportsTocombo.BringToFront();
                btnRepSave.FillColor = Color.Orange;
            }
            else
            {
                if (MessageBox.Show("Discard Changes?","Message",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    EditFalse();
                    btnRepEdit.Text = "Edit";
                    ReportsTocombo.SendToBack();
                    btnRepSave.FillColor = Color.Lime;
                    MessageBox.Show("No Changes Applied", "Message", MessageBoxButtons.OK);

                    using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
                    {
                        try
                        {
                            string QuerryRefresh = "SELECT `ReportsTOEmployee`, `Designation`, `Position` FROM reportsto WHERE ReportsToEmployee= @ReportsToEmployee";
                            MySqlCommand cmd1 = new MySqlCommand(QuerryRefresh, conn1);

                            cmd1.Parameters.AddWithValue("@ReportsToEmployee", designationTextBox.Text);
                            conn1.Open();
                            MySqlDataReader d1 = cmd1.ExecuteReader();

                            if (d1.Read())
                            {
                                reportsToEmployeeTextBox.Text = d1.GetValue(0).ToString();
                                designationTextBox.Text = d1.GetValue(1).ToString();
                                positionTextBox.Text = d1.GetValue(2).ToString();
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

        private void btnRepSave_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
            {
                try
                {
                    string QuerryRefresh = "UPDATE `reportsto` SET ReportsToEmployee= @ReportsToEmployee, Designation=@Designation, Position= @Position WHERE ReportsToEmployee= @Rep";
                    MySqlCommand cmd1 = new MySqlCommand(QuerryRefresh, conn1);

                    cmd1.Parameters.AddWithValue("@Rep", EditCombobx.Text);

                    cmd1.Parameters.AddWithValue("@ReportsToEmployee", reportsToEmployeeTextBox.Text);
                    cmd1.Parameters.AddWithValue("@Designation", designationTextBox.Text);
                    cmd1.Parameters.AddWithValue("@Position", positionTextBox.Text);

                    conn1.Open();
                    MySqlDataReader d1 = cmd1.ExecuteReader();
                    conn1.Close();            
                    MessageBox.Show("Successfully Update Information","Message");
                    btnRepEdit.Text = "Edit";
                    EditFalse();
                    EditCombobx.Items.Clear();
                    ReportsTocombo.SendToBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Mysqlloop();
        }
        void Mysqlloop()
        {
            using (MySqlConnection mysql = new MySqlConnection(MyDsql))
            {
                string querry = "SELECT ReportsToEmployee FROM reportsto";
                // string querry1 = "SELECT EmployeeName FROM employees";

                mysql.Open();
                MySqlCommand cmdO = new MySqlCommand(querry, mysql);
                MySqlDataReader readd = cmdO.ExecuteReader();

                while (readd.Read())

                {
                    EditCombobx.Items.Add(readd.GetString("ReportsToEmployee"));
                }
                mysql.Close();
            }
        }
        void ShowImg()
        {
            try
            {
                using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                {
                    string imges = "SELECT image FROM reportsto WHERE ReportsToEmployee =@ReportsToEmployee";
                    MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                    cmdO.Parameters.AddWithValue("@ReportsToEmployee", EditCombobx.Text);
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
        
        void EditTrue()
        {
            reportsToEmployeeTextBox.Enabled = true;
            designationTextBox.Enabled = true;
            positionTextBox.Enabled = true;
            btnRepSave.Enabled = true;
        }
        void EditFalse()
        {
            reportsToEmployeeTextBox.Enabled = false;
            designationTextBox.Enabled = false;
            positionTextBox.Enabled = false;
            btnRepSave.Enabled = false;
        }

        private void ReportsTocombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            positionTextBox.Text = ReportsTocombo.Text;
        }

        private void EditCombobx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowImg();
            using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
            {
                try
                {
                    string QuerryRefresh = "SELECT `ReportsTOEmployee`, `Designation`, `Position` FROM reportsto WHERE ReportsToEmployee= @ReportsToEmployee";
                    MySqlCommand cmd1 = new MySqlCommand(QuerryRefresh, conn1);

                    cmd1.Parameters.AddWithValue("@ReportsToEmployee", EditCombobx.Text);
                    conn1.Open();
                    MySqlDataReader d1 = cmd1.ExecuteReader();

                    if (d1.Read())
                    {
                        reportsToEmployeeTextBox.Text = d1.GetValue(0).ToString();
                        designationTextBox.Text = d1.GetValue(1).ToString();
                        positionTextBox.Text = d1.GetValue(2).ToString();
                    }
                    conn1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }
        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
            {
                OpenFileDialog ofpD = new OpenFileDialog();
                ofpD.InitialDirectory = @"C:\RFID\EMPSAVEIMG\";
                ofpD.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";

                if (ofpD.ShowDialog() == DialogResult.OK)
                {
                    empImg1.Image = Image.FromFile(ofpD.FileName);

                    string QuerryRefresh = "UPDATE `reportsto` SET image = @image WHERE  ReportsToEmployee= @ReportsToEmployee";
                    MySqlCommand cmd = new MySqlCommand(QuerryRefresh, conn1);

                    conn1.Open();
                    cmd.Parameters.AddWithValue("@ReportsToEmployee", EditCombobx.Text);
                    cmd.Parameters.AddWithValue("@image", File.ReadAllBytes(ofpD.FileName));

                    MySqlDataReader d = cmd.ExecuteReader();
                    MessageBox.Show("Successfully Update Information.", "Message", MessageBoxButtons.OK);

                    conn1.Close();
                }
            }
        }
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            if (btnRepEdit.Text == "Cancel")
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

        private void RepToEditForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
