CREATE TABLE [dbo].[TblOrder] (
    [OrderID]   INT  IDENTITY (1, 1) NOT NULL,
    [UserID]    INT  NOT NULL,
    [VendorID]  INT  NOT NULL,
    [OrderDate] DATE NOT NULL, 
    CONSTRAINT [PK_TblOrders] PRIMARY KEY ([OrderID]),

    --CONSTRAINT [FK_Orders_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[TblUser] ([userID]),
    --CONSTRAINT [FK_Orders_Vendors] FOREIGN KEY ([vendorID]) REFERENCES [dbo].[TblVendors] ([vendorID])
);