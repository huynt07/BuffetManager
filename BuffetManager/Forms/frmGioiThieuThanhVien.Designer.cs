namespace BuffetManager.Forms
{
    partial class frmGioiThieuThanhVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGioiThieuThanhVien));
            this.lblNhomThucHien = new System.Windows.Forms.Label();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblNhomThucHien
            // 
            this.lblNhomThucHien.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNhomThucHien.Location = new System.Drawing.Point(44, 24);
            this.lblNhomThucHien.Name = "lblNhomThucHien";
            this.lblNhomThucHien.Size = new System.Drawing.Size(580, 49);
            this.lblNhomThucHien.TabIndex = 0;
            this.lblNhomThucHien.Text = "NHÓM THỰC HIỆN: Tứ kỵ sĩ Khải Huyền";
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderRadius = 20;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "THÔNG TIN THÀNH VIÊN:\r\n\r\nNguyễn Thanh Huy - 51.01.104.035\r\nOh Seung Jun - 51.01.1" +
    "04.039\r\nHuỳnh Trần Bảo Luân - 51.01.104.056\r\nChu Lê Anh Tú - 51.01.104.111";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2TextBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(50, 97);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBox1.Multiline = true;
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.ReadOnly = true;
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.ShortcutsEnabled = false;
            this.guna2TextBox1.Size = new System.Drawing.Size(567, 312);
            this.guna2TextBox1.TabIndex = 1;
            this.guna2TextBox1.TabStop = false;
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
            this.btnDong.Location = new System.Drawing.Point(228, 441);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(200, 70);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmGioiThieuThanhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(654, 553);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.lblNhomThucHien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGioiThieuThanhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giới thiệu thành viên";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNhomThucHien;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2Button btnDong;
    }
}