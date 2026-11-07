using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Services;

namespace BuffetManager.Forms
{
    public partial class frmXemKho : Form
    {
        private string dept;
        public frmXemKho() : this("BEP")
        {
        }

        public frmXemKho(string boPhan)
        {
            InitializeComponent();

            dept = boPhan;

            dgvTonKho.AutoGenerateColumns = false;

            Load += (s, e) =>
            {
                lblBoPhan.Text = dept == "BEP" ? "Kho nguyên liệu bếp" : "Kho nguyên liệu pha chế";
                if (!FormHelper.Run(Reload))
                    Close();
            };
            btnLamMoi.Click += (s, e) => FormHelper.Run(Reload);
            txtTimKiem.TextChanged += (s, e) => FormHelper.Run(Reload);
            chkCanhBao.CheckedChanged += (s, e) => FormHelper.Run(Reload);
            btnDong.Click += (s, e) => Close();
        }

        private void Reload()
        {
            dgvTonKho.DataSource = new TonKhoService().DanhSach(dept, txtTimKiem.Text, chkCanhBao.Checked);
        }

    }
}
