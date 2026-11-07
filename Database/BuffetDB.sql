-- ============================================================================
-- BUFFETDB.SQL - CAI DAT MOI DATABASE CHO DO AN BUFFETMANAGER
-- Ban goc: BuffetDB(1).sql do nguoi dung cung cap.
-- Da giu nguyen 28 bang, cac rang buoc va phan quyen trong file goc.
-- Bo sung: NGUOIDUNG.MaTaiKhoan, BODEM_MATAIKHOAN,
--           unique index ma tai khoan, 3 nhom chieu cao.
-- Tong cong: 28 bang nghiep vu + 1 bang bo dem ky thuat.
--
-- CHI DUNG DE CAI DAT DATABASE MOI/CHUA CO CAC BANG CUA DO AN.
-- KHONG CHAY TREN BUFFETDB DANG CO DU LIEU: CREATE TABLE se bao loi.
-- Day la mot file SQL duy nhat de cai dat moi, da bao gom tat ca bo sung.
-- Khong chua mat khau dang nhap hay du lieu nghiep vu ca nhan.
-- ============================================================================

-- Bước 1: Chọn database hệ thống
USE master;
GO

-- Bước 2: Kiểm tra và tạo database BuffetDB
IF DB_ID('BuffetDB') IS NULL
BEGIN
    CREATE DATABASE BuffetDB;
END;
GO

-- Bước 3: Chọn database BuffetDB
USE BuffetDB;
GO

-- Tạo bảng vai trò: Admin, Phục vụ, Bếp, Pha chế
CREATE TABLE VAITRO
(
    MaVaiTro VARCHAR(10) PRIMARY KEY,
    TenVaiTro NVARCHAR(50) NOT NULL UNIQUE,

    CONSTRAINT CK_VAITRO_MaVaiTro
        CHECK (MaVaiTro IN ('ADMIN', 'PHUCVU', 'BEP', 'PHACHE'))
);
GO

-- Thêm 4 vai trò, bỏ qua những vai trò đã tồn tại
INSERT INTO VAITRO (MaVaiTro, TenVaiTro)
SELECT v.MaVaiTro, v.TenVaiTro
FROM
(
    VALUES
        ('ADMIN', N'Admin'),
        ('PHUCVU', N'Phục vụ'),
        ('BEP', N'Bếp'),
        ('PHACHE', N'Pha chế')
) AS v(MaVaiTro, TenVaiTro)
WHERE NOT EXISTS
(
    SELECT 1
    FROM VAITRO AS r
    WHERE r.MaVaiTro = v.MaVaiTro
);
GO

-- Bo dem ID theo vai tro: NguoiDungRepository.TaoMaTaiKhoan() truy van truc tiep.
-- Bang nay khong co trong file .dbml nhung can thiet de tao Admin/tai khoan.
CREATE TABLE BODEM_MATAIKHOAN
(
    MaVaiTro VARCHAR(10) NOT NULL PRIMARY KEY,
    SoCuoi INT NOT NULL CONSTRAINT DF_BODEM_MATAIKHOAN_SoCuoi DEFAULT (0),
    CONSTRAINT CK_BODEM_MATAIKHOAN_SoCuoi CHECK (SoCuoi >= 0),
    CONSTRAINT FK_BODEM_MATAIKHOAN_VAITRO
        FOREIGN KEY (MaVaiTro) REFERENCES VAITRO(MaVaiTro)
);
GO

INSERT INTO BODEM_MATAIKHOAN (MaVaiTro, SoCuoi)
SELECT v.MaVaiTro, 0
FROM VAITRO AS v
WHERE v.MaVaiTro IN ('ADMIN', 'PHUCVU', 'BEP', 'PHACHE')
  AND NOT EXISTS
  (
      SELECT 1 FROM BODEM_MATAIKHOAN AS bd
      WHERE bd.MaVaiTro = v.MaVaiTro
  );
GO

-- Tạo bảng nhân viên
CREATE TABLE NHANVIEN
(
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15),
    DangLam BIT NOT NULL DEFAULT 1
);
GO

