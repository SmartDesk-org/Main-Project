
-------------------------------------------------------------------------------------------------------------------------------------
/*{[
  Title       : [dbo].[SP_HISTORYBYCOMPANY]
  Description : Handles history for companies 
  CreatedOn and Owner : { 20/12/2025 : Suhail}

  ModifiedOn and Owner:{ 23/12/2025 : Ganga Suresh V}
  Description :Added  error capture details

  Execution Statements:

  -- Get all histories of a company
  EXEC [dbo].[SP_HISTORYBYCOMPANY] @CompanyDi=companyID
  
}*/

GO
CREATE OR ALTER  PROCEDURE [dbo].[SP_HISTORYBYCOMPANY]
( 
    @CompanyId INT
)
AS
BEGIN
    BEGIN TRY
              
        SELECT 
            c.Name              AS CompanyName,
            s.SubscriptionName  AS SubscriptionName,
            h.StartDate,
            h.EndDate,
            h.AmountPaid,
            h.Status,
            h.ChangeReason
        FROM Histories h
        INNER JOIN CompanyDetails c ON h.CompanyId = c.CompanyId
        INNER JOIN Subscriptions s ON h.SubscriptionId = s.Id
        WHERE c.IsDeleted = 0 AND h.CompanyId = @CompanyId
        ORDER BY h.CreatedAt DESC;
    END TRY
    BEGIN CATCH
        
        DECLARE @ERRMSG NVARCHAR(MAX), @ERRSEVERITY INT, @ERRSTATE INT;

        SELECT  
            @ERRMSG      = ERROR_MESSAGE(),
            @ERRSEVERITY = ERROR_SEVERITY(),
            @ERRSTATE    = ERROR_STATE();

        RAISERROR(@ERRMSG, @ERRSEVERITY, @ERRSTATE);
    END CATCH
END;
GO

-----------------------------------------------------------------------------------------------------------------------------------------