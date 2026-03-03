namespace EnrollmentStudentCHRD_Project_GP_10
{
    partial class AdminDashboard
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.txtSemester = new System.Windows.Forms.TextBox();
            this.labRollNo = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblFemale = new System.Windows.Forms.Label();
            this.lblMale = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblBatch = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtRollNo = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.CadetBlue;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(1147, 132);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(126, 45);
            this.btnLogout.TabIndex = 16;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(698, 131);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(131, 43);
            this.button4.TabIndex = 13;
            this.button4.Text = "Refresh List";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(882, 68);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 35);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Tag = "BTN_DELETE";
            this.btnDelete.Text = "Delete Student";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(698, 60);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(131, 45);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Tag = "BTN_ADD";
            this.btnEdit.Text = "Edit Student";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 375);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1303, 636);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.txtSemester);
            this.panel1.Controls.Add(this.labRollNo);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.lblSemester);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.lblFemale);
            this.panel1.Controls.Add(this.lblMale);
            this.panel1.Controls.Add(this.txtFullName);
            this.panel1.Controls.Add(this.txtBatch);
            this.panel1.Controls.Add(this.lblBatch);
            this.panel1.Controls.Add(this.lblFullName);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.txtRollNo);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1303, 367);
            this.panel1.TabIndex = 18;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReport.Location = new System.Drawing.Point(698, 297);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(131, 46);
            this.btnReport.TabIndex = 33;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // txtSemester
            // 
            this.txtSemester.Location = new System.Drawing.Point(157, 136);
            this.txtSemester.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSemester.Multiline = true;
            this.txtSemester.Name = "txtSemester";
            this.txtSemester.Size = new System.Drawing.Size(170, 38);
            this.txtSemester.TabIndex = 32;
            // 
            // labRollNo
            // 
            this.labRollNo.AutoSize = true;
            this.labRollNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRollNo.Location = new System.Drawing.Point(352, 154);
            this.labRollNo.Name = "labRollNo";
            this.labRollNo.Size = new System.Drawing.Size(74, 22);
            this.labRollNo.TabIndex = 31;
            this.labRollNo.Text = "Roll No:";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(419, 308);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(141, 35);
            this.btnClear.TabIndex = 30;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemester.Location = new System.Drawing.Point(34, 154);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(91, 22);
            this.lblSemester.TabIndex = 29;
            this.lblSemester.Text = "Semester:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(415, 236);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 22);
            this.lblTotal.TabIndex = 28;
            this.lblTotal.Text = "Total:";
            // 
            // lblFemale
            // 
            this.lblFemale.AutoSize = true;
            this.lblFemale.Cursor = System.Windows.Forms.Cursors.Cross;
            this.lblFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFemale.Location = new System.Drawing.Point(230, 236);
            this.lblFemale.Name = "lblFemale";
            this.lblFemale.Size = new System.Drawing.Size(74, 22);
            this.lblFemale.TabIndex = 27;
            this.lblFemale.Text = "Female:";
            // 
            // lblMale
            // 
            this.lblMale.AutoSize = true;
            this.lblMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMale.Location = new System.Drawing.Point(69, 236);
            this.lblMale.Name = "lblMale";
            this.lblMale.Size = new System.Drawing.Size(53, 22);
            this.lblMale.TabIndex = 26;
            this.lblMale.Text = "Male:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(157, 52);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFullName.Multiline = true;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(170, 38);
            this.txtFullName.TabIndex = 25;
            this.txtFullName.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(432, 53);
            this.txtBatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBatch.Multiline = true;
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(170, 38);
            this.txtBatch.TabIndex = 24;
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatch.Location = new System.Drawing.Point(366, 71);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(61, 22);
            this.lblBatch.TabIndex = 22;
            this.lblBatch.Text = "Batch:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(34, 68);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(96, 22);
            this.lblFullName.TabIndex = 20;
            this.lblFullName.Text = "Full Name:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(184, 308);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(141, 35);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(882, 129);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(181, 45);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "Print Student Card";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtRollNo
            // 
            this.txtRollNo.Location = new System.Drawing.Point(432, 136);
            this.txtRollNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRollNo.Multiline = true;
            this.txtRollNo.Name = "txtRollNo";
            this.txtRollNo.Size = new System.Drawing.Size(170, 38);
            this.txtRollNo.TabIndex = 14;
            this.txtRollNo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 1011);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblFemale;
        private System.Windows.Forms.Label lblMale;
        private System.Windows.Forms.TextBox txtRollNo;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label labRollNo;
        private System.Windows.Forms.TextBox txtSemester;
        private System.Windows.Forms.Button btnReport;
    }
}