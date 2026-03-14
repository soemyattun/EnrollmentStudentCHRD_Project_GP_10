namespace EnrollmentStudentCHRD_Project_GP_10
{
    partial class StudentInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentInformation));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.labRollNo = new System.Windows.Forms.Label();
            this.labSemester = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.Label();
            this.txtRollNo = new System.Windows.Forms.TextBox();
            this.textBoxBatch = new System.Windows.Forms.TextBox();
            this.comboBoxSemester = new System.Windows.Forms.ComboBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtNRC = new System.Windows.Forms.TextBox();
            this.txtRaceReligion = new System.Windows.Forms.TextBox();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.txtFatherOccupation = new System.Windows.Forms.TextBox();
            this.txtFatherAddress = new System.Windows.Forms.TextBox();
            this.txtMotherAddress = new System.Windows.Forms.TextBox();
            this.txtMotherOccupation = new System.Windows.Forms.TextBox();
            this.txtMotherName = new System.Windows.Forms.TextBox();
            this.lblNRC = new System.Windows.Forms.Label();
            this.lblRaceReligion = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblParentName = new System.Windows.Forms.Label();
            this.lblFather = new System.Windows.Forms.Label();
            this.lblMother = new System.Windows.Forms.Label();
            this.lblHighSchool = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblExamCenter = new System.Windows.Forms.Label();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblUniversityDegree = new System.Windows.Forms.Label();
            this.lblDegree = new System.Windows.Forms.Label();
            this.labYear = new System.Windows.Forms.Label();
            this.lblUniversity = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.txtHSYear = new System.Windows.Forms.TextBox();
            this.txtExamCenter = new System.Windows.Forms.TextBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.txtDegreeType = new System.Windows.Forms.TextBox();
            this.txtUniversity = new System.Windows.Forms.TextBox();
            this.txtUniYear = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblRollNo = new System.Windows.Forms.Label();
            this.textBoxRoll = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(1013, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 50);
            this.button1.TabIndex = 147;
            this.button1.Text = "Check Student";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioFemale);
            this.groupBox1.Controls.Add(this.radioMale);
            this.groupBox1.Location = new System.Drawing.Point(529, 371);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 57);
            this.groupBox1.TabIndex = 146;
            this.groupBox1.TabStop = false;
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFemale.Location = new System.Drawing.Point(112, 20);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(93, 24);
            this.radioFemale.TabIndex = 1;
            this.radioFemale.TabStop = true;
            this.radioFemale.Text = "Female";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMale.Location = new System.Drawing.Point(6, 20);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(72, 24);
            this.radioMale.TabIndex = 0;
            this.radioMale.TabStop = true;
            this.radioMale.Text = "Male";
            this.radioMale.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 145;
            this.label1.Text = "Gender";
            // 
            // labRollNo
            // 
            this.labRollNo.AutoSize = true;
            this.labRollNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRollNo.Location = new System.Drawing.Point(158, 542);
            this.labRollNo.Name = "labRollNo";
            this.labRollNo.Size = new System.Drawing.Size(74, 25);
            this.labRollNo.TabIndex = 144;
            this.labRollNo.Text = "Roll No";
            // 
            // labSemester
            // 
            this.labSemester.AutoSize = true;
            this.labSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSemester.Location = new System.Drawing.Point(158, 480);
            this.labSemester.Name = "labSemester";
            this.labSemester.Size = new System.Drawing.Size(96, 25);
            this.labSemester.TabIndex = 143;
            this.labSemester.Text = "Semester";
            // 
            // txtBatch
            // 
            this.txtBatch.AutoSize = true;
            this.txtBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatch.Location = new System.Drawing.Point(158, 443);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(62, 25);
            this.txtBatch.TabIndex = 142;
            this.txtBatch.Text = "Batch";
            // 
            // txtRollNo
            // 
            this.txtRollNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRollNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRollNo.Location = new System.Drawing.Point(529, 527);
            this.txtRollNo.Multiline = true;
            this.txtRollNo.Name = "txtRollNo";
            this.txtRollNo.Size = new System.Drawing.Size(419, 37);
            this.txtRollNo.TabIndex = 141;
            // 
            // textBoxBatch
            // 
            this.textBoxBatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBatch.Location = new System.Drawing.Point(529, 437);
            this.textBoxBatch.Name = "textBoxBatch";
            this.textBoxBatch.Size = new System.Drawing.Size(419, 28);
            this.textBoxBatch.TabIndex = 140;
            // 
            // comboBoxSemester
            // 
            this.comboBoxSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSemester.FormattingEnabled = true;
            this.comboBoxSemester.Items.AddRange(new object[] {
            "\"1\", \"2\", \"3\""});
            this.comboBoxSemester.Location = new System.Drawing.Point(529, 482);
            this.comboBoxSemester.Name = "comboBoxSemester";
            this.comboBoxSemester.Size = new System.Drawing.Size(419, 30);
            this.comboBoxSemester.TabIndex = 139;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(158, 227);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 25);
            this.lblFullName.TabIndex = 96;
            this.lblFullName.Text = "Full Name";
            // 
            // txtFullName
            // 
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(529, 220);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(419, 28);
            this.txtFullName.TabIndex = 97;
            // 
            // txtNRC
            // 
            this.txtNRC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNRC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNRC.Location = new System.Drawing.Point(529, 255);
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(419, 28);
            this.txtNRC.TabIndex = 98;
            // 
            // txtRaceReligion
            // 
            this.txtRaceReligion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRaceReligion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaceReligion.Location = new System.Drawing.Point(529, 292);
            this.txtRaceReligion.Name = "txtRaceReligion";
            this.txtRaceReligion.Size = new System.Drawing.Size(419, 28);
            this.txtRaceReligion.TabIndex = 99;
            // 
            // txtFatherName
            // 
            this.txtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFatherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherName.Location = new System.Drawing.Point(527, 631);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(421, 28);
            this.txtFatherName.TabIndex = 100;
            // 
            // txtFatherOccupation
            // 
            this.txtFatherOccupation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFatherOccupation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherOccupation.Location = new System.Drawing.Point(527, 677);
            this.txtFatherOccupation.Name = "txtFatherOccupation";
            this.txtFatherOccupation.Size = new System.Drawing.Size(421, 28);
            this.txtFatherOccupation.TabIndex = 101;
            // 
            // txtFatherAddress
            // 
            this.txtFatherAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFatherAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherAddress.Location = new System.Drawing.Point(527, 723);
            this.txtFatherAddress.Name = "txtFatherAddress";
            this.txtFatherAddress.Size = new System.Drawing.Size(421, 28);
            this.txtFatherAddress.TabIndex = 102;
            // 
            // txtMotherAddress
            // 
            this.txtMotherAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotherAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotherAddress.Location = new System.Drawing.Point(1013, 725);
            this.txtMotherAddress.Name = "txtMotherAddress";
            this.txtMotherAddress.Size = new System.Drawing.Size(431, 28);
            this.txtMotherAddress.TabIndex = 104;
            // 
            // txtMotherOccupation
            // 
            this.txtMotherOccupation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotherOccupation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotherOccupation.Location = new System.Drawing.Point(1013, 674);
            this.txtMotherOccupation.Name = "txtMotherOccupation";
            this.txtMotherOccupation.Size = new System.Drawing.Size(431, 28);
            this.txtMotherOccupation.TabIndex = 105;
            // 
            // txtMotherName
            // 
            this.txtMotherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotherName.Location = new System.Drawing.Point(1013, 631);
            this.txtMotherName.Name = "txtMotherName";
            this.txtMotherName.Size = new System.Drawing.Size(431, 28);
            this.txtMotherName.TabIndex = 106;
            // 
            // lblNRC
            // 
            this.lblNRC.AutoSize = true;
            this.lblNRC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNRC.Location = new System.Drawing.Point(158, 264);
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Size = new System.Drawing.Size(335, 25);
            this.lblNRC.TabIndex = 107;
            this.lblNRC.Text = "National Registration Card(NRC) No.:";
            // 
            // lblRaceReligion
            // 
            this.lblRaceReligion.AutoSize = true;
            this.lblRaceReligion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceReligion.Location = new System.Drawing.Point(158, 305);
            this.lblRaceReligion.Name = "lblRaceReligion";
            this.lblRaceReligion.Size = new System.Drawing.Size(142, 25);
            this.lblRaceReligion.TabIndex = 108;
            this.lblRaceReligion.Text = "Race / Religion";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(158, 349);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(124, 25);
            this.lblDOB.TabIndex = 109;
            this.lblDOB.Text = "Date of Birth:";
            // 
            // lblParentName
            // 
            this.lblParentName.AutoSize = true;
            this.lblParentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParentName.Location = new System.Drawing.Point(158, 610);
            this.lblParentName.Name = "lblParentName";
            this.lblParentName.Size = new System.Drawing.Size(126, 25);
            this.lblParentName.TabIndex = 110;
            this.lblParentName.Text = "Parent Name";
            // 
            // lblFather
            // 
            this.lblFather.AutoSize = true;
            this.lblFather.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFather.Location = new System.Drawing.Point(525, 599);
            this.lblFather.Name = "lblFather";
            this.lblFather.Size = new System.Drawing.Size(68, 25);
            this.lblFather.TabIndex = 111;
            this.lblFather.Text = "Father";
            // 
            // lblMother
            // 
            this.lblMother.AutoSize = true;
            this.lblMother.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMother.Location = new System.Drawing.Point(1013, 599);
            this.lblMother.Name = "lblMother";
            this.lblMother.Size = new System.Drawing.Size(73, 25);
            this.lblMother.TabIndex = 112;
            this.lblMother.Text = "Mother";
            // 
            // lblHighSchool
            // 
            this.lblHighSchool.AutoSize = true;
            this.lblHighSchool.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighSchool.Location = new System.Drawing.Point(156, 803);
            this.lblHighSchool.Name = "lblHighSchool";
            this.lblHighSchool.Size = new System.Drawing.Size(129, 25);
            this.lblHighSchool.TabIndex = 113;
            this.lblHighSchool.Text = "Hight School:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(348, 845);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(59, 25);
            this.lblYear.TabIndex = 114;
            this.lblYear.Text = "Year:";
            // 
            // lblExamCenter
            // 
            this.lblExamCenter.AutoSize = true;
            this.lblExamCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamCenter.Location = new System.Drawing.Point(348, 894);
            this.lblExamCenter.Name = "lblExamCenter";
            this.lblExamCenter.Size = new System.Drawing.Size(126, 25);
            this.lblExamCenter.TabIndex = 115;
            this.lblExamCenter.Text = "Exam Center";
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegion.Location = new System.Drawing.Point(348, 933);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(125, 25);
            this.lblRegion.TabIndex = 116;
            this.lblRegion.Text = "Region/State";
            // 
            // lblUniversityDegree
            // 
            this.lblUniversityDegree.AutoSize = true;
            this.lblUniversityDegree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUniversityDegree.Location = new System.Drawing.Point(128, 1010);
            this.lblUniversityDegree.Name = "lblUniversityDegree";
            this.lblUniversityDegree.Size = new System.Drawing.Size(172, 25);
            this.lblUniversityDegree.TabIndex = 117;
            this.lblUniversityDegree.Text = "University Degree:";
            // 
            // lblDegree
            // 
            this.lblDegree.AutoSize = true;
            this.lblDegree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDegree.Location = new System.Drawing.Point(348, 1010);
            this.lblDegree.Name = "lblDegree";
            this.lblDegree.Size = new System.Drawing.Size(124, 25);
            this.lblDegree.TabIndex = 118;
            this.lblDegree.Text = "Degree type:";
            // 
            // labYear
            // 
            this.labYear.AutoSize = true;
            this.labYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labYear.Location = new System.Drawing.Point(348, 1056);
            this.labYear.Name = "labYear";
            this.labYear.Size = new System.Drawing.Size(53, 25);
            this.labYear.TabIndex = 119;
            this.labYear.Text = "Year";
            // 
            // lblUniversity
            // 
            this.lblUniversity.AutoSize = true;
            this.lblUniversity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUniversity.Location = new System.Drawing.Point(348, 1102);
            this.lblUniversity.Name = "lblUniversity";
            this.lblUniversity.Size = new System.Drawing.Size(97, 25);
            this.lblUniversity.TabIndex = 120;
            this.lblUniversity.Text = "University";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labName.Location = new System.Drawing.Point(348, 633);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(70, 25);
            this.labName.TabIndex = 121;
            this.labName.Text = "Name:";
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupation.Location = new System.Drawing.Point(348, 684);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(118, 25);
            this.lblOccupation.TabIndex = 122;
            this.lblOccupation.Text = "Occupation:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(348, 729);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(85, 25);
            this.lblAddress.TabIndex = 123;
            this.lblAddress.Text = "Address";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Location = new System.Drawing.Point(529, 332);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(419, 28);
            this.dtpDOB.TabIndex = 124;
            // 
            // txtHSYear
            // 
            this.txtHSYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHSYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSYear.Location = new System.Drawing.Point(527, 843);
            this.txtHSYear.Name = "txtHSYear";
            this.txtHSYear.Size = new System.Drawing.Size(421, 28);
            this.txtHSYear.TabIndex = 127;
            // 
            // txtExamCenter
            // 
            this.txtExamCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExamCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExamCenter.Location = new System.Drawing.Point(527, 889);
            this.txtExamCenter.Name = "txtExamCenter";
            this.txtExamCenter.Size = new System.Drawing.Size(421, 28);
            this.txtExamCenter.TabIndex = 128;
            // 
            // txtRegion
            // 
            this.txtRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegion.Location = new System.Drawing.Point(527, 935);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(421, 28);
            this.txtRegion.TabIndex = 129;
            // 
            // txtDegreeType
            // 
            this.txtDegreeType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDegreeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDegreeType.Location = new System.Drawing.Point(527, 1008);
            this.txtDegreeType.Name = "txtDegreeType";
            this.txtDegreeType.Size = new System.Drawing.Size(421, 28);
            this.txtDegreeType.TabIndex = 130;
            // 
            // txtUniversity
            // 
            this.txtUniversity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUniversity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUniversity.Location = new System.Drawing.Point(527, 1054);
            this.txtUniversity.Name = "txtUniversity";
            this.txtUniversity.Size = new System.Drawing.Size(421, 28);
            this.txtUniversity.TabIndex = 131;
            // 
            // txtUniYear
            // 
            this.txtUniYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUniYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUniYear.Location = new System.Drawing.Point(527, 1100);
            this.txtUniYear.Name = "txtUniYear";
            this.txtUniYear.Size = new System.Drawing.Size(421, 28);
            this.txtUniYear.TabIndex = 132;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(596, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(207, 26);
            this.label12.TabIndex = 133;
            this.label12.Text = "Yangon University";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(597, 172);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(217, 22);
            this.label20.TabIndex = 134;
            this.label20.Text = "Application for Permission";
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoto.Location = new System.Drawing.Point(1137, 181);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(57, 22);
            this.lblPhoto.TabIndex = 135;
            this.lblPhoto.Text = "Photo";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Teal;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.Transparent;
            this.btnSubmit.Location = new System.Drawing.Point(591, 1184);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(191, 56);
            this.btnSubmit.TabIndex = 136;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblRollNo
            // 
            this.lblRollNo.AutoSize = true;
            this.lblRollNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRollNo.Location = new System.Drawing.Point(348, 803);
            this.lblRollNo.Name = "lblRollNo";
            this.lblRollNo.Size = new System.Drawing.Size(184, 25);
            this.lblRollNo.TabIndex = 137;
            this.lblRollNo.Text = "High Scholl Roll No:";
            // 
            // textBoxRoll
            // 
            this.textBoxRoll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRoll.Location = new System.Drawing.Point(527, 797);
            this.textBoxRoll.Name = "textBoxRoll";
            this.textBoxRoll.Size = new System.Drawing.Size(421, 28);
            this.textBoxRoll.TabIndex = 138;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Teal;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Image = global::EnrollmentStudentCHRD_Project_GP_10.Properties.Resources.logout__1_;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1033, 1184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 56);
            this.button2.TabIndex = 148;
            this.button2.Text = "Log Out";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = global::EnrollmentStudentCHRD_Project_GP_10.Properties.Resources.user__3___1_;
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(1122, 83);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 126;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EnrollmentStudentCHRD_Project_GP_10.Properties.Resources.viber_image_2026_01_01_11_57_54_303;
            this.pictureBox1.Location = new System.Drawing.Point(657, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 125;
            this.pictureBox1.TabStop = false;
            // 
            // StudentInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1508, 1050);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labRollNo);
            this.Controls.Add(this.labSemester);
            this.Controls.Add(this.txtBatch);
            this.Controls.Add(this.txtRollNo);
            this.Controls.Add(this.textBoxBatch);
            this.Controls.Add(this.comboBoxSemester);
            this.Controls.Add(this.textBoxRoll);
            this.Controls.Add(this.lblRollNo);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtUniYear);
            this.Controls.Add(this.txtUniversity);
            this.Controls.Add(this.txtDegreeType);
            this.Controls.Add(this.txtRegion);
            this.Controls.Add(this.txtExamCenter);
            this.Controls.Add(this.txtHSYear);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblOccupation);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.lblUniversity);
            this.Controls.Add(this.labYear);
            this.Controls.Add(this.lblDegree);
            this.Controls.Add(this.lblUniversityDegree);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.lblExamCenter);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblHighSchool);
            this.Controls.Add(this.lblMother);
            this.Controls.Add(this.lblFather);
            this.Controls.Add(this.lblParentName);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lblRaceReligion);
            this.Controls.Add(this.lblNRC);
            this.Controls.Add(this.txtMotherName);
            this.Controls.Add(this.txtMotherOccupation);
            this.Controls.Add(this.txtMotherAddress);
            this.Controls.Add(this.txtFatherAddress);
            this.Controls.Add(this.txtFatherOccupation);
            this.Controls.Add(this.txtFatherName);
            this.Controls.Add(this.txtRaceReligion);
            this.Controls.Add(this.txtNRC);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "StudentInformation";
            this.Text = "StudentInformation";
            this.Load += new System.EventHandler(this.StudentInformation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioFemale;
        private System.Windows.Forms.RadioButton radioMale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labRollNo;
        private System.Windows.Forms.Label labSemester;
        private System.Windows.Forms.Label txtBatch;
        private System.Windows.Forms.TextBox txtRollNo;
        private System.Windows.Forms.TextBox textBoxBatch;
        private System.Windows.Forms.ComboBox comboBoxSemester;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtNRC;
        private System.Windows.Forms.TextBox txtRaceReligion;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.TextBox txtFatherOccupation;
        private System.Windows.Forms.TextBox txtFatherAddress;
        private System.Windows.Forms.TextBox txtMotherAddress;
        private System.Windows.Forms.TextBox txtMotherOccupation;
        private System.Windows.Forms.TextBox txtMotherName;
        private System.Windows.Forms.Label lblNRC;
        private System.Windows.Forms.Label lblRaceReligion;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblParentName;
        private System.Windows.Forms.Label lblFather;
        private System.Windows.Forms.Label lblMother;
        private System.Windows.Forms.Label lblHighSchool;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblExamCenter;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblUniversityDegree;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.Label labYear;
        private System.Windows.Forms.Label lblUniversity;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label lblOccupation;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.TextBox txtHSYear;
        private System.Windows.Forms.TextBox txtExamCenter;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox txtDegreeType;
        private System.Windows.Forms.TextBox txtUniversity;
        private System.Windows.Forms.TextBox txtUniYear;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblRollNo;
        private System.Windows.Forms.TextBox textBoxRoll;
        private System.Windows.Forms.Button button2;
    }
}