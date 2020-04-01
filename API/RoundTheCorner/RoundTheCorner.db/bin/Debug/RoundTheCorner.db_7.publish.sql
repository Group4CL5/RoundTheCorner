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
:setvar DefaultDataPath "C:\Users\fsant\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\fsant\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

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
drop table if exists [dbo].[TblMenus]
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
PRINT N'Starting rebuilding table [dbo].[TblOrderItems]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_TblOrderItems] (
    [orderItemID] INT   NOT NULL,
    [menuItemId]  INT   NOT NULL,
    [price]       MONEY NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TblOrderItems1] PRIMARY KEY CLUSTERED ([menuItemId] ASC, [orderItemID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TblOrderItems])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_TblOrderItems] ([menuItemId], [orderItemID], [price])
        SELECT   [menuItemId],
                 [orderItemID],
                 [price]
        FROM     [dbo].[TblOrderItems]
        ORDER BY [menuItemId] ASC, [orderItemID] ASC;
    END

DROP TABLE [dbo].[TblOrderItems];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TblOrderItems]', N'TblOrderItems';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TblOrderItems1]', N'PK_TblOrderItems', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[TblCuisine]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_TblCuisine] (
    [CuisineID]   INT           IDENTITY (1, 1) NOT NULL,
    [CuisineName] NVARCHAR (25) NOT NULL,
    [VendorID]    INT           NOT NULL,
    [MenuID]      INT           NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TblCuisine1] PRIMARY KEY CLUSTERED ([CuisineID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TblCuisine])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblCuisine] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TblCuisine] ([CuisineID], [CuisineName], [VendorID], [MenuID])
        SELECT   [CuisineID],
                 [CuisineName],
                 [VendorID],
                 [MenuID]
        FROM     [dbo].[TblCuisine]
        ORDER BY [CuisineID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblCuisine] OFF;
    END

DROP TABLE [dbo].[TblCuisine];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TblCuisine]', N'TblCuisine';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TblCuisine1]', N'PK_TblCuisine', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[TblMenuItem]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_TblMenuItem] (
    [itemID]        INT           IDENTITY (1, 1) NOT NULL,
    [menuID]        INT           NOT NULL,
    [itemName]      NVARCHAR (25) NOT NULL,
    [price]         MONEY         NOT NULL,
    [picture]       IMAGE         NULL,
    [description]   TEXT          NULL,
    [MenuSectionID] INT           NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TblMenuItem1] PRIMARY KEY CLUSTERED ([itemID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TblMenuItem])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblMenuItem] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TblMenuItem] ([itemID], [menuID], [itemName], [price], [picture], [description], [MenuSectionID])
        SELECT   [itemID],
                 [menuID],
                 [itemName],
                 [price],
                 [picture],
                 [description],
                 [MenuSectionID]
        FROM     [dbo].[TblMenuItem]
        ORDER BY [itemID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblMenuItem] OFF;
    END

DROP TABLE [dbo].[TblMenuItem];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TblMenuItem]', N'TblMenuItem';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TblMenuItem1]', N'PK_TblMenuItem', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[TblMenus]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_TblMenus] (
    [menuID]   INT IDENTITY (1, 1) NOT NULL,
    [vendorID] INT NOT NULL,
    [isActive] BIT NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TblMenus1] PRIMARY KEY CLUSTERED ([menuID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TblMenus])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblMenus] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TblMenus] ([menuID], [vendorID], [isActive])
        SELECT   [menuID],
                 [vendorID],
                 [isActive]
        FROM     [dbo].[TblMenus]
        ORDER BY [menuID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblMenus] OFF;
    END

DROP TABLE [dbo].[TblMenus];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TblMenus]', N'TblMenus';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TblMenus1]', N'PK_TblMenus', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[TblMenuSection]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_TblMenuSection] (
    [MenuSectionID]   INT IDENTITY (1, 1) NOT NULL,
    [MenuID]          INT NOT NULL,
    [DisplayOrderNum] INT NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TblMenuSection1] PRIMARY KEY CLUSTERED ([MenuSectionID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TblMenuSection])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblMenuSection] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TblMenuSection] ([MenuSectionID], [MenuID], [DisplayOrderNum])
        SELECT   [MenuSectionID],
                 [MenuID],
                 [DisplayOrderNum]
        FROM     [dbo].[TblMenuSection]
        ORDER BY [MenuSectionID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblMenuSection] OFF;
    END

DROP TABLE [dbo].[TblMenuSection];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TblMenuSection]', N'TblMenuSection';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TblMenuSection1]', N'PK_TblMenuSection', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[TblOrders]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_TblOrders] (
    [orderID]   INT  IDENTITY (1, 1) NOT NULL,
    [userID]    INT  NOT NULL,
    [vendorID]  INT  NOT NULL,
    [orderDate] DATE NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TblOrders1] PRIMARY KEY CLUSTERED ([orderID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TblOrders])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblOrders] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TblOrders] ([orderID], [userID], [vendorID], [orderDate])
        SELECT   [orderID],
                 [userID],
                 [vendorID],
                 [orderDate]
        FROM     [dbo].[TblOrders]
        ORDER BY [orderID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblOrders] OFF;
    END

