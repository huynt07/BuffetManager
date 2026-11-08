namespace BuffetManager.Forms
{
    partial class frmGoiMon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoiMon));
            this.lblThongTinBan = new System.Windows.Forms.Label();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.lblGoiBuffet = new System.Windows.Forms.Label();
            this.cboLoaiChon = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.nudSoLuong = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.dgvThucDon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tdLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGhiChu = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoaDong = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuiPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.lblTongTienDot = new System.Windows.Forms.Label();
            this.dgvChiTietGoi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ctgLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctgTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctgSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctgDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctgThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblLoaiChon = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietGoi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThongTinBan
            // 
            this.lblThongTinBan.AutoSize = true;
            this.lblThongTinBan.Location = new System.Drawing.Point(350, 52);
            this.lblThongTinBan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongTinBan.Name = "lblThongTinBan";
            this.lblThongTinBan.Size = new System.Drawing.Size(58, 25);
            this.lblThongTinBan.TabIndex = 0;
            this.lblThongTinBan.Text = "Bàn: ";
            // 
            // lblHinhThuc
            // 
            this.lblHinhThuc.AutoSize = true;
            this.lblHinhThuc.Location = new System.Drawing.Point(694, 52);
            this.lblHinhThuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHinhThuc.Name = "lblHinhThuc";
            this.lblHinhThuc.Size = new System.Drawing.Size(109, 25);
            this.lblHinhThuc.TabIndex = 0;
            this.lblHinhThuc.Text = "Hình thức: ";
            // 
            // lblGoiBuffet
            // 
            this.lblGoiBuffet.AutoSize = true;
            this.lblGoiBuffet.Location = new System.Drawing.Point(1092, 52);
            this.lblGoiBuffet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGoiBuffet.Name = "lblGoiBuffet";
            this.lblGoiBuffet.Size = new System.Drawing.Size(86, 25);
            this.lblGoiBuffet.TabIndex = 0;
            this.lblGoiBuffet.Text = "Mã gói: ";
            // 
            // cboLoaiChon
            // 
            this.cboLoaiChon.BackColor = System.Drawing.Color.Transparent;
            this.cboLoaiChon.BorderRadius = 8;
            this.cboLoaiChon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoaiChon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiChon.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLoaiChon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLoaiChon.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboLoaiChon.ForeColor = System.Drawing.Color.Black;
            this.cboLoaiChon.ItemHeight = 30;
            this.cboLoaiChon.Location = new System.Drawing.Point(75, 156);
            this.cboLoaiChon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboLoaiChon.Name = "cboLoaiChon";
            this.cboLoaiChon.Size = new System.Drawing.Size(233, 36);
            this.cboLoaiChon.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderRadius = 8;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Location = new System.Drawing.Point(422, 157);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(240, 36);
            this.txtTimKiem.TabIndex = 2;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.nudSoLuong.BorderRadius = 8;
            this.nudSoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudSoLuong.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudSoLuong.Location = new System.Drawing.Point(75, 725);
            this.nudSoLuong.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(140, 40);
            this.nudSoLuong.TabIndex = 3;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgvThucDon
            // 
            this.dgvThucDon.AllowUserToAddRows = false;
            this.dgvThucDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvThucDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThucDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThucDon.ColumnHeadersHeight = 50;
            this.dgvThucDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThucDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tdLoai,
            this.tdTen,
            this.tdDonVi,
            this.tdDonGia});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThucDon.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvThucDon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThucDon.Location = new System.Drawing.Point(48, 217);
            this.dgvThucDon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvThucDon.MultiSelect = false;
            this.dgvThucDon.Name = "dgvThucDon";
            this.dgvThucDon.ReadOnly = true;
            this.dgvThucDon.RowHeadersVisible = false;
            this.dgvThucDon.RowHeadersWidth = 51;
            this.dgvThucDon.RowTemplate.Height = 24;
            this.dgvThucDon.Size = new System.Drawing.Size(700, 450);
            this.dgvThucDon.TabIndex = 4;
            this.dgvThucDon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThucDon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvThucDon.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvThucDon.ThemeStyle.ReadOnly = true;
            this.dgvThucDon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvThucDon.ThemeStyle.RowsStyle.Height = 24;
            // 
            // tdLoai
            // 
            this.tdLoai.DataPropertyName = "Loai";
            this.tdLoai.FillWeight = 20F;
            this.tdLoai.HeaderText = "Loại";
            this.tdLoai.MinimumWidth = 6;
            this.tdLoai.Name = "tdLoai";
            this.tdLoai.ReadOnly = true;
            // 
            // tdTen
            // 
            this.tdTen.DataPropertyName = "Ten";
            this.tdTen.FillWeight = 35F;
            this.tdTen.HeaderText = "Tên món / Combo";
            this.tdTen.MinimumWidth = 6;
            this.tdTen.Name = "tdTen";
            this.tdTen.ReadOnly = true;
            // 
            // tdDonVi
            // 
            this.tdDonVi.DataPropertyName = "DonVi";
            this.tdDonVi.FillWeight = 20F;
            this.tdDonVi.HeaderText = "Đơn vị";
            this.tdDonVi.MinimumWidth = 6;
            this.tdDonVi.Name = "tdDonVi";
            this.tdDonVi.ReadOnly = true;
            // 
            // tdDonGia
            // 
            this.tdDonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle3.Format = "N0";
            this.tdDonGia.DefaultCellStyle = dataGridViewCellStyle3;
            this.tdDonGia.FillWeight = 25F;
            this.tdDonGia.HeaderText = "Đơn giá";
            this.tdDonGia.MinimumWidth = 6;
            this.tdDonGia.Name = "tdDonGia";
            this.tdDonGia.ReadOnly = true;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BorderRadius = 8;
            this.txtGhiChu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGhiChu.DefaultText = "";
            this.txtGhiChu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGhiChu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGhiChu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGhiChu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGhiChu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGhiChu.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtGhiChu.ForeColor = System.Drawing.Color.Black;
            this.txtGhiChu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGhiChu.Location = new System.Drawing.Point(422, 725);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.PlaceholderText = "";
            this.txtGhiChu.SelectedText = "";
            this.txtGhiChu.Size = new System.Drawing.Size(250, 40);
            this.txtGhiChu.TabIndex = 5;
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
            this.btnThem.Location = new System.Drawing.Point(48, 790);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(440, 70);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.BorderRadius = 8;
            this.btnXoaDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoaDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoaDong.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoaDong.ForeColor = System.Drawing.Color.White;
            this.btnXoaDong.Location = new System.Drawing.Point(548, 790);
            this.btnXoaDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(200, 70);
            this.btnXoaDong.TabIndex = 6;
            this.btnXoaDong.Text = "Xóa";
            // 
            // btnGuiPhieu
            // 
            this.btnGuiPhieu.BorderRadius = 8;
            this.btnGuiPhieu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuiPhieu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuiPhieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuiPhieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuiPhieu.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnGuiPhieu.ForeColor = System.Drawing.Color.White;
            this.btnGuiPhieu.Location = new System.Drawing.Point(802, 790);
            this.btnGuiPhieu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuiPhieu.Name = "btnGuiPhieu";
            this.btnGuiPhieu.Size = new System.Drawing.Size(200, 70);
            this.btnGuiPhieu.TabIndex = 6;
            this.btnGuiPhieu.Text = "Gửi phiếu";
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
            this.btnLamMoi.Location = new System.Drawing.Point(1052, 790);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(200, 70);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
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
            this.btnDong.Location = new System.Drawing.Point(1302, 790);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(200, 70);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            // 
            // lblTongTienDot
            // 
            this.lblTongTienDot.AutoSize = true;
            this.lblTongTienDot.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongTienDot.Location = new System.Drawing.Point(796, 634);
            this.lblTongTienDot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongTienDot.Name = "lblTongTienDot";
            this.lblTongTienDot.Size = new System.Drawing.Size(121, 33);
            this.lblTongTienDot.TabIndex = 7;
            this.lblTongTienDot.Text = "Tổng tiền";
            // 
            // dgvChiTietGoi
            // 
            this.dgvChiTietGoi.AllowUserToAddRows = false;
            this.dgvChiTietGoi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvChiTietGoi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietGoi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChiTietGoi.ColumnHeadersHeight = 50;
            this.dgvChiTietGoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChiTietGoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctgLoai,
            this.ctgTen,
            this.ctgSoLuong,
            this.ctgDonGia,
            this.ctgThanhTien});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietGoi.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvChiTietGoi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTietGoi.Location = new System.Drawing.Point(802, 126);
            this.dgvChiTietGoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvChiTietGoi.MultiSelect = false;
            this.dgvChiTietGoi.Name = "dgvChiTietGoi";
            this.dgvChiTietGoi.ReadOnly = true;
            this.dgvChiTietGoi.RowHeadersVisible = false;
            this.dgvChiTietGoi.RowHeadersWidth = 51;
            this.dgvChiTietGoi.RowTemplate.Height = 24;
            this.dgvChiTietGoi.Size = new System.Drawing.Size(700, 490);
            this.dgvChiTietGoi.TabIndex = 4;
            this.dgvChiTietGoi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTietGoi.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvChiTietGoi.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvChiTietGoi.ThemeStyle.ReadOnly = true;
            this.dgvChiTietGoi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvChiTietGoi.ThemeStyle.RowsStyle.Height = 24;
            // 
            // ctgLoai
            // 
            this.ctgLoai.DataPropertyName = "Loai";
            this.ctgLoai.FillWeight = 15F;
            this.ctgLoai.HeaderText = "Loại";
            this.ctgLoai.MinimumWidth = 6;
            this.ctgLoai.Name = "ctgLoai";
            this.ctgLoai.ReadOnly = true;
            // 
            // ctgTen
            // 
            this.ctgTen.DataPropertyName = "Ten";
            this.ctgTen.FillWeight = 30F;
            this.ctgTen.HeaderText = "Tên món / Combo";
            this.ctgTen.MinimumWidth = 6;
            this.ctgTen.Name = "ctgTen";
            this.ctgTen.ReadOnly = true;
            // 
            // ctgSoLuong
            // 
            this.ctgSoLuong.DataPropertyName = "SoLuong";
            this.ctgSoLuong.FillWeight = 15F;
            this.ctgSoLuong.HeaderText = "Số lượng";
            this.ctgSoLuong.MinimumWidth = 6;
            this.ctgSoLuong.Name = "ctgSoLuong";
            this.ctgSoLuong.ReadOnly = true;
            // 
            // ctgDonGia
            // 
            this.ctgDonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle7.Format = "N0";
            this.ctgDonGia.DefaultCellStyle = dataGridViewCellStyle7;
            this.ctgDonGia.FillWeight = 20F;
            this.ctgDonGia.HeaderText = "Đơn giá";
            this.ctgDonGia.MinimumWidth = 6;
            this.ctgDonGia.Name = "ctgDonGia";
            this.ctgDonGia.ReadOnly = true;
            // 
            // ctgThanhTien
            // 
            this.ctgThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle8.Format = "N0";
            this.ctgThanhTien.DefaultCellStyle = dataGridViewCellStyle8;
            this.ctgThanhTien.FillWeight = 20F;
            this.ctgThanhTien.HeaderText = "Thành tiền";
            this.ctgThanhTien.MinimumWidth = 6;
            this.ctgThanhTien.Name = "ctgThanhTien";
            this.ctgThanhTien.ReadOnly = true;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(70, 694);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(91, 25);
            this.lblSoLuong.TabIndex = 8;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(417, 694);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(81, 25);
            this.lblGhiChu.TabIndex = 8;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // lblLoaiChon
            // 
            this.lblLoaiChon.AutoSize = true;
            this.lblLoaiChon.Location = new System.Drawing.Point(70, 126);
            this.lblLoaiChon.Name = "lblLoaiChon";
            this.lblLoaiChon.Size = new System.Drawing.Size(98, 25);
            this.lblLoaiChon.TabIndex = 9;
            this.lblLoaiChon.Text = "Loại chọn";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(417, 126);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(97, 25);
            this.lblTimKiem.TabIndex = 9;
            this.lblTimKiem.Text = "Tìm kiếm";
            // 
            // frmGoiMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 903);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.lblLoaiChon);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblTongTienDot);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnGuiPhieu);
            this.Controls.Add(this.btnXoaDong);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.dgvChiTietGoi);
            this.Controls.Add(this.dgvThucDon);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.cboLoaiChon);
            this.Controls.Add(this.lblGoiBuffet);
            this.Controls.Add(this.lblHinhThuc);
            this.Controls.Add(this.lblThongTinBan);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmGoiMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gọi món";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietGoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThongTinBan;
        private System.Windows.Forms.Label lblHinhThuc;
        private System.Windows.Forms.Label lblGoiBuffet;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoaiChon;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudSoLuong;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThucDon;
        private Guna.UI2.WinForms.Guna2TextBox txtGhiChu;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnXoaDong;
        private Guna.UI2.WinForms.Guna2Button btnGuiPhieu;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private System.Windows.Forms.Label lblTongTienDot;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTietGoi;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label lblLoaiChon;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctgLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctgTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctgSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctgDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctgThanhTien;
    }
}