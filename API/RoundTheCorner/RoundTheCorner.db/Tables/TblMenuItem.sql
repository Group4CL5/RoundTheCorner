CREATE TABLE [dbo].[TblMenuItem] (
    [ItemID]        INT           IDENTITY (1, 1) NOT NULL,
    [MenuID]        INT           NOT NULL,
    [ItemName]      NVARCHAR (25) NOT NULL,
    [Price]         MONEY         NOT NULL,
    [Picture]       NVARCHAR(50)         NULL,
    [Description]   TEXT          NULL,
    [MenuSectionID] INT           NOT NULL, 
    CONSTRAINT [PK_TblMenuItem] PRIMARY KEY ([ItemID]),

    --CONSTRAINT [FK_MenuItem_Menus] FOREIGN KEY ([MenuSectionID]) REFERENCES [dbo].[TblMenuSection] ([MenuSectionID]),
    --CONSTRAINT [FK_MenuItem_Menus1] FOREIGN KEY ([menuID]) REFERENCES [dbo].[TblMenus] ([menuID])
);