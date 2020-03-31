CREATE TABLE [dbo].[TblVendorLocation] (
    [VendorID]  INT      NOT NULL,
    [datetime]  DATETIME NOT NULL,
    [locationX] INT      NOT NULL,
    [locationY] INT      NOT NULL, 
    CONSTRAINT [PK_TblVendorLocation] PRIMARY KEY ([VendorID], [datetime]),

    --CONSTRAINT [FK_VendorLocation_Vendors] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[TblVendors] ([vendorID])
);
