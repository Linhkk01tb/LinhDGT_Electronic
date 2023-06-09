USE [master]
GO
/****** Object:  Database [linhdgt_electronic]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE DATABASE [linhdgt_electronic]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'linhdgt_electronic', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\linhdgt_electronic.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'linhdgt_electronic_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\linhdgt_electronic_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [linhdgt_electronic] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [linhdgt_electronic].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [linhdgt_electronic] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET ARITHABORT OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [linhdgt_electronic] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [linhdgt_electronic] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET  DISABLE_BROKER 
GO
ALTER DATABASE [linhdgt_electronic] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [linhdgt_electronic] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [linhdgt_electronic] SET  MULTI_USER 
GO
ALTER DATABASE [linhdgt_electronic] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [linhdgt_electronic] SET DB_CHAINING OFF 
GO
ALTER DATABASE [linhdgt_electronic] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [linhdgt_electronic] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [linhdgt_electronic] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [linhdgt_electronic] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [linhdgt_electronic] SET QUERY_STORE = OFF
GO
USE [linhdgt_electronic]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[anhsanpham]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[anhsanpham](
	[AnhID] [int] IDENTITY(1,1) NOT NULL,
	[AnhName] [nvarchar](max) NULL,
	[AnhStatus] [bit] NOT NULL,
	[SanPhamID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.anhsanpham] PRIMARY KEY CLUSTERED 
(
	[AnhID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[FullName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitietdonhang]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitietdonhang](
	[ChiTietDonHangID] [int] IDENTITY(1,1) NOT NULL,
	[DonHangID] [int] NOT NULL,
	[SoLuongMua] [int] NOT NULL,
	[ThanhTien] [float] NOT NULL,
	[SanPhamID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.chitietdonhang] PRIMARY KEY CLUSTERED 
(
	[ChiTietDonHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[danhmuc]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[danhmuc](
	[DanhMucID] [int] IDENTITY(1,1) NOT NULL,
	[DanhMucName] [nvarchar](max) NOT NULL,
	[DanhMucDescription] [nvarchar](max) NULL,
	[DanhMucStatus] [int] NOT NULL,
 CONSTRAINT [PK_dbo.danhmuc] PRIMARY KEY CLUSTERED 
(
	[DanhMucID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[donhang]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[donhang](
	[DonHangID] [int] IDENTITY(1,1) NOT NULL,
	[DonHangReceiverName] [nvarchar](max) NOT NULL,
	[DonHangReceiverPhoneNumber] [nvarchar](max) NOT NULL,
	[DonHangReceiverAddress] [nvarchar](max) NOT NULL,
	[DonHangTotalPayment] [float] NOT NULL,
	[DonHangStatus] [int] NOT NULL,
	[DonHangCreatedDate] [datetime] NOT NULL,
	[DonHangModifiedDate] [datetime] NOT NULL,
	[DonHangCode] [nvarchar](max) NULL,
	[DonHangReceiverEmail] [nvarchar](max) NOT NULL,
	[DonHangPayment] [int] NOT NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.donhang] PRIMARY KEY CLUSTERED 
(
	[DonHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhanvien]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhanvien](
	[NhanVienID] [int] IDENTITY(1,1) NOT NULL,
	[NhanVienName] [nvarchar](max) NOT NULL,
	[NhanVienBirth] [datetime] NOT NULL,
	[NhanVienGender] [int] NOT NULL,
	[NhanVienAddress] [nvarchar](max) NULL,
	[NhanVienEmail] [nvarchar](max) NOT NULL,
	[NhanVienPhoneNumber] [nvarchar](max) NOT NULL,
	[NhanVienWorkingDate] [int] NOT NULL,
	[NhanVienSalary] [float] NOT NULL,
	[NhanVienStatus] [int] NOT NULL,
 CONSTRAINT [PK_dbo.nhanvien] PRIMARY KEY CLUSTERED 
(
	[NhanVienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanpham](
	[SanPhamID] [int] IDENTITY(1,1) NOT NULL,
	[SanPhamName] [nvarchar](max) NOT NULL,
	[SanPhamImage] [nvarchar](max) NOT NULL,
	[SanPhamProducedYear] [int] NOT NULL,
	[SanPhamDescription] [nvarchar](max) NULL,
	[DanhMucID] [int] NOT NULL,
	[ThuongHieuID] [int] NOT NULL,
	[SanPhamQuantity] [int] NOT NULL,
	[SanPhamUnitPrice] [float] NOT NULL,
	[SanPhamStatus] [int] NOT NULL,
	[SanPhamSellQuantity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.sanpham] PRIMARY KEY CLUSTERED 
(
	[SanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thuonghieu]    Script Date: 5/13/2023 8:23:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thuonghieu](
	[ThuongHieuID] [int] IDENTITY(1,1) NOT NULL,
	[ThuongHieuName] [nvarchar](max) NOT NULL,
	[ThuongHieuDescription] [nvarchar](max) NULL,
	[ThuongHieuStatus] [int] NOT NULL,
 CONSTRAINT [PK_dbo.thuonghieu] PRIMARY KEY CLUSTERED 
(
	[ThuongHieuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_SanPhamID]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_SanPhamID] ON [dbo].[anhsanpham]
(
	[SanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DonHangID]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_DonHangID] ON [dbo].[chitietdonhang]
(
	[DonHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SanPhamID]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_SanPhamID] ON [dbo].[chitietdonhang]
(
	[SanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DanhMucID]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_DanhMucID] ON [dbo].[sanpham]
(
	[DanhMucID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ThuongHieuID]    Script Date: 5/13/2023 8:23:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_ThuongHieuID] ON [dbo].[sanpham]
(
	[ThuongHieuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[donhang] ADD  DEFAULT ('') FOR [DonHangReceiverEmail]
GO
ALTER TABLE [dbo].[donhang] ADD  DEFAULT ((0)) FOR [DonHangPayment]
GO
ALTER TABLE [dbo].[sanpham] ADD  DEFAULT ((0)) FOR [SanPhamSellQuantity]
GO
ALTER TABLE [dbo].[anhsanpham]  WITH CHECK ADD  CONSTRAINT [FK_dbo.anhsanpham_dbo.sanpham_SanPhamID] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[sanpham] ([SanPhamID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[anhsanpham] CHECK CONSTRAINT [FK_dbo.anhsanpham_dbo.sanpham_SanPhamID]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_dbo.chitietdonhang_dbo.donhang_DonHangID] FOREIGN KEY([DonHangID])
REFERENCES [dbo].[donhang] ([DonHangID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chitietdonhang] CHECK CONSTRAINT [FK_dbo.chitietdonhang_dbo.donhang_DonHangID]
GO
ALTER TABLE [dbo].[chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_dbo.chitietdonhang_dbo.sanpham_SanPhamID] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[sanpham] ([SanPhamID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chitietdonhang] CHECK CONSTRAINT [FK_dbo.chitietdonhang_dbo.sanpham_SanPhamID]
GO
ALTER TABLE [dbo].[sanpham]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.sanpham_dbo.danhmuc_DanhMucID] FOREIGN KEY([DanhMucID])
REFERENCES [dbo].[danhmuc] ([DanhMucID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sanpham] CHECK CONSTRAINT [FK_dbo.sanpham_dbo.danhmuc_DanhMucID]
GO
ALTER TABLE [dbo].[sanpham]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.sanpham_dbo.thuonghieu_ThuongHieuID] FOREIGN KEY([ThuongHieuID])
REFERENCES [dbo].[thuonghieu] ([ThuongHieuID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sanpham] CHECK CONSTRAINT [FK_dbo.sanpham_dbo.thuonghieu_ThuongHieuID]
GO
USE [master]
GO
ALTER DATABASE [linhdgt_electronic] SET  READ_WRITE 
GO
