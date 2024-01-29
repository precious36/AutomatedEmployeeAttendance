using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using EmployeeRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmployeeAttendance
{
    internal static class Program 
    {
        //again janine testing
        //comment
        //me againnnnnnnn
        /// <summary>
        /// The main entry point for the application..
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignXtraForm1());
        }
    }
}

