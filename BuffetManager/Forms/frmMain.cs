using BuffetManager.Forms;
using BuffetManager.Helpers;
using BuffetManager.Repositories;
using BuffetManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuffetManager
{
    public partial class frmMain : Form
    {
        private readonly ThongKeService thongKeService =
    new ThongKeService();

        public frmMain()
        {
            InitializeComponent();

            // Mặc định chọn tháng và năm hiện tại.
            nudThang.Value = DateTime.Today.Month;
            nudNam.Value = DateTime.Today.Year;

            btnBaoCao.Click += (s, e) => FormHelper.Run(() =>
            {
                NghiepVuHelper.Quyen("XEM_BAOCAO");
                using (var f = new frmLichSuHoaDon())
                    f.ShowDialog(this);
            });
            // Áp dụng quyền sau khi các control đã được tạo
            ApDungPhanQuyen();
        }

        private void btnKiemTraKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi Repository để kiểm tra truy vấn database
                var repository = new KhuVucRepository();
                int soKhuVuc = repository.DemKhuVuc();
                // Hiển thị kết quả
                MessageBox.Show("Kết nối và truy vấn thành công!\nSố khu vực: " + soKhuVuc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi để kiểm tra cấu hình hoặc kết nối
                MessageBox.Show(ex.Message, "Lỗi kết nối / truy vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bật hoặc tắt nút theo quyền của người đang đăng nhập
        private void ApDungPhanQuyen()
        {
            btnTaiKhoan.Enabled = UserSession.CoQuyen("QUANLY_TAIKHOAN");
            btnPhanQuyen.Enabled = UserSession.CoQuyen("QUANLY_PHANQUYEN");
            btnDanhMuc.Enabled = UserSession.CoQuyen("QUANLY_DANHMUC");
            btnKho.Enabled = UserSession.CoQuyen("QUANLY_KHO");
            btnBaoCao.Enabled = UserSession.CoQuyen("XEM_BAOCAO");
            // Cho mở màn hình nghiệp vụ nếu có ít nhất một quyền liên quan
            btnNghiepVu.Enabled = UserSession.CoQuyen("DAT_BAN") || UserSession.CoQuyen("MO_BAN") || UserSession.CoQuyen("GOI_MON") || UserSession.CoQuyen("CHUYEN_GOP_BAN") || UserSession.CoQuyen("LAP_HOADON") || UserSession.CoQuyen("THANH_TOAN") || UserSession.CoQuyen("XULY_MON_BEP") || UserSession.CoQuyen("XULY_DO_UONG") || UserSession.CoQuyen("XEM_KHO_BEP") || UserSession.CoQuyen("XEM_KHO_PHACHE");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Đóng Form; frmLogin sẽ xóa session và hiện lại
            this.Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            // Chỉ người đã đăng nhập mới được đổi mật khẩu
            if (!UserSession.DaDangNhap)
            {
                MessageBox.Show("Vui lòng đăng nhập lại.");
                this.Close();
                return;
            }

            // Mở Form đổi mật khẩu
            using (var form = new frmChangePassword())
            {
                form.ShowDialog(this);
            }
        }

        private void btnNghiepVu_Click(object sender, EventArgs e)
        {
            // Kiểm tra phiên đăng nhập và vai trò trước khi mở
            if (!UserSession.DaDangNhap || UserSession.BatBuocDoiMatKhau || UserSession.MaVaiTro != "ADMIN")
            {
                MessageBox.Show("Bạn không được phép mở chức năng này.");
                return;
            }

            // Mở giao diện nghiệp vụ dành cho Admin
            using (var form = new frmNhanVien(moTuAdmin: true))
            {
                form.ShowDialog(this);
            }
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở Form
            if (!UserSession.CoQuyen("QUANLY_TAIKHOAN"))
            {
                MessageBox.Show("Bạn không có quyền quản lý tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở cửa sổ quản lý tài khoản
            using (var form = new frmUserManagement())
            {
                form.ShowDialog(this);
            }
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở màn hình
            if (!UserSession.CoQuyen("QUANLY_PHANQUYEN"))
            {
                MessageBox.Show("Bạn không có quyền quản lý phân quyền.");
                return;
            }

            using (var form = new frmRoleManagement())
            {
                form.ShowDialog(this);
            }
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                MessageBox.Show("Bạn không có quyền quản lý danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở màn hình quản lý khu vực
            using (var form = new frmKhuVuc())
            {
                // Hiển thị menu bên phải nút Danh mục
                cmsDanhMuc.Show(btnDanhMuc, new System.Drawing.Point(btnDanhMuc.Width, 0));
            }
        }

        private void mnuKhuVuc_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở Form
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                MessageBox.Show("Bạn không có quyền quản lý danh mục.");
                return;
            }

            using (var form = new frmKhuVuc())
            {
                form.ShowDialog(this);
            }
        }

        private void mnuBan_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở Form
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                MessageBox.Show("Bạn không có quyền quản lý danh mục.");
                return;
            }

            using (var form = new frmBan())
            {
                form.ShowDialog(this);
            }
        }

        private void mnuDanhMucMon_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở danh mục món
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                MessageBox.Show("Bạn không có quyền quản lý danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở màn hình quản lý danh mục món
            using (var form = new frmDanhMucMon())
            {
                form.ShowDialog(this);
            }
        }

        private void mnuMonAn_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở màn hình món ăn
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                MessageBox.Show("Bạn không có quyền quản lý danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở cửa sổ quản lý món ăn
            using (var form = new frmMonAn())
            {
                form.ShowDialog(this);
            }
        }

        private void mnuGoiBuffet_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở màn hình gói buffet
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                MessageBox.Show("Bạn không có quyền quản lý danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở cửa sổ quản lý gói buffet
            using (var form = new frmGoiBuffet())
            {
                form.ShowDialog(this);
            }
        }

        private void mnuGoiBuffetMon_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở Form
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                MessageBox.Show("Bạn không có quyền quản lý danh mục.");
                return;
            }

            using (var form = new frmGoiBuffetMon())
            {
                form.ShowDialog(this);
            }
        }

        private void mnuCombo_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở màn hình combo
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                MessageBox.Show("Bạn không có quyền quản lý danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở cửa sổ quản lý combo
            using (var form = new frmCombo())
            {
                form.ShowDialog(this);
            }
        }

        private void mnuComboMon_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở Form
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                MessageBox.Show("Bạn không có quyền quản lý danh mục.");
                return;
            }

            using (var form = new frmComboMon())
            {
                form.ShowDialog(this);
            }
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở màn hình quản lý nguyên liệu
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                MessageBox.Show("Bạn không có quyền quản lý kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị menu bên phải nút Quản lý kho
            cmsKho.Show(btnKho, new System.Drawing.Point(btnKho.Width, 0));
        }

        private void mnuNguyenLieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở nguyên liệu
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                MessageBox.Show("Bạn không có quyền quản lý kho.");
                return;
            }

            // Mở Form quản lý nguyên liệu
            using (var form = new frmNguyenLieu())
            {
                form.ShowDialog(this);
            }
        }

        private void mnuDinhLuong_Click(object sender, EventArgs e)
        {
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                MessageBox.Show("Bạn không có quyền quản lý kho.");
                return;
            }

            using (var form = new frmDinhLuong())
            {
                form.ShowDialog(this);
            }
        }

        private void mnuNhapKho_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền trước khi mở màn hình nhập kho
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                MessageBox.Show("Bạn không có quyền quản lý kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở cửa sổ lập phiếu nhập
            using (var form = new frmNhapKho())
            {
                form.ShowDialog(this);
            }
        }

        private void TaiThongKe()
        {
            int thang = (int)nudThang.Value;
            int nam = (int)nudNam.Value;

            // Lấy dữ liệu qua Service, có kiểm tra quyền.
            var topMon = thongKeService.Top5MonTrongThang(thang, nam);
            var theoNam = thongKeService.DoanhThuTheoNam(nam);
            var theoHinhThuc =
                thongKeService.DoanhThuTheoHinhThuc(thang, nam);

            // Xóa dữ liệu cũ để không bị cộng dồn khi tải lại.
            var cot = chartTopMon.Series["SoLuong"];
            var duong = chartDoanhThu.Series["DoanhThu"];
            var tron = chartHinhThuc.Series["TyLeDoanhThu"];

            cot.Points.Clear();
            duong.Points.Clear();
            tron.Points.Clear();

            // Biểu đồ cột: số lượng theo từng món.
            foreach (var mon in topMon)
            {
                int viTri = cot.Points.AddXY(mon.TenMon, mon.SoLuong);

                cot.Points[viTri].ToolTip =
                    mon.TenMon + ": " + mon.SoLuong.ToString("0.##");
            }

            // Biểu đồ đường: luôn có đủ 12 tháng.
            foreach (var item in theoNam)
            {
                duong.Points.AddXY(item.Thang, item.DoanhThu);
            }

            // Biểu đồ tròn: chỉ thêm phần có doanh thu dương.
            foreach (var item in theoHinhThuc)
            {
                if (item.DoanhThu <= 0)
                    continue;

                string ten = BaoCaoService.TenHinhThuc(item.HinhThuc);

                int viTri = tron.Points.AddXY(ten, item.DoanhThu);

                tron.Points[viTri].ToolTip =
                    ten + ": " + item.DoanhThu.ToString("N0") + " đ";
            }

            // Cập nhật tiêu đề theo bộ lọc.
            chartTopMon.Titles[0].Text =
                $"Top 5 món bán chạy — {thang:00}/{nam}";

            chartDoanhThu.Titles[0].Text =
                $"Doanh thu 12 tháng năm {nam}";

            chartHinhThuc.Titles[0].Text =
                $"Tỷ lệ doanh thu — {thang:00}/{nam}";

            if (topMon.Count == 0)
                chartTopMon.Titles[0].Text += " (Chưa có dữ liệu)";

            if (tron.Points.Count == 0)
                chartHinhThuc.Titles[0].Text += " (Chưa có doanh thu)";
        }

        private void btnTaiThongKe_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo nếu việc tải thống kê gặp lỗi.
            FormHelper.Run(TaiThongKe);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Ẩn dashboard nếu tài khoản không có quyền xem báo cáo.
            bool coQuyen = UserSession.CoQuyen("XEM_BAOCAO");
            pnlDashboard.Visible = coQuyen;

            // Tự tải biểu đồ khi mở form.
            if (coQuyen)
            {
                FormHelper.Run(TaiThongKe);
            }
        }
    }
}
