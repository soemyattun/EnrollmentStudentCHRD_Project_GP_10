

using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO; // ဓာတ်ပုံသိမ်းရန် MemoryStream အတွက် လိုအပ်သည်
using System.Windows.Forms;

namespace EnrollmentStudentCHRD_Project_GP_10
{
    public partial class StudentInformation : Form
    {
        // Database Connection String
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Soe Myat Tun\Downloads\StudentInfo1.accdb";

        public StudentInformation()
        {
            InitializeComponent();
        }



        private bool ValidateForm()
        {
            // Roll No (Auto)
            if (string.IsNullOrWhiteSpace(txtRollNo.Text))
            {
                MessageBox.Show("Roll No is missing.", "Validation Error");
                return false;
            }

            // Full Name
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter Full Name.", "Validation Error");
                txtFullName.Focus();
                return false;
            }

            // NRC
            if (string.IsNullOrWhiteSpace(txtNRC.Text))
            {
                MessageBox.Show("Please enter NRC.", "Validation Error");
                txtNRC.Focus();
                return false;
            }

            // NRC Format (basic)
            if (txtNRC.Text.Length < 6)
            {
                MessageBox.Show("Invalid NRC format.", "Validation Error");
                txtNRC.Focus();
                return false;
            }

            // DOB (Age check)
            int age = DateTime.Today.Year - dtpDOB.Value.Year;

            // Birthday မရောက်သေးရင် 1 နှစ်လျှော့
            if (dtpDOB.Value.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            if (!radioMale.Checked && !radioFemale.Checked)
            {
                MessageBox.Show("Please select Gender.", "Validation Error");
                return false;
            }
            if (age < 18)
            {
                MessageBox.Show(
                    "Student must be at least 18 years old.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                dtpDOB.Focus();
                return false;
            }


            // Father
            if (string.IsNullOrWhiteSpace(txtFatherName.Text))
            {
                MessageBox.Show("Please enter Father Name.", "Validation Error");
                txtFatherName.Focus();
                return false;
            }

            // Mother
            if (string.IsNullOrWhiteSpace(txtMotherName.Text))
            {
                MessageBox.Show("Please enter Mother Name.", "Validation Error");
                txtMotherName.Focus();
                return false;
            }

            // HS Year
            if (!int.TryParse(txtHSYear.Text, out int hsYear) || hsYear < 1990 || hsYear > DateTime.Now.Year)
            {
                MessageBox.Show("Invalid High School Year.", "Validation Error");
                txtHSYear.Focus();
                return false;
            }

            // University Year
            if (string.IsNullOrWhiteSpace(txtUniYear.Text))
            {
                MessageBox.Show("University Year is required.", "Validation Error");
                txtUniYear.Focus();
                return false;
            }

            // Semester
            if (comboBoxSemester.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Semester.", "Validation Error");
                comboBoxSemester.Focus();
                return false;
            }

            // Batch
            if (string.IsNullOrWhiteSpace(textBoxBatch.Text))
            {
                MessageBox.Show("Please enter Batch.", "Validation Error");
                textBoxBatch.Focus();
                return false;
            }

            // Photo
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Please choose a photo.", "Validation Error");
                return false;
            }

            // Duplicate Roll No
            //if (IsDuplicateRollNo(txtRollNo.Text))
            //{
            //    MessageBox.Show("Roll No already exists.", "Validation Error");
            //    return false;
            //}

            return true; // ✅ All passed
        }


        private void StudentInformation_Load(object sender, EventArgs e)
        {
            LocalizationService.ApplyLanguage(
                this,
                LanguageState.CurrentLanguage
            );

            comboBoxSemester.Items.Clear();
            comboBoxSemester.Items.Add(1);
            comboBoxSemester.Items.Add(2);
            comboBoxSemester.Items.Add(3);
            comboBoxSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSemester.SelectedItem = 1;

            // Auto-generate Roll Number
            txtRollNo.Text = GenerateRollNo();
            txtRollNo.ReadOnly = false;
            dtpDOB.MaxDate = DateTime.Today.AddYears(-18);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // ဓာတ်ပုံကို PictureBox ထဲသို့ ထည့်ခြင်း
                pictureBox2.Image = Image.FromFile(ofd.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom; // ဓာတ်ပုံကို အကွက်ထဲ အံကိုက်ဖြစ်စေရန်
            }
        }

