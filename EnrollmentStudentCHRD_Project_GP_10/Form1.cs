using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace EnrollmentStudentCHRD_Project_GP_10
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Soe Myat Tun\Documents\User_db.accdb;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Default language Myanmar
            SetLanguage("en");
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = textUserName.Text.Trim();
            string password = textPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    LocalizationService.GetString("LoginEmpty"),
                    LocalizationService.GetString("LoginTitle"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string role = AuthenticateUser(username, password);
            if (!string.IsNullOrEmpty(role))
            {
                MessageBox.Show(
                    LocalizationService.GetString("LoginSuccess"),
                    LocalizationService.GetString("LoginTitle"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Open dashboard non-modal
                OpenDashboard(role);

                this.Hide(); // hide login form
            }
            else
            {
                MessageBox.Show(
                    LocalizationService.GetString("LoginFail"),
                    LocalizationService.GetString("LoginTitle"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string AuthenticateUser(string username, string password)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                using (OleDbCommand cmd = new OleDbCommand("SELECT Role FROM LoginTable WHERE Username=? AND Password=?", con))
                {
                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", password);

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
                return null;
            }
        }

        private void OpenDashboard(string role)
        {
            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                using (AdminDashboard admin = new AdminDashboard())
                {
                    admin.ShowDialog();
                }
            }
            else
            {
                using (StudentInformation studentForm = new StudentInformation())
                {
                    studentForm.ShowDialog();
                }
            }
        }

        private void SetLanguage(string langCode)
        {
            try
            {
                LocalizationService.ApplyLanguage(this, langCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting language: " + ex.Message);
            }
        }

        private void btnMyanmar_Click(object sender, EventArgs e) => SetLanguage("my");
        private void btnEnglish_Click(object sender, EventArgs e) => SetLanguage("en");
    }
}
