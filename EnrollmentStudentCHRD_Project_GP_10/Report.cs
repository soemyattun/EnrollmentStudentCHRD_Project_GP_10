

//using System;
//using System.Data;
//using System.Data.OleDb;
//using System.Drawing;
//using System.Drawing.Printing;
//using System.IO;
//using System.Windows.Forms;

//namespace EnrollmentStudentCHRD_Project_GP_10
//{
//    public partial class Report : Form
//    {
//        private DataTable reportData;
//        private int currentRow = 0;

//        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Soe Myat Tun\Downloads\StudentInfo1.accdb";

//        public Report()
//        {
//            InitializeComponent();
//            printDocument1.PrintPage += printDocument1_PrintPage;
//            printDocument1.BeginPrint += printDocument1_BeginPrint;
//        }

//        private void Report_Load(object sender, EventArgs e)
//        {
//            cboSemester.Items.Add("All");
//            cboSemester.Items.Add("1");
//            cboSemester.Items.Add("2");
//            cboSemester.Items.Add("3");
//            cboSemester.SelectedIndex = 0;

//            printPreviewDialog1.Document = printDocument1;

//            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
//            dgvStudents.ReadOnly = true;
//        }

//        private void btnLoad_Click(object sender, EventArgs e)
//        {
//            string batch = txtBatch.Text.Trim();
//            string rollNo = txtRollNo.Text.Trim();
//            int semester = 0;

//            if (cboSemester.SelectedIndex > 0)
//                semester = int.Parse(cboSemester.SelectedItem.ToString());

//            DataTable dt = new DataTable();

//            using (OleDbConnection con = new OleDbConnection(conStr))
//            {
//                con.Open();
//                string sql = "SELECT * FROM UserInfotable WHERE 1=1";

//                if (!string.IsNullOrEmpty(batch))
//                    sql += " AND Batch=?";
//                if (semester > 0)
//                    sql += " AND Semester=?";
//                if (!string.IsNullOrEmpty(rollNo))
//                    sql += " AND RollNo=?";

//                using (OleDbCommand cmd = new OleDbCommand(sql, con))
//                {
//                    if (!string.IsNullOrEmpty(batch))
//                        cmd.Parameters.AddWithValue("?", batch);
//                    if (semester > 0)
//                        cmd.Parameters.AddWithValue("?", semester);
//                    if (!string.IsNullOrEmpty(rollNo))
//                        cmd.Parameters.AddWithValue("?", rollNo);

//                    new OleDbDataAdapter(cmd).Fill(dt);
//                }
//            }

//            dgvStudents.DataSource = dt;
//        }

//        private void btnPreview_Click(object sender, EventArgs e)
//        {
//            if (dgvStudents.DataSource == null || dgvStudents.Rows.Count == 0)
//            {
//                MessageBox.Show("No data to preview");
//                return;
//            }

//            reportData = ((DataTable)dgvStudents.DataSource).Copy();
//            currentRow = 0;
//            printPreviewDialog1.ShowDialog();
//        }

//        private void btnPrint_Click(object sender, EventArgs e)
//        {
//            if (dgvStudents.DataSource == null || dgvStudents.Rows.Count == 0)
//            {
//                MessageBox.Show("No data to print");
//                return;
//            }

//            reportData = ((DataTable)dgvStudents.DataSource).Copy();
//            currentRow = 0;
//            printDocument1.Print();
//        }

//        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
//        {
//            printDocument1.DefaultPageSettings.Landscape = true;
//            currentRow = 0;
//        }

//        // ===== SAFE OLE IMAGE FUNCTION =====
//        private Image GetImageFromOle(byte[] oleData)
//        {
//            try
//            {
//                if (oleData == null || oleData.Length == 0)
//                    return null;

//                int headerIndex = 0;

