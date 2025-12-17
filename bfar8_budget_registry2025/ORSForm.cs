using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfiumViewer;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using static bfar8_budget_registry2025.viewRegistry;

namespace bfar8_budget_registry2025
{
    public partial class ORSForm : Form
    {
        Bitmap panelBitmap;

        private string obligationIDToPrint;
        public ORSForm()
        {
            InitializeComponent();
            obligationIDToPrint = SharedData.selectedIDToPrint;
        }
        Bitmap CaptureControl(Control c)
        {
            Bitmap bmp = new Bitmap(c.Width, c.Height);
            c.DrawToBitmap(bmp, new Rectangle(0, 0, c.Width, c.Height));

            using (Graphics g = Graphics.FromImage(bmp))
            {
                IntPtr hdc = g.GetHdc();
                PrintWindow(c.Handle, hdc, 0);
                g.ReleaseHdc(hdc);
            }

            return bmp;
        }

        [DllImport("user32.dll")]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, int nFlags);

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Take screenshot of your panel
            panelBitmap = CaptureControl(ORSDocs);

            PrintDocument printDoc = new PrintDocument();

            // Use actual long bond size
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("LongBond", 850, 1300);
            printDoc.DefaultPageSettings.Landscape = false;
            printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            printDoc.OriginAtMargins = false;

            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.ShowDialog();
        }
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (panelBitmap != null)
            {
                // Calculate scaling to fit printable area
                Rectangle m = e.MarginBounds;

                float scaleX = (float)m.Width / panelBitmap.Width;
                float scaleY = (float)m.Height / panelBitmap.Height;
                float scale = Math.Min(scaleX, scaleY); // keep aspect ratio

                int width = (int)(panelBitmap.Width * scale);
                int height = (int)(panelBitmap.Height * scale);

                int left = m.Left + (m.Width - width) / 2;   // center horizontally
                int top = m.Top + (m.Height - height) / 2;  // center vertically

                e.Graphics.DrawImage(panelBitmap, left, top, width, height);
            }
            e.HasMorePages = false;

        }

        private void ORSForm_Load(object sender, EventArgs e)
        {
            panelLabelORS.Height = panelORSNo.Height;       
            btnPrint.Focus();
            //To print function -->
            getObligationToPrint(obligationIDToPrint);
            adjustBottomPanel();
            adjustHeight();
            comboBoxSettings();
            getSignatory();
        }
        private void getObligationToPrint(string obligationIDToPrint)
        {
            string query = "SELECT orsNo, payee, particulars, fund_category, responsibility_center, signatory, position, " +
                "program_project, project_sub_category, activity_level, expense_class, account_code, obligations_incurred FROM " +
                "tbl_obligations WHERE id = @obligationIDToPrint";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@obligationIDToPrint", obligationIDToPrint);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                                lblORSNo.Text = reader["orsNo"].ToString();
                                lblPayee.Text = reader["payee"].ToString();
                                lblResponsibility.Text = reader["responsibility_center"].ToString();
                                lblParticulars.Text = reader["particulars"].ToString();
                                lblFunding.Text = reader["fund_category"].ToString();
                                lblProject.Text = reader["program_project"].ToString();
                                lblSubProject.Text = reader["project_sub_category"].ToString();
                                lblActivity.Text = reader["activity_level"].ToString();
                                lblExpenseClass.Text = reader["expense_class"].ToString();
                                lblAccountCode.Text = reader["account_code"].ToString();
                                string iniAmount = reader["obligations_incurred"].ToString();
                                if (double.TryParse(iniAmount, out double amount))
                                {
                                    lblAmount.Text = amount.ToString("N2");
                                }
                                else
                                {
                                    lblAmount.Text = "0.00";
                                }
                                lblTotalAmount.Text = lblAmount.Text;
                                lblSignatory.Text = reader["signatory"].ToString();
                                lblPosition.Text = reader["position"].ToString();
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
            txtSignatory.Items.Clear();
            txtSignatory.Items.Add("- Select Signatory -");
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
            txtSignatory.SelectedIndex = 0;
        }
        private void comboBoxSettings()
        {
            //For signatory combo box
            //txtSignatory.DropDownStyle = ComboBoxStyle.DropDownList;
            //txtSignatory.IntegralHeight = false;
            //txtSignatory.DropDownHeight = 250;
            //txtSignatory.MaxDropDownItems = 10;
        }

        private void adjustBottomPanel()
        {
            bottomPanel.Location = new Point(
                bottomPanel.Location.X,
                fundingPanel.Location.Y + fundingPanel.Height
                );
        }

        private void adjustHeight()
        {
            particularPanel.Height = fundingPanel.Height;
            panelResponsibilityCenter.Height = fundingPanel.Height;
            amountPanel.Height = fundingPanel.Height;
        }

        private void fundingPanel_SizeChanged(object sender, EventArgs e)
        {
            // Keep bottomPanel attached
            bottomPanel.Location = new Point(
                bottomPanel.Location.X,
                fundingPanel.Location.Y + fundingPanel.Height
            );
        }

        private void assignSignatory()
        {
            string query = "SELECT signatory, position FROM tbl_end_user WHERE signatory = @Signatory";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Signatory", txtSignatory.Text);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblSignatory.Text = reader["signatory"].ToString();
                                lblPosition.Text = reader["position"].ToString();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit Signatory")
            {
                btnEdit.Text = "Save Edit";
                comboPanel.Visible = true;
            }
            else if (btnEdit.Text == "Save Edit")
            {
                if (txtSignatory.SelectedIndex == 0)
                {
                    MessageBox.Show("Error: Must select an end user before committing", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnEdit.Text = "Edit Signatory";
                    assignSignatory();
                    getSignatory();
                    comboPanel.Visible = false;
                }
            }
        }
    }
}
