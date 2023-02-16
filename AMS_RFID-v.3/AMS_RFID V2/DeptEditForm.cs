using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS_RFID_V2
{
    public partial class DeptEditForm : Form
    {
        //mysql COnnections
        string MyDsql = "Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid; Max Pool Size=1000;Convert Zero Datetime=True";


        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void DeptEditForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public DeptEditForm()
        {
            InitializeComponent();

            DeptComboSelect.SelectedIndexChanged += DeptComboSelect_SelectedIndexChanged;
        }

        private void DeptEditForm_Load(object sender, EventArgs e)
        {
            Mysqlloop();
            DeptTxtbx.Enabled = false;
            btnSave.Enabled = false;
        }
        void Mysqlloop()
        {
            using (MySqlConnection mysql = new MySqlConnection(MyDsql))
            {
                string querry = "SELECT * FROM department";
                mysql.Open();
                MySqlCommand cmdO = new MySqlCommand(querry, mysql);
                MySqlDataReader readd = cmdO.ExecuteReader();

                while (readd.Read())

                {
                    DeptComboSelect.Items.Add(readd.GetString("DepartmentName"));
                }
                mysql.Close();
            }
        }
        //save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(MyDsql))
                {
                    string querry = "UPDATE department SET DepartmentName= @DepartmentName WHERE DepartmentName= @dep";
                    // string querry1 = "SELECT EmployeeName FROM employees";

                    mysql.Open();
                    MySqlCommand cmdoy = new MySqlCommand(querry, mysql);
                    //MySqlCommand cmdoy = new MySqlCommand(querry1, mysql);

                    cmdoy.Parameters.AddWithValue("@DepartmentName", DeptTxtbx.Text);
                    cmdoy.Parameters.AddWithValue("@dep", DeptComboSelect.Text);
                    MySqlDataReader readd = cmdoy.ExecuteReader();

                    mysql.Close();
                }
                MessageBox.Show("Successfully Saved Data", "Message");
                DeptComboSelect.Items.Clear();
                Mysqlloop();

                btnEdit.Text = "Edit";
                DeptTxtbx.Clear();
                DeptTxtbx.Enabled = false;
                btnSave.FillColor = Color.Lime;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                DeptTxtbx.Focus();
            }

        }
        //edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                if (DeptTxtbx.Text == "")
                {
                    MessageBox.Show("Entry box Empty. Please select from the combobox first.", "Message", MessageBoxButtons.OK);
                }
                else
                {
                    DeptTxtbx.Enabled = true;
                    DeptTxtbx.Focus();
                    btnEdit.Text = "Cancel";
                    btnSave.FillColor = Color.Orange;
                    btnSave.Enabled = true;
                }
            }
            else
            {
                if (MessageBox.Show("Discard Changes?","Message",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== DialogResult.OK)
                {
                    DeptTxtbx.Enabled = false;
                    btnSave.FillColor = Color.Lime;
                    btnEdit.Text = "Edit";
                    MessageBox.Show("No changes has been Made", "Message", MessageBoxButtons.OK);
                    DeptComboSelect.Items.Clear();
                    DeptTxtbx.Clear();
                    Mysqlloop();
                }

            }

        }

        private void DeptComboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeptTxtbx.Text = DeptComboSelect.Text;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Cancel")
            {
                if (MessageBox.Show("Discard Changes?","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)== DialogResult.OK)
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
