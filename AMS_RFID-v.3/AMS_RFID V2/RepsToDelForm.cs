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
    public partial class RepsToDelForm : Form
    {
        public RepsToDelForm()
        {
            InitializeComponent();
            RepCombobx.SelectedIndexChanged += empcombobx_SelectedIndexChanged;

        }

        private void RepsToDelForm_Load(object sender, EventArgs e)
        {
            combobox();
        }
        public string myValue
        {
            get { return NameTxt.Text; }
        }

        //mysql COnnections
        string MyDsql = "Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid; Max Pool Size=1000;Convert Zero Datetime=True";

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
        void refresh()
        {
            combobox();
        }
        void combobox()
        {
            using (MySqlConnection mysql = new MySqlConnection(MyDsql))
            {
                string querry = "SELECT * FROM reportsto";
                string querry1 = "SELECT ReportsToEmployee FROM reportsto WHERE ReportsToEmployee = @ReportsToEmployee";

                mysql.Open();
                MySqlCommand cmdO = new MySqlCommand(querry, mysql);
                MySqlCommand cmdoy = new MySqlCommand(querry1, mysql);

                cmdoy.Parameters.AddWithValue("@ReportsToEmployee", RepCombobx.Text);
                //cmdO.Parameters.AddWithValue("@EmployeeRfidTag", empcombobx.Text);
                MySqlDataReader readd = cmdO.ExecuteReader();

                while (readd.Read())

                {
                    RepCombobx.Items.Add(readd.GetString("ReportsToEmployee"));
                }
                mysql.Close();
            }
        }

        private void btnEmpDelete_Click(object sender, EventArgs e)
        {
            if (RepCombobx.Text == "")
            {
                MessageBox.Show("Please Select first from the combobox.");
            }
            else
            {
                if (MessageBox.Show("Confirm to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ReWriteAdminPass F1 = new ReWriteAdminPass();

                    F1.ShowDialog();

                    RepCombobx.Items.Clear();
                    refresh();
                    NameTxt.Clear();

                }
            }



        }
        //create variable for passing value to other form
        public static string xinput = string.Empty;

        private void empcombobx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //create a event for the value to be trigger or collect data
            xinput = NameTxt.Text;
            using (MySqlConnection mysqli = new MySqlConnection(MyDsql))
            {
                string querry1 = "SELECT `ReportsToEmployee` FROM reportsto WHERE ReportsToEmployee = @ReportsToEmployee";

                mysqli.Open();
                MySqlCommand cmdoy = new MySqlCommand(querry1, mysqli);

                cmdoy.Parameters.AddWithValue("@ReportsToEmployee", RepCombobx.Text);
                MySqlDataReader r = cmdoy.ExecuteReader();
                if (r.Read())
                {
                    NameTxt.Text = r.GetValue(0).ToString();
                }
                mysqli.Close();
            }
        }
    }
}
