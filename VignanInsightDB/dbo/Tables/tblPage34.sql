CREATE TABLE [dbo].[tblPage34] (
    [DataId]                INT           IDENTITY (1, 1) NOT NULL,
    [LubricationFlag]       NVARCHAR (50) NULL,
    [LubricationSelection]  NVARCHAR (50) NULL,
    [LubricationMode]       NVARCHAR (50) NULL,
    [LubIntervalTimeSet]    NVARCHAR (50) NULL,
    [LubIntervalTimeRem]    NVARCHAR (50) NULL,
    [LubIntervalShotsSet]   NVARCHAR (50) NULL,
    [LubIntervalShotsRem]   NVARCHAR (50) NULL,
    [LubOnTimeSet]          NVARCHAR (50) NULL,
    [LubOnTimeRem]          NVARCHAR (50) NULL,
    [LubRepeatCycleSet]     NVARCHAR (50) NULL,
    [LubRepeatCycleRem]     NVARCHAR (50) NULL,
    [LubFeedbackTimeoutSet] NVARCHAR (50) NULL,
    [LubFeedbackTimeoutRem] NVARCHAR (50) NULL,
    [LubMinOffTimeSet]      NVARCHAR (50) NULL,
    [LubMinOffTimeRem]      NVARCHAR (50) NULL,
    [CreatedOn]             DATETIME      DEFAULT (getdate()) NULL,
    [IsActive]              BIT           NULL,
    PRIMARY KEY CLUSTERED ([DataId] ASC)
);

