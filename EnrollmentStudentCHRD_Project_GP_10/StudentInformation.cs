


using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EnrollmentStudentCHRD_Project_GP_10
{
    public partial class StudentInformation : Form
    {
        // Connection string
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Soe Myat Tun\Downloads\StudentInfo1.accdb";

        public StudentInformation()
        {
            InitializeComponent();
        }

        private void StudentInformation_Load(object sender, EventArgs e)
        {
            comboBoxSemester.Items.Clear();
            comboBoxSemester.Items.Add(1);
            comboBoxSemester.Items.Add(2);
            comboBoxSemester.Items.Add(3);
            comboBoxSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSemester.SelectedIndex = 0; // Default to first item
            textBoxBatch.Text = "22";
            txtRollNo.Text = GenerateRollNo();
            dtpDOB.MaxDate = DateTime.Today.AddYears(-20); // Adjusted to a more realistic school age
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Loading this way prevents the file from being locked
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox2.Image = Image.FromStream(fs);
                    }
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        //private string GenerateRollNo()
        //{
        //    try
        //    {
        //        string batch = textBoxBatch.Text.Trim();
        //        if (string.IsNullOrEmpty(batch)) batch = "COM";

        //        using (OleDbConnection con = new OleDbConnection(conStr))
        //        {
        //            con.Open();
        //            int midStart = batch.Length + 2;
        //            string query = $"SELECT MAX(CInt(Mid(RollNo, {midStart}))) FROM UserInfotable WHERE RollNo LIKE ?";

        //            using (OleDbCommand cmd = new OleDbCommand(query, con))
        //            {
        //                cmd.Parameters.AddWithValue("?", batch + "-%");
        //                object result = cmd.ExecuteScalar();
        //                int nextNum = (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;
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
                if (string.IsNullOrEmpty(batch)) batch = "22"; // Batch မရှိရင် 22 ကို default ထားမယ်

                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    con.Open();

                    // "COM-" က ၄ လုံးဖြစ်လို့ ၅ လုံးမြောက်ကနေစပြီး ဂဏန်းကိုဖြတ်ယူမယ် (Mid(RollNo, 5))
                    // အဲဒီဂဏန်းကိုမှ integer ပြောင်းပြီး (CInt) အကြီးဆုံး (MAX) ကို ရှာမယ်
                    string query = "SELECT MAX(CInt(Mid(RollNo, 5))) FROM UserInfotable WHERE Batch = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", batch);

                        object result = cmd.ExecuteScalar();

                        // တကယ်လို့ record ရှိရင် ရှိတဲ့နံပါတ်ကို +1 တိုးမယ်၊ မရှိရင် 1 ကနေ စမယ်
                        int nextNum = (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;

                        // Format: COM-01, COM-02 စသဖြင့် ထွက်လာမယ်
                        return $"COM-{nextNum:D2}";
                    }
                }
            }
            catch
            {
                // Error တစ်ခုခုတက်ရင် Default အနေနဲ့ COM-01 ပြပေးမယ်
                return "COM-01";
            }
        }
        private DataRow GetStudentData(string batch, string rollNo)
        {
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                string query = "SELECT * FROM UserInfotable WHERE Batch = ? AND RollNo = ? ORDER BY Semester DESC";
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("?", batch);
                cmd.Parameters.AddWithValue("?", rollNo);

                DataTable dt = new DataTable();
                new OleDbDataAdapter(cmd).Fill(dt);

                return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
            }
        }

        private void BindStudentData(DataRow row)
        {
            txtFullName.Text = row["FullName"].ToString();
            txtNRC.Text = row["NRC"].ToString();
            txtRaceReligion.Text = row["RaceReligion"].ToString();

            if (row["DOB"] != DBNull.Value)
                dtpDOB.Value = Convert.ToDateTime(row["DOB"]);

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
            txtUniYear.Text = row["UniYear"].ToString();
            txtHSYear.Text = row["HSYear"].ToString();
            textBoxRoll.Text = row["HSRollNo"].ToString();

            string gender = row["Gender"].ToString();
            if (gender == "Male") radioMale.Checked = true;
            else if (gender == "Female") radioFemale.Checked = true;

            if (row["Photo"] != DBNull.Value)
            {
                try
                {
                    byte[] imgBytes = (byte[])row["Photo"];
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        pictureBox2.Image = Image.FromStream(ms);
                    }
                }
                catch { pictureBox2.Image = null; }
            }
        }

        private void button1_Click(object sender, EventArgs e) // Search/Bind Button
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
                MessageBox.Show("New Student detected.");
                return;
            }

            BindStudentData(row);
            int currentSem = Convert.ToInt32(row["Semester"]);
            if (currentSem < 3) comboBoxSemester.SelectedItem = currentSem + 1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    con.Open();
                    int semester = Convert.ToInt32(comboBoxSemester.SelectedItem);

                    // Convert UniYear to Integer (Matches DB screenshot: Number)
                    int.TryParse(txtUniYear.Text, out int uniYearValue);

                    byte[] photoBytes = null;
                    if (pictureBox2.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            photoBytes = ms.ToArray();
                        }
                    }

                    DataRow existingRow = GetStudentData(textBoxBatch.Text.Trim(), txtRollNo.Text.Trim());

                    if (existingRow != null)
                    {
                        // Update
                        string updateQuery = "UPDATE UserInfotable SET Semester = ?, Photo = ? WHERE Batch = ? AND RollNo = ?";
                        using (OleDbCommand cmd = new OleDbCommand(updateQuery, con))
                        {
                            cmd.Parameters.AddWithValue("?", semester);
                            cmd.Parameters.AddWithValue("?", (object)photoBytes ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("?", textBoxBatch.Text.Trim());
                            cmd.Parameters.AddWithValue("?", txtRollNo.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Insert - Positional order is critical for OleDb
                        string insertQuery = @"INSERT INTO UserInfotable
                        (RollNo, HSRollNo, FullName, NRC, RaceReligion, DOB, Gender,
                         FatherName, FatherOccupation, FatherAddress,
                         MotherName, MotherOccupation, MotherAddress,
                         HSYear, ExamCenter, Region,
                         DegreeType, University, UniYear, Semester, Batch, Photo)
                        VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                        using (OleDbCommand cmd = new OleDbCommand(insertQuery, con))
                        {
                            cmd.Parameters.AddWithValue("?", txtRollNo.Text);
                            cmd.Parameters.AddWithValue("?", textBoxRoll.Text);
                            cmd.Parameters.AddWithValue("?", txtFullName.Text);
                            cmd.Parameters.AddWithValue("?", txtNRC.Text);
                            cmd.Parameters.AddWithValue("?", txtRaceReligion.Text);
                            cmd.Parameters.AddWithValue("?", dtpDOB.Value.ToShortDateString());
                            cmd.Parameters.AddWithValue("?", radioMale.Checked ? "Male" : "Female");
                            cmd.Parameters.AddWithValue("?", txtFatherName.Text);
                            cmd.Parameters.AddWithValue("?", txtFatherOccupation.Text);
                            cmd.Parameters.AddWithValue("?", txtFatherAddress.Text);
                            cmd.Parameters.AddWithValue("?", txtMotherName.Text);
                            cmd.Parameters.AddWithValue("?", txtMotherOccupation.Text);
                            cmd.Parameters.AddWithValue("?", txtMotherAddress.Text);
                            cmd.Parameters.AddWithValue("?", txtHSYear.Text); // Long Text in DB
                            cmd.Parameters.AddWithValue("?", txtExamCenter.Text);
                            cmd.Parameters.AddWithValue("?", txtRegion.Text);
                            cmd.Parameters.AddWithValue("?", txtDegreeType.Text);
                            cmd.Parameters.AddWithValue("?", txtUniversity.Text);
                            cmd.Parameters.AddWithValue("?", uniYearValue); // Number in DB
                            cmd.Parameters.AddWithValue("?", semester);
                            cmd.Parameters.AddWithValue("?", textBoxBatch.Text.Trim());
                            cmd.Parameters.AddWithValue("?", (object)photoBytes ?? DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Saved successfully!");
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        

        private void ClearFields()
        {
            // TextBoxes
            txtFullName.Clear();
            txtNRC.Clear();
            txtRaceReligion.Clear();
            txtFatherName.Clear();
            txtFatherOccupation.Clear();
            txtFatherAddress.Clear();
            txtMotherName.Clear();
            txtMotherOccupation.Clear();
            txtMotherAddress.Clear();
            txtHSYear.Clear();
            txtExamCenter.Clear();
            txtRegion.Clear();
            txtDegreeType.Clear();
            txtUniversity.Clear();
            txtUniYear.Clear();
            textBoxRoll.Clear();
            textBoxBatch.Clear();

            // DatePicker - Reset to 20 years ago (as per your Load logic)
            dtpDOB.Value = DateTime.Today.AddYears(-20);

            // RadioButtons
            radioMale.Checked = false;
            radioFemale.Checked = false;

            // ComboBox
            if (comboBoxSemester.Items.Count > 0)
                comboBoxSemester.SelectedIndex = 0;

            // PictureBox
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose(); // Release memory
                pictureBox2.Image = null;
            }

            // Refresh Roll Number for the next entry
            txtRollNo.Text = GenerateRollNo();

            // Set focus back to the start
            txtFullName.Focus();
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required.");
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNRC.Text))
            {
                MessageBox.Show("NRC is required.");
                txtNRC.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRaceReligion.Text))
            {
                MessageBox.Show("Race and Religion is required.");
                txtRaceReligion.Focus();
                return false;
            }

            if (!radioMale.Checked && !radioFemale.Checked)
            {
                MessageBox.Show("Please select Gender.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFatherName.Text))
            {
                MessageBox.Show("Father Name is required.");
                txtFatherName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFatherOccupation.Text))
            {
                MessageBox.Show("Father Occupation is required.");
                txtFatherOccupation.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFatherAddress.Text))
            {
                MessageBox.Show("Father Address is required.");
                txtFatherAddress.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMotherName.Text))
            {
                MessageBox.Show("Mother Name is required.");
                txtMotherName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMotherOccupation.Text))
            {
                MessageBox.Show("Mother Occupation is required.");
                txtMotherOccupation.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMotherAddress.Text))
            {
                MessageBox.Show("Mother Address is required.");
                txtMotherAddress.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHSYear.Text))
            {
                MessageBox.Show("High School Year is required.");
                txtHSYear.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxRoll.Text))
            {
                MessageBox.Show("High School Roll No is required.");
                textBoxRoll.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtExamCenter.Text))
            {
                MessageBox.Show("Exam Center is required.");
                txtExamCenter.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRegion.Text))
            {
                MessageBox.Show("Region is required.");
                txtRegion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDegreeType.Text))
            {
                MessageBox.Show("Degree Type is required.");
                txtDegreeType.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUniversity.Text))
            {
                MessageBox.Show("University is required.");
                txtUniversity.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUniYear.Text))
            {
                MessageBox.Show("University Year is required.");
                txtUniYear.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxBatch.Text))
            {
                MessageBox.Show("Batch is required.");
                textBoxBatch.Focus();
                return false;
            }

            if (textBoxBatch.Text.Trim() != "22")
            {
                MessageBox.Show("Batch must be 22.");
                textBoxBatch.Focus();
                return false;
            }

            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Student Photo is required.");
                return false;
            }

            return true;
        }
        private void button2_Click(object sender, EventArgs e) // Logout
        {
            if (MessageBox.Show("Log out?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                new Form1().Show();
            }
        }
    }
}