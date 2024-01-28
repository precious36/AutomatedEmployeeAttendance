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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the AnotherForm
           // homepageForm1 anotherForm = new homepageForm1();

            // Show the AnotherForm
          //  anotherForm.Show();

            // If you want to hide the current form
            this.Hide();

        }

        private void SignXtraForm1_Load(object sender, EventArgs e)
        {

        }
    }
}