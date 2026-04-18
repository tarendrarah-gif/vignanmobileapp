CREATE PROCEDURE [dbo].[usp_UpdateMachine]
    @MachineId          INT,
    @MachineName        NVARCHAR(100),
    @MachineDescription NVARCHAR(255) = NULL,
    @IsActive           BIT,
    @OrganizationId     INT,
    @ModifiedBy         NVARCHAR(100) = NULL,
    @ModifiedOn         DATETIME      = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tblMachines
    SET MachineName        = @MachineName,
        MachineDescription = @MachineDescription,
        IsActive           = @IsActive,
        ModifiedBy         = @ModifiedBy,
        ModifiedOn         = @ModifiedOn
    WHERE MachineId = @MachineId;

    -- Refresh organisation mapping
    DELETE FROM tblMachineOrganization WHERE MachineId = @MachineId;
    INSERT INTO tblMachineOrganization (MachineId, OrganizationId)
    VALUES (@MachineId, @OrganizationId);

    SELECT @@ROWCOUNT AS RowsAffected;
END
