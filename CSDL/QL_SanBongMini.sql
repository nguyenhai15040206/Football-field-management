Create database QL_SanBongDaMini
Use QL_SanBongDaMini
Go


-- Bảng người dùng hệ thống
Create table NguoiDung
(
	maNguoiDung int identity(1,1) primary key,
	tenNguoiDung nvarchar(101),
	tenDangNhap varchar(31),
	matKhau varchar(101),
	diaChi nvarchar(500),
	soDienThoai varchar(11),
	email varchar(51),
	ngayVaoLam date,
	hoatDong bit,
)

-- Bảng Nhóm người dùng
Create table QL_NhomNguoiDung
(
	maNhom int identity(1,1) primary key,
	tenNhom nvarchar(100),
	ghiChu nvarchar(101)
)

-- Bảng danh mục nàm hình chức năng
Create table DanhMucManHinh
(
	maManHinh int identity (1,1) primary key,
	tenManHinh nvarchar(101)
)


-- bảng Quản lý người dùng nhóm người dùng
Create table QL_NguoiDungNhomNguoiDung
(
	maNguoiDung int,
	maNhom int,
	ghiChu nvarchar(101),
	primary key (maNguoiDung,maNhom),
	Constraint fk_QLNguoiDungNhomNguoiDung_QLNhomNguoiDung foreign key(maNhom) references QL_NhomNguoiDung(maNhom),
	Constraint fk_QLNguoiDungNhomNguoiDung_NguoiDung foreign key(maNguoiDung) references NguoiDung(maNguoiDung)
)

-- Bảng phân quyền
Create table QL_PhanQuyen
(
	maNhom int,
	maManHinh int,
	coQuyen bit,
	primary key(maNhom, maManHinh),
	Constraint fk_QL_PhanQuyen_QL_NhomNguoiDung foreign key(maNhom) references QL_NhomNguoiDung(maNhom),
	Constraint fk_QL_PhanQuyen_ManHinh foreign key(maManHinh) references DanhMucManHinh(maManHinh)
)


-- Bảng loại khách hàng
create table LoaiKhachHang
(
	maLoaiKhachHang int identity(1,1) primary key,
	tenLoai nvarchar(101),
	giamGia float, -- giảm giá theo phần trăm
)

-- Bảng khách hàng
create table KhachHang
(
	maKhachHang int identity(1,1) primary key,
	tenKhachHang nvarchar(71),
	soDienThoai varchar(11),
	diemTichLuy float,
	maLoaiKhachHang int,
	constraint FK_KH_LKH foreign key (maLoaiKhachHang) references LoaiKhachHang(maLoaiKhachHang)
)

-- Bảng loại sân
create table LoaiSan
(
	maLoaiSan int identity(1,1) primary key,
	tenLoai nvarchar(101)
)

-- Bảng Sân bóng
create table sanBong
(
	maSan int identity(1,1) primary key,
	tenSan nvarchar(51),
	maLoaiSan int,
	tinhTrang bit,
	constraint FK_SB_LS foreign key(maLoaiSan) references LoaiSan(maLoaiSan)
)



-- Bảng đơn giá giờ
create table DonGiaGio
(
	maloaiSan int,
	tuKhungGio float,
	denKhungGio float,
	ngayCapNhat date,
	donGia money,
	primary key(maloaiSan,tuKhungGio,denKhungGio,ngayCapNhat),
	constraint FK_DGG_LS foreign key(maLoaiSan) references LoaiSan(maLoaiSan),
)

-- Bảng đặt sân
create table DatSan
(
	maSan int,
	maKhachHang int,
	maNguoiDung int,
	NgayDat date,
	GioVao time,
	GioRa time,
	tienSan money,
	tienCoc money,
	ghiChu nvarchar(101),
	tinhTrang bit,
	primary key(maSan, NgayDat, GioVao, gioRa),
	constraint FK_DS_SB foreign key(maSan) references SanBong(maSan),
	constraint FK_DS_KH foreign key(maKhachHang) references KhachHang(maKhachHang),
	constraint fk_DS_ND foreign key(maNguoiDung) references NguoiDung(maNguoiDung)
)

-- Bảng thức uống
create table ThucUong
(
	maThucUong int identity(1,1) primary key,
	tenThucUong nvarchar(51),
	DVT nvarchar(21),
	giaBan money,
	giaNhap money,
	soLuong int,
	tinhTrang bit, -- còn hàng hay hết hàng
)

-- Bảng nhà cung cấp
create table NhaCungCap
(
	maNhaCungCap int identity(1,1) primary key,
	tenNhaCungCap nvarchar(101),
	SoDienThoai varchar(11),
	diaChi nvarchar(500)
)

-- Bảng phiếu nhập
create table PhieuNhap
(
	maPhieuNhap int identity(1,1) primary key,
	NgayLap date,
	tongTien money,
	maNhaCungCap int,
	maNguoiDung int,
	tinhTrang bit,
	constraint FK_PN_NCC foreign key(maNhaCungCap) references NhaCungCap(maNhaCungCap),
	constraint FK_PN_NV foreign key(maNguoiDung) references NguoiDung(maNguoiDung)
)


-- Bảng chi tiết phiếu nhập
create table ChiTietPN
(
	maPhieuNhap int,
	maThucUong int,
	soLuong int,
	donGia money,
	thanhTien money,
	primary key(maPhieuNhap, maThucUong),
	constraint FK_CTPN_PN foreign key(maPhieuNhap) references PhieuNhap(maPhieuNhap),
	constraint FK_CTPN_TU foreign key(maThucUong) references ThucUong(maThucUong)
)

