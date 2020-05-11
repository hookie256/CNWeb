USE [master]
GO
/****** Object:  Database [CNWeb_Pharmacy]    Script Date: 5/9/2020 10:52:25 PM ******/
CREATE DATABASE [CNWeb_Pharmacy]
GO
USE [CNWeb_Pharmacy]
GO
/****** Object:  Table [dbo].[CHITIETPHIEUXUAT]    Script Date: 5/9/2020 10:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETPHIEUXUAT](
	[MaPhieuXuat] [char](20) NOT NULL,
	[MaThuoc] [char](20) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK_CHITIETPHIEUXUAT] PRIMARY KEY CLUSTERED 
(
	[MaPhieuXuat] ASC,
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HANGSANXUAT]    Script Date: 5/9/2020 10:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HANGSANXUAT](
	[MaHangSX] [char](15) NOT NULL,
	[TenHangSX] [nvarchar](50) NULL,
	[QuocGia] [nvarchar](30) NULL,
 CONSTRAINT [PK_HANGSANXUAT] PRIMARY KEY CLUSTERED 
(
	[MaHangSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 5/9/2020 10:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKhachHang] [char](35) NOT NULL,
	[TenKhachHang] [nvarchar](40) NOT NULL,
	[SoDienThoai] [char](15) NOT NULL,
	[CMND/TCCCD] [nchar](12) NOT NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAITHUOC]    Script Date: 5/9/2020 10:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAITHUOC](
	[MaLoaiThuoc] [char](15) NOT NULL,
	[TenLoaiThuoc] [nvarchar](30) NULL,
 CONSTRAINT [PK_LOAITHUOC] PRIMARY KEY CLUSTERED 
(
	[MaLoaiThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 5/9/2020 10:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MaNhaCungCap] [char](15) NOT NULL,
	[TenNhaCungCap] [nvarchar](30) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[ThongTinDaiDien] [nvarchar](50) NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY CLUSTERED 
(
	[MaNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUXUAT]    Script Date: 5/9/2020 10:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUXUAT](
	[MaPhieuXuat] [char](20) NOT NULL,
	[NgayXuat] [date] NULL,
	[MaKhachHang] [char](35) NULL,
	[Tong] [int] NULL,
 CONSTRAINT [PK_PHIEUXUAT] PRIMARY KEY CLUSTERED 
(
	[MaPhieuXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THUOC]    Script Date: 5/9/2020 10:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THUOC](
	[MaThuoc] [char](20) NOT NULL,
	[TenThuoc] [nvarchar](max) NOT NULL,
	[CongDung] [nvarchar](max) NOT NULL,
	[ThanhPhan] [nvarchar](max) NOT NULL,
	[SoLuongTon] [int] NOT NULL,
	[DangThuoc] [nvarchar](20) NOT NULL,
	[MaLoaiThuoc] [char](15) NOT NULL,
	[DonGia] [int] NULL,
	[MaHangSX] [char](15) NULL,
	[MaNhaCungCap] [char](15) NULL,
	[UrlImage] [char](50) NULL,
 CONSTRAINT [PK_THUOC] PRIMARY KEY CLUSTERED 
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPhieuXuat], [MaThuoc], [SoLuong], [DonGia]) VALUES (N'080320200368732033  ', N'DPPM0120.TTY.PCTM   ', 2, 60000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPhieuXuat], [MaThuoc], [SoLuong], [DonGia]) VALUES (N'090320200345454543  ', N'AT670218.TTY.DCT5   ', 2, 50000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPhieuXuat], [MaThuoc], [SoLuong], [DonGia]) VALUES (N'100320200359999574  ', N'AT670218.TTY.DCT5   ', 1, 50000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPhieuXuat], [MaThuoc], [SoLuong], [DonGia]) VALUES (N'100320200359999574  ', N'BG5T0519.TDY.CSR    ', 1, 50000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPhieuXuat], [MaThuoc], [SoLuong], [DonGia]) VALUES (N'110320200368733032  ', N'BG5T0519.TDY.CSR    ', 1, 50000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPhieuXuat], [MaThuoc], [SoLuong], [DonGia]) VALUES (N'110320200368733032  ', N'DPDC0818.TTY.PTU    ', 1, 100000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPhieuXuat], [MaThuoc], [SoLuong], [DonGia]) VALUES (N'120320200356879565  ', N'AT670218.TTY.DCT5   ', 1, 50000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPhieuXuat], [MaThuoc], [SoLuong], [DonGia]) VALUES (N'120320200356879565  ', N'BG5T0519.TDY.CSR    ', 1, 50000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPhieuXuat], [MaThuoc], [SoLuong], [DonGia]) VALUES (N'150320200433433443  ', N'BG5T0519.TDY.CSR    ', 1, 50000)
INSERT [dbo].[HANGSANXUAT] ([MaHangSX], [TenHangSX], [QuocGia]) VALUES (N'AT67           ', N'Công ty DP Armephaco', N'Việt Nam')
INSERT [dbo].[HANGSANXUAT] ([MaHangSX], [TenHangSX], [QuocGia]) VALUES (N'BG5T           ', N'Công ty DP Traphaco', N'Việt Nam')
INSERT [dbo].[HANGSANXUAT] ([MaHangSX], [TenHangSX], [QuocGia]) VALUES (N'DPDC           ', N'Công ty DP Davinci', N'Pháp')
INSERT [dbo].[HANGSANXUAT] ([MaHangSX], [TenHangSX], [QuocGia]) VALUES (N'DPHL           ', N'Công ty DP Hoa Linh', N'Việt Nam')
INSERT [dbo].[HANGSANXUAT] ([MaHangSX], [TenHangSX], [QuocGia]) VALUES (N'DPPM           ', N'Công ty DP Pharmedic', N'Việt Nam')
INSERT [dbo].[HANGSANXUAT] ([MaHangSX], [TenHangSX], [QuocGia]) VALUES (N'DPSD           ', N'Công ty DP Shinpoong Daewoo', N'Hàn Quốc')
INSERT [dbo].[HANGSANXUAT] ([MaHangSX], [TenHangSX], [QuocGia]) VALUES (N'MTV            ', N'Một thành viên', N'Việt Nam')
INSERT [dbo].[HANGSANXUAT] ([MaHangSX], [TenHangSX], [QuocGia]) VALUES (N'NTP            ', N'Nam Thiên Phú', N'Việt Nam')
INSERT [dbo].[KHACHHANG] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [CMND/TCCCD]) VALUES (N'0310566549870356879565             ', N'Nguyễn Văn Dũng', N'0356879565     ', N'031056654987')
INSERT [dbo].[KHACHHANG] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [CMND/TCCCD]) VALUES (N'0310990054320359999574             ', N'Hoàng Văn Việt', N'0359999574     ', N'031099005432')
INSERT [dbo].[KHACHHANG] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [CMND/TCCCD]) VALUES (N'0310990054380368733032             ', N'Phan Thanh Tùng', N'0368733032     ', N'031099005438')
INSERT [dbo].[KHACHHANG] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [CMND/TCCCD]) VALUES (N'0310990054830368732033             ', N'Lỗ Trung Hiếu', N'0368732033     ', N'031099005483')
INSERT [dbo].[KHACHHANG] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [CMND/TCCCD]) VALUES (N'0312347659870345454543             ', N'Nguyễn Thị Chi', N'0345454543     ', N'031234765987')
INSERT [dbo].[KHACHHANG] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [CMND/TCCCD]) VALUES (N'0433433443031456433434             ', N'Nguyễn Tiến Mạnh', N'0433433443     ', N'031456433434')
INSERT [dbo].[LOAITHUOC] ([MaLoaiThuoc], [TenLoaiThuoc]) VALUES (N'CSCT           ', N'Chăm sóc cơ thể')
INSERT [dbo].[LOAITHUOC] ([MaLoaiThuoc], [TenLoaiThuoc]) VALUES (N'CSRM           ', N'Chăm sóc răng miệng')
INSERT [dbo].[LOAITHUOC] ([MaLoaiThuoc], [TenLoaiThuoc]) VALUES (N'CSSD           ', N'Chăm sóc sắc đẹp')
INSERT [dbo].[LOAITHUOC] ([MaLoaiThuoc], [TenLoaiThuoc]) VALUES (N'DCSC           ', N'Dụng cụ sơ cứu')
INSERT [dbo].[LOAITHUOC] ([MaLoaiThuoc], [TenLoaiThuoc]) VALUES (N'DCYT           ', N'Dụng cụ y tế')
INSERT [dbo].[LOAITHUOC] ([MaLoaiThuoc], [TenLoaiThuoc]) VALUES (N'TDY            ', N'Thuốc Đông Y')
INSERT [dbo].[LOAITHUOC] ([MaLoaiThuoc], [TenLoaiThuoc]) VALUES (N'TNY            ', N'Thuốc Nam Y')
INSERT [dbo].[LOAITHUOC] ([MaLoaiThuoc], [TenLoaiThuoc]) VALUES (N'TPCN           ', N'Thực Phẩm Chức Năng')
INSERT [dbo].[LOAITHUOC] ([MaLoaiThuoc], [TenLoaiThuoc]) VALUES (N'TTGD           ', N'Tủ thuốc gia đình')
INSERT [dbo].[LOAITHUOC] ([MaLoaiThuoc], [TenLoaiThuoc]) VALUES (N'TTY            ', N'Thuốc Tây Y')
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [ThongTinDaiDien]) VALUES (N'NCC1           ', N'CTY PP Ngô Phong', N'Hoàng Mai - Hà Nội', N'Ngô Hồng Phong')
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [ThongTinDaiDien]) VALUES (N'NCC2           ', N'CTY TNHH Downstair', N'Hai Bà Trưng - Hà Nội', N'Nguyễn Kiều Anh')
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [ThongTinDaiDien]) VALUES (N'NCC3           ', N'CTY PP Duy Anh', N'Chí Linh - Hải Dương', N'Phạm Công Anh')
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [ThongTinDaiDien]) VALUES (N'NCC4           ', N'CTY TNHH Hải Lam', N'Hưng Hà - Thái Bình', N'Nguyễn Văn Công')
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [ThongTinDaiDien]) VALUES (N'NCC5           ', N'CTY PP Wefor', N'Hoàn Kiếm - Hà Nội', N'Đào Duy Anh')
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [ThongTinDaiDien]) VALUES (N'NCC6           ', N'CTY PP Gamma', N'Hai Bà Trưng - Hà Nội', N'Vũ Trọng Luận')
INSERT [dbo].[PHIEUXUAT] ([MaPhieuXuat], [NgayXuat], [MaKhachHang], [Tong]) VALUES (N'080320200368732033  ', CAST(N'2020-03-08' AS Date), N'0310990054830368732033             ', 120000)
INSERT [dbo].[PHIEUXUAT] ([MaPhieuXuat], [NgayXuat], [MaKhachHang], [Tong]) VALUES (N'090320200345454543  ', CAST(N'2020-03-10' AS Date), N'0312347659870345454543             ', 100000)
INSERT [dbo].[PHIEUXUAT] ([MaPhieuXuat], [NgayXuat], [MaKhachHang], [Tong]) VALUES (N'100320200359999574  ', CAST(N'2020-03-10' AS Date), N'0310990054320359999574             ', 100000)
INSERT [dbo].[PHIEUXUAT] ([MaPhieuXuat], [NgayXuat], [MaKhachHang], [Tong]) VALUES (N'110320200368733032  ', CAST(N'2020-03-11' AS Date), N'0310990054380368733032             ', 150000)
INSERT [dbo].[PHIEUXUAT] ([MaPhieuXuat], [NgayXuat], [MaKhachHang], [Tong]) VALUES (N'120320200356879565  ', CAST(N'2020-03-12' AS Date), N'0310566549870356879565             ', 50000)
INSERT [dbo].[PHIEUXUAT] ([MaPhieuXuat], [NgayXuat], [MaKhachHang], [Tong]) VALUES (N'150320200433433443  ', CAST(N'2020-03-15' AS Date), N'0433433443031456433434             ', 50000)
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'AT670218.TTY.DCT5   ', N'D-Contresin 500', N'Chống đau lưng, vẹo cổ', N'Mephenesin', 1297, N'Viên nén', N'TTY            ', 23000, N'AT67           ', N'NCC1           ', NULL)
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'BG5T0519.TDY.CSR    ', N'Casoran', N'Thuốc hạ huyết áp', N'Cao hoa hòe, Cao dừa cạn, Cao tâm sen, Cao cúc hoa', 1296, N'Thuốc cốm', N'TDY            ', 3000, N'BG5T           ', N'NCC1           ', NULL)
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'Coq1234             ', N'Coq10 Mỹ', N'Co-enzim Q10 được sản xuất tại Mỹ có tác dụng hàng đầu trong việc bồi bổ sức khỏe cho trái tim. Vì giữ cho trái tim của bạn mạnh mẽ là một phần quan trọng của việc có một sức khỏe tốt.', N'Co enzim', 500, N'Hộp 30 viên', N'TPCN           ', 50000, N'NTP            ', N'NCC2           ', N'coq.jpg                                           ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'DPDC0818.TTY.PTU    ', N'PTU Thepharm', N'ức chế tổng hợp hormon tuyến giáp', N'Propylthiouracil', 1299, N'Viên nén', N'TTY            ', 5000, N'DPDC           ', N'NCC1           ', NULL)
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'DPHL1118.TTY.ABC    ', N'Abicin 250', N'Tác dụng kháng sinh', N'Amikacin', 1599, N'Bột pha tiêm', N'TTY            ', 55000, N'DPPM           ', N'NCC1           ', NULL)
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'DPPM0120.TTY.PCTM   ', N'PARACETAMOL 500 mg', N'Hạ sốt', N'Paracetamol', 1299, N'Viên nén', N'TTY            ', 650, N'MTV            ', N'NCC3           ', NULL)
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'DPSD0220.TTY.ACM1   ', N'ACM Control 1', N'Dùng trong bệnh tim', N'Acenocoumarol', 720, N'Viên nén', N'TTY            ', 4500, N'NTP            ', N'NCC2           ', NULL)
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'duong1234           ', N'Đường ăn kiêng Sweet''n Low', N'Đường ăn kiêng Sweet''n Low chiết xuất từ thiên nhiên, không chứa calorie nhưng có độ ngọt cao gấp 10 lần đường thông thường. Mỗi gói được phân lường có độ ngọt tương đương 2 muỗng cà phê đường. ', N'Dextrose dinh dưỡng, canxi sacarin , kem Tartar và calcium silicate (chất chống đông cứng).', 20, N'Hộp 100 gói', N'TPCN           ', 50600, N'NTP            ', N'NCC2           ', N'duongankieng.jpeg                                 ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'Gluc1234            ', N'Sữa bột dành cho người tiểu đường Glucerna 850 g', N'Glucerna là sản phẩm dinh dưỡng đầy đủ và cân đối cho người đái tháo đường và tiền đái tháo đường với công thức tiên tiến và hệ dưỡng chất đặc chế Triple Care được chứng minh lâm sàng giúp kiểm soát tốt đường huyết, tăng cường sức khỏe tim mạch.

Hệ bột đường tiên tiến, với chỉ số đường huyết thấp và được tiêu hóa từ từ giúp bình ổn đường huyết.', N'Năng lượng INT, Chất đạm(Protein),Chất béo (Fat), Chất bột đường (Carbohydrate) , Chất xơ (Total dietary fiber), FOS, Polyols, Taurin, Carnitin, Inositol, Vitamin A (palmitat), Vitamin D3, Vitamin E, Vitamin K1, Vitamin C, Acid Folic, Vitamin B1, Vitamin B2, Vitamin B6, Vitamin B12, Niacin (tương đương), Acid Pantothenic, Biotin, Cholin, Natri, Kali, Clorid, Canxi, Phostpho,...', 50, N'Hộp 850g', N'TPCN           ', 804440, N'NTP            ', N'NCC2           ', N'Glucerna.jpeg                                     ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'lic1234             ', N'Viên uống giảm cân LIC', N'LIC giúp kiểm soát cân nặng và giảm cân hiệu quả, an toàn (*).

Cải thiện số đo các vùng eo, bụng, đùi trong thời gian sớm nhất.

Phòng ngừa các bệnh mãn tính do béo phì: tim mạch, tiểu đường, rối loạn nội tiết, hô hấp, xương khớp, ung thư…

(*) Sản phẩm đã qua thử nghiệm lâm sàng về hiệu quả. LIC giúp giảm cân an toàn, không mất nước và mệt mỏi.', N'Hoạt chất chính: Belaunja extract 300mg, Mangastin extract 100mg, Psilio husk powder 200mg.', 50, N'Hộp 60 viên', N'TPCN           ', 675000, N'NTP            ', N'NCC2           ', N'lic.jpeg                                          ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'Mass1234            ', N'Sữa Protein tăng cân Elite Labs Mass Muscle Gainer', N'Sữa tăng cân Mass Muscle Gainer vị chocolate dành riêng cho người muốn tăng cân tăng cơ nhanh', N'Protein, carb, calo và chất béo.', 50, N'Bịch 2,3kg', N'TPCN           ', 1605000, N'NTP            ', N'NCC2           ', N'mass.jpeg                                         ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'Momega1234          ', N'Momega For Men Dao Nordic Health', N'Hỗ Trợ Tim Mạch Nam Giới', N'Demafort', 30, N'Hộp 90 viên', N'TPCN           ', 150000, N'NTP            ', N'NCC2           ', N'momega.jpg                                        ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P00200H_3_l         ', N'
Viên đặt giảm đau- hạ sốt Efferalgan Suppo. 150mg', N'Thuốc dùng điều trị các chứng đau và/hoặc sốt như đau đầu, tình trạng như cúm, đau răng, nhức mỏi cơ. Dạng trình bày dành cho trẻ em cân nặng từ 8 đến 12 kg (khoảng 6 đến 24 tháng tuổi). (còn có pararacetamol ở các dạng bào chế khác dành cho trẻ em có cân nặng khác nhau. Xin hỏi ý kiến thầy thuốc hoặc dược sĩ của bạn.)', N' Paracetamol 150mg', 50, N'Hộp 10 viên', N'TTGD           ', 31500, N'NTP            ', NULL, N'P00200H_3_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P00262H_2_l         ', N'Thuốc giảm đau hạ sốt cho trẻ Hapacol 150mg', N'Hạ sốt, giảm đau cho trẻ trong các trường hợp: cảm, cúm, sốt xuất huyết, nhiễm khuẩn, nhiễm siêu vi, mọc răng, sau khi tiêm chủng, sau phẫu thuật,…
Thuốc dạng viên sủi với hương cam dịu nhẹ giúp trẻ dễ uống.', N'Paracetamol 150 mg', 50, N'Hộp 50 gói', N'TTGD           ', 50000, N'NTP            ', NULL, N'P00262H_2_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P00264H_3_l         ', N'Thuốc giảm đau, hạ sốt Hapacol 325mg', N'Điều trị các triệu chứng đau trong các trường hợp: đau đầu, đau nửa đầu, đau răng, đau nhức do cảm cúm, đau họng, đau nhức cơ xương, đau do viêm khớp, đau sau khi tiêm ngừa hay nhổ răng.', N'Thành phần: Paracetamol 325mg, tá dược.', 10, N'Hộp 100 viên', N'TTGD           ', 32200, N'NTP            ', N'NCC2           ', N'P00264H_3_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P00267H_2_I         ', N'Thuốc giảm đau hạ sốt cho trẻ Hapacol 80mg', N'Hạ sốt, giảm đau cho trẻ trong các trường hợp: cảm, cúm, sốt xuất huyết, nhiễm khuẩn, nhiễm siêu vi, mọc răng, sau khi tiêm chủng, sau phẫu thuật,…', N'Paracetamol 80 mg', 4, N'Hộp 24 gói', N'TTGD           ', 26750, N'NTP            ', N'NCC2           ', N'P00267H_2_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P00513C_3_l         ', N'Siro giảm đau- hạ sốt cho trẻ em Tylenol 60ml', N'Thuốc Giảm Đau- Hạ Sốt Siro Tylenol Children''S Susp. 60Ml có tác dụng: Hạ sốt, giảm đau nhức thông thường & khó chịu trong các trường hợp cảm lạnh, cúm, mọc răng, đau răng, đau đầu, đau tai, đau sau tiêm chủng, viêm họng.', N'Acetaminophen 80mg.', 50, N'Chai 60ml', N'TTGD           ', 28000, N'NTP            ', NULL, N'P00513C_3_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P00621H_3_l         ', N'Thuốc giảm đau- hạ sốt Effer-Paralmax 150', N'Thuốc giảm đau- hạ sốt Effer-Paralmax 150 điều trị các triệu chứng đau và/hoặc sốt từ nhẹ đến vừa ở trẻ em trong các trường hợp: Đau đầu, đau răng, đau họng, nhức mỏi cơ, cảm cúm, mọc răng, nhức răng...', N'Paracetamol 150 mg.', 4, N'Hộp 30 gói', N'TTGD           ', 27330, N'NTP            ', NULL, N'P00621H_3_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P00623H_1_l         ', N'Thuốc giảm đau- hạ sốt Effer-Paralmax extra', N'Thuốc giảm đau- hạ sốt Effer-Paralmax extra được dùng để điều trị nhiều bệnh như đau đầu, đau cơ, viêm khớp, đau lưng, đau răng, cảm lạnh và sốt. Nó làm giảm đau trong viêm khớp nhẹ nhưng không có tác dụng trên các nền tảng và viêm sưng khớp.', N' Paracetamol 650 mg.', 50, N'Hộp 20 viên', N'TTGD           ', 32000, N'NTP            ', NULL, N'P00623H_1_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P00663H_3_l         ', N'Thuốc Giảm đau- hạ sốt dạng bột sủi Efferalgan 80mg', N'Thuốc Giảm đau- hạ sốt Efferalgan 80mg dùng điều trị các chứng đau và/hoặc sốt như đau đầu, tình trạng như cúm, đau răng, nhức mỏi cơ.', N'Paracetamol 80mg.', 50, N'Hộp 60 gói', N'TTGD           ', 26000, N'NTP            ', NULL, N'P00663H_3_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P00791H_4_l         ', N'Kem đánh răng dược liệu Ngọc Châu', N'Kem đánh răng dược liệu Ngọc Châu chứa các dược liệu có tác dụng làm bền thành mạch, hoạt huyết, tăng cường nuôi dưỡng răng, lợi, góp phần chống tụt lợi, chảy máu chân răng, chống ê buốt, bảo vệ lợi giúp răng chắc khỏe từ gốc, thanh nhiệt, tiêu viêm, làm dịu niêm mạc miệng, ngăn ngừa viêm lợi, nhiệt miệng....', N'Hoạt chất chính: Hoa hòe, keo ong, cam thảo, bạc hà, đinh hương, tinh chất rễ cây Ratany, vỏ quả cau, muối tinh khiết.

', 12, N'Hộp 1 tuýp', N'CSRM           ', 31160, N'NTP            ', NULL, N'P00791H_4_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P00941C_3_l         ', N'Bàn chải Jordan Trẻ Em Buddy 5-10 tuổi', N'Bàn chải đánh răng cho bé từ 5-10 tuổi Jordan Buddy giúp bé vệ sinh răng miệng sạch sẽ, chải sạch mọi mảng bám và vụn thức ăn mà không gây tổn thương đến nướu. Kết hợp với loại kem đánh răng không gây kích ứng, an toàn, cha mẹ hoàn toàn yên tâm vệ sinh răng miệng cho bé.', N'Đầu lông bàn chải mềm, thân làm bằng nhựa.', 50, N'1 cái', N'CSRM           ', 20000, N'NTP            ', NULL, N'P00941C_3_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P00946C_1_l         ', N'Bàn chải Jordan Trẻ Em 6-9 Tuổi Step 3', N'Bàn chải có cấu trúc đặc biệt, phù hợp với răng miệng trẻ 6 - 8 tuổi, giúp quét sạch những mảng bám trên răng, khử mùi khó chịu và ngăn ngừa sâu răng cho trẻ hiệu quả mà không làm tổn hại đến răng nướu trẻ.

Phần lông bàn chải siêu mềm giúp chăm sóc nhẹ nhàng và chải sạch vùng răng và nướu nhạy cảm của bé ở gia đoạn bé đã thành thạo việc đánh răng

', N'Đầu lông bàn chải mềm, thân làm bằng nhựa.', 12, N'1 cái', N'CSRM           ', 23000, N'NTP            ', NULL, N'P00946C_1_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P01229H_1_l         ', N'Nước súc miệng Valentine Thái dương sát trùng răng, miệng và vòm họng của bé 250ml', N'Nước súc miệng Valentine Thái dương trẻ em 250ml được sản xuất từ các dược liệu tự nhiên, quý giá, có nguồn gốc rõ ràng và có nguồn gốc từ thảo dược thiên nhiên nhằm đảm bảo an toàn sức khỏe và công dụng đến khách hàng.', N'Hoạt chất chính: Aqua, Propylene Glycol, Glycerin, Poloxamer 407, Sodium Clorid, Allantoin, Citrus, Sinensis peel oil ( tinh dầu cam), Menthol, Sodium Fluoride, Mentha piperita oil ( Tinh dầu bạc hà),….', 12, N'1 chai', N'CSRM           ', 15000, N'NTP            ', NULL, N'P01229H_1_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P01664H_1_l         ', N'Chỉ nha khoa Oraltana
', N'Chỉ Nha Khoa Oraltana được làm từ sợi nilon đây là loại chỉ đơn có thể trượt dễ dàng qua những kẽ răng thậm chí với những kẽ răng hẹp và gần như không bị tưa.', N'Nhựa y tế , sáp , hương liệu

', 12, N'Hộp 1 cái', N'CSRM           ', 45000, N'NTP            ', NULL, N'P01664H_1_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P01665G_1_l         ', N'Tăm chỉ nha khoa tiệt trùng Oraltana túi 50 cái', N'Tăm chỉ nha khoa tiệt trùng Oraltana túi 50 cái', N'Được làm từ sợi ni lông bền chắc , an toàn 

Nhựa y tế , sáp , hương liệu', 10, N'1 gói', N'CSRM           ', 22300, N'NTP            ', NULL, N'P01665G_1_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P01756C_2_l         ', N'Bàn chải đánh răng Oral - B Stages 3 dành cho bé 5-7 tuổi', N'Bàn Chải Đánh Răng Oral-B Stages 3 với thiết kế đầu bàn chải là những sợi chỉ tơ mềm là sản phẩm thích hợp cho răng nướu nhạy cảm của các bé từ 5 đến 7 tuổi. Bên cạnh đó, thiết kế ngộ nghĩnh, dễ thương của bàn chải còn thu hút và tạo cảm hứng để các bé chăm chỉ đánh răng mỗi ngày.

Với đầu bản chải là những sợi chỉ tơ siêu mềm giúp chăm sóc nhẹ nhàng và chải sạch vùng răng và nướu nhạy cảm. Thân bàn chải được thiết kế thon vừa phù hợp với khuôn bàn tay các bé.

Nhiều thiết kế ngộ nghĩnh, dễ thương để các bé dễ dàng lựa chọn.', N'Được làm từ sợi ni lông bền chắc , an toàn. 

Nhựa y tế , sáp , hương liệu.

', 10, N'Hộp 50 cái', N'CSRM           ', 18730, N'NTP            ', NULL, N'P01756C_2_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'P02320H_1_l         ', N'Nước súc miệng diệt khuẩn Pierrot 15ml', N'Nước súc miệng diệt khuẩn Chlorexidine Pierrot được chế tạo đặc biệt với Chlorhexidine 0.12% có khả năng diệt vi khuẩn đường miệng giúp bảo vệ lợi, điều trị nha nhu, viêm nướu và Florua ngăn ngừa tích tụ mảng bám cao răng và chống sâu răng hiệu quả. Sản phẩm cho răng miệng thơm tho  với hương bạc hà tươi mát. ', N'Aqua, xylitol, alcohol, PEG-40 hydrogenated, castrol oil, glycrerin, aroma, sodium saccharin, menthol, triclosan, ', 50, N'Chai 15ml', N'CSRM           ', 11600, N'NTP            ', NULL, N'P02320H_1_l.jpeg                                  ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'sara1234            ', N'Thuốc giảm đau- hạ sốt Siro Sara 120mg', N'Thuốc giảm đau- hạ sốt Siro Sara 120mg có tác dụng: Hạ sốt, giảm đau nhức thông thường & khó chịu trong các trường hợp cảm lạnh, cúm, mọc răng, đau răng, đau đầu, đau tai, đau sau tiêm chủng, viêm họng.', N'Dung dịch Sorbitol, Xanthan Gum, Natri Saccharin, Natri dihydro phosphate, Màu đỏ Carmoisin, Hương dâu tây, Glycerin, Magnesi nhôm silicat, Simethicon emulsion 30% w/w, Natri methylparaben, Natri propylparaben, Acid phosphoric, Nước tinh khiết.', 60, N'Chai 60ml', N'TTGD           ', 23000, N'NTP            ', N'NCC2           ', N'sara.jpeg                                         ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'sara12345           ', N'Thuốc giảm đau- hạ sốt Siro Sara 250mg', N'Thuốc giảm đau- hạ sốt Siro Sara 250mg có tác dụng: Hạ sốt, giảm đau nhức thông thường & khó chịu trong các trường hợp cảm lạnh, cúm, mọc răng, đau răng, đau đầu, đau tai, đau sau tiêm chủng, viêm họng.', N'Dung dịch Sorbitol, Xanthan Gum, Natri Saccharin, Natri dihydro phosphate, Màu đỏ Carmoisin, Hương dâu tây, Glycerin, Magnesi nhôm silicat, Simethicon emulsion 30% w/w, Natri methylparaben, Natri propylparaben, Acid phosphoric, Nước tinh khiết.', 60, N'Chai 60ml', N'TTGD           ', 26000, N'NTP            ', N'NCC2           ', N'sara1.jpeg                                        ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'tangco1234          ', N'Sữa Tăng Cơ Prostar 100% Whey Protein Chocolate 454g', N'Prostar Whey 100% Protein giúp chắc cơ, tăng cơ, giảm mỡ bao gồm 25g Protein chất lượng cao trong một khẩu phần.

Hàm lượng BCAAs (6g) hỗ trợ tăng cơ, xây dựng và phục hồi cơ.

Cung cấp nguồn năng lượng và kiểm soát nhiều tiến trình phát triển của cơ thể.

Mùi vị cực ngon, dễ hòa tan trong nước.', N'Protein 25g (50%), Cholesterol 20 mg (7%), Sodium 30mg(1%), Calcium 20%,…', 20, N'Hộp ', N'TPCN           ', 635560, N'NTP            ', N'NCC2           ', N'tangco.jpeg                                       ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'tangco12345         ', N'Sữa Tăng Cơ Prostar 100% Whey Protein Vanilla 454g', N'Prostar Whey 100% Protein giúp chắc cơ, tăng cơ, giảm mỡ bao gồm 25g Protein chất lượng cao trong một khẩu phần.

Hàm lượng BCAAs (6g) hỗ trợ tăng cơ, xây dựng và phục hồi cơ.

Cung cấp nguồn năng lượng và kiểm soát nhiều tiến trình phát triển của cơ thể.

Mùi vị cực ngon, dễ hòa tan trong nước.', N'Protein 25g (50%), Cholesterol 20 mg (7%), Sodium 30mg(1%), Calcium 20%,…', 20, N'Hộp', N'TPCN           ', 635600, N'NTP            ', N'NCC2           ', N'suatangco.jpeg                                    ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [CongDung], [ThanhPhan], [SoLuongTon], [DangThuoc], [MaLoaiThuoc], [DonGia], [MaHangSX], [MaNhaCungCap], [UrlImage]) VALUES (N'tra1234             ', N'Trà thảo mộc giảm cân Lanui', N'Kích thích đốt cháy mỡ thừa giúp giảm cân, làm săn chắc cơ bắp

Cải thiện quá trình chuyển hóa lipid, giảm rối loạn lipit máu

Tăng cường tiêu hóa, giúp cơ thể đào thải độc tố

Tăng cường hoạt động trao đổi chất trong cơ thể

Phòng ngừa các bệnh liên quan đến béo phì như tim mạch, tiểu đường, thoái hóa khớp gối, suy giãn hệ tĩnh mạch chi dưới.', N'Hoạt chất chính: Lá Sen, Sơn Tra.', 20, N'Hộp 20 gói', N'TPCN           ', 100000, N'NTP            ', N'NCC2           ', N'tragiamcan.jpeg                                   ')
ALTER TABLE [dbo].[CHITIETPHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUXUAT_PHIEUXUAT] FOREIGN KEY([MaPhieuXuat])
REFERENCES [dbo].[PHIEUXUAT] ([MaPhieuXuat])
GO
ALTER TABLE [dbo].[CHITIETPHIEUXUAT] CHECK CONSTRAINT [FK_CHITIETPHIEUXUAT_PHIEUXUAT]
GO
ALTER TABLE [dbo].[CHITIETPHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUXUAT_THUOC] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[THUOC] ([MaThuoc])
GO
ALTER TABLE [dbo].[CHITIETPHIEUXUAT] CHECK CONSTRAINT [FK_CHITIETPHIEUXUAT_THUOC]
GO
ALTER TABLE [dbo].[PHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUXUAT_KHACHHANG] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KHACHHANG] ([MaKhachHang])
GO
ALTER TABLE [dbo].[PHIEUXUAT] CHECK CONSTRAINT [FK_PHIEUXUAT_KHACHHANG]
GO
ALTER TABLE [dbo].[THUOC]  WITH CHECK ADD  CONSTRAINT [FK_THUOC_HANGSANXUAT] FOREIGN KEY([MaHangSX])
REFERENCES [dbo].[HANGSANXUAT] ([MaHangSX])
GO
ALTER TABLE [dbo].[THUOC] CHECK CONSTRAINT [FK_THUOC_HANGSANXUAT]
GO
ALTER TABLE [dbo].[THUOC]  WITH CHECK ADD  CONSTRAINT [FK_THUOC_LOAITHUOC] FOREIGN KEY([MaLoaiThuoc])
REFERENCES [dbo].[LOAITHUOC] ([MaLoaiThuoc])
GO
ALTER TABLE [dbo].[THUOC] CHECK CONSTRAINT [FK_THUOC_LOAITHUOC]
GO
ALTER TABLE [dbo].[THUOC]  WITH CHECK ADD  CONSTRAINT [FK_THUOC_NHACUNGCAP] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NHACUNGCAP] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[THUOC] CHECK CONSTRAINT [FK_THUOC_NHACUNGCAP]
GO
USE [master]
GO
ALTER DATABASE [CNWeb_Pharmacy] SET  READ_WRITE 
GO
