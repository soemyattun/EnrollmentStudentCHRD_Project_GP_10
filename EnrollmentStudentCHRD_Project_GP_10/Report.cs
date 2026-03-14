using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EnrollmentStudentCHRD_Project_GP_10
{
    public partial class Report : Form
    {
        private DataTable reportData;
        private int currentRow = 0;
        private PrintDocument printDocumentAttendance = new PrintDocument();

        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Soe Myat Tun\Downloads\StudentInfo1.accdb";

        public Report()
        {
            InitializeComponent();
            printDocument1.PrintPage += printDocument1_PrintPage;
            printDocument1.BeginPrint += printDocument1_BeginPrint;

            printDocumentAttendance.PrintPage += printDocumentAttendance_PrintPage;
            printDocumentAttendance.BeginPrint += printDocumentAttendance_BeginPrint;
        }

        //private void Report_Load(object sender, EventArgs e)
        //{
        //    cboSemester.Items.Add("All");
        //    cboSemester.Items.Add("1");
        //    cboSemester.Items.Add("2");
        //    cboSemester.Items.Add("3");
        //    cboSemester.SelectedIndex = 0;

        //    printPreviewDialog1.Document = printDocument1;



        //    dgvStudents.DefaultCellStyle.Font = new Font("Pyidaungsu", 10);


        //    dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Pyidaungsu", 10, FontStyle.Bold);
        //    dgvStudents.DataError += (s, ev) => { ev.ThrowException = false; };
        //    dgvStudents.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        //    dgvStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        //    dgvStudents.RowTemplate.Height = 50;
        //    if (dgvStudents.Columns.Contains("Photo"))
        //    {
        //        DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dgvStudents.Columns["Photo"];
        //        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
        //        imgCol.Width = 80; // Photo ကွက်ရဲ့ အကျယ်ကို ကန့်သတ်ခြင်း
        //    }
        //    dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        //    dgvStudents.ReadOnly = true;

        //}

        private void Report_Load(object sender, EventArgs e)
        {
            // ===== Semester Combo =====
            cboSemester.Items.Clear();
            cboSemester.Items.Add("All");
            cboSemester.Items.Add("1");
            cboSemester.Items.Add("2");
            cboSemester.Items.Add("3");
            cboSemester.SelectedIndex = 0;

            // ===== Print Preview =====
            printPreviewDialog1.Document = printDocument1;

            // ===== DataGridView Design =====
            dgvStudents.AutoGenerateColumns = true;
            dgvStudents.ReadOnly = true;

            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.BorderStyle = BorderStyle.FixedSingle;

            dgvStudents.DefaultCellStyle.Font = new Font("Pyidaungsu", 10);
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Pyidaungsu", 10, FontStyle.Bold);

            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvStudents.EnableHeadersVisualStyles = false;

            dgvStudents.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dgvStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvStudents.RowTemplate.Height = 60;

            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;

            dgvStudents.ScrollBars = ScrollBars.Both;

            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;

            dgvStudents.DataError += (s, ev) => { ev.ThrowException = false; };

            if (dgvStudents.Columns.Contains("Photo"))
            {
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dgvStudents.Columns["Photo"];
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 80;
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string batch = txtBatch.Text.Trim();
            string rollNo = txtRollNo.Text.Trim();
            int semester = 0;

            if (cboSemester.SelectedIndex > 0)
                semester = int.Parse(cboSemester.SelectedItem.ToString());

            DataTable dt = new DataTable();

            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                con.Open();
                // SELECT * ထားခဲ့လျှင်လည်း ရပါသည် (Column များလွန်း၍ ညှိလိုပါက အရင်ပြောခဲ့သလို နာမည်များတပ်၍ ရွေးထုတ်ပါ)
                string sql = "SELECT * FROM UserInfotable WHERE 1=1";

                if (!string.IsNullOrEmpty(batch))
                    sql += " AND Batch=?";
                if (semester > 0)
                    sql += " AND Semester=?";
                if (!string.IsNullOrEmpty(rollNo))
                    sql += " AND RollNo=?";

                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    if (!string.IsNullOrEmpty(batch))
                        cmd.Parameters.AddWithValue("?", batch);
                    if (semester > 0)
                        cmd.Parameters.AddWithValue("?", semester);
                    if (!string.IsNullOrEmpty(rollNo))
                        cmd.Parameters.AddWithValue("?", rollNo);

                    new OleDbDataAdapter(cmd).Fill(dt);
                }
            }

            // ===== Auto No Column =====
            if (dt.Columns.Contains("No"))
                dt.Columns.Remove("No");

            dt.Columns.Add("No", typeof(int));
            dt.Columns["No"].SetOrdinal(0);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["No"] = i + 1;
            }

            // --- Row Height ပုံသေသတ်မှတ်ခြင်း စတင်သည် ---
            dgvStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None; // Auto ချဲ့ခြင်းကို ပိတ်ပါ
            dgvStudents.AllowUserToResizeRows = false; // User ကို ဆွဲချဲ့ခွင့် ပိတ်ထားနိုင်သည်

            dgvStudents.DataSource = dt;
            dgvStudents.Columns["ID"].Visible = false;

            // Data ဆွဲတင်ပြီးမှ Row အမြင့်ကို ပုံသေ 80 သို့ ပြောင်းလဲခြင်း
            dgvStudents.RowTemplate.Height = 80;
            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                row.Height = 50;
            }

            // Photo Column ကို အချိုးကျဖြစ်အောင် ညှိခြင်း
            if (dgvStudents.Columns.Contains("Photo"))
            {
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dgvStudents.Columns["Photo"];
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; // ပုံမပြတ်အောင် Zoom လုပ်ပါ
                imgCol.Width = 80; // Column အကျယ်ကို ကန့်သတ်ပါ
            }
            // ----------------------------------------
        }
      
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (dgvStudents.DataSource == null || dgvStudents.Rows.Count == 0)
            {
                MessageBox.Show("No data to preview");
                return;
            }

            reportData = ((DataTable)dgvStudents.DataSource).Copy();
            currentRow = 0;

            printPreviewDialog1.ShowDialog();
        }

        // ===== Print Button =====
        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            if (dgvStudents.DataSource == null || dgvStudents.Rows.Count == 0)
            {
                MessageBox.Show("No data to print");
                return;
            }

            reportData = ((DataTable)dgvStudents.DataSource).Copy();
            currentRow = 0;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        // ===== Begin Print Settings =====
        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);
            currentRow = 0;
        }

        // ===== OLE Image Safe Function =====
        private Image GetImageFromOle(byte[] oleData)
        {
            try
            {
                if (oleData == null || oleData.Length == 0)
                    return null;

                int headerIndex = 0;
                for (int i = 0; i < oleData.Length - 1; i++)
                {
                    if (oleData[i] == 0xFF && oleData[i + 1] == 0xD8) { headerIndex = i; break; } // JPG
                    if (oleData[i] == 0x89 && oleData[i + 1] == 0x50) { headerIndex = i; break; } // PNG
                    if (oleData[i] == 0x42 && oleData[i + 1] == 0x4D) { headerIndex = i; break; } // BMP
                }

                using (MemoryStream ms = new MemoryStream(oleData, headerIndex, oleData.Length - headerIndex))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        // ===== Print Page =====
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (reportData == null || reportData.Rows.Count == 0)
                return;

            int marginLeft = e.MarginBounds.Left;
            int marginTop = e.MarginBounds.Top;
            int pageWidth = e.MarginBounds.Width;
            int pageHeight = e.MarginBounds.Height;

            Font headerFont = new Font("Arial", 9, FontStyle.Bold);
            Font dataFont = new Font("Arial", 8);

            int colCount = reportData.Columns.Count;

            // ===== Column width dynamic =====
            int photoWidth = 120;
            int[] colWidths = new int[colCount];

            for (int i = 0; i < colCount; i++)
            {
                if (reportData.Columns[i].ColumnName.ToLower() == "photo")
                    colWidths[i] = photoWidth;
                else
                {
                    int maxWidth = (int)e.Graphics.MeasureString(reportData.Columns[i].ColumnName, headerFont).Width + 10;
                    foreach (DataRow row in reportData.Rows)
                    {
                        string text = row[i]?.ToString() ?? "";
                        int textWidth = (int)e.Graphics.MeasureString(text, dataFont).Width + 10;
                        if (textWidth > maxWidth)
                            maxWidth = textWidth;
                    }
                    colWidths[i] = maxWidth;
                }
            }

            int totalWidth = colWidths.Sum();
            if (totalWidth > pageWidth)
            {
                float scale = (float)pageWidth / totalWidth;
                for (int i = 0; i < colCount; i++)
                    colWidths[i] = (int)(colWidths[i] * scale);
            }

            int y = marginTop;

            // ===== Header =====
            int currentX = marginLeft;
            for (int i = 0; i < colCount; i++)
            {
                Rectangle rect = new Rectangle(currentX, y, colWidths[i], 30);
                e.Graphics.FillRectangle(Brushes.LightGray, rect);
                e.Graphics.DrawRectangle(Pens.Black, rect);
                e.Graphics.DrawString(reportData.Columns[i].ColumnName, headerFont, Brushes.Black, rect);
                currentX += colWidths[i];
            }
            y += 30;

            // ===== Rows =====
            while (currentRow < reportData.Rows.Count)
            {
                DataRow row = reportData.Rows[currentRow];

                int rowHeight = 0;
                for (int i = 0; i < colCount; i++)
                {
                    if (reportData.Columns[i].ColumnName.ToLower() == "photo" && row[i] != DBNull.Value && row[i] is byte[])
                        rowHeight = Math.Max(rowHeight, 80);
                    else
                    {
                        string text = row[i]?.ToString() ?? "";
                        int cellHeight = (int)e.Graphics.MeasureString(text, dataFont, colWidths[i]).Height + 10;
                        rowHeight = Math.Max(rowHeight, cellHeight);
                    }
                }

                currentX = marginLeft;
                for (int i = 0; i < colCount; i++)
                {
                    Rectangle cellRect = new Rectangle(currentX, y, colWidths[i], rowHeight);
                    e.Graphics.DrawRectangle(Pens.Black, cellRect);

                    if (reportData.Columns[i].ColumnName.ToLower() == "photo" && row[i] != DBNull.Value && row[i] is byte[])
                    {
                        Image img = GetImageFromOle((byte[])row[i]);
                        if (img != null)
                        {
                            float ratio = Math.Min((float)cellRect.Width / img.Width,
                                                   (float)cellRect.Height / img.Height);
                            int newWidth = (int)(img.Width * ratio);
                            int newHeight = (int)(img.Height * ratio);
                            int imgX = cellRect.X + (cellRect.Width - newWidth) / 2;
                            int imgY = cellRect.Y + (cellRect.Height - newHeight) / 2;
                            e.Graphics.DrawImage(img, imgX, imgY, newWidth, newHeight);
                        }
                    }
                    else
                    {
                        string text = row[i]?.ToString() ?? "";
                        e.Graphics.DrawString(text, dataFont, Brushes.Black, cellRect);
                    }

                    currentX += colWidths[i];
                }

                y += rowHeight;
                currentRow++;

                if (y + rowHeight > marginTop + pageHeight)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            currentRow = 0;
            e.HasMorePages = false;
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void btnReport_Click_1(object sender, EventArgs e)
        {
            if (dgvStudents.DataSource == null || dgvStudents.Rows.Count == 0)
            {
                MessageBox.Show("No data to print!");
                return;
            }

            DataTable sourceTable = (DataTable)dgvStudents.DataSource;
            DataTable dt = new DataTable();

            string[] columns =
            {
        "RollNo",
        "FullName",
        "NRC",
        "Gender",
        "DOB",
        "FatherName",
        "DegreeType",
        "University",
        "UniYear",
        "FatherAddress",


    };

            foreach (string col in columns)
            {
                if (sourceTable.Columns.Contains(col))
                    dt.Columns.Add(col);
            }

            foreach (DataRow row in sourceTable.Rows)
            {
                DataRow newRow = dt.NewRow();
                foreach (string col in columns)
                {
                    if (sourceTable.Columns.Contains(col))
                    {
                        // ===== DOB ကို date only format =====
                        if (col == "DOB" && row[col] != DBNull.Value)
                        {
                            DateTime dob = Convert.ToDateTime(row[col]);
                            newRow[col] = dob.ToString("yyyy-MM-dd"); // "2026-03-05" ပုံစံ
                        }
                        else
                        {
                            newRow[col] = row[col];
                        }
                    }
                }
                dt.Rows.Add(newRow);
            }

            reportData = dt;
            currentRow = 0;

            printPreviewDialog1.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        
        {
                AdminDashboard admin = new AdminDashboard();
                admin.Show();
                this.Close();
        }

        private void printDocumentAttendance_BeginPrint(object sender, PrintEventArgs e)
        {
            printDocumentAttendance.DefaultPageSettings.Landscape = true;
            printDocumentAttendance.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);
            currentRow = 0;
        }

       
        private void printDocumentAttendance_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (reportData == null || reportData.Rows.Count == 0)
                return;

            int marginLeft = e.MarginBounds.Left;
            int marginTop = e.MarginBounds.Top;
            int pageWidth = e.MarginBounds.Width;
            int pageHeight = e.MarginBounds.Height;

            Font headerFont = new Font("Arial", 9, FontStyle.Bold);
            Font dataFont = new Font("Arial", 8);

            int colCount = reportData.Columns.Count;
            int attendanceColWidth = 50;

            int[] colWidths = new int[colCount];
            for (int i = 0; i < colCount; i++)
            {
                string colName = reportData.Columns[i].ColumnName.ToLower();
                if (int.TryParse(colName, out int day) && day >= 1 && day <= 15)
                    colWidths[i] = attendanceColWidth;
                else
                {
                    int maxWidth = (int)e.Graphics.MeasureString(reportData.Columns[i].ColumnName, headerFont).Width + 10;
                    foreach (DataRow row in reportData.Rows)
                    {
                        string text = row[i]?.ToString() ?? "";
                        int textWidth = (int)e.Graphics.MeasureString(text, dataFont).Width + 10;
                        if (textWidth > maxWidth)
                            maxWidth = textWidth;
                    }
                    colWidths[i] = maxWidth;
                }
            }

            // Scale other columns if total width exceeds page
            int totalWidth = colWidths.Sum();
            if (totalWidth > pageWidth)
            {
                float scale = (float)(pageWidth - 15 * attendanceColWidth) / (totalWidth - 15 * attendanceColWidth);
                for (int i = 0; i < colCount; i++)
                {
                    string colName = reportData.Columns[i].ColumnName.ToLower();
                    if (!int.TryParse(colName, out int day) || day > 15)
                        colWidths[i] = (int)(colWidths[i] * scale);
                }
            }

            int y = marginTop;

            // Header
            int currentX = marginLeft;
            for (int i = 0; i < colCount; i++)
            {
                Rectangle rect = new Rectangle(currentX, y, colWidths[i], 30);
                e.Graphics.FillRectangle(Brushes.LightGray, rect);
                e.Graphics.DrawRectangle(Pens.Black, rect);
                e.Graphics.DrawString(reportData.Columns[i].ColumnName, headerFont, Brushes.Black, rect);
                currentX += colWidths[i];
            }
            y += 30;

            // Rows
            while (currentRow < reportData.Rows.Count)
            {
                DataRow row = reportData.Rows[currentRow];
                int rowHeight = 25;
                currentX = marginLeft;

                for (int i = 0; i < colCount; i++)
                {
                    Rectangle cellRect = new Rectangle(currentX, y, colWidths[i], rowHeight);
                    e.Graphics.DrawRectangle(Pens.Black, cellRect);

                    string colName = reportData.Columns[i].ColumnName;

                    if (int.TryParse(colName, out int day) && day >= 1 && day <= 15)
                    {
                        int boxSize = 12;
                        Rectangle checkBoxRect = new Rectangle(
                            cellRect.X + (cellRect.Width - boxSize) / 2,
                            cellRect.Y + (cellRect.Height - boxSize) / 2,
                            boxSize, boxSize);
                        //e.Graphics.DrawRectangle(Pens.Black);
                    }
                    else
                    {
                        string text = row[i]?.ToString() ?? "";
                        e.Graphics.DrawString(text, dataFont, Brushes.Black, new RectangleF(
                            cellRect.X + 2, cellRect.Y + 2, cellRect.Width - 4, cellRect.Height - 4));
                    }

                    currentX += colWidths[i];
                }

                y += rowHeight;
                currentRow++;

                if (y + rowHeight > marginTop + pageHeight)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            currentRow = 0;
            e.HasMorePages = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgvStudents.DataSource == null || dgvStudents.Rows.Count == 0)
            {
                MessageBox.Show("No data for attendance report!");
                return;
            }

            DataTable sourceTable = (DataTable)dgvStudents.DataSource;
            DataTable attendanceTable = new DataTable();

            // Fixed columns
            attendanceTable.Columns.Add("No", typeof(int));
            attendanceTable.Columns.Add("RollNo", typeof(string));
            attendanceTable.Columns.Add("FullName", typeof(string));

            // 15 Day columns
            for (int day = 1; day <= 15; day++)
                attendanceTable.Columns.Add(day.ToString("00"), typeof(string));

            // Fill data
            int no = 1;
            foreach (DataRow row in sourceTable.Rows)
            {
                DataRow newRow = attendanceTable.NewRow();
                newRow["No"] = no++;
                newRow["RollNo"] = row["RollNo"];
                newRow["FullName"] = row["FullName"];

                for (int day = 1; day <= 15; day++)
                    newRow[day.ToString("00")] = "";

                attendanceTable.Rows.Add(newRow);
            }

            reportData = attendanceTable;
            currentRow = 0;

            // သီးသန့် PrintDocument သို့ assign
            printPreviewDialog1.Document = printDocumentAttendance;
            printPreviewDialog1.ShowDialog();
        }

        //private void btnReport_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void btnPrint_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void button1_Click_1(object sender, EventArgs e)
        //{

        //}
    }
}