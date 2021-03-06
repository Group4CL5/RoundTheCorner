USE [master]
GO
/****** Object:  Database [RoundTheCorner]    Script Date: 2/20/2020 11:43:47 AM ******/
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
/****** Object:  Table [dbo].[EmployeeType]    Script Date: 2/20/2020 11:43:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeType](
	[employeeTypeID] [int] IDENTITY(1,1) NOT NULL,
	[vendorID] [int] NOT NULL,
	[name] [nvarchar](15) NOT NULL,
	[typeOfEmployee] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_EmployeeType] PRIMARY KEY CLUSTERED 
(
	[employeeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 2/20/2020 11:43:47 AM ******/
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
 CONSTRAINT [PK_menuItem] PRIMARY KEY CLUSTERED 
(
	[itemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 2/20/2020 11:43:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[menuID] [int] IDENTITY(1,1) NOT NULL,
	[vendorID] [int] NOT NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[menuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 2/20/2020 11:43:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[orderItemID] [int] NOT NULL,
	[menuItemId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2/20/2020 11:43:47 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 2/20/2020 11:43:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](25) NOT NULL,
	[lastName] [nvarchar](25) NOT NULL,
	[DOB] [date] NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](15) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorEmployees]    Script Date: 2/20/2020 11:43:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorEmployees](
	[userID] [int] NOT NULL,
	[vendorID] [int] NOT NULL,
	[employeeTypeId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorLocation]    Script Date: 2/20/2020 11:43:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorLocation](
	[truckID] [int] NOT NULL,
	[date] [date] NOT NULL,
	[locationHistory] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 2/20/2020 11:43:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[vendorID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](25) NOT NULL,
	[inspectionDate] [date] NOT NULL,
	[bio] [ntext] NULL,
	[isTruck] [bit] NOT NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[vendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeType]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeType_Vendors] FOREIGN KEY([employeeTypeID])
REFERENCES [dbo].[Vendors] ([vendorID])
GO
ALTER TABLE [dbo].[EmployeeType] CHECK CONSTRAINT [FK_EmployeeType_Vendors]
GO
ALTER TABLE [dbo].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_MenuItem_Menus] FOREIGN KEY([menuID])
REFERENCES [dbo].[Menus] ([menuID])
GO
ALTER TABLE [dbo].[MenuItem] CHECK CONSTRAINT [FK_MenuItem_Menus]
GO
ALTER TABLE [dbo].[Menus]  WITH CHECK ADD  CONSTRAINT [FK_Menus_Vendors] FOREIGN KEY([vendorID])
REFERENCES [dbo].[Vendors] ([vendorID])
GO
ALTER TABLE [dbo].[Menus] CHECK CONSTRAINT [FK_Menus_Vendors]
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
ALTER TABLE [dbo].[VendorEmployees]  WITH CHECK ADD  CONSTRAINT [FK_VendorEmployees_EmployeeType] FOREIGN KEY([employeeTypeId])
REFERENCES [dbo].[EmployeeType] ([employeeTypeID])
GO
ALTER TABLE [dbo].[VendorEmployees] CHECK CONSTRAINT [FK_VendorEmployees_EmployeeType]
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
ALTER TABLE [dbo].[VendorLocation]  WITH CHECK ADD  CONSTRAINT [FK_VendorLocation_Vendors] FOREIGN KEY([truckID])
REFERENCES [dbo].[Vendors] ([vendorID])
GO
ALTER TABLE [dbo].[VendorLocation] CHECK CONSTRAINT [FK_VendorLocation_Vendors]
GO
USE [master]
GO
ALTER DATABASE [RoundTheCorner] SET  READ_WRITE 
GO
