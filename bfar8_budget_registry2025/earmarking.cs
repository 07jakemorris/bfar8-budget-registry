using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bfar8_budget_registry2025
{
    public partial class earmarking : Form
    {
        //Database configuration
        public static string connString = "server=localhost;port=3306;user id=root;password=;database=db_bfar8;";

        public earmarking()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }
        private void earmarking_Load(object sender, EventArgs e)
        {

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string keyword = txtPRNo.Text;
                string query = @"
                    SELECT *
                    FROM tbl_prs
                    WHERE pr_number LIKE @search
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
                    }
                }
            }
        }
    }
}
