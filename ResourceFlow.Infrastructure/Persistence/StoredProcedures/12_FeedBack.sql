CREATE PROCEDURE dbo.Feedback
(
    @FLAG NVARCHAR(50),
    @CompanyId INT = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    -- -------------------------------------------------
    -- GET ALL FEEDBACKS (Admin)
    -- -------------------------------------------------
    IF (@FLAG = 'GET_ALL')
    BEGIN
        SELECT
            f.Id,
            f.Title,
            f.Content,
            c.Name AS CompanyName,
            f.IsPublished,
            f.CompanyId,
            f.CreatedAt
        FROM Feedbacks f
        INNER JOIN CompanyDetails c 
            ON f.CompanyId = c.CompanyId
        WHERE f.IsDeleted = 0
        ORDER BY f.CreatedAt DESC;
    END

    -- -------------------------------------------------
    -- GET ONLY PUBLISHED FEEDBACKS (Public)
    -- -------------------------------------------------
    ELSE IF (@FLAG = 'GET_PUBLISHED')
    BEGIN
        SELECT
            f.Id,
            f.Title,
            f.Content,
            c.Name AS CompanyName,
            f.CompanyId,
            f.CreatedAt
        FROM Feedbacks f
        INNER JOIN CompanyDetails c 
            ON f.CompanyId = c.CompanyId
        WHERE f.IsDeleted = 0
          AND f.IsPublished = 1
        ORDER BY f.CreatedAt DESC;
    END

    -- -------------------------------------------------
    -- GET FEEDBACKS BY COMPANY
    -- -------------------------------------------------
    ELSE IF (@FLAG = 'GET_BY_COMPANY')
    BEGIN
        SELECT
            f.Id,
            f.Title,
            f.Content,
            f.CreatedAt
        FROM Feedbacks f
        WHERE f.IsDeleted = 0
          AND f.CompanyId = @CompanyId
        ORDER BY f.CreatedAt DESC;
    END
END;
GO
