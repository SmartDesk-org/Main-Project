CREATE PROCEDURE GetCompanyOverview
(
	@CompanyId INT
)
AS
BEGIN
	SET NOCOUNT On;
	SELECT
		c.CompanyId,
		c.Name,
		cs.MaxEmployees,
		cs.MaxFloors,
		cs.MaxDesks,
		cs.MaxMeetingRooms,

		(SELECT COUNT(*) 
		FROM Employees e
		WHERE e.IsDeleted =0 
			AND e.CompanyId=c.CompanyId ) AS CurrentEmployees,

		(SELECT COUNT(*)
		FROM CompanyFloors f 
			WHERE f.CompanyId =c.CompanyId 
				AND f.IsDeleted=0 ) AS CurrentFloors,

		(SELECT COUNT(*) 
		FROM CompanyDesks d
			WHERE d.CompanyId=c.CompanyId
				AND d.IsDeleted=0 ) AS CurrentDesks,

		(SELECT COUNT(*) 
		FROM CompanyMeetingRooms m 
			WHERE m.CompanyId=c.CompanyId
				AND m.IsDeleted=0) AS CurrentMeetingRooms

	FROM CompanyDetails c 
	LEFT JOIN CompanySubscrpition cs 
		ON cs.CompanyId=c.CompanyId
		AND cs.IsDeleted=0
		AND cs.IsActive=1
	WHERE c.CompanyId=@CompanyId 
	AND c.IsDeleted=0 AND c.IsActive=1 
END