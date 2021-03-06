﻿CREATE TABLE [dbo].[TblVendor] (
    [VendorID]       INT           IDENTITY (1, 1) NOT NULL,
    [OwnerID]        INT           NOT NULL,
    [CompanyName]    NVARCHAR (25) NOT NULL,
    [CompanyEmail]   NVARCHAR (25) NULL,
    [LicenseNumber]  INT           NOT NULL,
    [InspectionDate] DATETIME          NOT NULL,
    [Bio]            NTEXT         NULL,
    [Website]        NVARCHAR (50) NULL, 

    [Confirmed] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_TblVendors] PRIMARY KEY ([VendorID]),

    --CONSTRAINT [FK_Vendors_User] FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[TblUser] ([userID])
)