-- Tạo bảng người dùng: tài khoản đăng nhập của nhân viên
CREATE TABLE NGUOIDUNG
(
    MaND INT IDENTITY(1,1) PRIMARY KEY,
    -- Ma hien thi: AD1, PV1, PC1, BE1... duoc code C# tu sinh.
    MaTaiKhoan VARCHAR(20) NULL,
    MaNV INT NOT NULL UNIQUE,
    MaVaiTro VARCHAR(10) NOT NULL,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhauHash BINARY(32) NOT NULL,
    Salt BINARY(32) NOT NULL,
    HoatDong BIT NOT NULL DEFAULT 1,
    BatBuocDoiMatKhau BIT NOT NULL DEFAULT 1,

    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    FOREIGN KEY (MaVaiTro) REFERENCES VAITRO(MaVaiTro)
);
GO

-- Chi cap ma tai khoan cho cac tai khoan co ma, cho phep NULL neu chua gan.
CREATE UNIQUE INDEX UX_NGUOIDUNG_MaTaiKhoan
ON NGUOIDUNG(MaTaiKhoan)
WHERE MaTaiKhoan IS NOT NULL;
GO

-- Tạo bảng chức năng dùng để phân quyền
CREATE TABLE CHUCNANG
(
    MaChucNang INT IDENTITY(1,1) PRIMARY KEY,
    MaCode VARCHAR(50) NOT NULL UNIQUE,
    TenChucNang NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);
GO

-- Thêm các chức năng chưa tồn tại
INSERT INTO CHUCNANG (MaCode, TenChucNang)
SELECT v.MaCode, v.TenChucNang
FROM
(
    VALUES
        ('QUANLY_TAIKHOAN', N'Quản lý tài khoản'),
        ('QUANLY_PHANQUYEN', N'Quản lý phân quyền'),
        ('QUANLY_DANHMUC', N'Quản lý danh mục'),
        ('QUANLY_KHO', N'Quản lý kho'),

        ('DAT_BAN', N'Đặt bàn'),
        ('MO_BAN', N'Mở bàn'),
        ('GOI_MON', N'Gọi món'),
        ('CHUYEN_GOP_BAN', N'Chuyển và gộp bàn'),
        ('LAP_HOADON', N'Lập hóa đơn'),
        ('THANH_TOAN', N'Thanh toán'),

        ('XULY_MON_BEP', N'Xem và xử lý phiếu món bếp'),
        ('XULY_DO_UONG', N'Xem và xử lý phiếu đồ uống'),
        ('XEM_KHO_BEP', N'Xem kho nguyên liệu bếp'),
        ('XEM_KHO_PHACHE', N'Xem kho nguyên liệu pha chế'),

        ('XEM_BAOCAO', N'Xem báo cáo và thống kê')
) AS v(MaCode, TenChucNang)

-- Tránh thêm trùng mã chức năng khi chạy lại
WHERE NOT EXISTS
(
    SELECT 1
    FROM CHUCNANG AS cn
    WHERE cn.MaCode = v.MaCode
);
GO

-- Tạo bảng phân quyền: mỗi dòng cấp một chức năng cho một vai trò
CREATE TABLE PHANQUYEN
(
    MaVaiTro VARCHAR(10) NOT NULL,
    MaChucNang INT NOT NULL,

    PRIMARY KEY (MaVaiTro, MaChucNang),

    FOREIGN KEY (MaVaiTro) REFERENCES VAITRO(MaVaiTro),
    FOREIGN KEY (MaChucNang) REFERENCES CHUCNANG(MaChucNang)
);
GO

