CREATE OR ALTER PROCEDURE [dbo].[SUBSCRIPTION_SP] 
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
                Id,
        SubscriptionName,
        EmployeeLimit,
        FloorLimit,
        DeskLimit,
        MeetingRoomLimit,
        PriceMonthly,
        PriceYearly,
        Description,
        IsActive
            FROM Subscriptions
            WHERE IsDeleted = 0;
            RETURN;
        END
       
        IF @FLAG = 'GETBYID'
        BEGIN
            IF @SUBSCRIPTIONID IS NULL
            BEGIN
                RAISERROR('SUBSCRIPTIONID is required for GETBYID', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM Subscriptions WHERE Id = @SUBSCRIPTIONID AND IsDeleted = 0)
            BEGIN
                RAISERROR('Subscription with this id not found', 16, 1);
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
