CREATE TABLE [dbo].[tblUserOrganization] (
    [UserOrganizationId] INT      IDENTITY (1, 1) NOT NULL,
    [UserId]             INT      NOT NULL,
    [OrganizationId]     INT      NOT NULL,
    [CreatedOn]          DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserOrganizationId] ASC),
    CONSTRAINT [FK_UserOrganization_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[tblOrganization] ([OrganizationId]),
    CONSTRAINT [FK_UserOrganization_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[tblUsersMaster] ([UserId])
);

