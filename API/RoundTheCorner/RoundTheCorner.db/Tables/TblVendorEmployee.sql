CREATE TABLE [dbo].[TblVendorEmployee] (
    [ID]       INT IDENTITY (1, 1) NOT NULL,
    [UserID]   INT NOT NULL,
    [VendorID] INT NOT NULL, 
    CONSTRAINT [PK_TblVendorEmployees] PRIMARY KEY ([ID]),

    --CONSTRAINT [FK_VendorEmployees_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[TblUser] ([userID]),
    --CONSTRAINT [FK_VendorEmployees_Vendors] FOREIGN KEY ([vendorID]) REFERENCES [dbo].[TblVendors] ([vendorID])
);