using BuffetManager.Helpers;
using BuffetManager.Models;
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

namespace BuffetManager.Forms
{
    public partial class frmRoleManagement : Form
    {
        public frmRoleManagement()
        {
            InitializeComponent();
        }

        // Tải danh sách vai trò và chức năng
        private void TaiDuLieu()
        {
            var chucNangRepository = new ChucNangRepository();

            // Gán dữ liệu trước, sau đó chỉ định thuộc tính hiển thị
            clbChucNang.DataSource = chucNangRepository.LayDanhSach();
            clbChucNang.DisplayMember = nameof(CHUCNANG.TenChucNang);
            clbChucNang.ValueMember = nameof(CHUCNANG.MaChucNang);

            var vaiTroRepository = new VaiTroRepository();

            cboVaiTro.DisplayMember = "TenVaiTro";
            cboVaiTro.ValueMember = "MaVaiTro";
            cboVaiTro.DataSource = vaiTroRepository.LayDanhSach();

            // Chưa chọn vai trò khi mới mở Form
            cboVaiTro.SelectedIndex = -1;

            // Chỉ cho chỉnh khi đã tải quyền của vai trò
            clbChucNang.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void frmRoleManagement_Load(object sender, EventArgs e)
        {
            try
            {
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu phân quyền: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        // Tải chức năng phù hợp và đánh dấu các quyền đã được cấp
        private void TaiQuyenTheoVaiTro()
        {
            clbChucNang.Enabled = false;
            btnLuu.Enabled = false;

            string maVaiTro = cboVaiTro.SelectedValue as string;

            if (string.IsNullOrEmpty(maVaiTro))
            {
                return;
            }

            var chucNangRepository = new ChucNangRepository();
            var danhSach = chucNangRepository.LayDanhSach();

            // Nạp lại danh sách chức năng
            clbChucNang.DataSource = null;
            clbChucNang.DataSource = danhSach;
            clbChucNang.DisplayMember = nameof(CHUCNANG.TenChucNang);
            clbChucNang.ValueMember = nameof(CHUCNANG.MaChucNang);

            var repository = new PhanQuyenRepository();
            var cacQuyen = repository.LayMaChucNang(maVaiTro);

            // Đánh dấu quyền thực tế đã lưu trong database
            for (int i = 0; i < clbChucNang.Items.Count; i++)
            {
                var chucNang = (CHUCNANG)clbChucNang.Items[i];

                clbChucNang.SetItemChecked(
                    i, cacQuyen.Contains(chucNang.MaCode));
            }

            // Admin chỉ được xem; các vai trò khác có thể chỉnh dấu tích
            clbChucNang.Enabled =
                maVaiTro != "ADMIN" &&
                UserSession.CoQuyen("QUANLY_PHANQUYEN");

            // Chỉ cho lưu khi được phép chỉnh quyền
            btnLuu.Enabled = clbChucNang.Enabled;
        }

        private void cboVaiTro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                // Chạy khi người dùng chọn một vai trò
                TaiQuyenTheoVaiTro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải quyền: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string maVaiTro = cboVaiTro.SelectedValue as string;

                // Lấy mã của các chức năng đang được tích
                var cacMaQuyen = clbChucNang.CheckedItems
                    .Cast<CHUCNANG>()
                    .Select(cn => cn.MaCode)
                    .ToList();

                // Service kiểm tra quyền và lưu xuống database
                var service = new PhanQuyenService();
                service.LuuQuyen(maVaiTro, cacMaQuyen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể lưu quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Lưu quyền thành công!\n" +
                "Người dùng thuộc vai trò này cần đăng nhập lại để nhận quyền mới.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
