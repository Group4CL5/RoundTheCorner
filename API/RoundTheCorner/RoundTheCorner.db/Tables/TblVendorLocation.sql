CREATE TABLE [dbo].[TblVendorLocation] (
    [VendorID]  INT      NOT NULL,
    [Datetime]  DATETIME NOT NULL,
    [LocationX] INT      NOT NULL,
    [LocationY] INT      NOT NULL, 
    CONSTRAINT [PK_TblVendorLocation] PRIMARY KEY ([VendorID], [Datetime]),

    --CONSTRAINT [FK_VendorLocation_Vendors] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[TblVendors] ([vendorID])
);
