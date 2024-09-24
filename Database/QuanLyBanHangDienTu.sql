--drop database QuanLyCuaHangDienTu2
create database QuanLyCuaHangDienTu2
go 
use QuanLyCuaHangDienTu2
go
SET DATEFORMAT dmy; 

CREATE TABLE DanhMuc (
    MaDanhMuc INT PRIMARY KEY IDENTITY(100,1),
    TenDanhMuc NVARCHAR(100) ,
    MoTa NVARCHAR(255)
);

CREATE TABLE NhaCungCap (
    MaNhaCungCap INT PRIMARY KEY IDENTITY(100,1),
    TenNhaCungCap NVARCHAR(100) ,
    NguoiLienHe NVARCHAR(100),
    SoDienThoai VARCHAR(20),
    Email VARCHAR(100),
    DiaChi NVARCHAR(255)
);
CREATE TABLE BaoHanh (
	MaBaoHanh VARCHAR(13) PRIMARY KEY,
	ThoiGianBaoHanh INT,
	GhiChu NVARCHAR(255),
);
CREATE TABLE SanPham (
	MaSanPham VARCHAR(13) PRIMARY KEY,
	MaBaoHanh VARCHAR(13),
    MaVach VARCHAR(13)  UNIQUE,
    TenSanPham NVARCHAR(100) ,
    MaDanhMuc INT,
	MaNhaCungCap INT,
    MoTa NVARCHAR(255),
    GiaBan INT,
    NgaySanXuat Date,
	XuatXu NVARCHAR(50),
	CONSTRAINT FK_SanPham_NhaCungCap FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap) ON DELETE CASCADE,
    CONSTRAINT FK_SanPham_DanhMuc FOREIGN KEY  (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc) ON DELETE CASCADE,
	CONSTRAINT FK_SanPham_BaoHanh FOREIGN KEY (MaBaoHanh) REFERENCES BaoHanh(MaBaoHanh) ON DELETE CASCADE
);

CREATE TABLE KhachHang (
    MaKhachHang VARCHAR(13) PRIMARY KEY,
    TenKhachHang NVARCHAR(50) ,
	NgaySinh DATE,
    SoDienThoai VARCHAR(20) UNIQUE,
	DiemTichLuy INT DEFAULT 0,
	TrangThai NVARCHAR(255),
);

CREATE TABLE NhanVien (
    MaNhanVien VARCHAR(13) PRIMARY KEY,
	HinhAnh image,
    TenNhanVien NVARCHAR(50),
	GioiTinh NVARCHAR(10),
	NgaySinh DATE,
    SoDienThoai VARCHAR(20),
    Email VARCHAR(100),
    ChucVu NVARCHAR(50),
	MucLuong INT,
	TaiKhoan NVARCHAR(50) UNIQUE,
    MatKhau VARCHAR(255) 
);

CREATE TABLE KhuyenMai (
    MaKhuyenMai VARCHAR(13) PRIMARY KEY,
    TenChuongTrinh NVARCHAR(100) ,
    GiaTriKhuyenMai FLOAT ,
	MoTa NVARCHAR(255),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    DieuKienApDung NVARCHAR(255),
	GiaTriDonHangToiThieu INT
);

CREATE TABLE HoaDon (
	MaHoaDon VARCHAR(13) PRIMARY KEY,
	MaNhanVien VARCHAR(13),
	MaKhachHang VARCHAR(13),
	MaKhuyenMai VARCHAR(13) DEFAULT NULL,
	NgayLapHoaDon DATE,
	DiemDaDung INT,
	TongTien INT,
	PhuongThucThanhToan NVARCHAR(50),
	CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien) ON DELETE CASCADE,
	CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang) ON DELETE CASCADE,
	CONSTRAINT FK_HoaDon_KhuyenMai FOREIGN KEY (MaKhuyenMai) REFERENCES KhuyenMai(MaKhuyenMai) ON DELETE CASCADE
);

