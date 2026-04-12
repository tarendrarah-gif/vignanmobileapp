CREATE PROCEDURE [dbo].[usp_GetPage2Data]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1
        DataId,
        MoldClose,
        CoresIn,
        UnitFwd,
        Intrugen,
        Injection,
        HoldOn,
        Refill,
        Suckback,
        UnitRet,
        Cooling,
        MoldOpen,
        CoresOut,
        EjectorFwd,
        EjectorRet,
        CycleDelay,
        TotCycTime,
        CreatedOn,
        IsActive
    FROM dbo.tblPage2
    ORDER BY DataId DESC;
END
