using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace EmployeeAttendance

{
    public partial class registration_table : DevExpress.XtraEditors.XtraForm
    {
        public registration_table()
        {
            InitializeComponent();
          //  uSERINFOBindingSource.DataSource = new USER_INFO();
        }

        private void registration_table_Load(object sender, EventArgs e)
        {
            // Subscribe to the Resize event of the form
            this.Resize += registration_table_Resize;

            // Call the resizing logic initially
            AdjustPanelSize();

            // Set the initial panel width to be 10 less than the form width
            panel1.Width = Math.Max(ClientSize.Width - 300, 0);

         //   var db = new persornalEntities();
         //  dataGridView1.DataSource = db.USER_INFO.ToList();

            // Set DataGridView's Dock property to Fill
            dataGridView1.Dock = DockStyle.Fill;

            // Remove table borders
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Enable both horizontal and vertical scroll bars
            dataGridView1.ScrollBars = ScrollBars.Both;

            // Ensure columns fill the available space
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set the AutoSizeMode of the last column to Fill
          //  dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Set RowHeadersVisible to false
            dataGridView1.RowHeadersVisible = false;

            // Disable visual styles for headers
            dataGridView1.EnableHeadersVisualStyles = false;

            // Anchor the button to the top-right corner
            simpleButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Set the initial panel width to be 100 less than the form width
            panel1.Width = Math.Max(ClientSize.Width - 300, 0);

            // Set the initial panel height to be 100 less than the form height
            panel1.Height = Math.Max(ClientSize.Height - 200, 0);

            // Set the initial DataGridView size to be 100 less than the panel's size
            dataGridView1.Size = new Size(panel1.Width - SystemInformation.VerticalScrollBarWidth - dataGridView1.Left * 2, panel1.Height - dataGridView1.Top * 2);
            // Set border-radius for simpleButton1
            simpleButton1.Appearance.BorderColor = Color.FromArgb(0, 255, 255, 255); // Set the same color as your form background
            simpleButton1.Appearance.Options.UseBorderColor = true;
            simpleButton1.AppearanceHovered.BackColor = Color.FromArgb(50, 255, 255, 255); // Set the color when the button is hovered
            simpleButton1.AppearanceHovered.Options.UseBackColor = true;
            simpleButton1.AppearancePressed.BackColor = Color.FromArgb(100, 255, 255, 255); // Set the color when the button is pressed
            simpleButton1.AppearancePressed.Options.UseBackColor = true;
            simpleButton1.Appearance.Options.UseBackColor = true;
        }

        private void registration_table_Resize(object sender, EventArgs e)
        {
            // Call the resizing logic whenever the form is resized
            AdjustPanelSize();

            // Set the panel width to be 10 less than the form width
            panel1.Width = Math.Max(ClientSize.Width - 300, 0);
            dataGridView1.Size = new Size(panel1.Width - SystemInformation.VerticalScrollBarWidth - dataGridView1.Left * 2, panel1.Height - dataGridView1.Top * 2);

            // Adjust the DataGridView size when the form is resized
            dataGridView1.Size = new Size(panel1.Width - SystemInformation.VerticalScrollBarWidth - dataGridView1.Left * 2, panel1.Height - dataGridView1.Top * 2);

            // Calculate the new width for each column
            int totalWidth = dataGridView1.Columns.Cast<DataGridViewColumn>().Sum(col => col.Width);
            double ratio = (double)dataGridView1.Width / totalWidth;

            // Adjust the width of each column proportionally
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = (int)(column.Width * ratio);
            }

            // Ensure the last column is fully visible
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width += dataGridView1.Width - dataGridView1.Columns.Cast<DataGridViewColumn>().Sum(col => col.Width);
        }

        private void AdjustPanelSize()
        {
            // Set the panel size based on the form's client size
          panel1.Size = new Size(ClientSize.Width, ClientSize.Height);
        }
        private void sidePanel1_Click(object sender, EventArgs e)
        {
            // Add your click event handling logic here
        }

        private void uSERINFOBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Assuming you have another form named AnotherForm
          //  registration_form regForm = new registration_form();

            // Show the new form
          //  regForm.Show();

            // Optionally, you can hide the current form if needed
           this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