-- Gán chức năng phù hợp cho từng vai trò
INSERT INTO PHANQUYEN (MaVaiTro, MaChucNang)
SELECT vt.MaVaiTro, cn.MaChucNang
FROM VAITRO AS vt
CROSS JOIN CHUCNANG AS cn
WHERE
(
    -- Admin được dùng tất cả chức năng
    vt.MaVaiTro = 'ADMIN'

    -- Phục vụ được thao tác nghiệp vụ tại bàn
    OR
    (
        vt.MaVaiTro = 'PHUCVU'
        AND cn.MaCode IN
        (
            'DAT_BAN',
            'MO_BAN',
            'GOI_MON',
            'CHUYEN_GOP_BAN',
            'LAP_HOADON',
            'THANH_TOAN'
        )
    )

    -- Bếp xử lý món bếp và xem kho bếp
    OR
    (
        vt.MaVaiTro = 'BEP'
        AND cn.MaCode IN
        (
            'XULY_MON_BEP',
            'XEM_KHO_BEP'
        )
    )

    -- Pha chế xử lý đồ uống và xem kho pha chế
    OR
    (
        vt.MaVaiTro = 'PHACHE'
        AND cn.MaCode IN
        (
            'XULY_DO_UONG',
            'XEM_KHO_PHACHE'
        )
    )
)
-- Không thêm lại quyền đã tồn tại
AND NOT EXISTS
(
    SELECT 1
    FROM PHANQUYEN AS pq
    WHERE pq.MaVaiTro = vt.MaVaiTro
      AND pq.MaChucNang = cn.MaChucNang
);
GO

-- Tạo bảng khu vực của nhà hàng
CREATE TABLE KHUVUC
(
    MaKV INT IDENTITY(1,1) PRIMARY KEY,
    TenKV NVARCHAR(60) NOT NULL UNIQUE
);
GO

-- Tạo bảng bàn ăn
CREATE TABLE BAN
(
    MaBan INT IDENTITY(1,1) PRIMARY KEY,
    MaKV INT NOT NULL,
    TenBan NVARCHAR(30) NOT NULL UNIQUE,
    SoCho INT NOT NULL CHECK (SoCho > 0),
    HoatDong BIT NOT NULL DEFAULT 1,

    FOREIGN KEY (MaKV) REFERENCES KHUVUC(MaKV)
);
GO

-- Tạo bảng đặt bàn: chỉ lưu họ tên và SĐT của người đặt
CREATE TABLE DATBAN
(
    MaDatBan INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT NOT NULL,
    MaND INT NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) NOT NULL,
    GioDen DATETIME2 NOT NULL,
    SoKhach INT NOT NULL CHECK (SoKhach > 0),
    TrangThai VARCHAR(15) NOT NULL DEFAULT 'CHO',

    FOREIGN KEY (MaBan) REFERENCES BAN(MaBan),
    FOREIGN KEY (MaND) REFERENCES NGUOIDUNG(MaND),

    CHECK (TrangThai IN ('CHO', 'DA_DEN', 'HUY'))
);
GO
-- Tạo bảng danh mục món và bộ phận chịu trách nhiệm
CREATE TABLE DANHMUCMON
(
    MaDM INT IDENTITY(1,1) PRIMARY KEY,
    TenDM NVARCHAR(60) NOT NULL UNIQUE,
    BoPhan VARCHAR(10) NOT NULL,

    CHECK (BoPhan IN ('BEP', 'PHACHE'))
);
GO

-- Tạo bảng món ăn và đồ uống
CREATE TABLE MONAN
(
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    MaDM INT NOT NULL,
    TenMon NVARCHAR(100) NOT NULL,
    DonVi NVARCHAR(20) NOT NULL,
    GiaLe DECIMAL(18,2) NOT NULL CHECK (GiaLe >= 0),
    DangBan BIT NOT NULL DEFAULT 1,

    FOREIGN KEY (MaDM) REFERENCES DANHMUCMON(MaDM)
);
GO

-- Tạo bảng gói buffet: không giới hạn thời gian dùng bữa
CREATE TABLE GOIBUFFET
(
    MaGoi INT IDENTITY(1,1) PRIMARY KEY,
    TenGoi NVARCHAR(100) NOT NULL,
    GiaNguoiLon DECIMAL(18,2) NOT NULL,
    DonGiaPhatMoiKg DECIMAL(18,2) NOT NULL DEFAULT 0,
    DangBan BIT NOT NULL DEFAULT 1,

    CHECK (GiaNguoiLon >= 0),
    CHECK (DonGiaPhatMoiKg >= 0)
);
GO

