namespace BuffetManager.Forms
{
    partial class frmChuyenGopBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenGopBan));
            this.lblBanNguon = new System.Windows.Forms.Label();
            this.lblHinhThucNguon = new System.Windows.Forms.Label();
            this.lblThongTinBanDich = new System.Windows.Forms.Label();
            this.cboThaoTac = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboBanDich = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnThucHien = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.lblThaoTac = new System.Windows.Forms.Label();
            this.lblBanDich = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBanNguon
            // 
            this.lblBanNguon.AutoSize = true;
            this.lblBanNguon.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblBanNguon.Location = new System.Drawing.Point(111, 56);
            this.lblBanNguon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanNguon.Name = "lblBanNguon";
            this.lblBanNguon.Size = new System.Drawing.Size(138, 25);
            this.lblBanNguon.TabIndex = 0;
            this.lblBanNguon.Text = "Bàn nguồn: —";
            // 
            // lblHinhThucNguon
            // 
            this.lblHinhThucNguon.AutoSize = true;
            this.lblHinhThucNguon.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHinhThucNguon.Location = new System.Drawing.Point(395, 56);
            this.lblHinhThucNguon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHinhThucNguon.Name = "lblHinhThucNguon";
            this.lblHinhThucNguon.Size = new System.Drawing.Size(131, 25);
            this.lblHinhThucNguon.TabIndex = 0;
            this.lblHinhThucNguon.Text = "Hình thức: —";
            // 
            // lblThongTinBanDich
            // 
            this.lblThongTinBanDich.AutoSize = true;
            this.lblThongTinBanDich.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThongTinBanDich.Location = new System.Drawing.Point(111, 271);
            this.lblThongTinBanDich.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongTinBanDich.Name = "lblThongTinBanDich";
            this.lblThongTinBanDich.Size = new System.Drawing.Size(209, 25);
            this.lblThongTinBanDich.TabIndex = 0;
            this.lblThongTinBanDich.Text = "Thông tin bàn đích: —";
            // 
            // cboThaoTac
            // 
            this.cboThaoTac.BackColor = System.Drawing.Color.Transparent;
            this.cboThaoTac.BorderRadius = 8;
            this.cboThaoTac.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboThaoTac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThaoTac.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboThaoTac.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboThaoTac.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboThaoTac.ForeColor = System.Drawing.Color.Black;
            this.cboThaoTac.ItemHeight = 30;
            this.cboThaoTac.Location = new System.Drawing.Point(116, 172);
            this.cboThaoTac.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboThaoTac.Name = "cboThaoTac";
            this.cboThaoTac.Size = new System.Drawing.Size(250, 36);
            this.cboThaoTac.TabIndex = 1;
            // 
            // cboBanDich
            // 
            this.cboBanDich.BackColor = System.Drawing.Color.Transparent;
            this.cboBanDich.BorderRadius = 8;
            this.cboBanDich.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBanDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanDich.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBanDich.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBanDich.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboBanDich.ForeColor = System.Drawing.Color.Black;
            this.cboBanDich.ItemHeight = 30;
            this.cboBanDich.Location = new System.Drawing.Point(478, 172);
            this.cboBanDich.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboBanDich.Name = "cboBanDich";
            this.cboBanDich.Size = new System.Drawing.Size(180, 36);
            this.cboBanDich.TabIndex = 1;
            // 
            // btnThucHien
            // 
            this.btnThucHien.BorderRadius = 8;
            this.btnThucHien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThucHien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThucHien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThucHien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThucHien.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThucHien.ForeColor = System.Drawing.Color.White;
            this.btnThucHien.Location = new System.Drawing.Point(185, 350);
            this.btnThucHien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(160, 60);
            this.btnThucHien.TabIndex = 2;
            this.btnThucHien.Text = "Thực hiện";
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
            this.btnDong.Location = new System.Drawing.Point(455, 350);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(160, 60);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            // 
            // lblThaoTac
            // 
            this.lblThaoTac.AutoSize = true;
            this.lblThaoTac.Location = new System.Drawing.Point(111, 142);
            this.lblThaoTac.Name = "lblThaoTac";
            this.lblThaoTac.Size = new System.Drawing.Size(89, 25);
            this.lblThaoTac.TabIndex = 3;
            this.lblThaoTac.Text = "Thao tác";
            // 
            // lblBanDich
            // 
            this.lblBanDich.AutoSize = true;
            this.lblBanDich.Location = new System.Drawing.Point(473, 142);
            this.lblBanDich.Name = "lblBanDich";
            this.lblBanDich.Size = new System.Drawing.Size(95, 25);
            this.lblBanDich.TabIndex = 3;
            this.lblBanDich.Text = "Chọn bàn";
            // 
            // frmChuyenGopBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.lblBanDich);
            this.Controls.Add(this.lblThaoTac);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.cboBanDich);
            this.Controls.Add(this.cboThaoTac);
            this.Controls.Add(this.lblThongTinBanDich);
            this.Controls.Add(this.lblHinhThucNguon);
            this.Controls.Add(this.lblBanNguon);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChuyenGopBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển / gộp bàn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBanNguon;
        private System.Windows.Forms.Label lblHinhThucNguon;
        private System.Windows.Forms.Label lblThongTinBanDich;
        private Guna.UI2.WinForms.Guna2ComboBox cboThaoTac;
        private Guna.UI2.WinForms.Guna2ComboBox cboBanDich;
        private Guna.UI2.WinForms.Guna2Button btnThucHien;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private System.Windows.Forms.Label lblThaoTac;
        private System.Windows.Forms.Label lblBanDich;
    }
}