//                for (int i = 0; i < oleData.Length - 1; i++)
//                {
//                    if (oleData[i] == 0xFF && oleData[i + 1] == 0xD8) break; // JPG
//                    if (oleData[i] == 0x89 && oleData[i + 1] == 0x50) break; // PNG
//                    if (oleData[i] == 0x42 && oleData[i + 1] == 0x4D) break; // BMP
//                    headerIndex++;
//                }

//                using (MemoryStream ms = new MemoryStream(oleData, headerIndex, oleData.Length - headerIndex))
//                {
//                    return Image.FromStream(ms);
//                }
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
//        {
//            if (reportData == null || reportData.Rows.Count == 0)
//                return;

//            int marginLeft = e.MarginBounds.Left;
//            int marginTop = e.MarginBounds.Top;
//            int pageWidth = e.MarginBounds.Width;
//            int pageHeight = e.MarginBounds.Height;

//            Font headerFont = new Font("Arial", 9, FontStyle.Bold);
//            Font dataFont = new Font("Arial", 8);

//            int colCount = reportData.Columns.Count;

//            int minColWidth = 80;
//            int colWidth = pageWidth / colCount;
//            if (colWidth < minColWidth)
//                colWidth = minColWidth;

//            int y = marginTop;

//            // ===== HEADER =====
//            for (int i = 0; i < colCount; i++)
//            {
//                Rectangle rect = new Rectangle(marginLeft + i * colWidth, y, colWidth, 30);

//                e.Graphics.FillRectangle(Brushes.LightGray, rect);
//                e.Graphics.DrawRectangle(Pens.Black, rect);
//                e.Graphics.DrawString(reportData.Columns[i].ColumnName,
//                                      headerFont, Brushes.Black, rect);
//            }

//            y += 30;

//            // ===== ROWS =====
//            while (currentRow < reportData.Rows.Count)
//            {
//                DataRow row = reportData.Rows[currentRow];
//                int rowHeight = 60;

//                // Dynamic height
//                for (int i = 0; i < colCount; i++)
//                {
//                    if (!reportData.Columns[i].ColumnName.ToLower().Contains("photo"))
//                    {
//                        string text = row[i]?.ToString() ?? "";
//                        SizeF size = e.Graphics.MeasureString(text, dataFont, colWidth);
//                        rowHeight = Math.Max(rowHeight, (int)size.Height + 10);
//                    }
//                }

//                for (int i = 0; i < colCount; i++)
//                {
//                    Rectangle cellRect = new Rectangle(
//                        marginLeft + i * colWidth,
//                        y,
//                        colWidth,
//                        rowHeight);

//                    e.Graphics.DrawRectangle(Pens.Black, cellRect);

//                    if (reportData.Columns[i].ColumnName.ToLower().Contains("photo"))
//                    {
//                        if (row[i] != DBNull.Value && row[i] is byte[])
//                        {
//                            Image img = GetImageFromOle((byte[])row[i]);

//                            if (img != null)
//                            {
//                                float ratio = Math.Min(
//                                    (float)cellRect.Width / img.Width,
//                                    (float)cellRect.Height / img.Height);

//                                int newWidth = (int)(img.Width * ratio);
//                                int newHeight = (int)(img.Height * ratio);

//                                int imgX = cellRect.X + (cellRect.Width - newWidth) / 2;
//                                int imgY = cellRect.Y + (cellRect.Height - newHeight) / 2;

//                                e.Graphics.DrawImage(img, imgX, imgY, newWidth, newHeight);
//                                img.Dispose();
//                            }
//                        }
//                    }
//                    else
//                    {
//                        string text = row[i]?.ToString() ?? "";
//                        e.Graphics.DrawString(text, dataFont, Brushes.Black, cellRect);
//                    }
//                }

//                y += rowHeight;
//                currentRow++;

//                if (y + rowHeight > marginTop + pageHeight)
//                {
//                    e.HasMorePages = true;
//                    return;
//                }
//            }

//            currentRow = 0;
//            e.HasMorePages = false;
//        }

