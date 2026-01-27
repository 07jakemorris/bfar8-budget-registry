using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace bfar8_budget_registry2025
{
    public partial class login : Form
    {
        //Database configuration
        public static string connString = "server=localhost;port=3306;user id=root;password=;database=db_bfar8;";

        private string userID;

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
            lblTitle.ForeColor = darkBlue; 
        }
        public bool VerifyLogin(string userID, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
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
                    MessageBox.Show("Error verifying log in: " + ex.Message);
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
