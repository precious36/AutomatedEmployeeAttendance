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
    public partial class RegisterForm : DevExpress.XtraEditors.XtraForm
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Check if all fields are filled
            if (string.IsNullOrWhiteSpace(firstNameTextbox.Text) ||
                string.IsNullOrWhiteSpace(lastnameTextbox.Text) ||
                string.IsNullOrWhiteSpace(stationTextbox.Text) ||
                string.IsNullOrWhiteSpace(departmentTextboxd.Text) ||
                string.IsNullOrWhiteSpace(usernameTextbox.Text) ||
                string.IsNullOrWhiteSpace(emailTextbox.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the email has the correct domain
            string email = emailTextbox.Text.Trim();
            if (!email.EndsWith("@mra.mw"))
            {
                MessageBox.Show("Invalid email domain. Please use an email with '@mra.mw'.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //adding users

            String firstnmae = firstNameTextbox.Text.Trim();
            String lastnmae = lastnameTextbox.Text.Trim();
            String username = usernameTextbox.Text.Trim();
        String department = departmentTextboxd.Text.Trim();
         //   String station = stationTextboxd.Text.Trim();

            registration(firstnmae, lastnmae, username, department); 

        }

        public string registration(string firstname, string lastname, string username, string department )
        {
            employee_attendanceEntities2 db = new employee_attendanceEntities2();

            // Check if the user already exists
            var existingUser = db.EmployeeDetails.FirstOrDefault(x => x.username == username);

            if (existingUser != null)
            {
                return "User already exists.";
            }

            // Create a new user
            var newUser = new EmployeeDetail
            {
                firstname = firstname,
                lastname = lastname,
                username = username,
             //   email = email,
                department = department,
              //  station = station
            };

            // Add the user to the database
            db.EmployeeDetails.Add(newUser);
            _ = db.SaveChanges();

            return "User registered successfully.";
        }



        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}