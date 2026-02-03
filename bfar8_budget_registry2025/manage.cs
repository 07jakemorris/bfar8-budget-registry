using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;

namespace bfar8_budget_registry2025
{
    public partial class manage : Form
    {
        public manage()
        {
            InitializeComponent();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImportExcelToMySQL(ofd.FileName);
            }
        }
        private DataTable ReadExcel(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                });

                return result.Tables[0];
            }
        }
        private void ImportExcelToMySQL(string filePath)
        {
            DataTable dt = ReadExcel(filePath);

            using (MySqlConnection con = dbconn.GetConnection())
            {
                con.Open();
                using (MySqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        // Trim spaces and lowercase headers
                        foreach (DataColumn col in dt.Columns)
                        {
                            col.ColumnName = col.ColumnName.Trim().ToLower();
                        }
                        foreach (DataRow row in dt.Rows)
                        {
                            string sql = @"
                                 INSERT INTO tbl_obligations
                                 (month, day, year, quarter, orsNo, payee, creditorType, particulars, fund_cluster, financing_source, authorization_code, fund_category, full_funding_code,
                                 department_code, agency_code, operating_unit_classification, lower_level_unit, responsibility_center, signatory, position, program_project, project_category,
                                 project_sub_category, activity_level, expense_class, expense_type, account_code, obligations_incurred)
                                 VALUES
                                 (@month, @day, @year, @quarter, @orsNo, @payee, @creditorType, @particulars, @fund_cluster, @financing_source, @authorization_code, @fund_category, @full_funding_code,
                                 @department_code, @agency_code, @operating_unit_classification, @lower_level_unit, @responsibility_center, @signatory, @position, @program_project, @project_category,
                                 @project_sub_category, @activity_level, @expense_class, @expense_type, @account_code, @obligations_incurred)";

                            using (MySqlCommand cmd = new MySqlCommand(sql, con, tran))
                            {
                                cmd.Parameters.AddWithValue("@month", row["month"]);
                                cmd.Parameters.AddWithValue("@day", row["day"]);
                                cmd.Parameters.AddWithValue("@year", row["year"]);
                                cmd.Parameters.AddWithValue("@orsNo", row["orsno"]);
                                cmd.Parameters.AddWithValue("@payee", row["payee"]);
                                cmd.Parameters.AddWithValue("@creditorType", row["creditortype"]);
                                cmd.Parameters.AddWithValue("@particulars", row["particulars"]);
                                cmd.Parameters.AddWithValue("@fund_cluster", row["fund_cluster"]);
                                cmd.Parameters.AddWithValue("@financing_source", row["financing_source"]);
                                cmd.Parameters.AddWithValue("@authorization_code", row["authorization_code"]);
                                cmd.Parameters.AddWithValue("@fund_category", row["fund_category"]);
                                cmd.Parameters.AddWithValue("@full_funding_code", row["full_funding_code"]);
                                cmd.Parameters.AddWithValue("@department_code", row["department_code"]);
                                cmd.Parameters.AddWithValue("@agency_code", row["agency_code"]);
                                cmd.Parameters.AddWithValue("@operating_unit_classification", row["operating_unit_classification"]);
                                cmd.Parameters.AddWithValue("@lower_level_unit", row["lower_level_unit"]);
                                cmd.Parameters.AddWithValue("@responsibility_center", row["responsibility_center"]);
                                cmd.Parameters.AddWithValue("@signatory", row["signatory"]);
                                cmd.Parameters.AddWithValue("@position", row["position"]);
                                cmd.Parameters.AddWithValue("@program_project", row["program_project"]);
                                cmd.Parameters.AddWithValue("@project_category", row["project_category"]);
                                cmd.Parameters.AddWithValue("@project_sub_category", row["project_sub_category"]);
                                cmd.Parameters.AddWithValue("@activity_level", row["activity_level"]);
                                cmd.Parameters.AddWithValue("@expense_class", row["expense_class"]);
                                cmd.Parameters.AddWithValue("@expense_type", row["expense_type"]);
                                cmd.Parameters.AddWithValue("@account_code", row["account_code"]);
                                cmd.Parameters.AddWithValue("@obligations_incurred", row["obligations_incurred"]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        MessageBox.Show("Excel imported successfully!");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Import failed:\n" + ex.Message);
                    }
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            // Let the user select the Excel file
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = ReadExcel(ofd.FileName);

                // Build a string to show all columns
                string columnList = "Columns in Excel sheet:\n";
                foreach (DataColumn col in dt.Columns)
                {
                    // Show column name and its length to catch hidden spaces
                    columnList += $"'{col.ColumnName}' (length: {col.ColumnName.Length})\n";
                }

                // Show in a MessageBox
                MessageBox.Show(columnList, "Excel Columns");
            }
        }
    }
}