CREATE TABLE ChiTietHoaDon (
	MaHoaDon VARCHAR(13),
	MaSanPham VARCHAR(13),
	SoLuong INT,
	DonGia INT,
	ThanhTien INT,
	GhiChu NVARCHAR(255),
	PRIMARY KEY (MaHoaDon, MaSanPham),
	CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon) ON DELETE CASCADE,
	CONSTRAINT FK_ChiTietHoaDon_SanPham FOREIGN KEY (MaSanPham) REFERENCES SanPham (MaSanPham) ON DELETE CASCADE
);

CREATE TABLE GiaoHang (
	MaGiaoHang VARCHAR(13) PRIMARY KEY,
	MaHoaDon VARCHAR(13),
	NhanVienGiao VARCHAR(13),
	NgayGiao DATE,
	DiaChi NVARCHAR (255),
	TinhTrang NVARCHAR(255),
	CONSTRAINT FK_GiaoHang_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon) ON DELETE NO ACTION,
    CONSTRAINT FK_GiaoHang_NhanVien FOREIGN KEY (NhanVienGiao) REFERENCES NhanVien(MaNhanVien) ON DELETE NO ACTION
);
--ALTER TABLE GiaoHang
--add TinhTrang nvarchar(255)

CREATE TABLE ChiTietGiaoHang (
    MaGiaoHang VARCHAR(13),
    MaSanPham VARCHAR(13),
    SoLuong INT,
    PRIMARY KEY (MaGiaoHang, MaSanPham),
    CONSTRAINT FK_ChiTietGiaoHang_GiaoHang FOREIGN KEY (MaGiaoHang) REFERENCES GiaoHang(MaGiaoHang) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietGiaoHang_SanPham FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE
);

CREATE TABLE DonDatHangNhaCungCap (
    MaDonDatHang VARCHAR(13) PRIMARY KEY,
    MaNhaCungCap INT,
    NgayDatHang DATETIME,
    TongTien INT,
    TrangThai NVARCHAR(50),
    CONSTRAINT FK_DonDatHangNhaCungCap_NhaCungCap FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap) ON DELETE CASCADE
);

CREATE TABLE ChiTietDonDatHangNhaCungCap (
    MaDonDatHang VARCHAR(13),
    MaSanPham VARCHAR(13),
    SoLuong INT ,
    DonGia INT,
    ThanhTien INT,
	CONSTRAINT PK_ChiTietDonDatHangNCC PRIMARY KEY (MaDonDatHang, MaSanPham),
    CONSTRAINT FK_ChiTietDonDatHangNCC_DonDatHangNCC FOREIGN KEY (MaDonDatHang) REFERENCES DonDatHangNhaCungCap(MaDonDatHang) ON DELETE NO ACTION,
    CONSTRAINT FK_ChiTietDonDatHangNCC_SanPham FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE
);

CREATE TABLE TraHang (
    MaTraHang VARCHAR(13) PRIMARY KEY,
    MaHoaDon VARCHAR(13),
    NgayTra DATE,
	TongTien DECIMAL(10, 3),
    CONSTRAINT FK_TraHang_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon) ON DELETE CASCADE
);

CREATE TABLE ChiTietTraHang (
    MaTraHang VARCHAR(13),
    MaSanPham VARCHAR(13),
    SoLuong INT,
	LyDo NVARCHAR(255),
    PRIMARY KEY (MaTraHang, MaSanPham),
    CONSTRAINT FK_ChiTietTraHang_TraHang FOREIGN KEY (MaTraHang) REFERENCES TraHang(MaTraHang) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietTraHang_SanPham FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE
);

CREATE TABLE YeuCauBaoHanh (
    MaYeuCauBaoHanh VARCHAR(13) PRIMARY KEY,
    MaHoaDon VARCHAR(13),
	MaSanPham VARCHAR(13),
    NgayYeuCau DATE,
	LyDo NVARCHAR(255),
    TrangThai NVARCHAR(50) DEFAULT N'Chờ xử lý',
    CONSTRAINT FK_BaoHanhYeuCau_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon) ON DELETE CASCADE,
	CONSTRAINT FK_ChiTietBaoHanhYeuCau_SanPham FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE
);

