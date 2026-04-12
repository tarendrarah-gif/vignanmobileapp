CREATE PROCEDURE usp_InsertMachineOrganization
    @MachineId INT,
    @OrganizationId INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tblMachineOrganization (MachineId, OrganizationId,CreatedOn)
    VALUES (@MachineId, @OrganizationId,GETDATE());
END