        private void UserInformation_Shown(object sender, EventArgs e)
        {
            // Form ပြသချိန်တွင် နောက်ခံအရောင် ပြောင်းလဲခြင်း
            this.BackColor = Color.WhiteSmoke;
        }

        // Image ကို Database သိမ်းနိုင်ရန် Byte Array အဖြစ် ပြောင်းလဲပေးသော Method
        private byte[] ImageToByteArray(Image img)
        {
            if (img == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }





        //private string GenerateRollNo()
        //{
        //    string batch = textBoxBatch.Text.Trim(); // သင် input ထည့်ထားတဲ့ batch

        //    if (string.IsNullOrEmpty(batch))
        //    {
        //        MessageBox.Show("Please enter Batch first!");
        //        return "";
        //    }

        //    try
        //    {
        //        using (OleDbConnection con = new OleDbConnection(conStr))
        //        {
        //            con.Open();

        //            // Current batch အတွက် နောက်ဆုံး RollNo ရှာ
        //            string query = "SELECT MAX(RollNo) FROM UserInfotable WHERE Batch = ?";
        //            using (OleDbCommand cmd = new OleDbCommand(query, con))
        //            {
        //                cmd.Parameters.AddWithValue("?", batch);
        //                object result = cmd.ExecuteScalar();

        //                int lastNum = 0;

        //                if (result != DBNull.Value && result != null)
        //                {
        //                    string lastRoll = result.ToString(); // eg: COM-5
        //                    if (lastRoll.Contains("-"))
        //                    {
        //                        string[] parts = lastRoll.Split('-');
        //                        if (int.TryParse(parts[1], out int n))
        //                        {
        //                            lastNum = n;
        //                        }
        //                    }
        //                }

        //                int nextNum = lastNum + 1;
        //                return $"COM-{nextNum}";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error generating Roll Number: " + ex.Message);
        //    }

        //    return "COM-1"; // default
        //}

        //private string GenerateRollNo()
        //{
        //    // Auto-generate COM-XX roll number
        //    try
        //    {
        //        string batch = textBoxBatch.Text.Trim();
        //        if (string.IsNullOrEmpty(batch))
        //            batch = "COM";

        //        using (OleDbConnection con = new OleDbConnection(conStr))
        //        {
        //            con.Open();
        //            string query = "SELECT Nz(MAX(CInt(Mid(RollNo,5))),0)+1 FROM UserInfotable WHERE RollNo LIKE ?";
        //            using (OleDbCommand cmd = new OleDbCommand(query, con))
        //            {
        //                cmd.Parameters.AddWithValue("?", batch + "-%");
        //                int nextNum = Convert.ToInt32(cmd.ExecuteScalar());
        //                return $"{batch}-{nextNum:D2}";
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        return "COM-01";
        //    }
        //}


        private string GenerateRollNo()
        {
            try
            {
                string batch = textBoxBatch.Text.Trim();
                if (string.IsNullOrEmpty(batch))
                    batch = "COM";

                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    con.Open();
                    // Access မှာ RollNo format = "COM-01", "COM-02"...
                    string query = "SELECT MAX(CInt(Mid(RollNo, ?))) FROM UserInfotable WHERE RollNo LIKE ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        // Mid() start = batch.Length + 2
                        // example: COM-01 → number starts at position 5
                        int midStart = batch.Length + 2;

                        cmd.Parameters.AddWithValue("@p1", midStart);
                        cmd.Parameters.AddWithValue("@p2", batch + "-%");

                        object result = cmd.ExecuteScalar();
                        int nextNum = (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;

                        return $"{batch}-{nextNum:D2}";
                    }
                }
            }
            catch
            {
                return "COM-01";
            }
        }
        //        private void btnSubmit_Click(object sender, EventArgs e)
        //        {
        //            if (!ValidateForm()) return;

