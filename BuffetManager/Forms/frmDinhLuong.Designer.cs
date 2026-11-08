namespace BuffetManager.Forms
{
    partial class frmDinhLuong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDinhLuong));
            this.lblMonAn = new System.Windows.Forms.Label();
            this.lblNguyenLieu = new System.Windows.Forms.Label();
            this.lblLuongCan = new System.Windows.Forms.Label();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.cboMonAn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboNguyenLieu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.nudLuongCan = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDinhLuong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaNL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuongCan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuongCan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMonAn
            // 
            this.lblMonAn.AutoSize = true;
            this.lblMonAn.Location = new System.Drawing.Point(124, 38);
            this.lblMonAn.Name = "lblMonAn";
            this.lblMonAn.Size = new System.Drawing.Size(78, 25);
            this.lblMonAn.TabIndex = 0;
            this.lblMonAn.Text = "Món ăn";
            // 
            // lblNguyenLieu
            // 
            this.lblNguyenLieu.AutoSize = true;
            this.lblNguyenLieu.Location = new System.Drawing.Point(435, 38);
            this.lblNguyenLieu.Name = "lblNguyenLieu";
            this.lblNguyenLieu.Size = new System.Drawing.Size(119, 25);
            this.lblNguyenLieu.TabIndex = 0;
            this.lblNguyenLieu.Text = "Nguyên liệu";
            // 
            // lblLuongCan
            // 
            this.lblLuongCan.AutoSize = true;
            this.lblLuongCan.Location = new System.Drawing.Point(728, 38);
            this.lblLuongCan.Name = "lblLuongCan";
            this.lblLuongCan.Size = new System.Drawing.Size(263, 25);
            this.lblLuongCan.TabIndex = 0;
            this.lblLuongCan.Text = "Lượng cần cho 1 đơn vị món";
            // 
            // lblDonVi
            // 
            this.lblDonVi.AutoSize = true;
            this.lblDonVi.Location = new System.Drawing.Point(879, 77);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(107, 25);
            this.lblDonVi.TabIndex = 0;
            this.lblDonVi.Text = "Đơn vị: —";
            // 
            // cboMonAn
            // 
            this.cboMonAn.BackColor = System.Drawing.Color.Transparent;
            this.cboMonAn.BorderRadius = 8;
            this.cboMonAn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMonAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonAn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMonAn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMonAn.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboMonAn.ForeColor = System.Drawing.Color.Black;
            this.cboMonAn.ItemHeight = 30;
            this.cboMonAn.Location = new System.Drawing.Point(129, 66);
            this.cboMonAn.Name = "cboMonAn";
            this.cboMonAn.Size = new System.Drawing.Size(200, 36);
            this.cboMonAn.TabIndex = 1;
            this.cboMonAn.SelectionChangeCommitted += new System.EventHandler(this.cboMonAn_SelectionChangeCommitted);
            // 
            // cboNguyenLieu
            // 
            this.cboNguyenLieu.BackColor = System.Drawing.Color.Transparent;
            this.cboNguyenLieu.BorderRadius = 8;
            this.cboNguyenLieu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNguyenLieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguyenLieu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNguyenLieu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNguyenLieu.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboNguyenLieu.ForeColor = System.Drawing.Color.Black;
            this.cboNguyenLieu.ItemHeight = 30;
            this.cboNguyenLieu.Location = new System.Drawing.Point(440, 66);
            this.cboNguyenLieu.Name = "cboNguyenLieu";
            this.cboNguyenLieu.Size = new System.Drawing.Size(200, 36);
            this.cboNguyenLieu.TabIndex = 1;
            this.cboNguyenLieu.SelectionChangeCommitted += new System.EventHandler(this.cboNguyenLieu_SelectionChangeCommitted);
            // 
            // nudLuongCan
            // 
            this.nudLuongCan.BackColor = System.Drawing.Color.Transparent;
            this.nudLuongCan.BorderRadius = 8;
            this.nudLuongCan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudLuongCan.DecimalPlaces = 3;
            this.nudLuongCan.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudLuongCan.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLuongCan.Location = new System.Drawing.Point(733, 62);
            this.nudLuongCan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudLuongCan.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudLuongCan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudLuongCan.Name = "nudLuongCan";
            this.nudLuongCan.Size = new System.Drawing.Size(140, 40);
            this.nudLuongCan.TabIndex = 2;
            this.nudLuongCan.ThousandsSeparator = true;
            this.nudLuongCan.Value = new decimal(new int[] {
            100,
            0,
            0,
            196608});
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 8;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(65, 147);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(160, 65);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm nguyên liệu";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 8;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(265, 147);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(160, 65);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa lượng";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 8;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(465, 147);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(160, 65);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Gỡ nguyên liệu";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(665, 147);
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
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(865, 147);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(160, 65);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dgvDinhLuong
            // 
            this.dgvDinhLuong.AllowUserToAddRows = false;
            this.dgvDinhLuong.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDinhLuong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDinhLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDinhLuong.ColumnHeadersHeight = 50;
            this.dgvDinhLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDinhLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNL,
            this.TenNL,
            this.DonVi,
            this.LuongCan,
            this.MaMon});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDinhLuong.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDinhLuong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDinhLuong.Location = new System.Drawing.Point(50, 250);
            this.dgvDinhLuong.MultiSelect = false;
            this.dgvDinhLuong.Name = "dgvDinhLuong";
            this.dgvDinhLuong.ReadOnly = true;
            this.dgvDinhLuong.RowHeadersVisible = false;
            this.dgvDinhLuong.RowHeadersWidth = 51;
            this.dgvDinhLuong.RowTemplate.Height = 24;
            this.dgvDinhLuong.Size = new System.Drawing.Size(1000, 430);
            this.dgvDinhLuong.TabIndex = 4;
            this.dgvDinhLuong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDinhLuong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvDinhLuong.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvDinhLuong.ThemeStyle.ReadOnly = true;
            this.dgvDinhLuong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvDinhLuong.ThemeStyle.RowsStyle.Height = 24;
            this.dgvDinhLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDinhLuong_CellClick);
            // 
            // MaNL
            // 
            this.MaNL.DataPropertyName = "MaNL";
            this.MaNL.FillWeight = 25F;
            this.MaNL.HeaderText = "Mã nguyên liệu";
            this.MaNL.MinimumWidth = 6;
            this.MaNL.Name = "MaNL";
            this.MaNL.ReadOnly = true;
            // 
            // TenNL
            // 
            this.TenNL.DataPropertyName = "TenNL";
            this.TenNL.FillWeight = 35F;
            this.TenNL.HeaderText = "Tên nguyên liệu";
            this.TenNL.MinimumWidth = 6;
            this.TenNL.Name = "TenNL";
            this.TenNL.ReadOnly = true;
            // 
            // DonVi
            // 
            this.DonVi.DataPropertyName = "DonVi";
            this.DonVi.FillWeight = 15F;
            this.DonVi.HeaderText = "Đơn vị";
            this.DonVi.MinimumWidth = 6;
            this.DonVi.Name = "DonVi";
            this.DonVi.ReadOnly = true;
            // 
            // LuongCan
            // 
            this.LuongCan.DataPropertyName = "LuongCan";
            dataGridViewCellStyle3.Format = "N3";
            this.LuongCan.DefaultCellStyle = dataGridViewCellStyle3;
            this.LuongCan.FillWeight = 25F;
            this.LuongCan.HeaderText = "Lượng cần / 1 đơn vị món";
            this.LuongCan.MinimumWidth = 6;
            this.LuongCan.Name = "LuongCan";
            this.LuongCan.ReadOnly = true;
            // 
            // MaMon
            // 
            this.MaMon.DataPropertyName = "MaMon";
            this.MaMon.HeaderText = "Mã món";
            this.MaMon.MinimumWidth = 6;
            this.MaMon.Name = "MaMon";
            this.MaMon.ReadOnly = true;
            this.MaMon.Visible = false;
            // 
            // frmDinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 703);
            this.Controls.Add(this.dgvDinhLuong);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.nudLuongCan);
            this.Controls.Add(this.cboNguyenLieu);
            this.Controls.Add(this.cboMonAn);
            this.Controls.Add(this.lblDonVi);
            this.Controls.Add(this.lblLuongCan);
            this.Controls.Add(this.lblNguyenLieu);
            this.Controls.Add(this.lblMonAn);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDinhLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Định lượng nguyên liệu";
            this.Load += new System.EventHandler(this.frmDinhLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLuongCan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMonAn;
        private System.Windows.Forms.Label lblNguyenLieu;
        private System.Windows.Forms.Label lblLuongCan;
        private System.Windows.Forms.Label lblDonVi;
        private Guna.UI2.WinForms.Guna2ComboBox cboMonAn;
        private Guna.UI2.WinForms.Guna2ComboBox cboNguyenLieu;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudLuongCan;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDinhLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuongCan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMon;
    }
}