-- Tạo bảng xác định các món được gọi trong từng gói buffet
CREATE TABLE GOIBUFFET_MON
(
    MaGoi INT NOT NULL,
    MaMon INT NOT NULL,

    PRIMARY KEY (MaGoi, MaMon),

    FOREIGN KEY (MaGoi) REFERENCES GOIBUFFET(MaGoi),
    FOREIGN KEY (MaMon) REFERENCES MONAN(MaMon)
);
GO

-- Tạo bảng combo với giá bán cố định
CREATE TABLE COMBO
(
    MaCombo INT IDENTITY(1,1) PRIMARY KEY,
    TenCombo NVARCHAR(100) NOT NULL,
    SoNguoiGoiY INT NOT NULL CHECK (SoNguoiGoiY > 0),
    GiaCombo DECIMAL(18,2) NOT NULL CHECK (GiaCombo >= 0),
    DangBan BIT NOT NULL DEFAULT 1
);
GO

-- Tạo bảng thành phần combo và số lượng từng món
CREATE TABLE COMBO_MON
(
    MaCombo INT NOT NULL,
    MaMon INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),

    PRIMARY KEY (MaCombo, MaMon),

    FOREIGN KEY (MaCombo) REFERENCES COMBO(MaCombo),
    FOREIGN KEY (MaMon) REFERENCES MONAN(MaMon)
);
GO

-- Tạo bảng nhóm chiều cao để tính tiền vé buffet
CREATE TABLE NHOMCHIEUCAO
(
    MaNhom INT PRIMARY KEY,
    TenNhom NVARCHAR(60) NOT NULL,
    TuCm INT NOT NULL,
    DenCm INT NULL,
    TyLeThu DECIMAL(3,2) NOT NULL,

    CONSTRAINT CK_NHOMCHIEUCAO_QuyTac CHECK
    (
        (MaNhom = 1 AND TuCm = 0
         AND DenCm IS NOT NULL AND DenCm = 100
         AND TyLeThu = 0)

        OR

        (MaNhom = 2 AND TuCm = 100
         AND DenCm IS NOT NULL AND DenCm = 130
         AND TyLeThu = 0.5)

        OR

        (MaNhom = 3 AND TuCm = 130
         AND DenCm IS NULL AND TyLeThu = 1)
    )
);
GO

-- Cau hinh chieu cao cho ve buffet (phu hop MoBanRepository).
INSERT INTO NHOMCHIEUCAO (MaNhom, TenNhom, TuCm, DenCm, TyLeThu)
VALUES
    (1, N'Dưới 1 m', 0, 100, 0.00),
    (2, N'Từ 1 m đến dưới 1,3 m', 100, 130, 0.50),
    (3, N'Từ 1,3 m', 130, NULL, 1.00);
GO

-- Tạo bảng nguyên liệu và số lượng tồn kho
CREATE TABLE NGUYENLIEU
(
    MaNL INT IDENTITY(1,1) PRIMARY KEY,
    TenNL NVARCHAR(100) NOT NULL,
    DonVi NVARCHAR(20) NOT NULL,
    BoPhan VARCHAR(10) NOT NULL,
    TonKho DECIMAL(18,3) NOT NULL DEFAULT 0,
    MucCanhBao DECIMAL(18,3) NOT NULL DEFAULT 0,
    PhienBan ROWVERSION,

    CHECK (BoPhan IN ('BEP', 'PHACHE')),
    CHECK (TonKho >= 0),
    CHECK (MucCanhBao >= 0)
);
GO

-- Tạo bảng định lượng nguyên liệu cho một đơn vị món
CREATE TABLE DINHLUONG
(
    MaMon INT NOT NULL,
    MaNL INT NOT NULL,
    LuongCan DECIMAL(18,3) NOT NULL CHECK (LuongCan > 0),

    PRIMARY KEY (MaMon, MaNL),

    FOREIGN KEY (MaMon) REFERENCES MONAN(MaMon),
    FOREIGN KEY (MaNL) REFERENCES NGUYENLIEU(MaNL)
);
GO

