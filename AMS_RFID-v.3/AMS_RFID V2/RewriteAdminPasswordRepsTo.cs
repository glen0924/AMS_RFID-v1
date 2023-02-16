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
    public partial class RewriteAdminPasswordRepsTo : Form
    {
        //mysql COnnections
        string MyDsql = "Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid; Max Pool Size=1000;Convert Zero Datetime=True";

        public RewriteAdminPasswordRepsTo()
        {
            InitializeComponent();
        }

        private void RewriteAdminPasswordRepsTo_Load(object sender, EventArgs e)
        {
            //getvalue from other form
            string getValue = string.Empty;
            getValue = EmployeeDelForm.xinput;

            SelectName.Text = getValue;
        }
        void sql()
        {
            try
            {
                using (MySqlConnection msql = new MySqlConnection(MyDsql))
                {
                    string Querry = "SELECT password FROM login WHERE password=@password";
                    MySqlCommand cmd = new MySqlCommand(Querry, msql);
                    msql.Open();
                    cmd.Parameters.AddWithValue("@password", password.Text);

                    MySqlDataReader read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        using (MySqlConnection mysql = new MySqlConnection(MyDsql))
                        {
                            string querry = "DELETE FROM reportsto WHERE  ReportsToEmployee = @ReportsToEmployee";

                            mysql.Open();
                            MySqlCommand cmdO = new MySqlCommand(querry, mysql);

                            cmdO.Parameters.AddWithValue("@ReportsToEmployee", SelectName.Text);
                            MySqlDataReader readd = cmdO.ExecuteReader();

                            mysql.Close();

                            if (MessageBox.Show("Item Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error); ;
                    }
                    msql.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (password.Text == "")
                {
                    MessageBox.Show("Password Required/Cheked Required");
                }
                else if (checkbx.Checked == false)
                {
                    MessageBox.Show("checkbox Required");
                }
                else
                {
                    sql();
                }
            }

        }

        private void checkbx_CheckedChanged(object sender, EventArgs e)
        {
            password.Focus();
        }
    }
}
