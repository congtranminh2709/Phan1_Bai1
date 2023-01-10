USE [Bai4]
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 10/01/2023 10:57:32 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[ID_Luong] [int] NOT NULL,
	[Bac_Luong] [decimal](4, 2) NOT NULL,
	[Ten] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Luong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanSu]    Script Date: 10/01/2023 10:57:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanSu](
	[MaNV] [int] NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[QueQuan] [nvarchar](50) NULL,
	[GioiTinh] [int] NULL,
	[Ngay_BD] [datetime] NULL,
	[MaPB] [int] NULL,
	[ID_Luong] [int] NOT NULL,
 CONSTRAINT [PK_NhanSu] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 10/01/2023 10:57:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPB] [int] NOT NULL,
	[TenPB] [nvarchar](50) NULL,
	[MoTa] [nvarchar](50) NULL,
	[STT_PB] [int] NULL,
	[Parent_ID] [int] NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[NhanSu]  WITH CHECK ADD FOREIGN KEY([ID_Luong])
REFERENCES [dbo].[Luong] ([ID_Luong])
GO
ALTER TABLE [dbo].[NhanSu]  WITH CHECK ADD  CONSTRAINT [FK_NhanSu_PhongBan] FOREIGN KEY([MaPB])
REFERENCES [dbo].[PhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[NhanSu] CHECK CONSTRAINT [FK_NhanSu_PhongBan]
GO
