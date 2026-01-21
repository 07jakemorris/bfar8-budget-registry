using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static bfar8_budget_registry2025.viewRegistry;

namespace bfar8_budget_registry2025
{
    public partial class editObligation : Form
    {
        private string obligationID;
        public static string project_code;
        public static string category_code;
        public static string sub_category_code;

        //Database configuration
        public static string connString = "server=localhost;port=3306;user id=root;password=;database=db_bfar8;";

        public static string expense_category;
        public static string account_code;
        public static string expenseCategoryID;
        public editObligation()
        {
            InitializeComponent();
            obligationID = SharedData.selectedIDToEdit;
        }
        private void editObligation_Load(object sender, EventArgs e)
        {
            // Color pallete from html to use -->
            Color darkBlue = ColorTranslator.FromHtml("#2A3F55");
            txtDate.FillColor = darkBlue;
            comboBoxSettings();
            getAccountCodeValue(obligationID);
            getSignatory();
            getResCenter();
            getProject();
            getProjectCategory();
            getProjectSubCategory();
            getActivity();
            getFundCategory();
            getExpenseClass();
            getExpenseType();
            getAccountCode();
            getObligationToEdit(SharedData.selectedIDToEdit);               
        }
        private void comboBoxSettings()
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

            //For Project
            txtProjectInput1.DropDownStyle = ComboBoxStyle.DropDownList;
            txtProjectInput1.IntegralHeight = false;
            txtProjectInput1.DropDownHeight = 180;
            txtProjectInput1.MaxDropDownItems = 8;

            //For Project Category
            txtProjectInput2.DropDownStyle = ComboBoxStyle.DropDownList;
            txtProjectInput2.IntegralHeight = false;
            txtProjectInput2.DropDownHeight = 180;
            txtProjectInput2.MaxDropDownItems = 8;

            //For Project Sub Category
            txtProjectInput3.DropDownStyle = ComboBoxStyle.DropDownList;
            txtProjectInput3.IntegralHeight = false;
            txtProjectInput3.DropDownHeight = 180;
            txtProjectInput3.MaxDropDownItems = 8;

            //For Activity
            txtProjectInput4.DropDownStyle = ComboBoxStyle.DropDownList;
            txtProjectInput4.IntegralHeight = false;
            txtProjectInput4.DropDownHeight = 180;
            txtProjectInput4.MaxDropDownItems = 8;

