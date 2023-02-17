﻿using System;
using System.Windows.Forms;

namespace AMS_RFID_V2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new EmployeeAttendance());
            //Application.Run(new MainPage());
            Application.Run(new LoginForm());
            //Application.Run(new SupportingWinform());
            //Application.Run(new EditEmployeeForm());
            //Application.Run(new SupportingWinform());
        }
    }
}