SELECT * FROM SanPham, HoaDon WHERE MaHoaDon ='HD00001'

select * from GiaoHang
----------------------------------\

CREATE OR ALTER TRIGGER trg_Check_SanPham_ChiTietGiaoHang
ON ChiTietGiaoHang
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN ChiTietHoaDon c ON i.MaSanPham = c.MaSanPham AND (
            SELECT MaHoaDon
            FROM GiaoHang
            WHERE MaGiaoHang = i.MaGiaoHang
        ) = c.MaHoaDon
        WHERE i.SoLuong > c.SoLuong
    )
    BEGIN
        RAISERROR ('Số lượng giao hàng không được vượt quá số lượng trong hóa đơn.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
   
    IF EXISTS (
        SELECT 1
        FROM inserted i
        LEFT JOIN ChiTietHoaDon c ON i.MaSanPham = c.MaSanPham AND (
            SELECT MaHoaDon
            FROM GiaoHang
            WHERE MaGiaoHang = i.MaGiaoHang
        ) = c.MaHoaDon
        WHERE c.MaSanPham IS NULL
    )
    BEGIN
        RAISERROR ('Sản phẩm phải có trong ChiTietHoaDon.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
select * from ChiTietTraHang, ChiTietHoaDon
select * from TraHang, ChiTietTraHang
drop trigger trg_Check_SanPham_TraHang
CREATE OR ALTER TRIGGER trg_Check_SanPham_TraHang
ON ChiTietTraHang
AFTER INSERT
AS
BEGIN

     IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN TraHang th ON i.MaTraHang = th.MaTraHang
        LEFT JOIN ChiTietHoaDon chd 
        ON th.MaHoaDon = chd.MaHoaDon 
        AND i.MaSanPham = chd.MaSanPham
        WHERE chd.MaSanPham IS NULL
    )
    BEGIN
        RAISERROR ('Sản phẩm phải có trong ChiTietHoaDon.', 16, 1);
        ROLLBACK TRANSACTION;
    END

    IF EXISTS (
        SELECT 1
        FROM ChiTietHoaDon c
        JOIN inserted i ON c.MaSanPham = i.MaSanPham AND c.MaHoaDon = i.MaTraHang
        WHERE i.SoLuong > c.SoLuong
    )
    BEGIN
        RAISERROR ('Số lượng trả hàng không được vượt quá số lượng trong hóa đơn.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;

CREATE TRIGGER trg_Check_SanPham_TrongHoaDon
ON YeuCauBaoHanh
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        LEFT JOIN ChiTietHoaDon c ON i.MaHoaDon = c.MaHoaDon AND i.MaSanPham = c.MaSanPham
        WHERE c.MaSanPham IS NULL
    )
    BEGIN
        RAISERROR ('Sản phẩm yêu cầu bảo hành không có trong hóa đơn.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;

CREATE TRIGGER trg_Check_ThoiGianBaoHanh
ON YeuCauBaoHanh
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN HoaDon h ON i.MaHoaDon = h.MaHoaDon
        JOIN ChiTietHoaDon c ON h.MaHoaDon = c.MaHoaDon
        JOIN SanPham s ON c.MaSanPham = s.MaSanPham
        LEFT JOIN BaoHanh b ON s.MaBaoHanh = b.MaBaoHanh
        WHERE DATEDIFF(MONTH, h.NgayLapHoaDon, i.NgayYeuCau) > b.ThoiGianBaoHanh
        AND i.MaSanPham = s.MaSanPham
    )
    BEGIN
        RAISERROR ('Yêu cầu bảo hành không còn hợp lệ do đã quá thời gian bảo hành.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;

----------------------------------
CREATE TRIGGER trg_insert_DanhMuc
ON DanhMuc
AFTER INSERT
AS
BEGIN
    UPDATE DanhMuc
    SET MoTa = N'(Trống)'
    FROM DanhMuc
    INNER JOIN inserted i ON DanhMuc.MaDanhMuc = i.MaDanhMuc
    WHERE i.MoTa IS NULL OR i.MoTa = '';
END;

CREATE OR ALTER TRIGGER trg_insert_sanpham
ON SanPham
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaxID INT
    SELECT @MaxID = ISNULL(MAX(CAST(SUBSTRING(MaSanPham, 3, 5) AS INT)), 0) FROM SanPham

    INSERT INTO SanPham (
        MaSanPham, MaBaoHanh, MaVach, TenSanPham, MaDanhMuc, MaNhaCungCap,
        MoTa, GiaBan, NgaySanXuat, XuatXu
    )
    SELECT 
        'SP' + RIGHT('00000' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @MaxID AS VARCHAR(5)), 5),
        MaBaoHanh, MaVach, TenSanPham, MaDanhMuc, MaNhaCungCap,
        MoTa, GiaBan, NgaySanXuat, XuatXu
    FROM inserted
END


CREATE OR ALTER TRIGGER trg_insert_khachhang
ON KhachHang
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaxID INT
    SELECT @MaxID = ISNULL(MAX(CAST(SUBSTRING(MaKhachHang, 3, 5) AS INT)), 0) FROM KhachHang

    INSERT INTO KhachHang (MaKhachHang, TenKhachHang, NgaySinh, SoDienThoai, DiemTichLuy, TrangThai)
    SELECT 
        'KH' + RIGHT('00000' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @MaxID AS VARCHAR(5)), 5),
        TenKhachHang, NgaySinh, SoDienThoai, DiemTichLuy, TrangThai
    FROM inserted