-- Tạo bảng phiếu nhập nguyên liệu
CREATE TABLE PHIEUNHAP
(
    MaPN INT IDENTITY(1,1) PRIMARY KEY,
    MaND INT NOT NULL,
    NgayNhap DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    TenNhaCungCap NVARCHAR(150),
    GhiChu NVARCHAR(255),

    FOREIGN KEY (MaND) REFERENCES NGUOIDUNG(MaND)
);
GO

-- Tạo bảng chi tiết nguyên liệu trong từng phiếu nhập
CREATE TABLE CHITIETPHIEUNHAP
(
    MaPN INT NOT NULL,
    MaNL INT NOT NULL,
    SoLuong DECIMAL(18,3) NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),

    PRIMARY KEY (MaPN, MaNL),

    FOREIGN KEY (MaPN) REFERENCES PHIEUNHAP(MaPN),
    FOREIGN KEY (MaNL) REFERENCES NGUYENLIEU(MaNL)
);
GO

-- Tạo bảng lượt phục vụ: một lần khách đến ăn tại nhà hàng
CREATE TABLE LUOTPHUCVU
(
    MaLuot INT IDENTITY(1,1) PRIMARY KEY,
    MaND INT NOT NULL,
    MaDatBan INT NULL,
    HinhThuc VARCHAR(10) NOT NULL,
    MaGoi INT NULL,
    GioMo DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    GioDong DATETIME2 NULL,
    GiaPhatMoiKg DECIMAL(18,2) NULL,
    TrangThai VARCHAR(15) NOT NULL DEFAULT 'DANG_PHUC_VU',
    GopVaoMaLuot INT NULL,
    PhienBan ROWVERSION,

    FOREIGN KEY (MaND) REFERENCES NGUOIDUNG(MaND),
    FOREIGN KEY (MaDatBan) REFERENCES DATBAN(MaDatBan),
    FOREIGN KEY (MaGoi) REFERENCES GOIBUFFET(MaGoi),
    FOREIGN KEY (GopVaoMaLuot) REFERENCES LUOTPHUCVU(MaLuot),

    CHECK (HinhThuc IN ('BUFFET', 'COMBO', 'GOIMON')),

    CHECK
    (
        TrangThai IN
        ('DANG_PHUC_VU', 'DA_THANH_TOAN', 'DA_GOP', 'HUY')
    ),

    CHECK (GioDong IS NULL OR GioDong >= GioMo),

    -- Chỉ buffet có gói buffet và đơn giá phạt đồ thừa
    CONSTRAINT CK_LUOTPHUCVU_HinhThuc CHECK
    (
        (HinhThuc = 'BUFFET'
         AND MaGoi IS NOT NULL
         AND GiaPhatMoiKg IS NOT NULL
         AND GiaPhatMoiKg >= 0)

        OR

        (HinhThuc <> 'BUFFET'
         AND MaGoi IS NULL
         AND GiaPhatMoiKg IS NULL)
    ),

    -- Lượt đang phục vụ chưa có giờ đóng
    CONSTRAINT CK_LUOTPHUCVU_GioDong CHECK
    (
        (TrangThai = 'DANG_PHUC_VU' AND GioDong IS NULL)
        OR
        (TrangThai <> 'DANG_PHUC_VU' AND GioDong IS NOT NULL)
    ),

    -- Lượt đã gộp phải trỏ đến một lượt khác
    CONSTRAINT CK_LUOTPHUCVU_GopBan CHECK
    (
        (TrangThai = 'DA_GOP'
         AND GopVaoMaLuot IS NOT NULL
         AND GopVaoMaLuot <> MaLuot)

        OR

        (TrangThai <> 'DA_GOP' AND GopVaoMaLuot IS NULL)
    )
);
GO

-- Mỗi phiếu đặt bàn chỉ được tiếp nhận thành một lượt phục vụ
CREATE UNIQUE INDEX UX_LUOTPHUCVU_DatBan
ON LUOTPHUCVU(MaDatBan)
WHERE MaDatBan IS NOT NULL;
GO

