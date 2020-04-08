CREATE TABLE [dbo].[TblMenu] (
    [MenuID]   INT IDENTITY (1, 1) NOT NULL,
    [VendorID] INT NOT NULL,
    [IsActive] BIT NOT NULL, 
    CONSTRAINT [PK_TblMenus] PRIMARY KEY ([MenuID]),

    --CONSTRAINT [FK_Menus_Vendors] FOREIGN KEY ([vendorID]) REFERENCES [dbo].[TblVendors] ([vendorID])
);