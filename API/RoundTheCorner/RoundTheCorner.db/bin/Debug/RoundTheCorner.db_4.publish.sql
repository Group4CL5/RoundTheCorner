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
PRINT N'Creating [dbo].[TblCuisine]...';


GO
CREATE TABLE [dbo].[TblCuisine] (
    [CuisineID]   INT           IDENTITY (1, 1) NOT NULL,
    [CuisineName] NVARCHAR (25) NOT NULL,
    [VendorID]    INT           NOT NULL,
    [MenuID]      INT           NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CuisineID] ASC)
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
    CONSTRAINT [PK_menuItem] PRIMARY KEY CLUSTERED ([itemID] ASC)
);


GO
PRINT N'Creating [dbo].[TblMenus]...';


GO
CREATE TABLE [dbo].[TblMenus] (
    [menuID]   INT IDENTITY (1, 1) NOT NULL,
    [vendorID] INT NOT NULL,
    [isActive] BIT NOT NULL,
    CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED ([menuID] ASC)
);


GO
PRINT N'Creating [dbo].[TblMenuSection]...';


GO
CREATE TABLE [dbo].[TblMenuSection] (
    [MenuSectionID]   INT IDENTITY (1, 1) NOT NULL,
    [MenuID]          INT NOT NULL,
    [DisplayOrderNum] INT NOT NULL,
    CONSTRAINT [PK_MenuSection] PRIMARY KEY CLUSTERED ([MenuSectionID] ASC)
);


GO
PRINT N'Creating [dbo].[TblOrderItems]...';


GO
CREATE TABLE [dbo].[TblOrderItems] (
    [orderItemID] INT   NOT NULL,
    [menuItemId]  INT   NOT NULL,
    [price]       MONEY NOT NULL,
    CONSTRAINT [PK_TblOrderItems] PRIMARY KEY CLUSTERED ([orderItemID] ASC, [menuItemId] ASC)
);


GO
PRINT N'Creating [dbo].[TblOrders]...';


GO
CREATE TABLE [dbo].[TblOrders] (
    [orderID]   INT  IDENTITY (1, 1) NOT NULL,
    [userID]    INT  NOT NULL,
    [vendorID]  INT  NOT NULL,
    [orderDate] DATE NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([orderID] ASC)
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
    CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED ([ReviewID] ASC)
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
    CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([vendorID] ASC)
);


GO
PRINT N'Creating [dbo].[FK_MenuItem_Menus]...';


GO
ALTER TABLE [dbo].[TblMenuItem] WITH NOCHECK
    ADD CONSTRAINT [FK_MenuItem_Menus] FOREIGN KEY ([MenuSectionID]) REFERENCES [dbo].[TblMenuSection] ([MenuSectionID]);


GO
PRINT N'Creating [dbo].[FK_MenuItem_Menus1]...';


GO
ALTER TABLE [dbo].[TblMenuItem] WITH NOCHECK
    ADD CONSTRAINT [FK_MenuItem_Menus1] FOREIGN KEY ([menuID]) REFERENCES [dbo].[TblMenus] ([menuID]);


GO
PRINT N'Creating [dbo].[FK_Menus_Vendors]...';


GO
ALTER TABLE [dbo].[TblMenus] WITH NOCHECK
    ADD CONSTRAINT [FK_Menus_Vendors] FOREIGN KEY ([vendorID]) REFERENCES [dbo].[TblVendors] ([vendorID]);


GO
PRINT N'Creating [dbo].[FK_MenuSection_Menus]...';


GO
ALTER TABLE [dbo].[TblMenuSection] WITH NOCHECK
    ADD CONSTRAINT [FK_MenuSection_Menus] FOREIGN KEY ([MenuID]) REFERENCES [dbo].[TblMenus] ([menuID]);


GO
PRINT N'Creating [dbo].[FK_OrderItems_MenuItem]...';


GO
ALTER TABLE [dbo].[TblOrderItems] WITH NOCHECK
    ADD CONSTRAINT [FK_OrderItems_MenuItem] FOREIGN KEY ([menuItemId]) REFERENCES [dbo].[TblMenuItem] ([itemID]);


GO
PRINT N'Creating [dbo].[FK_OrderItems_Orders]...';


GO
ALTER TABLE [dbo].[TblOrderItems] WITH NOCHECK
    ADD CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY ([orderItemID]) REFERENCES [dbo].[TblOrders] ([orderID]);


