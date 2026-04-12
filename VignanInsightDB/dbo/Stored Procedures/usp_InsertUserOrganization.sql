CREATE PROCEDURE [dbo].[usp_InsertUserOrganization]
    @UserId INT,
    @OrganizationId INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tblUserOrganization (UserId, OrganizationId, CreatedOn)
    VALUES (@UserId, @OrganizationId, GETDATE());
END