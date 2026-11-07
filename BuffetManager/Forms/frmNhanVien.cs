using BuffetManager.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuffetManager.Forms
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien(bool moTuAdmin = false)
        {
            InitializeComponent();
            // Áp dụng quyền sau khi tạo các control
            ApDungPhanQuyen();
            NoiMenuGiaiDoan4();
            // Admin đóng cửa sổ nghiệp vụ để trở về dashboard
            if (moTuAdmin)
            {
                btnDangXuat.Text = "Đóng";
            }
        }

        // Chỉ hiển thị chức năng được cấp quyền
        private void ApDungPhanQuyen()
        {
            btnDatBan.Visible = UserSession.CoQuyen("DAT_BAN");
            btnMoBan.Visible = UserSession.CoQuyen("MO_BAN");
            btnSoDoBan.Visible = UserSession.CoQuyen("MO_BAN")
    || UserSession.CoQuyen("GOI_MON")
    || UserSession.CoQuyen("CHUYEN_GOP_BAN")
    || UserSession.CoQuyen("LAP_HOADON")
    || UserSession.CoQuyen("THANH_TOAN");
            btnPhieuBep.Visible = UserSession.CoQuyen("XULY_MON_BEP") || UserSession.CoQuyen("GOI_MON");
            btnPhieuPhaChe.Visible = UserSession.CoQuyen("XULY_DO_UONG") || UserSession.CoQuyen("GOI_MON");
            btnKhoBep.Visible = UserSession.CoQuyen("XEM_KHO_BEP");
            btnKhoPhaChe.Visible = UserSession.CoQuyen("XEM_KHO_PHACHE");
            // Admin đổi mật khẩu ở dashboard, không cần nút này ở màn hình nghiệp vụ
            btnDoiMatKhau.Visible = UserSession.MaVaiTro != "ADMIN";
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Đóng Form để trở lại màn hình đăng nhập
            this.Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            // Kiểm tra phiên đăng nhập
            if (!UserSession.DaDangNhap)
            {
                MessageBox.Show("Vui lòng đăng nhập lại.");
                this.Close();
                return;
            }

            // Mở cửa sổ đổi mật khẩu của tài khoản hiện tại
            using (var form = new frmChangePassword())
            {
                form.ShowDialog(this);
            }
        }

        private void btnMoBan_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở Form
            if (!UserSession.CoQuyen("MO_BAN"))
            {
                MessageBox.Show("Bạn không có quyền mở bàn.");
                return;
            }

            using (var form = new frmMoBan())
            {
                form.ShowDialog(this);
            }
        }

        // Gắn menu vào nghiệp vụ thật; các nút có sự kiện Designer vẫn giữ nguyên.
        private void NoiMenuGiaiDoan4()
        {
            btnDatBan.Click += (s, e) => MoForm("DAT_BAN", () => new frmDatBan());
            btnSoDoBan.Click += (s, e) => FormHelper.Run(() =>
            {
                NghiepVuHelper.Quyen("MO_BAN", "GOI_MON", "CHUYEN_GOP_BAN",
                                     "LAP_HOADON", "THANH_TOAN");
                using (var f = new frmSoDoBan())
                    f.ShowDialog(this);
            });
            btnPhieuBep.Click += (s, e) => FormHelper.Run(() =>
            {
                NghiepVuHelper.Quyen("XULY_MON_BEP", "GOI_MON");
                using (var f = new frmXuLyPhieu("BEP"))
                    f.ShowDialog(this);
            });
            btnPhieuPhaChe.Click += (s, e) => FormHelper.Run(() =>
            {
                NghiepVuHelper.Quyen("XULY_DO_UONG", "GOI_MON");
                using (var f = new frmXuLyPhieu("PHACHE"))
                    f.ShowDialog(this);
            });
            btnKhoBep.Click += (s, e) => MoForm("XEM_KHO_BEP", () => new frmXemKho("BEP"));
            btnKhoPhaChe.Click += (s, e) => MoForm("XEM_KHO_PHACHE", () => new frmXemKho("PHACHE"));
        }

        private void MoForm(string quyen, Func<Form> create)
        {
            FormHelper.Run(() =>
            {
                NghiepVuHelper.Quyen(quyen);
                using (var f = create())
                    f.ShowDialog(this);
            });
        }
    }
}
