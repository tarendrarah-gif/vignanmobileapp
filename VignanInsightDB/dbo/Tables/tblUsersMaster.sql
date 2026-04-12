CREATE TABLE [dbo].[tblUsersMaster] (
    [UserId]     INT            IDENTITY (1, 1) NOT NULL,
    [Username]   NVARCHAR (100) NOT NULL,
    [Password]   NVARCHAR (255) NOT NULL,
    [Role]       NVARCHAR (50)  NULL,
    [IsActive]   BIT            DEFAULT ((1)) NOT NULL,
    [CreatedBy]  NVARCHAR (100) NOT NULL,
    [CreatedOn]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy] NVARCHAR (100) NULL,
    [ModifiedOn] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

