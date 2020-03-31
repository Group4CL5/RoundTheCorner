CREATE TABLE [dbo].[TblOrderItems] (
    [orderItemID] INT   NOT NULL,
    [menuItemId]  INT   NOT NULL,
    [price]       MONEY NOT NULL 

    --CONSTRAINT [FK_OrderItems_MenuItem] FOREIGN KEY ([menuItemId]) REFERENCES [dbo].[TblMenuItem] ([itemID]),
    --CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY ([orderItemID]) REFERENCES [dbo].[TblOrders] ([orderID])
, 
    CONSTRAINT [PK_TblOrderItems] PRIMARY KEY ([menuItemId], [orderItemID]));