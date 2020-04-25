CREATE TABLE [dbo].[TblOrderItem](
	[OrderItemID] [int] NOT NULL IDENTITY,
	[MenuItemId] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[OrderID] [int] NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [PK_TblOrderItem] PRIMARY KEY ([OrderItemID])
) ON [PRIMARY]
GO











