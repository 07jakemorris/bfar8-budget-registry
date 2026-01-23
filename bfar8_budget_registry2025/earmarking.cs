using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using Org.BouncyCastle.Asn1.BC;
using Org.BouncyCastle.Bcpg.OpenPgp;
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
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;
using static System.Net.Mime.MediaTypeNames;

namespace bfar8_budget_registry2025
{
    public partial class earmarking : Form
    {
        //Database configuration
        public static string connString = "server=localhost;port=3306;user id=root;password=;database=db_bfar8;";

        //To be used to automatically generate a Particulars for earmark -->
        public static string purpose;
        public static string initialParticular;

        private string department_code;
        private string agency_code;
        private string operating_unit;
        private string lower_operating_unit;

        private string fund_cluster;
        private string financing_source;
        private string authorization_code;
        private string funding_code;

        public static string project_code;
        public static string category_code;
        public static string sub_category_code;
        private string expense_class_id;
        private string expense_category_id;
        private string account_code_id;
        private string selectedAccountCode;

        public earmarking()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!validInputs())
            {
                MessageBox.Show("Please fill in all required input fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            earmark(fund_cluster, financing_source, authorization_code, funding_code, department_code, agency_code,
                    operating_unit, lower_operating_unit);
        }
        private void earmarking_Load(object sender, EventArgs e)
        {
            getDepartmentCode();
            getResponsibilityCenter();
            getEndUsers();
            getProject();
            getFundingCategory();
            getExpenseClass();
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

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT code
                        FROM tbl_program_projects WHERE code = @Code AND hasProjectCategory = 1
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Code", project_code);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                getProjectCategory(project_code);
                            }
                            else
                            {
                                txtProjectInput2.Items.Add("No Project Category");
                                txtProjectInput2.SelectedIndex = 0;
                                getProjectSubCateg(project_code);
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
            txtProjectInput3.Items.Clear();
            txtProjectInput4.Items.Clear();

            string projectCategory = txtProjectInput2.Text;

            if (string.IsNullOrWhiteSpace(projectCategory) || !projectCategory.Contains("-"))
                return; // skip invalid text

            string codePart = projectCategory.Split('-')[0].Trim();
            category_code = codePart;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT categoryCode
                        FROM tbl_project_categ WHERE categoryCode = @CategoryCode
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryCode", category_code);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                getProjectSubCateg(project_code);
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
        private void txtProjectInput3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProjectInput4.Items.Clear();

            string projectSubCategory = txtProjectInput3.Text;

            if (string.IsNullOrWhiteSpace(projectSubCategory) || !projectSubCategory.Contains("-"))
                return; // skip invalid text

            string codePart = projectSubCategory.Split('-')[0].Trim();
            sub_category_code = codePart;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT subCategoryCode
                        FROM tbl_project_sub_categ WHERE subCategoryCode = @SubCategoryCode
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SubCategoryCode", sub_category_code);
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
            }
        }
        private void txtExpensesClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtExpensesType.Items.Clear();
            txtAccountCode.Items.Clear();
            txtSubAccountCode.Items.Clear();
            string expenseClass = txtExpensesClass.Text;

            if (string.IsNullOrWhiteSpace(expenseClass) || !expenseClass.Contains("-"))
                return;

            string codePart = expenseClass.Split('-')[0].Trim();
            expense_class_id = codePart;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT id
                        FROM tbl_class_expenses WHERE id = @SelectedID
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SelectedID", expense_class_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
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
        private void txtExpensesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAccountCode.Items.Clear();
            txtSubAccountCode.Items.Clear();
            string expenseCategory = txtExpensesType.Text;

            if (string.IsNullOrWhiteSpace(expenseCategory) || !expenseCategory.Contains("-"))
                return;

            string codePart = expenseCategory.Split('-')[0].Trim();
            expense_category_id = codePart;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT id
                        FROM tbl_expenses_category WHERE id = @SelectedCategoryID
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(@"SelectedCategoryID", expense_category_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                getAccountCode(expense_category_id);
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

        private void txtAccountCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSubAccountCode.Items.Clear();
            string selectedAccount = txtAccountCode.Text;

            if (string.IsNullOrWhiteSpace(selectedAccount) || !selectedAccount.Contains("-"))
                return;

            string codePart = selectedAccount.Split(new string[] { " - " }, StringSplitOptions.None)[0];
            selectedAccountCode = codePart;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT id 
                        FROM tbl_account_codes WHERE hasSubAccountCode = 1 AND codeNo = @selectedAccountCode
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedAccountCode", selectedAccountCode);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                account_code_id = reader["id"].ToString();
                                getSubAccountCode(account_code_id);
                            }
                            else
                            {
                                txtSubAccountCode.Items.Add("- No Sub Account Code -");
                                txtSubAccountCode.SelectedIndex = 0;
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

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            txtAmount.Text = "";
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

        //----------------------------------------------------------|
        // Functions & Methods Declared at the Bottom Line ->       |
        //----------------------------------------------------------|

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

            // For Fund Category Combobox -->
            txtFundCluster.DropDownStyle = ComboBoxStyle.DropDownList;
            txtFundCluster.IntegralHeight = false;
            txtFundCluster.DropDownHeight = 250;
            txtFundCluster.MaxDropDownItems = 10;

            // For Expense Class Combobox -->
            txtExpensesType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtExpensesType.IntegralHeight = false;
            txtExpensesType.DropDownHeight = 250;
            txtExpensesType.MaxDropDownItems = 10;

            // For Account Code Combobox -->
            txtAccountCode.DropDownStyle = ComboBoxStyle.DropDownList;
            txtAccountCode.IntegralHeight = false;
            txtAccountCode.DropDownHeight = 250;
            txtAccountCode.MaxDropDownItems = 10;

            // For Sub Account Code Combobox -->
            txtSubAccountCode.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSubAccountCode.IntegralHeight = false;
            txtSubAccountCode.DropDownHeight = 250;
            txtSubAccountCode.MaxDropDownItems = 10;
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
        private void getProject()
        {
            txtProjectInput1.Items.Clear();
            txtProjectInput1.Items.Add("- Select Program / Project -");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT *
                        FROM tbl_program_projects
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string code = reader["code"].ToString();
                                string name = reader["programs_projects"].ToString();
                                txtProjectInput1.Items.Add($"{code} - {name}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            txtProjectInput1.SelectedIndex = 0;
        }
        private void getProjectCategory(string project_code)
        {
            txtProjectInput2.Items.Clear();
            txtProjectInput2.Items.Add("- Select Project Category -");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT *
                        FROM tbl_project_categ WHERE project_code = @ProjectCode
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProjectCode", project_code);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string code = reader["categoryCode"].ToString();
                                string name = reader["projectCategory"].ToString();
                                txtProjectInput2.Items.Add($"{code} - {name}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            txtProjectInput2.SelectedIndex = 0;
        }
        private void getProjectSubCateg(string project_code)
        {
            txtProjectInput3.Items.Clear();
            
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT subCategoryCode, subCategory
                        FROM tbl_project_sub_categ WHERE project_code = @ProjectCode
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProjectCode", project_code);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            txtProjectInput3.Items.Add("- Select Project Sub Category -");
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string code = reader["subCategoryCode"].ToString();
                                    string name = reader["subCategory"].ToString();
                                    txtProjectInput3.Items.Add($"{code} - {name}");
                                }
                            }                  
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            txtProjectInput3.SelectedIndex = 0;
        }
        private void getActivity(string sub_category_code)
        {
            txtProjectInput4.Items.Clear();
            txtProjectInput4.Items.Add("- Select Activity -");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT *
                        FROM tbl_activity WHERE project_sub_category_code = @ProjectSubCategoryCode
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProjectSubCategoryCode", sub_category_code);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string code = reader["activity_code"].ToString();
                                string name = reader["activity_name"].ToString();
                                txtProjectInput4.Items.Add($"{code} - {name}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            txtProjectInput4.SelectedIndex = 0;
        }
        private void getFundingCategory()
        {
            txtFundCluster.Items.Clear();
            txtFundCluster.Items.Add("- Select Funding Category -");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT *
                        FROM tbl_fund_cluster
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtFundCluster.Items.Add(reader["fund_category"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }
            txtFundCluster.SelectedIndex = 0;
        }
        private void getExpenseClass()
        {
            txtExpensesClass.Items.Clear();
            txtExpensesClass.Items.Add("- Select Class Expense -");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT *
                        FROM tbl_class_expenses
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["id"].ToString();
                                string name = reader["name"].ToString();
                                txtExpensesClass.Items.Add($"{id} - {name}");
                            }
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
        private void getExpenseType(string expense_class_id)
        {
            txtExpensesType.Items.Clear();
            txtExpensesType.Items.Add("- Select Expense Category -");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT id, expenses_category
                        FROM tbl_expenses_category WHERE expenses_class_id = @ExpensesClassID
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ExpensesClassID", expense_class_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["id"].ToString();
                                string name = reader["expenses_category"].ToString();
                                txtExpensesType.Items.Add($"{id} - {name}");
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
        private void getAccountCode(string expense_category_id)
        {
            txtAccountCode.Items.Clear();
            txtAccountCode.Items.Add("- Select Account Code -");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT codeNo, accountName
                        FROM tbl_account_codes WHERE expensesCategoryID = @ExpenseCategoryID
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ExpenseCategoryID", expense_category_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["codeNo"].ToString();
                                string name = reader["accountName"].ToString();
                                txtAccountCode.Items.Add($"{id} - {name}");
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
        private void getSubAccountCode(string account_code_id)
        {
            txtSubAccountCode.Items.Clear();
            txtSubAccountCode.Items.Add("- Select Sub Account Code -");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT subAccountCode, subAccountName
                        FROM tbl_sub_account_codes WHERE accountCodeID = @AccountCodeID
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AccountCodeID", account_code_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["subAccountCode"].ToString();
                                string name = reader["subAccountName"].ToString();
                                txtSubAccountCode.Items.Add($"{id} - {name}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            txtSubAccountCode.SelectedIndex = 0;
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
        private void earmark(string fund_cluster, string financing_source, string authorization_code,
                            string funding_code, string department_code, string agency_code, 
                            string operating_unit, string lower_operating_unit)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();          
                    //Breaking down the datetimepicker value into 3 parts month, day and year -->
                    string month = "";
                    string day = "";
                    string year = "";
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

                    string query = @"
                        INSERT INTO tbl_earmarks 
                        (month, day, year, quarter, pr_no, particulars, fund_cluster, financing_source, authorization_code, fund_category, full_funding_code,
                        department_code, agency_code, operating_unit_classification, lower_level_unit, responsibility_center, signatory, position, program_project,
                        project_category, project_sub_category, activity_level, expense_class, expense_type, account_code, amount_earmarked)
                        VALUES
                        (@Month, @Day, @Year, @Quarter, @PRNo, @Particulars, @FundCluster, @FinancingSource, @AuthorizationCode, @FundCategory, @FullFundingCode,
                        @DepartmentCode, @AgencyCode, @OperatingUnitClassification, @LowerLevelUnit, @ResponsibilityCenter, @Signatory, @Position, @ProgramProject,
                        @ProjectCategory, @ProjectSubCategory, @ActivityLevel, @ExpenseClass, @ExpenseType, @AccountCode, @AmountEarmarked)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@Day", day);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@Quarter", txtQuarter.Text);
                        cmd.Parameters.AddWithValue("@PRNo", txtPRNo.Text);
                        cmd.Parameters.AddWithValue("@Particulars", txtParticulars.Text);
                        cmd.Parameters.AddWithValue("@FundCluster", fund_cluster);
                        cmd.Parameters.AddWithValue("@FinancingSource", financing_source);
                        cmd.Parameters.AddWithValue("@AuthorizationCode", authorization_code);
                        cmd.Parameters.AddWithValue("@FundCategory", txtFundCluster.Text);
                        cmd.Parameters.AddWithValue("@FullFundingCode", funding_code);
                        cmd.Parameters.AddWithValue("@DepartmentCode", department_code);
                        cmd.Parameters.AddWithValue("@AgencyCode", agency_code);
                        cmd.Parameters.AddWithValue("@OperatingUnitClassification", operating_unit);
                        cmd.Parameters.AddWithValue("@LowerLevelUnit", lower_operating_unit);
                        cmd.Parameters.AddWithValue("@ResponsibilityCenter", txtResponsibilityCenter.Text);
                        cmd.Parameters.AddWithValue("@Signatory", txtEndUser.Text);
                        cmd.Parameters.AddWithValue("@Position", txtPosition.Text);
                        cmd.Parameters.AddWithValue("@ProgramProject", txtProjectInput1.Text);
                        cmd.Parameters.AddWithValue("@ProjectCategory", txtProjectInput2.Text);
                        cmd.Parameters.AddWithValue("@ProjectSubCategory", txtProjectInput3.Text);
                        cmd.Parameters.AddWithValue("@ActivityLevel", txtProjectInput4.Text);
                        cmd.Parameters.AddWithValue("@ExpenseClass", txtExpensesClass.Text);
                        cmd.Parameters.AddWithValue("@ExpenseType", txtExpensesType.Text);

                        //Concatenate Function for Account Code
                        string accountCodeValue;
                        if (txtSubAccountCode.Text == "- No Sub Account Code -")
                        {
                            accountCodeValue = txtAccountCode.Text.Trim();
                        }
                        else
                        {
                            // Parent account
                            string parentRaw = txtAccountCode.Text.Trim();
                            var parentParts = parentRaw.Split(new[] { " - " }, 2, StringSplitOptions.None);
                            string parentName = parentParts.Length > 1 ? parentParts[1].Trim() : "";

                            // Sub account
                            string subRaw = txtSubAccountCode.Text.Trim();
                            var subParts = subRaw.Split(new[] { " - " }, 2, StringSplitOptions.None);
                            string subCode = subParts[0].Trim();
                            string subName = subParts.Length > 1 ? subParts[1].Trim() : "";

                            accountCodeValue = $"{subCode} - {parentName} - {subName}";
                        }
                        cmd.Parameters.Add("@AccountCode", MySqlDbType.VarChar).Value = accountCodeValue;
                        // Safely parse amount
                        decimal amount = 0;
                        decimal.TryParse(txtAmount.Text, out amount);
                        cmd.Parameters.AddWithValue("@AmountEarmarked", amount);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("PR earmarks successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private bool validInputs()
        {
            bool isValid =
                !string.IsNullOrWhiteSpace(txtParticulars.Text) &&
                txtEndUser.SelectedIndex != 0 &&
                txtPosition.SelectedIndex != 0 &&
                txtResponsibilityCenter.SelectedIndex != 0 &&
                txtProjectInput1.SelectedIndex != 0 &&
                txtProjectInput3.SelectedIndex != 0 &&
                txtFundCluster.SelectedIndex != 0 &&
                txtExpensesClass.SelectedIndex != 0 &&
                txtExpensesType.SelectedIndex != 0 &&
                txtAccountCode.SelectedIndex != 0 &&
                txtAmount.Text != "0.00";

            return isValid;
        }
        private void clearAllInputFields()
        {
            txtParticulars.Clear();
            // Use try-catch or condition checks to avoid "ArgumentOutOfRangeException"
            if (txtEndUser.Items.Count > 0) txtEndUser.SelectedIndex = 0;
            if (txtResponsibilityCenter.Items.Count > 0) txtResponsibilityCenter.SelectedIndex = 0;
            if (txtPosition.Items.Count > 0) txtPosition.SelectedIndex = 0;
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
    }
}
