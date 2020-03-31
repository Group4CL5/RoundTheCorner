CREATE TABLE [dbo].[TblMenuSection] (
    [MenuSectionID]   INT IDENTITY (1, 1) NOT NULL,
    [MenuID]          INT NOT NULL,
    [DisplayOrderNum] INT NOT NULL, 
    CONSTRAINT [PK_TblMenuSection] PRIMARY KEY ([MenuSectionID]),

    --CONSTRAINT [FK_MenuSection_Menus] FOREIGN KEY ([MenuID]) REFERENCES [dbo].[TblMenus] ([menuID])
);