        //            string gender = "";
        //            if (radioMale.Checked) gender = "Male";
        //            else if (radioFemale.Checked) gender = "Female";

        //            try
        //            {
        //                using (OleDbConnection con = new OleDbConnection(conStr))
        //                {
        //                    string query = @"INSERT INTO UserInfotable
        //(RollNo, HSRollNo, FullName, NRC, RaceReligion, DOB, Gender,
        // FatherName, FatherOccupation, FatherAddress,
        // MotherName, MotherOccupation, MotherAddress,
        // HSYear, ExamCenter, Region,
        // DegreeType, University, UniYear, Semester, Batch, Photo)
        //VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

        //                    using (OleDbCommand cmd = new OleDbCommand(query, con))
        //                    {
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtRollNo.Text.Trim();

        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = textBoxRoll.Text;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtFullName.Text;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtNRC.Text;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtRaceReligion.Text;
        //                        cmd.Parameters.Add("?", OleDbType.Date).Value = dtpDOB.Value.Date;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = gender;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtFatherName.Text;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtFatherOccupation.Text;
        //                        cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = txtFatherAddress.Text;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtMotherName.Text;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtMotherOccupation.Text;
        //                        cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = txtMotherAddress.Text;
        //                        cmd.Parameters.Add("?", OleDbType.Integer).Value = int.TryParse(txtHSYear.Text, out int hs) ? hs : (object)DBNull.Value;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtExamCenter.Text;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtRegion.Text;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtDegreeType.Text;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtUniversity.Text;
        //                        cmd.Parameters.Add("?", OleDbType.Integer).Value = int.TryParse(txtUniYear.Text, out int uy) ? uy : (object)DBNull.Value;
        //                        cmd.Parameters.Add("?", OleDbType.Integer).Value = comboBoxSemester.SelectedItem != null ? int.Parse(comboBoxSemester.SelectedItem.ToString()) : (object)DBNull.Value;
        //                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = textBoxBatch.Text;

        //                        byte[] photoData = ImageToByteArray(pictureBox2.Image);
        //                        if (photoData != null) cmd.Parameters.Add("?", OleDbType.Binary).Value = photoData;
        //                        else cmd.Parameters.Add("?", OleDbType.Binary).Value = DBNull.Value;

        //                        con.Open();
        //                        cmd.ExecuteNonQuery();
        //                        con.Close();
        //                    }
        //                }

        //                MessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                this.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBoxSemester_TextChanged(object sender, EventArgs e)
        {
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBatch.Text) || string.IsNullOrWhiteSpace(txtRollNo.Text))
            {
                MessageBox.Show("Please enter Batch and Roll No.");
                return;
            }

            DataRow row = GetStudentData(textBoxBatch.Text.Trim(), txtRollNo.Text.Trim());

            if (row == null)
            {
                comboBoxSemester.SelectedItem = 1;
                txtFullName.ReadOnly = false;
                txtNRC.ReadOnly = false;
                txtRaceReligion.ReadOnly = false;
                dtpDOB.Enabled = true;
                radioMale.Enabled = true;
                radioFemale.Enabled = true;
                txtFatherName.ReadOnly = false;
                txtFatherOccupation.ReadOnly = false;
                txtMotherName.ReadOnly = false;
                txtMotherOccupation.ReadOnly = false;
                txtFatherAddress.ReadOnly = false;
                txtMotherAddress.ReadOnly = false;
                MessageBox.Show("Semester 1 student → enter new info");
                return;
            }

            BindStudentData(row);
            int currentSemester = Convert.ToInt32(row["Semester"]);

