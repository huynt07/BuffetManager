namespace BuffetManager.Forms
{
    partial class frmXuLyPhieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuLyPhieu));
            this.lblBoPhan = new System.Windows.Forms.Label();
            this.lblMonDangChon = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.cboTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnBatDau = new Guna.UI2.WinForms.Guna2Button();
            this.btnHoanThanh = new Guna.UI2.WinForms.Guna2Button();
            this.btnDaPhucVu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuyMon = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.dgvChiTietPhieu = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaPG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nguon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioGoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTrangThai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBoPhan
            // 
            this.lblBoPhan.AutoSize = true;
            this.lblBoPhan.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblBoPhan.Location = new System.Drawing.Point(117, 62);
            this.lblBoPhan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBoPhan.Name = "lblBoPhan";
            this.lblBoPhan.Size = new System.Drawing.Size(118, 25);
            this.lblBoPhan.TabIndex = 0;
            this.lblBoPhan.Text = "Bộ phận: —";
            // 
            // lblMonDangChon
            // 
            this.lblMonDangChon.AutoSize = true;
            this.lblMonDangChon.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMonDangChon.Location = new System.Drawing.Point(336, 62);
            this.lblMonDangChon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonDangChon.Name = "lblMonDangChon";
            this.lblMonDangChon.Size = new System.Drawing.Size(180, 25);
            this.lblMonDangChon.TabIndex = 0;
            this.lblMonDangChon.Text = "Món đang chọn: —";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGhiChu.Location = new System.Drawing.Point(608, 62);
            this.lblGhiChu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(115, 25);
            this.lblGhiChu.TabIndex = 0;
            this.lblGhiChu.Text = "Ghi chú: —";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cboTrangThai.BorderRadius = 8;
            this.cboTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangThai.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboTrangThai.ForeColor = System.Drawing.Color.Black;
            this.cboTrangThai.ItemHeight = 30;
            this.cboTrangThai.Location = new System.Drawing.Point(224, 142);
            this.cboTrangThai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(340, 36);
            this.cboTrangThai.TabIndex = 1;
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
            this.btnLamMoi.Location = new System.Drawing.Point(600, 142);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 38);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm mới";
            // 
            // btnBatDau
            // 
            this.btnBatDau.BorderRadius = 8;
            this.btnBatDau.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBatDau.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBatDau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBatDau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBatDau.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBatDau.ForeColor = System.Drawing.Color.White;
            this.btnBatDau.Location = new System.Drawing.Point(30, 235);
            this.btnBatDau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(140, 60);
            this.btnBatDau.TabIndex = 3;
            this.btnBatDau.Text = "Bắt đầu làm";
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.BorderRadius = 8;
            this.btnHoanThanh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHoanThanh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHoanThanh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHoanThanh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHoanThanh.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHoanThanh.ForeColor = System.Drawing.Color.White;
            this.btnHoanThanh.Location = new System.Drawing.Point(200, 235);
            this.btnHoanThanh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(140, 60);
            this.btnHoanThanh.TabIndex = 3;
            this.btnHoanThanh.Text = "Hoàn thành";
            // 
            // btnDaPhucVu
            // 
            this.btnDaPhucVu.BorderRadius = 8;
            this.btnDaPhucVu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDaPhucVu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDaPhucVu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDaPhucVu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDaPhucVu.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDaPhucVu.ForeColor = System.Drawing.Color.White;
            this.btnDaPhucVu.Location = new System.Drawing.Point(370, 235);
            this.btnDaPhucVu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDaPhucVu.Name = "btnDaPhucVu";
            this.btnDaPhucVu.Size = new System.Drawing.Size(140, 60);
            this.btnDaPhucVu.TabIndex = 3;
            this.btnDaPhucVu.Text = "Đã phục vụ";
            // 
            // btnHuyMon
            // 
            this.btnHuyMon.BorderRadius = 8;
            this.btnHuyMon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuyMon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuyMon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuyMon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuyMon.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHuyMon.ForeColor = System.Drawing.Color.White;
            this.btnHuyMon.Location = new System.Drawing.Point(540, 235);
            this.btnHuyMon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHuyMon.Name = "btnHuyMon";
            this.btnHuyMon.Size = new System.Drawing.Size(140, 60);
            this.btnHuyMon.TabIndex = 3;
            this.btnHuyMon.Text = "Hủy món";
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
            this.btnDong.Location = new System.Drawing.Point(710, 235);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(140, 60);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            // 
            // dgvChiTietPhieu
            // 
            this.dgvChiTietPhieu.AllowUserToAddRows = false;
            this.dgvChiTietPhieu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvChiTietPhieu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietPhieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTietPhieu.ColumnHeadersHeight = 50;
            this.dgvChiTietPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChiTietPhieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPG,
            this.TenBan,
            this.TenMon,
            this.Nguon,
            this.SoLuong,
            this.TrangThai,
            this.GioGoi});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietPhieu.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvChiTietPhieu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTietPhieu.Location = new System.Drawing.Point(50, 320);
            this.dgvChiTietPhieu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvChiTietPhieu.MultiSelect = false;
            this.dgvChiTietPhieu.Name = "dgvChiTietPhieu";
            this.dgvChiTietPhieu.ReadOnly = true;
            this.dgvChiTietPhieu.RowHeadersVisible = false;
            this.dgvChiTietPhieu.RowHeadersWidth = 51;
            this.dgvChiTietPhieu.RowTemplate.Height = 24;
            this.dgvChiTietPhieu.Size = new System.Drawing.Size(800, 320);
            this.dgvChiTietPhieu.TabIndex = 4;
            this.dgvChiTietPhieu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTietPhieu.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvChiTietPhieu.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvChiTietPhieu.ThemeStyle.ReadOnly = true;
            this.dgvChiTietPhieu.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvChiTietPhieu.ThemeStyle.RowsStyle.Height = 24;
            // 
            // MaPG
            // 
            this.MaPG.DataPropertyName = "MaPG";
            this.MaPG.FillWeight = 10F;
            this.MaPG.HeaderText = "Phiếu";
            this.MaPG.MinimumWidth = 6;
            this.MaPG.Name = "MaPG";
            this.MaPG.ReadOnly = true;
            // 
            // TenBan
            // 
            this.TenBan.DataPropertyName = "TenBan";
            this.TenBan.FillWeight = 15F;
            this.TenBan.HeaderText = "Bàn hiện tại";
            this.TenBan.MinimumWidth = 6;
            this.TenBan.Name = "TenBan";
            this.TenBan.ReadOnly = true;
            // 
            // TenMon
            // 
            this.TenMon.DataPropertyName = "TenMon";
            this.TenMon.FillWeight = 15F;
            this.TenMon.HeaderText = "Món";
            this.TenMon.MinimumWidth = 6;
            this.TenMon.Name = "TenMon";
            this.TenMon.ReadOnly = true;
            // 
            // Nguon
            // 
            this.Nguon.DataPropertyName = "Nguon";
            this.Nguon.FillWeight = 15F;
            this.Nguon.HeaderText = "Nguồn";
            this.Nguon.MinimumWidth = 6;
            this.Nguon.Name = "Nguon";
            this.Nguon.ReadOnly = true;
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
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.FillWeight = 15F;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // GioGoi
            // 
            this.GioGoi.DataPropertyName = "GioGoi";
            dataGridViewCellStyle3.Format = "dd/MM HH:mm";
            this.GioGoi.DefaultCellStyle = dataGridViewCellStyle3;
            this.GioGoi.FillWeight = 20F;
            this.GioGoi.HeaderText = "Giờ gọi";
            this.GioGoi.MinimumWidth = 6;
            this.GioGoi.Name = "GioGoi";
            this.GioGoi.ReadOnly = true;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTrangThai.Location = new System.Drawing.Point(116, 153);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(100, 25);
            this.lblTrangThai.TabIndex = 5;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // frmXuLyPhieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 653);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.dgvChiTietPhieu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnHuyMon);
            this.Controls.Add(this.btnDaPhucVu);
            this.Controls.Add(this.btnHoanThanh);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblMonDangChon);
            this.Controls.Add(this.lblBoPhan);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXuLyPhieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xử lý phiếu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBoPhan;
        private System.Windows.Forms.Label lblMonDangChon;
        private System.Windows.Forms.Label lblGhiChu;
        private Guna.UI2.WinForms.Guna2ComboBox cboTrangThai;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnBatDau;
        private Guna.UI2.WinForms.Guna2Button btnHoanThanh;
        private Guna.UI2.WinForms.Guna2Button btnDaPhucVu;
        private Guna.UI2.WinForms.Guna2Button btnHuyMon;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTietPhieu;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nguon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioGoi;
    }
}