//        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {

//        }
//    }
//}

using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace EnrollmentStudentCHRD_Project_GP_10
{
    public partial class Report : Form
    {
        private DataTable reportData;
        private int currentRow = 0;

        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Soe Myat Tun\Downloads\StudentInfo1.accdb";

        public Report()
        {
            InitializeComponent();
            printDocument1.PrintPage += printDocument1_PrintPage;
            printDocument1.BeginPrint += printDocument1_BeginPrint;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            cboSemester.Items.Add("All");
            cboSemester.Items.Add("1");
            cboSemester.Items.Add("2");
            cboSemester.Items.Add("3");
            cboSemester.SelectedIndex = 0;

            printPreviewDialog1.Document = printDocument1;

            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ReadOnly = true;
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

            dgvStudents.DataSource = dt;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvStudents.DataSource == null || dgvStudents.Rows.Count == 0)
            {
                MessageBox.Show("No data to print");
                return;
            }

            reportData = ((DataTable)dgvStudents.DataSource).Copy();
            currentRow = 0;

            printDocument1.Print();
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            currentRow = 0;
        }

        // ===== OLE SAFE IMAGE FUNCTION =====
        private Image GetImageFromOle(byte[] oleData)
        {
            try
            {
                if (oleData == null || oleData.Length == 0)
                    return null;

                int headerIndex = 0;

                for (int i = 0; i < oleData.Length - 1; i++)
                {
                    // JPEG
                    if (oleData[i] == 0xFF && oleData[i + 1] == 0xD8)
                    {
                        headerIndex = i;
                        break;
                    }
                    // PNG
                    if (oleData[i] == 0x89 && oleData[i + 1] == 0x50)
                    {
                        headerIndex = i;
                        break;
                    }
                    // BMP
                    if (oleData[i] == 0x42 && oleData[i + 1] == 0x4D)
                    {
                        headerIndex = i;
                        break;
                    }
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
            int colWidth = pageWidth / colCount;

            int y = marginTop;

            // ===== HEADER =====
            for (int i = 0; i < colCount; i++)
            {
                Rectangle rect = new Rectangle(marginLeft + i * colWidth, y, colWidth, 30);

                e.Graphics.FillRectangle(Brushes.LightGray, rect);
                e.Graphics.DrawRectangle(Pens.Black, rect);
                e.Graphics.DrawString(reportData.Columns[i].ColumnName,
                                      headerFont, Brushes.Black, rect);
            }

            y += 30;

            // ===== ROWS =====
            while (currentRow < reportData.Rows.Count)
            {
                DataRow row = reportData.Rows[currentRow];
                int rowHeight = 70;

                for (int i = 0; i < colCount; i++)
                {
                    Rectangle cellRect = new Rectangle(
                        marginLeft + i * colWidth,
                        y,
                        colWidth,
                        rowHeight);

                    e.Graphics.DrawRectangle(Pens.Black, cellRect);

                    if (reportData.Columns[i].ColumnName.ToLower() == "photo")
                    {
                        if (row[i] != DBNull.Value && row[i] is byte[])
                        {
                            Image img = GetImageFromOle((byte[])row[i]);

                            if (img != null)
                            {
                                float ratio = Math.Min(
                                    (float)cellRect.Width / img.Width,
                                    (float)cellRect.Height / img.Height);

                                int newWidth = (int)(img.Width * ratio);
                                int newHeight = (int)(img.Height * ratio);

                                int imgX = cellRect.X + (cellRect.Width - newWidth) / 2;
                                int imgY = cellRect.Y + (cellRect.Height - newHeight) / 2;

                                e.Graphics.DrawImage(img, imgX, imgY, newWidth, newHeight);
                            }
                        }
                    }
                    else
                    {
                        string text = row[i]?.ToString() ?? "";
                        e.Graphics.DrawString(text, dataFont, Brushes.Black, cellRect);
                    }
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

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}