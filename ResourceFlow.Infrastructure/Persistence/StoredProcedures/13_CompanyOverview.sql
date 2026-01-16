CREATE OR ALTER PROCEDURE dbo.SP_GetCompanyOverview
    @CompanyId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.Id AS CompanyId,
        c.CompanyName,

        (SELECT COUNT(*) 
         FROM Employees e
         WHERE e.CompanyId = c.Id 
           AND e.IsDeleted = 0) AS EmployeesCount,

        (SELECT COUNT(*) 
         FROM CompanyFloors f
         WHERE f.CompanyId = c.Id 
           AND f.IsDeleted = 0) AS FloorsCount,

        (SELECT COUNT(*) 
         FROM Resources r
         WHERE r.CompanyId = c.Id 
           AND r.ResourceTypeId = 1 
           AND r.IsDeleted = 0) AS DesksCount,

        (SELECT COUNT(*) 
         FROM Resources r
         WHERE r.CompanyId = c.Id 
           AND r.ResourceTypeId = 2 
           AND r.IsDeleted = 0) AS MeetingRoomsCount,

        s.EmployeeLimit      AS EmployeesLimit,
        s.FloorLimit         AS FloorsLimi,
        s.DeskLimit          AS DesksLimit,
        s.MeetingRoomLimit   AS MeetingRoomsLimi

    FROM Companies c
    INNER JOIN Subscriptions s 
        ON s.Id = c.ActiveSubscriptionId
    WHERE c.Id = @CompanyId;
END;
GO
