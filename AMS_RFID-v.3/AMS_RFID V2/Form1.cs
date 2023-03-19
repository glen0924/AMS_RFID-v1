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

namespace AMS_RFID_V2
{
    public partial class LoginForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public LoginForm()
        {
            InitializeComponent();
        }
        
        private void Guna2CircleButton1_Click(object sender, EventArgs e)
        {
            MainPage Mp = new MainPage();
            Mp.Show();
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Application.Exit();
                this.Close();
            }
        }

        private void guna2PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void guna2GradientPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void guna2GradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("User Input required.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.Focus();
            }
            else
            {
				try
				{
                    using (MySqlConnection iconnect = new MySqlConnection("Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid"))
                    {
                        string query = ("SELECT username , password FROM login WHERE username=@username AND password=@password");

                        MySqlCommand cmdO = new MySqlCommand(query, iconnect);

                        cmdO.Parameters.AddWithValue("@username", username.Text);
                        cmdO.Parameters.AddWithValue("@password", password.Text);
                        iconnect.Open();
                        MySqlDataReader readd = cmdO.ExecuteReader();
                        if (readd.Read())
                        {
                            MessageBox.Show("Welcome Admin!", "Successfully Login", MessageBoxButtons.OK);
                            MainPage Mp = new MainPage();
                            Mp.Show();
                            this.Hide();

                        }
                        else
                        {
                            if (MessageBox.Show("Incorrect credentials. Are You ADMIN? ", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                            {
                                password.Focus();
                            }
                        }
                        iconnect.Close();
                    }
                }
				catch
				{
                    MessageBox.Show("Database not found. Please contact admin.","Connection Error");
				}
                
            }
            
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            string s = "Members:";
            string G = "Glenn Contreras(Programmer)";
            string C = "Cristian Silos(Database designer)";
            string E = "Eulises Gorospe(Analyst)";
            string SysName = "AMS_RFID 2022";

            MessageBox.Show("\t" + "Welcome to AMS_rfid!" + "\n" + s + "\n" + "\t" + G + "\n" + "\t" + C + "\n" + "\t" + E + "\n" + "\n" + "\t" + "\t" + SysName, "Information", MessageBoxButtons.OK);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (username.Text == "" || password.Text == "")
                {
                    MessageBox.Show("User Input Required!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    username.Focus();
                }
                else
                {
					try
					{
                        using (MySqlConnection iconnect = new MySqlConnection("Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid"))
                        {
                            string query = ("SELECT username , password FROM login WHERE username=@username AND password=@password");

                            MySqlCommand cmdO = new MySqlCommand(query, iconnect);

                            cmdO.Parameters.AddWithValue("@username", username.Text);
                            cmdO.Parameters.AddWithValue("@password", password.Text);
                            iconnect.Open();
                            MySqlDataReader readd = cmdO.ExecuteReader();
                            if (readd.Read())
                            {
                                MessageBox.Show("Welcome Admin!", "Successfully Login", MessageBoxButtons.OK);
                                MainPage Mp = new MainPage();
                                Mp.Show();
                                this.Hide();

                            }
                            else
                            {
                                if (MessageBox.Show("Incorrect credentials. Are You ADMIN? ", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                                {
                                    password.Focus();
                                }
                            }
                            iconnect.Close();
                        }
                    }
					catch
					{
                        MessageBox.Show("Database not found. Please contact admin.", "Connection Error");
                    }


                }
            }
        }
    }
}
