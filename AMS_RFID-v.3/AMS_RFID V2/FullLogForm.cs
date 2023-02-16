using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AMS_RFID_V2
{
    public partial class FullLogForm : Form
    {
        //mysql COnnections
        private string MyDsql = "Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid; Max Pool Size=1000;Convert Zero Datetime=True";

        public FullLogForm()
        {
            InitializeComponent();
        }

        private void FullLogForm_Load(object sender, EventArgs e)
        {

        }
    }
}