            if (currentSemester == 1)
            {
                comboBoxSemester.SelectedItem = 2;
                LockPersonalInfo();
                UnlockAddressOnly();
                MessageBox.Show("Semester 2 → only address can be edited");
            }
            else if (currentSemester == 2)
            {
                comboBoxSemester.SelectedItem = 3;
                LockPersonalInfo();
                UnlockAddressOnly();
                MessageBox.Show("Semester 3 → only address can be edited");
            }
            else
            {
                MessageBox.Show("Student already completed Semester 3!");
                btnSubmit.Enabled = false;
                comboBoxSemester.SelectedItem = 3;
            }

            comboBoxSemester.Enabled = false;
        }


        private DataRow GetStudentData(string batch, string rollNo)
        {
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                string query = @"SELECT TOP 1 * FROM UserInfotable 
                                 WHERE Batch = ? AND RollNo = ? 
                                 ORDER BY Semester DESC";
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("?", batch);
                cmd.Parameters.AddWithValue("?", rollNo);
                DataTable dt = new DataTable();
                new OleDbDataAdapter(cmd).Fill(dt);
                if (dt.Rows.Count == 0) return null;
                return dt.Rows[0];
            }
        }
      
        private void UnlockAddressOnly()
        {
            txtFatherAddress.ReadOnly = false;
            txtMotherAddress.ReadOnly = false;
        }
        private void LockPersonalInfo()
        {
            txtFullName.ReadOnly = true;
            txtNRC.ReadOnly = true;
            txtRaceReligion.ReadOnly = true;
            dtpDOB.Enabled = false;
            radioMale.Enabled = true;
            radioFemale.Enabled = true;
            txtFatherName.ReadOnly = true;
            txtFatherOccupation.ReadOnly = true;
            txtMotherName.ReadOnly = true;
            txtMotherOccupation.ReadOnly = true;
        }
        //private void BindStudentData(DataRow row)
        //{
        //    txtFullName.Text = row["FullName"].ToString();
        //    txtNRC.Text = row["NRC"].ToString();
        //    txtRaceReligion.Text = row["RaceReligion"].ToString();
        //    if (row["DOB"] != DBNull.Value) dtpDOB.Value = Convert.ToDateTime(row["DOB"]);
        //    txtFatherName.Text = row["FatherName"].ToString();
        //    txtFatherOccupation.Text = row["FatherOccupation"].ToString();
        //    txtFatherAddress.Text = row["FatherAddress"].ToString();
        //    txtMotherName.Text = row["MotherName"].ToString();
        //    txtMotherOccupation.Text = row["MotherOccupation"].ToString();
        //    txtMotherAddress.Text = row["MotherAddress"].ToString();
        //    txtExamCenter.Text = row["ExamCenter"].ToString();
        //    txtRegion.Text = row["Region"].ToString();
        //    txtDegreeType.Text = row["DegreeType"].ToString();
        //    txtUniversity.Text = row["University"].ToString();

        //    string gender = row["Gender"].ToString();
        //    if (gender == "Male") radioMale.Checked = true;
        //    else if (gender == "Female") radioFemale.Checked = true;

        //    if (row["Photo"] != DBNull.Value)
        //    {
        //        byte[] imgBytes = (byte[])row["Photo"];
        //        using (MemoryStream ms = new MemoryStream(imgBytes))
        //        {
        //            pictureBox2.Image = Image.FromStream(ms);
        //            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        //        }
        //    }
        //}
        // Image ကို MemoryStream နဲ့ load လုပ်ခြင်း + Bitmap copy
        private void BindStudentData(DataRow row)
        {
            txtFullName.Text = row["FullName"].ToString();
            txtNRC.Text = row["NRC"].ToString();
            txtRaceReligion.Text = row["RaceReligion"].ToString();
            if (row["DOB"] != DBNull.Value) dtpDOB.Value = Convert.ToDateTime(row["DOB"]);
            txtFatherName.Text = row["FatherName"].ToString();
            txtFatherOccupation.Text = row["FatherOccupation"].ToString();
            txtFatherAddress.Text = row["FatherAddress"].ToString();
            txtMotherName.Text = row["MotherName"].ToString();
            txtMotherOccupation.Text = row["MotherOccupation"].ToString();
            txtMotherAddress.Text = row["MotherAddress"].ToString();
            txtExamCenter.Text = row["ExamCenter"].ToString();
            txtRegion.Text = row["Region"].ToString();
            txtDegreeType.Text = row["DegreeType"].ToString();
            txtUniversity.Text = row["University"].ToString();

            string gender = row["Gender"].ToString();
            if (gender == "Male") radioMale.Checked = true;
            else if (gender == "Female") radioFemale.Checked = true;

            if (row["Photo"] != DBNull.Value)
            {
                byte[] imgBytes = (byte[])row["Photo"];
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    // Original image load + Bitmap copy to avoid file lock
                    using (Image original = Image.FromStream(ms))
                    {
                        pictureBox2.Image = new Bitmap(original);
                        pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
        }

        // Submit Button အတွက် fix: semester 1 → 2 image path save
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string gender = radioMale.Checked ? "Male" : "Female";

            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    con.Open();

                    // Check if student already exists
                    DataRow existingRow = GetStudentData(textBoxBatch.Text.Trim(), txtRollNo.Text.Trim());
                    int semester = comboBoxSemester.SelectedItem != null ? int.Parse(comboBoxSemester.SelectedItem.ToString()) : 1;

                    string photoPath = null;
                    if (pictureBox2.Image != null)
                    {
                        // Semester-specific unique path
                        string baseDir = @"C:\StudentPhotos"; // folder must exist
                        if (!Directory.Exists(baseDir)) Directory.CreateDirectory(baseDir);

                        photoPath = Path.Combine(baseDir, $"{textBoxBatch.Text.Trim()}_{txtRollNo.Text.Trim()}_S{semester}.jpg");
                        using (Bitmap bmp = new Bitmap(pictureBox2.Image))
                        {
                            bmp.Save(photoPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                    }

                    if (existingRow != null)
                    {
                        // Existing student → update semester only, update photo path if changed
                        string updateQuery = @"UPDATE UserInfotable 
                                       SET Semester = ?, Photo = ?
                                       WHERE Batch = ? AND RollNo = ?";
                        using (OleDbCommand cmd = new OleDbCommand(updateQuery, con))
                        {
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = semester;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = photoPath ?? (object)DBNull.Value;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = textBoxBatch.Text.Trim();
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtRollNo.Text.Trim();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // New student → insert
                        string insertQuery = @"INSERT INTO UserInfotable
(RollNo, HSRollNo, FullName, NRC, RaceReligion, DOB, Gender,
 FatherName, FatherOccupation, FatherAddress,
 MotherName, MotherOccupation, MotherAddress,
 HSYear, ExamCenter, Region,
 DegreeType, University, UniYear, Semester, Batch, Photo)
VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                        using (OleDbCommand cmd = new OleDbCommand(insertQuery, con))
                        {
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtRollNo.Text.Trim();
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = textBoxRoll.Text;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtFullName.Text;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtNRC.Text;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtRaceReligion.Text;
                            cmd.Parameters.Add("?", OleDbType.Date).Value = dtpDOB.Value.Date;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = gender;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtFatherName.Text;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtFatherOccupation.Text;
                            cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = txtFatherAddress.Text;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtMotherName.Text;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtMotherOccupation.Text;
                            cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = txtMotherAddress.Text;
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = int.TryParse(txtHSYear.Text, out int hs) ? hs : (object)DBNull.Value;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtExamCenter.Text;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtRegion.Text;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtDegreeType.Text;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtUniversity.Text;
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = int.TryParse(txtUniYear.Text, out int uy) ? uy : (object)DBNull.Value;
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = semester;
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = textBoxBatch.Text.Trim();
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = photoPath ?? (object)DBNull.Value;

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