END


CREATE OR ALTER TRIGGER trg_insert_nhanvien
ON NhanVien
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaxID INT
    SELECT @MaxID = ISNULL(MAX(CAST(SUBSTRING(MaNhanVien, 3, 5) AS INT)), 0) FROM NhanVien

    INSERT INTO NhanVien (MaNhanVien, HinhAnh, TenNhanVien, GioiTinh, NgaySinh, SoDienThoai, Email, ChucVu, MucLuong, TaiKhoan, MatKhau)
    SELECT 
        'NV' + RIGHT('00000' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @MaxID AS VARCHAR(5)), 5),
        HinhAnh, TenNhanVien, GioiTinh, NgaySinh, SoDienThoai, Email, ChucVu, MucLuong, TaiKhoan, MatKhau
    FROM inserted
END

CREATE OR ALTER TRIGGER trg_insert_hoadon
ON HoaDon
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaxID INT
    SELECT @MaxID = ISNULL(MAX(CAST(SUBSTRING(MaHoaDon, 3, 5) AS INT)), 0) FROM HoaDon

    INSERT INTO HoaDon (MaHoaDon, MaNhanVien, MaKhachHang, MaKhuyenMai, NgayLapHoaDon, DiemDaDung, TongTien, PhuongThucThanhToan)
    SELECT 
        'HD' + RIGHT('00000' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @MaxID AS VARCHAR(5)), 5),
        MaNhanVien, MaKhachHang, MaKhuyenMai, NgayLapHoaDon, DiemDaDung, TongTien, PhuongThucThanhToan
    FROM inserted
END


CREATE OR ALTER TRIGGER trg_insert_giaohang
ON GiaoHang
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaxID INT
    SELECT @MaxID = ISNULL(MAX(CAST(SUBSTRING(MaGiaoHang, 3, 5) AS INT)), 0) FROM GiaoHang

    INSERT INTO GiaoHang (MaGiaoHang, MaHoaDon, NhanVienGiao, NgayGiao, DiaChi)
    SELECT 
        'GH' + RIGHT('00000' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @MaxID AS VARCHAR(5)), 5),
        MaHoaDon, NhanVienGiao, NgayGiao, DiaChi
    FROM inserted
END


