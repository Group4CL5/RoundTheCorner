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
(CuisineName, VendorID, MenuID)
Values 
('Dominican', 1, 1)
End
BEGIN
Insert into TblMenu
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
