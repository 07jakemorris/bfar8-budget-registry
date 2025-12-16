using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontAwesome.Sharp;
using System.Windows.Forms;

namespace bfar8_budget_registry2025
{
    public partial class dashboard : Form
    {
        public static dashboard Instance;

        public dashboard()
        {
            InitializeComponent();
            Instance = this;
        }

        public void LoadForm(Form form)
        {
            // Clear existing controls
            if (panelMain.Controls.Count > 0)
                panelMain.Controls.RemoveAt(0);

            // Setup form inside panel
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            panelMain.Tag = form;
            form.Show();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            Color darkBlue = ColorTranslator.FromHtml("#2A3F55");
            panelMenu.BackColor = darkBlue;
            btnInsert.FillColor = darkBlue;
            btnHome.FillColor = darkBlue;
            btnView.FillColor = darkBlue;
            btnEarmarks.FillColor = darkBlue;
            btnManage.FillColor = darkBlue;
            panelTop.FillColor = darkBlue;
            MakePictureCircular(logoPic);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            hideHighlight();
            insertObligationHighlight.Visible = true; 
            LoadForm(new insertRegistry());
        }
        private void MakePictureCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
            pictureBox.Region = new Region(path);
        }

        private void dateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss tt");
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            hideHighlight();
            viewHighlight.Visible = true;

            LoadForm(new viewRegistry());
        }

        private void btnManage_Click_1(object sender, EventArgs e)
        {
            hideHighlight();
            manageHighlight.Visible = true;
        }
        private void btnEarmarks_Click(object sender, EventArgs e)
        {
            hideHighlight();
            insertEarmarkHighlight.Visible = true;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            hideHighlight();
            homeHighlight.Visible = true;
        }

        private void hideHighlight()
        {
            homeHighlight.Visible = false;
            insertObligationHighlight.Visible = false;
            insertEarmarkHighlight.Visible = false;
            viewHighlight.Visible = false;
            manageHighlight.Visible = false;
        }
    }
}