-- Tạo bảng lịch sử các bàn được sử dụng trong lượt phục vụ
CREATE TABLE LUOTBAN
(
    MaLuotBan INT IDENTITY(1,1) PRIMARY KEY,
    MaLuot INT NOT NULL,
    MaBan INT NOT NULL,
    TuLuc DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    DenLuc DATETIME2 NULL,

    FOREIGN KEY (MaLuot) REFERENCES LUOTPHUCVU(MaLuot),
    FOREIGN KEY (MaBan) REFERENCES BAN(MaBan),

    CHECK (DenLuc IS NULL OR DenLuc >= TuLuc)
);
GO

-- Một bàn chỉ được có một bản ghi sử dụng chưa kết thúc
CREATE UNIQUE INDEX UX_LUOTBAN_DangSuDung
ON LUOTBAN(MaBan)
WHERE DenLuc IS NULL;
GO

-- Tạo bảng vé buffet theo nhóm chiều cao trong từng lượt phục vụ
CREATE TABLE VEBUFFET
(
    MaVe INT IDENTITY(1,1) PRIMARY KEY,
    MaLuot INT NOT NULL,
    MaNhom INT NOT NULL,
    SoKhach INT NOT NULL CHECK (SoKhach > 0),
    GiaNguoiLon DECIMAL(18,2) NOT NULL,
    TyLeThu DECIMAL(3,2) NOT NULL,

    -- Giá vé thực tế được tính từ giá người lớn và tỷ lệ thu
    DonGia AS
        CONVERT(DECIMAL(18,2), GiaNguoiLon * TyLeThu) PERSISTED,

    FOREIGN KEY (MaLuot) REFERENCES LUOTPHUCVU(MaLuot),
    FOREIGN KEY (MaNhom) REFERENCES NHOMCHIEUCAO(MaNhom),

    UNIQUE (MaLuot, MaNhom),

    CHECK (GiaNguoiLon >= 0),

    CHECK
    (
        (MaNhom = 1 AND TyLeThu = 0)
        OR (MaNhom = 2 AND TyLeThu = 0.5)
        OR (MaNhom = 3 AND TyLeThu = 1)
    )
);
GO

-- Tạo bảng combo khách đã chọn trong lượt phục vụ
CREATE TABLE LUACHONCOMBO
(
    MaChonCombo INT IDENTITY(1,1) PRIMARY KEY,
    MaLuot INT NOT NULL,
    MaCombo INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),

    FOREIGN KEY (MaLuot) REFERENCES LUOTPHUCVU(MaLuot),
    FOREIGN KEY (MaCombo) REFERENCES COMBO(MaCombo),

    -- Dùng cho khóa ngoại ghép ở bảng chi tiết gọi món
    UNIQUE (MaChonCombo, MaLuot)
);
GO

-- Tạo bảng phiếu gọi món: mỗi phiếu là một đợt gọi
CREATE TABLE PHIEUGOIMON
(
    MaPG INT IDENTITY(1,1) PRIMARY KEY,
    MaLuot INT NOT NULL,
    MaND INT NOT NULL,
    GioGoi DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    GhiChu NVARCHAR(255),

    FOREIGN KEY (MaLuot) REFERENCES LUOTPHUCVU(MaLuot),
    FOREIGN KEY (MaND) REFERENCES NGUOIDUNG(MaND),

    UNIQUE (MaPG, MaLuot)
);
GO

