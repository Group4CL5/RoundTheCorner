﻿/*
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
drop table if exists [dbo].[TblOrderItem]
drop table if exists [dbo].[TblOrder]
drop table if exists [dbo].[TblReview]
drop table if exists [dbo].[TblUser]
drop table if exists [dbo].[TblVendorEmployee]
drop table if exists [dbo].[TblVendorLocation]
drop table if exists [dbo].[TblVendor]