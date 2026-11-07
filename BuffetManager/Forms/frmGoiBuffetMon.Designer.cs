namespace BuffetManager.Forms
{
    partial class frmGoiBuffetMon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoiBuffetMon));
            this.lblGoiBuffet = new System.Windows.Forms.Label();
            this.cboGoiBuffet = new Guna.UI2.WinForms.Guna2ComboBox();
            this.clbMonAn = new System.Windows.Forms.CheckedListBox();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblGoiBuffet
            // 
            this.lblGoiBuffet.AutoSize = true;
            this.lblGoiBuffet.Location = new System.Drawing.Point(224, 54);
            this.lblGoiBuffet.Name = "lblGoiBuffet";
            this.lblGoiBuffet.Size = new System.Drawing.Size(103, 25);
            this.lblGoiBuffet.TabIndex = 0;
            this.lblGoiBuffet.Text = "Gói buffet";
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
            this.cboGoiBuffet.Location = new System.Drawing.Point(333, 43);
            this.cboGoiBuffet.Name = "cboGoiBuffet";
            this.cboGoiBuffet.Size = new System.Drawing.Size(180, 36);
            this.cboGoiBuffet.TabIndex = 1;
            this.cboGoiBuffet.SelectionChangeCommitted += new System.EventHandler(this.cboGoiBuffet_SelectionChangeCommitted);
            // 
            // clbMonAn
            // 
            this.clbMonAn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbMonAn.CheckOnClick = true;
            this.clbMonAn.Enabled = false;
            this.clbMonAn.FormattingEnabled = true;
            this.clbMonAn.IntegralHeight = false;
            this.clbMonAn.Location = new System.Drawing.Point(100, 100);
            this.clbMonAn.Name = "clbMonAn";
            this.clbMonAn.Size = new System.Drawing.Size(550, 400);
            this.clbMonAn.TabIndex = 2;
            this.clbMonAn.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.clbMonAn_Format);
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 8;
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.Enabled = false;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(140, 520);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(160, 60);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu danh sách món";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
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
            this.btnDong.Location = new System.Drawing.Point(450, 520);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(160, 60);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmGoiBuffetMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 603);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.clbMonAn);
            this.Controls.Add(this.cboGoiBuffet);
            this.Controls.Add(this.lblGoiBuffet);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGoiBuffetMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Món thuộc gói buffet";
            this.Load += new System.EventHandler(this.frmGoiBuffetMon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGoiBuffet;
        private Guna.UI2.WinForms.Guna2ComboBox cboGoiBuffet;
        private System.Windows.Forms.CheckedListBox clbMonAn;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnDong;
    }
}