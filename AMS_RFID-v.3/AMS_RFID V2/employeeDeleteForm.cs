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
    public partial class employeeDeleteForm : Form
    {
        public employeeDeleteForm()
        {
            InitializeComponent();
        }
        void Mysql()
        {
            using (MySqlConnection mysql = new MySqlConnection("server=localhost;user id=AMS_RFID;password=@M$_Rf1d2O22;persistsecurityinfo=True;database=ams_rfid;allowuservariables=True;connectionlifetime=100"))
            {
                string imges = "SELECT image FROM employees WHERE EmployeeRfidTag =@EmployeeRfidTag";
                MySqlCommand cmdO = new MySqlCommand(imges, mysql);

                cmdO.Parameters.AddWithValue("@EmployeeRfidTag", employeeCombobx.Text);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
