namespace BuffetManager.Forms
{
    partial class frmMoBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoBan));
            this.cboBan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboHinhThuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.chkCoDatTruoc = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnMoBan = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.cboDatBan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlBuffet = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTren1m3 = new System.Windows.Forms.Label();
            this.lblTu1mDen1m3 = new System.Windows.Forms.Label();
            this.lblDuoi1m = new System.Windows.Forms.Label();
            this.lblGoiBuffet = new System.Windows.Forms.Label();
            this.lblTienVe = new System.Windows.Forms.Label();
            this.lblTongKhach = new System.Windows.Forms.Label();
            this.nudTren1m3 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nudTu1mDen1m3 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nudDuoi1m = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.cboGoiBuffet = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDatBan = new System.Windows.Forms.Label();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.lblBan = new System.Windows.Forms.Label();
            this.pnlBuffet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTren1m3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTu1mDen1m3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuoi1m)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBan
            // 
            this.cboBan.BackColor = System.Drawing.Color.Transparent;
            this.cboBan.BorderColor = System.Drawing.Color.Transparent;
            this.cboBan.BorderRadius = 8;
            this.cboBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBan.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboBan.ForeColor = System.Drawing.Color.Black;
            this.cboBan.ItemHeight = 30;
            this.cboBan.Location = new System.Drawing.Point(138, 71);
            this.cboBan.Name = "cboBan";
            this.cboBan.Size = new System.Drawing.Size(200, 36);
            this.cboBan.TabIndex = 0;
            this.cboBan.SelectionChangeCommitted += new System.EventHandler(this.cboBan_SelectionChangeCommitted);
            // 
            // cboHinhThuc
            // 
            this.cboHinhThuc.BackColor = System.Drawing.Color.Transparent;
            this.cboHinhThuc.BorderColor = System.Drawing.Color.Transparent;
            this.cboHinhThuc.BorderRadius = 8;
            this.cboHinhThuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboHinhThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHinhThuc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboHinhThuc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboHinhThuc.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboHinhThuc.ForeColor = System.Drawing.Color.Black;
            this.cboHinhThuc.ItemHeight = 30;
            this.cboHinhThuc.Location = new System.Drawing.Point(724, 71);
            this.cboHinhThuc.Name = "cboHinhThuc";
            this.cboHinhThuc.Size = new System.Drawing.Size(210, 36);
            this.cboHinhThuc.TabIndex = 0;
            this.cboHinhThuc.SelectedIndexChanged += new System.EventHandler(this.cboHinhThuc_SelectedIndexChanged);
            // 
            // chkCoDatTruoc
            // 
            this.chkCoDatTruoc.AutoSize = true;
            this.chkCoDatTruoc.BackColor = System.Drawing.Color.Transparent;
            this.chkCoDatTruoc.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCoDatTruoc.CheckedState.BorderRadius = 0;
            this.chkCoDatTruoc.CheckedState.BorderThickness = 0;
            this.chkCoDatTruoc.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCoDatTruoc.Location = new System.Drawing.Point(823, 153);
            this.chkCoDatTruoc.Name = "chkCoDatTruoc";
            this.chkCoDatTruoc.Size = new System.Drawing.Size(186, 29);
            this.chkCoDatTruoc.TabIndex = 1;
            this.chkCoDatTruoc.Text = "Khách đã đặt bàn";
            this.chkCoDatTruoc.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkCoDatTruoc.UncheckedState.BorderRadius = 0;
            this.chkCoDatTruoc.UncheckedState.BorderThickness = 0;
            this.chkCoDatTruoc.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkCoDatTruoc.UseVisualStyleBackColor = false;
            this.chkCoDatTruoc.CheckedChanged += new System.EventHandler(this.chkCoDatTruoc_CheckedChanged);
            // 
            // btnMoBan
            // 
            this.btnMoBan.BackColor = System.Drawing.Color.Transparent;
            this.btnMoBan.BorderRadius = 8;
            this.btnMoBan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMoBan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMoBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMoBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMoBan.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnMoBan.ForeColor = System.Drawing.Color.White;
            this.btnMoBan.Location = new System.Drawing.Point(252, 540);
            this.btnMoBan.Name = "btnMoBan";
            this.btnMoBan.Size = new System.Drawing.Size(180, 70);
            this.btnMoBan.TabIndex = 2;
            this.btnMoBan.Text = "Mở bàn";
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
            this.btnDong.Location = new System.Drawing.Point(667, 540);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(180, 70);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // cboDatBan
            // 
            this.cboDatBan.BackColor = System.Drawing.Color.Transparent;
            this.cboDatBan.BorderColor = System.Drawing.Color.Transparent;
            this.cboDatBan.BorderRadius = 8;
            this.cboDatBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDatBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatBan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDatBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDatBan.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboDatBan.ForeColor = System.Drawing.Color.Black;
            this.cboDatBan.ItemHeight = 30;
            this.cboDatBan.Location = new System.Drawing.Point(441, 71);
            this.cboDatBan.Name = "cboDatBan";
            this.cboDatBan.Size = new System.Drawing.Size(200, 36);
            this.cboDatBan.TabIndex = 0;
            // 
            // pnlBuffet
            // 
            this.pnlBuffet.BackColor = System.Drawing.Color.Transparent;
            this.pnlBuffet.Controls.Add(this.lblTren1m3);
            this.pnlBuffet.Controls.Add(this.lblTu1mDen1m3);
            this.pnlBuffet.Controls.Add(this.lblDuoi1m);
            this.pnlBuffet.Controls.Add(this.lblGoiBuffet);
            this.pnlBuffet.Controls.Add(this.lblTienVe);
            this.pnlBuffet.Controls.Add(this.lblTongKhach);
            this.pnlBuffet.Controls.Add(this.nudTren1m3);
            this.pnlBuffet.Controls.Add(this.nudTu1mDen1m3);
            this.pnlBuffet.Controls.Add(this.nudDuoi1m);
            this.pnlBuffet.Controls.Add(this.cboGoiBuffet);
            this.pnlBuffet.Location = new System.Drawing.Point(109, 206);
            this.pnlBuffet.Name = "pnlBuffet";
            this.pnlBuffet.Size = new System.Drawing.Size(900, 300);
            this.pnlBuffet.TabIndex = 3;
            // 
            // lblTren1m3
            // 
            this.lblTren1m3.AutoSize = true;
            this.lblTren1m3.Location = new System.Drawing.Point(642, 110);
            this.lblTren1m3.Name = "lblTren1m3";
            this.lblTren1m3.Size = new System.Drawing.Size(96, 25);
            this.lblTren1m3.TabIndex = 4;
            this.lblTren1m3.Text = "Trên 1m3";
            // 
            // lblTu1mDen1m3
            // 
            this.lblTu1mDen1m3.AutoSize = true;
            this.lblTu1mDen1m3.Location = new System.Drawing.Point(387, 110);
            this.lblTu1mDen1m3.Name = "lblTu1mDen1m3";
            this.lblTu1mDen1m3.Size = new System.Drawing.Size(128, 25);
            this.lblTu1mDen1m3.TabIndex = 4;
            this.lblTu1mDen1m3.Text = "Từ 1m - 1m3";
            // 
            // lblDuoi1m
            // 
            this.lblDuoi1m.AutoSize = true;
            this.lblDuoi1m.Location = new System.Drawing.Point(149, 109);
            this.lblDuoi1m.Name = "lblDuoi1m";
            this.lblDuoi1m.Size = new System.Drawing.Size(91, 25);
            this.lblDuoi1m.TabIndex = 4;
            this.lblDuoi1m.Text = "Dưới 1m";
            // 
            // lblGoiBuffet
            // 
            this.lblGoiBuffet.AutoSize = true;
            this.lblGoiBuffet.BackColor = System.Drawing.Color.Transparent;
            this.lblGoiBuffet.Location = new System.Drawing.Point(24, 17);
            this.lblGoiBuffet.Name = "lblGoiBuffet";
            this.lblGoiBuffet.Size = new System.Drawing.Size(103, 25);
            this.lblGoiBuffet.TabIndex = 3;
            this.lblGoiBuffet.Text = "Gói buffet";
            // 
            // lblTienVe
            // 
            this.lblTienVe.AutoSize = true;
            this.lblTienVe.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTienVe.Location = new System.Drawing.Point(518, 244);
            this.lblTienVe.Name = "lblTienVe";
            this.lblTienVe.Size = new System.Drawing.Size(145, 33);
            this.lblTienVe.TabIndex = 2;
            this.lblTienVe.Text = "Tiền vé: 0 đ";
            // 
            // lblTongKhach
            // 
            this.lblTongKhach.AutoSize = true;
            this.lblTongKhach.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongKhach.Location = new System.Drawing.Point(183, 244);
            this.lblTongKhach.Name = "lblTongKhach";
            this.lblTongKhach.Size = new System.Drawing.Size(174, 33);
            this.lblTongKhach.TabIndex = 2;
            this.lblTongKhach.Text = "Tổng khách: 0";
            // 
            // nudTren1m3
            // 
            this.nudTren1m3.BackColor = System.Drawing.Color.Transparent;
            this.nudTren1m3.BorderRadius = 8;
            this.nudTren1m3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudTren1m3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudTren1m3.Location = new System.Drawing.Point(650, 139);
            this.nudTren1m3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudTren1m3.Name = "nudTren1m3";
            this.nudTren1m3.Size = new System.Drawing.Size(120, 36);
            this.nudTren1m3.TabIndex = 1;
            this.nudTren1m3.ValueChanged += new System.EventHandler(this.SoKhach_ValueChanged);
            // 
            // nudTu1mDen1m3
            // 
            this.nudTu1mDen1m3.BackColor = System.Drawing.Color.Transparent;
            this.nudTu1mDen1m3.BorderRadius = 8;
            this.nudTu1mDen1m3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudTu1mDen1m3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudTu1mDen1m3.Location = new System.Drawing.Point(392, 139);
            this.nudTu1mDen1m3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudTu1mDen1m3.Name = "nudTu1mDen1m3";
            this.nudTu1mDen1m3.Size = new System.Drawing.Size(120, 36);
            this.nudTu1mDen1m3.TabIndex = 1;
            this.nudTu1mDen1m3.ValueChanged += new System.EventHandler(this.SoKhach_ValueChanged);
            // 
            // nudDuoi1m
            // 
            this.nudDuoi1m.BackColor = System.Drawing.Color.Transparent;
            this.nudDuoi1m.BorderRadius = 8;
            this.nudDuoi1m.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudDuoi1m.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudDuoi1m.Location = new System.Drawing.Point(154, 139);
            this.nudDuoi1m.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudDuoi1m.Name = "nudDuoi1m";
            this.nudDuoi1m.Size = new System.Drawing.Size(120, 36);
            this.nudDuoi1m.TabIndex = 1;
            this.nudDuoi1m.ValueChanged += new System.EventHandler(this.SoKhach_ValueChanged);
            // 
            // cboGoiBuffet
            // 
            this.cboGoiBuffet.BackColor = System.Drawing.Color.Transparent;
            this.cboGoiBuffet.BorderRadius = 8;
            this.cboGoiBuffet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGoiBuffet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGoiBuffet.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboGoiBuffet.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboGoiBuffet.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboGoiBuffet.ForeColor = System.Drawing.Color.Black;
            this.cboGoiBuffet.ItemHeight = 30;
            this.cboGoiBuffet.Location = new System.Drawing.Point(29, 45);
            this.cboGoiBuffet.Name = "cboGoiBuffet";
            this.cboGoiBuffet.Size = new System.Drawing.Size(160, 36);
            this.cboGoiBuffet.TabIndex = 0;
            this.cboGoiBuffet.SelectedIndexChanged += new System.EventHandler(this.cboGoiBuffet_SelectedIndexChanged);
            // 
            // lblDatBan
            // 
            this.lblDatBan.AutoSize = true;
            this.lblDatBan.BackColor = System.Drawing.Color.Transparent;
            this.lblDatBan.Location = new System.Drawing.Point(436, 43);
            this.lblDatBan.Name = "lblDatBan";
            this.lblDatBan.Size = new System.Drawing.Size(81, 25);
            this.lblDatBan.TabIndex = 4;
            this.lblDatBan.Text = "Đặt bàn";
            // 
            // lblHinhThuc
            // 
            this.lblHinhThuc.AutoSize = true;
            this.lblHinhThuc.BackColor = System.Drawing.Color.Transparent;
            this.lblHinhThuc.Location = new System.Drawing.Point(719, 43);
            this.lblHinhThuc.Name = "lblHinhThuc";
            this.lblHinhThuc.Size = new System.Drawing.Size(97, 25);
            this.lblHinhThuc.TabIndex = 4;
            this.lblHinhThuc.Text = "Hình thức";
            // 
            // lblBan
            // 
            this.lblBan.AutoSize = true;
            this.lblBan.BackColor = System.Drawing.Color.Transparent;
            this.lblBan.Location = new System.Drawing.Point(133, 43);
            this.lblBan.Name = "lblBan";
            this.lblBan.Size = new System.Drawing.Size(95, 25);
            this.lblBan.TabIndex = 4;
            this.lblBan.Text = "Chọn bàn";
            // 
            // frmMoBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BuffetManager.Properties.Resources.nen_kem;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.lblHinhThuc);
            this.Controls.Add(this.lblBan);
            this.Controls.Add(this.lblDatBan);
            this.Controls.Add(this.pnlBuffet);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnMoBan);
            this.Controls.Add(this.chkCoDatTruoc);
            this.Controls.Add(this.cboDatBan);
            this.Controls.Add(this.cboHinhThuc);
            this.Controls.Add(this.cboBan);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMoBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mở bàn";
            this.Load += new System.EventHandler(this.frmMoBan_Load);
            this.pnlBuffet.ResumeLayout(false);
            this.pnlBuffet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTren1m3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTu1mDen1m3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuoi1m)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cboBan;
        private Guna.UI2.WinForms.Guna2ComboBox cboHinhThuc;
        private Guna.UI2.WinForms.Guna2CheckBox chkCoDatTruoc;
        private Guna.UI2.WinForms.Guna2Button btnMoBan;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Guna.UI2.WinForms.Guna2ComboBox cboDatBan;
        private Guna.UI2.WinForms.Guna2Panel pnlBuffet;
        private System.Windows.Forms.Label lblTienVe;
        private System.Windows.Forms.Label lblTongKhach;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudTren1m3;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudTu1mDen1m3;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudDuoi1m;
        private Guna.UI2.WinForms.Guna2ComboBox cboGoiBuffet;
        private System.Windows.Forms.Label lblDatBan;
        private System.Windows.Forms.Label lblHinhThuc;
        private System.Windows.Forms.Label lblBan;
        private System.Windows.Forms.Label lblGoiBuffet;
        private System.Windows.Forms.Label lblTren1m3;
        private System.Windows.Forms.Label lblTu1mDen1m3;
        private System.Windows.Forms.Label lblDuoi1m;
    }
}