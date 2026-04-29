using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace bfar8_budget_registry2025
{
    public partial class reports : Form
    {
        private int selected_fy_id;
        private int selected_ec_id;
        public reports()
        {
            InitializeComponent();

            AttachPanels();
            panel1.SizeChanged += (s, e) => AttachPanels();
            panel1.VisibleChanged += (s, e) => AttachPanels();
            this.Resize += (s, e) => AttachPanels();
        }

        private void reports_Load(object sender, EventArgs e)
        {
            initializePropertyComponents();
            loadingTimer.Start();
            loadFiscalYear();
            txtYear.SelectedIndex = 2;
        }
        private void initializePropertyComponents()
        {
            Color darkBlue = ColorTranslator.FromHtml("#2A3F55");
            lblReportTitle.ForeColor = darkBlue;
            label3.ForeColor = darkBlue;
            label4.ForeColor = darkBlue;
            label6.ForeColor = darkBlue;
            lblResCenter.ForeColor = darkBlue;
            lblGrandTotal.FillColor = darkBlue;
            lblAllotmentGrandTotal.FillColor = darkBlue;
            lblObligationGrandTotal.FillColor = darkBlue;
            lblDisbursementGrandTotal.FillColor = darkBlue;
            lblUnpaidGrandTotal.FillColor = darkBlue;
            lblEarmarkGrandTotal.FillColor = darkBlue;
            lblUnobligatedGrandTotal.FillColor = darkBlue;
            allotmentUIPanel.FillColor = darkBlue;
            obligationUIPanel.FillColor = darkBlue;
            disbursementUIPanel.FillColor = darkBlue;
            unpaidUIPanel.FillColor = darkBlue;
            earmarkUIPanel.FillColor = darkBlue;
            unobligatedUIPanel.FillColor = darkBlue;
            lblAllotmentUI.FillColor = darkBlue;
            lblObligationUI.FillColor = darkBlue;
            lblDisbursementUI.FillColor = darkBlue;
            lblUnpaidUI.FillColor = darkBlue;
            lblEarmarksUI.FillColor = darkBlue;
            lblUnobligatedUI.FillColor = darkBlue;
        }
        private void AttachPanels()
        {
            panel2.Top = panel1.Bottom
               - panel1.Margin.Bottom
               - panel2.Margin.Top;

            panel3.Top = panel2.Bottom
               - panel2.Margin.Bottom
               - panel3.Margin.Top;

            bottomPanel.Top = panel3.Bottom
               - panel3.Margin.Bottom
               - bottomPanel.Margin.Top;
        }
        private void loadFiscalYear()
        {
            using (MySqlConnection conn = dbconn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT year 
                                    FROM tbl_fiscal_year
                                    ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtYear.Items.Add(reader["year"].ToString());
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
        private void ResizePanelToContent()
        {
            int rowsHeight = table1.Rows
                .GetRowsHeight(DataGridViewElementStates.Visible);

            // Minimum height if no rows
            if (table1.Rows.Count == 0)
                rowsHeight = table1.RowTemplate.Height;

            table1.Height = rowsHeight;

            panel1.Height = lblResCenter.Height + rowsHeight;
        }
        private void getAccountCodes()
        {
            using (MySqlConnection conn = dbconn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT account_codes
                                    FROM tbl_obligations WHERE responsibility_center = @ResponsibilityCenter AND expense_class = @ExpenseClass
                                    ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ResponsibilityCenter", txtExpenseClass.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            btnUp.Visible = false;
            btnDown.Visible = true;
            panelExpenseClass.Height = 0;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            btnDown.Visible = false;
            btnUp.Visible = true;
            panelExpenseClass.Height = 117;
        }

        private void btnAllExpenseClass_Click(object sender, EventArgs e)
        {
            btnUp.Visible = false;
            btnDown.Visible = true;
            panelExpenseClass.Height = 0;
            txtExpenseClass.Text = btnAllExpenseClass.Text;
            getAllExpenseClassID();
        }

        private void btnPSClass_Click(object sender, EventArgs e)
        {
            btnUp.Visible = false;
            btnDown.Visible = true;
            panelExpenseClass.Height = 0;
            txtExpenseClass.Text = btnPSClass.Text;
            getExpenseClassID();
        }

        private void btnMOOEClass_Click(object sender, EventArgs e)
        {
            btnUp.Visible = false;
            btnDown.Visible = true;
            panelExpenseClass.Height = 0;
            txtExpenseClass.Text = btnMOOEClass.Text;
            getExpenseClassID();
        }

        private void btnCOClass_Click(object sender, EventArgs e)
        {
            btnUp.Visible = false;
            btnDown.Visible = true;
            panelExpenseClass.Height = 0;
            txtExpenseClass.Text = btnCOClass.Text;
            getExpenseClassID();
        }

        private void txtResponsibilityCenter_TextChanged(object sender, EventArgs e)
        {
            if (txtResponsibilityCenter.TextLength >= 1)
            {
                using (MySqlConnection conn = dbconn.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = @"SELECT name
                            FROM tbl_responsibility_center WHERE name LIKE ?
                            ";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("name", txtResponsibilityCenter.Text + "%");
                            DataTable dt = new DataTable();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            if (da != null && dt.Rows.Count > 0)
                            {
                                responsibilityCenterResult.DataSource = dt;
                                responsibilityCenterResult.Height = responsibilityCenterResult.Rows.Count * 30;
                            }
                            else
                            {
                                responsibilityCenterResult.Height = 0;
                            }
                            cmd.Dispose();
                            da.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else if (txtResponsibilityCenter.TextLength <= 0)
            {
                responsibilityCenterResult.Height = 0;
            }
        }

        private void responsibilityCenterResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.responsibilityCenterResult.Rows[e.RowIndex];
            txtResponsibilityCenter.Text = row.Cells["name"].Value.ToString();
            responsibilityCenterResult.Height = 0;
            getFYID();
            getData(selected_fy_id, selected_ec_id);
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            if (lblWait.Text == "Please wait.")
            {
                lblWait.Text = "Please wait..";
            }
            else if (lblWait.Text == "Please wait..")
            {
                lblWait.Text = "Please wait...";
            }
            else if (lblWait.Text == "Please wait...")
            {
                lblWait.Text = "Please wait.";
            }
        }
        private void getFYID()
        {
            using (MySqlConnection conn = dbconn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT fy_id 
                                    FROM tbl_fiscal_year
                                    WHERE year = @selectedYear
                                    ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedYear", txtYear.Text);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selected_fy_id = Convert.ToInt32(reader["fy_id"]);
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
        private void getExpenseClassID()
        {
            using (MySqlConnection conn = dbconn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT expense_class_id 
                                    FROM tbl_class_expenses
                                    WHERE name = @selectedExpense
                                    ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedExpense", txtExpenseClass.Text);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selected_ec_id = Convert.ToInt32(reader["name"]);
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
        private void getAllExpenseClassID()
        {
            using (MySqlConnection conn = dbconn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT expense_class_id 
                                    FROM tbl_class_expenses
                                    ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedExpense", txtExpenseClass.Text);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selected_ec_id = Convert.ToInt32(reader["name"]);
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

        //private void getData(string rcName, string expenseClass, string fiscalYear)
        private void getData(int selected_fy_id, int selected_ec_id)
        {
            using (MySqlConnection conn = dbconn.GetConnection())
            {
                try
                {
                    conn.Open();                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message);
                }
            }
        }
    }
}
