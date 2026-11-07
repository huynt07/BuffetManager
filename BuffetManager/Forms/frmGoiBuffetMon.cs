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
    public partial class frmGoiBuffetMon : Form
    {
        public frmGoiBuffetMon()
        {
            InitializeComponent();
        }

        // Tải danh sách món và các gói buffet
        private void TaiDuLieu()
        {
            var monRepository = new MonAnRepository();

            // Giữ đối tượng MonAnDTO để dùng khi tích chọn và lưu
            clbMonAn.DataSource = monRepository.LayDanhSach();
            clbMonAn.DisplayMember = nameof(MonAnDTO.TenMon);
            clbMonAn.ValueMember = nameof(MonAnDTO.MaMon);

            var goiRepository = new GoiBuffetRepository();

            cboGoiBuffet.DisplayMember = "TenGoi";
            cboGoiBuffet.ValueMember = "MaGoi";
            cboGoiBuffet.DataSource = goiRepository.LayDanhSach();

            // Chưa chọn gói thì chưa cho chỉnh danh sách
            cboGoiBuffet.SelectedIndex = -1;
            clbMonAn.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void clbMonAn_Format(object sender, ListControlConvertEventArgs e)
        {
            // Hiển thị thêm danh mục và trạng thái bán
            var mon = e.ListItem as MonAnDTO;

            if (mon != null)
            {
                e.Value = mon.TenMon + " — " + mon.TenDM
                    + (mon.DangBan ? "" : " (Ngừng bán)");
            }
        }

        private void frmGoiBuffetMon_Load(object sender, EventArgs e)
        {
            try
            {
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hiển thị các món đã được liên kết với gói đang chọn
        private void TaiMonTheoGoi()
        {
            clbMonAn.Enabled = false;
            btnLuu.Enabled = false;

            // Xóa dấu tích của gói trước
            for (int i = 0; i < clbMonAn.Items.Count; i++)
            {
                clbMonAn.SetItemChecked(i, false);
            }

            if (cboGoiBuffet.SelectedValue == null)
            {
                return;
            }

            int maGoi = Convert.ToInt32(cboGoiBuffet.SelectedValue);

            var repository = new GoiBuffetMonRepository();
            var cacMaMon = repository.LayMaMonTheoGoi(maGoi);

            // Tích những món đã có trong gói
            for (int i = 0; i < clbMonAn.Items.Count; i++)
            {
                var mon = (MonAnDTO)clbMonAn.Items[i];

                clbMonAn.SetItemChecked(
                    i, cacMaMon.Contains(mon.MaMon));
            }

            clbMonAn.Enabled = UserSession.CoQuyen("QUANLY_DANHMUC");

            // Cho lưu khi người dùng có quyền chỉnh danh sách
            btnLuu.Enabled = clbMonAn.Enabled;
        }

        private void cboGoiBuffet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                TaiMonTheoGoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải món thuộc gói: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Phải chọn gói trước khi lưu
            if (cboGoiBuffet.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn gói buffet.");
                return;
            }

            try
            {
                int maGoi = Convert.ToInt32(cboGoiBuffet.SelectedValue);

                // Lấy mã của các món đang được tích
                var cacMaMon = clbMonAn.CheckedItems
                    .Cast<MonAnDTO>()
                    .Select(mon => mon.MaMon)
                    .ToList();

                // Kiểm tra quyền và lưu danh sách liên kết
                var service = new GoiBuffetMonService();
                service.LuuDanhSachMon(maGoi, cacMaMon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể lưu danh sách món",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Lưu danh sách món thành công!");
        }
    }
}
