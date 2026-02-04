using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bfar8_budget_registry2025
{
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
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
        }
    }
}
