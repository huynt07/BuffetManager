namespace BuffetManager
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnPhanQuyen = new Guna.UI2.WinForms.Guna2Button();
            this.btnDanhMuc = new Guna.UI2.WinForms.Guna2Button();
            this.btnKho = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnNghiepVu = new Guna.UI2.WinForms.Guna2Button();
            this.btnDoiMatKhau = new Guna.UI2.WinForms.Guna2Button();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.cmsDanhMuc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuKhuVuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMucMon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMonAn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGoiBuffet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGoiBuffetMon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCombo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComboMon = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsKho = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNguyenLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDinhLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapKho = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMenuBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.cmsDanhMuc.SuspendLayout();
            this.cmsKho.SuspendLayout();
            this.pnlMenuBottom.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.flpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BorderRadius = 5;
            this.btnTaiKhoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiKhoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiKhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaiKhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnTaiKhoan.Location = new System.Drawing.Point(3, 3);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(210, 60);
            this.btnTaiKhoan.TabIndex = 0;
            this.btnTaiKhoan.Text = "Quản lý tài khoản";
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.BorderRadius = 5;
            this.btnPhanQuyen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPhanQuyen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPhanQuyen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPhanQuyen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPhanQuyen.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPhanQuyen.ForeColor = System.Drawing.Color.White;
            this.btnPhanQuyen.Location = new System.Drawing.Point(3, 69);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.Size = new System.Drawing.Size(210, 60);
            this.btnPhanQuyen.TabIndex = 0;
            this.btnPhanQuyen.Text = "Phân quyền";
            this.btnPhanQuyen.Click += new System.EventHandler(this.btnPhanQuyen_Click);
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.BorderRadius = 5;
            this.btnDanhMuc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDanhMuc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDanhMuc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDanhMuc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDanhMuc.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDanhMuc.ForeColor = System.Drawing.Color.White;
            this.btnDanhMuc.Location = new System.Drawing.Point(3, 201);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(210, 60);
            this.btnDanhMuc.TabIndex = 0;
            this.btnDanhMuc.Text = "Danh mục";
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnKho
            // 
            this.btnKho.BorderRadius = 5;
            this.btnKho.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKho.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKho.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKho.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKho.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnKho.ForeColor = System.Drawing.Color.White;
            this.btnKho.Location = new System.Drawing.Point(3, 267);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(210, 60);
            this.btnKho.TabIndex = 0;
            this.btnKho.Text = "Quản lý kho";
            this.btnKho.Click += new System.EventHandler(this.btnKho_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.BorderRadius = 5;
            this.btnBaoCao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBaoCao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBaoCao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBaoCao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBaoCao.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.Location = new System.Drawing.Point(3, 333);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(210, 60);
            this.btnBaoCao.TabIndex = 0;
            this.btnBaoCao.Text = "Báo cáo";
            // 
            // btnNghiepVu
            // 
            this.btnNghiepVu.BorderRadius = 5;
            this.btnNghiepVu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNghiepVu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNghiepVu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNghiepVu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNghiepVu.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNghiepVu.ForeColor = System.Drawing.Color.White;
            this.btnNghiepVu.Location = new System.Drawing.Point(3, 135);
            this.btnNghiepVu.Name = "btnNghiepVu";
            this.btnNghiepVu.Size = new System.Drawing.Size(210, 60);
            this.btnNghiepVu.TabIndex = 0;
            this.btnNghiepVu.Text = "Nghiệp vụ nhà hàng";
            this.btnNghiepVu.Click += new System.EventHandler(this.btnNghiepVu_Click);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.BorderRadius = 5;
            this.btnDoiMatKhau.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDoiMatKhau.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDoiMatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDoiMatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDoiMatKhau.FillColor = System.Drawing.Color.Silver;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(3, 9);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(210, 60);
            this.btnDoiMatKhau.TabIndex = 0;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BorderRadius = 5;
            this.btnDangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangXuat.FillColor = System.Drawing.Color.Tomato;
            this.btnDangXuat.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(3, 75);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(210, 60);
            this.btnDangXuat.TabIndex = 0;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // cmsDanhMuc
            // 
            this.cmsDanhMuc.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDanhMuc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKhuVuc,
            this.mnuBan,
            this.mnuDanhMucMon,
            this.mnuMonAn,
            this.mnuGoiBuffet,
            this.mnuGoiBuffetMon,
            this.mnuCombo,
            this.mnuComboMon});
            this.cmsDanhMuc.Name = "cmsDanhMuc";
            this.cmsDanhMuc.Size = new System.Drawing.Size(220, 196);
            // 
            // mnuKhuVuc
            // 
            this.mnuKhuVuc.Name = "mnuKhuVuc";
            this.mnuKhuVuc.Size = new System.Drawing.Size(219, 24);
            this.mnuKhuVuc.Text = "Khu vực";
            this.mnuKhuVuc.Click += new System.EventHandler(this.mnuKhuVuc_Click);
            // 
            // mnuBan
            // 
            this.mnuBan.Name = "mnuBan";
            this.mnuBan.Size = new System.Drawing.Size(219, 24);
            this.mnuBan.Text = "Bàn";
            this.mnuBan.Click += new System.EventHandler(this.mnuBan_Click);
            // 
            // mnuDanhMucMon
            // 
            this.mnuDanhMucMon.Name = "mnuDanhMucMon";
            this.mnuDanhMucMon.Size = new System.Drawing.Size(219, 24);
            this.mnuDanhMucMon.Text = "Danh mục món";
            this.mnuDanhMucMon.Click += new System.EventHandler(this.mnuDanhMucMon_Click);
            // 
            // mnuMonAn
            // 
            this.mnuMonAn.Name = "mnuMonAn";
            this.mnuMonAn.Size = new System.Drawing.Size(219, 24);
            this.mnuMonAn.Text = "Món ăn";
            this.mnuMonAn.Click += new System.EventHandler(this.mnuMonAn_Click);
            // 
            // mnuGoiBuffet
            // 
            this.mnuGoiBuffet.Name = "mnuGoiBuffet";
            this.mnuGoiBuffet.Size = new System.Drawing.Size(219, 24);
            this.mnuGoiBuffet.Text = "Gói buffet";
            this.mnuGoiBuffet.Click += new System.EventHandler(this.mnuGoiBuffet_Click);
            // 
            // mnuGoiBuffetMon
            // 
            this.mnuGoiBuffetMon.Name = "mnuGoiBuffetMon";
            this.mnuGoiBuffetMon.Size = new System.Drawing.Size(219, 24);
            this.mnuGoiBuffetMon.Text = "Món thuộc gói buffet";
            this.mnuGoiBuffetMon.Click += new System.EventHandler(this.mnuGoiBuffetMon_Click);
            // 
            // mnuCombo
            // 
            this.mnuCombo.Name = "mnuCombo";
            this.mnuCombo.Size = new System.Drawing.Size(219, 24);
            this.mnuCombo.Text = "Combo";
            this.mnuCombo.Click += new System.EventHandler(this.mnuCombo_Click);
            // 
            // mnuComboMon
            // 
            this.mnuComboMon.Name = "mnuComboMon";
            this.mnuComboMon.Size = new System.Drawing.Size(219, 24);
            this.mnuComboMon.Text = "Món thuộc combo";
            this.mnuComboMon.Click += new System.EventHandler(this.mnuComboMon_Click);
            // 
            // cmsKho
            // 
            this.cmsKho.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsKho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNguyenLieu,
            this.mnuDinhLuong,
            this.mnuNhapKho});
            this.cmsKho.Name = "cmsKho";
            this.cmsKho.Size = new System.Drawing.Size(158, 76);
            // 
            // mnuNguyenLieu
            // 
            this.mnuNguyenLieu.Name = "mnuNguyenLieu";
            this.mnuNguyenLieu.Size = new System.Drawing.Size(157, 24);
            this.mnuNguyenLieu.Text = "Nguyên liệu";
            this.mnuNguyenLieu.Click += new System.EventHandler(this.mnuNguyenLieu_Click);
            // 
            // mnuDinhLuong
            // 
            this.mnuDinhLuong.Name = "mnuDinhLuong";
            this.mnuDinhLuong.Size = new System.Drawing.Size(157, 24);
            this.mnuDinhLuong.Text = "Định lượng";
            this.mnuDinhLuong.Click += new System.EventHandler(this.mnuDinhLuong_Click);
            // 
            // mnuNhapKho
            // 
            this.mnuNhapKho.Name = "mnuNhapKho";
            this.mnuNhapKho.Size = new System.Drawing.Size(157, 24);
            this.mnuNhapKho.Text = "Nhập kho";
            this.mnuNhapKho.Click += new System.EventHandler(this.mnuNhapKho_Click);
            // 
            // pnlMenuBottom
            // 
            this.pnlMenuBottom.Controls.Add(this.btnDoiMatKhau);
            this.pnlMenuBottom.Controls.Add(this.btnDangXuat);
            this.pnlMenuBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMenuBottom.Location = new System.Drawing.Point(0, 613);
            this.pnlMenuBottom.Name = "pnlMenuBottom";
            this.pnlMenuBottom.Size = new System.Drawing.Size(220, 140);
            this.pnlMenuBottom.TabIndex = 1;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(120)))), ((int)(((byte)(77)))));
            this.pnlMenu.Controls.Add(this.flpMenu);
            this.pnlMenu.Controls.Add(this.pnlMenuBottom);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(220, 753);
            this.pnlMenu.TabIndex = 3;
            // 
            // flpMenu
            // 
            this.flpMenu.AutoScroll = true;
            this.flpMenu.Controls.Add(this.btnTaiKhoan);
            this.flpMenu.Controls.Add(this.btnPhanQuyen);
            this.flpMenu.Controls.Add(this.btnNghiepVu);
            this.flpMenu.Controls.Add(this.btnDanhMuc);
            this.flpMenu.Controls.Add(this.btnKho);
            this.flpMenu.Controls.Add(this.btnBaoCao);
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMenu.Location = new System.Drawing.Point(0, 0);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(220, 613);
            this.flpMenu.TabIndex = 0;
            this.flpMenu.WrapContents = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BuffetManager.Properties.Resources.nen_nha_hang;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1202, 753);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "Quản trị nhà hàng buffet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.cmsDanhMuc.ResumeLayout(false);
            this.cmsKho.ResumeLayout(false);
            this.pnlMenuBottom.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.flpMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnTaiKhoan;
        private Guna.UI2.WinForms.Guna2Button btnPhanQuyen;
        private Guna.UI2.WinForms.Guna2Button btnDanhMuc;
        private Guna.UI2.WinForms.Guna2Button btnKho;
        private Guna.UI2.WinForms.Guna2Button btnBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnNghiepVu;
        private Guna.UI2.WinForms.Guna2Button btnDoiMatKhau;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private System.Windows.Forms.ContextMenuStrip cmsDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuKhuVuc;
        private System.Windows.Forms.ToolStripMenuItem mnuBan;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMucMon;
        private System.Windows.Forms.ToolStripMenuItem mnuMonAn;
        private System.Windows.Forms.ToolStripMenuItem mnuGoiBuffet;
        private System.Windows.Forms.ToolStripMenuItem mnuGoiBuffetMon;
        private System.Windows.Forms.ToolStripMenuItem mnuCombo;
        private System.Windows.Forms.ToolStripMenuItem mnuComboMon;
        private System.Windows.Forms.ContextMenuStrip cmsKho;
        private System.Windows.Forms.ToolStripMenuItem mnuNguyenLieu;
        private System.Windows.Forms.ToolStripMenuItem mnuDinhLuong;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapKho;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBottom;
        private Guna.UI2.WinForms.Guna2Panel pnlMenu;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
    }
}

