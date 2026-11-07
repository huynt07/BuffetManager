namespace BuffetManager.Forms
{
    partial class frmGoiBuffet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoiBuffet));
            this.txtTenGoi = new Guna.UI2.WinForms.Guna2TextBox();
            this.nudGiaNguoiLon = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nudGiaPhat = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.chkDangBan = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.dgvGoiBuffet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTenGoi = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblGiaPhat = new System.Windows.Forms.Label();
            this.colMaGoiHienThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaGoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenGoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNguoiLon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGiaPhatMoiKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DangBan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaNguoiLon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaPhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoiBuffet)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTenGoi
            // 
            this.txtTenGoi.BorderRadius = 8;
            this.txtTenGoi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenGoi.DefaultText = "";
            this.txtTenGoi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenGoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenGoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenGoi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenGoi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenGoi.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenGoi.ForeColor = System.Drawing.Color.Black;
            this.txtTenGoi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenGoi.Location = new System.Drawing.Point(113, 66);
            this.txtTenGoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenGoi.Name = "txtTenGoi";
            this.txtTenGoi.PlaceholderText = "";
            this.txtTenGoi.SelectedText = "";
            this.txtTenGoi.Size = new System.Drawing.Size(200, 50);
            this.txtTenGoi.TabIndex = 0;
            // 
            // nudGiaNguoiLon
            // 
            this.nudGiaNguoiLon.BackColor = System.Drawing.Color.Transparent;
            this.nudGiaNguoiLon.BorderRadius = 8;
            this.nudGiaNguoiLon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudGiaNguoiLon.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudGiaNguoiLon.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGiaNguoiLon.Location = new System.Drawing.Point(429, 66);
            this.nudGiaNguoiLon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudGiaNguoiLon.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudGiaNguoiLon.Name = "nudGiaNguoiLon";
            this.nudGiaNguoiLon.Size = new System.Drawing.Size(160, 50);
            this.nudGiaNguoiLon.TabIndex = 1;
            this.nudGiaNguoiLon.ThousandsSeparator = true;
            // 
            // nudGiaPhat
            // 
            this.nudGiaPhat.BackColor = System.Drawing.Color.Transparent;
            this.nudGiaPhat.BorderRadius = 8;
            this.nudGiaPhat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudGiaPhat.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudGiaPhat.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGiaPhat.Location = new System.Drawing.Point(720, 66);
            this.nudGiaPhat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudGiaPhat.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudGiaPhat.Name = "nudGiaPhat";
            this.nudGiaPhat.Size = new System.Drawing.Size(160, 50);
            this.nudGiaPhat.TabIndex = 1;
            this.nudGiaPhat.ThousandsSeparator = true;
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
            this.chkDangBan.Location = new System.Drawing.Point(808, 162);
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
            this.btnThem.Location = new System.Drawing.Point(55, 210);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 65);
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
            this.btnSua.Location = new System.Drawing.Point(235, 210);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 65);
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
            this.btnXoa.Location = new System.Drawing.Point(415, 210);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(150, 65);
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
            this.btnLamMoi.Location = new System.Drawing.Point(595, 210);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(150, 65);
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
            this.btnDong.Location = new System.Drawing.Point(775, 210);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(150, 65);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dgvGoiBuffet
            // 
            this.dgvGoiBuffet.AllowUserToAddRows = false;
            this.dgvGoiBuffet.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvGoiBuffet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoiBuffet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGoiBuffet.ColumnHeadersHeight = 50;
            this.dgvGoiBuffet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvGoiBuffet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaGoiHienThi,
            this.MaGoi,
            this.TenGoi,
            this.GiaNguoiLon,
            this.DonGiaPhatMoiKg,
            this.DangBan});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGoiBuffet.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGoiBuffet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvGoiBuffet.Location = new System.Drawing.Point(50, 300);
            this.dgvGoiBuffet.MultiSelect = false;
            this.dgvGoiBuffet.Name = "dgvGoiBuffet";
            this.dgvGoiBuffet.ReadOnly = true;
            this.dgvGoiBuffet.RowHeadersVisible = false;
            this.dgvGoiBuffet.RowHeadersWidth = 51;
            this.dgvGoiBuffet.RowTemplate.Height = 24;
            this.dgvGoiBuffet.Size = new System.Drawing.Size(900, 330);
            this.dgvGoiBuffet.TabIndex = 4;
            this.dgvGoiBuffet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvGoiBuffet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvGoiBuffet.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvGoiBuffet.ThemeStyle.ReadOnly = true;
            this.dgvGoiBuffet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvGoiBuffet.ThemeStyle.RowsStyle.Height = 24;
            this.dgvGoiBuffet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoiBuffet_CellClick);
            // 
            // lblTenGoi
            // 
            this.lblTenGoi.AutoSize = true;
            this.lblTenGoi.Location = new System.Drawing.Point(108, 41);
            this.lblTenGoi.Name = "lblTenGoi";
            this.lblTenGoi.Size = new System.Drawing.Size(79, 25);
            this.lblTenGoi.TabIndex = 5;
            this.lblTenGoi.Text = "Tên gói";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(424, 41);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(77, 25);
            this.lblGia.TabIndex = 5;
            this.lblGia.Text = "Giá gói";
            // 
            // lblGiaPhat
            // 
            this.lblGiaPhat.AutoSize = true;
            this.lblGiaPhat.Location = new System.Drawing.Point(715, 41);
            this.lblGiaPhat.Name = "lblGiaPhat";
            this.lblGiaPhat.Size = new System.Drawing.Size(87, 25);
            this.lblGiaPhat.TabIndex = 5;
            this.lblGiaPhat.Text = "Giá phạt";
            // 
            // colMaGoiHienThi
            // 
            this.colMaGoiHienThi.DataPropertyName = "MaHienThi";
            this.colMaGoiHienThi.FillWeight = 20F;
            this.colMaGoiHienThi.HeaderText = "Mã gói";
            this.colMaGoiHienThi.MinimumWidth = 6;
            this.colMaGoiHienThi.Name = "colMaGoiHienThi";
            this.colMaGoiHienThi.ReadOnly = true;
            // 
            // MaGoi
            // 
            this.MaGoi.DataPropertyName = "MaGoi";
            this.MaGoi.FillWeight = 20F;
            this.MaGoi.HeaderText = "Mã gói";
            this.MaGoi.MinimumWidth = 6;
            this.MaGoi.Name = "MaGoi";
            this.MaGoi.ReadOnly = true;
            this.MaGoi.Visible = false;
            // 
            // TenGoi
            // 
            this.TenGoi.DataPropertyName = "TenGoi";
            this.TenGoi.FillWeight = 22F;
            this.TenGoi.HeaderText = "Tên gói";
            this.TenGoi.MinimumWidth = 6;
            this.TenGoi.Name = "TenGoi";
            this.TenGoi.ReadOnly = true;
            // 
            // GiaNguoiLon
            // 
            this.GiaNguoiLon.DataPropertyName = "GiaNguoiLon";
            dataGridViewCellStyle3.Format = "N0";
            this.GiaNguoiLon.DefaultCellStyle = dataGridViewCellStyle3;
            this.GiaNguoiLon.FillWeight = 25F;
            this.GiaNguoiLon.HeaderText = "Giá vé người lớn (đồng)";
            this.GiaNguoiLon.MinimumWidth = 6;
            this.GiaNguoiLon.Name = "GiaNguoiLon";
            this.GiaNguoiLon.ReadOnly = true;
            // 
            // DonGiaPhatMoiKg
            // 
            this.DonGiaPhatMoiKg.DataPropertyName = "DonGiaPhatMoiKg";
            dataGridViewCellStyle4.Format = "N0";
            this.DonGiaPhatMoiKg.DefaultCellStyle = dataGridViewCellStyle4;
            this.DonGiaPhatMoiKg.FillWeight = 23F;
            this.DonGiaPhatMoiKg.HeaderText = "Phạt đồ thừa (đồng/kg)";
            this.DonGiaPhatMoiKg.MinimumWidth = 6;
            this.DonGiaPhatMoiKg.Name = "DonGiaPhatMoiKg";
            this.DonGiaPhatMoiKg.ReadOnly = true;
            // 
            // DangBan
            // 
            this.DangBan.DataPropertyName = "DangBan";
            this.DangBan.FillWeight = 10F;
            this.DangBan.HeaderText = "Đang bán";
            this.DangBan.MinimumWidth = 6;
            this.DangBan.Name = "DangBan";
            this.DangBan.ReadOnly = true;
            // 
            // frmGoiBuffet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.lblGiaPhat);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblTenGoi);
            this.Controls.Add(this.dgvGoiBuffet);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.chkDangBan);
            this.Controls.Add(this.nudGiaPhat);
            this.Controls.Add(this.nudGiaNguoiLon);
            this.Controls.Add(this.txtTenGoi);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGoiBuffet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý gói buffet";
            this.Load += new System.EventHandler(this.frmGoiBuffet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaNguoiLon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaPhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoiBuffet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtTenGoi;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudGiaNguoiLon;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudGiaPhat;
        private Guna.UI2.WinForms.Guna2CheckBox chkDangBan;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Guna.UI2.WinForms.Guna2DataGridView dgvGoiBuffet;
        private System.Windows.Forms.Label lblTenGoi;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblGiaPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaGoiHienThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenGoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNguoiLon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGiaPhatMoiKg;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DangBan;
    }
}