-- Bảng hóa đơn
create table HoaDon
(
	maHoaDon int identity(1,1) primary key,
	ngayLap datetime,
	tienSan money,
	giamGia money,
	tienNuoc money,
	tongTien money,
	maSan int,
	maKhachHang int,
	ngayDat date,
	gioVao time,
	gioRa time,
	maNguoiDung int,
	tinhTrang bit,
	constraint FK_HD_NV foreign key(maNguoiDung) references NguoiDung(maNguoiDung),
	constraint FK_HD_KH foreign key(maKhachHang) references KhachHang(maKhachHang)	,
	constraint FK_HD_San foreign key(maSan) references sanBong(maSan)	
)

-- Bảng chi tiết hóa đơn
create table ChiTietHD
(
	maHoaDon int,
	maThucUong int,
	soLuong int,
	giaBan money,
	thanhTien money,
	primary key(maHoaDon, maThucUong),
	constraint FK_CTHD_HD foreign key(maHoaDon) references HoaDon(maHoaDon),
	constraint FK_CTHD_TU foreign key(maThucUong) references ThucUong(maThucUong)
)

select * from LoaiSan
Insert into LoaiSan(tenLoai) values (N'Sân 5 người')
Insert into LoaiSan(tenLoai) values (N'Sân 7 người')
Insert into LoaiSan(tenLoai) values (N'Sân 11 người')

select * from sanBong
Insert into sanBong(tenSan,maLoaiSan,tinhTrang) values (N'Sân 5 -1',1,1)
Insert into sanBong(tenSan,maLoaiSan,tinhTrang) values (N'Sân 5 -2',1,'True')
Insert into sanBong(tenSan,maLoaiSan,tinhTrang) values (N'Sân 5 -3',1,'True')
Insert into sanBong(tenSan,maLoaiSan,tinhTrang) values (N'Sân 7 -1',2,1)
Insert into sanBong(tenSan,maLoaiSan,tinhTrang) values (N'Sân 7 -2',2,1)
Insert into sanBong(tenSan,maLoaiSan,tinhTrang) values (N'Sân 11 -1',3,1)

select * from LoaiKhachHang
Insert into LoaiKhachHang(tenLoai,giamGia) values(N'Khách lẻ',0.0)
Insert into LoaiKhachHang(tenLoai,giamGia) values(N'Khách hàng tiềm năng',10.0)
Insert into LoaiKhachHang(tenLoai,giamGia) values(N'Khách hàng thân thiết',20.0)


select * from NguoiDung
Insert into NguoiDung(tenNguoiDung,tenDangNhap,matKhau, diaChi,soDienThoai,email,ngayVaoLam,hoatDong) values (N'Nguyễn Tấn Hải','HaiNguyen','202cb962ac59075b964b07152d234b70',N'Nguyễn Hữu Tiến','0357866848','nguyenhai15040206@gmail.com','05-25-2021',1)
select * from KhachHang

Insert into KhachHang(tenKhachHang,soDienThoai,diemTichLuy, maLoaiKhachHang) values (N'Nguyễn Tấn Sơn','0984186195',0,1)
Insert into KhachHang(tenKhachHang,soDienThoai,diemTichLuy, maLoaiKhachHang) values (N'Nguyễn Tấn Hải','0357866848',0,2)

select * from DonGiaGio

Insert into DonGiaGio values (1,5,9,'05-25-2021',180000)
Insert into DonGiaGio values (1,9,14,'05-25-2021',140000)
Insert into DonGiaGio values (1,14,17,'05-25-2021',220000)
Insert into DonGiaGio values (1,17,20,'05-25-2021',250000)
Insert into DonGiaGio values (1,20,23,'05-25-2021',230000)

Insert into DonGiaGio values (2,5,9,'05-25-2021',250000)
Insert into DonGiaGio values (2,9,14,'05-25-2021',200000)
Insert into DonGiaGio values (2,14,17,'05-25-2021',270000)
Insert into DonGiaGio values (2,17,20,'05-25-2021',300000)
Insert into DonGiaGio values (2,20,23,'05-25-2021',250000)

Insert into DonGiaGio values (3,5,9,'05-25-2021',300000)
Insert into DonGiaGio values (3,9,14,'05-25-2021',250000)
Insert into DonGiaGio values (3,14,17,'05-25-2021',270000)
Insert into DonGiaGio values (3,17,20,'05-25-2021',350000)
Insert into DonGiaGio values (3,20,23,'05-25-2021',270000)

select * from ThucUong
-- thức uống
INSERT [dbo].[ThucUong] ( [tenThucUong], [DVT], [giaBan],[giaNhap], [soLuong], [tinhTrang]) VALUES ( N'Device', N'Chai', 12000.0000,10000, 120, 1)
INSERT [dbo].[ThucUong] ( [tenThucUong], [DVT], [giaBan],[giaNhap], [soLuong], [tinhTrang]) VALUES ( N'Trà xanh', N'Chai', 12000.0000,10000, 120, 1)
INSERT [dbo].[ThucUong] ( [tenThucUong], [DVT], [giaBan], [giaNhap],[soLuong], [tinhTrang]) VALUES ( N'Sting', N'Chai', 12000.0000,10000, 120, 1)
INSERT [dbo].[ThucUong] ( [tenThucUong], [DVT], [giaBan], [giaNhap],[soLuong], [tinhTrang]) VALUES ( N'C2', N'Chai', 12000.0000,10000, 120, 1)
INSERT [dbo].[ThucUong] ( [tenThucUong], [DVT], [giaBan],[giaNhap] ,[soLuong], [tinhTrang]) VALUES ( N'Ô long', N'Chai', 12000.0000,10000, 120, 1)
INSERT [dbo].[ThucUong] ( [tenThucUong], [DVT], [giaBan],[giaNhap], [soLuong], [tinhTrang]) VALUES ( N'Chanh muối', N'Chai', 12000.0000,10000, 120, 1)


