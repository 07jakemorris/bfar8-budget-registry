namespace bfar8_budget_registry2025
{
    partial class viewRegistry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewRegistry));
            this.obligationsTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orsNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.particulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsibility_center = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signatory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obligations_incurred = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.txtPayee = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtORSNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtRespCenter = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.searchResultDGV = new System.Windows.Forms.DataGridView();
            this.resultPayee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.obligationsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResultDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // obligationsTable
            // 
            this.obligationsTable.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.obligationsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.obligationsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.obligationsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.obligationsTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.obligationsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.obligationsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.obligationsTable.ColumnHeadersHeight = 32;
            this.obligationsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.obligationsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.month,
            this.day,
            this.year,
            this.orsNo,
            this.payee,
            this.particulars,
            this.responsibility_center,
            this.signatory,
            this.position,
            this.obligations_incurred});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.obligationsTable.DefaultCellStyle = dataGridViewCellStyle8;
            this.obligationsTable.GridColor = System.Drawing.Color.Gray;
            this.obligationsTable.Location = new System.Drawing.Point(11, 208);
            this.obligationsTable.Name = "obligationsTable";
            this.obligationsTable.ReadOnly = true;
            this.obligationsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.obligationsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.obligationsTable.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.obligationsTable.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.obligationsTable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.obligationsTable.Size = new System.Drawing.Size(1434, 731);
            this.obligationsTable.TabIndex = 3;
            this.obligationsTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.obligationsTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.obligationsTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.obligationsTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.obligationsTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.obligationsTable.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.obligationsTable.ThemeStyle.GridColor = System.Drawing.Color.Gray;
            this.obligationsTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.obligationsTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.obligationsTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.obligationsTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.obligationsTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.obligationsTable.ThemeStyle.HeaderStyle.Height = 32;
            this.obligationsTable.ThemeStyle.ReadOnly = true;
            this.obligationsTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.obligationsTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.obligationsTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.obligationsTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.obligationsTable.ThemeStyle.RowsStyle.Height = 22;
            this.obligationsTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.obligationsTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.obligationsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.obligationsTable_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // month
            // 
            this.month.HeaderText = "Month";
            this.month.Name = "month";
            this.month.ReadOnly = true;
            this.month.Width = 70;
            // 
            // day
            // 
            this.day.HeaderText = "Day";
            this.day.Name = "day";
            this.day.ReadOnly = true;
            this.day.Width = 50;
            // 
            // year
            // 
            this.year.HeaderText = "Year";
            this.year.Name = "year";
            this.year.ReadOnly = true;
            this.year.Width = 65;
            // 
            // orsNo
            // 
            this.orsNo.HeaderText = "ORS No.";
            this.orsNo.Name = "orsNo";
            this.orsNo.ReadOnly = true;
            this.orsNo.Width = 90;
            // 
            // payee
            // 
            this.payee.HeaderText = "Payee";
            this.payee.Name = "payee";
            this.payee.ReadOnly = true;
            this.payee.Width = 180;
            // 
            // particulars
            // 
            this.particulars.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.particulars.HeaderText = "Particulars";
            this.particulars.Name = "particulars";
            this.particulars.ReadOnly = true;
            // 
            // responsibility_center
            // 
            this.responsibility_center.HeaderText = "Responsibility Center";
            this.responsibility_center.Name = "responsibility_center";
            this.responsibility_center.ReadOnly = true;
            this.responsibility_center.Width = 170;
            // 
            // signatory
            // 
            this.signatory.HeaderText = "Signatory";
            this.signatory.Name = "signatory";
            this.signatory.ReadOnly = true;
            this.signatory.Width = 180;
            // 
            // position
            // 
            this.position.HeaderText = "Position";
            this.position.Name = "position";
            this.position.ReadOnly = true;
            this.position.Visible = false;
            this.position.Width = 150;
            // 
            // obligations_incurred
            // 
            this.obligations_incurred.HeaderText = "Obligations Incurred";
            this.obligations_incurred.Name = "obligations_incurred";
            this.obligations_incurred.ReadOnly = true;
            this.obligations_incurred.Width = 120;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(701, 69);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(53, 27);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 5;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // txtPayee
            // 
            this.txtPayee.BorderColor = System.Drawing.Color.DarkGray;
            this.txtPayee.BorderRadius = 3;
            this.txtPayee.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPayee.DefaultText = "";
            this.txtPayee.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPayee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPayee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPayee.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPayee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPayee.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPayee.ForeColor = System.Drawing.Color.Black;
            this.txtPayee.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPayee.Location = new System.Drawing.Point(176, 115);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtPayee.PlaceholderText = "Payee";
            this.txtPayee.SelectedText = "";
            this.txtPayee.Size = new System.Drawing.Size(298, 30);
            this.txtPayee.TabIndex = 0;
            this.txtPayee.TextChanged += new System.EventHandler(this.txtPayee_TextChanged);
            // 
            // txtORSNo
            // 
            this.txtORSNo.BorderColor = System.Drawing.Color.DarkGray;
            this.txtORSNo.BorderRadius = 3;
            this.txtORSNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtORSNo.DefaultText = "";
            this.txtORSNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtORSNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtORSNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtORSNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtORSNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtORSNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtORSNo.ForeColor = System.Drawing.Color.Black;
            this.txtORSNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtORSNo.Location = new System.Drawing.Point(12, 115);
            this.txtORSNo.Name = "txtORSNo";
            this.txtORSNo.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtORSNo.PlaceholderText = "ORS No.";
            this.txtORSNo.SelectedText = "";
            this.txtORSNo.Size = new System.Drawing.Size(148, 30);
            this.txtORSNo.TabIndex = 2;
            // 
            // txtRespCenter
            // 
            this.txtRespCenter.BorderColor = System.Drawing.Color.DarkGray;
            this.txtRespCenter.BorderRadius = 3;
            this.txtRespCenter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRespCenter.DefaultText = "";
            this.txtRespCenter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRespCenter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRespCenter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRespCenter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRespCenter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRespCenter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRespCenter.ForeColor = System.Drawing.Color.Black;
            this.txtRespCenter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRespCenter.Location = new System.Drawing.Point(12, 161);
            this.txtRespCenter.Name = "txtRespCenter";
            this.txtRespCenter.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtRespCenter.PlaceholderText = "Responsibility Center";
            this.txtRespCenter.SelectedText = "";
            this.txtRespCenter.Size = new System.Drawing.Size(462, 30);
            this.txtRespCenter.TabIndex = 3;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.DimGray;
            this.lblSearch.Location = new System.Drawing.Point(644, 71);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(71, 25);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search";
            // 
            // searchResultDGV
            // 
            this.searchResultDGV.AllowUserToAddRows = false;
            this.searchResultDGV.AllowUserToDeleteRows = false;
            this.searchResultDGV.AllowUserToResizeColumns = false;
            this.searchResultDGV.AllowUserToResizeRows = false;
            this.searchResultDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchResultDGV.ColumnHeadersVisible = false;
            this.searchResultDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.resultPayee});
            this.searchResultDGV.Location = new System.Drawing.Point(176, 146);
            this.searchResultDGV.MaximumSize = new System.Drawing.Size(341, 250);
            this.searchResultDGV.Name = "searchResultDGV";
            this.searchResultDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.searchResultDGV.RowHeadersVisible = false;
            this.searchResultDGV.RowTemplate.Height = 30;
            this.searchResultDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchResultDGV.Size = new System.Drawing.Size(298, 0);
            this.searchResultDGV.TabIndex = 33;
            this.searchResultDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchResultDGV_CellClick);
            // 
            // resultPayee
            // 
            this.resultPayee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.resultPayee.DataPropertyName = "payee";
            this.resultPayee.HeaderText = "Name";
            this.resultPayee.Name = "resultPayee";
            this.resultPayee.ReadOnly = true;
            // 
            // viewRegistry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 951);
            this.Controls.Add(this.searchResultDGV);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.obligationsTable);
            this.Controls.Add(this.txtRespCenter);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.txtORSNo);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewRegistry";
            this.Text = "viewRegistry";
            this.Load += new System.EventHandler(this.viewRegistry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.obligationsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResultDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView obligationsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn month;
        private System.Windows.Forms.DataGridViewTextBoxColumn day;
        private System.Windows.Forms.DataGridViewTextBoxColumn year;
        private System.Windows.Forms.DataGridViewTextBoxColumn orsNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn payee;
        private System.Windows.Forms.DataGridViewTextBoxColumn particulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsibility_center;
        private System.Windows.Forms.DataGridViewTextBoxColumn signatory;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn obligations_incurred;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtPayee;
        private Guna.UI2.WinForms.Guna2TextBox txtORSNo;
        private Guna.UI2.WinForms.Guna2TextBox txtRespCenter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView searchResultDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultPayee;
    }
}