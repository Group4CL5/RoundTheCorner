CREATE TABLE [dbo].[TblOrderItem] (
    [orderItemID] INT   NOT NULL IDENTITY,
    [menuItemId]  INT   NOT NULL,
    [price]       MONEY NOT NULL 

    --CONSTRAINT [FK_OrderItems_MenuItem] FOREIGN KEY ([menuItemId]) REFERENCES [dbo].[TblMenuItem] ([itemID]),
    --CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY ([orderItemID]) REFERENCES [dbo].[TblOrders] ([orderID])
, 
    CONSTRAINT [PK_TblOrderItem] PRIMARY KEY ([orderItemID]) 
);