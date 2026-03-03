using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EnrollmentStudentCHRD_Project_GP_10
{
    public partial class AdminDashboard : Form
    {
        PrintDocument printDocument1 = new PrintDocument();
        DataGridViewRow selectedRow;
        OleDbDataAdapter adapter;
        DataTable dt;

        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Soe Myat Tun\Downloads\StudentInfo1.accdb";
        public AdminDashboard()
        {
            InitializeComponent();
            dataGridView1.DataError += dataGridView1_DataError;
            printDocument1.PrintPage += PrintDocument1_PrintPage;
        }


        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Are you sure you want to delete this student?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (r == DialogResult.No) return;

            string rollNo = dataGridView1.SelectedRows[0].Cells["RollNo"].Value.ToString();

            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    string query = "DELETE FROM UserInfotable WHERE RollNo = ?";

                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.Parameters.AddWithValue("?", rollNo);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("Student deleted successfully.");
                        LoadStudents();
                    }
                    else
                    {
                        MessageBox.Show("No student found to delete.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadStudents();

           


            LocalizationService.ApplyLanguage(
                this,
                LanguageState.CurrentLanguage
            );
            txtBatch.Clear();
        }

        //private void LoadStudents()
        //{
        //    using (OleDbConnection con = new OleDbConnection(conStr))
        //    {
        //        string query = "SELECT * FROM UserInfotable";
        //        OleDbDataAdapter da = new OleDbDataAdapter(query, con);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        dataGridView1.DataSource = dt;
        //    }
        //}
        //private void LoadStudents()
        //{
        //    try
        //    {
        //        using (OleDbConnection con = new OleDbConnection(conStr))
        //        {
        //            string query = "SELECT * FROM UserInfotable";
        //            adapter = new OleDbDataAdapter(query, con);
        //            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

        //            dt = new DataTable();
        //            adapter.Fill(dt);
        //            dataGridView1.DataSource = dt;
        //        }

        //        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //        dataGridView1.DefaultCellStyle.Font = new Font("Pyidaungsu", 10);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading students: " + ex.Message);
        //    }
        //}
        private void LoadStudents()
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    string query = "SELECT * FROM UserInfotable";
                    adapter = new OleDbDataAdapter(query, con);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                // ❌ AutoSize AllCells မသုံးပါ
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                dataGridView1.RowTemplate.Height = 50;
                dataGridView1.DefaultCellStyle.Font = new Font("Pyidaungsu", 10);

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (col.Name == "Photo")
                    {
                        col.Width = 100;
                        if (col is DataGridViewImageColumn imgCol)
                        {
                            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        }
                    }
                    else
                    {
                        col.Width = 120;// fixed width (လိုသလိုပြင်)
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void LoadStudents()
        //{
        //    try
        //    {
        //        using (OleDbConnection con = new OleDbConnection(conStr))
        //        {
        //            string query = "SELECT * FROM UserInfotable";
        //            adapter = new OleDbDataAdapter(query, con);
        //            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

        //            dt = new DataTable();
        //            adapter.Fill(dt);
        //            dataGridView1.DataSource = dt;
        //        }

        //        // ===== GENERAL SETTINGS =====
        //        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //        dataGridView1.DefaultCellStyle.Font = new Font("Pyidaungsu", 10);

        //        // ===== COLUMN WIDTH & ROW HEIGHT =====
        //        foreach (DataGridViewColumn col in dataGridView1.Columns)
        //        {
        //            if (col.Name == "Photo") // Photo column အတွက်
        //            {
        //                col.Width = 100; // column width
        //                DataGridViewImageColumn imgCol = col as DataGridViewImageColumn;
        //                if (imgCol != null)
        //                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; // Zoom layout
        //            }
        //            else
        //            {
        //                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //            }
        //        }

        //        // Row height
        //        dataGridView1.RowTemplate.Height = 100;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading students: " + ex.Message);
        //    }
        //}
        //private void LoadStudents()
        //{
        //    using (OleDbConnection con = new OleDbConnection(conStr))
        //    {
        //        string query = "SELECT * FROM UserInfotable"; // Database field အားလုံးကို ဆွဲထုတ်ခြင်း
        //        adapter = new OleDbDataAdapter(query, con);

        //        // CommandBuilder က Update/Delete/Insert code တွေကို အလိုအလျောက် ဖန်တီးပေးပါတယ်
        //        OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

        //        dt = new DataTable();
        //        adapter.Fill(dt);
        //        dataGridView1.DataSource = dt;
        //    }
        //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //    dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //    dataGridView1.DefaultCellStyle.Font = new Font("Pyidaungsu", 10);
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
//            string keyword = textBox1.Text;

//            using (OleDbConnection con = new OleDbConnection(conStr))
//            {
//                string query = @"
//SELECT * FROM UserInfotable 
//WHERE RollNo LIKE ? OR FullName LIKE ? OR NRC LIKE ?";

//                OleDbCommand cmd = new OleDbCommand(query, con);
//                string pattern = "%" + keyword + "%";
//                cmd.Parameters.Add("?", OleDbType.VarWChar).Value = pattern;
//                cmd.Parameters.Add("?", OleDbType.VarWChar).Value = pattern;
//                cmd.Parameters.Add("?", OleDbType.VarWChar).Value = pattern;

//                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
//                DataTable dt = new DataTable();
//                da.Fill(dt);

//                dataGridView1.DataSource = dt;
//            }
        }
        //private void button4_Click(object sender, EventArgs e)
        //{

        //}

        private void button4_Click(object sender, EventArgs e)
        {
            // Clear search textbox
            txtRollNo.Clear();

            // Reset search dropdown
            txtRollNo.Clear();

            // Reload all students from database
            LoadStudents();

            //// Clear DataGridView selection and selectedRow variable
            //dataGridView1.ClearSelection();
            //selectedRow = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        


        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // ===== PAGE & CARD SIZE =====
            int pageW = e.PageBounds.Width;
            int pageH = e.PageBounds.Height;

            int cardW = 460;
            int cardH = 270;

            int x = (pageW - cardW) / 2;
            int y = (pageH - cardH) / 2;

            // ===== CARD BACKGROUND =====
            g.FillRectangle(Brushes.White, x, y, cardW, cardH);
            g.DrawRectangle(new Pen(Color.Black, 2), x, y, cardW, cardH);

            // ===== HEADER =====
            int headerH = 66;
            g.FillRectangle(Brushes.SteelBlue, x, y, cardW, headerH);

            Image logo = Image.FromFile(@"C:\Users\Soe Myat Tun\Pictures\Yangon_university.jpg");
            g.DrawImage(logo, x + 10, y + 5, 45, 45);


            Font headerFont = new Font("Myanmar Text", 12, FontStyle.Bold);
            g.DrawString("ရန်ကုန် တက္ကသိုလ်", headerFont, Brushes.White, x + 200, y + 6);
            g.DrawString("လူ့စွမ်းအားအရင်းအမြစ် ဖွံ့ဖြိုးရေးဌာန", headerFont, Brushes.White, x + 140, y + 28);

            // ===== PHOTO =====
            int photoX = x + 15;
            int photoY = y + headerH + 12;
            int photoW = 90;
            int photoH = 115;

            g.DrawRectangle(Pens.Black, photoX, photoY, photoW, photoH);

            if (selectedRow.Cells["Photo"].Value != DBNull.Value)
            {
                byte[] imgBytes = (byte[])selectedRow.Cells["Photo"].Value;
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    Image img = Image.FromStream(ms);
                    g.DrawImage(img, photoX + 2, photoY + 2, photoW - 4, photoH - 4);
                }
            }

            // ===== TEXT =====
            Font labelFont = new Font("Myanmar Text", 9, FontStyle.Bold);
            Font valueFont = new Font("Myanmar Text", 9);

            int textX = photoX + photoW + 15;
            int textY = photoY;

            g.DrawString("အမည် :", labelFont, Brushes.Black, textX, textY);
            g.DrawString(selectedRow.Cells["FullName"].Value.ToString(),
                valueFont, Brushes.Black, textX + 65, textY);

            g.DrawString("ခုံအမှတ် :", labelFont, Brushes.Black, textX, textY + 26);
            g.DrawString(selectedRow.Cells["RollNo"].Value.ToString(),
                valueFont, Brushes.Black, textX + 65, textY + 26);

            g.DrawString("NRC NO:", labelFont, Brushes.Black, textX, textY + 52);
            g.DrawString(selectedRow.Cells["NRC"].Value.ToString(),
                valueFont, Brushes.Black, textX + 65, textY + 52);

            g.DrawString("အဖ အမည် :", labelFont, Brushes.Black, textX, textY + 78);
            g.DrawString(selectedRow.Cells["FatherName"].Value.ToString(),
                valueFont, Brushes.Black, textX + 65, textY + 78);

            // ===== SIGNATURE LINE =====
            g.DrawLine(Pens.Black, x + cardW - 160, y + cardH - 35, x + cardW - 20, y + cardH - 35);
            g.DrawString("တာဝန်ရှိသူ လက်မှတ်", valueFont, Brushes.Black,
                x + cardW - 150, y + cardH - 28);
        }


        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student first.");
                return;
            }

            selectedRow = dataGridView1.SelectedRows[0];

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocument1;
            preview.Width = 800;
            preview.Height = 600;

            preview.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchStudents();
        }

        

        //private void SearchStudent()
        //{
        //    if (txtSemester.SelectedIndex == -1)
        //    {
        //        MessageBox.Show("Please select search type.");
        //        return;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtRollNo.Text))
        //    {
        //        MessageBox.Show("Please enter search value.");
        //        return;
        //    }

        //    string searchBy = txtSemester.SelectedItem.ToString();
        //    string query = "";

        //    using (OleDbConnection con = new OleDbConnection(conStr))
        //    using (OleDbCommand cmd = new OleDbCommand())
        //    {
        //        cmd.Connection = con;

        //        if (searchBy == "Batch")
        //        {
        //            query = "SELECT * FROM UserInfotable WHERE Trim(Batch) = ?";
        //            cmd.Parameters.AddWithValue("?", txtRollNo.Text.Trim());
        //        }
        //        else if (searchBy == "Semester")
        //        {
        //            if (!int.TryParse(txtRollNo.Text.Trim(), out int semester))
        //            {
        //                MessageBox.Show("Invalid semester number.");
        //                txtRollNo.Focus();
        //                return;
        //            }
        //            query = "SELECT * FROM UserInfotable WHERE Semester = ?";
        //            cmd.Parameters.AddWithValue("?", semester);
        //        }
        //        else if (searchBy == "Roll No")
        //        {
        //            query = "SELECT * FROM UserInfotable WHERE Trim(RollNo) LIKE ?";
        //            cmd.Parameters.AddWithValue("?", "%" + txtRollNo.Text.Trim() + "%");
        //        }
        //        else if (searchBy == "NRC No")
        //        {
        //            query = "SELECT * FROM UserInfotable WHERE Trim(NRC) LIKE ?";
        //            cmd.Parameters.AddWithValue("?", "%" + txtRollNo.Text.Trim() + "%");
        //        }

        //        cmd.CommandText = query;

        //        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        if (dt.Rows.Count == 0)
        //        {
        //            MessageBox.Show("No record found.", "Search Result");
        //            txtRollNo.Focus();
        //            txtRollNo.SelectAll();
        //            return;
        //        }

        //        dataGridView1.DataSource = dt;
        //    }
        //}
        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtRollNo.Clear();
            //txtRollNo.KeyPress -= NumberOnly_KeyPress;

            //// ✅ Null check
            //if (txtRollNo.SelectedItem != null && txtRollNo.SelectedItem.ToString() == "Semester")
            //{
            //    txtRollNo.KeyPress += NumberOnly_KeyPress;
            //}
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Confirm logout
            DialogResult r = MessageBox.Show(
                "Are you sure you want to log out?",
                "Log Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (r == DialogResult.Yes)
            {
                // Hide or close Admin Dashboard
                this.Hide();

                // Show Login form
                Form1 login = new Form1();
                login.Show();
            }
        }
        //private void btnEdit_Click(object sender, EventArgs e)
        //{

        //}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Edit လုပ်ရန် Row တစ်ခုရွေးပါ");
                return;
            }

            int id = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["ID"].Value
            );

            FormEditStudents frm = new FormEditStudents(id);
            frm.ShowDialog();

            LoadStudents(); // refresh grid
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchStudents()
        {
            try
            {
                List<string> conditions = new List<string>();
                List<OleDbParameter> parameters = new List<OleDbParameter>();

                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;

                    // ===== Roll No =====
                    if (!string.IsNullOrWhiteSpace(txtRollNo.Text))
                    {
                        conditions.Add("Trim(RollNo) LIKE ?");
                        parameters.Add(new OleDbParameter("?", "%" + txtRollNo.Text.Trim() + "%"));
                    }

                    // ===== Full Name =====
                    if (!string.IsNullOrWhiteSpace(txtFullName.Text))
                    {
                        conditions.Add("Trim(FullName) LIKE ?");
                        parameters.Add(new OleDbParameter("?", "%" + txtFullName.Text.Trim() + "%"));
                    }

                    // ===== Batch =====
                    if (!string.IsNullOrWhiteSpace(txtBatch.Text))
                    {
                        conditions.Add("Trim(Batch) = ?");
                        parameters.Add(new OleDbParameter("?", txtBatch.Text.Trim()));
                    }

                    // ===== Semester =====
                    if (!string.IsNullOrWhiteSpace(txtSemester.Text))
                    {
                        // Number only: parse or just keep as string
                        if (int.TryParse(txtSemester.Text.Trim(), out int sem))
                        {
                            conditions.Add("Semester = ?");
                            parameters.Add(new OleDbParameter("?", sem));
                        }
                        else
                        {
                            MessageBox.Show("Semester must be a number.");
                            txtSemester.Focus();
                            return;
                        }
                    }

                    // ===== Build query =====
                    string query = "SELECT * FROM UserInfotable";
                    if (conditions.Count > 0)
                        query += " WHERE " + string.Join(" AND ", conditions);

                    cmd.CommandText = query;
                    cmd.Parameters.AddRange(parameters.ToArray());

                    // ===== Execute search =====
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable searchDt = new DataTable();
                    da.Fill(searchDt);

                    if (searchDt.Rows.Count == 0)
                    {
                        MessageBox.Show("No record found.", "Search Result");
                        return;
                    }

                    dataGridView1.DataSource = searchDt;

                    // Update male/female/total counter
                    UpdateGenderCount(searchDt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }
        // ==================== MALE/FEMALE/TOTAL COUNTER ====================
        private void UpdateGenderCount(DataTable table)
        {
            int maleCount = 0;
            int femaleCount = 0;

            foreach (DataRow row in table.Rows)
            {
                string gender = row["Gender"].ToString().Trim().ToLower();
                if (gender == "male") maleCount++;
                else if (gender == "female") femaleCount++;
            }

            lblMale.Text = "Male: " + maleCount;
            lblFemale.Text = "Female: " + femaleCount;
            lblTotal.Text = "Total: " + table.Rows.Count;
        }

        // ==================== CLEAR SEARCH ====================
        //private void btnClear_Click(object sender, EventArgs e)
        //{
        //    txtFullName.Clear();
        //    txtFullName.Clear();
        //    txtBatch.Clear();
        //    txtRollNo.Clear();
        //}

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtFullName.Clear();
            txtBatch.Clear();
            txtRollNo.Clear();
            lblFemale.Text="";
            lblMale.Text = "";
            lblTotal.Text = "";
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report reportForm = new Report();
            reportForm.ShowDialog();
        }
    }


}
