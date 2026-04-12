CREATE PROCEDURE usp_GetOrganizationsByUser
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT o.*
    FROM tblUserOrganization uo
    INNER JOIN tblOrganization o ON uo.OrganizationId = o.OrganizationId
    WHERE uo.UserId = @UserId;
END