            //For account code combo box
            txtAccountCode.DropDownStyle = ComboBoxStyle.DropDownList;
            txtAccountCode.IntegralHeight = false;
            txtAccountCode.DropDownHeight = 250;
            txtAccountCode.MaxDropDownItems = 10;
        }
        private void getAccountCodeValue(string obligationID)
        {
            string query = "SELECT account_code FROM tbl_obligations WHERE id = @selectedIDToEdit";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedIDToEdit", obligationID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtAccountCode.Items.Add(reader["account_code"].ToString());
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
        private void getSignatory()
        {
            string query = "SELECT signatory FROM tbl_end_user";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtSignatory.Items.Add(reader["signatory"].ToString());
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
        private void getResCenter()
        {
            string query = "SELECT name FROM tbl_responsibility_center";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
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
        private void getProject()
        {
            string query = "SELECT code, programs_projects FROM tbl_program_projects";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
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
        }
        private void getFilteredProjectCategory(string project_code)
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
            }
        }
        private void getProjectCategory()
        {
            string query = "SELECT categoryCode, projectCategory FROM tbl_project_categ;";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string code = reader["categoryCode"].ToString();
                                string name = reader["projectCategory"].ToString();
                                txtProjectInput3.Items.Add($"{code} - {name}");
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
        private void getProjectSubCategory()
        {
            string query = "SELECT subCategoryCode, subCategory FROM tbl_project_sub_categ";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void getFilteredSubCategory(string category_code)
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

        private void getActivity()
        {
            string query = "SELECT activity_code, activity_name FROM tbl_activity";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
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
        }
        private void getFilteredActivity(string sub_category_code)
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
            }
        }
        private void getFundCategory()
        {
            string query = "SELECT fund_category FROM tbl_fund_cluster";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
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
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void getExpenseClass()
        {
            string query = "SELECT id, name FROM tbl_class_expenses";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string code = reader["id"].ToString();
                                string name = reader["name"].ToString();
                                txtExpensesClass.Items.Add($"{code} - {name}");
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
        private void getExpenseType()
        {
            string query = "SELECT id, expenses_category FROM tbl_expenses_category";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string code = reader["id"].ToString();
                                string name = reader["expenses_category"].ToString();
                                txtExpensesType.Items.Add($"{code} - {name}");
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
        private void getAccountCode()
        {       
            string query = "SELECT codeNo, accountName FROM tbl_account_codes";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string code = reader["codeNo"].ToString();
                                string name = reader["accountName"].ToString();
                                txtAccountCode.Items.Add($"{code} - {name}");
                                txtAccountCode.SelectedIndex = 0;
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

        private void getObligationToEdit(string obligationID)
        {
            string query = "SELECT * FROM tbl_obligations WHERE id = @selectedObligationID";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedObligationID", obligationID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Setting the obligations to edit into input fields -->
                                txtORSNo.Text = reader["orsNo"].ToString();
                                string monthStr = reader["month"].ToString();
                                string dayStr = reader["day"].ToString();
                                string yearStr = reader["year"].ToString();

                                if (int.TryParse(dayStr, out int day) &&
                                    int.TryParse(yearStr, out int year))
                                {
                                    try
                                    {
                                        int monthNum = DateTime.ParseExact(monthStr, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month;

                                        DateTime fullDate = new DateTime(year, monthNum, day);
                                        txtDate.Value = fullDate;
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Invalid date: " + monthStr + "/" + dayStr + "/" + yearStr);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Invalid date parts: Year '{yearStr}', Month '{monthStr}', Day '{dayStr}'");
                                }

                                txtPayee.Text = reader["payee"].ToString();
                                // For creditor check buttons -->
                                string creditor = reader["creditorType"].ToString();
                                if (creditor == "Internal Creditor")
                                {
                                    btnInternalCred.Checked = true;
                                }
                                else
                                {
                                    btnExternalCred.Checked = true;
                                }
                                txtQuarter.Text = reader["quarter"].ToString();
                                txtParticulars.Text = reader["particulars"].ToString();
                                txtSignatory.Text = reader["signatory"].ToString();
                                txtResponsibilityCenter.Text = reader["responsibility_center"].ToString();
                                txtProjectInput1.Text = reader["program_project"].ToString();
                                string value = reader["project_category"].ToString();
                                if (!txtProjectInput2.Items.Contains(value))
                                {              
                                    txtProjectInput2.Items.Add(value);
                                }
                                txtProjectInput2.SelectedItem = value;
                                txtProjectInput3.Text = reader["project_sub_category"].ToString();
                                txtProjectInput4.Text = reader["activity_level"].ToString();
                                txtFundCluster.Text = reader["fund_category"].ToString();
                                txtExpensesClass.Text = reader["expense_class"].ToString();
                                txtExpensesType.Text = reader["expense_type"].ToString();
                                txtAccountCode.Text = reader["account_code"].ToString();
                                if (decimal.TryParse(reader["obligations_incurred"]?.ToString(), out decimal amount))
                                {
                                    txtAmount.Text = amount.ToString("N2");
                                }
                                else
                                {
                                    txtAmount.Text = "0.00";
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string creditorType = btnExternalCred.Checked ? "External Creditor" : "Internal Creditor";

            // Extract Date
            DateTime parsedDate = txtDate.Value;
            string month = parsedDate.ToString("MMMM");
            string day = parsedDate.Day.ToString("00");
            string year = parsedDate.Year.ToString();


            string updateQuery = "UPDATE tbl_obligations SET orsNo = @OrsNo, month = @Month, day = @Day, year = @Year, payee = @Payee, creditorType = @CreditorType, " +
                                     "quarter = @Quarter, particulars = @Particulars, signatory = @Signatory, responsibility_center = @ResponsibilityCenter, program_project = @ProgramProject, " +
                                     "project_category = @ProjectCategory, project_sub_category = @ProjectSubCategory, activity_level = @ActivityLevel, fund_category = @FundCategory, " +
                                     "expense_class = @ExpenseClass, expense_type = @ExpenseType, account_code = @AccountCode, obligations_incurred = @ObligationsIncurred WHERE id = @ID";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {                      
                        cmd.Parameters.AddWithValue("@OrsNo", txtORSNo.Text);
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@Day", day);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@Payee", txtPayee.Text);
                        cmd.Parameters.AddWithValue("@CreditorType", creditorType);
                        cmd.Parameters.AddWithValue("@Quarter", txtQuarter.Text);
                        cmd.Parameters.AddWithValue("@Particulars", txtParticulars.Text);
                        cmd.Parameters.AddWithValue("@Signatory", txtSignatory.Text);
                        cmd.Parameters.AddWithValue("@ResponsibilityCenter", txtResponsibilityCenter.Text);
                        cmd.Parameters.AddWithValue("@ProgramProject", txtProjectInput1.Text);
                        cmd.Parameters.AddWithValue("@ProjectCategory", txtProjectInput2.Text);
                        cmd.Parameters.AddWithValue("@ProjectSubCategory", txtProjectInput3.Text);
                        cmd.Parameters.AddWithValue("@ActivityLevel", txtProjectInput4.Text);
                        cmd.Parameters.AddWithValue("@FundCategory", txtFundCluster.Text);
                        cmd.Parameters.AddWithValue("@ExpenseClass", txtExpensesClass.Text);
                        cmd.Parameters.AddWithValue("@ExpenseType", txtExpensesType.Text);
                        cmd.Parameters.AddWithValue("@AccountCode", txtAccountCode.Text);
                        cmd.Parameters.AddWithValue("@ObligationsIncurred", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@ID", obligationID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data successfully updated!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearInputFields();
                            viewRegistry viewRegistry = new viewRegistry();
                            dashboard.Instance.LoadForm(viewRegistry);           
                        }
                        else
                        {
                            MessageBox.Show("Update failed. No record was changed.", "Retry", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtProjectInput1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProjectInput2.Items.Clear();
            txtProjectInput3.Items.Clear();
            txtProjectInput4.Items.Clear();

            string project = txtProjectInput1.Text;

            if (string.IsNullOrWhiteSpace(project) || !project.Contains("-"))
                return;

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
                                getFilteredProjectCategory(project_code);
                            }
                            else
                            {
                                txtProjectInput2.Items.Clear();
                                txtProjectInput2.Items.Add("No Project Category");
                                txtProjectInput2.SelectedIndex = 0;
                                getFilteredSubCategory(project_code);
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
                return;

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
                                getFilteredSubCategory(category_code);
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
                                getFilteredActivity(sub_category_code);
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
        private void clearInputFields()
        {
            txtORSNo.Clear();
            txtPayee.Clear();
            txtQuarter.Items.Clear();
            txtParticulars.Clear();
            txtSignatory.Items.Clear();
            txtResponsibilityCenter.Items.Clear();
            txtProjectInput1.Items.Clear();
            txtProjectInput2.Items.Clear();
            txtProjectInput3.Items.Clear();
            txtProjectInput4.Items.Clear();
            txtFundCluster.Items.Clear();
            txtExpensesClass.Items.Clear();
            txtExpensesType.Items.Clear();
            txtAccountCode.Items.Clear();
            txtAmount.Text = "0.00";
        }
    }
}
