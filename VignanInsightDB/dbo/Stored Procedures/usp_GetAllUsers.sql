CREATE PROCEDURE usp_GetAllUsers
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        UserId,
        Username,
        [Role],
        IsActive,
        CreatedBy,
        CreatedOn
    FROM tblUsersMaster
    ORDER BY UserId ASC;
END