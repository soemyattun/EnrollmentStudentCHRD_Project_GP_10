namespace EnrollmentStudentCHRD_Project_GP_10
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labUniversity = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.btnMyanmar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labUniversity
            // 
            this.labUniversity.AutoSize = true;
            this.labUniversity.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUniversity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labUniversity.Location = new System.Drawing.Point(511, 178);
            this.labUniversity.Name = "labUniversity";
            this.labUniversity.Size = new System.Drawing.Size(246, 27);
            this.labUniversity.TabIndex = 15;
            this.labUniversity.Text = "University Of Yangon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(501, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 36);
            this.label3.TabIndex = 13;
            this.label3.Text = "Enrollment Student Of CHRD";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(481, 377);
            this.textPassword.MaxLength = 6;
            this.textPassword.Multiline = true;
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(365, 26);
            this.textPassword.TabIndex = 12;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(325, 377);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(89, 22);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Password";
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(481, 299);
            this.textUserName.Multiline = true;
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(365, 34);
            this.textUserName.TabIndex = 10;
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogIn.Location = new System.Drawing.Point(536, 482);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(186, 48);
            this.btnLogIn.TabIndex = 9;
            this.btnLogIn.Text = "LOG IN";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(325, 304);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(105, 22);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "User Name:";
            // 
            // btnEnglish
            // 
            this.btnEnglish.AutoSize = true;
            this.btnEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnglish.Image = global::EnrollmentStudentCHRD_Project_GP_10.Properties.Resources.united_states__1_;
            this.btnEnglish.Location = new System.Drawing.Point(1084, 93);
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(128, 46);
            this.btnEnglish.TabIndex = 17;
            this.btnEnglish.Text = "English";
            this.btnEnglish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnglish.UseVisualStyleBackColor = true;
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // btnMyanmar
            // 
            this.btnMyanmar.AutoSize = true;
            this.btnMyanmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyanmar.ForeColor = System.Drawing.Color.Black;
            this.btnMyanmar.Image = global::EnrollmentStudentCHRD_Project_GP_10.Properties.Resources.images__1_;
            this.btnMyanmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyanmar.Location = new System.Drawing.Point(1084, 33);
            this.btnMyanmar.Name = "btnMyanmar";
            this.btnMyanmar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMyanmar.Size = new System.Drawing.Size(128, 44);
            this.btnMyanmar.TabIndex = 16;
            this.btnMyanmar.Text = "Myanmar";
            this.btnMyanmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMyanmar.UseVisualStyleBackColor = true;
            this.btnMyanmar.Click += new System.EventHandler(this.btnMyanmar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::EnrollmentStudentCHRD_Project_GP_10.Properties.Resources.viber_image_2026_01_01_11_57_54_3031;
            this.pictureBox1.Location = new System.Drawing.Point(565, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1283, 659);
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.btnMyanmar);
            this.Controls.Add(this.labUniversity);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.textUserName);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.lblUsername);
            this.Name = "Form1";
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labUniversity;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnMyanmar;
        private System.Windows.Forms.Button btnEnglish;
    }
}

