CREATE TABLE [dbo].[TblCuisine] (
    [CuisineID]   INT           IDENTITY (1, 1) NOT NULL,
    [CuisineName] NVARCHAR (25) NOT NULL,
    [VendorID]    INT           NOT NULL,
    [MenuID]      INT           NOT Null, 
    CONSTRAINT [PK_TblCuisine] PRIMARY KEY ([CuisineID])
);