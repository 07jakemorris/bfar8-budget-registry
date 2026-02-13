using System;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace bfar8_budget_registry2025
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private void login_Load(object sender, EventArgs e)
        {
            initializePropertyComponent();          
        }
        private void initializePropertyComponent()
        {
            Color darkBlue = ColorTranslator.FromHtml("#2A3F55");

            btnLogin.FillColor = darkBlue;
            lblTitle1.ForeColor = darkBlue;
            lblTitle2.ForeColor = darkBlue;
            lblDA.ForeColor = darkBlue;
            lblRO.ForeColor = darkBlue;
        }
        public bool VerifyLogin(string userID, string password)
        {
            using (MySqlConnection conn = dbconn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT *
                            FROM tbl_user_admin
                            WHERE user_id = @UserID
                            ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHashedPass = reader["hashed_password"].ToString();
                                string storedSalt = reader["salt_password"].ToString();
                                return passwordHelper.verifyPassword(password, storedHashedPass, storedSalt);
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text;
            string password = txtPassword.Text;

            if (VerifyLogin(userID, password))
            {
                dashboard Dashboard = new dashboard();
                txtUserID.Clear();
                txtPassword.Clear();
                this.Hide();
                Dashboard.Show();
            }
            else
            {
                MessageBox.Show("Incorrect User ID or Password, Try again!", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Clear();
                txtPassword.Clear();
            }
        }
        public static class passwordHelper
        {
            public static bool verifyPassword(string password, string storedHashedPass, string storedSalt)
            {
                //Generate a random 16-byte salt -->
                byte[] saltBytes = Convert.FromBase64String(storedSalt);
            
                // Use PBKDF2 to hash the password with the salt -->
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100000, HashAlgorithmName.SHA256))
                {
                    byte[] hash = pbkdf2.GetBytes(32);
                    string computedHash = Convert.ToBase64String(hash);
                    return computedHash == storedHashedPass;              
                }
            }
        }

        private void txtShowHidePass_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtShowHidePass.Text = "Hide password";
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtShowHidePass.Text = "Show password";
            }
        }
    }
}
