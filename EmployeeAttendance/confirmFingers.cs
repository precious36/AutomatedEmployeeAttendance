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

namespace EmployeeRegistration
{
    public partial class confirmFingers : DevExpress.XtraEditors.XtraForm
    {
        public confirmFingers()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void confirmForm_Load(object sender, EventArgs e)
        {
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            enrollFingers confirmForm = new enrollFingers();
            confirmForm.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            enrollFingers confirmForm = new enrollFingers();
            confirmForm.ShowDialog();
            this.Close();
        }
    }
}