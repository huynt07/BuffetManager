namespace BuffetManager.Forms
{
    partial class frmDatBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatBan));
            this.cboBan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtHoTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSDT = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpGioDen = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.nudSoKhach = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btnDatBan = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuyDat = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDatBan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaDatBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoKhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBan = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblSoKhach = new System.Windows.Forms.Label();
            this.lblGioDen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoKhach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatBan)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBan
            // 
            this.cboBan.BackColor = System.Drawing.Color.Transparent;
            this.cboBan.BorderRadius = 8;
            this.cboBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBan.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboBan.ForeColor = System.Drawing.Color.Black;
            this.cboBan.ItemHeight = 30;
            this.cboBan.Location = new System.Drawing.Point(187, 69);
            this.cboBan.Name = "cboBan";
            this.cboBan.Size = new System.Drawing.Size(150, 36);
            this.cboBan.TabIndex = 0;
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.Color.Transparent;
            this.txtHoTen.BorderRadius = 8;
            this.txtHoTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHoTen.DefaultText = "";
            this.txtHoTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHoTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHoTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHoTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHoTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHoTen.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtHoTen.ForeColor = System.Drawing.Color.Black;
            this.txtHoTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHoTen.Location = new System.Drawing.Point(461, 65);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHoTen.MaxLength = 50;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.PlaceholderText = "";
            this.txtHoTen.SelectedText = "";
            this.txtHoTen.Size = new System.Drawing.Size(170, 40);
            this.txtHoTen.TabIndex = 1;
            // 
            // txtSDT
            // 
            this.txtSDT.BackColor = System.Drawing.Color.Transparent;
            this.txtSDT.BorderRadius = 8;
            this.txtSDT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSDT.DefaultText = "";
            this.txtSDT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSDT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSDT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSDT.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSDT.ForeColor = System.Drawing.Color.Black;
            this.txtSDT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSDT.Location = new System.Drawing.Point(743, 66);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSDT.MaxLength = 15;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.PlaceholderText = "";
            this.txtSDT.SelectedText = "";
            this.txtSDT.Size = new System.Drawing.Size(170, 40);
            this.txtSDT.TabIndex = 1;
            // 
            // dtpGioDen
            // 
            this.dtpGioDen.BorderRadius = 8;
            this.dtpGioDen.Checked = true;
            this.dtpGioDen.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpGioDen.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpGioDen.Location = new System.Drawing.Point(250, 163);
            this.dtpGioDen.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpGioDen.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpGioDen.Name = "dtpGioDen";
            this.dtpGioDen.Size = new System.Drawing.Size(290, 50);
            this.dtpGioDen.TabIndex = 2;
            this.dtpGioDen.Value = new System.DateTime(2026, 10, 29, 2, 39, 56, 140);
            // 
            // nudSoKhach
            // 
            this.nudSoKhach.BackColor = System.Drawing.Color.Transparent;
            this.nudSoKhach.BorderRadius = 8;
            this.nudSoKhach.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudSoKhach.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudSoKhach.Location = new System.Drawing.Point(697, 163);
            this.nudSoKhach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudSoKhach.Name = "nudSoKhach";
            this.nudSoKhach.Size = new System.Drawing.Size(110, 40);
            this.nudSoKhach.TabIndex = 3;
            this.nudSoKhach.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnDatBan
            // 
            this.btnDatBan.BackColor = System.Drawing.Color.Transparent;
            this.btnDatBan.BorderRadius = 8;
            this.btnDatBan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDatBan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDatBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDatBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDatBan.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDatBan.ForeColor = System.Drawing.Color.White;
            this.btnDatBan.Location = new System.Drawing.Point(200, 255);
            this.btnDatBan.Name = "btnDatBan";
            this.btnDatBan.Size = new System.Drawing.Size(140, 60);
            this.btnDatBan.TabIndex = 4;
            this.btnDatBan.Text = "Đặt bàn";
            this.btnDatBan.Click += new System.EventHandler(this.btnDatBan_Click);
            // 
            // btnHuyDat
            // 
            this.btnHuyDat.BackColor = System.Drawing.Color.Transparent;
            this.btnHuyDat.BorderRadius = 8;
            this.btnHuyDat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuyDat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuyDat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuyDat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuyDat.Enabled = false;
            this.btnHuyDat.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHuyDat.ForeColor = System.Drawing.Color.White;
            this.btnHuyDat.Location = new System.Drawing.Point(385, 255);
            this.btnHuyDat.Name = "btnHuyDat";
            this.btnHuyDat.Size = new System.Drawing.Size(140, 60);
            this.btnHuyDat.TabIndex = 4;
            this.btnHuyDat.Text = "Hủy đặt";
            this.btnHuyDat.Click += new System.EventHandler(this.btnHuyDat_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Transparent;
            this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(573, 255);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 60);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Transparent;
            this.btnDong.BorderRadius = 8;
            this.btnDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(760, 255);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(140, 60);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dgvDatBan
            // 
            this.dgvDatBan.AllowUserToAddRows = false;
            this.dgvDatBan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDatBan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatBan.ColumnHeadersHeight = 50;
            this.dgvDatBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDatBan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDatBan,
            this.TenBan,
            this.HoTen,
            this.SDT,
            this.GioDen,
            this.SoKhach,
            this.TenTrangThai,
            this.MaBan,
            this.TrangThai});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatBan.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDatBan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDatBan.Location = new System.Drawing.Point(91, 346);
            this.dgvDatBan.MultiSelect = false;
            this.dgvDatBan.Name = "dgvDatBan";
            this.dgvDatBan.ReadOnly = true;
            this.dgvDatBan.RowHeadersVisible = false;
            this.dgvDatBan.RowHeadersWidth = 51;
            this.dgvDatBan.RowTemplate.Height = 24;
            this.dgvDatBan.Size = new System.Drawing.Size(900, 280);
            this.dgvDatBan.TabIndex = 5;
            this.dgvDatBan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDatBan.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvDatBan.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvDatBan.ThemeStyle.ReadOnly = true;
            this.dgvDatBan.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvDatBan.ThemeStyle.RowsStyle.Height = 24;
            this.dgvDatBan.SelectionChanged += new System.EventHandler(this.dgvDatBan_SelectionChanged);
            // 
            // MaDatBan
            // 
            this.MaDatBan.DataPropertyName = "MaDatBan";
            this.MaDatBan.FillWeight = 16F;
            this.MaDatBan.HeaderText = "Mã đặt bàn";
            this.MaDatBan.MinimumWidth = 6;
            this.MaDatBan.Name = "MaDatBan";
            this.MaDatBan.ReadOnly = true;
            // 
            // TenBan
            // 
            this.TenBan.DataPropertyName = "TenBan";
            this.TenBan.FillWeight = 10F;
            this.TenBan.HeaderText = "Bàn";
            this.TenBan.MinimumWidth = 6;
            this.TenBan.Name = "TenBan";
            this.TenBan.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.FillWeight = 18F;
            this.HoTen.HeaderText = "Tên khách hàng";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // SDT
            // 
            this.SDT.DataPropertyName = "SDT";
            this.SDT.FillWeight = 16F;
            this.SDT.HeaderText = "Số điện thoại";
            this.SDT.MinimumWidth = 6;
            this.SDT.Name = "SDT";
            this.SDT.ReadOnly = true;
            // 
            // GioDen
            // 
            this.GioDen.DataPropertyName = "GioDen";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm";
            this.GioDen.DefaultCellStyle = dataGridViewCellStyle3;
            this.GioDen.FillWeight = 20F;
            this.GioDen.HeaderText = "Giờ đến";
            this.GioDen.MinimumWidth = 6;
            this.GioDen.Name = "GioDen";
            this.GioDen.ReadOnly = true;
            // 
            // SoKhach
            // 
            this.SoKhach.DataPropertyName = "SoKhach";
            this.SoKhach.FillWeight = 12F;
            this.SoKhach.HeaderText = "Số khách";
            this.SoKhach.MinimumWidth = 6;
            this.SoKhach.Name = "SoKhach";
            this.SoKhach.ReadOnly = true;
            // 
            // TenTrangThai
            // 
            this.TenTrangThai.DataPropertyName = "TenTrangThai";
            this.TenTrangThai.FillWeight = 14F;
            this.TenTrangThai.HeaderText = "Trạng thái";
            this.TenTrangThai.MinimumWidth = 6;
            this.TenTrangThai.Name = "TenTrangThai";
            this.TenTrangThai.ReadOnly = true;
            // 
            // MaBan
            // 
            this.MaBan.DataPropertyName = "MaBan";
            this.MaBan.HeaderText = "Mã bàn";
            this.MaBan.MinimumWidth = 6;
            this.MaBan.Name = "MaBan";
            this.MaBan.ReadOnly = true;
            this.MaBan.Visible = false;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.FillWeight = 15F;
            this.TrangThai.HeaderText = "Mã trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Visible = false;
            // 
            // lblBan
            // 
            this.lblBan.AutoSize = true;
            this.lblBan.BackColor = System.Drawing.Color.Transparent;
            this.lblBan.Location = new System.Drawing.Point(182, 41);
            this.lblBan.Name = "lblBan";
            this.lblBan.Size = new System.Drawing.Size(95, 25);
            this.lblBan.TabIndex = 6;
            this.lblBan.Text = "Chọn bàn";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.BackColor = System.Drawing.Color.Transparent;
            this.lblHoTen.Location = new System.Drawing.Point(456, 37);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(149, 25);
            this.lblHoTen.TabIndex = 6;
            this.lblHoTen.Text = "Tên khách hàng";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.BackColor = System.Drawing.Color.Transparent;
            this.lblSDT.Location = new System.Drawing.Point(738, 37);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(127, 25);
            this.lblSDT.TabIndex = 6;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // lblSoKhach
            // 
            this.lblSoKhach.AutoSize = true;
            this.lblSoKhach.BackColor = System.Drawing.Color.Transparent;
            this.lblSoKhach.Location = new System.Drawing.Point(692, 138);
            this.lblSoKhach.Name = "lblSoKhach";
            this.lblSoKhach.Size = new System.Drawing.Size(91, 25);
            this.lblSoKhach.TabIndex = 6;
            this.lblSoKhach.Text = "Số người";
            // 
            // lblGioDen
            // 
            this.lblGioDen.AutoSize = true;
            this.lblGioDen.BackColor = System.Drawing.Color.Transparent;
            this.lblGioDen.Location = new System.Drawing.Point(245, 138);
            this.lblGioDen.Name = "lblGioDen";
            this.lblGioDen.Size = new System.Drawing.Size(83, 25);
            this.lblGioDen.TabIndex = 6;
            this.lblGioDen.Text = "Giờ đến";
            // 
            // frmDatBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BuffetManager.Properties.Resources.nen_kem;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.lblGioDen);
            this.Controls.Add(this.lblSoKhach);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblBan);
            this.Controls.Add(this.dgvDatBan);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnHuyDat);
            this.Controls.Add(this.btnDatBan);
            this.Controls.Add(this.nudSoKhach);
            this.Controls.Add(this.dtpGioDen);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.cboBan);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đặt bàn";
            this.Load += new System.EventHandler(this.frmDatBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoKhach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatBan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cboBan;
        private Guna.UI2.WinForms.Guna2TextBox txtHoTen;
        private Guna.UI2.WinForms.Guna2TextBox txtSDT;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpGioDen;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudSoKhach;
        private Guna.UI2.WinForms.Guna2Button btnDatBan;
        private Guna.UI2.WinForms.Guna2Button btnHuyDat;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDatBan;
        private System.Windows.Forms.Label lblBan;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblSoKhach;
        private System.Windows.Forms.Label lblGioDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDatBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoKhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}