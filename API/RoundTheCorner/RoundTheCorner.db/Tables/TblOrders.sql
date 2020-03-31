CREATE TABLE [dbo].[TblOrders] (
    [orderID]   INT  IDENTITY (1, 1) NOT NULL,
    [userID]    INT  NOT NULL,
    [vendorID]  INT  NOT NULL,
    [orderDate] DATE NOT NULL, 
    CONSTRAINT [PK_TblOrders] PRIMARY KEY ([orderID]),

    --CONSTRAINT [FK_Orders_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[TblUser] ([userID]),
    --CONSTRAINT [FK_Orders_Vendors] FOREIGN KEY ([vendorID]) REFERENCES [dbo].[TblVendors] ([vendorID])
);