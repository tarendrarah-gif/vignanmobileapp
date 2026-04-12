CREATE PROCEDURE usp_GetUsersByOrganization
    @OrganizationId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.*
    FROM tblUserOrganization uo
    INNER JOIN tblUsersMaster u ON uo.UserId = u.UserId
    WHERE uo.OrganizationId = @OrganizationId;
END