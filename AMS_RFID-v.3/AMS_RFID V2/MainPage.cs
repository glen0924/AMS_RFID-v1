using AForge.Video;
using AForge.Video.DirectShow;
using CrystalDecisions.CrystalReports.Engine;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AMS_RFID_V2
{
    public partial class MainPage : Form
    {
        //mysql COnnections
        private string MyDsql = "Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid; Max Pool Size=1000;Convert Zero Datetime=True";

        #region Autoclosemsgbx

        //auto close message
        public class AutoClosingMessageBox
        {
            private System.Threading.Timer _timeoutTimer;
            private string _caption;

            private AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }

            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }

            private void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }

            private const int WM_CLOSE = 0x0010;

            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        #endregion Autoclosemsgbx

        #region Mouse

        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion Mouse

        #region Image Properties

        //video Properties
        private readonly FilterInfoCollection VideoCaptureDevices;
        public FilterInfoCollection VideoCaptureDevices1;

        private VideoCaptureDevice FinalVideo;
        private Image<Bgr, Byte> currentFrame;
        private Capture grabber;
        private HaarCascade face;
        private HaarCascade eye;
        private MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        private Image<Gray, byte> result, TrainedFace = null;
        private Image<Gray, byte> gray = null;
        private List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        private List<string> labels = new List<string>();
        private List<string> NamePersons = new List<string>();
        private int ContTrain, NumLabels, t;
        private string name, names = null;
        private bool streaming;
        private Capture CaptureApp;

        #endregion Image Properties

        #region MainpAge

        public MainPage()
        {
            InitializeComponent();

            departmentNameComboBox.SelectedIndexChanged += departmentNameComboBox_SelectedIndexChanged;
            designationNameComboBox.SelectedIndexChanged += designationNameComboBox_SelectedIndexChanged;
            reportsToEmployeeComboBox.SelectedIndexChanged += reportsToEmployeeComboBox_SelectedIndexChanged;
            employeeNameComboBox.SelectedIndexChanged += employeeNameComboBox_SelectedIndexChanged;
            Address.SelectedIndexChanged += Address_SelectedIndexChanged;
            ReportsTocombo.SelectedIndexChanged += ReportsTocombo_SelectedIndexChanged;
            employeeNameComboBox.SelectedIndexChanged += metroComboBox1_SelectedIndexChanged;

            //video source
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                WebCamSelect.Items.Add(VideoCaptureDevice.Name);
                WebCamSelect.SelectedIndex = 0;
            }
            FinalVideo = new VideoCaptureDevice();
            //CaptureApp = new Capture(WebCamSelect.SelectedIndex);

            //video source
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                WebCamSelect1.Items.Add(VideoCaptureDevice.Name);
                WebCamSelect.SelectedIndex = 0;
            }
            FinalVideo = new VideoCaptureDevice();
            //CaptureApp = new Capture(WebCamSelect.SelectedIndex);

            DoubleBuffered = true;

            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                string fileName = @"C:\\RFID\\TrainedFaces\\TrainedLabels.txt";
                string fileName1 = @"C:\\RFID\\TrainedFaces\\face";
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + fileName);
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + fileName1 + LoadFaces));
                    labels.Add(Labels[tf]);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                // MessageBox.Show("rgrg");
            }
        }

        //double buffer for smooth gfx (do not modify)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparams = base.CreateParams;
                handleparams.ExStyle |= 0x08000000;
                return handleparams;
            }
        }

        #endregion MainpAge

        #region LOAD

        //LOAD//
        private void MainPage_Load(object sender, EventArgs e)
        {
            //this.Activate();
            DtrbyDate();
            Mysqlloop();
            // TODO: This line of code loads data into the 'ams_rfidDataSetAttendance.attendance' table. You can move, or remove it, as needed.
            this.attendanceTableAdapter.Fill(this.ams_rfidDataSetAttendance.attendance);
            // TODO: This line of code loads data into the 'ams_rfidDataSetAttendance.attendance' table. You can move, or remove it, as needed.
            this.attendanceTableAdapter.Fill(this.ams_rfidDataSetAttendance.attendance);
            // TODO: This line of code loads data into the 'ams_rfidDataSetReportsTo.reportsto' table. You can move, or remove it, as needed.
            this.reportstoTableAdapter.Fill(this.ams_rfidDataSetReportsTo.reportsto);
            // TODO: This line of code loads data into the 'ams_rfidDataSetReportsTo.reportsto' table. You can move, or remove it, as needed.
            this.reportstoTableAdapter.Fill(this.ams_rfidDataSetReportsTo.reportsto);
            // TODO: This line of code loads data into the 'ams_rfidDataSetReportsTo.reportsto' table. You can move, or remove it, as needed.
            this.reportstoTableAdapter.Fill(this.ams_rfidDataSetReportsTo.reportsto);
            // TODO: This line of code loads data into the 'ams_rfidDataSetReportsTo.reportsto' table. You can move, or remove it, as needed.
            this.reportstoTableAdapter.Fill(this.ams_rfidDataSetReportsTo.reportsto);
            // TODO: This line of code loads data into the 'ams_rfidDataSetReportsTo.reportsto' table. You can move, or remove it, as needed.
            this.reportstoTableAdapter.Fill(this.ams_rfidDataSetReportsTo.reportsto);
            // TODO: This line of code loads data into the 'ams_rfidDataSetReportsTo.reportsto' table. You can move, or remove it, as needed.
            this.reportstoTableAdapter.Fill(this.ams_rfidDataSetReportsTo.reportsto);
            // TODO: This line of code loads data into the 'ams_rfidDataSetReportsTo.reportsto' table. You can move, or remove it, as needed.
            this.reportstoTableAdapter.Fill(this.ams_rfidDataSetReportsTo.reportsto);
            // TODO: This line of code loads data into the 'ams_rfidDataSet_Leave.onleave' table. You can move, or remove it, as needed.
            this.onleaveTableAdapter1.Fill(this.ams_rfidDataSet_Leave.onleave);
            // TODO: This line of code loads data into the 'ams_rfidDataSetAttendance.attendance' table. You can move, or remove it, as needed.

            this.employeesTableAdapter.Fill(this.ams_rfidDataSetEmployee.employees);

            this.reportstoTableAdapter.Fill(this.ams_rfidDataSetReportsTo.reportsto);
            // TODO: This line of code loads data into the 'ams_rfidDataSet.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.ams_rfidDataSet.department);

            // TODO: This line of code loads data into the 'ams_rfidDataSet1.designation' table. You can move, or remove it, as needed.
            this.designationTableAdapter1.Fill(this.ams_rfidDataSet1.designation);

            //
            departmentBindingSource.DataSource = this.ams_rfidDataSet.department;
            designationBindingSource1.DataSource = this.ams_rfidDataSet1.designation;
            reportstoBindingSource.DataSource = this.ams_rfidDataSetReportsTo.reportsto;
            employeesBindingSource.DataSource = this.ams_rfidDataSetEmployee.employees;

            //
            departmentNameTextBox1.Enabled = false;
            //departmentNameTextBox1.Clear();
            btnNew.Enabled = true;
            btnSave.Enabled = false;

            designationNameTextBox.Enabled = false;
            btnSave1.Enabled = false;

            //EMPLOYEE
            employeeRfidTagTextBox.Enabled = false;
            employeeNameTextBox.Enabled = false;
            employeeAddressTextBox.Enabled = false;
            employeeContactNumberTextBox.Enabled = false;
            departmentNameTextBox.Enabled = false;
            departmentNameComboBox.Enabled = false;
            designationNameComboBox.Enabled = false;
            btnEmpSave.Enabled = false;
            designationNameTextBox1.Enabled = false;
            designationNameComboBox.Enabled = false;
            reportsToTextBox.Enabled = false;
            reportsToEmployeeComboBox.Enabled = false;

            NA.Enabled = false;

            Address.Enabled = false;
            employeeNameComboBox.Enabled = false;

            employeeRfidTagTextBox.Clear();
            employeeNameTextBox.Clear();
            employeeAddressTextBox.Clear();
            employeeContactNumberTextBox.Clear();
            departmentNameTextBox.Clear();
            designationNameTextBox1.Clear();
            reportsToTextBox.Clear();
            firstname.Enabled = false;
            m_i.Enabled = false;

            //REPORTSTO
            reportsToEmployeeTextBox.Enabled = false;
            designationTextBox.Enabled = false;
            employeeNameComboBox.Enabled = false;
            positionTextBox.Enabled = false;
            btnRepSave.Enabled = false;
            btnimgfrmwebcam.Enabled = false;
            repbrowse.Enabled = false;
            positionTextBox.Enabled = false;
            designationTextBox.Enabled = false;
            ReportsTocombo.Enabled = false;

            //webcam Properties
            //this.btnScan1.Focus();
            //streaming = true;
            //CaptureApp = new Capture();
            //Application.Idle += Streamin;

        }

        #endregion LOAD

        #region OTHERS

        ////////////////////OTHERS////////////////////

        private void RealtimeClock_Tick(object sender, EventArgs e)
        {
            timeclock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        ////////////FORM MOUSE DRAG (OTHERS)/////////
        private void MainPage_MouseDown(object sender, MouseEventArgs e)
        {

		}

		////////////FORM MOUSE DRAG (OTHERS)/////////
		private void guna2CustomGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        ////////////FORM MOUSE designationNameDRAG (OTHERS)/////////
        private void guna2CustomGradientPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        ////////////FORM MOUSE DRAG (OTHERS)/////////
        private void guna2TabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void designationNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (designationNameComboBox.SelectedIndex == -1)
            {
                designationNameTextBox1.Text = string.Empty;
            }
            else
            {
                //string dpnme = (string)departmentNameComboBox.SelectedItem;
                designationNameTextBox1.Text = designationNameComboBox.Text;
            }
        }

        private void guna2PictureBox3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                //EmployeeAttendance EmpAtt = new EmployeeAttendance();
                //EmpAtt.ShowDialog();
                Application.Exit();
            }
        }

        private void employeeContactNumberTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void employeeRfidTagTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TxtEmpSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtSearch.Text))
            {
                btnEmpNew.Enabled = false;
            }
            else
            {
                btnEmpNew.Enabled = true;
                employeesBindingSource.Filter = string.Empty;
            }
        }

        private void DatetoDay_Tick(object sender, EventArgs e)
        {
            //Date

            Date.Text = DateTime.Now.ToString("dddd | MMMM dd,yyyy");
            hhmm.Text = DateTime.Now.ToString("hh:mm");
            sec.Text = DateTime.Now.ToString("ss");
            am.Text = DateTime.Now.ToString("tt");
        }

        

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            DTR dtr = new DTR();
            dtr.Show();
        }

        private void btnEmpEdit_Click(object sender, EventArgs e)
        {
            EditForm editform = new EditForm();
            editform.ShowDialog();
        }

        private void guna2CirclePictureBox6_Click_1(object sender, EventArgs e)
        {
            SettingsForm SetForm = new SettingsForm();
            SetForm.Show();
        }

        #endregion OTHERS

        #region Browse Files

        //BROWSE IMAGES.browse//
        private void FrmWebcam_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofpD = new OpenFileDialog();
            ofpD.InitialDirectory = @"C:\RFID\EMPSAVEIMG\";
            ofpD.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (ofpD.ShowDialog() == DialogResult.OK)
            {
                empImg.Image = Image.FromFile(ofpD.FileName);
            }
        }

        //Browse Files CAN BE CHANGE WHEN NEW LOCATION IS NEEDED
        private void Browse1_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\RFID\EMPSAVEIMG\");
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            ofp.InitialDirectory = @"C:\RFID\EMPSAVEIMG\";
            ofp.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                empImg.Image = Image.FromFile(ofp.FileName);
            }
        }

        #endregion Browse Files

        #region Full Logs

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                using (MySqlConnection com = new MySqlConnection(MyDsql))
                {
                    string selectqueryD = string.Format("SELECT Date FROM Attendance WHERE Date = '" + date + "' ");
                    MySqlCommand commandD = new MySqlCommand(selectqueryD, com);
                    com.Open();
                    MySqlDataReader readerD = commandD.ExecuteReader();
                    if (readerD.Read())
                    {
                        MessageBox.Show("Already Inserted");
                    }
                    else
                    {
                        DayOfWeek dayofweek = DateTime.Today.DayOfWeek;
                        Console.WriteLine(dayofweek);
                        using (MySqlConnection iconnect = new MySqlConnection(MyDsql))
                        {
                            string selectquery = string.Format("SELECT * FROM employees ");

                            MySqlCommand command = new MySqlCommand(selectquery, iconnect);
                            iconnect.Open();

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
								if (reader.Read())
								{
                                    while (reader.Read())
                                    {
                                        using (MySqlConnection iconnectg = new MySqlConnection(MyDsql))
                                        {
                                            string selectquery1 = string.Format("INSERT INTO `attendance`(`EmployeeRfid`,`EmployeeName`,`Date`,`DayofWeek`) VALUES ('" + reader["EmployeeRfidTag"] + "' ,'" + reader["EmployeeName"] + "', current_timestamp()  , '" + dayofweek + "')");
                                            iconnectg.Open();
                                            MySqlCommand command1 = new MySqlCommand(selectquery1, iconnectg);
                                            MySqlDataReader reader1 = command1.ExecuteReader();
                                            //AutoClosingMessageBox.Show("Importing data", "", 50);
                                        }
                                    }
								}
								else
								{
                                    MessageBox.Show("No Data To be Inserted", "Error");
								}
                                
                            }
                            iconnect.Close();
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void FullLogTimer1_Tick(object sender, EventArgs e)
        {
			try
			{
                string QueryRef1 = "select `EmployeeRfid`,`EmployeeName`,`Date`,`Am_In`,`Am_Out`,`Pm_In`,`Pm_Out`,`Remarks`,`Remarks_AP`  from attendance";

                MySqlConnection conn1 = new MySqlConnection(MyDsql);
                MySqlCommand cmd = new MySqlCommand(QueryRef1, conn1);

                conn1.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter();

                adp.SelectCommand = cmd;
                DataTable dTable = new DataTable();
                adp.Fill(dTable);
                FullLogs.DataSource = dTable;
                conn1.Close();

                for (int i = 0; i < FullLogs.Rows.Count; i++)
                {
                    if (FullLogs.Rows[i].Cells[5].Value.ToString() != "")
                    {
                        DateTime dt1W = DateTime.Parse(FullLogs.Rows[i].Cells[5].Value.ToString(), System.Globalization.CultureInfo.CurrentCulture);
                        string tW = dt1W.ToString("hh:mm:ss");
                        FullLogs.Rows[i].Cells[5].Value = tW;
                    }
                }
                for (int i = 0; i < FullLogs.Rows.Count; i++)
                {
                    if (FullLogs.Rows[i].Cells[6].Value.ToString() != "")
                    {
                        DateTime dt1E = DateTime.Parse(FullLogs.Rows[i].Cells[6].Value.ToString(), System.Globalization.CultureInfo.CurrentCulture);
                        string tE = dt1E.ToString("hh:mm:ss");
                        FullLogs.Rows[i].Cells[6].Value = tE;
                    }
                }
            }
			catch
			{
                MessageBox.Show("Please check you connection between the server");
            }

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (guna2GradientButton2.Checked == true)
            {
                MessageBox.Show("Pease Turn off the toggle button before manual search.");
            }
            try
            {
                string QueryRef1 = "select `EmployeeRfid`,`EmployeeName`,`Date`,`Am_In`,`Am_Out`,`Pm_In`,`Pm_Out`,`Remarks`,`Remarks_AP`  from attendance WHERE Date >= @date  AND  Date <@date1 ";
                MySqlConnection conn1 = new MySqlConnection(MyDsql);
                MySqlCommand cmd = new MySqlCommand(QueryRef1, conn1);

                DateTime dtToday = datePicker.Value;
                DateTime dtToday1 = datePicker1.Value;
                string strDate = dtToday.ToString("yyyy/MM/dd");
                string strDate1 = dtToday1.ToString("yyyy/MM/dd");

                cmd.Parameters.AddWithValue("@date", strDate);
                cmd.Parameters.AddWithValue("@date1", strDate1);
                Console.WriteLine(strDate);
                conn1.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter();
                Console.WriteLine();
                adp.SelectCommand = cmd;
                DataTable dTable = new DataTable();
                adp.Fill(dTable);
                FullLogs.DataSource = dTable;
                conn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label40_MouseHover(object sender, EventArgs e)
        {
            label40.ForeColor = Color.Lime;
        }

        private void label40_MouseLeave(object sender, EventArgs e)
        {
            label40.ForeColor = Color.White;
        }

        #endregion Full Logs

        #region DB

        //Auto Refresh DB resides HEREE **ATTENDANCE today
        private void AutoRefreshDB_Tick(object sender, EventArgs e)
        {
            try
            {
                //EmployeeAttendance gg = new EmployeeAttendance();
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
                {
                    //string QuerryRefresh = "SELECT * FROM attendance WHERE Date= '" + date + "'";
                    string QueryRef1 = "select `EmployeeRfid`,`EmployeeName`,`Date`,`DayofWeek`,`Am_In`,`Am_Out`,`Pm_In`,`Pm_Out`,`Remarks`  from attendance  WHERE Date= '" + date + "'";

                    MySqlCommand cmd = new MySqlCommand(QueryRef1, conn1);

                    conn1.Open();
                    MySqlDataAdapter adp = new MySqlDataAdapter();

                    adp.SelectCommand = cmd;

                    DataTable dTable = new DataTable();
                    adp.Fill(dTable);
                    guna2DataGridView1.DataSource = dTable;

                    conn1.Close();

                    for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
                    {
                        if (guna2DataGridView1.Rows[i].Cells[6].Value.ToString() != "")
                        {
                            DateTime dt1W = DateTime.Parse(guna2DataGridView1.Rows[i].Cells[6].Value.ToString(), System.Globalization.CultureInfo.CurrentCulture);
                            string tW = dt1W.ToString("hh:mm:ss");
                            guna2DataGridView1.Rows[i].Cells[6].Value = tW;
                        }
                    }
                    for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
                    {
                        if (guna2DataGridView1.Rows[i].Cells[7].Value.ToString() != "")
                        {
                            DateTime dt1E = DateTime.Parse(guna2DataGridView1.Rows[i].Cells[7].Value.ToString(), System.Globalization.CultureInfo.CurrentCulture);
                            string tE = dt1E.ToString("hh:mm:ss");
                            guna2DataGridView1.Rows[i].Cells[7].Value = tE;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region TImer Ticks

        private void RefreshDb_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
            {
                try
                {
                    string QuerryRefresh = "SELECT `EmployeeRfidTag`, `EmployeeName`, `EmployeeAddress`, `EmployeeContactNumber`, `DepartmentName`, `DesignationName`, `ReportsTo` FROM employees";
                    MySqlCommand cmd = new MySqlCommand(QuerryRefresh, conn1);

                    conn1.Open();
                    MySqlDataReader d = cmd.ExecuteReader();

                    if (d.Read())
                    {
                        employeeRfidTagTextBox.Text = d.GetValue(0).ToString();
                        employeeNameTextBox.Text = d.GetValue(1).ToString();
                        employeeAddressTextBox.Text = d.GetValue(2).ToString();
                        employeeContactNumberTextBox.Text = d.GetValue(3).ToString();
                        departmentNameTextBox.Text = d.GetValue(4).ToString();
                        designationNameTextBox.Text = d.GetValue(5).ToString();
                        reportsToTextBox.Text = d.GetValue(6).ToString();
                    }
                    conn1.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("No Rfid Recognized");
                }
            }
        }

        private void DeptAutoRefTbl_Tick(object sender, EventArgs e)
        {
			try
			{
                string date = DateTime.Now.ToString("yyyy-MM-dd");

                string QuerryRefresh = "SELECT DepartmentName FROM department";
                MySqlConnection conn1 = new MySqlConnection(MyDsql);
                MySqlCommand cmd = new MySqlCommand(QuerryRefresh, conn1);

                conn1.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter();

                adp.SelectCommand = cmd;

                DataTable dTable = new DataTable();
                adp.Fill(dTable);
                departmentGuna2DataGridView.DataSource = dTable;

                conn1.Close();
            }
			catch (Exception ex)
			{

                MessageBox.Show(ex.Message);
			}

        }

        private void DesAutoRefTbl_Tick(object sender, EventArgs e)
        {
			try
			{
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            string QuerryRefresh = "SELECT designationName FROM designation";
            MySqlConnection conn1 = new MySqlConnection(MyDsql);
            MySqlCommand cmd = new MySqlCommand(QuerryRefresh, conn1);

            conn1.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter();

            adp.SelectCommand = cmd;

            DataTable dTable = new DataTable();
            adp.Fill(dTable);
            guna2DataGridView6.DataSource = dTable;

            conn1.Close();
			}
			catch (Exception ex)
			{

                MessageBox.Show(ex.Message);
			}

        }

        #endregion TImer Ticks

        #endregion DB

        #region Employee List db

        private void EmpListTimer_Tick(object sender, EventArgs e)
        {
			try
			{
                string ConString = "server=localhost;user id=AMS_RFID;password=@M$_Rf1d2O22;persistsecurityinfo=True;database=ams_rfid;allowuservariables=True;connectionlifetime=100";
                string QuerryRefresh = "SELECT * FROM employees";
                string QuerryRefresh1 = "SELECT `EmployeeRfidTag`,`EmployeeName` FROM employees";
                //string QueryRef1 = "select `EmployeeRfid`,`EmployeeName`,`Date`,`Am_In`,`Am_Out`,`Pm_In`,`Pm_Out`,`Remarks`  from attendance  WHERE Date= '" + date + "'";
                MySqlConnection conn1 = new MySqlConnection(ConString);

                MySqlCommand cmd = new MySqlCommand(QuerryRefresh, conn1);

                MySqlCommand cmd1 = new MySqlCommand(QuerryRefresh1, conn1);
                MySqlCommand cmd0 = new MySqlCommand(QuerryRefresh1, conn1);

                conn1.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter();
                MySqlDataAdapter adp1 = new MySqlDataAdapter();

                adp.SelectCommand = cmd;
                adp1.SelectCommand = cmd1;

                DataTable dTable = new DataTable();
                DataTable dataTable1 = new DataTable();
                DataTable dataTable2 = new DataTable();

                adp.Fill(dTable);
                adp1.Fill(dataTable1);
                adp.Fill(dataTable2);

                employeesGuna2DataGridView.DataSource = dTable;
                guna2DataGridView2.DataSource = dataTable1;
                guna2DataGridView8.DataSource = dataTable1;
                conn1.Close();
            }
			catch
			{
                MessageBox.Show("Please check you connection between the server");
			}
            
        }

        #endregion Employee List db

        #region EMPLOYEEIMAGE

        //registerEmployeeImage//
        private void btnScan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string locationToCreateFolder = "C:/RFID/EMPSAVEIMG/";
                Directory.CreateDirectory(locationToCreateFolder);

                string fileName = btnScan1.Text + ".png";
                string path = @"C:\RFID\EMPSAVEIMG\" + fileName;
                if (e.KeyData == Keys.Enter)
                {
                    if (File.Exists(path))
                    {
                        if (MessageBox.Show("ID exist in the folder. Overwrite ?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //var img = CaptureApp.QueryFrame();
                            //var bmp = img.ToBitmap();
                            //ResWebcam.Image = bmp;

                            ResWebcam.Image = (Bitmap)webcam2.Image.Clone();
                            string[] paths = { locationToCreateFolder };
                            string fullPath = Path.Combine(paths);
                            ResWebcam.Image.Save(fullPath + btnScan1.Text + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                    else
                    {
                        Bitmap bit = (Bitmap)webcam2.Image.Clone();
                        Image<Bgr, byte> grayImage = new Image<Bgr, byte>(bit).Resize(100, 100, INTER.CV_INTER_CUBIC);

                        ResWebcam.Image = bit;

                        string[] paths = { locationToCreateFolder };
                        string fullPath = Path.Combine(paths);
                        ResWebcam.Image.Save(fullPath + btnScan1.Text + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
                // ResWebcam.Visible = false;
                //Notif.Text = "Successfully Save! " + "ID: " + btnScan1.Text + " Time: " + DateTime.Now.ToString("hh:mm tt");
                btnScan1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //accept only numbers
        private void btnScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            btnScan1.Clear();
            this.btnScan1.Focus();
        }

        private void EmployeePhoto_Click(object sender, EventArgs e)
        {
            this.btnScan1.Focus();
        }

        #endregion EMPLOYEEIMAGE

        #region Train Images

        //TRAIN NOTIF
        private void train_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("This is the Training area of images uploaded by you. you can train images in order to recognize from the attendance.", "Notification");
        }

        //train AI.Browse
        private void guna2CirclePictureBox6_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"/TrainedFaces/TrainedLabels.txt");
        }

        public void Streamin(object sender, NewFrameEventArgs e)
        {
            try
            {
                //var img = CaptureApp.QueryFrame();
                //var bmp = img.Bitmap;
                //webcam1.Image = bmp;

                Bitmap bitmap = (Bitmap)e.Frame.Clone();

                Image<Bgr, byte> grayImage = new Image<Bgr, byte>(bitmap).Resize(100, 100, INTER.CV_INTER_CUBIC);
                webcam2.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void oNWebcam_CheckedChanged_1(object sender, EventArgs e)
        {
            if (oNWebcam.Checked == false)
            {
                if (FinalVideo.IsRunning)
                {
                    FinalVideo.Stop();
                }

                onoffwebcamlbl.Text = "WEBCAM TURNED OFF";
                onoffwebcamlbl.ForeColor = Color.DarkRed;
                WebCamSelect.Enabled = true;
                offpanel2.BringToFront();
                offpanel22.BringToFront();
            }
            else
            {
				try
				{
                    this.btnScan1.Focus();
                    FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[WebCamSelect.SelectedIndex].MonikerString);
                    FinalVideo.NewFrame += Streamin;
                    FinalVideo.Start();
                    //streaming = true;
                    //CaptureApp = new Capture();
                    //Application.Idle += Streamin;
                    onoffwebcamlbl.ForeColor = Color.LimeGreen;
                    onoffwebcamlbl.Text = "WEBCAM TURNED ON";
                    WebCamSelect.Enabled = false;
                    offpanel2.SendToBack();
                    offpanel22.SendToBack();
                }
				catch (Exception)
				{

                    MessageBox.Show("No camera detected, Please plug a camera before start capturing. Thank you.","Warning");
				}

            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle1.Checked == false)
            {
                try
                {
                    using (grabber.QueryFrame())
                    {
                        Application.Idle -= FrameGrabber;
                        grabber.Dispose();
                    }

                    //grabber.Dispose();
                    offpanel.BringToFront();
                    offpanel1.BringToFront();
                }
                catch (Exception)
                {

                    // MessageBox.Show(ex.Message);
                }

            }
            else
            {
                try
                {
                    grabber = new Capture();
                    using (grabber.QueryFrame())
                    {
                        Application.Idle += new EventHandler(FrameGrabber);
                        face = new HaarCascade("haarcascade_frontalface_default.xml");
                        try
                        {
                            string path = @"C:/RFID/TrainedFaces/TrainedLabels.txt";
                            string path1 = @"C:/RFID/TrainedFaces/";
                            //Load of previus trainned faces and labels for each image
                            string Labelsinfo = File.ReadAllText(path, Encoding.UTF8);
                            //string readText = File.ReadAllText(path, Encoding.UTF8);
                            string[] Labels = Labelsinfo.Split('%');
                            NumLabels = Convert.ToInt16(Labels[0]);
                            ContTrain = NumLabels;
                            string LoadFaces;

                            for (int tf = 1; tf < NumLabels + 1; tf++)
                            {
                                LoadFaces = "face" + tf + ".bmp";
                                trainingImages.Add(new Image<Gray, byte>(path1 + LoadFaces));
                                labels.Add(Labels[tf]);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("No camera detected, Please plug a camera before start capturing. Thank you.", "Warning");
                }
                //Initialize the FrameGraber event

                offpanel.SendToBack();
                offpanel1.SendToBack();

                
            }
        }
        #endregion Train Images

        #region Employe View Details

        private void employeesGuna2DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2ToggleSwitch8.Checked == true)
            {
                AutoClosingMessageBox.Show("Please disable first auto refresh in settings", "Warning", 3000);
            }
            else
            {
                if (employeesGuna2DataGridView.Columns[e.ColumnIndex].Name == "Viewbtn")
                {
                    //MessageBox.Show("ta ulom");
                    foreach (DataGridViewRow row in employeesGuna2DataGridView.SelectedRows)
                    {
                        string value1 = row.Cells[0].Value.ToString();
                        //string value2 = row.Cells[1].Value.ToString();
                        //...
                        Console.WriteLine(value1);

                        using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
                        {
                            try
                            {
                                string QuerryRefresh = "SELECT `EmployeeRfidTag`, `EmployeeName`, `EmployeeAddress`, `EmployeeContactNumber`, `DepartmentName`, `DesignationName`, `ReportsTo` FROM employees WHERE EmployeeName= @EmployeeName";
                                MySqlCommand cmd1 = new MySqlCommand(QuerryRefresh, conn1);

                                cmd1.Parameters.AddWithValue("@EmployeeName", value1);
                                conn1.Open();
                                MySqlDataReader d1 = cmd1.ExecuteReader();

                                if (d1.Read())
                                {
                                    Rfidtxtx.Text = d1.GetValue(0).ToString();
                                    Nametxtbx.Text = d1.GetValue(1).ToString();
                                    Addresstxbx.Text = d1.GetValue(2).ToString();
                                    cpNumbertxbx.Text = d1.GetValue(3).ToString();
                                    Depttxbx.Text = d1.GetValue(4).ToString();
                                    Destxbx.Text = d1.GetValue(5).ToString();
                                    RepsTotxbx.Text = d1.GetValue(6).ToString();
                                }
                                conn1.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            try
                            {
                                using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                                {
                                    string imges = "SELECT image FROM employees WHERE EmployeeName =@EmployeeName";
                                    MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                                    cmdO.Parameters.AddWithValue("@EmployeeName", value1);
                                    //cmdO.Parameters.AddWithValue("@image", empImg1.Image);

                                    MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                                    DataTable tbk = new DataTable();

                                    da.Fill(tbk);
                                    byte[] img = (byte[])tbk.Rows[0][0];

                                    MemoryStream ms1 = new MemoryStream(img);
                                    empimges.Image = Image.FromStream(ms1);

                                    da.Dispose();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("No Image to display");
                            }
                        }
                    }

    ;
                }
            }
        }

        #endregion Employe View Details

        #region EMPLOYEE

        ////////////empNEW/////////
        private void btnEmpNew_Click_1(object sender, EventArgs e)
        {
            if (btnEmpNew.Text == "New")
            {
                employeeRfidTagTextBox.Enabled = true;
                employeeRfidTagTextBox.Clear();
                employeeRfidTagTextBox.Focus();
                btnEmpDelete.Enabled = false;
                btnEmpEdit.Enabled = false;
                btnEmpSave.Enabled = true;
                btnEmpNew.Text = "&Cancel";
                departmentNameTextBox.ReadOnly = true;
                employeeRfidTagTextBox.Enabled = true;
                departmentNameComboBox.Enabled = true;
                employeeNameTextBox.Enabled = true;
                employeeAddressTextBox.Enabled = true;
                employeeContactNumberTextBox.Enabled = true;
                designationNameComboBox.Enabled = true;
                employeesGuna2DataGridView.Enabled = false;
                reportsToTextBox.Enabled = false;
                reportsToEmployeeComboBox.Enabled = true;
                NA.Enabled = true;
                firstname.Enabled = true;
                m_i.Enabled = true;

                Address.BringToFront();
                Address.Text = "Select..";
                departmentNameComboBox.BringToFront();
                designationNameComboBox.BringToFront();
                reportsToEmployeeComboBox.BringToFront();
                Address.Enabled = true;
                RefreshDb.Enabled = false;

                Address.SelectedIndex = 0;
                this.ams_rfidDataSetEmployee.employees.AddemployeesRow(this.ams_rfidDataSetEmployee.employees.NewemployeesRow());

                employeesBindingSource.MoveLast();
            }
            else
            {
                if (MessageBox.Show("Are you sure?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        employeeRfidTagTextBox.Enabled = false;
                        btnEmpDelete.Enabled = true;
                        btnEmpEdit.Enabled = true;
                        btnEmpSave.Enabled = false;
                        btnEmpNew.Text = "New";
                        employeeRfidTagTextBox.Clear();
                        employeeRfidTagTextBox.Enabled = false;

                        this.employeesBindingSource.RemoveCurrent();

                        employeeRfidTagTextBox.Enabled = false;
                        employeeRfidTagTextBox.Enabled = false;
                        employeeNameTextBox.Enabled = false;
                        employeeAddressTextBox.Enabled = false;
                        employeeContactNumberTextBox.Enabled = false;
                        departmentNameComboBox.Enabled = false;
                        employeesGuna2DataGridView.Enabled = true;

                        NA.Enabled = false;

                        Address.SendToBack();
                        designationNameComboBox.Enabled = false;
                        departmentNameComboBox.SendToBack();
                        designationNameComboBox.SendToBack();
                        reportsToEmployeeComboBox.SendToBack();
                        Address.Enabled = false;

                        employeeRfidTagTextBox.Clear();
                        employeeNameTextBox.Clear();
                        employeeAddressTextBox.Clear();
                        employeeContactNumberTextBox.Clear();
                        departmentNameTextBox.Clear();
                        designationNameTextBox1.Clear();
                        reportsToTextBox.Clear();
                        RefreshDb.Enabled = true;
                        firstname.Enabled = false; ;
                        m_i.Enabled = false ;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        ////////////empSAVE/////////
        private void btnEmpSave_Click(object sender, EventArgs e)
        {
            if (employeeRfidTagTextBox.Text == "" || employeeNameTextBox.Text == "" || employeeAddressTextBox.Text == "" || employeeContactNumberTextBox.Text == "" || departmentNameTextBox.Text == "")
            {
                MessageBox.Show("Missing input Detected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                employeeRfidTagTextBox.Focus();
            }
            else
            {
                try
                {
                    using (MySqlConnection msqll = new MySqlConnection(MyDsql))
                    {
                        string ins = "INSERT INTO `employees`(`EmployeeRfidTag`, `EmployeeName`, `EmployeeAddress`," +
                            " `EmployeeContactNumber`, `DepartmentName`, `DesignationName`, `ReportsTo`)" +
                            " VALUES (@EmployeeRfidTag,@EmployeeName,@EmployeeAddress,@EmployeeContactNumber,@DepartmentName,@DesignationName,@ReportsTo)";

                        MySqlCommand cmd1 = new MySqlCommand(ins, msqll);

                        cmd1.Parameters.AddWithValue("@EmployeeRfidTag", employeeRfidTagTextBox.Text);
                        cmd1.Parameters.AddWithValue("@EmployeeName", employeeNameTextBox.Text + ", " + firstname.Text + " " + m_i.Text);
                        cmd1.Parameters.AddWithValue("@EmployeeAddress", employeeAddressTextBox.Text);
                        cmd1.Parameters.AddWithValue("@EmployeeContactNumber", employeeContactNumberTextBox.Text);
                        cmd1.Parameters.AddWithValue("@DepartmentName", departmentNameTextBox.Text);
                        cmd1.Parameters.AddWithValue("@DesignationName", designationNameTextBox1.Text);
                        cmd1.Parameters.AddWithValue("@ReportsTo", reportsToTextBox.Text);

                        msqll.Open();
                        MySqlDataReader d1 = cmd1.ExecuteReader();
                        msqll.Close();
                    }
                    using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
                    {
                        OpenFileDialog ofpD = new OpenFileDialog();
                        ofpD.InitialDirectory = @"C:\RFID\EMPSAVEIMG\";
                        ofpD.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";

                        if (ofpD.ShowDialog() == DialogResult.OK)
                        {
                            empImg.Image = Image.FromFile(ofpD.FileName);

                            string QuerryRefresh = "UPDATE `employees` SET image = @image WHERE  EmployeeRfidTag= @EmployeeRfidTag";
                            MySqlCommand cmd = new MySqlCommand(QuerryRefresh, conn1);

                            conn1.Open();
                            cmd.Parameters.AddWithValue("@EmployeeRfidTag", employeeRfidTagTextBox.Text);
                            cmd.Parameters.AddWithValue("@image", File.ReadAllBytes(ofpD.FileName));

                            MySqlDataReader d = cmd.ExecuteReader();
                            conn1.Close();
                        }
                    }
                    MessageBox.Show("Data has been saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtSearch.Clear();
                    btnEmpNew.Text = "New";
                    employeeNameTextBox.Enabled = false;
                    btnEmpDelete.Enabled = true;
                    btnEmpEdit.Enabled = true;
                    btnEmpSave.Enabled = false;
                    btnEmpNew.Enabled = true;
                    btnEmpEdit.Text = "Edit";
                    btnEmpSave.FillColor = Color.GreenYellow;
                    employeeRfidTagTextBox.Enabled = false;
                    employeeNameTextBox.Enabled = false;
                    employeeAddressTextBox.Enabled = false;
                    employeeContactNumberTextBox.Enabled = false;
                    departmentNameComboBox.Enabled = false;
                    reportsToEmployeeComboBox.Enabled = false;
                    employeesGuna2DataGridView.Enabled = true;
                    designationNameComboBox.Enabled = false;

                    NA.Enabled = false;

                    Address.SendToBack();
                    departmentNameComboBox.SendToBack();
                    designationNameComboBox.SendToBack();
                    reportsToEmployeeComboBox.SendToBack();
                    Address.Enabled = false;
                    guna2DataGridView2.Enabled = true;

                    employeeRfidTagTextBox.Clear();
                    employeeNameTextBox.Clear();
                    employeeAddressTextBox.Clear();
                    employeeContactNumberTextBox.Clear();
                    departmentNameTextBox.Clear();
                    designationNameTextBox1.Clear();
                    reportsToTextBox.Clear();
                    designationNameComboBox.Enabled = false;
                    RefreshDb.Enabled = true;
                    firstname.Enabled = false;
                    m_i.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    employeeRfidTagTextBox.Focus();
                }
            }
        }

        ////////////empDELETE/////////
        private void btnEmpDelete_Click_1(object sender, EventArgs e)
        {
            EmployeeDelForm del = new EmployeeDelForm();
            del.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            employeeContactNumberTextBox.Text = "N/A";
        }

        private void Address_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Address.SelectedIndex == -1)
            {
                employeeAddressTextBox.Text = string.Empty;
            }
            else
            {
                employeeAddressTextBox.Text = Address.Text;
            }
        }

        //btn for shrtcut face recog
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 5;
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 4;
        }

        #endregion EMPLOYEE

        #region IMAGE TRAIN

        private void SaveTrainImage_Click(object sender, EventArgs e)
        {
            if (grabber == null)
            {
                MessageBox.Show("Please Enable Webcam first.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                if (rfidtxtbx.Text == " ")
                {
                    AutoClosingMessageBox.Show("No input detected", "warning", 2000);
                }
                else
                {
                    try
                    {
                        //Trained face counter
                        ContTrain = ContTrain + 1;

                        //Get a gray frame from capture device
                        gray = grabber.QueryGrayFrame().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                        //Face Detector
                        MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                        face,
                        1.2,
                        10,
                        Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        new Size(20, 20));

                        //Action for each element detected
                        foreach (MCvAvgComp f in facesDetected[0])
                        {
                            TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                            break;
                        }

                        //resize face detected image for force to compare the same size with the
                        //test image with cubic interpolation type method
                        TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        trainingImages.Add(TrainedFace);
                        labels.Add(rfidtxtbx.Text);

                        //Show face added in gray scale
                        ImgeBox.Image = TrainedFace;

                        //File and path you want to create and write to
                        string fileName = @"C:\\RFID\\TrainedFaces\\TrainedLabels.txt";
                        string fileName1 = @"C:\\RFID\\TrainedFaces\\face";

                        //Write the number of triained faces in a file text for further load
                        File.WriteAllText(fileName, trainingImages.ToArray().Length.ToString() + "%");
						//Write the labels of triained faces in a file text for further load
						for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
						{
							trainingImages.ToArray()[i - 1].Save(fileName1 + i + ".bmp");
							File.AppendAllText(fileName, labels.ToArray()[i - 1] + "%");
						}

						MessageBox.Show(rfidtxtbx.Text + "´s face detected and added", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        //MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void FrameGrabber(object sender, EventArgs e)
        {
            try
            {
                lblEmp.Text = "0";
                //label4.Text = "";
                NamePersons.Add("");

                //Get the current frame form capture device
                currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Convert it to Grayscale
                gray = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
              face,
              1.1,
              10,
              Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
              new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);

                    if (trainingImages.ToArray().Length != 0)
                    {
                        //TermCriteria for face recognition with numbers of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           3000,
                           ref termCrit);

                        name = recognizer.Recognize(result);

                        //Draw the label for each face detected and recognized
                        currentFrame.Draw(name, ref font, new Point(f.rect.X - 1, f.rect.Y - 1), new Bgr(Color.LightGreen));
                    }

                    NamePersons[t - 1] = name;
                    NamePersons.Add("");

                    //Set the number of faces detected on the scene
                    lblEmp.Text = facesDetected[0].Length.ToString();
                }
                t = 0;

                //Names concatenation of persons recognized
                for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                {
                    names = NamePersons[nnn];
                }
                //Show the faces procesed and recognized
                web1.Image = currentFrame;
                lblEmp.Text = names;
                names = "";
                //Clear the list(vector) of names
                NamePersons.Clear();
            }
            catch (Exception)
            {
                //
            }
        }

        private void employeeAddressTextBox_Click(object sender, EventArgs e)
        {
        }

        private void Snap_Click(object sender, EventArgs e)
        {
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
        }

        #endregion IMAGE TRAIN

        #region DEPARTMENT

        ////////////depNEW/////////
        private void BtnNew_Click_1(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                departmentNameTextBox1.Enabled = true;
                departmentNameTextBox1.Clear();
                departmentNameTextBox1.Focus();
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                btnNew.Text = "Cancel";

                this.ams_rfidDataSet.department.AdddepartmentRow(this.ams_rfidDataSet.department.NewdepartmentRow());
                departmentBindingSource.MoveLast();
            }
            else
            {
                if (MessageBox.Show("Are you sure?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    departmentNameTextBox1.Enabled = false;
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                    btnNew.Text = "New";
                    departmentNameTextBox1.Clear();
                    departmentNameTextBox1.Enabled = false;
                    this.departmentBindingSource.RemoveCurrent();
                    departmentBindingSource.ResetBindings(false);
                    departmentTableAdapter.Update(this.ams_rfidDataSet.department);
                    departmentBindingSource.EndEdit();
                }
            }
        }

        private void departmentNameTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (departmentNameTextBox1.Text == "")
                {
                    MessageBox.Show("Department Name is required.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    departmentNameTextBox1.Focus();
                }
                else
                {
                    try
                    {
                        this.Validate();
                        departmentBindingSource.EndEdit();
                        tableAdapterManager.UpdateAll(this.ams_rfidDataSet);
                        //departmentBindingSource.MoveLast();
                        //departmentGuna2DataGridView.Columns[0].ReadOnly = true;
                        MessageBox.Show("Data has been saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtSearch.Clear();
                        btnNew.Text = "&New";
                        //departmentNameTextBox.Clear();
                        departmentNameTextBox1.Enabled = false;
                        btnDelete.Enabled = true;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;
                        btnNew.Enabled = true;
                        btnEdit.Text = "&Edit";
                        btnSave.FillColor = Color.GreenYellow;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        departmentNameTextBox.Focus();
                    }
                }
            }
        }

        ////////////depSAVE/////////
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (departmentNameTextBox1.Text == "")
            {
                MessageBox.Show("Department Name is required.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                departmentNameTextBox1.Focus();
            }
            else
            {
                try
                {
                    this.Validate();
                    departmentBindingSource.EndEdit();
                    tableAdapterManager.UpdateAll(this.ams_rfidDataSet);
                    //departmentBindingSource.MoveLast();
                    //departmentGuna2DataGridView.Columns[0].ReadOnly = true;
                    MessageBox.Show("Data has been saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtSearch.Clear();
                    btnNew.Text = "New";
                    //departmentNameTextBox.Clear();
                    departmentNameTextBox1.Enabled = false;
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                    btnNew.Enabled = true;
                    btnEdit.Text = "Edit";
                    btnSave.FillColor = Color.GreenYellow;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    departmentNameTextBox.Focus();
                }
            }
        }

        ////////////depDELETE/////////
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DEptDel Deptdel = new DEptDel();
            Deptdel.ShowDialog();
        }

        ////////////depEDIT/////////
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            DeptEditForm deptForm = new DeptEditForm();

            deptForm.ShowDialog();
        }

        ////////////depSEARCH/////////
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtSearch.Text == "")
                {
                    MessageBox.Show("Please input your query.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtSearch.Focus();
                }
                else
                {
                    this.departmentBindingSource.Filter = "DepartmentName LIKE '" + TxtSearch.Text + "%'";
                    if (departmentNameTextBox1.Text == "")
                    {
                        MessageBox.Show("No record(s) found for " + TxtSearch.Text + ".", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtSearch.Focus();
                    }
                }
            }
        }

        //BTN SEARCH
        private void BtnSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtSearch.Text))
            {
                btnNew.Enabled = false;
            }
            else
            {
                btnNew.Enabled = true;
                departmentBindingSource.Filter = string.Empty;
            }
        }

        ////////////depSEARCH BTN/////////
        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            if (TxtSearch.Text == "")
            {
                MessageBox.Show("Please input your query.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSearch.Focus();
            }
            else
            {
                this.departmentBindingSource.Filter = "DepartmentName LIKE '" + TxtSearch.Text + "%'";
                if (departmentNameTextBox1.Text == "")
                {
                    MessageBox.Show("No record(s) found for " + TxtSearch.Text + ".", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtSearch.Focus();
                }
            }
        }

        private void departmentNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (departmentNameComboBox.SelectedIndex == -1)
            {
                departmentNameTextBox.Text = string.Empty;
            }
            else
            {
                departmentNameTextBox.Text = departmentNameComboBox.Text;
            }
        }

        #endregion DEPARTMENT

        #region DESIGNATION

        ////////////desNEW/////////
        private void BtnNew1_Click(object sender, EventArgs e)
        {
            if (btnNew1.Text == "New")
            {
                designationNameTextBox.Enabled = true;
                designationNameTextBox.Clear();
                designationNameTextBox.Focus();
                btnDelete1.Enabled = false;
                btnEdit1.Enabled = false;
                btnSave1.Enabled = true;
                btnNew1.Text = "Cancel";

                this.ams_rfidDataSet1.designation.AdddesignationRow(this.ams_rfidDataSet1.designation.NewdesignationRow());
                designationBindingSource1.MoveLast();
            }
            else
            {
                if (MessageBox.Show("Are you sure?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    designationNameTextBox.Enabled = false;
                    btnDelete1.Enabled = true;
                    btnEdit1.Enabled = true;
                    btnSave1.Enabled = false;
                    btnNew1.Text = "New";
                    designationNameTextBox.Clear();
                    designationNameTextBox.Enabled = false;
                    this.designationBindingSource1.RemoveCurrent();
                    designationBindingSource1.ResetBindings(false);
                    designationTableAdapter1.Update(this.ams_rfidDataSet1.designation);
                    designationBindingSource1.EndEdit();
                }
            }
        }

        private void designationNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (designationNameTextBox.Text == "")
                {
                    MessageBox.Show("Designation Name is required.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    designationNameTextBox.Focus();
                }
                else
                {
                    try
                    {
                        this.Validate();
                        designationBindingSource1.EndEdit();
                        tableAdapterManager1.UpdateAll(this.ams_rfidDataSet1);
                        //departmentBindingSource.MoveLast();
                        //departmentGuna2DataGridView.Columns[0].ReadOnly = true;
                        MessageBox.Show("Data has been saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtSearch1.Clear();
                        btnNew1.Text = "New";
                        //departmentNameTextBox.Clear();
                        designationNameTextBox.Enabled = false;
                        btnDelete1.Enabled = true;
                        btnEdit1.Enabled = true;
                        btnSave1.Enabled = false;
                        btnNew1.Enabled = true;
                        btnEdit1.Text = "Edit";
                        btnSave1.FillColor = Color.GreenYellow;
                        guna2DataGridView6.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        ////////////desSAVE/////////
        private void BtnSave1_Click(object sender, EventArgs e)
        {
            if (designationNameTextBox.Text == "")
            {
                MessageBox.Show("Designation Name is required.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                designationNameTextBox.Focus();
            }
            else
            {
                try
                {
                    this.Validate();
                    designationBindingSource1.EndEdit();
                    tableAdapterManager1.UpdateAll(this.ams_rfidDataSet1);
                    //departmentBindingSource.MoveLast();
                    //departmentGuna2DataGridView.Columns[0].ReadOnly = true;
                    MessageBox.Show("Data has been saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtSearch1.Clear();
                    btnNew1.Text = "New";
                    //departmentNameTextBox.Clear();
                    designationNameTextBox.Enabled = false;
                    btnDelete1.Enabled = true;
                    btnEdit1.Enabled = true;
                    btnSave1.Enabled = false;
                    btnNew1.Enabled = true;
                    btnEdit1.Text = "Edit";
                    btnSave1.FillColor = Color.GreenYellow;
                    guna2DataGridView6.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        ////////////desEDIT/////////
        private void BtnEdit1_Click(object sender, EventArgs e)
        {
            DesEditForm desEditForm = new DesEditForm();

            desEditForm.ShowDialog();
        }

        ////////////desDELETE/////////
        private void BtnDelete1_Click(object sender, EventArgs e)
        {
            DEsDel dEsDel = new DEsDel();

            dEsDel.ShowDialog();
        }

        ////////////desSEACRH/////////
        private void TxtSearch1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtSearch1.Text == "")
                {
                    MessageBox.Show("Please input your query.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtSearch1.Focus();
                }
                else
                {
                    this.designationBindingSource1.Filter = "designationName LIKE '" + TxtSearch1.Text + "%'";
                    if (designationNameTextBox.Text == "")
                    {
                        MessageBox.Show("No record(s) found for " + TxtSearch1.Text + ".", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtSearch1.Focus();
                    }
                }
            }
        }

        private void TxtSearch1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtSearch1.Text))
            {
                btnNew1.Enabled = false;
            }
            else
            {
                btnNew1.Enabled = true;
                designationBindingSource1.Filter = string.Empty;
            }
        }

        ////////////desSEARCH BTN/////////
        private void Guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            if (TxtSearch1.Text == "")
            {
                MessageBox.Show("Please input your query.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSearch1.Focus();
            }
            else
            {
                this.designationBindingSource1.Filter = "designationName LIKE '" + TxtSearch1.Text + "%'";
                if (designationNameTextBox.Text == "")
                {
                    MessageBox.Show("No record(s) found for " + TxtSearch1.Text + ".", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtSearch1.Focus();
                }
            }
        }

        #endregion DESIGNATION

        #region REPORTSto

        //////////////////////REPORTSTO///////////
        ////////////////repNew////////////////
        private void btnRepNew_Click(object sender, EventArgs e)
        {
            if (btnRepNew.Text == "New")
            {
                employeeNameComboBox.Enabled = true;
                reportsToEmployeeTextBox.Enabled = true;
                reportsToEmployeeTextBox.Clear();
                reportsToEmployeeTextBox.Focus();
                btnRepDel.Enabled = false;
                btnRepEdit.Enabled = false;
                btnRepSave.Enabled = true;
                btnRepNew.Text = "Cancel";
                btnimgfrmwebcam.Enabled = true;
                repbrowse.Enabled = true;
                btnimgfrmwebcam.FillColor = Color.Green;
                repbrowse.FillColor = Color.Green;
                positionTextBox.Enabled = true;
                designationTextBox.Enabled = true;
                guna2DataGridView5.Enabled = false;
                ReportsTocombo.Enabled = true;
                ReportsTocombo.BringToFront();
                employeeNameComboBox.Enabled = true;
            }
            else
            {
                if (MessageBox.Show("Are you sure?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    reportsToEmployeeTextBox.Enabled = false;
                    btnRepDel.Enabled = true;
                    btnRepEdit.Enabled = true;
                    btnRepSave.Enabled = false;
                    btnRepNew.Text = "New";
                    reportsToEmployeeTextBox.Clear();
                    reportsToEmployeeTextBox.Enabled = false;
                    employeeNameComboBox.Enabled = false;
                    btnimgfrmwebcam.Enabled = false;
                    repbrowse.Enabled = false;
                    btnimgfrmwebcam.FillColor = Color.DeepSkyBlue;
                    repbrowse.FillColor = Color.DeepSkyBlue;
                    positionTextBox.Enabled = false;
                    designationTextBox.Enabled = false;
                    guna2DataGridView5.Enabled = true;
                    ReportsTocombo.Enabled = false;
                    ReportsTocombo.SendToBack();
                    employeeNameComboBox.Enabled = false;
                }
            }
        }

        ////////////RepSave//////////
        private void btnRepSave_Click(object sender, EventArgs e)
        {
            if (reportsToEmployeeTextBox.Text == "" || designationTextBox.Text == "" || positionTextBox.Text == "")
            {
                MessageBox.Show("Data is required.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reportsToEmployeeTextBox.Focus();
            }
            else
            {
                if (imagePictureBox1.Image == null)
                {
                    MessageBox.Show("No photo Uploaded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
                else
                {
                    try
                    {
                        this.Validate();
                        reportstoBindingSource.EndEdit();
                        tableAdapterManager3.UpdateAll(this.ams_rfidDataSetReportsTo);

                        MessageBox.Show("Data has been saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRepNew.Text = "New";
                        reportsToEmployeeTextBox.Enabled = false;
                        btnRepDel.Enabled = true;
                        btnRepEdit.Enabled = true;
                        btnRepSave.Enabled = false;
                        btnRepNew.Enabled = true;
                        btnRepEdit.Text = "Edit";
                        btnRepSave.FillColor = Color.GreenYellow;
                        employeeNameComboBox.Enabled = false;
                        positionTextBox.Enabled = false;
                        designationTextBox.Enabled = false;
                        guna2DataGridView5.Enabled = true;
                        ReportsTocombo.Enabled = false;
                        ReportsTocombo.SendToBack();
                        employeeNameComboBox.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        // MessageBox.Show("Employee already exist.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        reportsToEmployeeTextBox.Focus();
                    }
                }
            }
        }

        private void RepsDb()
        {
        }

        private void employeeNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (employeeNameComboBox.SelectedIndex == -1)
            {
                reportsToEmployeeTextBox.Text = string.Empty;
            }
            else
            {
                reportsToEmployeeTextBox.Text = employeeNameComboBox.Text;
            }
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofpD = new OpenFileDialog();
            ofpD.InitialDirectory = @"C:\RFID\EMPSAVEIMG\";
            ofpD.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (ofpD.ShowDialog() == DialogResult.OK)
            {
                imagePictureBox1.Image = Image.FromFile(ofpD.FileName);
            }
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofpD = new OpenFileDialog();
            ofpD.InitialDirectory = @"C:\RFID\BROWSE\";
            ofpD.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (ofpD.ShowDialog() == DialogResult.OK)
            {
                imagePictureBox1.Image = Image.FromFile(ofpD.FileName);
            }
        }

        private void reportsToEmployeeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportsToEmployeeComboBox.SelectedIndex == -1)
            {
                reportsToTextBox.Text = string.Empty;
            }
            else
            {
                reportsToTextBox.Text = reportsToEmployeeComboBox.Text;
            }
        }

        private void ReportsTocombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            positionTextBox.Text = ReportsTocombo.Text;
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportsToEmployeeTextBox.Text = employeeNameComboBox.Text;
        }

        //database combobox
        private void RefreshRepsTo()
        {
            try
            {
                using (MySqlConnection mswl = new MySqlConnection(MyDsql))
                {
                    string Ref = "SELECT EmployeeName FROM Employees";
                    mswl.Open();
                    MySqlCommand cmdO = new MySqlCommand(Ref, mswl);
                    MySqlDataReader readd = cmdO.ExecuteReader();

                    while (readd.Read())

                    {
                        employeeNameComboBox.Items.Add(readd.GetString("EmployeeName"));
                    }
                    mswl.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion REPORTSto

        private void btnRepEdit_Click(object sender, EventArgs e)
        {
            RepToEditForm preditfm = new RepToEditForm();

            preditfm.ShowDialog();
        }

        private void btnRepDel_Click(object sender, EventArgs e)
        {
            RepsToDelForm DEL = new RepsToDelForm();

            DEL.ShowDialog();
        }

        #region DTR by Date/employee

        private void DtrbyDate()
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
                {
                    string QuerryRefresh = "SELECT `Date` FROM attendance ";
                    MySqlCommand cmd = new MySqlCommand(QuerryRefresh, conn1);

                    //cmd.Parameters.AddWithValue("@EmployeeName", EmpTextbx.Text);
                    conn1.Open();
                    MySqlDataReader d = cmd.ExecuteReader();

                    while (d.Read())
                    {
                        using (MySqlConnection mscon = new MySqlConnection(MyDsql))
                        {
                            //string query = "SELECT UserName, COUNT(UserName) as JobsCount FROM tblJobs WHERE JobStatus != 'Booked' Group by UserName";
                            string ms = "SELECT Date, count( Remarks_AP ) as total_record FROM `attendance` WHERE Remarks_AP = 'Present' group by Date";
                            string ms1 = "SELECT Date, count( Remarks_AP ) as total_record1 FROM `attendance` WHERE Remarks_AP = 'Absent' group by Date";
                            string ms2 = "SELECT Date, count( Remarks_AP ) as total_record1 FROM `attendance` WHERE Remarks_AP = 'Half Day' group by Date";

                            MySqlCommand mcmd = new MySqlCommand(ms, mscon);
                            MySqlCommand mcmd1 = new MySqlCommand(ms1, mscon);
                            MySqlCommand mcmd2 = new MySqlCommand(ms2, mscon);

                            DataTable tb = new DataTable();
                            DataTable tb1 = new DataTable();
                            DataTable tb2 = new DataTable();
                            mscon.Open();
                            MySqlDataAdapter ds = new MySqlDataAdapter();
                            MySqlDataAdapter ds1 = new MySqlDataAdapter();
                            MySqlDataAdapter ds2 = new MySqlDataAdapter();

                            ds.SelectCommand = mcmd;
                            ds1.SelectCommand = mcmd1;
                            ds2.SelectCommand = mcmd2;

                            ds.Fill(tb);
                            ds1.Fill(tb1);
                            ds2.Fill(tb2);
                            DTRDate.DataSource = tb;
                            DTRDate1.DataSource = tb1;
                            DTRDate2.DataSource = tb2;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Rfid Recognized");
            }
        }

        private void DTRDate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2ToggleSwitch12.Checked == true)
            {
                AutoClosingMessageBox.Show("Please Disable first the auto refresh switvh from the settings", "Info", 2500);
            }
            else
            {
                if (DTRDate.Columns[e.ColumnIndex].Name == "Details")
                {
                    foreach (DataGridViewRow row in DTRDate.SelectedRows)
                    {
                        string dateq = DateTime.Now.ToString("yyyy-MM-dd");

                        string value1 = row.Cells[1].Value.ToString();
                        string[] gg = value1.Split(' ');

                        string g = gg[0].ToString();

                        DateTime startDate;
                        string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                                                "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy", "MM/dd/yyyy"};

                        DateTime.TryParseExact(g, formats,
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out startDate);

                        using (MySqlConnection mscon = new MySqlConnection(MyDsql))
                        {
                            //string query = "SELECT UserName, COUNT(UserName) as JobsCount FROM tblJobs WHERE JobStatus != 'Booked' Group by UserName";
                            string ms = "SELECT Date,EmployeeName FROM `attendance` WHERE Remarks_AP = 'Present' and Date = '" + startDate.ToString("yyyy-MM-dd") + "' ";

                            MySqlCommand mcmd = new MySqlCommand(ms, mscon);

                            DataTable tb = new DataTable();
                            mscon.Open();
                            MySqlDataAdapter ds = new MySqlDataAdapter();

                            ds.SelectCommand = mcmd;

                            ds.Fill(tb);
                            employeedetailsdataview.DataSource = tb;
                        }
                    }
                }
            }
        }

        private void DTRDate1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2ToggleSwitch12.Checked == true)
            {
                AutoClosingMessageBox.Show("Please Disable first the auto refresh switvh from the settings", "Info", 2500);
            }
            else
            {
                if (DTRDate1.Columns[e.ColumnIndex].Name == "Details1")
                {
                    foreach (DataGridViewRow row in DTRDate1.SelectedRows)
                    {
                        string dateq = DateTime.Now.ToString("yyyy-MM-dd");

                        string value1 = row.Cells[1].Value.ToString();
                        string[] gg = value1.Split(' ');

                        string g = gg[0].ToString();

                        DateTime startDate;
                        string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                                "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy", "MM/dd/yyyy"};
                        DateTime.TryParseExact(g, formats,
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out startDate);

                        Console.WriteLine(startDate.ToString("yyyy-MM-dd"));

                        Console.WriteLine(value1);

                        using (MySqlConnection mscon = new MySqlConnection(MyDsql))
                        {
                            //string query = "SELECT UserName, COUNT(UserName) as JobsCount FROM tblJobs WHERE JobStatus != 'Booked' Group by UserName";
                            string ms = "SELECT Date,EmployeeName FROM `attendance` WHERE Remarks_AP = 'Absent' and Date = '" + startDate.ToString("yyyy-MM-dd") + "' ";

                            MySqlCommand mcmd = new MySqlCommand(ms, mscon);

                            DataTable tb = new DataTable();
                            mscon.Open();
                            MySqlDataAdapter ds = new MySqlDataAdapter();

                            ds.SelectCommand = mcmd;

                            ds.Fill(tb);
                            employeedetailsdataview.DataSource = tb;
                        }
                    }
                }
            }
        }

        private void DTRDate2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2ToggleSwitch12.Checked == true)
            {
                AutoClosingMessageBox.Show("Please Disable first the auto refresh switvh from the settings", "Info", 2500);
            }
            else
            {
                if (DTRDate2.Columns[e.ColumnIndex].Name == "Details1q")
                {
                    foreach (DataGridViewRow row in DTRDate2.SelectedRows)
                    {
                        string dateq = DateTime.Now.ToString("yyyy-MM-dd");

                        string value1 = row.Cells[2].Value.ToString();
                        string[] gg = value1.Split(' ');

                        string g = gg[0].ToString();
                        Console.WriteLine(g);
                        DateTime startDate;
                        string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                                                "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy", "MM/dd/yyyy"};

                        DateTime.TryParseExact(g, formats,
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out startDate);

                        using (MySqlConnection mscon = new MySqlConnection(MyDsql))
                        {
                            //string query = "SELECT UserName, COUNT(UserName) as JobsCount FROM tblJobs WHERE JobStatus != 'Booked' Group by UserName";
                            string ms = "SELECT Date,EmployeeName FROM `attendance` WHERE Remarks_AP = 'Half Day' and Date = '" + startDate.ToString("yyyy-MM-dd") + "' ";

                            MySqlCommand mcmd = new MySqlCommand(ms, mscon);

                            DataTable tb = new DataTable();
                            mscon.Open();
                            MySqlDataAdapter ds = new MySqlDataAdapter();

                            ds.SelectCommand = mcmd;

                            ds.Fill(tb);
                            employeedetailsdataview.DataSource = tb;
                        }
                    }
                }
            }
        }

        #endregion DTR by Date/employee

        #region Report Viewer

        private void empName_Click(object sender, EventArgs e)
        {
            empName.Items.Clear();
            Mysqlloop();

        }

        private void update()
        {
			try
			{
                using (MySqlConnection iconnecth = new MySqlConnection("Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid; Max Pool Size=1000;Convert Zero Datetime=True"))
                {
                    string dateq = DateTime.Now.ToString("yyyy-MM-dd");
                    string selectqueryh = string.Format("SELECT `Date`, `Am_In`, `Am_Out`, `Pm_In`, `Pm_Out` FROM `attendance` WHERE Date = '" + dateq + "' ");

                    MySqlCommand commandh = new MySqlCommand(selectqueryh, iconnecth);
                    iconnecth.Open();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    DateTime A = DateTime.Now.AddDays(0);
                    using (MySqlDataReader readerh = commandh.ExecuteReader())
                    {
                        while (readerh.Read())
                        {
                            using (MySqlConnection iconnectAMIN = new MySqlConnection(MyDsql))
                            {
                                string selectquery12am1 = string.Format("UPDATE `attendance` SET Am_In = '' WHERE Am_In IS NULL");
                                iconnectAMIN.Open();
                                MySqlCommand command12am1 = new MySqlCommand(selectquery12am1, iconnectAMIN);
                                MySqlDataReader reader1am1 = command12am1.ExecuteReader();
                            }
                            using (MySqlConnection iconnectg12AMOUT = new MySqlConnection(MyDsql))
                            {
                                string selectquery12gam2 = string.Format("UPDATE `attendance` SET Am_Out = '' WHERE Am_Out IS NULL");
                                iconnectg12AMOUT.Open();
                                MySqlCommand command12am2 = new MySqlCommand(selectquery12gam2, iconnectg12AMOUT);
                                MySqlDataReader reader1 = command12am2.ExecuteReader();
                            }
                            using (MySqlConnection iconnectg12PMIN = new MySqlConnection(MyDsql))
                            {
                                string selectquery12pm = string.Format("UPDATE `attendance` SET Pm_In = '' WHERE Pm_In IS NULL");
                                iconnectg12PMIN.Open();
                                MySqlCommand command12pm = new MySqlCommand(selectquery12pm, iconnectg12PMIN);
                                MySqlDataReader reader1h = command12pm.ExecuteReader();
                            }
                            using (MySqlConnection iconnectg12pm1 = new MySqlConnection(MyDsql))
                            {
                                string selectquery12g = string.Format("UPDATE `attendance` SET Pm_Out = '' WHERE Pm_Out IS NULL");
                                iconnectg12pm1.Open();
                                MySqlCommand command12 = new MySqlCommand(selectquery12g, iconnectg12pm1);
                                MySqlDataReader reader1pm = command12.ExecuteReader();
                            }
                        }
                    }
                    iconnecth.Close();
                }
            }
			catch (Exception ez)
			{

                MessageBox.Show(ez.Message);
			}
            
        }

        ///Finalize data for absent
        private void calculate()
        {
			try
			{
                using (MySqlConnection iconnect = new MySqlConnection(MyDsql))
                {
                    string dateq = DateTime.Now.ToString("yyyy-MM-dd");
                    string selectquery = string.Format("SELECT * FROM `attendance`");

                    MySqlCommand command = new MySqlCommand(selectquery, iconnect);
                    iconnect.Open();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    DateTime A = DateTime.Now.AddDays(0);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DayOfWeek dayofweek = DateTime.Today.DayOfWeek;

                            if (dayofweek == System.DayOfWeek.Saturday || dayofweek == System.DayOfWeek.Sunday)
                            {
                                using (MySqlConnection iconnectg12 = new MySqlConnection(MyDsql))
                                {
                                    string selectquery1 = string.Format("UPDATE `attendance` SET Remarks_AP = 'WeekEnd/P' WHERE DayofWeek = 'Saturday' and Am_In IS NOT NULL And Am_Out IS NOT NULL and Pm_In IS NOT NULL and Pm_Out IS NOT NULL");
                                    iconnectg12.Open();
                                    MySqlCommand command1 = new MySqlCommand(selectquery1, iconnectg12);
                                    MySqlDataReader reader1 = command1.ExecuteReader();
                                    iconnectg12.Close();
                                }
                                using (MySqlConnection iconnectg123 = new MySqlConnection(MyDsql))
                                {
                                    string selectquery1 = string.Format("UPDATE `attendance` SET Remarks_AP = 'WeekEnd' WHERE DayofWeek = 'Sunday' ");
                                    iconnectg123.Open();
                                    MySqlCommand command1 = new MySqlCommand(selectquery1, iconnectg123);
                                    MySqlDataReader reader1 = command1.ExecuteReader();
                                    iconnectg123.Close();
                                }
                            }
                        }
                    }
                    iconnect.Close();
                }
                using (MySqlConnection iconnectg1 = new MySqlConnection(MyDsql))
                {
                    string selectquery1 = string.Format("SELECT Remarks,Remarks_AP FROM attendance WHERE Remarks = 'No12Break' AND Remarks_AP = 'Present' ");
                    iconnectg1.Open();
                    MySqlCommand command1q = new MySqlCommand(selectquery1, iconnectg1);
                    MySqlDataReader reader1 = command1q.ExecuteReader();

                    if (reader1.Read())
                    {
                        MessageBox.Show("week");
                    }
                    else
                    {
                        using (MySqlConnection iconnectg12 = new MySqlConnection(MyDsql))
                        {
                            string selectquery12 = string.Format("UPDATE `attendance` SET Remarks_AP = 'Present' WHERE Am_In IS NOT NULL AND Am_Out IS NOT NULL AND Pm_In IS NOT NULL AND Pm_Out IS NOT NULL");
                            iconnectg12.Open();
                            MySqlCommand command12 = new MySqlCommand(selectquery12, iconnectg12);
                            MySqlDataReader reader1q = command12.ExecuteReader();
                            iconnectg12.Close();
                        }
                        using (MySqlConnection iconnectg = new MySqlConnection(MyDsql))
                        {
                            string selectquery1q = string.Format("UPDATE `attendance` SET Remarks_AP = 'Absent' WHERE Am_In IS NULL AND Am_Out IS NULL AND Pm_In IS NULL AND Pm_Out IS NULL");
                            iconnectg.Open();
                            MySqlCommand command1q1 = new MySqlCommand(selectquery1q, iconnectg);
                            MySqlDataReader reader1q1 = command1q1.ExecuteReader();
                            iconnectg.Close();
                        }

                        using (MySqlConnection iconnectg1q = new MySqlConnection(MyDsql))
                        {
                            string selectquery1q = string.Format("UPDATE `attendance` SET Remarks_AP = 'Half Day' WHERE Am_In IS NOT NULL AND Am_Out IS NOT NULL AND Pm_In IS NULL AND Pm_out IS NULL");
                            iconnectg1q.Open();
                            MySqlCommand command1qs = new MySqlCommand(selectquery1q, iconnectg1q);
                            MySqlDataReader reader1q2 = command1qs.ExecuteReader();
                            iconnectg1q.Close();
                        }
                        using (MySqlConnection icon = new MySqlConnection(MyDsql))
                        {
                            string selectquery1q = string.Format("UPDATE `attendance` SET Remarks_AP = 'Half Day' WHERE Am_In IS NULL AND Am_Out IS NULL AND Pm_In IS NOT NULL AND Pm_out IS NOT NULL ");
                            icon.Open();
                            MySqlCommand command1qq = new MySqlCommand(selectquery1q, icon);
                            MySqlDataReader reader1q3 = command1qq.ExecuteReader();
                            icon.Close();
                        }
                    }
                    iconnectg1.Close();
                }
            }
			catch (Exception ez)
			{

                MessageBox.Show(ez.Message);
			}
        }

        private void Finalize_Click(object sender, EventArgs e)
        {
            calculate();
            //update();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DtrbyDate();
        }

        private void Mysqlloop()
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(MyDsql))
                {
                    string querry = "SELECT EmployeeName FROM employees";
                    // string querry1 = "SELECT EmployeeName FROM employees";

                    mysql.Open();
                    MySqlCommand cmdO = new MySqlCommand(querry, mysql);
                    MySqlDataReader readd = cmdO.ExecuteReader();

                    while (readd.Read())

                    {
                        empName.Items.Add(readd.GetString("EmployeeName"));
                    }
                    mysql.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
        }

        private void rep()
        {
            try
            {
                using (MySqlConnection selectEmp = new MySqlConnection(MyDsql))
                {
                    string QueryRef11 = "select `EmployeeName` from attendance  WHERE EmployeeName = @empName";

                    MySqlCommand cmdz = new MySqlCommand(QueryRef11, selectEmp);

                    selectEmp.Open();
                    cmdz.Parameters.AddWithValue("@empName", empName.Text);

                    MySqlDataReader R = cmdz.ExecuteReader();
                    if (R.Read())
                    {
                        using (MySqlConnection conn1k = new MySqlConnection(MyDsql))
                        {
                            string QueryRef1 = "select `EmployeeRfid`,`Date`,`Am_In`,`Am_Out`,`Pm_In`,`Pm_Out`,`Remarks`,`Remarks_AP`  from attendance  WHERE EmployeeName = @empName And Date BETWEEN @date and @date1 ORDER BY Date ASC";

                            MySqlCommand cmd = new MySqlCommand(QueryRef1, conn1k);

                            DateTime dtToday = strtDate.Value;
                            DateTime dtToday1 = endDate.Value;
                            string strDate = dtToday.ToString("yyyy/MM/dd");
                            string strDate1 = dtToday1.ToString("yyyy/MM/dd");

                            cmd.Parameters.AddWithValue("@date", strDate);
                            cmd.Parameters.AddWithValue("@date1", strDate1);
                            cmd.Parameters.AddWithValue("@empName", empName.Text);
                            Console.WriteLine(strDate);
                            conn1k.Open();
                            MySqlDataAdapter adp = new MySqlDataAdapter();

                            adp.SelectCommand = cmd;
                            DataTable dTable = new DataTable();
                            adp.Fill(dTable);
                            AttendanceReport1.SetDataSource(dTable);

                            TextObject txtMonth = (TextObject)AttendanceReport1.ReportDefinition.Sections["Section2"].ReportObjects["Month"];
                            txtMonth.Text = strtDate.Value.ToString("MMMM");

                            TextObject EmpName = (TextObject)AttendanceReport1.ReportDefinition.Sections["Section2"].ReportObjects["EmployeeName"];
                            EmpName.Text = empName.Text;

                            TextObject EmpRfid = (TextObject)AttendanceReport1.ReportDefinition.Sections["Section2"].ReportObjects["rfid"];
                            EmpRfid.Text = rfid.Text;

                            TextObject EmpNamepr = (TextObject)AttendanceReport1.ReportDefinition.Sections["Section4"].ReportObjects["EmpNamePr"];
                            EmpNamepr.Text = empName.Text;

                            TextObject RepsTo = (TextObject)AttendanceReport1.ReportDefinition.Sections["Section4"].ReportObjects["EmpRepsTo"];
                            RepsTo.Text = incharge.Text;

                            crystalReportViewer1.ReportSource = AttendanceReport1;

                            conn1k.Close();
                        }
                    }
                    else
                    {
                       // MessageBox.Show("No data Found");
                    }
                    selectEmp.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void reps()
        {
            using (MySqlConnection conn1 = new MySqlConnection(MyDsql))
            {
                try
                {
                    string QuerryRefresh = "SELECT `EmployeeRfidTag` FROM employees WHERE EmployeeName = @empname";
                    MySqlCommand cmd = new MySqlCommand(QuerryRefresh, conn1);

                    cmd.Parameters.AddWithValue("@empname", empName.Text);
                    conn1.Open();
                    MySqlDataReader d = cmd.ExecuteReader();

                    if (d.Read())
                    {
                        rfid.Text = d.GetValue(0).ToString();
                    }
                    conn1.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (empName.Text == "")
            {
                MessageBox.Show("Please select from the dropdown menu first.", "Info");
            }
            else if (incharge.Text == "")
            {
                MessageBox.Show("Please type Incharge Personnel.", "Info");
            }
            else
            {
                rep();
                crystalReportViewer1.Refresh();
                crystalReportViewer1.Zoom(1);
            }
        }

        #endregion Report Viewer

        #region Settings

        #region export/import

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            string file = @"C:\RFID\BROWSE\ams_rfid.sql";
            using (MySqlConnection conn = new MySqlConnection(MyDsql))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }
            string backup1 = @"C:\RFID\BROWSE\BACKUP\ams_rfid.sql";
            using (MySqlConnection conn = new MySqlConnection(MyDsql))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(backup1);
                        conn.Close();
                    }
                }
            }
            MessageBox.Show("SUCCESSFULLY BACK UP.", "Information");
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
			if (MessageBox.Show("Do you want to Import File?","Warning",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if (MessageBox.Show("You cannot Revert this area, once imported, the current database will be deleted. Are you Sure?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
                    try
                    {
                        string file = @"C:\RFID\BROWSE\ams_rfid.sql";
                        using (MySqlConnection conn = new MySqlConnection(MyDsql))
                        {
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                using (MySqlBackup mb = new MySqlBackup(cmd))
                                {
                                    cmd.Connection = conn;
                                    conn.Open();
                                    mb.ImportFromFile(file);
                                    conn.Close();
                                }
                            }
                        }
                        MessageBox.Show("SUCCESSFULLY RESTORED.", "Information");


                    }
                    catch
                    {
                        MessageBox.Show("Max Allowed Packets needed is greter than 1M", "Warning");
                    }
                }
				else
				{
                    MessageBox.Show("Import Cancelled.", "Inoformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
			else
			{
                MessageBox.Show("Import Cancelled.", "Inoformation",MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			
           } 

        #endregion export/import

        //autorefresh dbs
        //db_for_DTR

        //TODAYS LOG TICK
        private void guna2ToggleSwitch6_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch6.Checked == true)
            {
                AutoRefreshDB.Enabled = true;
                AutoRefreshDB.Start();
            }
            else
            {
                AutoRefreshDB.Enabled = false;
                AutoRefreshDB.Stop();
            }
        }

        //FULL LOGS TICK
        private void guna2ToggleSwitch7_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch7.Checked == true)
            {
                FullLogTimer1.Enabled = true;
                FullLogTimer1.Start();
            }
            else
            {
                FullLogTimer1.Enabled = false;
                FullLogTimer1.Stop();
            }
        }

        //EMPLOYEELIST TICK
        private void guna2ToggleSwitch8_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch8.Checked == true)
            {
                EmpListTimer.Enabled = true;
                EmpListTimer.Start();
            }
            else
            {
                EmpListTimer.Stop();
                EmpListTimer.Enabled = false;
            }
        }

        private void RepsTo_Tick(object sender, EventArgs e)
        {
			try
			{
                using (MySqlConnection ms = new MySqlConnection(MyDsql))
                {
                    string QuerryRefresh = "SELECT * FROM reportsto";
                    //string QueryRef1 = "select `EmployeeRfid`,`EmployeeName`,`Date`,`Am_In`,`Am_Out`,`Pm_In`,`Pm_Out`,`Remarks`  from attendance  WHERE Date= '" + date + "'";

                    MySqlCommand cmd = new MySqlCommand(QuerryRefresh, ms);

                    ms.Open();
                    MySqlDataAdapter adp = new MySqlDataAdapter();

                    adp.SelectCommand = cmd;

                    DataTable dTable = new DataTable();

                    adp.Fill(dTable);

                    guna2DataGridView5.DataSource = dTable;
                    ms.Close();
                }
            }
			catch (Exception ez)
			{
                MessageBox.Show(ez.Message);
            }
            
        }

        //deP
        private void guna2ToggleSwitch9_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch9.Checked == true)
            {
                DeptAutoRefTbl.Enabled = true;
                DeptAutoRefTbl.Start();
            }
            else
            {
                DeptAutoRefTbl.Enabled = false;
                DeptAutoRefTbl.Stop();
            }
        }

        private void employeeNameComboBox_Click(object sender, EventArgs e)
        {
            employeeNameComboBox.Items.Clear();
            RefreshRepsTo();
        }

        private void employeedetailsdataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (employeedetailsdataview.Columns[e.ColumnIndex].Name == "Details11")
            {
                foreach (DataGridViewRow row in employeedetailsdataview.SelectedRows)
                {
                    string value1 = row.Cells[2].Value.ToString();
                    Console.WriteLine(value1);

                    guna2TabControl4.SelectedIndex = 1;
					try
					{
                        using (MySqlConnection md = new MySqlConnection(MyDsql))
                        {
                            string g = "SELECT EmployeeName,Date,Am_In,Am_Out,Pm_In,Pm_Out,Remarks,Remarks_AP FROM attendance WHERE EmployeeName=@emp ";

                            MySqlCommand c = new MySqlCommand(g, md);
                            c.Parameters.AddWithValue("@emp", value1);
                            md.Open();

                            MySqlDataAdapter ad = new MySqlDataAdapter();
                            DataTable gs = new DataTable();

                            ad.SelectCommand = c;
                            ad.Fill(gs);

                            EmployeeGrid.DataSource = gs;
                            md.Close();
                        }
                    }
					catch (Exception)
					{
                        MessageBox.Show("Error Connection the server");
					}
                    
                }
            }
        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
            
        }
       //dES
        private void guna2ToggleSwitch10_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch10.Checked == true)
            {
                DesAutoRefTbl.Enabled = true;
                DesAutoRefTbl.Start();
            }
            else
            {
                DesAutoRefTbl.Enabled = false;
                DesAutoRefTbl.Stop();
            }
        }

        //Resps
        private void guna2ToggleSwitch11_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch11.Checked == true)
            {
                RepsTo.Enabled = true;
                RepsTo.Start();
            }
            else
            {
                RepsTo.Enabled = false;
                RepsTo.Stop();
            }
        }

        //DTR
        private void guna2ToggleSwitch12_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch12.Checked == true)
            {
                DTRbyDateTimer.Enabled = true;
                DTRbyDateTimer.Start();
            }
            else
            {
                DTRbyDateTimer.Enabled = false;
                DTRbyDateTimer.Stop();
            }
        }

        //travel
        private void guna2ToggleSwitch14_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch14.Checked == true)
            {
                TravelDb.Enabled = true;
                TravelDb.Start();
            }
            else
            {
                TravelDb.Enabled = false;
                TravelDb.Stop();
            }
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            if (CurrPass.Text == "" || NewPass.Text == "" || ReTPass.Text == "")
            {
                MessageBox.Show("Please FIll the textboxes first.", "Information");
            }
            else
            {
				try
				{
                    using (MySqlConnection ms = new MySqlConnection(MyDsql))
                    {
                        string updt = "SELECT password FROM login WHERE password = @pass";
                        ms.Open();
                        MySqlCommand c = new MySqlCommand(updt, ms);

                        c.Parameters.AddWithValue("@pass", CurrPass.Text);

                        MySqlDataReader r = c.ExecuteReader();
                        if (r.Read())
                        {
                            if (NewPass.Text == ReTPass.Text)
                            {
                                if (MessageBox.Show("Are you sure to change password???????", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    using (MySqlConnection n = new MySqlConnection(MyDsql))
                                    {
                                        string d = "UPDATE 'login' SET 'password' = @password ";
                                        string d1 = "UPDATE `login` SET `password`=@password";

                                        n.Open();
                                        MySqlCommand gs = new MySqlCommand(d1, n);

                                        gs.Parameters.AddWithValue("@password", ReTPass.Text);

                                        MySqlDataReader t = gs.ExecuteReader();
                                        n.Close();
                                    }
                                    AutoClosingMessageBox.Show("Change password Successfully", "Information", 2000);
                                }
                                else
                                {
                                    AutoClosingMessageBox.Show("No Changes made.", "Information", 2000);
                                }
                            }
                            else
                            {
                                AutoClosingMessageBox.Show("Password does not Match", "error", 2500);
                            }
                            ms.Close();
                        }
                        else
                        {
                            AutoClosingMessageBox.Show("Password does not Match", "error", 2500);
                        }
                    }
                }
				catch (Exception ex)
				{

                    MessageBox.Show(ex.Message);
				}
               
            }
        }

        //nONOONBREAKCOMBO
        private void guna2ComboBox2_Click(object sender, EventArgs e)
        {
            guna2ComboBox2.Items.Clear();
            NoNoonBreakDb();
        }

		private void guna2GradientButton11_Click(object sender, EventArgs e)
		{

		}

		private void empName_TextChanged(object sender, EventArgs e)
		{
            reps();
        }

		private void BrwsTrainFile_Click(object sender, EventArgs e)
		{
            Process.Start("C:\\RFID\\TrainedFaces\\TrainedLabels.txt");
		}

		private void MainPage_MouseClick(object sender, MouseEventArgs e)
		{
            //
            
		}

		private void MainPage_Activated(object sender, EventArgs e)
		{
            this.Activate();
		}

		private void WebCamSelect1_Click(object sender, EventArgs e)
		{
            WebCamSelect1.Items.Clear();
            //video source
            VideoCaptureDevices1 = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices1)
            {
                WebCamSelect.Items.Add(VideoCaptureDevice.Name);
                WebCamSelect.SelectedIndex = 0;
            }
            FinalVideo = new VideoCaptureDevice();
            //CaptureApp = new Capture(WebCamSelect.SelectedIndex);

            //video source
            VideoCaptureDevices1 = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices1)
            {
                WebCamSelect1.Items.Add(VideoCaptureDevice.Name);
                WebCamSelect.SelectedIndex = 0;
            }
            FinalVideo = new VideoCaptureDevice();
            //CaptureApp = new Capture(WebCamSelect.SelectedIndex);

        }

		private void WebCamSelect_Click(object sender, EventArgs e)
		{
            WebCamSelect.Items.Clear();
            //video source
            VideoCaptureDevices1 = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices1)
            {
                WebCamSelect.Items.Add(VideoCaptureDevice.Name);
                WebCamSelect.SelectedIndex = 0;
            }
            FinalVideo = new VideoCaptureDevice();
            //CaptureApp = new Capture(WebCamSelect.SelectedIndex);

            //video source
            VideoCaptureDevices1 = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices1)
            {
                WebCamSelect.Items.Add(VideoCaptureDevice.Name);
                WebCamSelect.SelectedIndex = 0;
            }
            FinalVideo = new VideoCaptureDevice();
            //CaptureApp = new Capture(WebCamSelect.SelectedIndex);
        }

        private void NoNoonBreakDb()
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");

                using (MySqlConnection mswl = new MySqlConnection(MyDsql))
                {
                    string Ref = "SELECT EmployeeName FROM attendance WHERE Date = '" + date + "' ";
                    mswl.Open();
                    MySqlCommand cmdO = new MySqlCommand(Ref, mswl);
                    MySqlDataReader readd = cmdO.ExecuteReader();

                    while (readd.Read())

                    {
                        guna2ComboBox2.Items.Add(readd.GetString("EmployeeName"));
                    }
                    mswl.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                    using (MySqlConnection s = new MySqlConnection(MyDsql))
                    {
                        string d = "UPDATE attendance SET Remarks = 'No12Break',Remarks_AP = 'Present' WHERE EmployeeName = @emp AND Date = @date";

                        MySqlCommand c = new MySqlCommand(d, s);

                        c.Parameters.AddWithValue("@emp", guna2ComboBox2.Text);
                        c.Parameters.AddWithValue("@date", date);
                        s.Open();
                        MySqlDataReader r = c.ExecuteReader();
                        s.Close();
                    }
                    AutoClosingMessageBox.Show("Updated successfully", "Information", 2000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                AutoClosingMessageBox.Show("No changes Made", "Information", 2000);
            }
        }

        //General


        //General Employee db+Combo


        #endregion Settings
    }
}