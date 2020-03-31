CREATE TABLE [dbo].[TblVendors] (
    [vendorID]       INT           IDENTITY (1, 1) NOT NULL,
    [OwnerID]        INT           NOT NULL,
    [CompanyName]    NVARCHAR (25) NOT NULL,
    [CompanyEmail]   NVARCHAR (25) NULL,
    [LicenseNumber]  INT           NOT NULL,
    [inspectionDate] DATE          NOT NULL,
    [bio]            NTEXT         NULL,
    [Website]        NVARCHAR (50) NULL, 
    CONSTRAINT [PK_TblVendors] PRIMARY KEY ([vendorID]),

    --CONSTRAINT [FK_Vendors_User] FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[TblUser] ([userID])
)
