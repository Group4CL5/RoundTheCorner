CREATE TABLE [dbo].[TblOrderItem] (
    [OrderItemID] INT   NOT NULL IDENTITY,
    [MenuItemId]  INT   NOT NULL,
    [Price]       MONEY NOT NULL 

    --CONSTRAINT [FK_OrderItems_MenuItem] FOREIGN KEY ([menuItemId]) REFERENCES [dbo].[TblMenuItem] ([itemID]),
    --CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY ([orderItemID]) REFERENCES [dbo].[TblOrders] ([orderID])
, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [PK_TblOrderItem] PRIMARY KEY ([OrderItemID]) 
);