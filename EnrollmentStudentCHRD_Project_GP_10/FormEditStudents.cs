using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EnrollmentStudentCHRD_Project_GP_10
{
    public partial class FormEditStudents : Form
    {
        int _studentId;

        public FormEditStudents()
        {
            InitializeComponent();
        }

        public FormEditStudents(int id)
        {
            InitializeComponent();
            _studentId = id;
        }

        private void FormEditStudents_Load(object sender, EventArgs e)
        {
            LoadStudentById();
        }

        void LoadStudentById()
        {
            string cs = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Soe Myat Tun\Downloads\StudentInfo1.accdb";

            using (OleDbConnection con = new OleDbConnection(cs))
            {
                string sql = "SELECT * FROM UserInfotable WHERE ID = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = _studentId;

                    con.Open();
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtRollNo.Text = dr["RollNo"]?.ToString();
                            textBoxRoll.Text = dr["HSRollNo"]?.ToString();
                            txtFullName.Text = dr["FullName"]?.ToString();
                            txtNRC.Text = dr["NRC"]?.ToString();
                            txtRaceReligion.Text = dr["RaceReligion"]?.ToString();
                            dtpDOB.Value = dr["DOB"] != DBNull.Value ? Convert.ToDateTime(dr["DOB"]) : DateTime.Today;
                            txtFatherName.Text = dr["FatherName"]?.ToString();
                            txtFatherOccupation.Text = dr["FatherOccupation"]?.ToString();
                            txtFatherAddress.Text = dr["FatherAddress"]?.ToString();
                            txtMotherName.Text = dr["MotherName"]?.ToString();
                            txtMotherOccupation.Text = dr["MotherOccupation"]?.ToString();
                            txtMotherAddress.Text = dr["MotherAddress"]?.ToString();
                            txtHSYear.Text = dr["HSYear"]?.ToString();
                            txtExamCenter.Text = dr["ExamCenter"]?.ToString();
                            txtRegion.Text = dr["Region"]?.ToString();
                            txtDegreeType.Text = dr["DegreeType"]?.ToString();
                            txtUniversity.Text = dr["University"]?.ToString();
                            txtUniYear.Text = dr["UniYear"]?.ToString();
                            comboBoxSemester.SelectedItem = dr["Semester"]?.ToString();
                            textBoxBatch.Text = dr["Batch"]?.ToString();
                        }
                    }
                }
            }
        }

        void ClearForm()
        {
            txtRollNo.Clear();
            textBoxRoll.Clear();
            txtFullName.Clear();
            txtNRC.Clear();
            txtRaceReligion.Clear();

            dtpDOB.Value = DateTime.Today;
            dtpDOB.Checked = false;

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

            comboBoxSemester.SelectedIndex = -1;
            textBoxBatch.Clear();
        }
        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            string cs = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Soe Myat Tun\Downloads\StudentInfo1.accdb";

            using (OleDbConnection con = new OleDbConnection(cs))
            {
                string sql = @"UPDATE UserInfotable SET
                        RollNo = ?,
                        HSRollNo = ?,
                        FullName = ?,
                        NRC = ?,
                        RaceReligion = ?,
                        DOB = ?,
                        FatherName = ?,
                        FatherOccupation = ?,
                        FatherAddress = ?,
                        MotherName = ?,
                        MotherOccupation = ?,
                        MotherAddress = ?,
                        HSYear = ?,
                        ExamCenter = ?,
                        Region = ?,
                        DegreeType = ?,
                        University = ?,
                        UniYear = ?,
                        Semester = ?,
                        Batch = ?
                       WHERE ID = ?";
                try
                {
                    using (OleDbCommand cmd = new OleDbCommand(sql, con))
                    {
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = int.TryParse(txtRollNo.Text, out int roll) ? roll : (object)DBNull.Value;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = textBoxRoll.Text;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtFullName.Text;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(txtNRC.Text) ? (object)DBNull.Value : txtNRC.Text;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(txtRaceReligion.Text) ? (object)DBNull.Value : txtRaceReligion.Text;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = dtpDOB.Checked ? (object)dtpDOB.Value.Date : DBNull.Value;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(txtFatherName.Text) ? (object)DBNull.Value : txtFatherName.Text;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(txtFatherOccupation.Text) ? (object)DBNull.Value : txtFatherOccupation.Text;
                        cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = string.IsNullOrWhiteSpace(txtFatherAddress.Text) ? (object)DBNull.Value : txtFatherAddress.Text;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(txtMotherName.Text) ? (object)DBNull.Value : txtMotherName.Text;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(txtMotherOccupation.Text) ? (object)DBNull.Value : txtMotherOccupation.Text;
                        cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = string.IsNullOrWhiteSpace(txtMotherAddress.Text) ? (object)DBNull.Value : txtMotherAddress.Text;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = int.TryParse(txtHSYear.Text, out int hsYear) ? hsYear : (object)DBNull.Value;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(txtExamCenter.Text) ? (object)DBNull.Value : txtExamCenter.Text;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(txtRegion.Text) ? (object)DBNull.Value : txtRegion.Text;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(txtDegreeType.Text) ? (object)DBNull.Value : txtDegreeType.Text;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(txtUniversity.Text) ? (object)DBNull.Value : txtUniversity.Text;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = int.TryParse(txtUniYear.Text, out int uniYear) ? uniYear : (object)DBNull.Value;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = comboBoxSemester.SelectedItem != null ? int.Parse(comboBoxSemester.SelectedItem.ToString()) : (object)DBNull.Value;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(textBoxBatch.Text) ? (object)DBNull.Value : textBoxBatch.Text;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = _studentId;

                        con.Open();
                        int rows = cmd.ExecuteNonQuery();


                        if (rows > 0)
                        {
                            MessageBox.Show("Update Successfully");
                            ClearForm();   // 👈 ဒီနေရာမှာခေါ်ပါ
                        }
                        else
                        {
                            MessageBox.Show("No record was updated.");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AdminDashboard admin = new AdminDashboard();
            admin.Show();
            this.Close();
        }

        private void FormEditStudents_Load_1(object sender, EventArgs e)
        {
            LoadStudentById();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }






        //private void btnSubmit_Click(object sender, EventArgs e)
        //{

        //}
    }
}
