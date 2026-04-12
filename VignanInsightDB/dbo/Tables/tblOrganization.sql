CREATE TABLE [dbo].[tblOrganization] (
    [OrganizationId]          INT            IDENTITY (1, 1) NOT NULL,
    [OrganizationName]        NVARCHAR (200) NOT NULL,
    [OrganizationDescription] NVARCHAR (500) NULL,
    [IsActive]                BIT            NOT NULL,
    [CreatedBy]               NVARCHAR (100) NOT NULL,
    [CreatedOn]               DATETIME       NOT NULL,
    [ModifiedBy]              NVARCHAR (100) NULL,
    [ModifiedOn]              DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([OrganizationId] ASC)
);

