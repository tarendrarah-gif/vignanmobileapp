CREATE TABLE [dbo].[tblMachines] (
    [MachineId]          INT            IDENTITY (1, 1) NOT NULL,
    [MachineName]        NVARCHAR (100) NOT NULL,
    [MachineDescription] NVARCHAR (255) NULL,
    [IsActive]           BIT            DEFAULT ((1)) NOT NULL,
    [CreatedBy]          NVARCHAR (100) NOT NULL,
    [CreatedOn]          DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]         NVARCHAR (100) NULL,
    [ModifiedOn]         DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([MachineId] ASC)
);

