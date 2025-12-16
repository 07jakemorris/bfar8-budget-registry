namespace bfar8_budget_registry2025
{
    partial class dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashboard));
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.dateTime = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsert = new Guna.UI2.WinForms.Guna2Button();
            this.btnEarmarks = new Guna.UI2.WinForms.Guna2Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.manageHighlight = new Guna.UI2.WinForms.Guna2Button();
            this.viewHighlight = new Guna.UI2.WinForms.Guna2Button();
            this.insertEarmarkHighlight = new Guna.UI2.WinForms.Guna2Button();
            this.insertObligationHighlight = new Guna.UI2.WinForms.Guna2Button();
            this.homeHighlight = new Guna.UI2.WinForms.Guna2Button();
            this.btnManage = new Guna.UI2.WinForms.Guna2Button();
            this.btnView = new Guna.UI2.WinForms.Guna2Button();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.panelTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(224, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1400, 900);
            this.panelMain.TabIndex = 2;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblDateTime);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(224, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1400, 38);
            this.panelTop.TabIndex = 0;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(1198, 11);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(38, 17);
            this.lblDateTime.TabIndex = 2;
            this.lblDateTime.Text = "clock";
            // 
            // dateTime
            // 
            this.dateTime.Enabled = true;
            this.dateTime.Interval = 1000;
            this.dateTime.Tick += new System.EventHandler(this.dateTime_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.logoPic);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 190);
            this.panel2.TabIndex = 0;
            // 
            // logoPic
            // 
            this.logoPic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.logoPic.Image = ((System.Drawing.Image)(resources.GetObject("logoPic.Image")));
            this.logoPic.Location = new System.Drawing.Point(61, 12);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(101, 102);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPic.TabIndex = 0;
            this.logoPic.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "BFAR 8 Budget Registry";
            // 
            // btnInsert
            // 
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInsert.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInsert.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInsert.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInsert.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInsert.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Image = ((System.Drawing.Image)(resources.GetObject("btnInsert.Image")));
            this.btnInsert.ImageOffset = new System.Drawing.Point(-12, 0);
            this.btnInsert.ImageSize = new System.Drawing.Size(24, 24);
            this.btnInsert.Location = new System.Drawing.Point(0, 235);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(224, 45);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Insert Obligations";
            this.btnInsert.TextOffset = new System.Drawing.Point(-8, 0);
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnEarmarks
            // 
            this.btnEarmarks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEarmarks.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEarmarks.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEarmarks.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEarmarks.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEarmarks.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEarmarks.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEarmarks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEarmarks.ForeColor = System.Drawing.Color.White;
            this.btnEarmarks.Image = ((System.Drawing.Image)(resources.GetObject("btnEarmarks.Image")));
            this.btnEarmarks.ImageOffset = new System.Drawing.Point(-17, 0);
            this.btnEarmarks.Location = new System.Drawing.Point(0, 280);
            this.btnEarmarks.Name = "btnEarmarks";
            this.btnEarmarks.Size = new System.Drawing.Size(224, 45);
            this.btnEarmarks.TabIndex = 2;
            this.btnEarmarks.Text = "Insert Earmarks";
            this.btnEarmarks.TextOffset = new System.Drawing.Point(-12, 0);
            this.btnEarmarks.Click += new System.EventHandler(this.btnEarmarks_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelMenu.Controls.Add(this.manageHighlight);
            this.panelMenu.Controls.Add(this.viewHighlight);
            this.panelMenu.Controls.Add(this.insertEarmarkHighlight);
            this.panelMenu.Controls.Add(this.insertObligationHighlight);
            this.panelMenu.Controls.Add(this.homeHighlight);
            this.panelMenu.Controls.Add(this.btnManage);
            this.panelMenu.Controls.Add(this.btnView);
            this.panelMenu.Controls.Add(this.btnEarmarks);
            this.panelMenu.Controls.Add(this.btnInsert);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(224, 900);
            this.panelMenu.TabIndex = 0;
            // 
            // manageHighlight
            // 
            this.manageHighlight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.manageHighlight.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.manageHighlight.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.manageHighlight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.manageHighlight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.manageHighlight.FillColor = System.Drawing.Color.LightSkyBlue;
            this.manageHighlight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageHighlight.ForeColor = System.Drawing.Color.White;
            this.manageHighlight.ImageOffset = new System.Drawing.Point(-30, 0);
            this.manageHighlight.ImageSize = new System.Drawing.Size(22, 22);
            this.manageHighlight.Location = new System.Drawing.Point(213, 370);
            this.manageHighlight.Name = "manageHighlight";
            this.manageHighlight.Size = new System.Drawing.Size(11, 45);
            this.manageHighlight.TabIndex = 10;
            this.manageHighlight.TextOffset = new System.Drawing.Point(-25, 0);
            this.manageHighlight.Visible = false;
            // 
            // viewHighlight
            // 
            this.viewHighlight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewHighlight.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.viewHighlight.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.viewHighlight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.viewHighlight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.viewHighlight.FillColor = System.Drawing.Color.LightSkyBlue;
            this.viewHighlight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewHighlight.ForeColor = System.Drawing.Color.White;
            this.viewHighlight.ImageOffset = new System.Drawing.Point(-30, 0);
            this.viewHighlight.ImageSize = new System.Drawing.Size(22, 22);
            this.viewHighlight.Location = new System.Drawing.Point(213, 325);
            this.viewHighlight.Name = "viewHighlight";
            this.viewHighlight.Size = new System.Drawing.Size(11, 45);
            this.viewHighlight.TabIndex = 9;
            this.viewHighlight.TextOffset = new System.Drawing.Point(-25, 0);
            this.viewHighlight.Visible = false;
            // 
            // insertEarmarkHighlight
            // 
            this.insertEarmarkHighlight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insertEarmarkHighlight.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.insertEarmarkHighlight.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.insertEarmarkHighlight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.insertEarmarkHighlight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.insertEarmarkHighlight.FillColor = System.Drawing.Color.LightSkyBlue;
            this.insertEarmarkHighlight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertEarmarkHighlight.ForeColor = System.Drawing.Color.White;
            this.insertEarmarkHighlight.ImageOffset = new System.Drawing.Point(-30, 0);
            this.insertEarmarkHighlight.ImageSize = new System.Drawing.Size(22, 22);
            this.insertEarmarkHighlight.Location = new System.Drawing.Point(213, 280);
            this.insertEarmarkHighlight.Name = "insertEarmarkHighlight";
            this.insertEarmarkHighlight.Size = new System.Drawing.Size(11, 45);
            this.insertEarmarkHighlight.TabIndex = 8;
            this.insertEarmarkHighlight.TextOffset = new System.Drawing.Point(-25, 0);
            this.insertEarmarkHighlight.Visible = false;
            // 
            // insertObligationHighlight
            // 
            this.insertObligationHighlight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insertObligationHighlight.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.insertObligationHighlight.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.insertObligationHighlight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.insertObligationHighlight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.insertObligationHighlight.FillColor = System.Drawing.Color.LightSkyBlue;
            this.insertObligationHighlight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertObligationHighlight.ForeColor = System.Drawing.Color.White;
            this.insertObligationHighlight.ImageOffset = new System.Drawing.Point(-30, 0);
            this.insertObligationHighlight.ImageSize = new System.Drawing.Size(22, 22);
            this.insertObligationHighlight.Location = new System.Drawing.Point(213, 235);
            this.insertObligationHighlight.Name = "insertObligationHighlight";
            this.insertObligationHighlight.Size = new System.Drawing.Size(11, 45);
            this.insertObligationHighlight.TabIndex = 7;
            this.insertObligationHighlight.TextOffset = new System.Drawing.Point(-25, 0);
            this.insertObligationHighlight.Visible = false;
            // 
            // homeHighlight
            // 
            this.homeHighlight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeHighlight.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.homeHighlight.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.homeHighlight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.homeHighlight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.homeHighlight.FillColor = System.Drawing.Color.LightSkyBlue;
            this.homeHighlight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeHighlight.ForeColor = System.Drawing.Color.White;
            this.homeHighlight.ImageOffset = new System.Drawing.Point(-30, 0);
            this.homeHighlight.ImageSize = new System.Drawing.Size(22, 22);
            this.homeHighlight.Location = new System.Drawing.Point(213, 190);
            this.homeHighlight.Name = "homeHighlight";
            this.homeHighlight.Size = new System.Drawing.Size(11, 45);
            this.homeHighlight.TabIndex = 6;
            this.homeHighlight.TextOffset = new System.Drawing.Point(-25, 0);
            this.homeHighlight.Visible = false;
            // 
            // btnManage
            // 
            this.btnManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnManage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnManage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnManage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnManage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManage.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnManage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManage.ForeColor = System.Drawing.Color.White;
            this.btnManage.Image = ((System.Drawing.Image)(resources.GetObject("btnManage.Image")));
            this.btnManage.ImageOffset = new System.Drawing.Point(-19, 0);
            this.btnManage.ImageSize = new System.Drawing.Size(24, 24);
            this.btnManage.Location = new System.Drawing.Point(0, 370);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(224, 45);
            this.btnManage.TabIndex = 5;
            this.btnManage.Text = "Manage Data";
            this.btnManage.TextOffset = new System.Drawing.Point(-17, 0);
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click_1);
            // 
            // btnView
            // 
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnView.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnView.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnView.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnView.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnView.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageOffset = new System.Drawing.Point(-14, 0);
            this.btnView.ImageSize = new System.Drawing.Size(26, 26);
            this.btnView.Location = new System.Drawing.Point(0, 325);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(224, 45);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View Obligations";
            this.btnView.TextOffset = new System.Drawing.Point(-12, 0);
            this.btnView.Click += new System.EventHandler(this.btnView_Click_1);
            // 
            // btnHome
            // 
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageOffset = new System.Drawing.Point(-30, 0);
            this.btnHome.ImageSize = new System.Drawing.Size(22, 22);
            this.btnHome.Location = new System.Drawing.Point(0, 190);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(224, 45);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.TextOffset = new System.Drawing.Point(-25, 0);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 900);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.Name = "dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dashboard";
            this.Load += new System.EventHandler(this.dashboard_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private System.Windows.Forms.Timer dateTime;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox logoPic;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnInsert;
        private Guna.UI2.WinForms.Guna2Button btnEarmarks;
        private System.Windows.Forms.Panel panelMenu;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2Button btnView;
        private Guna.UI2.WinForms.Guna2Button btnManage;
        private Guna.UI2.WinForms.Guna2Button homeHighlight;
        private Guna.UI2.WinForms.Guna2Button insertEarmarkHighlight;
        private Guna.UI2.WinForms.Guna2Button insertObligationHighlight;
        private Guna.UI2.WinForms.Guna2Button manageHighlight;
        private Guna.UI2.WinForms.Guna2Button viewHighlight;
    }
}