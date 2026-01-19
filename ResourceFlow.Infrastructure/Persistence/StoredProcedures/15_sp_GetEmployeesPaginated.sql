-- CREATED BY RINSHAD
-- SP_sp_GetEmployeesPaginated
-- CREATED ON : 09:01:2026 on 04:07 PM

CREATE PROCEDURE sp_GetEmployeesPaginated
    @CompanyId INT,
    @PageNumber INT,
    @PageSize INT,
    @SearchTerm NVARCHAR(100) = NULL -- 🟢 Add this
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

    -- Helper to handle wildcards
    DECLARE @SearchPattern NVARCHAR(100) = '%' + ISNULL(@SearchTerm, '') + '%';

    -- 1. Fetch Paginated Data
    SELECT 
        e.Id AS EmployeeId,
        e.CompanyId,
        u.UserId,
        e.DefaultFloorId,
        e.Department,
        CAST(e.Status AS NVARCHAR(50)) AS Status, 
        u.UserName,
        u.Email,
        u.RoleId,
        u.IsActive,
        u.IsBlocked,
        u.FailedLoginAttempts,
        u.LockoutEnd,
        e.CreatedAt,
        e.CreatedBy,
        e.ModifiedAt,
        e.ModifiedBy
    FROM Employees e
    INNER JOIN Users u ON e.UserId = u.UserId
    WHERE e.CompanyId = @CompanyId 
      AND e.IsDeleted = 0
      -- 🟢 Search Logic
      AND (@SearchTerm IS NULL OR 
           u.UserName LIKE @SearchPattern OR 
           u.Email LIKE @SearchPattern OR 
           e.Department LIKE @SearchPattern)
    ORDER BY e.CreatedAt DESC
    OFFSET @Offset ROWS 
    FETCH NEXT @PageSize ROWS ONLY;

    -- 2. Fetch Total Count (Must apply same search filter)
    SELECT COUNT(*) 
    FROM Employees e
    INNER JOIN Users u ON e.UserId = u.UserId
    WHERE e.CompanyId = @CompanyId 
      AND e.IsDeleted = 0
      AND (@SearchTerm IS NULL OR 
           u.UserName LIKE @SearchPattern OR 
           u.Email LIKE @SearchPattern OR 
           e.Department LIKE @SearchPattern);
END
GO