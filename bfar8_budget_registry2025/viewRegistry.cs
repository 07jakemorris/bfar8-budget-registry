using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bfar8_budget_registry2025
{
    public partial class viewRegistry : Form
    {
        //Database configuration
        public static string connString = "server=localhost;port=3306;user id=root;password=;database=db_bfar8;";


        public viewRegistry()
        {
            InitializeComponent();
        }
        public static class SharedData
        {
            public static string selectedIDToEdit;
            public static string selectedIDToPrint;
            public static string selectedIDToView;
        }


        private void viewRegistry_Load(object sender, EventArgs e)
        {
            SetupGridColumns();
            getObligations();
            obligationsTable.Paint += obligationsTable_Paint;
        }

        private void SetupGridColumns()
        {
            obligationsTable.AutoGenerateColumns = false;

            obligationsTable.Columns["id"].DataPropertyName = "id";
            obligationsTable.Columns["month"].DataPropertyName = "month";
            obligationsTable.Columns["day"].DataPropertyName = "day";
            obligationsTable.Columns["year"].DataPropertyName = "year";
            obligationsTable.Columns["orsNo"].DataPropertyName = "orsNo";
            obligationsTable.Columns["payee"].DataPropertyName = "payee";
            obligationsTable.Columns["particulars"].DataPropertyName = "particulars";        
            obligationsTable.Columns["responsibility_center"].DataPropertyName = "responsibility_center";
            obligationsTable.Columns["signatory"].DataPropertyName = "signatory";
            obligationsTable.Columns["position"].DataPropertyName = "position";
            obligationsTable.Columns["obligations_incurred"].DataPropertyName = "obligations_incurred";
            amountFormat();
        }

        private void amountFormat()
        {
            obligationsTable.Columns["obligations_incurred"].DefaultCellStyle.Format = "N2";
            obligationsTable.Columns["obligations_incurred"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void addActionButtons()
        {
            // Edit button
            if (!obligationsTable.Columns.Contains("edit"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "edit";
                editBtn.HeaderText = "Edit";
                editBtn.Text = "Edit";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 50;
                obligationsTable.Columns.Add(editBtn);
            }

            // View button
            if (!obligationsTable.Columns.Contains("view"))
            {
                DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
                viewBtn.Name = "view";
                viewBtn.HeaderText = "View";
                viewBtn.Text = "View";
                viewBtn.UseColumnTextForButtonValue = true;
                viewBtn.Width = 50;
                obligationsTable.Columns.Add(viewBtn);
            }

            // Print button
            if (!obligationsTable.Columns.Contains("print"))
            {
                DataGridViewButtonColumn printBtn = new DataGridViewButtonColumn();
                printBtn.Name = "print";
                printBtn.HeaderText = "Print";
                printBtn.Text = "Print";
                printBtn.UseColumnTextForButtonValue = true;
                printBtn.Width = 50;
                obligationsTable.Columns.Add(printBtn);
            }
        }
        private void obligationsTable_Paint(object sender, PaintEventArgs e)
        {
            // Get rectangles for all 3 button columns
            Rectangle rEdit = obligationsTable.GetCellDisplayRectangle(obligationsTable.Columns["edit"].Index, -1, true);
            Rectangle rView = obligationsTable.GetCellDisplayRectangle(obligationsTable.Columns["view"].Index, -1, true);
            Rectangle rPrint = obligationsTable.GetCellDisplayRectangle(obligationsTable.Columns["print"].Index, -1, true);

            // Combine into one rectangle
            Rectangle mergedHeader = new Rectangle(
                rEdit.Left,
                rEdit.Top,
                rPrint.Right - rEdit.Left,
                rEdit.Height
            );

            // Draw background
            e.Graphics.FillRectangle(Brushes.DarkGreen, mergedHeader);
            e.Graphics.DrawRectangle(Pens.Black, mergedHeader);

            // Draw text centered
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Create semi-bold font
            using (Font headerFont = new Font("Futura Md BT", 9, FontStyle.Bold))

                e.Graphics.DrawString("Action",
            obligationsTable.ColumnHeadersDefaultCellStyle.Font,
            Brushes.White, 
            mergedHeader,
            format);
        }

        private void getObligations()
        {
            string query = "SELECT * FROM tbl_obligations";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {              
                try
                {
                    conn.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        da.Fill(dataTable);

                        obligationsTable.DataSource = dataTable;
                        addActionButtons();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void obligationsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header clicks

            // EDIT button
            if (obligationsTable.Columns[e.ColumnIndex].Name == "edit")
            {
                // Get hidden ID
                SharedData.selectedIDToEdit = obligationsTable.Rows[e.RowIndex].Cells["id"].Value.ToString();
                editObligation editForm = new editObligation();
                dashboard.Instance.LoadForm(editForm);
            }

            // PRINT button
            else if (obligationsTable.Columns[e.ColumnIndex].Name == "print")
            {
                // Get the ID or data to print
                SharedData.selectedIDToPrint = obligationsTable.Rows[e.RowIndex].Cells["id"].Value.ToString();
                ORSForm orsForm = new ORSForm();
                orsForm.ShowDialog();
            }

            // PRINT button
            else if (obligationsTable.Columns[e.ColumnIndex].Name == "view")
            {
                // Get the ID or data to print
                SharedData.selectedIDToView = obligationsTable.Rows[e.RowIndex].Cells["id"].Value.ToString();
                viewDetails viewDetails = new viewDetails();
                viewDetails.ShowDialog();
            }

        }
    }
}
