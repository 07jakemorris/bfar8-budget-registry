using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static bfar8_budget_registry2025.viewRegistry;

namespace bfar8_budget_registry2025
{
    public partial class viewDetails : Form
    {
        //Database configuration
        public static string connString = "server=localhost;port=3306;user id=root;password=;database=db_bfar8;";

        private string viewObligationID;

        public viewDetails()
        {
            InitializeComponent();
            viewObligationID = SharedData.selectedIDToView;
        }

        private void viewDetails_Load(object sender, EventArgs e)
        {
            getData(viewObligationID);
            // Color pallete from html to use -->
            Color darkBlue = ColorTranslator.FromHtml("#2A3F55");
            topPanel.BackColor = darkBlue;
            bottomPanel.BorderColor = darkBlue;
            projectHighlight.FillColor = darkBlue;
            projectLabel.BackColor = darkBlue;
            fundingHighlight.FillColor = darkBlue;
            fundingLabel.BackColor = darkBlue;
        }
        private void getData(string viewObligationID)
        {
            string getData = "SELECT * FROM tbl_obligations WHERE id = @selectedID";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(getData, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedID", viewObligationID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblORSNo.Text = reader["orsNo"].ToString();
                                string monthStr = reader["month"].ToString();
                                string dayStr = reader["day"].ToString();
                                string yearStr = reader["year"].ToString();

                                if (int.TryParse(dayStr, out int day) &&
                                    int.TryParse(yearStr, out int year))
                                {
                                    try
                                    {
                                        int monthNum = DateTime
                                            .ParseExact(monthStr, "MMMM", CultureInfo.InvariantCulture)
                                            .Month;
                                        DateTime fullDate = new DateTime(year, monthNum, day);
                                        lblObligDate.Text = fullDate.ToString("MMMM dd, yyyy");
                                    }
                                    catch
                                    {
                                        MessageBox.Show($"Invalid date: {monthStr} {dayStr}, {yearStr}");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Invalid date parts: Year '{yearStr}', Month '{monthStr}', Day '{dayStr}'");
                                }
                                lblCreditor.Text = reader["creditorType"].ToString();
                                lblResCenter.Text = reader["responsibility_center"].ToString();
                                lblSignatory.Text = reader["signatory"].ToString();
                                lblPosition.Text = reader["position"].ToString();
                                if (decimal.TryParse(reader["obligations_incurred"]?.ToString(), out decimal amount))
                                {
                                    lblTotalAmount.Text = amount.ToString("N2");
                                }
                                else
                                {
                                    lblTotalAmount.Text = "0.00";
                                }
                                lblProject.Text = reader["program_project"].ToString();
                                lblCategory.Text = reader["project_category"].ToString();
                                lblSubCategory.Text = reader["project_sub_category"].ToString();
                                lblActivity.Text = reader["activity_level"].ToString();
                                lblFundCluster.Text = reader["fund_cluster"].ToString();
                                lblFinancingSource.Text = reader["financing_source"].ToString();
                                lblAuthCode.Text = reader["authorization_code"].ToString();
                                lblFundCategory.Text = reader["fund_category"].ToString();
                                lblExpenseClass.Text = reader["expense_class"].ToString();
                                lblAccountCode.Text = reader["account_code"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }
        }
    }
}