CREATE OR ALTER TRIGGER trg_insert_yeucau_baohanh
ON YeuCauBaoHanh
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaxID INT
    SELECT @MaxID = ISNULL(MAX(CAST(SUBSTRING(MaYeuCauBaoHanh, 3, 5) AS INT)), 0) FROM YeuCauBaoHanh

    INSERT INTO YeuCauBaoHanh (MaYeuCauBaoHanh, MaHoaDon, MaSanPham, NgayYeuCau, LyDo, TrangThai)
    SELECT 
        'BH' + RIGHT('00000' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @MaxID AS VARCHAR(5)), 5),
        MaHoaDon, MaSanPham, NgayYeuCau, LyDo, TrangThai
    FROM inserted
END


CREATE OR ALTER TRIGGER trg_insert_trahang
ON TraHang
INSTEAD OF INSERT
AS
BEGIN
    --CREATE TABLE #TempTraHang (
    --    ID INT IDENTITY(1,1),
    --    MaHoaDon VARCHAR(15),
    --    NgayTra DATE
    --);

    --INSERT INTO #TempTraHang (MaHoaDon, NgayTra)
    --SELECT MaHoaDon, NgayTra
    --FROM inserted;

    --INSERT INTO TraHang (MaTraHang, MaHoaDon, NgayTra)
    --SELECT 
    --    'TH' + FORMAT(t.NgayTra, 'ddMMyyyy') + RIGHT('000' + CAST(ROW_NUMBER() OVER (PARTITION BY t.NgayTra ORDER BY t.ID) AS VARCHAR(3)), 3),
    --    t.MaHoaDon,
    --    t.NgayTra
    --FROM #TempTraHang t;

    --DROP TABLE #TempTraHang;

	 DECLARE @MaxID INT
    SELECT @MaxID = ISNULL(MAX(CAST(SUBSTRING(MaTraHang, 3, 5) AS INT)), 0) FROM TraHang

    INSERT INTO TraHang (MaTraHang, MaHoaDon, NgayTra)
    SELECT 
        'TH' + RIGHT('00000' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @MaxID AS VARCHAR(5)), 5),
         MaHoaDon, NgayTra
    FROM inserted
END


CREATE OR ALTER TRIGGER trg_insert_dondathang_nhacungcap
ON DonDatHangNhaCungCap
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaxID INT
    SELECT @MaxID = ISNULL(MAX(CAST(SUBSTRING(MaDonDatHang, 3, 5) AS INT)), 0) FROM DonDatHangNhaCungCap

    INSERT INTO DonDatHangNhaCungCap (MaDonDatHang, MaNhaCungCap, NgayDatHang, TongTien, TrangThai)
    SELECT 
        'DH' + RIGHT('00000' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @MaxID AS VARCHAR(5)), 5),
        MaNhaCungCap, NgayDatHang, TongTien, TrangThai
    FROM inserted
END

-------------------------------
--Thành tiền/Tổng tiền NCC
CREATE TRIGGER trg_TinhThanhTien
ON ChiTietDonDatHangNhaCungCap
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE ChiTietDonDatHangNhaCungCap
    SET ThanhTien = SoLuong * DonGia
    WHERE MaDonDatHang IN (SELECT MaDonDatHang FROM inserted)
      AND MaSanPham IN (SELECT MaSanPham FROM inserted)
END;

CREATE OR ALTER TRIGGER trg_CapNhatTongTien
ON ChiTietDonDatHangNhaCungCap
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE DonDatHangNhaCungCap
    SET TongTien = (
        SELECT COALESCE(SUM(ThanhTien), 0)
        FROM ChiTietDonDatHangNhaCungCap
        WHERE ChiTietDonDatHangNhaCungCap.MaDonDatHang = DonDatHangNhaCungCap.MaDonDatHang
    )
    WHERE MaDonDatHang IN (
        SELECT MaDonDatHang FROM inserted
        UNION
        SELECT MaDonDatHang FROM deleted
    )
END;