-- Tạo bảng chi tiết món trong từng đợt gọi
CREATE TABLE CHITIETGOIMON
(
    MaCTG INT IDENTITY(1,1) PRIMARY KEY,
    MaPG INT NOT NULL,
    MaLuot INT NOT NULL,
    MaMon INT NOT NULL,
    MaChonCombo INT NULL,
    Nguon VARCHAR(15) NOT NULL,
    BoPhan VARCHAR(10) NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    TrangThai VARCHAR(15) NOT NULL DEFAULT 'CHO',
    PhienBan ROWVERSION,

    FOREIGN KEY (MaMon) REFERENCES MONAN(MaMon),

    -- Đảm bảo phiếu gọi thuộc đúng lượt phục vụ
    FOREIGN KEY (MaPG, MaLuot)
        REFERENCES PHIEUGOIMON(MaPG, MaLuot),

    -- Đảm bảo combo được chọn thuộc cùng lượt phục vụ
    FOREIGN KEY (MaChonCombo, MaLuot)
        REFERENCES LUACHONCOMBO(MaChonCombo, MaLuot),

    CHECK (Nguon IN ('BUFFET', 'TRONG_COMBO', 'GOI_THEM', 'GOIMON')),

    CHECK (BoPhan IN ('BEP', 'PHACHE')),

    CHECK
    (
        TrangThai IN
        ('CHO', 'DANG_LAM', 'DA_XONG', 'DA_PHUC_VU', 'HUY')
    ),

    -- Chỉ món thuộc combo mới có mã lựa chọn combo
    CONSTRAINT CK_CHITIETGOIMON_Nguon CHECK
    (
        (Nguon = 'TRONG_COMBO' AND MaChonCombo IS NOT NULL)
        OR
        (Nguon <> 'TRONG_COMBO' AND MaChonCombo IS NULL)
    ),

    -- Món buffet và món trong combo không tính tiền riêng
    CONSTRAINT CK_CHITIETGOIMON_DonGia CHECK
    (
        Nguon NOT IN ('BUFFET', 'TRONG_COMBO')
        OR DonGia = 0
    )
);
GO

-- Tạo bảng hóa đơn đã thanh toán
CREATE TABLE HOADON
(
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaLuot INT NOT NULL UNIQUE,
    MaND INT NOT NULL,
    NgayLap DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    HinhThuc VARCHAR(10) NOT NULL,
    TenBanSnapshot NVARCHAR(255) NOT NULL,
    PhuongThuc VARCHAR(15) NOT NULL,
    TongTien DECIMAL(18,2) NOT NULL CHECK (TongTien >= 0),
    TienKhachDua DECIMAL(18,2) NOT NULL,

    -- Tiền thừa được SQL Server tự tính
    TienThua AS (TienKhachDua - TongTien) PERSISTED,

    FOREIGN KEY (MaLuot) REFERENCES LUOTPHUCVU(MaLuot),
    FOREIGN KEY (MaND) REFERENCES NGUOIDUNG(MaND),

    CHECK (HinhThuc IN ('BUFFET', 'COMBO', 'GOIMON')),
    CHECK (PhuongThuc IN ('TIENMAT', 'CHUYENKHOAN')),
    CHECK (TienKhachDua >= TongTien),

    -- Chuyển khoản phải đúng số tiền thanh toán
    CHECK
    (
        PhuongThuc = 'TIENMAT'
        OR TienKhachDua = TongTien
    )
);
GO

-- Tạo bảng các dòng tính tiền trên hóa đơn
CREATE TABLE CHITIETHOADON
(
    MaCTHD INT IDENTITY(1,1) PRIMARY KEY,
    MaHD INT NOT NULL,
    LoaiDong VARCHAR(15) NOT NULL,
    MaVe INT NULL,
    MaChonCombo INT NULL,
    MaCTG INT NULL,
    TenDong NVARCHAR(150) NOT NULL,
    DonVi NVARCHAR(20) NOT NULL,
    SoLuong DECIMAL(18,3) NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),

    -- Thành tiền được tự tính và làm tròn đến 2 chữ số thập phân
    ThanhTien AS
        CONVERT(DECIMAL(18,2), ROUND(SoLuong * DonGia, 2)) PERSISTED,

    FOREIGN KEY (MaHD) REFERENCES HOADON(MaHD),
    FOREIGN KEY (MaVe) REFERENCES VEBUFFET(MaVe),
    FOREIGN KEY (MaChonCombo) REFERENCES LUACHONCOMBO(MaChonCombo),
    FOREIGN KEY (MaCTG) REFERENCES CHITIETGOIMON(MaCTG),

    CHECK (LoaiDong IN ('VE', 'COMBO', 'MON', 'PHAT_THUA')),

    -- Mỗi loại dòng chỉ tham chiếu đến đúng nguồn tương ứng
    CONSTRAINT CK_CHITIETHOADON_Nguon CHECK
    (
        (LoaiDong = 'VE'
         AND MaVe IS NOT NULL
         AND MaChonCombo IS NULL AND MaCTG IS NULL)

        OR

        (LoaiDong = 'COMBO'
         AND MaVe IS NULL
         AND MaChonCombo IS NOT NULL AND MaCTG IS NULL)

        OR

        (LoaiDong = 'MON'
         AND MaVe IS NULL AND MaChonCombo IS NULL
         AND MaCTG IS NOT NULL)

        OR

        (LoaiDong = 'PHAT_THUA'
         AND MaVe IS NULL AND MaChonCombo IS NULL
         AND MaCTG IS NULL)
    )
);
GO

