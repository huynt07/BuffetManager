namespace BuffetManager.Forms
{
    partial class frmCombo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCombo));
            this.txtTenCombo = new Guna.UI2.WinForms.Guna2TextBox();
            this.nudGiaCombo = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nudSoNguoi = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.chkDangBan = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.dgvCombo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTenCombo = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.MaCombo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaComboHienThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCombo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNguoiGoiY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaCombo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DangBan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoNguoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTenCombo
            // 
            this.txtTenCombo.BorderRadius = 8;
            this.txtTenCombo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenCombo.DefaultText = "";
            this.txtTenCombo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenCombo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenCombo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenCombo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenCombo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenCombo.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenCombo.ForeColor = System.Drawing.Color.Black;
            this.txtTenCombo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenCombo.Location = new System.Drawing.Point(105, 65);
            this.txtTenCombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenCombo.Name = "txtTenCombo";
            this.txtTenCombo.PlaceholderText = "";
            this.txtTenCombo.SelectedText = "";
            this.txtTenCombo.Size = new System.Drawing.Size(200, 50);
            this.txtTenCombo.TabIndex = 0;
            // 
            // nudGiaCombo
            // 
            this.nudGiaCombo.BackColor = System.Drawing.Color.Transparent;
            this.nudGiaCombo.BorderRadius = 8;
            this.nudGiaCombo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudGiaCombo.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudGiaCombo.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGiaCombo.Location = new System.Drawing.Point(715, 65);
            this.nudGiaCombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudGiaCombo.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudGiaCombo.Name = "nudGiaCombo";
            this.nudGiaCombo.Size = new System.Drawing.Size(180, 50);
            this.nudGiaCombo.TabIndex = 1;
            this.nudGiaCombo.ThousandsSeparator = true;
            // 
            // nudSoNguoi
            // 
            this.nudSoNguoi.BackColor = System.Drawing.Color.Transparent;
            this.nudSoNguoi.BorderRadius = 8;
            this.nudSoNguoi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudSoNguoi.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudSoNguoi.Location = new System.Drawing.Point(445, 65);
            this.nudSoNguoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudSoNguoi.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSoNguoi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoNguoi.Name = "nudSoNguoi";
            this.nudSoNguoi.Size = new System.Drawing.Size(130, 50);
            this.nudSoNguoi.TabIndex = 1;
            this.nudSoNguoi.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // chkDangBan
            // 
            this.chkDangBan.AutoSize = true;
            this.chkDangBan.Checked = true;
            this.chkDangBan.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDangBan.CheckedState.BorderRadius = 0;
            this.chkDangBan.CheckedState.BorderThickness = 0;
            this.chkDangBan.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDangBan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDangBan.Location = new System.Drawing.Point(778, 165);
            this.chkDangBan.Name = "chkDangBan";
            this.chkDangBan.Size = new System.Drawing.Size(117, 29);
            this.chkDangBan.TabIndex = 2;
            this.chkDangBan.Text = "Đang bán";
            this.chkDangBan.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDangBan.UncheckedState.BorderRadius = 0;
            this.chkDangBan.UncheckedState.BorderThickness = 0;
            this.chkDangBan.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 8;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(55, 211);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(160, 65);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 8;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.Enabled = false;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(235, 211);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(160, 65);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 8;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.Enabled = false;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(415, 211);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(160, 65);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(595, 211);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(160, 65);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDong
            // 
            this.btnDong.BorderRadius = 8;
            this.btnDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(775, 211);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(160, 65);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dgvCombo
            // 
            this.dgvCombo.AllowUserToAddRows = false;
            this.dgvCombo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCombo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCombo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCombo.ColumnHeadersHeight = 50;
            this.dgvCombo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCombo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCombo,
            this.colMaComboHienThi,
            this.TenCombo,
            this.SoNguoiGoiY,
            this.GiaCombo,
            this.DangBan});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCombo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCombo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCombo.Location = new System.Drawing.Point(50, 310);
            this.dgvCombo.MultiSelect = false;
            this.dgvCombo.Name = "dgvCombo";
            this.dgvCombo.ReadOnly = true;
            this.dgvCombo.RowHeadersVisible = false;
            this.dgvCombo.RowHeadersWidth = 51;
            this.dgvCombo.RowTemplate.Height = 24;
            this.dgvCombo.Size = new System.Drawing.Size(900, 360);
            this.dgvCombo.TabIndex = 4;
            this.dgvCombo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCombo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvCombo.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvCombo.ThemeStyle.ReadOnly = true;
            this.dgvCombo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvCombo.ThemeStyle.RowsStyle.Height = 24;
            this.dgvCombo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCombo_CellClick);
            // 
            // lblTenCombo
            // 
            this.lblTenCombo.AutoSize = true;
            this.lblTenCombo.Location = new System.Drawing.Point(100, 36);
            this.lblTenCombo.Name = "lblTenCombo";
            this.lblTenCombo.Size = new System.Drawing.Size(111, 25);
            this.lblTenCombo.TabIndex = 5;
            this.lblTenCombo.Text = "Tên combo";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(710, 36);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(44, 25);
            this.lblGia.TabIndex = 5;
            this.lblGia.Text = "Giá";
            // 
            // lblSoNguoi
            // 
            this.lblSoNguoi.AutoSize = true;
            this.lblSoNguoi.Location = new System.Drawing.Point(440, 36);
            this.lblSoNguoi.Name = "lblSoNguoi";
            this.lblSoNguoi.Size = new System.Drawing.Size(91, 25);
            this.lblSoNguoi.TabIndex = 5;
            this.lblSoNguoi.Text = "Số người";
            // 
            // MaCombo
            // 
            this.MaCombo.DataPropertyName = "MaCombo";
            this.MaCombo.FillWeight = 18F;
            this.MaCombo.HeaderText = "Mã combo";
            this.MaCombo.MinimumWidth = 6;
            this.MaCombo.Name = "MaCombo";
            this.MaCombo.ReadOnly = true;
            this.MaCombo.Visible = false;
            // 
            // colMaComboHienThi
            // 
            this.colMaComboHienThi.DataPropertyName = "MaHienThi";
            this.colMaComboHienThi.FillWeight = 18F;
            this.colMaComboHienThi.HeaderText = "Mã combo";
            this.colMaComboHienThi.MinimumWidth = 6;
            this.colMaComboHienThi.Name = "colMaComboHienThi";
            this.colMaComboHienThi.ReadOnly = true;
            // 
            // TenCombo
            // 
            this.TenCombo.DataPropertyName = "TenCombo";
            this.TenCombo.FillWeight = 28F;
            this.TenCombo.HeaderText = "Tên combo";
            this.TenCombo.MinimumWidth = 6;
            this.TenCombo.Name = "TenCombo";
            this.TenCombo.ReadOnly = true;
            // 
            // SoNguoiGoiY
            // 
            this.SoNguoiGoiY.DataPropertyName = "SoNguoiGoiY";
            this.SoNguoiGoiY.FillWeight = 17F;
            this.SoNguoiGoiY.HeaderText = "Số người gợi ý";
            this.SoNguoiGoiY.MinimumWidth = 6;
            this.SoNguoiGoiY.Name = "SoNguoiGoiY";
            this.SoNguoiGoiY.ReadOnly = true;
            // 
            // GiaCombo
            // 
            this.GiaCombo.DataPropertyName = "GiaCombo";
            this.GiaCombo.FillWeight = 24F;
            this.GiaCombo.HeaderText = "Giá combo (đồng)";
            this.GiaCombo.MinimumWidth = 6;
            this.GiaCombo.Name = "GiaCombo";
            this.GiaCombo.ReadOnly = true;
            // 
            // DangBan
            // 
            this.DangBan.DataPropertyName = "DangBan";
            this.DangBan.FillWeight = 13F;
            this.DangBan.HeaderText = "Đang bán";
            this.DangBan.MinimumWidth = 6;
            this.DangBan.Name = "DangBan";
            this.DangBan.ReadOnly = true;
            // 
            // frmCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.lblSoNguoi);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblTenCombo);
            this.Controls.Add(this.dgvCombo);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.chkDangBan);
            this.Controls.Add(this.nudSoNguoi);
            this.Controls.Add(this.nudGiaCombo);
            this.Controls.Add(this.txtTenCombo);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCombo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý combo";
            this.Load += new System.EventHandler(this.frmCombo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtTenCombo;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudGiaCombo;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudSoNguoi;
        private Guna.UI2.WinForms.Guna2CheckBox chkDangBan;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCombo;
        private System.Windows.Forms.Label lblTenCombo;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCombo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaComboHienThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCombo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNguoiGoiY;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaCombo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DangBan;
    }
}