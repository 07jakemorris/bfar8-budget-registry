using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bfar8_budget_registry2025
{
    public partial class earmarking : Form
    {
        //Database configuration
        public static string connString = "server=localhost;port=3306;user id=root;password=;database=db_bfar8;";

        //To be used to automatically generate a Particulars for earmark -->
        public static string purpose;
        public static string initialParticular;


        public earmarking()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }
        private void earmarking_Load(object sender, EventArgs e)
        {         
            getResponsibilityCenter();
            getEndUsers();
            comboBoxSettings();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getPRNo();
            getTotalLot();
            getPRDetails(purpose);
        }
        private void txtLotNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPRDetails(purpose);
        }
        private void comboBoxSettings()
        {
            // For Responsibility Center Combobox -->
            txtResponsibilityCenter.DropDownStyle = ComboBoxStyle.DropDownList;
            txtResponsibilityCenter.IntegralHeight = false;
            txtResponsibilityCenter.DropDownHeight = 250;
            txtResponsibilityCenter.MaxDropDownItems = 10;

            // For End User Combobox -->
            txtEndUser.DropDownStyle = ComboBoxStyle.DropDownList;
            txtEndUser.IntegralHeight = false;
            txtEndUser.DropDownHeight = 250;
            txtEndUser.MaxDropDownItems = 10;

            // For Position Combobox -->
            txtPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPosition.IntegralHeight = false;
            txtPosition.DropDownHeight = 250;
            txtPosition.MaxDropDownItems = 10;

        }
        private void getEndUsers()
        {
            txtEndUser.Items.Clear();
            txtPosition.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT *
                        FROM tbl_end_user
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtEndUser.Items.Add(reader["signatory"].ToString());
                                txtPosition.Items.Add(reader["position"].ToString());
                            }                          
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void getResponsibilityCenter()
        {
            txtResponsibilityCenter.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT *
                        FROM tbl_responsibility_center
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtResponsibilityCenter.Items.Add(reader["name"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void getPRNo()
        {
            //Fetching if PR No. Exist -->
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string keyword = txtPRNo.Text;
                string query = @"
                    SELECT pr_no
                    FROM tbl_prs
                    WHERE pr_no LIKE @search
                    ";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + keyword + "%");
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtPRNo.Text = reader["pr_no"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No PR number found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private void getTotalLot()
        {
            txtLotNo.Items.Clear();
            //Fetch PRs total lot -->
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = @"
                    SELECT lot_no, purpose
                    FROM tbl_prs
                    WHERE pr_no LIKE @PRNo
                    ";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PRNo", txtPRNo.Text);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtLotNo.Items.Add(reader["lot_no"].ToString());
                            purpose = reader["purpose"].ToString();
                        }
                    }
                }
            }
        }

        private void getPRDetails(string purpose)
        {
            //Fetch PR details and assign it in each input for earmarking -->
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM tbl_prs
                    WHERE pr_no = @PRNo AND lot_no = @LotNo
                    ";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PRNo", txtPRNo.Text);
                    cmd.Parameters.AddWithValue("@LotNo", txtLotNo.Text);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            initialParticular = reader["particulars"].ToString();
                            txtParticulars.Text = "Procurement of " + initialParticular + " for " + purpose;
                            string RC = reader["responsibility_center"].ToString();
                            txtResponsibilityCenter.SelectedItem = RC;
                            string user = reader["end_user"].ToString();
                            txtEndUser.SelectedItem = user;
                            string position = reader["position"].ToString();
                            txtPosition.SelectedItem = position;              
                            txtAmount.Text = Convert.ToDecimal(reader["amount"]).ToString("N2");         
                        }
                    }
                }
            }
        }
        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                txtAmount.Text = "0.00";
                return;
            }

            if (decimal.TryParse(txtAmount.Text, out decimal value))
            {
                txtAmount.Text = value.ToString("N2");
            }
            else
            {
                txtAmount.Text = "0.00";
            }
        }
    }
}
