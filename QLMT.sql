USE [QLMT]
GO
/****** Object:  Table [dbo].[Hang]    Script Date: 12/20/2021 5:52:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hang](
	[Mahang] [nvarchar](50) NOT NULL,
	[Tenhang] [nvarchar](50) NULL,
	[Soluong] [int] NULL,
	[Gianhap] [float] NULL,
	[Giaban] [int] NULL,
	[NCC] [nvarchar](50) NULL,
 CONSTRAINT [PK_Hang] PRIMARY KEY CLUSTERED 
(
	[Mahang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hoadon]    Script Date: 12/20/2021 5:52:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoadon](
	[Mahd] [nvarchar](50) NOT NULL,
	[Manv] [nvarchar](50) NULL,
	[Ngayban] [nvarchar](50) NULL,
	[Makh] [nvarchar](50) NULL,
	[Mahang] [nvarchar](50) NULL,
	[Soluong] [int] NULL,
	[Dongia] [int] NULL,
	[Tongtien] [float] NULL,
 CONSTRAINT [PK_Hoadon] PRIMARY KEY CLUSTERED 
(
	[Mahd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Khachhang]    Script Date: 12/20/2021 5:52:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khachhang](
	[Makh] [nvarchar](50) NOT NULL,
	[Tenkh] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_Khachhang] PRIMARY KEY CLUSTERED 
(
	[Makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nguoidung]    Script Date: 12/20/2021 5:52:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nguoidung](
	[Taikhoan] [nvarchar](50) NOT NULL,
	[Matkhau] [nvarchar](50) NULL,
 CONSTRAINT [PK_Nguoidung] PRIMARY KEY CLUSTERED 
(
	[Taikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nhacungcap]    Script Date: 12/20/2021 5:52:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhacungcap](
	[Mancc] [nvarchar](50) NOT NULL,
	[Tenncc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Nhacungcap] PRIMARY KEY CLUSTERED 
(
	[Mancc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nhanvien]    Script Date: 12/20/2021 5:52:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhanvien](
	[Manv] [nvarchar](50) NOT NULL,
	[Tennv] [nvarchar](50) NULL,
	[GT] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[Ngaysinh] [nvarchar](50) NULL,
 CONSTRAINT [PK_Nhanvien] PRIMARY KEY CLUSTERED 
(
	[Manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Hang] ([Mahang], [Tenhang], [Soluong], [Gianhap], [Giaban], [NCC]) VALUES (N'H01', N'nitro5', 3, 17000000, 21000000, N'ACER')
INSERT [dbo].[Hang] ([Mahang], [Tenhang], [Soluong], [Gianhap], [Giaban], [NCC]) VALUES (N'H02', N'Dell 1030', 2, 10000000, 13000000, N'DELL')
INSERT [dbo].[Hang] ([Mahang], [Tenhang], [Soluong], [Gianhap], [Giaban], [NCC]) VALUES (N'H03', N'ASUS 2021', 2, 2000000, 25000000, N'ASUS')
INSERT [dbo].[Hoadon] ([Mahd], [Manv], [Ngayban], [Makh], [Mahang], [Soluong], [Dongia], [Tongtien]) VALUES (N'HD01', N'NV01', N'12/05/2001', N'KH02', N'H02', 2, 13000000, 26000000)
INSERT [dbo].[Hoadon] ([Mahd], [Manv], [Ngayban], [Makh], [Mahang], [Soluong], [Dongia], [Tongtien]) VALUES (N'HD02', N'NV02', N'12/05/2021', N'KH03', N'H03', 1, 25000000, 25000000)
INSERT [dbo].[Hoadon] ([Mahd], [Manv], [Ngayban], [Makh], [Mahang], [Soluong], [Dongia], [Tongtien]) VALUES (N'HD03', N'NV01', N'16/10/2021', N'KH03', N'H02', 2, 13000000, 26000000)
INSERT [dbo].[Khachhang] ([Makh], [Tenkh], [Diachi], [SDT]) VALUES (N'KH01', N'NVA', N'HN', N'(+84) 12-3456789')
INSERT [dbo].[Khachhang] ([Makh], [Tenkh], [Diachi], [SDT]) VALUES (N'KH02', N'NVB', N'HN', N'(+84) 34-5148456')
INSERT [dbo].[Khachhang] ([Makh], [Tenkh], [Diachi], [SDT]) VALUES (N'KH03', N'NVC', N'HN', N'(+84) 11-5465123')
INSERT [dbo].[Nguoidung] ([Taikhoan], [Matkhau]) VALUES (N'a', N'123')
INSERT [dbo].[Nguoidung] ([Taikhoan], [Matkhau]) VALUES (N'admin', N'123')
INSERT [dbo].[Nhacungcap] ([Mancc], [Tenncc]) VALUES (N'NCC01', N'ACER')
INSERT [dbo].[Nhacungcap] ([Mancc], [Tenncc]) VALUES (N'NCC02', N'DELL')
INSERT [dbo].[Nhacungcap] ([Mancc], [Tenncc]) VALUES (N'NCC03', N'APPLE')
INSERT [dbo].[Nhacungcap] ([Mancc], [Tenncc]) VALUES (N'NCC04', N'LENOVO')
INSERT [dbo].[Nhacungcap] ([Mancc], [Tenncc]) VALUES (N'NCC05', N'HP')
INSERT [dbo].[Nhacungcap] ([Mancc], [Tenncc]) VALUES (N'NCC06', N'ASUS')
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [GT], [Diachi], [SDT], [Ngaysinh]) VALUES (N'NV01', N'A', N'Nữ', N'HN', N'(+84) 33-3502583', N'12/05/2001')
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [GT], [Diachi], [SDT], [Ngaysinh]) VALUES (N'NV02', N'B', N'Nam', N'HN', N'(+84) 12-0520011', N'11/09/2011')
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [GT], [Diachi], [SDT], [Ngaysinh]) VALUES (N'NV03', N'C', N'Nam', N'HN', N'(+84) 32-4561123', N'11/12/2012')
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [GT], [Diachi], [SDT], [Ngaysinh]) VALUES (N'NV04', N'D', N'Nam', N'HN', N'(+84) 13-1112111', N'12/03/2000')
