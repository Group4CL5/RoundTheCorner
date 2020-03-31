CREATE TABLE [dbo].[TblMenu] (
    [menuID]   INT IDENTITY (1, 1) NOT NULL,
    [vendorID] INT NOT NULL,
    [isActive] BIT NOT NULL, 
    CONSTRAINT [PK_TblMenus] PRIMARY KEY ([menuID]),

    --CONSTRAINT [FK_Menus_Vendors] FOREIGN KEY ([vendorID]) REFERENCES [dbo].[TblVendors] ([vendorID])
);