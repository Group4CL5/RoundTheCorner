CREATE TABLE [dbo].[TblUser] (
    [UserID]      INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (25) NOT NULL,
    [LastName]    NVARCHAR (25) NOT NULL,
    [DOB]         DATE          NULL,
    [Email]       NVARCHAR (50) NOT NULL,
    [Phone]       NVARCHAR (15) NULL,
    [Password]    NVARCHAR (32) NOT NULL,
    [Deactivated] BIT           NOT NULL, 
    [Admin] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_TblUser] PRIMARY KEY ([UserID]),

);