DROP TABLE [dbo].[TblOrders];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TblOrders]', N'TblOrders';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TblOrders1]', N'PK_TblOrders', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[TblReview]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_TblReview] (
    [ReviewID] INT           IDENTITY (1, 1) NOT NULL,
    [VendorID] INT           NOT NULL,
    [UserID]   INT           NOT NULL,
    [Rating]   INT           NOT NULL,
    [Subject]  NVARCHAR (25) NOT NULL,
    [Body]     NTEXT         NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TblReview1] PRIMARY KEY CLUSTERED ([ReviewID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TblReview])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblReview] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TblReview] ([ReviewID], [VendorID], [UserID], [Rating], [Subject], [Body])
        SELECT   [ReviewID],
                 [VendorID],
                 [UserID],
                 [Rating],
                 [Subject],
                 [Body]
        FROM     [dbo].[TblReview]
        ORDER BY [ReviewID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblReview] OFF;
    END

DROP TABLE [dbo].[TblReview];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TblReview]', N'TblReview';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TblReview1]', N'PK_TblReview', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[TblUser]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_TblUser] (
    [userID]      INT           IDENTITY (1, 1) NOT NULL,
    [firstName]   NVARCHAR (25) NOT NULL,
    [lastName]    NVARCHAR (25) NOT NULL,
    [DOB]         DATE          NULL,
    [email]       NVARCHAR (50) NOT NULL,
    [phone]       NVARCHAR (15) NULL,
    [password]    NVARCHAR (32) NOT NULL,
    [deactivated] BIT           NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TblUser1] PRIMARY KEY CLUSTERED ([userID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TblUser])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblUser] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TblUser] ([userID], [firstName], [lastName], [DOB], [email], [phone], [password], [deactivated])
        SELECT   [userID],
                 [firstName],
                 [lastName],
                 [DOB],
                 [email],
                 [phone],
                 [password],
                 [deactivated]
        FROM     [dbo].[TblUser]
        ORDER BY [userID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblUser] OFF;
    END

DROP TABLE [dbo].[TblUser];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TblUser]', N'TblUser';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TblUser1]', N'PK_TblUser', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[TblVendors]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_TblVendors] (
    [vendorID]       INT           IDENTITY (1, 1) NOT NULL,
    [OwnerID]        INT           NOT NULL,
    [CompanyName]    NVARCHAR (25) NOT NULL,
    [CompanyEmail]   NVARCHAR (25) NULL,
    [LicenseNumber]  INT           NOT NULL,
    [inspectionDate] DATE          NOT NULL,
    [bio]            NTEXT         NULL,
    [Website]        NVARCHAR (50) NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TblVendors1] PRIMARY KEY CLUSTERED ([vendorID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TblVendors])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblVendors] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TblVendors] ([vendorID], [OwnerID], [CompanyName], [CompanyEmail], [LicenseNumber], [inspectionDate], [bio], [Website])
        SELECT   [vendorID],
                 [OwnerID],
                 [CompanyName],
                 [CompanyEmail],
                 [LicenseNumber],
                 [inspectionDate],
                 [bio],
                 [Website]
        FROM     [dbo].[TblVendors]
        ORDER BY [vendorID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TblVendors] OFF;
    END

DROP TABLE [dbo].[TblVendors];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TblVendors]', N'TblVendors';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TblVendors1]', N'PK_TblVendors', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


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
Insert into [dbo].[TblCuisine]
(CuisineID, CuisineName, VendorID, MenuID)
Values 
(1, 'Dominican', 1, 1)
End
BEGIN
Insert into TblMenu
(menuID, vendorID, isActive)
values
(1,  1, 1)
END
BEGIN
Insert into TblMenuItem
(itemID, itemName, menuID, MenuSectionID, [description], picture, price)
values
(1, 'cookie', 1, 1, 'cookie monster loves this', 'cookie.jpeg', 2)
END
BEGIN
Insert into TblMenuSection
(MenuSectionID,MenuID,DisplayOrderNum)
values
(1, 1, 1)
END
BEGIN
Insert into TblOrder
(orderID, userID, vendorId, orderDate)
values
(1,  1, 1, '2020-03-22')
END
BEGIN
Insert into TblOrderItems
(orderItemID,price,menuItemId)
values
(1, 3, 1)
END
BEGIN
Insert into TblReview
(ReviewID, VendorID, UserID,Rating,[Subject],Body)
values
(1, 1, 1,4,'It was not the best', 'I wish that they cooked the steak a little less')
END
BEGIN
Insert into TblUser
(userID,firstName,lastName,phone,email,[password],DOB, deactivated)
values
(1, 'Conner','Hando','123456789','Conner.hando@student.com','loopmaker123','1997-09-11', 0)
END
BEGIN
Insert into TblVendors
(vendorID, CompanyEmail, CompanyName, inspectionDate, LicenseNumber, OwnerID, Website, bio)
values
(1, 'company@email.com', 'TopCorp','2020-04-11',123456, 1,'TopCorp.com','Were the best and no one tops us' )
END
BEGIN
Insert into TblVendorEmployees
(id,userID,vendorID)
values
(1, 1, 1)
END
BEGIN
Insert into TblVendorLocation
(datetime,locationX,locationY)
values
('2020-06-23', 3, 5)
END
GO

GO
PRINT N'Update complete.';


GO