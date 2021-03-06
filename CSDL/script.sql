USE [QL_SanBongDaMini]
GO
/****** Object:  Table [dbo].[DoiBong]    Script Date: 9/16/2021 7:25:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DoiBong](
	[maDoiBong] [int] NOT NULL,
	[maSuKien] [int] NOT NULL,
	[tenDoiBong] [nvarchar](100) NULL,
	[SDTDoiDaiDien] [varchar](11) NULL,
	[tenNguoiDaiDien] [nvarchar](36) NULL,
	[emailNguoiDaiDien] [varchar](36) NULL,
	[hinhDoiBong] [nvarchar](500) NULL,
	[tinhTrang] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[maDoiBong] ASC,
	[maSuKien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SuKien]    Script Date: 9/16/2021 7:25:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuKien](
	[maSuKien] [int] IDENTITY(1,1) NOT NULL,
	[tenSuKien] [nvarchar](100) NULL,
	[ngayBatDau] [date] NULL,
	[soDoiThamGia] [int] NULL,
	[soBangDau] [int] NULL,
	[soDoiVongKnockout] [int] NULL,
	[soLuongNguoiMoiDoi] [int] NULL,
	[maNguoiDung] [int] NULL,
	[tinhTrang] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[maSuKien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


