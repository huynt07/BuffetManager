using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BuffetManager.Repositories
{
    public class NguoiDungRepository
    {
        // Tìm tài khoản theo tên đăng nhập
        public NGUOIDUNG TimTheoTenDangNhap(string tenDangNhap)
        {
            using (var db = DbFactory.Create())
            {
                // Trả về tài khoản tìm được;
                // nếu không có thì trả về null
                return db.GetTable<NGUOIDUNG>()
                         .SingleOrDefault(
                             nd => nd.TenDangNhap == tenDangNhap);
            }
        }

        // Tạo nhân viên và tài khoản Admin đầu tiên
        public void TaoAdminDauTien(
            string hoTen,
            string tenDangNhap,
            byte[] matKhauHash,
            byte[] salt)
        {
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                // Chỉ dùng để khởi tạo khi chưa có tài khoản nào
                if (db.GetTable<NGUOIDUNG>().Any())
                {
                    throw new InvalidOperationException(
                        "Đã có tài khoản. Không thể khởi tạo lại.");
                }

                // Tạo nhân viên quản trị
                var nhanVien = new NHANVIEN
                {
                    HoTen = hoTen,
                    DangLam = true
                };

                db.GetTable<NHANVIEN>().InsertOnSubmit(nhanVien);
                db.SubmitChanges();

                // Sau khi lưu, MaNV nhận giá trị IDENTITY từ SQL Server
                var nguoiDung = new NGUOIDUNG
                {
                    MaNV = nhanVien.MaNV,
                    MaTaiKhoan = TaoMaTaiKhoan(db, "ADMIN"),
                    MaVaiTro = "ADMIN",
                    TenDangNhap = tenDangNhap,
                    MatKhauHash = new Binary(matKhauHash),
                    Salt = new Binary(salt),
                    HoatDong = true,
                    BatBuocDoiMatKhau = true
                };

                db.GetTable<NGUOIDUNG>().InsertOnSubmit(nguoiDung);
                db.SubmitChanges();

                // Xác nhận lưu cả nhân viên và tài khoản
                scope.Complete();
            }
        }

        // Kiểm tra database đã có tài khoản hay chưa
        public bool DaCoTaiKhoan()
        {
            using (var db = DbFactory.Create())
            {
                return db.GetTable<NGUOIDUNG>().Any();
            }
        }

        // Kiểm tra nhân viên có còn làm việc không
        public bool NhanVienConLamViec(int maNV)
        {
            using (var db = DbFactory.Create())
            {
                return db.GetTable<NHANVIEN>()
                         .Any(nv => nv.MaNV == maNV && nv.DangLam);
            }
        }

        // Cập nhật Hash và Salt khi đổi mật khẩu
        public void CapNhatMatKhau(int maND, byte[] hashMoi, byte[] saltMoi)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm đúng tài khoản cần cập nhật
                var nguoiDung = db.GetTable<NGUOIDUNG>()
                                 .SingleOrDefault(nd => nd.MaND == maND);

                if (nguoiDung == null)
                {
                    throw new InvalidOperationException(
                        "Tài khoản không tồn tại.");
                }

                // Không cho đổi mật khẩu của tài khoản đã bị khóa
                if (!nguoiDung.HoatDong)
                {
                    throw new InvalidOperationException(
                        "Tài khoản đã bị khóa.");
                }

                // Lưu Hash và Salt mới, không lưu mật khẩu gốc
                nguoiDung.MatKhauHash = new Binary(hashMoi);
                nguoiDung.Salt = new Binary(saltMoi);

                // Đã đổi mật khẩu thì bỏ yêu cầu đổi lần đầu
                nguoiDung.BatBuocDoiMatKhau = false;

                // Ghi các thay đổi xuống database
                db.SubmitChanges();
            }
        }

        // Lấy thông tin tài khoản, nhân viên và vai trò
        public List<TaiKhoanDTO> LayDanhSach()
        {
            using (var db = DbFactory.Create())
            {
                var query =
                    from nd in db.GetTable<NGUOIDUNG>()
                    join nv in db.GetTable<NHANVIEN>()
                        on nd.MaNV equals nv.MaNV
                    join vt in db.GetTable<VAITRO>()
                        on nd.MaVaiTro equals vt.MaVaiTro
                    orderby nd.MaND
                    select new TaiKhoanDTO
                    {
                        MaND = nd.MaND,
                        MaTaiKhoan = nd.MaTaiKhoan,
                        MaNV = nd.MaNV,
                        HoTen = nv.HoTen,
                        TenDangNhap = nd.TenDangNhap,
                        MaVaiTro = nd.MaVaiTro,
                        TenVaiTro = vt.TenVaiTro,
                        HoatDong = nd.HoatDong
                    };

                // Thực thi truy vấn trước khi đóng DataContext
                return query.ToList();
            }
        }

        // Tạo nhân viên và tài khoản trong cùng một transaction
        public void ThemTaiKhoan(
            string hoTen,
            string tenDangNhap,
            string maVaiTro,
            byte[] hash,
            byte[] salt,
            bool hoatDong)
        {
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                // Không cho phép trùng tên đăng nhập
                if (db.GetTable<NGUOIDUNG>()
                      .Any(nd => nd.TenDangNhap == tenDangNhap))
                {
                    throw new InvalidOperationException(
                        "Tên đăng nhập đã tồn tại.");
                }

                // Vai trò phải có trong database
                if (!db.GetTable<VAITRO>()
                       .Any(vt => vt.MaVaiTro == maVaiTro))
                {
                    throw new InvalidOperationException(
                        "Vai trò không hợp lệ.");
                }

                // Tạo hồ sơ nhân viên
                var nhanVien = new NHANVIEN
                {
                    HoTen = hoTen,
                    DangLam = true
                };

                db.GetTable<NHANVIEN>().InsertOnSubmit(nhanVien);
                db.SubmitChanges();

                // Tạo tài khoản gắn với nhân viên vừa thêm
                var nguoiDung = new NGUOIDUNG
                {
                    MaNV = nhanVien.MaNV,
                    MaTaiKhoan = TaoMaTaiKhoan(db, maVaiTro),
                    MaVaiTro = maVaiTro,
                    TenDangNhap = tenDangNhap,
                    MatKhauHash = new Binary(hash),
                    Salt = new Binary(salt),
                    HoatDong = hoatDong,
                    BatBuocDoiMatKhau = true
                };

                db.GetTable<NGUOIDUNG>().InsertOnSubmit(nguoiDung);
                db.SubmitChanges();

                // Chỉ xác nhận khi cả hai lần lưu đều thành công
                scope.Complete();
            }
        }

        // Cập nhật thông tin tài khoản và nhân viên
        public void CapNhatTaiKhoan(
            int maND,
            string hoTen,
            string maVaiTro,
            bool hoatDong)
        {
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                // Tìm tài khoản cần cập nhật
                var nguoiDung = db.GetTable<NGUOIDUNG>()
                                 .SingleOrDefault(nd => nd.MaND == maND);

                if (nguoiDung == null)
                {
                    throw new InvalidOperationException(
                        "Tài khoản không tồn tại.");
                }

                // Kiểm tra vai trò được chọn
                if (!db.GetTable<VAITRO>()
                       .Any(vt => vt.MaVaiTro == maVaiTro))
                {
                    throw new InvalidOperationException(
                        "Vai trò không hợp lệ.");
                }

                // Tìm nhân viên liên kết với tài khoản
                var nhanVien = db.GetTable<NHANVIEN>()
                                .SingleOrDefault(
                                    nv => nv.MaNV == nguoiDung.MaNV);

                if (nhanVien == null)
                {
                    throw new InvalidOperationException(
                        "Không tìm thấy nhân viên của tài khoản.");
                }

                // Cập nhật các thông tin được phép sửa
                nhanVien.HoTen = hoTen;
                // Nếu đổi vai trò thì cấp mã mới đúng vai trò
                if (nguoiDung.MaVaiTro != maVaiTro)
                {
                    nguoiDung.MaTaiKhoan =
                        TaoMaTaiKhoan(db, maVaiTro);
                }
                nguoiDung.MaVaiTro = maVaiTro;
                nguoiDung.HoatDong = hoatDong;

                // Lưu thay đổi của cả hai bảng trong một lần
                db.SubmitChanges();
                scope.Complete();
            }
        }

        // Xóa tài khoản và hồ sơ nhân viên đi kèm
        public void XoaTaiKhoan(int maND)
        {
            using (var db = DbFactory.Create())
            {
                var nguoiDung = db.GetTable<NGUOIDUNG>()
                                  .SingleOrDefault(nd => nd.MaND == maND);

                if (nguoiDung == null)
                {
                    throw new InvalidOperationException(
                        "Tài khoản không tồn tại hoặc đã bị xóa.");
                }

                // Không xóa tài khoản ADMIN cuối cùng
                if (nguoiDung.MaVaiTro == "ADMIN" &&
                    db.GetTable<NGUOIDUNG>().Count(nd => nd.MaVaiTro == "ADMIN") <= 1)
                {
                    throw new InvalidOperationException(
                        "Không thể xóa tài khoản Admin cuối cùng.");
                }

                // Tài khoản đã phát sinh dữ liệu thì không xóa được
                bool daPhatSinhDuLieu =
                    db.GetTable<HOADON>().Any(x => x.MaND == maND) ||
                    db.GetTable<DATBAN>().Any(x => x.MaND == maND) ||
                    db.GetTable<PHIEUGOIMON>().Any(x => x.MaND == maND) ||
                    db.GetTable<PHIEUNHAP>().Any(x => x.MaND == maND) ||
                    db.GetTable<BIENDONGKHO>().Any(x => x.MaND == maND) ||
                    db.GetTable<LUOTPHUCVU>().Any(x => x.MaND == maND);

                if (daPhatSinhDuLieu)
                {
                    throw new InvalidOperationException(
                        "Tài khoản này đã phát sinh dữ liệu (hóa đơn, đặt bàn, " +
                        "nhập kho...) nên không thể xóa.\n" +
                        "Hãy bỏ tick \"Hoạt động\" rồi bấm Cập nhật để khóa tài khoản.");
                }

                // Xóa tài khoản trước, rồi tới nhân viên
                var nhanVien = db.GetTable<NHANVIEN>()
                                 .SingleOrDefault(nv => nv.MaNV == nguoiDung.MaNV);

                db.GetTable<NGUOIDUNG>().DeleteOnSubmit(nguoiDung);
                if (nhanVien != null)
                {
                    db.GetTable<NHANVIEN>().DeleteOnSubmit(nhanVien);
                }

                db.SubmitChanges();
            }
        }

        private static string TaoMaTaiKhoan(
            BuffetDataContext db, string maVaiTro)
        {
            string tienTo;

            switch (maVaiTro)
            {
                case "ADMIN":
                    tienTo = "AD";
                    break;

                case "PHUCVU":
                    tienTo = "PV";
                    break;

                case "PHACHE":
                    tienTo = "PC";
                    break;

                case "BEP":
                    tienTo = "BE";
                    break;

                default:
                    throw new InvalidOperationException(
                        "Vai trò không hợp lệ.");
            }

            // Tăng bộ đếm tương ứng trong SQL Server.
            // UPDATE đảm bảo hai tài khoản không lấy cùng số.
            int soMoi = db.ExecuteQuery<int>(
                @"UPDATE dbo.BODEM_MATAIKHOAN
          SET SoCuoi = SoCuoi + 1
          OUTPUT INSERTED.SoCuoi
          WHERE MaVaiTro = {0}",
                maVaiTro
            ).Single();

            return tienTo + soMoi.ToString();
        }
    }
}
