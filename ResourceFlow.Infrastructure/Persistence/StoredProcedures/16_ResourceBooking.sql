-------------------------------------------------------------------------------------------------------------------------------------
/*{[
  Title       : [dbo].[SP_GETBOOKINGSBYUSER]
  Description : Fetches all resource bookings of a specific user along with user details
  CreatedOn and Owner : { 12/01/2026 : Ganga Suresh V }

  

  Execution Statements:

  -- Get all bookings of a user
  EXEC [dbo].[SP_GETBOOKINGSBYUSER] @UserId = 1

}]}*/
CREATE OR ALTER PROCEDURE [dbo].[SP_GETBOOKINGSBYUSER]
(
    @UserId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT
            rb.Id                     AS BookingId,
            rb.CompanyId              AS CompanyId,
            rb.ResourceId             AS ResourceId,
            rb.ResourceTypeId         AS ResourceTypeId,
            rb.QRCodeValue            AS QRCodeValue,
            rb.QrExpiresAt            AS QrExpiresAt,

            u.UserId                  AS UserId,
            u.UserName                AS UserName,

            e.Department              AS Department,
            e.Designation             AS Designation,
            CAST(e.Status AS VARCHAR(50)) AS EmployeeStatus,

            rb.StartTime              AS StartTime,
            rb.EndTime                AS EndTime,
            CAST(rb.Status AS VARCHAR(50)) AS Status

        FROM dbo.ResourceBookings rb
        INNER JOIN dbo.Users u
            ON u.UserId = rb.BookedByUserId

        LEFT JOIN dbo.Employees e
            ON e.UserId = u.UserId
            AND e.IsDeleted = 0

        WHERE u.UserId = @UserId
          AND u.IsActive = 1
          AND u.IsBlocked = 0
          AND rb.IsDeleted = 0

        ORDER BY rb.StartTime DESC;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

-------------------------------------------------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------------------------------------------
