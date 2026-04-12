CREATE TABLE [dbo].[tblUserMachines] (
    [UserMachineId] INT      IDENTITY (1, 1) NOT NULL,
    [UserId]        INT      NOT NULL,
    [MachineId]     INT      NOT NULL,
    [AssignedOn]    DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserMachineId] ASC),
    CONSTRAINT [FK__tblUserMa__Machi__4222D4EF] FOREIGN KEY ([MachineId]) REFERENCES [dbo].[tblMachines] ([MachineId]),
    CONSTRAINT [FK__tblUserMa__UserI__412EB0B6] FOREIGN KEY ([UserId]) REFERENCES [dbo].[tblUsersMaster] ([UserId])
);

