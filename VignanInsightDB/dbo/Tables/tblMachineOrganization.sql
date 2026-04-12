CREATE TABLE [dbo].[tblMachineOrganization] (
    [MachineOrganizationId] INT      IDENTITY (1, 1) NOT NULL,
    [MachineId]             INT      NOT NULL,
    [OrganizationId]        INT      NOT NULL,
    [CreatedOn]             DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([MachineOrganizationId] ASC),
    CONSTRAINT [FK_MachineOrganization_Machine] FOREIGN KEY ([MachineId]) REFERENCES [dbo].[tblMachines] ([MachineId]),
    CONSTRAINT [FK_MachineOrganization_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[tblOrganization] ([OrganizationId])
);

