using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeAttendance
{
    public partial class SignXtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public SignXtraForm1()
        {
            InitializeComponent();
        }
        public string Authentification(string username, string password)
        {
            employee_attendanceEntities2 db = new employee_attendanceEntities2();
            var matches = db.Administrators.Where(x => x.username == username && x.password == password);

            if (matches.Count() > 0)
            {
                // Create an instance of the AnotherForm
                registration_table regtable = new registration_table();

                // Show the AnotherForm
                regtable.Show();

                // If you want to hide the current form
                this.Hide();

                // Return a success message or status
                return "Authentication successful";
            }

            // Return a failure message or status
            return "Authentication failed";
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = usernameTextedBox.Text;
            String password = passwordTextBox.Text;

            Authentification(username, password);
        }
        
        private void SignXtraForm1_Load(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
                          
        }
    }
}