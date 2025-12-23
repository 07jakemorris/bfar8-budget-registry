using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Resultset;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bfar8_budget_registry2025
{
    public partial class insertRegistry : Form
    {
        //Database configuration
        public static string connString = "server=localhost;port=3306;user id=root;password=;database=db_bfar8;";


        public static string newOrsNo;

        public static string department_code;
        public static string agency_code;
        public static string operating_unit;
        public static string lower_operating_unit;

        //For Project Category and Sub Category -->
        public static string project_code;
        public static string category_code;
        public static string sub_category_code;

        //For position of each signatory -->
        public static string position;

        //For funding source code -->
        public static string fund_cluster;
        public static string financing_source;
        public static string authorization_code;
        public static string funding_category;
        public static string funding_code;

        //For accounting details global variable -->
        public static string expense_class_id;
        public static string expense_type_id;
        public static string selectedAccountID;
        public static string accountID;

        private string payeeName;

        //List for Responsibility Center
        private List<(string Name, string Type)> allCenters = new List<(string, string)>();

        private bool isAutoFilling = false;
        private string suggestedText = "";

        public insertRegistry()
        {
            InitializeComponent();
        }

        private void getQuarter()
        {
            int month = txtDate.Value.Month;
            string quarter = "";

            if (month >= 1 && month <= 3)
                quarter = "1st Quarter";
            else if (month >= 4 && month <= 6)
                quarter = "2nd Quarter";
            else if (month >= 7 && month <= 9)
                quarter = "3rd Quarter";
            else
                quarter = "4th Quarter";

            txtQuarter.SelectedItem = quarter;
        }

        private void comboboxSetting()
        {
            //For signatory combo box
            txtSignatory.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSignatory.IntegralHeight = false;
            txtSignatory.DropDownHeight = 250;
            txtSignatory.MaxDropDownItems = 10;

            //For responsibility center combo box
            txtResponsibilityCenter.DropDownStyle = ComboBoxStyle.DropDownList;
            txtResponsibilityCenter.IntegralHeight = false;
            txtResponsibilityCenter.DropDownHeight = 250;
            txtResponsibilityCenter.MaxDropDownItems = 10;

            //For expenses type combo box
            txtExpensesType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtExpensesType.IntegralHeight = false;
            txtExpensesType.DropDownHeight = 180;
            txtExpensesType.MaxDropDownItems = 8;

            //For account code combo box
            txtAccountCode.DropDownStyle = ComboBoxStyle.DropDownList;
            txtAccountCode.IntegralHeight = false;
            txtAccountCode.DropDownHeight = 250;
            txtAccountCode.MaxDropDownItems = 10;
        }

        private void insertRegistry_Load(object sender, EventArgs e)
        {
            // Color pallete from html to use -->
            Color darkBlue = ColorTranslator.FromHtml("#2A3F55");
            txtDate.FillColor = darkBlue;
            comboboxSetting();
            getDepartmentCode();
            getQuarter();
            getSignatory();
            getResCenter();
            getProject();
            getProjectCategory(project_code);
            getFundCluster();
            getExpensesType();
            loadOrsNo(newOrsNo);     
        }
        
        private void getDepartmentCode()
        {
            
            string query = "SELECT department_code, agency_code, operating_unit, lower_operating_unit FROM tbl_department_code";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        department_code = reader["department_code"].ToString();
                        agency_code = reader["agency_code"].ToString();
                        operating_unit = reader["operating_unit"].ToString();
                        lower_operating_unit = reader["lower_operating_unit"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void getSignatory()
        {
            txtSignatory.Items.Add("- Select Signatory -");
            string query = "SELECT signatory FROM tbl_end_user";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtSignatory.Items.Add(reader["signatory"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            txtSignatory.SelectedIndex = 0;
        }
        private void getResCenter()
        {
            txtResponsibilityCenter.Items.Add("- Select Responsibility Center -");
            string query = "SELECT name FROM tbl_responsibility_center";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtResponsibilityCenter.Items.Add(reader["name"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            txtResponsibilityCenter.SelectedIndex = 0;
        }       
        private void txtDate_ValueChanged(object sender, EventArgs e)
        {
            int month = txtDate.Value.Month;
            string quarter = "";

            if (month >= 1 && month <= 3)
                quarter = "1st Quarter";
            else if (month >= 4 && month <= 6)
                quarter = "2nd Quarter";
            else if (month >= 7 && month <= 9)
                quarter = "3rd Quarter";
            else
                quarter = "4th Quarter";

            txtQuarter.SelectedItem = quarter;
        }

        private void getProject()
        {
            txtProjectInput1.Items.Add("- Select Program / Project -");
            string query = "SELECT code, programs_projects FROM tbl_program_projects";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string code = reader["code"].ToString();
                        string name = reader["programs_projects"].ToString();

                        txtProjectInput1.Items.Add($"{code} - {name}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            txtProjectInput1.SelectedIndex = 0;
        }
        private void getProjectCategory(string project_code)
        {
            txtProjectInput2.Items.Clear();
            string query = "SELECT categoryCode, projectCategory FROM tbl_project_categ WHERE project_code = @projectCode";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@projectCode", project_code);
                        conn.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            txtProjectInput2.Items.Add("- Select Project Category -");

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string code = reader["categoryCode"].ToString();
                                    string name = reader["projectCategory"].ToString();
                                    txtProjectInput2.Items.Add($"{code} - {name}");
                                }
                                txtProjectInput2.SelectedIndex = 0;
                            }
                            else
                            {
                                txtProjectInput2.Items.Add("- No Project Category -");

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }   
        }

        private void txtProjectInput1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProjectInput2.Items.Clear();
            txtProjectInput3.Items.Clear();
            txtProjectInput4.Items.Clear();

            string project = txtProjectInput1.Text;

            if (string.IsNullOrWhiteSpace(project) || !project.Contains("-"))
                return; // skip invalid text

            string codePart = project.Split('-')[0].Trim();
            project_code = codePart;

            string fetch = "SELECT code FROM tbl_program_projects WHERE code = @selectedCode AND hasProjectCategory = 1";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(fetch, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedCode", codePart);

                        // ✅ Use ExecuteReader instead of ExecuteNonQuery
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // ✅ Only call this if data exists
                                getProjectCategory(project_code);
                            }
                            else
                            {
                                txtProjectInput2.Items.Clear();
                                txtProjectInput2.Items.Add("No Project Category");
                                txtProjectInput2.SelectedIndex = 0;
                                getSubCategory(project_code);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void getSubCategory(string category_code)
        {
            txtProjectInput3.Items.Clear();
            string query = "SELECT subCategoryCode, subCategory FROM tbl_project_sub_categ WHERE project_code = @projectCode";  
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@projectCode", project_code);                
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            txtProjectInput3.Items.Add("- Select Sub Project Category -");

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string code = reader["subCategoryCode"].ToString();
                                    string name = reader["subCategory"].ToString();
                                    txtProjectInput3.Items.Add($"{code} - {name}");
                                }
                                txtProjectInput3.SelectedIndex = 0;
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

        private void txtProjectInput2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProjectInput4.Items.Clear();
            txtProjectInput3.Items.Clear();

            string category = txtProjectInput2.Text;

            if (string.IsNullOrWhiteSpace(category) || !category.Contains("-"))
                return; // skip invalid text

            string categoryCode = category.Split('-')[0].Trim();
            category_code = categoryCode;

            string fetch = "SELECT categoryCode FROM tbl_project_categ WHERE categoryCode = @selectedCode";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(fetch, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedCode", categoryCode);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                getSubCategory(category_code);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txtProjectInput3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProjectInput4.Items.Clear();

            string subCategoryCode = txtProjectInput3.Text;

            if (string.IsNullOrWhiteSpace(subCategoryCode) || !subCategoryCode.Contains("-"))
                return; // skip invalid text

            string fetchedSubCategoryCode = subCategoryCode.Split('-')[0].Trim();
            sub_category_code = fetchedSubCategoryCode;

            string fetch = "SELECT subCategoryCode FROM tbl_project_sub_categ WHERE project_code = @selectedCode";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(fetch, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedCode", project_code);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                getActivity(sub_category_code);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void getActivity(string sub_category_code)
        {
            txtProjectInput4.Items.Clear();
            string query = "SELECT activity_code, activity_name FROM tbl_activity WHERE project_sub_category_code = @projectSubCategory";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@projectSubCategory", sub_category_code);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            txtProjectInput4.Items.Add("- Select Activity -");

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string code = reader["activity_code"].ToString();
                                    string name = reader["activity_name"].ToString();
                                    txtProjectInput4.Items.Add($"{code} - {name}");
                                }
                                txtProjectInput4.SelectedIndex = 0;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void getFundCluster()
        {
            txtFundCluster.Items.Clear();
            string fetch = "SELECT fund_category FROM tbl_fund_cluster";
            
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(fetch, conn))
                    {
                        
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            txtFundCluster.Items.Add("- Select Funding Category -");

                            while (reader.Read())
                            {
                                txtFundCluster.Items.Add(reader["fund_category"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            txtFundCluster.SelectedIndex = 0;
        }

        // This is to set automatically all the funding source code according to their categories -->
        private void txtFundCluster_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getFund = "SELECT fund_cluster, financing_source, authorization_code, full_funding_code FROM tbl_fund_cluster WHERE fund_category = @selectedFundCategory";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(getFund, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedFundCategory", txtFundCluster.Text.ToString());
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                fund_cluster = reader["fund_cluster"].ToString();
                                financing_source = reader["financing_source"].ToString();
                                authorization_code = reader["authorization_code"].ToString();
                                funding_code = reader["full_funding_code"].ToString();
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

        private void getExpensesType()
        {
            txtExpensesClass.Items.Clear();
            txtExpensesClass.Items.Add("- Select Expense Class -");
            string fetch = "SELECT id, name FROM tbl_class_expenses";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(fetch, conn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string id = reader["id"].ToString();
                            string name = reader["name"].ToString();
                            txtExpensesClass.Items.Add($"{id} - {name}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            txtExpensesClass.SelectedIndex = 0;
        }

        private void txtExpensesClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtExpensesType.Items.Clear();
            txtAccountCode.Items.Clear();

            string selectedExpenseClass = txtExpensesClass.Text;

            if (string.IsNullOrWhiteSpace(selectedExpenseClass) || !selectedExpenseClass.Contains("-"))
                return; // skip invalid text

            expense_class_id = selectedExpenseClass.Split('-')[0].Trim();

            string fetchExpenseType = "SELECT id FROM tbl_class_expenses WHERE id = @selectedExpenseClass";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(fetchExpenseType, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedExpenseClass", expense_class_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                getExpenseType(expense_class_id);
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
        private void getExpenseType(string expense_class_id)
        {
            txtExpensesType.Items.Clear();
            txtExpensesType.Items.Add("- Select Expenses Type -");
            string fetchExpenseType = "SELECT id, expenses_category FROM tbl_expenses_category WHERE expenses_class_id = @selectedExpensesClass";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(fetchExpenseType, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedExpensesClass", expense_class_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["id"].ToString();
                                string expenseName = reader["expenses_category"].ToString();
                                txtExpensesType.Items.Add($"{id} - {expenseName}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            txtExpensesType.SelectedIndex = 0;
        }

        private void txtExpensesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAccountCode.Items.Clear();

            string selectedExpenseType = txtExpensesType.Text;

            if (string.IsNullOrWhiteSpace(selectedExpenseType) || !selectedExpenseType.Contains("-"))
                return; // skip invalid text

            expense_type_id = selectedExpenseType.Split('-')[0].Trim();

            string fetchExpenseType = "SELECT id FROM tbl_expenses_category WHERE id = @selectedExpenseType";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(fetchExpenseType, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedExpenseType", expense_type_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                getAccountCode(expense_type_id);
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

        private void getAccountCode(string expense_type_id)
        {
            txtAccountCode.Items.Clear();
            txtAccountCode.Items.Add("- Select Account Code -");        
            string fetchAccountCode = "SELECT codeNo, accountName FROM tbl_account_codes WHERE expensesCategoryID = @selectedExpensesType";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(fetchAccountCode, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedExpensesType", expense_type_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string code = reader["codeNo"].ToString();
                                string account = reader["accountName"].ToString();
                                txtAccountCode.Items.Add($"{code} - {account}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            txtAccountCode.SelectedIndex = 0;
        }

        private void txtAccountCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAccountCode = txtAccountCode.Text;

            if (string.IsNullOrWhiteSpace(selectedAccountCode) || !selectedAccountCode.Contains("-"))
                return; // skip invalid text

            selectedAccountID = selectedAccountCode.Split(new string[] { " - " }, StringSplitOptions.None)[0];

            string fetchSubAccountCode = "SELECT id FROM tbl_account_codes WHERE hasSubAccountCode = 1 AND codeNo = @selectedAccountID";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(fetchSubAccountCode, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedAccountID", selectedAccountID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                accountID = reader["id"].ToString();                               
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

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && (sender as Guna.UI2.WinForms.Guna2TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                txtAmount.Text = "0.00";
                return;
            }

            if (decimal.TryParse(txtAmount.Text, out decimal value))
            {
                txtAmount.Text = value.ToString("N2"); // e.g. 12,000.00
            }
            else
            {
                txtAmount.Text = "0.00";
            }
        }
        private void txtAmount_Enter(object sender, EventArgs e)
        {
            txtAmount.Text = "";
        }

        private void insertObligation(string fund_cluster, string financing_source, string authorization_code, 
            string funding_code, string department_code, string agency_code, string operating_unit, string lower_operating_unit, string position)
        {
            //Check for creditor type -->
            string creditorType = "";
            string month = "";
            string day = "";
            string year = "";
            if (btnExternalCred.Checked == true)
            {
                creditorType = "External Creditor";
            }
            else
            {
                creditorType = "Internal Creditor";
            }
            //Breaks down txtDate value to Month, Day and Year -->
            string dateText = txtDate.Text;

            if (DateTime.TryParse(dateText, out DateTime parsedDate))
            {
                month = parsedDate.ToString("MMMM");
                day = parsedDate.Day.ToString("00");    
                year = parsedDate.Year.ToString();   
            }
            else
            {
                MessageBox.Show("Invalid date format. Please enter a valid date (e.g., 10/17/2025 10:26 AM).");
            }

            //Insert obligation command -->
            string insertQuery = @"INSERT INTO `tbl_obligations`
            (`month`, `day`, `year`, `quarter`, `orsNo`, `payee`, `creditorType`, `particulars`,
            `fund_cluster`, `financing_source`, `authorization_code`, `fund_category`, `full_funding_code`,
            `department_code`, `agency_code`, `operating_unit_classification`, `lower_level_unit`,
            `responsibility_center`, `signatory`, `position`, `program_project`, `project_category`,
            `project_sub_category`, `activity_level`, `expense_class`, `expense_type`, `account_code`, `obligations_incurred`)
            VALUES (@month, @day, @year, @quarter, @orsNo, @payee, @creditorType, @particulars,
            @fundCluster, @financingSource, @authorizationCode, @fundCategory, @fullFundingCode,
            @departmentCode, @agencyCode, @operatingUnit, @lowerUnit, @responsibilityCenter,
            @signatory, @position, @project, @projectCategory, @projectSubCategory, @activityLevel,
            @expenseClass, @expenseType, @accountCode, @obligationsIncurred)";


            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@day", day);
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@quarter", txtQuarter.Text);
                        cmd.Parameters.AddWithValue("@orsNo", txtORSNo.Text);
                        cmd.Parameters.AddWithValue("@payee", txtPayee.Text);
                        cmd.Parameters.AddWithValue("@creditorType", creditorType);
                        cmd.Parameters.AddWithValue("@particulars", txtParticulars.Text);
                        cmd.Parameters.AddWithValue("@fundCluster", fund_cluster);
                        cmd.Parameters.AddWithValue("@financingSource", financing_source);
                        cmd.Parameters.AddWithValue("@authorizationCode", authorization_code);
                        cmd.Parameters.AddWithValue("@fundCategory", txtFundCluster.Text);
                        cmd.Parameters.AddWithValue("@fullFundingCode", funding_code);
                        cmd.Parameters.AddWithValue("@departmentCode", department_code);
                        cmd.Parameters.AddWithValue("@agencyCode", agency_code);
                        cmd.Parameters.AddWithValue("@operatingUnit", operating_unit);
                        cmd.Parameters.AddWithValue("@lowerUnit", lower_operating_unit);
                        cmd.Parameters.AddWithValue("@responsibilityCenter", txtResponsibilityCenter.Text);
                        cmd.Parameters.AddWithValue("@signatory", txtSignatory.Text);
                        cmd.Parameters.AddWithValue("@position", position);
                        cmd.Parameters.AddWithValue("@project", txtProjectInput1.Text);
                        cmd.Parameters.AddWithValue("@projectCategory", txtProjectInput2.Text);
                        cmd.Parameters.AddWithValue("@projectSubCategory", txtProjectInput3.Text);
                        cmd.Parameters.AddWithValue("@activityLevel", txtProjectInput4.Text);
                        cmd.Parameters.AddWithValue("@expenseClass", txtExpensesClass.Text);
                        cmd.Parameters.AddWithValue("@expenseType", txtExpensesType.Text);
                        cmd.Parameters.AddWithValue("@accountCode", txtAccountCode.Text);

                        // Safely parse amount
                        decimal amount = 0;
                        decimal.TryParse(txtAmount.Text, out amount);
                        cmd.Parameters.AddWithValue("@obligationsIncurred", amount);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Checks if Payee or Creditor already exist or not then it will save to database -->
                            if (!PayeeExists(txtPayee.Text))
                            {
                                InsertPayee(txtPayee.Text);
                            }
                            clearAllInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Insert failed — no rows were affected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        bool PayeeExists(string payeeName)
        {
            if (string.IsNullOrWhiteSpace(payeeName))
                return false;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string query = @"SELECT 1
                         FROM tbl_payee
                         WHERE name = @Name
                         LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", payeeName.Trim());

                    object result = cmd.ExecuteScalar();
                    return result != null;
                }
            }
        }
        void InsertPayee(string payeeName)
        {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string query = @"INSERT INTO tbl_payee (`name`) 
                         VALUES (@name)";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", payeeName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {   
            if (!validInputs())
            {
                MessageBox.Show("Please fill in all required input fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            insertObligation(fund_cluster, financing_source, authorization_code, funding_code, department_code, agency_code, operating_unit, lower_operating_unit, position);         
        }

        private bool validInputs()
        {
            bool isValid =
                !string.IsNullOrWhiteSpace(txtPayee.Text) &&
                !string.IsNullOrWhiteSpace(txtParticulars.Text) &&
                txtSignatory.SelectedIndex != 0 &&
                txtResponsibilityCenter.SelectedIndex != 0 &&
                txtProjectInput1.SelectedIndex != 0 &&
                txtProjectInput3.SelectedIndex != 0 &&
                txtProjectInput4.SelectedIndex != 0 &&
                txtFundCluster.SelectedIndex != 0 &&
                txtExpensesClass.SelectedIndex != 0 &&
                txtExpensesType.SelectedIndex != 0 &&
                txtAccountCode.SelectedIndex != 0 &&
                txtAmount.Text != "0.00";

                return isValid;
        }

        private void txtSignatory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getSignatoryPosition = "SELECT position FROM tbl_end_user WHERE signatory = @name";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(getSignatoryPosition, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtSignatory.Text);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                position = reader["position"].ToString();
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

        //To generate Ors No. automatically -->
        private string GenerateNextOrsNo()
        {
            string latestOrsNo = "";
            string newOrsNo = "";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // Get the most recent ORsNo
                string query = "SELECT orsNo FROM tbl_obligations ORDER BY id DESC LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        latestOrsNo = result.ToString();
                }

                if (string.IsNullOrEmpty(latestOrsNo))
                {
                    string yearPrefix = DateTime.Now.ToString("yy");
                    string month = DateTime.Now.ToString("MM");
                    newOrsNo = $"{yearPrefix}-{month}-0001";
                }
                else
                {
                    // Split the latest ORsNo
                    string[] parts = latestOrsNo.Split('-');
                    if (parts.Length == 3)
                    {
                        string yearPrefix = parts[0];
                        string currentMonth = DateTime.Now.ToString("MM");
                        int lastNumber = int.Parse(parts[2]);
                        lastNumber++; // Increment

                        // Combine new ORsNo
                        newOrsNo = $"{yearPrefix}-{currentMonth}-{lastNumber:D4}";
                    }
                    else
                    {
                        throw new Exception("Invalid ORsNo format in database.");
                    }
                }
            }
            return newOrsNo;
        }
        
        private void loadOrsNo(string newOrsNo)
        {
            newOrsNo = GenerateNextOrsNo();
            txtORSNo.Text = newOrsNo;
        }
        private void clearAllInputFields()
        {
            txtPayee.Clear();
            txtParticulars.Clear();

            // Use try-catch or condition checks to avoid "ArgumentOutOfRangeException"
            if (txtSignatory.Items.Count > 0) txtSignatory.SelectedIndex = 0;
            if (txtResponsibilityCenter.Items.Count > 0) txtResponsibilityCenter.SelectedIndex = 0;
            if (txtProjectInput1.Items.Count > 0) txtProjectInput1.SelectedIndex = 0;
            if (txtProjectInput2.Items.Count > 0) txtProjectInput2.SelectedIndex = 0;
            if (txtProjectInput3.Items.Count > 0) txtProjectInput3.SelectedIndex = 0;
            if (txtProjectInput4.Items.Count > 0) txtProjectInput4.SelectedIndex = 0;
            if (txtFundCluster.Items.Count > 0) txtFundCluster.SelectedIndex = 0;
            if (txtExpensesClass.Items.Count > 0) txtExpensesClass.SelectedIndex = 0;
            if (txtExpensesType.Items.Count > 0) txtExpensesType.SelectedIndex = 0;
            if (txtAccountCode.Items.Count > 0) txtAccountCode.SelectedIndex = 0;

            txtAmount.Text = "0.00";
        }

        private void editORS_Click(object sender, EventArgs e)
        {
            if (txtORSNo.ReadOnly && editORS.Text == "Edit ORS")
            {
                editORS.Text = "Save";
                txtORSNo.ReadOnly = false;
            }
            else if (!txtORSNo.ReadOnly && editORS.Text == "Save")
            {
                editORS.Text = "Edit ORS";
                txtORSNo.ReadOnly = true;
            }
        }

        private void txtPayee_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && txtPayee.SelectionLength > 0)
            {
                txtPayee.SelectionStart = txtPayee.Text.Length;
                txtPayee.SelectionLength = 0;

                e.SuppressKeyPress = true;
            }
        }
        //This function checks the payee and auto complete if exist -->
        string GetSuggestedName(string input)
        {
            string result = null;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string query = @"SELECT name 
                         FROM tbl_payee
                         WHERE name LIKE @Name
                         ORDER BY name
                         LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", input + "%");

                    object value = cmd.ExecuteScalar();
                    if (value != null)
                        result = value.ToString();
                }
            }

            return result;
        }

        private void txtPayee_TextChanged(object sender, EventArgs e)
        {
            if (isAutoFilling) return;
            int cursorPos = txtPayee.SelectionStart;
            string typedText = txtPayee.Text;

            if (string.IsNullOrWhiteSpace(typedText))
                return;

            string match = GetSuggestedName(typedText);

            if (!string.IsNullOrEmpty(match) &&
                match.StartsWith(typedText, StringComparison.OrdinalIgnoreCase))
            {
                isAutoFilling = true;

                txtPayee.Text = match;
                txtPayee.SelectionStart = typedText.Length;
                txtPayee.SelectionLength = match.Length - typedText.Length;

                suggestedText = match;
                isAutoFilling = false;
            }
        }
    }
}
