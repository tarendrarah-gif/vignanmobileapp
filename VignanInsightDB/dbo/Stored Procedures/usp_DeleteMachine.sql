CREATE PROCEDURE [dbo].[usp_DeleteMachine]
    @MachineId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM tblMachineOrganization WHERE MachineId = @MachineId;
    DELETE FROM tblMachines            WHERE MachineId = @MachineId;

    SELECT @@ROWCOUNT AS RowsAffected;
END