--Cập nhật điểm tích lũy
CREATE TRIGGER trg_CapNhatDiemTichLuy
ON HoaDon
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @MaKhachHang VARCHAR(13)
    DECLARE @TongTien INT
    DECLARE @DiemDaDung INT
    DECLARE @DiemMoi INT

    SELECT @MaKhachHang = MaKhachHang, 
           @TongTien = TongTien, 
           @DiemDaDung = DiemDaDung
    FROM inserted

    SET @DiemMoi = FLOOR(@TongTien / 10000)

    UPDATE KhachHang
    SET DiemTichLuy = DiemTichLuy - @DiemDaDung + @DiemMoi
    WHERE MaKhachHang = @MaKhachHang

    IF (SELECT DiemTichLuy FROM KhachHang WHERE MaKhachHang = @MaKhachHang) < 0
    BEGIN
        UPDATE KhachHang
        SET DiemTichLuy = 0
        WHERE MaKhachHang = @MaKhachHang
    END
END;


---------------------------------------
select * from DanhMuc, NhaCungCap
INSERT INTO DanhMuc (TenDanhMuc, MoTa) VALUES 
(N'Thiết Bị Điện Tử', N'Thiết bị điện tử công nghệ cao'),
(N'Điện Gia Dụng', N'Thiết bị điện gia dụng'),
(N'Thiết Bị Văn Phòng', N'Thiết bị dùng cho văn phòng'),
(N'Phụ Kiện', N'Phụ kiện các loại'),
(N'Âm Thanh', N'Thiết bị âm thanh');

INSERT INTO DanhMuc (TenDanhMuc, MoTa) VALUES 
(N'Laptop', N'Laptop các loại'),
(N'Điện Thoại', N'Điện thoại di động thông minh'),
(N'Máy Ảnh', N'Máy ảnh kỹ thuật số'),
(N'Thiết Bị Gaming', N'Thiết bị dành cho game thủ'),
(N'Phụ Kiện Máy Ảnh', N'Phụ kiện cho máy ảnh kỹ thuật số'),
(N'Máy In', N'Thiết bị in ấn cho văn phòng và gia đình'),
(N'Loa', N'Hệ thống âm thanh loa'),
(N'Thiết Bị Nhà Thông Minh', N'Thiết bị điều khiển nhà thông minh');


INSERT INTO NhaCungCap (TenNhaCungCap, NguoiLienHe, SoDienThoai, Email, DiaChi) VALUES 
(N'Samsung', N'Nguyễn Văn A', '0123456789', 'a@samsung.com', N'TPHCM'),
(N'Sony', N'Trần Văn B', '0123456790', 'b@sony.com', N'HN'),
(N'LG', N'Phạm Văn C', '0123456791', 'c@lg.com', N'DN'),
(N'Apple', N'Lê Văn D', '0123456792', 'd@apple.com', N'USA'),
(N'Panasonic', N'Võ Văn E', '0123456793', 'e@panasonic.com', N'Japan');

INSERT INTO NhaCungCap (TenNhaCungCap, NguoiLienHe, SoDienThoai, Email, DiaChi) VALUES 
(N'Dell', N'Nguyễn Văn F', '0123456794', 'f@dell.com', N'USA'),
(N'Asus', N'Trần Văn G', '0123456795', 'g@asus.com', N'Taiwan'),
(N'Canon', N'Phạm Văn H', '0123456796', 'h@canon.com', N'Japan'),
(N'Nikon', N'Lê Văn I', '0123456797', 'i@nikon.com', N'Japan'),
(N'Microsoft', N'Võ Văn J', '0123456798', 'j@microsoft.com', N'USA'),
(N'HP', N'Nguyễn Văn K', '0123456799', 'k@hp.com', N'USA'),
(N'Razer', N'Trần Văn L', '0123456700', 'l@razer.com', N'USA'),
(N'Logitech', N'Phạm Văn M', '0123456701', 'm@logitech.com', N'Switzerland');


INSERT INTO BaoHanh (MaBaoHanh, ThoiGianBaoHanh) VALUES
('BH1T', 1),
('BH3T', 3),
('BH6T', 6),
('BH12T', 12)

