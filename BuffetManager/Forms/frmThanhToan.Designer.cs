namespace BuffetManager.Forms
{
    partial class frmThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThanhToan));
            this.lblThongTinBan = new System.Windows.Forms.Label();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.lblGioMo = new System.Windows.Forms.Label();
            this.lblTienThua = new System.Windows.Forms.Label();
            this.lblDonGiaPhat = new System.Windows.Forms.Label();
            this.lblTongThanhToan = new System.Windows.Forms.Label();
            this.lblTienPhat = new System.Windows.Forms.Label();
            this.dgvChiTietHoaDon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.LoaiDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nudKhoiLuongThua = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.cboPhuongThuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.nudTienKhachDua = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.chkDaNhanChuyenKhoan = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.lblTienKhachDua = new System.Windows.Forms.Label();
            this.pnlThanhToan = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlPhatThua = new Guna.UI2.WinForms.Guna2Panel();
            this.picQR = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKhoiLuongThua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTienKhachDua)).BeginInit();
            this.pnlThanhToan.SuspendLayout();
            this.pnlPhatThua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThongTinBan
            // 
            this.lblThongTinBan.AutoSize = true;
            this.lblThongTinBan.Location = new System.Drawing.Point(143, 47);
            this.lblThongTinBan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongTinBan.Name = "lblThongTinBan";
            this.lblThongTinBan.Size = new System.Drawing.Size(58, 25);
            this.lblThongTinBan.TabIndex = 0;
            this.lblThongTinBan.Text = "Bàn: ";
            // 
            // lblHinhThuc
            // 
            this.lblHinhThuc.AutoSize = true;
            this.lblHinhThuc.Location = new System.Drawing.Point(421, 47);
            this.lblHinhThuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHinhThuc.Name = "lblHinhThuc";
            this.lblHinhThuc.Size = new System.Drawing.Size(109, 25);
            this.lblHinhThuc.TabIndex = 0;
            this.lblHinhThuc.Text = "Hình thức: ";
            // 
            // lblGioMo
            // 
            this.lblGioMo.AutoSize = true;
            this.lblGioMo.Location = new System.Drawing.Point(744, 47);
            this.lblGioMo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGioMo.Name = "lblGioMo";
            this.lblGioMo.Size = new System.Drawing.Size(92, 25);
            this.lblGioMo.TabIndex = 0;
            this.lblGioMo.Text = "Giờ mở: ";
            // 
            // lblTienThua
            // 
            this.lblTienThua.AutoSize = true;
            this.lblTienThua.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTienThua.Location = new System.Drawing.Point(16, 648);
            this.lblTienThua.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTienThua.Name = "lblTienThua";
            this.lblTienThua.Size = new System.Drawing.Size(95, 25);
            this.lblTienThua.TabIndex = 0;
            this.lblTienThua.Text = "Tiền thừa";
            // 
            // lblDonGiaPhat
            // 
            this.lblDonGiaPhat.AutoSize = true;
            this.lblDonGiaPhat.Location = new System.Drawing.Point(21, 9);
            this.lblDonGiaPhat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDonGiaPhat.Name = "lblDonGiaPhat";
            this.lblDonGiaPhat.Size = new System.Drawing.Size(125, 25);
            this.lblDonGiaPhat.TabIndex = 0;
            this.lblDonGiaPhat.Text = "Đơn giá phạt";
            // 
            // lblTongThanhToan
            // 
            this.lblTongThanhToan.AutoSize = true;
            this.lblTongThanhToan.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongThanhToan.Location = new System.Drawing.Point(15, 693);
            this.lblTongThanhToan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongThanhToan.Name = "lblTongThanhToan";
            this.lblTongThanhToan.Size = new System.Drawing.Size(196, 33);
            this.lblTongThanhToan.TabIndex = 0;
            this.lblTongThanhToan.Text = "Tổng thanh toán";
            // 
            // lblTienPhat
            // 
            this.lblTienPhat.AutoSize = true;
            this.lblTienPhat.Location = new System.Drawing.Point(21, 96);
            this.lblTienPhat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTienPhat.Name = "lblTienPhat";
            this.lblTienPhat.Size = new System.Drawing.Size(94, 25);
            this.lblTienPhat.TabIndex = 0;
            this.lblTienPhat.Text = "Tiền phạt";
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvChiTietHoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTietHoaDon.ColumnHeadersHeight = 50;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChiTietHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoaiDong,
            this.TenDong,
            this.DonVi,
            this.SoLuong,
            this.DonGia,
            this.ThanhTien});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietHoaDon.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvChiTietHoaDon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(60, 100);
            this.dgvChiTietHoaDon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvChiTietHoaDon.MultiSelect = false;
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = true;
            this.dgvChiTietHoaDon.RowHeadersVisible = false;
            this.dgvChiTietHoaDon.RowHeadersWidth = 51;
            this.dgvChiTietHoaDon.RowTemplate.Height = 24;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(1000, 750);
            this.dgvChiTietHoaDon.TabIndex = 1;
            this.dgvChiTietHoaDon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTietHoaDon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChiTietHoaDon.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvChiTietHoaDon.ThemeStyle.ReadOnly = true;
            this.dgvChiTietHoaDon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChiTietHoaDon.ThemeStyle.RowsStyle.Height = 24;
            // 
            // LoaiDong
            // 
            this.LoaiDong.DataPropertyName = "LoaiDong";
            this.LoaiDong.FillWeight = 15F;
            this.LoaiDong.HeaderText = "Loại";
            this.LoaiDong.MinimumWidth = 6;
            this.LoaiDong.Name = "LoaiDong";
            this.LoaiDong.ReadOnly = true;
            // 
            // TenDong
            // 
            this.TenDong.DataPropertyName = "TenDong";
            this.TenDong.FillWeight = 25F;
            this.TenDong.HeaderText = "Nội dung";
            this.TenDong.MinimumWidth = 6;
            this.TenDong.Name = "TenDong";
            this.TenDong.ReadOnly = true;
            // 
            // DonVi
            // 
            this.DonVi.DataPropertyName = "DonVi";
            this.DonVi.FillWeight = 10F;
            this.DonVi.HeaderText = "Đơn vị";
            this.DonVi.MinimumWidth = 6;
            this.DonVi.Name = "DonVi";
            this.DonVi.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.FillWeight = 10F;
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle3.Format = "N0";
            this.DonGia.DefaultCellStyle = dataGridViewCellStyle3;
            this.DonGia.FillWeight = 20F;
            this.DonGia.HeaderText = "Đơn giá (đồng)";
            this.DonGia.MinimumWidth = 6;
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle4.Format = "N0";
            this.ThanhTien.DefaultCellStyle = dataGridViewCellStyle4;
            this.ThanhTien.FillWeight = 20F;
            this.ThanhTien.HeaderText = "Thành tiền (đồng)";
            this.ThanhTien.MinimumWidth = 6;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            // 
            // nudKhoiLuongThua
            // 
            this.nudKhoiLuongThua.BackColor = System.Drawing.Color.Transparent;
            this.nudKhoiLuongThua.BorderRadius = 8;
            this.nudKhoiLuongThua.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudKhoiLuongThua.DecimalPlaces = 3;
            this.nudKhoiLuongThua.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudKhoiLuongThua.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudKhoiLuongThua.Location = new System.Drawing.Point(26, 40);
            this.nudKhoiLuongThua.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.nudKhoiLuongThua.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudKhoiLuongThua.Name = "nudKhoiLuongThua";
            this.nudKhoiLuongThua.Size = new System.Drawing.Size(150, 50);
            this.nudKhoiLuongThua.TabIndex = 0;
            // 
            // cboPhuongThuc
            // 
            this.cboPhuongThuc.BackColor = System.Drawing.Color.Transparent;
            this.cboPhuongThuc.BorderRadius = 8;
            this.cboPhuongThuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThuc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPhuongThuc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPhuongThuc.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboPhuongThuc.ForeColor = System.Drawing.Color.Black;
            this.cboPhuongThuc.ItemHeight = 30;
            this.cboPhuongThuc.Location = new System.Drawing.Point(93, 178);
            this.cboPhuongThuc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboPhuongThuc.Name = "cboPhuongThuc";
            this.cboPhuongThuc.Size = new System.Drawing.Size(170, 36);
            this.cboPhuongThuc.TabIndex = 3;
            // 
            // nudTienKhachDua
            // 
            this.nudTienKhachDua.BackColor = System.Drawing.Color.Transparent;
            this.nudTienKhachDua.BorderRadius = 8;
            this.nudTienKhachDua.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudTienKhachDua.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudTienKhachDua.Location = new System.Drawing.Point(93, 581);
            this.nudTienKhachDua.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.nudTienKhachDua.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudTienKhachDua.Name = "nudTienKhachDua";
            this.nudTienKhachDua.Size = new System.Drawing.Size(150, 45);
            this.nudTienKhachDua.TabIndex = 4;
            this.nudTienKhachDua.ThousandsSeparator = true;
            // 
            // chkDaNhanChuyenKhoan
            // 
            this.chkDaNhanChuyenKhoan.AutoSize = true;
            this.chkDaNhanChuyenKhoan.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDaNhanChuyenKhoan.CheckedState.BorderRadius = 0;
            this.chkDaNhanChuyenKhoan.CheckedState.BorderThickness = 0;
            this.chkDaNhanChuyenKhoan.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDaNhanChuyenKhoan.Location = new System.Drawing.Point(93, 480);
            this.chkDaNhanChuyenKhoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDaNhanChuyenKhoan.Name = "chkDaNhanChuyenKhoan";
            this.chkDaNhanChuyenKhoan.Size = new System.Drawing.Size(232, 29);
            this.chkDaNhanChuyenKhoan.TabIndex = 5;
            this.chkDaNhanChuyenKhoan.Text = "Đã nhận chuyển khoản";
            this.chkDaNhanChuyenKhoan.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDaNhanChuyenKhoan.UncheckedState.BorderRadius = 0;
            this.chkDaNhanChuyenKhoan.UncheckedState.BorderThickness = 0;
            this.chkDaNhanChuyenKhoan.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BorderRadius = 8;
            this.btnThanhToan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThanhToan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(17, 749);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(180, 70);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "Thanh toán";
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
            this.btnDong.Location = new System.Drawing.Point(240, 749);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(180, 70);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.AutoSize = true;
            this.lblPhuongThuc.Location = new System.Drawing.Point(42, 148);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(217, 25);
            this.lblPhuongThuc.TabIndex = 7;
            this.lblPhuongThuc.Text = "Phương thức thanh toán";
            // 
            // lblTienKhachDua
            // 
            this.lblTienKhachDua.AutoSize = true;
            this.lblTienKhachDua.Location = new System.Drawing.Point(42, 550);
            this.lblTienKhachDua.Name = "lblTienKhachDua";
            this.lblTienKhachDua.Size = new System.Drawing.Size(147, 25);
            this.lblTienKhachDua.TabIndex = 7;
            this.lblTienKhachDua.Text = "Tiền khách đưa";
            // 
            // pnlThanhToan
            // 
            this.pnlThanhToan.BackColor = System.Drawing.Color.Transparent;
            this.pnlThanhToan.BorderColor = System.Drawing.Color.Silver;
            this.pnlThanhToan.BorderRadius = 20;
            this.pnlThanhToan.BorderThickness = 1;
            this.pnlThanhToan.Controls.Add(this.picQR);
            this.pnlThanhToan.Controls.Add(this.pnlPhatThua);
            this.pnlThanhToan.Controls.Add(this.lblTienKhachDua);
            this.pnlThanhToan.Controls.Add(this.lblPhuongThuc);
            this.pnlThanhToan.Controls.Add(this.btnDong);
            this.pnlThanhToan.Controls.Add(this.btnThanhToan);
            this.pnlThanhToan.Controls.Add(this.chkDaNhanChuyenKhoan);
            this.pnlThanhToan.Controls.Add(this.lblTongThanhToan);
            this.pnlThanhToan.Controls.Add(this.nudTienKhachDua);
            this.pnlThanhToan.Controls.Add(this.cboPhuongThuc);
            this.pnlThanhToan.Controls.Add(this.lblTienThua);
            this.pnlThanhToan.FillColor = System.Drawing.Color.White;
            this.pnlThanhToan.Location = new System.Drawing.Point(1085, 31);
            this.pnlThanhToan.Name = "pnlThanhToan";
            this.pnlThanhToan.Size = new System.Drawing.Size(434, 842);
            this.pnlThanhToan.TabIndex = 8;
            // 
            // pnlPhatThua
            // 
            this.pnlPhatThua.Controls.Add(this.nudKhoiLuongThua);
            this.pnlPhatThua.Controls.Add(this.lblTienPhat);
            this.pnlPhatThua.Controls.Add(this.lblDonGiaPhat);
            this.pnlPhatThua.Location = new System.Drawing.Point(21, 3);
            this.pnlPhatThua.Name = "pnlPhatThua";
            this.pnlPhatThua.Size = new System.Drawing.Size(382, 128);
            this.pnlPhatThua.TabIndex = 8;
            // 
            // picQR
            // 
            this.picQR.ImageRotate = 0F;
            this.picQR.Location = new System.Drawing.Point(93, 222);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(250, 250);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 9;
            this.picQR.TabStop = false;
            this.picQR.Visible = false;
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 903);
            this.Controls.Add(this.pnlThanhToan);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.lblGioMo);
            this.Controls.Add(this.lblHinhThuc);
            this.Controls.Add(this.lblThongTinBan);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThanhToan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKhoiLuongThua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTienKhachDua)).EndInit();
            this.pnlThanhToan.ResumeLayout(false);
            this.pnlThanhToan.PerformLayout();
            this.pnlPhatThua.ResumeLayout(false);
            this.pnlPhatThua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThongTinBan;
        private System.Windows.Forms.Label lblHinhThuc;
        private System.Windows.Forms.Label lblGioMo;
        private System.Windows.Forms.Label lblTienThua;
        private System.Windows.Forms.Label lblDonGiaPhat;
        private System.Windows.Forms.Label lblTongThanhToan;
        private System.Windows.Forms.Label lblTienPhat;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTietHoaDon;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudKhoiLuongThua;
        private Guna.UI2.WinForms.Guna2ComboBox cboPhuongThuc;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudTienKhachDua;
        private Guna.UI2.WinForms.Guna2CheckBox chkDaNhanChuyenKhoan;
        private Guna.UI2.WinForms.Guna2Button btnThanhToan;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private System.Windows.Forms.Label lblPhuongThuc;
        private System.Windows.Forms.Label lblTienKhachDua;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private Guna.UI2.WinForms.Guna2Panel pnlThanhToan;
        private Guna.UI2.WinForms.Guna2Panel pnlPhatThua;
        private Guna.UI2.WinForms.Guna2PictureBox picQR;
    }
}