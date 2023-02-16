using MySql.Data.MySqlClient;
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
    public partial class DEptDel : Form
    {
        //mysql COnnections
        string MyDsql = "Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid; Max Pool Size=1000;Convert Zero Datetime=True";

        public DEptDel()
        {
            InitializeComponent();

            DeptCombobx.SelectedIndexChanged += DeptCombobx_SelectedIndexChanged;
        }

        private void DEptDel_Load(object sender, EventArgs e)
        {
            combobox();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void DelForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        void mysql()
        {
            using (MySqlConnection mysql = new MySqlConnection(MyDsql))
            {
                string querry = "DELETE FROM department WHERE  DepartmentName = @DepartmentName";

                mysql.Open();
                MySqlCommand cmdO = new MySqlCommand(querry, mysql);

                cmdO.Parameters.AddWithValue("@DepartmentName", DeptCombobx.Text);
                MySqlDataReader readd = cmdO.ExecuteReader();

                mysql.Close();
            }
        }

        void combobox()
        {
            using (MySqlConnection mysql = new MySqlConnection(MyDsql))
            {
                string querry = "SELECT * FROM department";
                string querry1 = "SELECT DepartmentName FROM department ";

                mysql.Open();
                MySqlCommand cmdO = new MySqlCommand(querry, mysql);
                MySqlCommand cmdoy = new MySqlCommand(querry1, mysql);

                MySqlDataReader readd = cmdoy.ExecuteReader();

                while (readd.Read())

                {
                    DeptCombobx.Items.Add(readd.GetString("DepartmentName"));
                }
                mysql.Close();
            }
        }

        private void btnEmpDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                mysql();
                
                if (MessageBox.Show("Item Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    DeptCombobx.Items.Clear();
                    combobox();
                }
                
            }
            
        }

        private void DeptCombobx_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepName.Text = DeptCombobx.Text;
        }

        private void DeptNameLocator_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection mysqli = new MySqlConnection(MyDsql))
            {
                string querry1 = "SELECT `EmployeeName` FROM employees WHERE EmployeeRfidTag = @EmployeeRfidTag";

                mysqli.Open();
                MySqlCommand cmdoy = new MySqlCommand(querry1, mysqli);

                cmdoy.Parameters.AddWithValue("@EmployeeRfidTag", DeptNameLocator.Text);
                MySqlDataReader r = cmdoy.ExecuteReader();
                if (r.Read())
                {
                    DepName.Text = r.GetValue(0).ToString();
                }
                mysqli.Close();
            }
        }
    }
}
