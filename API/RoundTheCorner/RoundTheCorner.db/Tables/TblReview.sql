CREATE TABLE [dbo].[TblReview] (
    [ReviewID] INT           IDENTITY (1, 1) NOT NULL,
    [VendorID] INT           NOT NULL,
    [UserID]   INT           NOT NULL,
    [Rating]   INT           NOT NULL,
    [Subject]  NVARCHAR (25) NOT NULL,
    [Body]     NTEXT         NOT NULL, 
    CONSTRAINT [PK_TblReview] PRIMARY KEY ([ReviewID]),

    --CONSTRAINT [FK_Review_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[TblUser] ([userID]),
    --CONSTRAINT [FK_Review_Vendors] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[TblVendors] ([vendorID])
);
