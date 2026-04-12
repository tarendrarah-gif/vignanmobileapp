CREATE PROCEDURE usp_InsertMachine
    @MachineName NVARCHAR(100),
    @MachineDescription NVARCHAR(255) = NULL,
    @IsActive BIT,
    @CreatedBy NVARCHAR(100),
    @CreatedOn DATETIME,
    @ModifiedBy NVARCHAR(100) = NULL,
    @ModifiedOn DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tblMachines
    (
        MachineName,
        MachineDescription,
        IsActive,
        CreatedBy,
        CreatedOn,
        ModifiedBy,
        ModifiedOn
    )
    VALUES
    (
        @MachineName,
        @MachineDescription,
        @IsActive,
        @CreatedBy,
        @CreatedOn,
        @ModifiedBy,
        @ModifiedOn
    );

    SELECT SCOPE_IDENTITY() AS MachineId;
END