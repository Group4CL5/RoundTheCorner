CREATE TABLE [dbo].[TblUser] (
    [userID]      INT           IDENTITY (1, 1) NOT NULL,
    [firstName]   NVARCHAR (25) NOT NULL,
    [lastName]    NVARCHAR (25) NOT NULL,
    [DOB]         DATE          NULL,
    [email]       NVARCHAR (50) NOT NULL,
    [phone]       NVARCHAR (15) NULL,
    [password]    NVARCHAR (32) NOT NULL,
    [deactivated] BIT           NOT NULL, 
    CONSTRAINT [PK_TblUser] PRIMARY KEY ([userID]),

);