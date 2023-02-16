using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace AMS_RFID_V2
{
    public partial class EmployeeDelForm : Form
    {
        public string myValue
        {
            get { return Namess.Text; }
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

        public EmployeeDelForm()
        {
            InitializeComponent();

            empcombobx.SelectedIndexChanged += empcombobx_SelectedIndexChanged;
        }
        private void EmployeeDelForm_Load(object sender, EventArgs e)
        {
            combobox();
        }

        void mysql()
        {
            using (MySqlConnection mysql = new MySqlConnection(MyDsql))
            {
                string querry = "DELETE FROM employees WHERE  EmployeeName = @EmployeeName";

                mysql.Open();
                MySqlCommand cmdO = new MySqlCommand(querry, mysql);

                cmdO.Parameters.AddWithValue("@EmployeeName", empcombobx.Text);
                MySqlDataReader readd = cmdO.ExecuteReader();

                mysql.Close();

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
                string querry = "SELECT * FROM employees";
                string querry1 = "SELECT EmployeeName FROM employees WHERE EmployeeName = @EmployeeName";

                mysql.Open();
                MySqlCommand cmdO = new MySqlCommand(querry, mysql);
                MySqlCommand cmdoy = new MySqlCommand(querry1, mysql);

                cmdoy.Parameters.AddWithValue("@EmployeeName", empcombobx.Text);
                //cmdO.Parameters.AddWithValue("@EmployeeRfidTag", empcombobx.Text);
                MySqlDataReader readd = cmdO.ExecuteReader();
                
                while (readd.Read())
                    
                {
                    empcombobx.Items.Add(readd.GetString("EmployeeName"));
                }
                mysql.Close();
            }
        }

        private void btnEmpDelete_Click(object sender, EventArgs e)
        {
            if (empcombobx.Text == "")
            {
                MessageBox.Show("Please Select first from the combobox.");
            }
            else
            {
                if (MessageBox.Show("Confirm to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ReWriteAdminPass F1 = new ReWriteAdminPass();

                    F1.ShowDialog();

                    empcombobx.Items.Clear();
                    refresh();
                    Namess.Clear();
                
                }
            }


            
        }
        //create variable for passing value to other form
        public static string xinput = string.Empty;

        private void empcombobx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //create a event for the value to be trigger or collect data
            xinput = Namess.Text;
            using (MySqlConnection mysqli = new MySqlConnection(MyDsql))
            {
                string querry1 = "SELECT `EmployeeRfidTag` FROM employees WHERE EmployeeName = @EmployeeName";

                mysqli.Open();
                MySqlCommand cmdoy = new MySqlCommand(querry1, mysqli);

                cmdoy.Parameters.AddWithValue("@EmployeeName", empcombobx.Text);
                MySqlDataReader r = cmdoy.ExecuteReader();
                if (r.Read())
                {
                    Namess.Text = r.GetValue(0).ToString();
                }
                mysqli.Close();
            }
        }
       

    }
}
