CREATE TABLE [dbo].[tblPage32] (
    [DataId]            INT           IDENTITY (1, 1) NOT NULL,
    [MotorStatus]       NVARCHAR (50) NULL,
    [SwitchedOnBy]      NVARCHAR (50) NULL,
    [StarterType]       NVARCHAR (50) NULL,
    [StarDeltaDelaySec] NVARCHAR (50) NULL,
    [StarDeltaDelayMin] NVARCHAR (50) NULL,
    [OnDelaySec]        NVARCHAR (50) NULL,
    [OnDelayMin]        NVARCHAR (50) NULL,
    [HandOperation]     NVARCHAR (50) NULL,
    [PowerSaving]       NVARCHAR (50) NULL,
    [SwitchOnMotorTime] NVARCHAR (50) NULL,
    [StarterOutputK1]   NVARCHAR (50) NULL,
    [StarterOutputK2]   NVARCHAR (50) NULL,
    [CreatedOn]         DATETIME      DEFAULT (getdate()) NULL,
    [IsActive]          BIT           DEFAULT ((1)) NULL,
    PRIMARY KEY CLUSTERED ([DataId] ASC)
);