GO
PRINT N'Creating [dbo].[FK_Orders_User]...';


GO
ALTER TABLE [dbo].[TblOrders] WITH NOCHECK
    ADD CONSTRAINT [FK_Orders_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[TblUser] ([userID]);


GO
PRINT N'Creating [dbo].[FK_Orders_Vendors]...';


GO
ALTER TABLE [dbo].[TblOrders] WITH NOCHECK
    ADD CONSTRAINT [FK_Orders_Vendors] FOREIGN KEY ([vendorID]) REFERENCES [dbo].[TblVendors] ([vendorID]);


GO
PRINT N'Creating [dbo].[FK_Review_User]...';


GO
ALTER TABLE [dbo].[TblReview] WITH NOCHECK
    ADD CONSTRAINT [FK_Review_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[TblUser] ([userID]);


GO
PRINT N'Creating [dbo].[FK_Review_Vendors]...';


GO
ALTER TABLE [dbo].[TblReview] WITH NOCHECK
    ADD CONSTRAINT [FK_Review_Vendors] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[TblVendors] ([vendorID]);


GO
PRINT N'Creating [dbo].[FK_VendorEmployees_User]...';


GO
ALTER TABLE [dbo].[TblVendorEmployees] WITH NOCHECK
    ADD CONSTRAINT [FK_VendorEmployees_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[TblUser] ([userID]);


GO
PRINT N'Creating [dbo].[FK_VendorEmployees_Vendors]...';


GO
ALTER TABLE [dbo].[TblVendorEmployees] WITH NOCHECK
    ADD CONSTRAINT [FK_VendorEmployees_Vendors] FOREIGN KEY ([vendorID]) REFERENCES [dbo].[TblVendors] ([vendorID]);


GO
PRINT N'Creating [dbo].[FK_VendorLocation_Vendors]...';


GO
ALTER TABLE [dbo].[TblVendorLocation] WITH NOCHECK
    ADD CONSTRAINT [FK_VendorLocation_Vendors] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[TblVendors] ([vendorID]);


GO
PRINT N'Creating [dbo].[FK_Vendors_User]...';


GO
ALTER TABLE [dbo].[TblVendors] WITH NOCHECK
    ADD CONSTRAINT [FK_Vendors_User] FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[TblUser] ([userID]);


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
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[TblMenuItem] WITH CHECK CHECK CONSTRAINT [FK_MenuItem_Menus];

ALTER TABLE [dbo].[TblMenuItem] WITH CHECK CHECK CONSTRAINT [FK_MenuItem_Menus1];

ALTER TABLE [dbo].[TblMenus] WITH CHECK CHECK CONSTRAINT [FK_Menus_Vendors];

ALTER TABLE [dbo].[TblMenuSection] WITH CHECK CHECK CONSTRAINT [FK_MenuSection_Menus];

ALTER TABLE [dbo].[TblOrderItems] WITH CHECK CHECK CONSTRAINT [FK_OrderItems_MenuItem];

ALTER TABLE [dbo].[TblOrderItems] WITH CHECK CHECK CONSTRAINT [FK_OrderItems_Orders];

ALTER TABLE [dbo].[TblOrders] WITH CHECK CHECK CONSTRAINT [FK_Orders_User];

ALTER TABLE [dbo].[TblOrders] WITH CHECK CHECK CONSTRAINT [FK_Orders_Vendors];

ALTER TABLE [dbo].[TblReview] WITH CHECK CHECK CONSTRAINT [FK_Review_User];

ALTER TABLE [dbo].[TblReview] WITH CHECK CHECK CONSTRAINT [FK_Review_Vendors];

ALTER TABLE [dbo].[TblVendorEmployees] WITH CHECK CHECK CONSTRAINT [FK_VendorEmployees_User];

ALTER TABLE [dbo].[TblVendorEmployees] WITH CHECK CHECK CONSTRAINT [FK_VendorEmployees_Vendors];

ALTER TABLE [dbo].[TblVendorLocation] WITH CHECK CHECK CONSTRAINT [FK_VendorLocation_Vendors];

ALTER TABLE [dbo].[TblVendors] WITH CHECK CHECK CONSTRAINT [FK_Vendors_User];


GO
PRINT N'Update complete.';


GO
