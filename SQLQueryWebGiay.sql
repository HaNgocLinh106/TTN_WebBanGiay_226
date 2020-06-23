create database WebBanGiay_226
go
use WebBanGiay_226
go

create table QuanTriVien
(
UserName int identity(1,1) primary key,
Email char(50),
Pass char(10),
PhanQuyen char(10),
)

create table DanhMuc
(
MaDanhMuc bigint identity(1,1) primary key,
TenDanhMuc nvarchar(250),
MetaTitle varchar(50),
)

create table SanPham
(
MaSanPham bigint identity(1,1) primary key,
TenSanPham nvarchar(100),
MetaTitle varchar(50),
DonGia int,
LinkAnhSP nvarchar(20),
MoTa nvarchar(500),
TrangThai bit,
MaDanhMuc bigint references DanhMuc(MaDanhMuc),
)

 create table ChiTietSanPham
 (
 MaCTSP bigint identity(1,1) primary key,
 MetaTitle varchar(50),
 Code varchar(50),
 Mau nvarchar(20),
 Size int,
 SoLuong int,
 LinkAnh nvarchar(20),
 TrangThai bit,
 MaSanPham bigint references SanPham(MaSanPham),
 )

 create table NguoiDung
 (
 MaNguoiDung int identity(1,1) primary key,
 TenNguoiDung nvarchar(250),
 SDT char(10),
 DiaChi nvarchar(500),
 UserName char(250),
 Pass char(10),
 )
 create table PhanHoi
 (
 MaPhanHoi int identity(1,1) primary key,
 MaNguoiDung int references NguoiDung(MaNguoiDung),
 NoiDung nvarchar(500),
 NgayPhanHoi datetime,
 )

 create table GioHang 
 (
 MaGioHang bigint identity(1,1) primary key,
 MaNguoiDung int references NguoiDung(MaNguoiDung),
 NgayThang date,
 HinhThucThanhToan nvarchar(250),
 TenNguoiDung nvarchar(250),
 SDT char(10),
 DiaChi nvarchar(500),
 )

 create table ChiTietGioHang
 (
 MaChiTietGioHang bigint identity(1,1) primary key,
 MaGioHang bigint references GioHang(MaGioHang),
 MaCTSP bigint references ChiTietSanPham(MaCTSP),
 DonGia int,
 SoLuong int,
 )