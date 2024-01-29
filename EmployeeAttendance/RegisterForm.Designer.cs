using System.Windows.Forms;
using System;

namespace EmployeeAttendance

{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void button1_Click(object sender, EventArgs e)

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


            // If all checks pass, proceed to the next page or perform any other action
            // Add your code here to navigate to the next page or perform other actions.
            // For example:
            // NextPageForm nextPage = new NextPageForm();
            // nextPage.Show();
        }


        private bool ValidateForm()
        {
            // Perform validation checks for all fields
            if (string.IsNullOrWhiteSpace(firstNameTextbox.Text))
            {
                MessageBox.Show("First Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Add more validation checks for other fields...

            return true; // All checks passed
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.emailTextbox = new System.Windows.Forms.RichTextBox();
            this.usernameTextbox = new System.Windows.Forms.RichTextBox();
            this.departmentTextboxd = new System.Windows.Forms.RichTextBox();
            this.stationTextbox = new System.Windows.Forms.RichTextBox();
            this.lastnameTextbox = new System.Windows.Forms.RichTextBox();
            this.firstNameTextbox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.emailTextbox);
            this.panel1.Controls.Add(this.usernameTextbox);
            this.panel1.Controls.Add(this.departmentTextboxd);
            this.panel1.Controls.Add(this.stationTextbox);
            this.panel1.Controls.Add(this.lastnameTextbox);
            this.panel1.Controls.Add(this.firstNameTextbox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(146, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 503);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Yu Gothic", 17F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Location = new System.Drawing.Point(92, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 58);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EmployeeAttendance.Properties.Resources.MRA_logo;
            this.pictureBox1.Location = new System.Drawing.Point(140, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(38, 381);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(249, 27);
            this.emailTextbox.TabIndex = 11;
            this.emailTextbox.Text = "";
            this.emailTextbox.TextChanged += new System.EventHandler(this.richTextBox6_TextChanged);
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(38, 315);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(249, 27);
            this.usernameTextbox.TabIndex = 10;
            this.usernameTextbox.Text = "";
            // 
            // departmentTextboxd
            // 
            this.departmentTextboxd.Location = new System.Drawing.Point(38, 266);
            this.departmentTextboxd.Name = "departmentTextboxd";
            this.departmentTextboxd.Size = new System.Drawing.Size(249, 27);
            this.departmentTextboxd.TabIndex = 9;
            this.departmentTextboxd.Text = "";
            this.departmentTextboxd.TextChanged += new System.EventHandler(this.richTextBox4_TextChanged);
            // 
            // stationTextbox
            // 
            this.stationTextbox.Location = new System.Drawing.Point(38, 200);
            this.stationTextbox.Name = "stationTextbox";
            this.stationTextbox.Size = new System.Drawing.Size(249, 27);
            this.stationTextbox.TabIndex = 8;
            this.stationTextbox.Text = "";
            // 
            // lastnameTextbox
            // 
            this.lastnameTextbox.Location = new System.Drawing.Point(38, 151);
            this.lastnameTextbox.Name = "lastnameTextbox";
            this.lastnameTextbox.Size = new System.Drawing.Size(249, 27);
            this.lastnameTextbox.TabIndex = 7;
            this.lastnameTextbox.Text = "";
            // 
            // firstNameTextbox
            // 
            this.firstNameTextbox.Location = new System.Drawing.Point(38, 97);
            this.firstNameTextbox.Name = "firstNameTextbox";
            this.firstNameTextbox.Size = new System.Drawing.Size(249, 27);
            this.firstNameTextbox.TabIndex = 6;
            this.firstNameTextbox.Text = "";
            this.firstNameTextbox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(35, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(35, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(35, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(35, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Station";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(35, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lastname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(35, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "FirstName";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 623);
            this.Controls.Add(this.panel1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox emailTextbox;
        private System.Windows.Forms.RichTextBox usernameTextbox;
        private System.Windows.Forms.RichTextBox departmentTextboxd;
        private System.Windows.Forms.RichTextBox stationTextbox;
        private System.Windows.Forms.RichTextBox lastnameTextbox;
        private System.Windows.Forms.RichTextBox firstNameTextbox;
        private System.Windows.Forms.Button button1;
    }
}


