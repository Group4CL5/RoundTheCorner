USE [master]
GO
/****** Object:  Database [RoundTheCorner]    Script Date: 3/2/2020 4:02:19 PM ******/
CREATE DATABASE [RoundTheCorner]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RoundTheCorner', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\RoundTheCorner.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RoundTheCorner_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\RoundTheCorner_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RoundTheCorner] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RoundTheCorner].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RoundTheCorner] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RoundTheCorner] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RoundTheCorner] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RoundTheCorner] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RoundTheCorner] SET ARITHABORT OFF 
GO
ALTER DATABASE [RoundTheCorner] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RoundTheCorner] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RoundTheCorner] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RoundTheCorner] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RoundTheCorner] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RoundTheCorner] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RoundTheCorner] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RoundTheCorner] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RoundTheCorner] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RoundTheCorner] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RoundTheCorner] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RoundTheCorner] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RoundTheCorner] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RoundTheCorner] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RoundTheCorner] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RoundTheCorner] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RoundTheCorner] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RoundTheCorner] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RoundTheCorner] SET  MULTI_USER 
GO
ALTER DATABASE [RoundTheCorner] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RoundTheCorner] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RoundTheCorner] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RoundTheCorner] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RoundTheCorner] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RoundTheCorner] SET QUERY_STORE = OFF
GO
USE [RoundTheCorner]
GO
/****** Object:  Table [dbo].[Cuisine]    Script Date: 3/2/2020 4:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuisine](
	[CuisineID] [int] IDENTITY(1,1) NOT NULL,
	[CuisineName] [nvarchar](25) NOT NULL,
	[VendorID] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CuisineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 3/2/2020 4:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItem](
	[itemID] [int] IDENTITY(1,1) NOT NULL,
	[menuID] [int] NOT NULL,
	[itemName] [nvarchar](25) NOT NULL,
	[price] [money] NOT NULL,
	[picture] [image] NULL,
	[description] [text] NULL,
	[MenuSectionID] [int] NOT NULL,
 CONSTRAINT [PK_menuItem] PRIMARY KEY CLUSTERED 
(
	[itemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 3/2/2020 4:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[menuID] [int] IDENTITY(1,1) NOT NULL,
	[vendorID] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[menuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuSection]    Script Date: 3/2/2020 4:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuSection](
	[MenuSectionID] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [int] NOT NULL,
	[DisplayOrderNum] [int] NOT NULL,
 CONSTRAINT [PK_MenuSection] PRIMARY KEY CLUSTERED 
(
	[MenuSectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 3/2/2020 4:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[orderItemID] [int] NOT NULL,
	[menuItemId] [int] NOT NULL,
	[price] [money] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3/2/2020 4:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[orderID] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NOT NULL,
	[vendorID] [int] NOT NULL,
	[orderDate] [date] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 3/2/2020 4:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[VendorID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[Subject] [nvarchar](25) NOT NULL,
	[Body] [ntext] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/2/2020 4:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](25) NOT NULL,
	[lastName] [nvarchar](25) NOT NULL,
	[DOB] [date] NULL,
	[email] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](15) NULL,
	[password] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorEmployees]    Script Date: 3/2/2020 4:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorEmployees](
	[userID] [int] NOT NULL,
	[vendorID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorLocation]    Script Date: 3/2/2020 4:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorLocation](
	[VendorID] [int] NOT NULL,
	[datetime] [datetime] NOT NULL,
	[locationX] [int] NOT NULL,
	[locationY] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 3/2/2020 4:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[vendorID] [int] IDENTITY(1,1) NOT NULL,
	[OwnerID] [int] NOT NULL,
	[CompanyName] [nvarchar](25) NOT NULL,
	[CompanyEmail] [nvarchar](25) NULL,
	[LicenseNumber] [int] NOT NULL,
	[inspectionDate] [date] NOT NULL,
	[bio] [ntext] NULL,
	[Website] [nvarchar](50) NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[vendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuisine]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([vendorID])
GO
ALTER TABLE [dbo].[Cuisine] CHECK CONSTRAINT [FK_Categories_Categories]
GO
ALTER TABLE [dbo].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_MenuItem_Menus] FOREIGN KEY([MenuSectionID])
REFERENCES [dbo].[MenuSection] ([MenuSectionID])
GO
ALTER TABLE [dbo].[MenuItem] CHECK CONSTRAINT [FK_MenuItem_Menus]
GO
ALTER TABLE [dbo].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_MenuItem_Menus1] FOREIGN KEY([menuID])
REFERENCES [dbo].[Menus] ([menuID])
GO
ALTER TABLE [dbo].[MenuItem] CHECK CONSTRAINT [FK_MenuItem_Menus1]
GO
ALTER TABLE [dbo].[Menus]  WITH CHECK ADD  CONSTRAINT [FK_Menus_Vendors] FOREIGN KEY([vendorID])
REFERENCES [dbo].[Vendors] ([vendorID])
GO
ALTER TABLE [dbo].[Menus] CHECK CONSTRAINT [FK_Menus_Vendors]
GO
ALTER TABLE [dbo].[MenuSection]  WITH CHECK ADD  CONSTRAINT [FK_MenuSection_Menus] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menus] ([menuID])
GO
ALTER TABLE [dbo].[MenuSection] CHECK CONSTRAINT [FK_MenuSection_Menus]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_MenuItem] FOREIGN KEY([menuItemId])
REFERENCES [dbo].[MenuItem] ([itemID])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_MenuItem]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY([orderItemID])
REFERENCES [dbo].[Orders] ([orderID])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_User] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([userID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_User]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Vendors] FOREIGN KEY([vendorID])
REFERENCES [dbo].[Vendors] ([vendorID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Vendors]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([userID])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_User]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Vendors] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([vendorID])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Vendors]
GO
ALTER TABLE [dbo].[VendorEmployees]  WITH CHECK ADD  CONSTRAINT [FK_VendorEmployees_User] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([userID])
GO
ALTER TABLE [dbo].[VendorEmployees] CHECK CONSTRAINT [FK_VendorEmployees_User]
GO
ALTER TABLE [dbo].[VendorEmployees]  WITH CHECK ADD  CONSTRAINT [FK_VendorEmployees_Vendors] FOREIGN KEY([vendorID])
REFERENCES [dbo].[Vendors] ([vendorID])
GO
ALTER TABLE [dbo].[VendorEmployees] CHECK CONSTRAINT [FK_VendorEmployees_Vendors]
GO
ALTER TABLE [dbo].[VendorLocation]  WITH CHECK ADD  CONSTRAINT [FK_VendorLocation_Vendors] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([vendorID])
GO
ALTER TABLE [dbo].[VendorLocation] CHECK CONSTRAINT [FK_VendorLocation_Vendors]
GO
ALTER TABLE [dbo].[Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Vendors_User] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[User] ([userID])
GO
ALTER TABLE [dbo].[Vendors] CHECK CONSTRAINT [FK_Vendors_User]
GO
USE [master]
GO
ALTER DATABASE [RoundTheCorner] SET  READ_WRITE 
GO
