GO
CREATE or ALTER PROCEDURE dbo.SP_GetCompanyOverview
    @CompanyId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.CompanyId,
        c.Name AS CompanyName,

        (SELECT COUNT(*) FROM Employees e
         WHERE e.CompanyId = c.CompanyId AND e.IsDeleted = 0) AS EmployeesCount,

        (SELECT COUNT(*) FROM CompanyFloors f
         WHERE f.CompanyId = c.CompanyId AND f.IsDeleted = 0) AS FloorsCount,

        (SELECT COUNT(*) FROM Resources r
         WHERE r.CompanyId = c.CompanyId AND r.ResourceTypeId = 1 AND r.IsDeleted = 0) AS DesksCount,

        (SELECT COUNT(*) FROM Resources r
         WHERE r.CompanyId = c.CompanyId AND r.ResourceTypeId = 2 AND r.IsDeleted = 0) AS MeetingRoomsCount,

        ISNULL(s.EmployeesLimit, 0)    AS EmployeesLimit,
        ISNULL(s.FloorsLimit, 0)       AS FloorsLimit,
        ISNULL(s.DesksLimit, 0)        AS DesksLimit,
        ISNULL(s.MeetingRoomsLimit, 0) AS MeetingRoomsLimit,
        s.EndDate AS subscriptionEndDate

    FROM CompanyDetails c
    LEFT JOIN CompanySubscription s
        ON s.Id = c.CompanySubscriptionId
    WHERE c.CompanyId = @CompanyId;
END;

GO