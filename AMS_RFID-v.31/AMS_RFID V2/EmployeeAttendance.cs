using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AMS_RFID_V2
{
    public partial class EmployeeAttendance : Form
    {
        // private bool streaming;
        // private Capture CaptureApp;
        //private HaarCascade haar;
        //Declararation of all variables, vectors and haarcascades
        private Image<Bgr, Byte> currentFrame;

        private Capture grabber;
        private HaarCascade face;
        private MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        private Image<Gray, byte> result, TrainedFace = null;
        private Image<Gray, byte> gray = null;
        private List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        private List<string> labels = new List<string>();
        private List<string> NamePersons = new List<string>();
        private int ContTrain, NumLabels, t;
        private string name, names = null;

        //MainPage AttendanceGridView;
        public EmployeeAttendance()
        {
            InitializeComponent();
            //this.AttendanceGridView = g;
        }

        //mysql COnnections
        private string MyDsql = "Datasource=localhost;port=3306;username=AMS_RFID;password=@M$_Rf1d2O22; database = ams_rfid; Max Pool Size=1000;Convert Zero Datetime=True";

        #region others

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion others

        //LOAD//
        private void EmployeeAttendance_Load(object sender, EventArgs e)
        {

            btnScan.Focus();
            //this.ActiveControl = btnScan;
            webcam1.Enabled = true;
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            //button1.Enabled = false;
            panelONOFF.SendToBack();
            btnScan.Focus();
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                string path = @"I:/TrainedFaces/TrainedLabels.txt";
                string path1 = @"I:/TrainedFaces/";
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
            catch (Exception)
            {
                MessageBox.Show("Please copy trained images from the admin, Thank you");
            }
        }

        #region OTHERS

        //Date
        private void DateTimer_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString("dddd | MMMM dd,yyyy");
        }

        //TIme
        private void Time_Tick(object sender, EventArgs e)
        {
            timeclock.Text = DateTime.Now.ToString("hh:mm");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec.Text = DateTime.Now.ToString("ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            am.Text = DateTime.Now.ToString("tt");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //Date1.Text = DateTime.Now.ToString("dddd | MMMM dd,yyyy");
        }

        private void AmPm_Tick(object sender, EventArgs e)
        {
            DateTime timeOfDayGreeting = DateTime.Now;

            if (timeOfDayGreeting.Hour >= 5 && timeOfDayGreeting.Hour < 12)
            {
                Greetings.ForeColor = Color.Yellow;
                Greetings.Text = "Good morning!";
                g.Visible = true;
            }
            else if (timeOfDayGreeting.Hour >= 12 && timeOfDayGreeting.Hour < 18)
            {
                Greetings.ForeColor = Color.Azure;
                Greetings.Text = "Good Afternoon!";
                g.Visible = true;
            }
            else
            {
                Greetings.ForeColor = Color.Black;
                Greetings.Text = "Good Evening!";
                g.Visible = false;
            }
        }

        #region AUTO CLOSE MESSAGBOX

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

        #endregion AUTO CLOSE MESSAGBOX

        #endregion OTHERS

        #region details

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            string s = "Members:";
            string G = "Glenn Contreras(Programmer)";
            string C = "Cristian Silos(Database designer)";
            string E = "Eulises Gorospe(Analyst)";
            string SysName = "AMS_RFID 2022";

            MessageBox.Show("\t" + "Welcome to AMS_rfid!" + "\n" + s + "\n" + "\t" + G + "\n" + "\t" + C + "\n" + "\t" + E + "\n" + "\n" + "\t" + "\t" + SysName, "Information", MessageBoxButtons.OK);
        }

        #endregion details

        #region Train Face

        private void FrameGrabber(object sender, EventArgs e)
        {
            try
            {
                RFID.Text = "0";
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
                    RFID.Text = facesDetected[0].Length.ToString();
                }
                t = 0;

                //Names concatenation of persons recognized
                for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                {
                    names = NamePersons[nnn];
                }
                //Show the faces procesed and recognized
                webcam1.Image = currentFrame;
                RFID.Text = names;
                names = "";
                //Clear the list(vector) of names
                NamePersons.Clear();
            }
            catch (Exception)
            {
                //
            }
        }

        #endregion Train Face

        //Scan RFID TAg HERE

        private bool _ran = false; //initial setting at start up

        private void insert_Tick(object sender, EventArgs e)
        {
            TimeSpan newDayReference = new TimeSpan(24, 0, 0);
            TimeSpan comparison;

            //These two variables set to show difference.
            DateTime A = DateTime.Now.AddDays(+1);
            DateTime B = DateTime.Now;
            comparison = B - A;
            var d = B < A;

            var G = comparison < newDayReference;

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            if (DateTime.Now.Hour == 5 && DateTime.Now.Minute == 0 && _ran == false && B < A)
            {
                _ran = true;
                Sql();
            }

            if (DateTime.Now.Hour != 5 && _ran == true)
            {
                _ran = false;
            }
        }

        private bool _ran1 = false; //initial setting at start up

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                //EmployeeAttendance EmpAtt = new EmployeeAttendance();
                //EmpAtt.ShowDialog();
            }
        }

        private void timerCountOnAbsences_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == 23 && DateTime.Now.Minute < 5 && _ran1 == false)
            {
                _ran1 = true;
                calculate();
            }
            if (DateTime.Now.Hour != 23 && DateTime.Now.Minute < 5 && _ran1 == true)
            {
                _ran1 = false;
            }
        }

        private void Imagebox_Click(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //form deactivated
        private void EmployeeAttendance_Deactivate(object sender, EventArgs e)
        {
            txfocus.Enabled = true;
        }

        private void btnScan_Leave(object sender, EventArgs e)
        {
            btnScan.Focus();
        }

        private void txfocus_Tick(object sender, EventArgs e)
        {
            txfocus.Enabled = false;
            Show();
            Activate();
        }

        private void imageShow_Tick(object sender, EventArgs e)
        {
            //Images Show then off
            using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
            {
                string imges = "SELECT image FROM employees WHERE EmployeeRfidTag =@EmployeeRfidTag";
                MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                cmdO.Parameters.AddWithValue("@EmployeeRfidTag", btnScan.Text);

                MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                DataTable tbk = new DataTable();

                da.Fill(tbk);
                byte[] img = (byte[])tbk.Rows[0][0];

                MemoryStream ms1 = new MemoryStream(img);
                Imagebox.Image = Image.FromStream(ms1);

                da.Dispose();
            }
        }

        #region DATABASE

        private void Sql()
        {
            DayOfWeek dayofweek = DateTime.Today.DayOfWeek;
            Console.WriteLine(dayofweek);
            using (MySqlConnection iconnect = new MySqlConnection(MyDsql))
            {
                string selectquery = string.Format("SELECT * FROM employees ");

                MySqlCommand command = new MySqlCommand(selectquery, iconnect);
                iconnect.Open();
                string date = DateTime.Now.ToString("yyyy-MM-dd");

                using (MySqlDataReader reader = command.ExecuteReader())
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
                iconnect.Close();
            }
        }

        private void calculate()
        {
            using (MySqlConnection iconnect = new MySqlConnection(MyDsql))
            {
                string dateq = DateTime.Now.ToString("yyyy-MM-dd");
                string selectquery = string.Format("SELECT `Date`, `Am_In`, `Am_Out`, `Pm_In`, `Pm_Out` FROM `attendance` WHERE Date = '" + dateq + "' ");

                MySqlCommand command = new MySqlCommand(selectquery, iconnect);
                iconnect.Open();
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                DateTime A = DateTime.Now.AddDays(0);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DayOfWeek dayofweek = DateTime.Today.DayOfWeek;
                        if (dayofweek == DayOfWeek.Saturday || dayofweek == DayOfWeek.Sunday)
                        {
                            using (MySqlConnection iconnectg12 = new MySqlConnection(MyDsql))
                            {
                                string selectquery1 = string.Format("UPDATE `attendance` SET Remarks_AP = 'WeekEnd' WHERE DayofWeek = 'Saturday' and Date='" + date + "'");
                                iconnectg12.Open();
                                MySqlCommand command1 = new MySqlCommand(selectquery1, iconnectg12);
                                MySqlDataReader reader1 = command1.ExecuteReader();
                            }
                            using (MySqlConnection iconnectg123 = new MySqlConnection(MyDsql))
                            {
                                string selectquery1 = string.Format("UPDATE `attendance` SET Remarks_AP = 'WeekEnd' WHERE DayofWeek = 'Sunday' and Date='" + date + "'");
                                iconnectg123.Open();
                                MySqlCommand command1 = new MySqlCommand(selectquery1, iconnectg123);
                                MySqlDataReader reader1 = command1.ExecuteReader();
                            }
                        }
                        else
                        {
                            using (MySqlConnection iconnectg12 = new MySqlConnection(MyDsql))
                            {
                                string selectquery12 = string.Format("UPDATE `attendance` SET Remarks_AP = 'Present' WHERE Date='" + date + "' AND  Am_In IS NOT NULL AND Am_Out IS NOT NULL AND Pm_In IS NOT NULL AND Pm_Out IS NOT NULL");
                                iconnectg12.Open();
                                MySqlCommand command12 = new MySqlCommand(selectquery12, iconnectg12);
                                MySqlDataReader reader1 = command12.ExecuteReader();
                            }
                            using (MySqlConnection iconnectg = new MySqlConnection(MyDsql))
                            {
                                string selectquery1 = string.Format("UPDATE `attendance` SET Remarks_AP = 'Absent' WHERE Date='" + date + "' AND Am_In IS NULL AND Am_Out IS NULL AND Pm_In IS NULL AND Pm_Out IS NULL");
                                iconnectg.Open();
                                MySqlCommand command1 = new MySqlCommand(selectquery1, iconnectg);
                                MySqlDataReader reader1 = command1.ExecuteReader();
                            }

                            using (MySqlConnection iconnectg1 = new MySqlConnection(MyDsql))
                            {
                                string selectquery1 = string.Format("UPDATE `attendance` SET Remarks_AP = 'Half Day' WHERE Date='" + date + "' AND  Am_In IS NOT NULL AND Am_Out IS NOT NULL AND Pm_In IS NULL AND Pm_out IS NULL");
                                iconnectg1.Open();
                                MySqlCommand command1 = new MySqlCommand(selectquery1, iconnectg1);
                                MySqlDataReader reader1 = command1.ExecuteReader();
                            }
                            using (MySqlConnection iconnectg1 = new MySqlConnection(MyDsql))
                            {
                                string selectquery1 = string.Format("UPDATE `attendance` SET Remarks_AP = 'Half Day' WHERE Date='" + date + "' AND  Am_In IS NULL AND Am_Out IS NULL AND Pm_In IS NOT NULL AND Pm_out IS NOT NULL ");
                                iconnectg1.Open();
                                MySqlCommand command1 = new MySqlCommand(selectquery1, iconnectg1);
                                MySqlDataReader reader1 = command1.ExecuteReader();
                            }
                        }
                    }
                }
                iconnect.Close();
            }
        }

        #endregion DATABASE

        private void update()
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
                            string selectquery12pm = string.Format("UPDATE `attendance` SET Pm_In = '' WHERE Am_In IS NULL");
                            iconnectg12PMIN.Open();
                            MySqlCommand command12pm = new MySqlCommand(selectquery12pm, iconnectg12PMIN);
                            MySqlDataReader reader1h = command12pm.ExecuteReader();
                        }
                        using (MySqlConnection iconnectg12pm1 = new MySqlConnection(MyDsql))
                        {
                            string selectquery12g = string.Format("UPDATE `attendance` SET Pm_Out = '' WHERE Am_Out IS NULL");
                            iconnectg12pm1.Open();
                            MySqlCommand command12 = new MySqlCommand(selectquery12g, iconnectg12pm1);
                            MySqlDataReader reader1pm = command12.ExecuteReader();
                        }
                    }
                }
                iconnecth.Close();
            }
        }

        #region aTTENDANCE

        //Attendance resides here
        private void btnScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnScan.Text == RFID.Text)
                {
                    using (MySqlConnection iconnect = new MySqlConnection(MyDsql))
                    {
                        string selectquery = string.Format("SELECT * from employees Where EmployeeRfidTag = '{0}'", btnScan.Text);

                        MySqlCommand command = new MySqlCommand(selectquery, iconnect);
                        iconnect.Open();
                        var dtime = DateTime.Now;
                        dtime.ToString("hh:mm:ss");
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            string catchTime0 = DateTime.Now.ToString("hh:mm tt");

                            if (reader.Read())
                            {
                                string info;
                                string catchTime;
                                string remarks;

                                #region TimeSpan

                                TimeSpan startam = new TimeSpan(8, 0, 0); //10 o'clock
                                                                          //TimeSpan endam = new TimeSpan(8, 15, 0); //12 o'clock
                                TimeSpan now = DateTime.Now.TimeOfDay;
                                DateTime theDate = DateTime.Today;

                                TimeSpan startam8 = new TimeSpan(8, 0, 0); //10 o'clock
                                TimeSpan endam8 = new TimeSpan(8, 15, 0); //12 o'clock
                                now = DateTime.Now.TimeOfDay;

                                TimeSpan startam1 = new TimeSpan(8, 15, 0); //10 o'clock
                                TimeSpan endam1 = new TimeSpan(8, 31, 0); //12 o'clock
                                now = DateTime.Now.TimeOfDay;

                                TimeSpan start830 = new TimeSpan(8, 30, 0); //10 o'clock
                                TimeSpan end12 = new TimeSpan(11, 59, 0); //12 o'clock
                                now = DateTime.Now.TimeOfDay;

                                TimeSpan start11 = new TimeSpan(10, 0, 0); //10 o'clock
                                TimeSpan end11 = new TimeSpan(11, 0, 0); //12 o'clock
                                now = DateTime.Now.TimeOfDay;

                                TimeSpan start12 = new TimeSpan(11, 0, 0); //10 o'clock
                                TimeSpan end1122 = new TimeSpan(12, 0, 0); //12 o'clock
                                now = DateTime.Now.TimeOfDay;

                                TimeSpan start111pm = new TimeSpan(12, 0, 0); //10 o'clock
                                TimeSpan end1pm = new TimeSpan(13, 0, 0); //12 o'clock
                                now = DateTime.Now.TimeOfDay;

                                TimeSpan startinpm = new TimeSpan(15, 0, 0); //10 o'clock
                                TimeSpan end1inpm = new TimeSpan(16, 0, 0); //12 o'clock
                                now = DateTime.Now.TimeOfDay;

                                var str1 = start111pm.Subtract(TimeSpan.FromHours(11));//1
                                var endt = end1pm.Subtract(TimeSpan.FromHours(11));//2

                                var ttimeOut = startinpm.Subtract(TimeSpan.FromHours(13));//2
                                var end5time = end1pm.Subtract(TimeSpan.FromHours(14));//3

                                #endregion TimeSpan

                                // <8:00
                                if ((now < startam))
                                {
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                                    catchTime = DateTime.Now.ToString("hh:mm tt");
                                    IDrecognaizer.Visible = true;
                                    tme.Visible = true;
                                    timed.Visible = true;
                                    rem.Visible = true;
                                    inff.Visible = true;

                                    info = "Time in_0";
                                    remarks = "Early " + catchTime0;
                                    //LESS THEN 8AM
                                    using (MySqlConnection iconnectSelect = new MySqlConnection(MyDsql))
                                    {
                                        string selectquerry1 = "SELECT `EmployeeRfid`, `Date` FROM `attendance` WHERE EmployeeRfid = @rfid AND Date= '" + date + "' AND Am_In IS NULL ";

                                        MySqlCommand commandSelect = new MySqlCommand(selectquerry1, iconnectSelect);

                                        commandSelect.Parameters.AddWithValue("@rfid", btnScan.Text);

                                        MySqlDataReader readerSelect;
                                        iconnectSelect.Open();

                                        readerSelect = commandSelect.ExecuteReader();
                                        if (readerSelect.Read())
                                        {
                                            MySqlConnection iconnect12 = new MySqlConnection(MyDsql);

                                            string insertquerry1 = "UPDATE `attendance` SET `Am_In` = current_timestamp() , remarks = 'Early' WHERE `attendance`.`Date` = '" + date + "' AND `attendance`.`EmployeeRfid` = @EmployeeRfid";

                                            MySqlCommand command123 = new MySqlCommand(insertquerry1, iconnect12);
                                            command123.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);
                                            MySqlDataReader reader23;
                                            iconnect12.Open();
                                            reader23 = command123.ExecuteReader();

                                            
                                        }
                                        else
                                        {
                                            AutoClosingMessageBox.Show("Already Log", "Information : < 8", 2000);
                                        }

                                        catchTime = DateTime.Now.ToString("hh:mm tt");
                                        IDrecognaizer.Text = "Hello";
                                        cvname.Text = reader["EmployeeName"].ToString();
                                        timed.Text = catchTime;
                                        Remarks.Text = remarks;
                                        info32.Text = info;
                                        btnScan.Clear();
                                    }
                                }
                                //8:00 - 8:15
                                else if ((now > startam8) && (now < endam8))
                                {
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                                    catchTime = DateTime.Now.ToString("hh:mm tt");
                                    IDrecognaizer.Visible = true;
                                    tme.Visible = true;
                                    timed.Visible = true;
                                    rem.Visible = true;
                                    inff.Visible = true;

                                    theDate = DateTime.Today;
                                    info = "Time in_0";
                                    remarks = "On Time " + catchTime0;
                                    //LESS THEN 8AM
                                    using (MySqlConnection iconnectSelect = new MySqlConnection(MyDsql))
                                    {
                                        string selectquerry1 = "SELECT `EmployeeRfid`, `Date` FROM `attendance` WHERE EmployeeRfid = @rfid AND Date= '" + date + "' AND Am_in IS NULL";

                                        MySqlCommand commandSelect = new MySqlCommand(selectquerry1, iconnectSelect);
                                        commandSelect.Parameters.AddWithValue("@rfid", btnScan.Text);

                                        MySqlDataReader readerSelect;
                                        iconnectSelect.Open();

                                        readerSelect = commandSelect.ExecuteReader();
                                        if (readerSelect.Read())
                                        {
                                            MySqlConnection iconnect12 = new MySqlConnection(MyDsql);

                                            string insertquerry1 = "UPDATE `attendance` SET `Am_In` = current_timestamp() , remarks = 'Ontime' WHERE `attendance`.`Date` = '" + date + "' AND `attendance`.`EmployeeRfid` = @EmployeeRfid";

                                            MySqlCommand command123 = new MySqlCommand(insertquerry1, iconnect12);
                                            command123.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);

                                            MySqlDataReader reader23;
                                            iconnect12.Open();
                                            reader23 = command123.ExecuteReader();

                                            using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                                            {
                                                string imges = "SELECT image FROM employees WHERE EmployeeRfidTag =@EmployeeRfidTag";
                                                MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                                                cmdO.Parameters.AddWithValue("@EmployeeRfidTag", btnScan.Text);

                                                MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                                                DataTable tbk = new DataTable();

                                                da.Fill(tbk);
                                                byte[] img = (byte[])tbk.Rows[0][0];

                                                MemoryStream ms1 = new MemoryStream(img);
                                                Imagebox.Image = Image.FromStream(ms1);

                                                da.Dispose();
                                            }
                                        }
                                        else
                                        {
                                            AutoClosingMessageBox.Show("Already Log", "Information : 8 - 8:15", 2000);
                                        }
                                        catchTime = DateTime.Now.ToString("hh:mm tt");
                                        IDrecognaizer.Text = "Hello";
                                        cvname.Text = reader["EmployeeName"].ToString();
                                        timed.Text = catchTime;
                                        Remarks.Text = remarks;
                                        info32.Text = info;
                                        btnScan.Clear();
                                    }
                                }
                                //8:15 - 8:30
                                else if ((now > startam1) && (now <= endam1))
                                {
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                                    IDrecognaizer.Visible = true;
                                    tme.Visible = true;
                                    timed.Visible = true;
                                    rem.Visible = true;
                                    inff.Visible = true;
                                    //Notif.Visible = false;

                                    info = "Time in_1";
                                    remarks = "Late";

                                    using (MySqlConnection iconnectSelect1 = new MySqlConnection(MyDsql))
                                    {
                                        DateTime time = DateTime.Now;
                                        string selectquerry11 = "SELECT `EmployeeRfid`, `Date` FROM `attendance` WHERE EmployeeRfid = @rfid AND `attendance`.`Date` = '" + date + "' AND Am_In IS NULL";

                                        MySqlCommand commandSelect = new MySqlCommand(selectquerry11, iconnectSelect1);
                                        commandSelect.Parameters.AddWithValue("@rfid", btnScan.Text);

                                        MySqlDataReader readerSelect11;
                                        iconnectSelect1.Open();

                                        readerSelect11 = commandSelect.ExecuteReader();
                                        if (readerSelect11.Read())
                                        {
                                            MySqlConnection iconnect12 = new MySqlConnection(MyDsql);

                                            string insertquerry1 = "UPDATE `attendance` SET `Am_In` = current_timestamp(), remarks='Late' WHERE `attendance`.`Date` = '" + date + "' AND `attendance`.`EmployeeRfid` = @EmployeeRfid ";

                                            MySqlCommand command123 = new MySqlCommand(insertquerry1, iconnect12);
                                            command123.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);

                                            MySqlDataReader reader23;
                                            iconnect12.Open();
                                            reader23 = command123.ExecuteReader();

                                            using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                                            {
                                                string imges = "SELECT image FROM employees WHERE EmployeeRfidTag =@EmployeeRfidTag";
                                                MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                                                cmdO.Parameters.AddWithValue("@EmployeeRfidTag", btnScan.Text);
                                                //cmdO.Parameters.AddWithValue("@image", empImg1.Image);

                                                MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                                                DataTable tbk = new DataTable();

                                                da.Fill(tbk);
                                                byte[] img = (byte[])tbk.Rows[0][0];

                                                MemoryStream ms1 = new MemoryStream(img);
                                                Imagebox.Image = Image.FromStream(ms1);

                                                da.Dispose();
                                            }
                                        }
                                        else
                                        {
                                            AutoClosingMessageBox.Show("Already Log :)", "Information : 8:15 - 9:00", 1500);
                                        }
                                        catchTime = DateTime.Now.ToString("hh:mm tt");
                                        IDrecognaizer.Text = "Hello";
                                        cvname.Text = reader["EmployeeName"].ToString();
                                        timed.Text = catchTime;
                                        Remarks.Text = remarks;
                                        info32.Text = info;
                                        //Notif.Visible = false;
                                        btnScan.Clear();
                                    }
                                }
                                //8:30 - 11:59
                                else if ((now > start830) && (now <= end12))
                                {
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                                    IDrecognaizer.Visible = true;
                                    tme.Visible = true;
                                    timed.Visible = true;
                                    rem.Visible = true;
                                    inff.Visible = true;
                                    //Notif.Visible = false;

                                    info = "Time in_1";
                                    remarks = "Late";

                                    using (MySqlConnection iconnectSelect1 = new MySqlConnection(MyDsql))
                                    {
                                        DateTime time = DateTime.Now;
                                        string selectquerry11 = "SELECT `EmployeeRfid`, `Date` FROM `attendance` WHERE EmployeeRfid = @rfid AND `attendance`.`Date` = '" + date + "' AND Am_In IS NULL";

                                        MySqlCommand commandSelect = new MySqlCommand(selectquerry11, iconnectSelect1);
                                        commandSelect.Parameters.AddWithValue("@rfid", btnScan.Text);

                                        MySqlDataReader readerSelect11;
                                        iconnectSelect1.Open();

                                        readerSelect11 = commandSelect.ExecuteReader();
                                        if (readerSelect11.Read())
                                        {
                                            MySqlConnection iconnect12 = new MySqlConnection(MyDsql);

                                            string insertquerry1 = "UPDATE `attendance` SET `Am_In` = current_timestamp(), remarks='Late' WHERE `attendance`.`Date` = '" + date + "' AND `attendance`.`EmployeeRfid` = @EmployeeRfid ";

                                            MySqlCommand command123 = new MySqlCommand(insertquerry1, iconnect12);
                                            command123.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);

                                            MySqlDataReader reader23;
                                            iconnect12.Open();
                                            reader23 = command123.ExecuteReader();

                                            using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                                            {
                                                string imges = "SELECT image FROM employees WHERE EmployeeRfidTag =@EmployeeRfidTag";
                                                MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                                                cmdO.Parameters.AddWithValue("@EmployeeRfidTag", btnScan.Text);
                                                //cmdO.Parameters.AddWithValue("@image", empImg1.Image);

                                                MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                                                DataTable tbk = new DataTable();

                                                da.Fill(tbk);
                                                byte[] img = (byte[])tbk.Rows[0][0];

                                                MemoryStream ms1 = new MemoryStream(img);
                                                Imagebox.Image = Image.FromStream(ms1);

                                                da.Dispose();
                                            }
                                        }
                                        else
                                        {
                                            AutoClosingMessageBox.Show("Already Log :)", "Information : 8:15 - 9:00", 1500);
                                        }
                                        catchTime = DateTime.Now.ToString("hh:mm tt");
                                        IDrecognaizer.Text = "Hello";
                                        cvname.Text = reader["EmployeeName"].ToString();
                                        timed.Text = catchTime;
                                        Remarks.Text = remarks;
                                        info32.Text = info;
                                        //Notif.Visible = false;
                                        btnScan.Clear();
                                    }
                                }
                                // 12:00 - 12:59
                                else if (dtime.Hour == 12 && dtime.Minute <= 59)
                                {
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                                    IDrecognaizer.Visible = true;
                                    tme.Visible = true;
                                    timed.Visible = true;
                                    rem.Visible = true;
                                    inff.Visible = true;
                                    //Notif.Visible = false;

                                    info = "Time out_2";
                                    remarks = "None";

                                    using (MySqlConnection iconnectSelect = new MySqlConnection(MyDsql))
                                    {
                                        DateTime time = DateTime.Now;
                                        string selectquerry1 = "SELECT `EmployeeRfid`, `Date` ,`Am_Out` FROM `attendance` WHERE EmployeeRfid = @EmployeeRfid AND Date= '" + date + "'  AND Am_Out IS  NULL";
                                        //string insquerry = "insert into ams_rfid.attendance(AttendanceID,EmployeeRfid,EmployeeName,Date,Am_In,Am_Out,Pm_In,Pm_Out,Remarks) values('','" + this.btnScan.Text + "','"+ reader["EmployeeName"]+ "','""','8:00:00', NULL,NULL,NULL, '"+ remarks +"')";

                                        MySqlCommand commandSelect = new MySqlCommand(selectquerry1, iconnectSelect);
                                        commandSelect.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);

                                        MySqlDataReader readerSelect;
                                        iconnectSelect.Open();
                                        DateTime catchTime1 = DateTime.Now;

                                        readerSelect = commandSelect.ExecuteReader();
                                        if (readerSelect.Read())
                                        {
                                            using (MySqlConnection pmsearchin = new MySqlConnection(MyDsql))
                                            {
                                                MySqlConnection iconnect12 = new MySqlConnection(MyDsql);

                                                string insertquerry1 = "UPDATE `attendance` SET `Am_Out` = current_timestamp() WHERE `attendance`.`Date` = '" + date + "' AND `attendance`.`EmployeeRfid` = @rfid";


                                                MySqlCommand command123 = new MySqlCommand(insertquerry1, iconnect12);
                                                command123.Parameters.AddWithValue("@rfid", btnScan.Text);
                                                MySqlDataReader reader23;
                                                iconnect12.Open();
                                                reader23 = command123.ExecuteReader();

                                                using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                                                {
                                                    string imges = "SELECT image FROM employees WHERE EmployeeRfidTag =@EmployeeRfidTag";
                                                    MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                                                    cmdO.Parameters.AddWithValue("@EmployeeRfidTag", btnScan.Text);

                                                    MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                                                    DataTable tbk = new DataTable();

                                                    da.Fill(tbk);
                                                    byte[] img = (byte[])tbk.Rows[0][0];

                                                    MemoryStream ms1 = new MemoryStream(img);
                                                    Imagebox.Image = Image.FromStream(ms1);

                                                    da.Dispose();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            using (MySqlConnection pmsearchinX = new MySqlConnection(MyDsql))
                                            {
                                                string tm = DateTime.Now.ToString("hh:mm:ss");
                                                DateTime dt1 = DateTime.Now;
                                                DateTime dt2 = dt1.AddMinutes(1);
                                                Console.WriteLine(dt2.Minute);
                                                string selectquerry1q2 = "select MINUTE(Am_Out) FROM `attendance` WHERE EmployeeRfid = @EmployeeRfid AND Date = '" + date + "'  AND Am_Out IS NOT NULL";
                                                MySqlCommand commandSelect1S = new MySqlCommand(selectquerry1q2, pmsearchinX);
                                                commandSelect1S.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);
                                                MySqlDataReader readerSelect1X;
                                                pmsearchinX.Open();
                                                DateTime catchTime12 = DateTime.Now;
                                                readerSelect1X = commandSelect1S.ExecuteReader();

                                                if (readerSelect1X.Read())
                                                {
                                                    //MessageBox.Show("GOOD");

                                                    if (dt2.Minute > (int)readerSelect1X["MINUTE(Am_Out)"] + 5)
                                                    {
                                                        {
                                                            MySqlConnection iconnect12 = new MySqlConnection(MyDsql);

                                                            string insertquerry1 = "UPDATE `attendance` SET `Pm_In` = current_timestamp() WHERE `attendance`.`Date` = '" + date + "' AND `attendance`.`EmployeeRfid` = @rfid";


                                                            MySqlCommand command123 = new MySqlCommand(insertquerry1, iconnect12);
                                                            command123.Parameters.AddWithValue("@rfid", btnScan.Text);
                                                            MySqlDataReader reader23;
                                                            iconnect12.Open();
                                                            reader23 = command123.ExecuteReader();

                                                            using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                                                            {
                                                                string imges = "SELECT image FROM employees WHERE EmployeeRfidTag =@EmployeeRfidTag";
                                                                MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                                                                cmdO.Parameters.AddWithValue("@EmployeeRfidTag", btnScan.Text);

                                                                MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                                                                DataTable tbk = new DataTable();

                                                                da.Fill(tbk);
                                                                byte[] img = (byte[])tbk.Rows[0][0];

                                                                MemoryStream ms1 = new MemoryStream(img);
                                                                Imagebox.Image = Image.FromStream(ms1);

                                                                da.Dispose();
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        AutoClosingMessageBox.Show("Time In Not Available: Comeback After 5 minutes. Thank you", "Info", 1500);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("ERROR");
                                                }
                                            }
                                        }
                                    }
                                    catchTime = DateTime.Now.ToString("hh:mm tt");
                                    IDrecognaizer.Text = "Hello";
                                    cvname.Text = reader["EmployeeName"].ToString();
                                    timed.Text = catchTime;
                                    Remarks.Text = remarks;
                                    info32.Text = info;
                                    btnScan.Clear();
                                }
                                // 1:00 - 1:15
                                else if (dtime.Hour == 13 && dtime.Minute <= 15)
                                {
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                                    dtime.Hour.ToString("hh");
                                    IDrecognaizer.Visible = true;
                                    tme.Visible = true;
                                    timed.Visible = true;
                                    rem.Visible = true;
                                    inff.Visible = true;
                                    //Notif.Visible = false;

                                    info = "Time In ";
                                    remarks = "None";

                                    using (MySqlConnection iconnectSelect = new MySqlConnection(MyDsql))
                                    {
                                        DateTime time = DateTime.Now;
                                        string selectquerry1 = "SELECT `EmployeeRfid`, `Date` ,`Pm_In` FROM `attendance` WHERE EmployeeRfid = @EmployeeRfid AND Date= '" + date + "' AND Pm_In IS NULL ";

                                        MySqlCommand commandSelect = new MySqlCommand(selectquerry1, iconnectSelect);
                                        commandSelect.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);
                                        MySqlDataReader readerSelect;
                                        iconnectSelect.Open();

                                        readerSelect = commandSelect.ExecuteReader();
                                        if (readerSelect.Read())
                                        {
                                            string dtime1 = DateTime.Now.ToString("hh:mm:ss");
                                            MySqlConnection iconnect12 = new MySqlConnection(MyDsql);

                                            string insertquerry1 = "UPDATE `attendance` SET `Pm_In` = '" + dtime1 + "' WHERE `attendance`.`Date` = '" + date + "' AND `attendance`.`EmployeeRfid`= @EmployeeRfid";


                                            MySqlCommand command123 = new MySqlCommand(insertquerry1, iconnect12);
                                            command123.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);

                                            MySqlDataReader reader23;
                                            iconnect12.Open();
                                            reader23 = command123.ExecuteReader();

                                            using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                                            {
                                                string imges = "SELECT image FROM employees WHERE EmployeeRfidTag =@EmployeeRfidTag";
                                                MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                                                cmdO.Parameters.AddWithValue("@EmployeeRfidTag", btnScan.Text);

                                                MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                                                DataTable tbk = new DataTable();

                                                da.Fill(tbk);
                                                byte[] img = (byte[])tbk.Rows[0][0];

                                                MemoryStream ms1 = new MemoryStream(img);
                                                Imagebox.Image = Image.FromStream(ms1);

                                                da.Dispose();
                                            }
                                        }
                                        else
                                        {
                                            AutoClosingMessageBox.Show("Already Log", "Information: 1:00 - 1:15", 2000);
                                        }
                                    }

                                    catchTime = DateTime.Now.ToString("hh:mm tt");
                                    IDrecognaizer.Text = "Hello";
                                    cvname.Text = reader["EmployeeName"].ToString();
                                    timed.Text = catchTime;
                                    Remarks.Text = remarks;
                                    info32.Text = info;
                                    btnScan.Clear();
                                }
                                //1:16 - 1:30
                                else if (dtime.Hour == 13 && dtime.Minute <= 30)
                                {
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                                    dtime.Hour.ToString("hh");
                                    IDrecognaizer.Visible = true;
                                    tme.Visible = true;
                                    timed.Visible = true;
                                    rem.Visible = true;
                                    inff.Visible = true;

                                    info = "Time In ";
                                    remarks = "None";

                                    using (MySqlConnection iconnectSelect = new MySqlConnection(MyDsql))
                                    {
                                        DateTime time = DateTime.Now;
                                        string selectquerry1 = "SELECT `EmployeeRfid`, `Date`  FROM `attendance` WHERE EmployeeRfid = @EmployeeRfid AND Date= '" + date + "' AND Pm_In IS NULL";

                                        MySqlCommand commandSelect = new MySqlCommand(selectquerry1, iconnectSelect);
                                        commandSelect.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);

                                        MySqlDataReader readerSelect;
                                        iconnectSelect.Open();

                                        readerSelect = commandSelect.ExecuteReader();
                                        if (readerSelect.Read())
                                        {
                                            string dtime1 = DateTime.Now.ToString("hh:mm:ss");
                                            MySqlConnection iconnect12 = new MySqlConnection(MyDsql);

                                            string insertquerry1 = "UPDATE `attendance` SET `Pm_In` = '" + dtime1 + "' WHERE `attendance`.`Date` = '" + date + "' AND `attendance`.`EmployeeRfid`= @EmployeeRfid";


                                            MySqlCommand command123 = new MySqlCommand(insertquerry1, iconnect12);
                                            command123.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);
                                            MySqlDataReader reader23;
                                            iconnect12.Open();
                                            reader23 = command123.ExecuteReader();

                                            using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                                            {
                                                string imges = "SELECT image FROM employees WHERE EmployeeRfidTag =@EmployeeRfidTag";
                                                MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                                                cmdO.Parameters.AddWithValue("@EmployeeRfidTag", btnScan.Text);

                                                MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                                                DataTable tbk = new DataTable();

                                                da.Fill(tbk);
                                                byte[] img = (byte[])tbk.Rows[0][0];

                                                MemoryStream ms1 = new MemoryStream(img);
                                                Imagebox.Image = Image.FromStream(ms1);

                                                da.Dispose();
                                            }
                                        }
                                        else
                                        {
                                            AutoClosingMessageBox.Show("Already Log", "Information: 1:15 - 1:30", 2000);
                                        }
                                    }

                                    catchTime = DateTime.Now.ToString("hh:mm tt");
                                    IDrecognaizer.Text = "Hello";
                                    cvname.Text = reader["EmployeeName"].ToString();
                                    timed.Text = catchTime;
                                    Remarks.Text = remarks;
                                    info32.Text = info;
                                    btnScan.Clear();
                                }
                                //1:30 > // 2:00 . 3:00 . 4:00
                                else if (dtime.Hour == 13 && dtime.Minute > 30 || dtime.Hour == 14 || dtime.Hour == 15 || dtime.Hour == 16)
                                {
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                                    dtime.Hour.ToString("hh");
                                    IDrecognaizer.Visible = true;
                                    tme.Visible = true;
                                    timed.Visible = true;
                                    rem.Visible = true;
                                    inff.Visible = true;

                                    info = "Time In ";
                                    remarks = "None";

                                    using (MySqlConnection iconnectSelect = new MySqlConnection(MyDsql))
                                    {
                                        DateTime time = DateTime.Now;
                                        string selectquerry1 = "SELECT `EmployeeRfid`, `Date`  FROM `attendance` WHERE EmployeeRfid = @EmployeeRfid AND Date= '" + date + "' AND Pm_In IS NULL";

                                        MySqlCommand commandSelect = new MySqlCommand(selectquerry1, iconnectSelect);
                                        commandSelect.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);

                                        MySqlDataReader readerSelect;
                                        iconnectSelect.Open();

                                        readerSelect = commandSelect.ExecuteReader();
                                        if (readerSelect.Read())
                                        {
                                            string dtime1 = DateTime.Now.ToString("hh:mm:ss");
                                            MySqlConnection iconnect12 = new MySqlConnection(MyDsql);

                                            string insertquerry1 = "UPDATE `attendance` SET `Pm_In` = '" + dtime1 + "' WHERE `attendance`.`Date` = '" + date + "' AND `attendance`.`EmployeeRfid`= @EmployeeRfid";


                                            MySqlCommand command123 = new MySqlCommand(insertquerry1, iconnect12);
                                            command123.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);
                                            MySqlDataReader reader23;
                                            iconnect12.Open();
                                            reader23 = command123.ExecuteReader();

                                            using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                                            {
                                                string imges = "SELECT image FROM employees WHERE EmployeeRfidTag =@EmployeeRfidTag";
                                                MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                                                cmdO.Parameters.AddWithValue("@EmployeeRfidTag", btnScan.Text);
                                                //cmdO.Parameters.AddWithValue("@image", empImg1.Image);

                                                MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                                                DataTable tbk = new DataTable();

                                                da.Fill(tbk);
                                                byte[] img = (byte[])tbk.Rows[0][0];

                                                MemoryStream ms1 = new MemoryStream(img);
                                                Imagebox.Image = Image.FromStream(ms1);

                                                da.Dispose();
                                            }
                                            catchTime = DateTime.Now.ToString("hh:mm tt");
                                            IDrecognaizer.Text = "Hello";
                                            cvname.Text = reader["EmployeeName"].ToString();
                                            timed.Text = catchTime;
                                            Remarks.Text = remarks;
                                            info32.Text = info;
                                            btnScan.Clear();
                                        }
                                        else
                                        {
                                            AutoClosingMessageBox.Show("Already Log", "Information: Late", 2000);
                                        }
                                    }
                                }
                                //6:00
                                else if (dtime.Hour == 17)
                                {
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                                    dtime.Hour.ToString("hh");
                                    IDrecognaizer.Visible = true;
                                    tme.Visible = true;
                                    timed.Visible = true;
                                    rem.Visible = true;
                                    inff.Visible = true;

                                    info = "Time Out ";
                                    remarks = "None";

                                    using (MySqlConnection iconnectSelectend = new MySqlConnection(MyDsql))
                                    {
                                        DateTime time = DateTime.Now;
                                        string selectquerry1end = "SELECT `EmployeeRfid`, `Date` ,`Pm_Out` FROM `attendance` WHERE EmployeeRfid = @EmployeeRfid AND Date= '" + date + "' AND Pm_Out IS NULL ";

                                        MySqlCommand commandSelectend = new MySqlCommand(selectquerry1end, iconnectSelectend);
                                        commandSelectend.Parameters.AddWithValue("@EmployeeRfid", btnScan.Text);
                                        MySqlDataReader readerSelectend;
                                        iconnectSelectend.Open();

                                        readerSelectend = commandSelectend.ExecuteReader();
                                        if (readerSelectend.Read())
                                        {
                                            string dtime1 = DateTime.Now.ToString("hh:mm:ss");
                                            MySqlConnection iconnect12 = new MySqlConnection(MyDsql);

                                            string insertquerry1 = "UPDATE `attendance` SET `Pm_Out` = '" + dtime1 + "' WHERE `attendance`.`Date` = '" + date + "' AND `attendance`.`EmployeeRfid`= @rfid";


                                            MySqlCommand command123 = new MySqlCommand(insertquerry1, iconnect12);
                                            command123.Parameters.AddWithValue("@rfid", btnScan.Text);

                                            MySqlDataReader reader23;
                                            iconnect12.Open();
                                            reader23 = command123.ExecuteReader();

                                            using (MySqlConnection conn12 = new MySqlConnection(MyDsql))
                                            {
                                                string imges = "SELECT image FROM employees WHERE EmployeeRfidTag =@EmployeeRfidTag";
                                                MySqlCommand cmdO = new MySqlCommand(imges, conn12);

                                                cmdO.Parameters.AddWithValue("@EmployeeRfidTag", btnScan.Text);

                                                MySqlDataAdapter da = new MySqlDataAdapter(cmdO);
                                                DataTable tbk = new DataTable();

                                                da.Fill(tbk);
                                                byte[] img = (byte[])tbk.Rows[0][0];

                                                MemoryStream ms1 = new MemoryStream(img);
                                                Imagebox.Image = Image.FromStream(ms1);

                                                da.Dispose();
                                            }
                                        }
                                        else
                                        {
                                            AutoClosingMessageBox.Show("Already Log", "Information: 5:00", 2000);
                                        }
                                    }
                                    catchTime = DateTime.Now.ToString("hh:mm tt");
                                    IDrecognaizer.Text = "Hello";
                                    cvname.Text = reader["EmployeeName"].ToString();
                                    timed.Text = catchTime;
                                    Remarks.Text = remarks;
                                    info32.Text = info;
                                    btnScan.Clear();
                                }
                                else
                                {
                                    AutoClosingMessageBox.Show("No Work", "Warning", 2000);
                                    btnScan.Clear();
                                }
                            }
                            else
                            {
                                AutoClosingMessageBox.Show("Rfid Not Registered. Please contact Administrator for Assistance", "Warning", 1500);
                            }
                        }
                    }
                }
                else
                {
                    AutoClosingMessageBox.Show("Image does not Initialized. Please consult your admin", "Warning", 2000);
                    btnScan.Clear();
                }
            }
        }

        #endregion aTTENDANCE
    }
}