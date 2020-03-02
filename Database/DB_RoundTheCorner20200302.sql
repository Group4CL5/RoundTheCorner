USE [master]
GO

/****** Object:  Database [RoundTheCorner]    Script Date: 3/2/2020 3:49:32 PM ******/
CREATE DATABASE [RoundTheCorner]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RoundTheCorner', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\RoundTheCorner.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RoundTheCorner_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\RoundTheCorner_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
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

ALTER DATABASE [RoundTheCorner] SET  READ_WRITE 
GO