INSERT INTO SanPham (MaBaoHanh, MaVach, TenSanPham, MaDanhMuc, MaNhaCungCap, MoTa, GiaBan, NgaySanXuat, XuatXu) VALUES 
('BH1T', '0123546203', N'Tivi Samsung', 101, 100, N'Tivi 4K 55 inch', 1500000.000, '2022-01-01', N'Hàn Quốc'),
('BH3T', '0123546207', N'Tủ lạnh LG', 102, 102, N'Tủ lạnh Inverter 300L', 1200000.000, '2022-02-01', N'Hàn Quốc'),
('BH6T', '0123546206', N'Tai nghe Sony', 103, 101, N'Tai nghe chống ồn', 200000.000, '2022-03-01', N'Nhật Bản'),
('BH12T', '0123546205', N'Điều hòa Panasonic', 102, 104, N'Điều hòa 2 chiều', 1800000.000, '2022-04-01', N'Nhật Bản'),
('BH12T', '0123546204', N'Iphone 13', 101, 103, N'Smartphone cao cấp', 3000000.000, '2022-05-01', N'Mỹ');

INSERT INTO SanPham (MaBaoHanh, MaVach, TenSanPham, MaDanhMuc, MaNhaCungCap, MoTa, GiaBan, NgaySanXuat, XuatXu) VALUES 
('BH12T', '0123546210', N'Laptop Dell XPS 13', 116, 114, N'Laptop cao cấp 13 inch', 3500000.000, '2022-06-01', N'Mỹ'),
('BH6T', '0123546211', N'Asus ROG Phone 5', 117, 115, N'Diện thoại gaming cao cấp', 2500000.000, '2022-07-01', N'Taiwan'),
('BH12T', '0123546212', N'Máy ảnh Canon EOS 90D', 103, 116, N'Máy ảnh DSLR chất lượng cao', 1800000.000, '2022-08-01', N'Nhật Bản'),
('BH3T', '0123546213', N'Tai nghe Razer Kraken', 103, 120, N'Tai nghe gaming chuyên nghiệp', 500000.000, '2022-09-01', N'USA'),
('BH12T', '0123546214', N'Máy in HP LaserJet Pro', 121, 119, N'Máy in laser đơn năng', 1200000.000, '2022-10-01', N'Mỹ'),
('BH12T', '0123546215', N'Loa Logitech Z906', 106, 121, N'Hệ thống âm thanh 5.1', 1500000.000, '2022-11-01', N'Thụy Sĩ'),
('BH6T', '0123546216', N'Microsoft Surface Laptop 4', 106, 118, N'Laptop mỏng nhẹ 15 inch', 3000000.000, '2022-12-01', N'Mỹ'),
('BH12T', '0123546217', N'Loa Sony SRS-XB43', 122, 101, N'Loa bluetooth chống nước', 700000.000, '2023-01-01', N'Nhật Bản'),
('BH12T', '0123546218', N'Nikon D3500', 118, 106, N'Máy ảnh DSLR cho người mới', 1000000.000, '2023-02-01', N'Nhật Bản'),
('BH12T', '0123546219', N'Laptop Asus TUF Gaming', 116, 115, N'Laptop gaming hiệu năng cao', 2000000.000, '2023-03-01', N'Taiwan'),
('BH6T', '0123546220', N'Máy ảnh Sony Alpha 7C', 118, 101, N'Máy ảnh mirrorless nhỏ gọn', 2200000.000, '2023-04-01', N'Nhật Bản'),
('BH12T', '0123546221', N'Tai nghe Bluetooth Apple AirPods Pro', 103, 104, N'Tai nghe chống ồn chủ động', 800000.000, '2023-05-01', N'Mỹ');

INSERT INTO KhachHang (TenKhachHang, NgaySinh, SoDienThoai) VALUES 
(N'Nguyễn Văn A', '1990-01-01', '0123456789'),
(N'Trần Văn B', '1991-02-01', '0123456790'),
(N'Phạm Văn C', '1992-03-01', '0123456791'),
(N'Lê Văn D', '1993-04-01', '0123456792'),
(N'Võ Văn E', '1994-05-01', '0123456793');

