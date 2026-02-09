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
        private string responsibility_center;
        private string expense_class;
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
                                FROM tbl_obligations ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void getExpenseClass()
        {

        }
    }
}