-- Ngăn cùng một nhóm vé bị đưa vào hóa đơn nhiều lần
CREATE UNIQUE INDEX UX_CHITIETHOADON_Ve
ON CHITIETHOADON(MaVe)
WHERE MaVe IS NOT NULL;
GO

-- Ngăn cùng một lựa chọn combo bị tính tiền nhiều lần
CREATE UNIQUE INDEX UX_CHITIETHOADON_Combo
ON CHITIETHOADON(MaChonCombo)
WHERE MaChonCombo IS NOT NULL;
GO

-- Ngăn cùng một dòng món gọi bị tính tiền nhiều lần
CREATE UNIQUE INDEX UX_CHITIETHOADON_Mon
ON CHITIETHOADON(MaCTG)
WHERE MaCTG IS NOT NULL;
GO

-- Tạo bảng nhật ký nhập, xuất và hoàn nguyên liệu
CREATE TABLE BIENDONGKHO
(
    MaBD INT IDENTITY(1,1) PRIMARY KEY,
    MaNL INT NOT NULL,
    MaND INT NOT NULL,
    MaPN INT NULL,
    MaCTG INT NULL,
    NgayGhi DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Loai VARCHAR(10) NOT NULL,
    SoLuong DECIMAL(18,3) NOT NULL,

    FOREIGN KEY (MaNL) REFERENCES NGUYENLIEU(MaNL),
    FOREIGN KEY (MaND) REFERENCES NGUOIDUNG(MaND),
    FOREIGN KEY (MaCTG) REFERENCES CHITIETGOIMON(MaCTG),

    -- Nguyên liệu nhập phải có trong chi tiết phiếu nhập
    FOREIGN KEY (MaPN, MaNL)
        REFERENCES CHITIETPHIEUNHAP(MaPN, MaNL),

    CHECK (Loai IN ('NHAP', 'XUAT', 'HOAN')),

    -- Nhập/hoàn ghi số dương; xuất ghi số âm
    CONSTRAINT CK_BIENDONGKHO_Nguon CHECK
    (
        (Loai = 'NHAP' AND SoLuong > 0
         AND MaPN IS NOT NULL AND MaCTG IS NULL)

        OR

        (Loai = 'XUAT' AND SoLuong < 0
         AND MaPN IS NULL AND MaCTG IS NOT NULL)

        OR

        (Loai = 'HOAN' AND SoLuong > 0
         AND MaPN IS NULL AND MaCTG IS NOT NULL)
    )
);
GO

-- Mỗi nguyên liệu trong phiếu nhập chỉ được ghi nhận nhập kho một lần
CREATE UNIQUE INDEX UX_BIENDONGKHO_Nhap
ON BIENDONGKHO(MaPN, MaNL)
WHERE Loai = 'NHAP';
GO

-- Mỗi dòng món chỉ xuất một lần cho từng nguyên liệu
CREATE UNIQUE INDEX UX_BIENDONGKHO_Xuat
ON BIENDONGKHO(MaCTG, MaNL)
WHERE Loai = 'XUAT';
GO

-- Mỗi dòng món chỉ hoàn một lần cho từng nguyên liệu
CREATE UNIQUE INDEX UX_BIENDONGKHO_Hoan
ON BIENDONGKHO(MaCTG, MaNL)
WHERE Loai = 'HOAN';
GO
