-- ============================================================
-- Seed Script: tblPage2 Dummy Data
-- Matches the 16 NVARCHAR(10) display fields used on Page2.html
-- Values are realistic injection-moulding cycle time strings
-- ============================================================

INSERT INTO [dbo].[tblPage2]
(
    MoldClose, CoresIn,   UnitFwd,   Intrugen,
    Injection, HoldOn,    Refill,    Suckback,
    UnitRet,   Cooling,   MoldOpen,  CoresOut,
    EjectorFwd,EjectorRet,CycleDelay,TotCycTime,
    CreatedOn, IsActive
)
VALUES
-- Row 1 – baseline cycle
('02.38', '01.20', '00.80', '00.50',
 '05.00', '03.00', '04.20', '00.30',
 '00.70', '12.00', '02.10', '01.10',
 '01.50', '01.50', '00.00', '34.58',
 GETDATE(), 1),

-- Row 2 – slightly faster cycle
('02.10', '01.10', '00.75', '00.45',
 '04.80', '02.80', '04.00', '00.28',
 '00.65', '11.50', '02.00', '01.05',
 '01.40', '01.40', '00.00', '32.88',
 GETDATE(), 1),

-- Row 3 – latest/current live values (TOP 1 will return this)
('02.55', '01.30', '00.90', '00.55',
 '05.20', '03.20', '04.40', '00.35',
 '00.80', '12.50', '02.20', '01.20',
 '01.60', '01.60', '00.50', '37.05',
 GETDATE(), 1);
