CREATE TABLE [dbo].[TblVendorEmployee] (
    [id]       INT IDENTITY (1, 1) NOT NULL,
    [userID]   INT NOT NULL,
    [vendorID] INT NOT NULL, 
    CONSTRAINT [PK_TblVendorEmployees] PRIMARY KEY ([id]),

    --CONSTRAINT [FK_VendorEmployees_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[TblUser] ([userID]),
    --CONSTRAINT [FK_VendorEmployees_Vendors] FOREIGN KEY ([vendorID]) REFERENCES [dbo].[TblVendors] ([vendorID])
);