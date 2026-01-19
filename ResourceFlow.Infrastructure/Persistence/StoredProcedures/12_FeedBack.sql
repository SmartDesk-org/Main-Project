
-------------------------------------------------------------------------------------------------------------------------------------
/*{
  Title       : [dbo].[SP_FEEDBACK]
  Description : Handles Feedback read operations using FLAG-based logic
  Created On  : 05/01/2026
  Created By  : -----------
  Modified On : 07/01/2026
  Modified By : Rinshad

  Execution Statements:

  -- Get all feedbacks (Admin)
  EXEC dbo.SP_FEEDBACK @FLAG = 'GET_ALL';

  -- Get only published feedbacks (Public)
  EXEC dbo.SP_FEEDBACK @FLAG = 'GET_PUBLISHED';

  -- Get feedbacks by company
  EXEC dbo.SP_FEEDBACK @FLAG = 'GET_BY_COMPANY', @CompanyId = 1;
}*/


CREATE OR ALTER PROCEDURE dbo.Feedback
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


