﻿/*
Deployment script for RoundTheCorner

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "RoundTheCorner"
:setvar DefaultFilePrefix "RoundTheCorner"
:setvar DefaultDataPath "C:\Users\Owner\AppData\Local\Microsoft\VisualStudio\SSDT\"
:setvar DefaultLogPath "C:\Users\Owner\AppData\Local\Microsoft\VisualStudio\SSDT\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DROP Table if EXISTS [dbo].[TblCuisine]
drop table if exists [dbo].[TblMenuItem]
drop table if exists [dbo].[TblMenu]
drop table if exists [dbo].[TblMenuSection]
drop table if exists [dbo].[TblOrderItems]
drop table if exists [dbo].[TblOrders]
drop table if exists [dbo].[TblReview]
drop table if exists [dbo].[TblUser]
drop table if exists [dbo].[TblVendorEmployees]
drop table if exists [dbo].[TblVendorLocation]
drop table if exists [dbo].[TblVendors]
GO

GO
PRINT N'Creating [dbo].[TblCuisine]...';


GO
CREATE TABLE [dbo].[TblCuisine] (
    [CuisineID]   INT           IDENTITY (1, 1) NOT NULL,
    [CuisineName] NVARCHAR (25) NOT NULL,
    [VendorID]    INT           NOT NULL,
    [MenuID]      INT           NOT NULL,
    CONSTRAINT [PK_TblCuisine] PRIMARY KEY CLUSTERED ([CuisineID] ASC)
);


GO
PRINT N'Creating [dbo].[TblMenu]...';


GO
CREATE TABLE [dbo].[TblMenu] (
    [menuID]   INT IDENTITY (1, 1) NOT NULL,
    [vendorID] INT NOT NULL,
    [isActive] BIT NOT NULL,
    CONSTRAINT [PK_TblMenus] PRIMARY KEY CLUSTERED ([menuID] ASC)
);


GO
PRINT N'Creating [dbo].[TblMenuItem]...';


GO
CREATE TABLE [dbo].[TblMenuItem] (
    [itemID]        INT           IDENTITY (1, 1) NOT NULL,
    [menuID]        INT           NOT NULL,
    [itemName]      NVARCHAR (25) NOT NULL,
    [price]         MONEY         NOT NULL,
    [picture]       IMAGE         NULL,
    [description]   TEXT          NULL,
    [MenuSectionID] INT           NOT NULL,
    CONSTRAINT [PK_TblMenuItem] PRIMARY KEY CLUSTERED ([itemID] ASC)
);


GO
PRINT N'Creating [dbo].[TblMenuSection]...';


GO
CREATE TABLE [dbo].[TblMenuSection] (
    [MenuSectionID]   INT IDENTITY (1, 1) NOT NULL,
    [MenuID]          INT NOT NULL,
    [DisplayOrderNum] INT NOT NULL,
    CONSTRAINT [PK_TblMenuSection] PRIMARY KEY CLUSTERED ([MenuSectionID] ASC)
);


GO
PRINT N'Creating [dbo].[TblOrderItems]...';


GO
CREATE TABLE [dbo].[TblOrderItems] (
    [orderItemID] INT   NOT NULL,
    [menuItemId]  INT   NOT NULL,
    [price]       MONEY NOT NULL,
    CONSTRAINT [PK_TblOrderItems] PRIMARY KEY CLUSTERED ([menuItemId] ASC, [orderItemID] ASC)
);


GO
PRINT N'Creating [dbo].[TblOrders]...';


GO
CREATE TABLE [dbo].[TblOrders] (
    [orderID]   INT  IDENTITY (1, 1) NOT NULL,
    [userID]    INT  NOT NULL,
    [vendorID]  INT  NOT NULL,
    [orderDate] DATE NOT NULL,
    CONSTRAINT [PK_TblOrders] PRIMARY KEY CLUSTERED ([orderID] ASC)
);


GO
PRINT N'Creating [dbo].[TblReview]...';


GO
CREATE TABLE [dbo].[TblReview] (
    [ReviewID] INT           IDENTITY (1, 1) NOT NULL,
    [VendorID] INT           NOT NULL,
    [UserID]   INT           NOT NULL,
    [Rating]   INT           NOT NULL,
    [Subject]  NVARCHAR (25) NOT NULL,
    [Body]     NTEXT         NOT NULL,
    CONSTRAINT [PK_TblReview] PRIMARY KEY CLUSTERED ([ReviewID] ASC)
);


GO
PRINT N'Creating [dbo].[TblUser]...';


GO
CREATE TABLE [dbo].[TblUser] (
    [userID]      INT           IDENTITY (1, 1) NOT NULL,
    [firstName]   NVARCHAR (25) NOT NULL,
    [lastName]    NVARCHAR (25) NOT NULL,
    [DOB]         DATE          NULL,
    [email]       NVARCHAR (50) NOT NULL,
    [phone]       NVARCHAR (15) NULL,
    [password]    NVARCHAR (32) NOT NULL,
    [deactivated] BIT           NOT NULL,
    CONSTRAINT [PK_TblUser] PRIMARY KEY CLUSTERED ([userID] ASC)
);


GO
PRINT N'Creating [dbo].[TblVendorEmployees]...';


GO
CREATE TABLE [dbo].[TblVendorEmployees] (
    [id]       INT IDENTITY (1, 1) NOT NULL,
    [userID]   INT NOT NULL,
    [vendorID] INT NOT NULL,
    CONSTRAINT [PK_TblVendorEmployees] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[TblVendorLocation]...';


GO
CREATE TABLE [dbo].[TblVendorLocation] (
    [VendorID]  INT      NOT NULL,
    [datetime]  DATETIME NOT NULL,
    [locationX] INT      NOT NULL,
    [locationY] INT      NOT NULL,
    CONSTRAINT [PK_TblVendorLocation] PRIMARY KEY CLUSTERED ([VendorID] ASC, [datetime] ASC)
);


GO
PRINT N'Creating [dbo].[TblVendors]...';


GO
CREATE TABLE [dbo].[TblVendors] (
    [vendorID]       INT           IDENTITY (1, 1) NOT NULL,
    [OwnerID]        INT           NOT NULL,
    [CompanyName]    NVARCHAR (25) NOT NULL,
    [CompanyEmail]   NVARCHAR (25) NULL,
    [LicenseNumber]  INT           NOT NULL,
    [inspectionDate] DATE          NOT NULL,
    [bio]            NTEXT         NULL,
    [Website]        NVARCHAR (50) NULL,
    CONSTRAINT [PK_TblVendors] PRIMARY KEY CLUSTERED ([vendorID] ASC)
);


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
Begin
Insert into TblCuisine
(CuisineName, VendorID, MenuID)
Values 
('Dominican', 1, 1)
End
BEGIN
Insert into TblMenus
(vendorID, isActive)
values
(1, 1)
END
BEGIN
Insert into TblMenuItem
(itemName, menuID, MenuSectionID, [description], picture, price)
values
('cookie', 1, 1, 'cookie monster loves this', 'cookie.jpeg', 2)
END
BEGIN
Insert into TblMenuSection
(MenuID,DisplayOrderNum)
values
(1, 1)
END
BEGIN
Insert into TblOrder
(userID, vendorId, orderDate)
values
(1, 1, '2020-03-22')
END
BEGIN
Insert into TblOrderItems
(price,menuItemId)
values
(3, 1)
END
BEGIN
Insert into TblReview
(VendorID, UserID,Rating,[Subject],Body)
values
(1, 1,4,'It was not the best', 'I wish that they cooked the steak a little less')
END
BEGIN
Insert into TblUser
(firstName,lastName,phone,email,[password],DOB, deactivated)
values
('Conner','Hando','123456789','Conner.hando@student.com','loopmaker123','1997-09-11', 0)
END
BEGIN
Insert into TblVendors
(CompanyEmail, CompanyName, inspectionDate, LicenseNumber, OwnerID, Website, bio)
values
('company@email.com', 'TopCorp','2020-04-11',123456, 1,'TopCorp.com','Were the best and no one tops us' )
END
BEGIN
Insert into TblVendorEmployees
(userID,vendorID)
values
(1, 1)
END
BEGIN
Insert into TblVendorLocation
(vendorId, [datetime],locationX,locationY)
values
(1, '2020-06-23', 3, 5)
END
GO

GO
PRINT N'Update complete.';


GO
