
-------------------------------------------------------------------------------------------------------------------------------------
/*{
  Title       : [dbo].[SP_SUBSCRIPTION]
  Description : Handles Subscription master read operations using FLAG-based logic
  CreatedOn and Owner : { 16/12/2025 : Ganga Suresh V }

  Execution Statements:

  -- Get all subscriptions
  EXEC dbo.SP_SUBSCRIPTION @FLAG = 'GETALL';

  -- Get subscription by ID
  EXEC dbo.SP_SUBSCRIPTION @FLAG = 'GETBYID', @SUBSCRIPTIONID = 1;

  -- Get subscription by name
  EXEC dbo.SP_SUBSCRIPTION @FLAG = 'GETBYNAME', @SUBSCRIPTIONNAME = 'Premium';

  -- Get active subscriptions
  EXEC dbo.SP_SUBSCRIPTION @FLAG = 'GETBYACTIVE', @ISACTIVE = 1;

  Modified On and Modified By : { 124/12/2025 : Suhail }
  Description : Added typeName in GETALL joining subscrptioType table 
}*/

CREATE  PROCEDURE [dbo].[SP_SUBSCRIPTION] 
    @FLAG           VARCHAR(40),
    @SUBSCRIPTIONID INT              = NULL,
    @SUBSCRIPTIONNAME NVARCHAR(200)  = NULL,
    @ISACTIVE       BIT              = NULL,
    @CREATEAT       DATETIME2        = NULL,
    @CREATEDBY      INT              = NULL,
    @MODIFIEDAT     DATETIME2        = NULL,
    @MODIFIEDBY     INT              = NULL,
    @DELETEDAT      DATETIME2        = NULL,
    @DELETEDBY      INT              = NULL,
    @ISDELETED       BIT              = NULL
AS
BEGIN
    BEGIN TRY

        IF @FLAG = 'GETALL'
        BEGIN
            SELECT 
                s.Id,
        s.SubscriptionName,
        s.MaxEmployees,
        s.MaxFloors,
        s.MaxDesks,
        s.MaxMeetingRooms,
        s.PriceMonthly,
        s.PriceYearly,
        s.Description,
        s.IsActive,
        t.TypeName
            FROM Subscriptions s
            JOIN SubscriptionTypes t ON s.TypeId =t.Id
            WHERE s.IsDeleted = 0;
            RETURN;
        END
       
        IF @FLAG = 'GETBYID'
        BEGIN
            IF @SUBSCRIPTIONID IS NULL
            BEGIN
                RAISERROR('SUBSCRIPTIONID is required for GETBYID', 16, 1);
                RETURN;
            END


            SELECT 
                Id, SubscriptionName, PriceMonthly, PriceYearly, Description,IsActive
            FROM Subscriptions
            WHERE Id = @SUBSCRIPTIONID AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYNAME'
        BEGIN
            IF @SUBSCRIPTIONNAME IS NULL
            BEGIN
                RAISERROR('SUBSCRIPTIONNAME is required for GETBYNAME', 16, 1);
                RETURN;
            END

            SELECT 
                Id, SubscriptionName, PriceMonthly, PriceYearly, Description,IsActive
            FROM Subscriptions
            WHERE SubscriptionName = @SUBSCRIPTIONNAME AND IsDeleted = 0;
            RETURN;
        END
        IF @FLAG = 'GETBYACTIVE'
        BEGIN
            IF @ISACTIVE IS NULL
            BEGIN
                RAISERROR('ISACTIVE is required for GETBYACTIVE', 16, 1);
                RETURN;
            END

            SELECT 
                Id, SubscriptionName,  PriceMonthly, PriceYearly, Description,IsActive
            FROM Subscriptions
            WHERE IsActive = @ISACTIVE AND IsDeleted = 0;
            RETURN;
        END

      
        RAISERROR('INVALID INPUT FLAG', 16, 1);
        RETURN;

    END TRY

    BEGIN CATCH
        DECLARE @ERRMSG VARCHAR(MAX), @ERRSEVERITY INT, @ERRSTATE INT;

        SELECT  
            @ERRMSG      = ERROR_MESSAGE(),
            @ERRSEVERITY = ERROR_SEVERITY(),
            @ERRSTATE    = ERROR_STATE();

        RAISERROR(@ERRMSG, @ERRSEVERITY, @ERRSTATE);
    END CATCH
END
GO


-------------------------------------------------------------------------------------------------