INSERT INTO NhanVien (TenNhanVien, GioiTinh, NgaySinh, SoDienThoai, Email, ChucVu, MucLuong, TaiKhoan, MatKhau) VALUES 
(N'Nguyễn Văn F', N'Nam', '1980-01-01', '0123456788', 'f@company.com', N'Quản lý', 20000.000, 'quanly', '1234'),
(N'Trần Văn G', N'Nam', '1981-02-01', '0123456799', 'g@company.com', N'Nhân viên bán hàng', 15000.000, 'banhang', '4567'),
(N'Phạm Văn H', N'Nam', '1982-03-01', '0123456800', 'h@company.com', N'Nhân viên quản lý hàng hóa', 12000.000, 'hanghoa', '8910'),
(N'Lê Văn I', N'Nam', '1983-04-01', '0123456801', 'i@company.com', N'Nhân viên giao hàng', 13000.000, 'giaohang', '1011'),
(N'Võ Văn J', N'Nam', '1984-05-01', '0123456802', 'j@company.com', N'Nhân viên bảo hành và đổi trả', 14000.000, 'baohanh', '1213'),
(N'Lê Văn Hehe', N'Nam', '1999-06-01', '0123451023', 'k@company.com', N'Nhân viên marketing', 13000.000, 'marketing', '1415'),
(N'Võ Văn Haha', N'Nam', '1981-07-01', '0123455630', 'l@company.com', N'Nhân viên thống kê', 14000.000, 'thongke', '1617');

INSERT INTO KhuyenMai (MaKhuyenMai, TenChuongTrinh, GiaTriKhuyenMai, MoTa, NgayBatDau, NgayKetThuc, DieuKienApDung , GiaTriDonHangToiThieu) VALUES 
('KMH5TR',N'Khuyến mãi mùa hè', 5000.000, N'Giảm trực tiếp', '2023-06-01', '2024-06-30', N'Áp dụng cho đơn hàng trên 20 triệu', 20000000),
('KM3TR', N'Khuyến mãi mùa đông', 3000.000, N'Giảm trực tiếp', '2023-12-01', '2024-12-31', N'Áp dụng cho đơn hàng trên 15 triệu', 15000000),
('BFD7', N'Black Friday', 0.07, N'Giảm phần trăm', '2023-11-25', '2025-11-25', N'Áp dụng cho tất cả sản phẩm', 0),
('BD10', N'Sinh nhật công ty', 10000.000, N'Giảm trực tiếp', '2024-07-01', '2024-07-07', N'Áp dụng cho đơn hàng trên 30 triệu', 30000000),
('GS4',N'Giáng sinh', 0.4, N'Giảm phần trăm', '2023-12-24', '2024-12-25', N'Áp dụng cho đơn hàng trên 10 triệu', 10000000);

insert into KhuyenMai (MaKhuyenMai,GiaTriKhuyenMai, TenChuongTrinh, MoTa)
values ('KHONG',N'Không',0,N'Không áp dụng chương trình khuyến mãi')

INSERT INTO DonDatHangNhaCungCap (MaNhaCungCap, NgayDatHang, TrangThai)
VALUES
(100, '2024-08-05', N'Đã đặt hàng'),
(101, '2024-07-01', N'Đã nhập hàng vào kho'),
(102, '2024-08-06', N'Đã đặt hàng'),
(103, '2024-08-06', N'Đã đặt hàng'),
(104, '2024-07-05', N'Đã nhập hàng vào kho')

INSERT INTO ChiTietDonDatHangNhaCungCap (MaDonDatHang, MaSanPham, SoLuong, DonGia)
VALUES
('DH00001', 'SP00001', 5, 15000.000),
('DH00002', 'SP00002', 2, 30000.000),
('DH00003', 'SP00003', 3, 18000.000),
('DH00004', 'SP00004', 10, 2000.000),
('DH00005', 'SP00005', 10, 2000.000),
('DH00005', 'SP00005', 1, 12000.000);

Insert into TraHang (MaHoaDon, NgayTra) values ('HD00001', '9/6/2024 8:58:24 AM')

select * from HoaDon left join ChiTietHoaDon on HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon

select * from NhaCungCap