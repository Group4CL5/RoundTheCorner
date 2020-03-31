CREATE TABLE [dbo].[TblMenuItem] (
    [itemID]        INT           IDENTITY (1, 1) NOT NULL,
    [menuID]        INT           NOT NULL,
    [itemName]      NVARCHAR (25) NOT NULL,
    [price]         MONEY         NOT NULL,
    [picture]       IMAGE         NULL,
    [description]   TEXT          NULL,
    [MenuSectionID] INT           NOT NULL, 
    CONSTRAINT [PK_TblMenuItem] PRIMARY KEY ([itemID]),

    --CONSTRAINT [FK_MenuItem_Menus] FOREIGN KEY ([MenuSectionID]) REFERENCES [dbo].[TblMenuSection] ([MenuSectionID]),
    --CONSTRAINT [FK_MenuItem_Menus1] FOREIGN KEY ([menuID]) REFERENCES [dbo].[TblMenus] ([menuID])
);