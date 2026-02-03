namespace bfar8_budget_registry2025
{
    partial class manage
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
            this.btnImport = new Guna.UI2.WinForms.Guna2Button();
            this.btnTest = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImport.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnImport.BorderRadius = 5;
            this.btnImport.BorderThickness = 2;
            this.btnImport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImport.FillColor = System.Drawing.Color.DarkGreen;
            this.btnImport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(554, 183);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(275, 52);
            this.btnImport.TabIndex = 34;
            this.btnImport.Text = "Import Excel File";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTest.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnTest.BorderRadius = 5;
            this.btnTest.BorderThickness = 2;
            this.btnTest.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTest.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTest.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTest.FillColor = System.Drawing.Color.DarkGreen;
            this.btnTest.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.ForeColor = System.Drawing.Color.White;
            this.btnTest.Location = new System.Drawing.Point(563, 424);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(275, 52);
            this.btnTest.TabIndex = 35;
            this.btnTest.Text = "test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "manage";
            this.Text = "manage";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnImport;
        private Guna.UI2.WinForms.Guna2Button btnTest;
    }
}