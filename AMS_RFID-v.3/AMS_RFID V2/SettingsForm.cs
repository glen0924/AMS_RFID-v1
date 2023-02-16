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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ams_rfidDataSet_Login.login' table. You can move, or remove it, as needed.
            //this.loginTableAdapter.Fill(this.ams_rfidDataSet_Login.login);

        }

        private void Browse_Click(object sender, EventArgs e)
        {

        }
    }
}
