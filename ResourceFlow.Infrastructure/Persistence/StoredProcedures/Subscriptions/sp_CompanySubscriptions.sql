CREATE OR ALTER PROCEDURE [dbo].[COMPANYSUBSCRIPTION_SP]
    @FLAG                VARCHAR(40),
    @ID                  INT              = NULL,
    @COMPANYID           INT              = NULL,
    @SUBSCRIPTIONID      INT              = NULL,
    @STARTDATE           DATETIME2        = NULL,
    @ENDDATE             DATETIME2        = NULL,
    @ISACTIVE            BIT              = NULL,
    @STATUS              INT              = NULL,   
    @CREATEAT            DATETIME2        = NULL,
    @CREATEDBY           INT              = NULL,
    @MODIFIEDAT          DATETIME2        = NULL,
    @MODIFIEDBY          INT              = NULL,
    @DELETEDAT           DATETIME2        = NULL,
    @DELETEDBY           INT              = NULL,
    @ISDELETED            BIT              = NULL
AS
BEGIN
    BEGIN TRY

        IF @FLAG = 'GETALL'
        BEGIN
            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscriptions
            WHERE IsDeleted = 0;
            RETURN;
        END

 
        IF @FLAG = 'GETBYID'
        BEGIN
            IF @ID IS NULL
            BEGIN
                RAISERROR('ID is required for GETBYID', 16, 1);
                RETURN;
            END

           
            IF NOT EXISTS (SELECT 1 FROM CompanySubscriptions WHERE Id = @ID AND IsDeleted = 0)
            BEGIN
                RAISERROR('CompanySubscription record not found for the given ID', 16, 1);
                RETURN;
            END

            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscriptions
            WHERE Id = @ID AND IsDeleted = 0;

            RETURN;
        END
      
        IF @FLAG = 'GETBYCOMPANYID'
        BEGIN
            IF @COMPANYID IS NULL
            BEGIN
                RAISERROR('COMPANYID is required for GETBYCOMPANYID', 16, 1);
                RETURN;
            END
            IF NOT EXISTS (SELECT 1 FROM CompanySubscriptions WHERE CompanyId = @COMPANYID AND IsDeleted = 0)
            BEGIN
                RAISERROR('CompanySubscription record not found for the given CompanyId', 16, 1);
                RETURN;
            END
                    
            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscriptions
            WHERE CompanyId = @COMPANYID AND IsDeleted = 0;
            RETURN;
        END
      
        IF @FLAG = 'GETBYSUBSCRIPTIONID'
        BEGIN
            IF @SUBSCRIPTIONID IS NULL
            BEGIN
                RAISERROR('SUBSCRIPTIONID is required for GETBYSUBSCRIPTIONID', 16, 1);
                RETURN;
            END
            IF NOT EXISTS (SELECT 1 FROM CompanySubscriptions WHERE SubscriptionId = @SUBSCRIPTIONID AND IsDeleted = 0)
            BEGIN
                RAISERROR('CompanySubscription record not found for the given ID', 16, 1);
                RETURN;
            END

            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscriptions
            WHERE SubscriptionId = @SUBSCRIPTIONID AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETACTIVE'
        BEGIN
            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscriptions
            WHERE IsActive = 1 AND IsDeleted = 0;
            RETURN;
        END

      
        IF @FLAG = 'GETBYSTATUS'
        BEGIN
            IF @STATUS IS NULL
            BEGIN
                RAISERROR('STATUS is required for GETBYSTATUS', 16, 1);
                RETURN;
            END

            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscriptions
            WHERE Status = @STATUS AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETEXPIRED'
        BEGIN
            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscriptions
            WHERE EndDate < GETUTCDATE() 
              AND IsDeleted = 0;
            RETURN;
        END
        IF @FLAG = 'GETEXPIRINGTODAY'
        BEGIN
            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscriptions
            WHERE 
                CAST(EndDate AS DATE) = CAST(GETUTCDATE()  AS DATE)
                AND IsDeleted = 0;

            RETURN;
        END

        IF @FLAG = 'GETEXPIRINGWITHINWEEK'
        BEGIN
            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscriptions
            WHERE 
                EndDate >= GETUTCDATE() 
                AND EndDate <= DATEADD(DAY, 7, GETUTCDATE() )
                AND IsDeleted = 0;

            RETURN;
        END

        RAISERROR('INVALID INPUT FLAG', 16, 1);
        RETURN;

    END TRY

    BEGIN CATCH
        DECLARE @ERR_MSG VARCHAR(MAX), @ERR_SEVERITY INT, @ERR_STATE INT;

        SELECT  
            @ERR_MSG      = ERROR_MESSAGE(),
            @ERR_SEVERITY = ERROR_SEVERITY(),
            @ERR_STATE    = ERROR_STATE();

        RAISERROR(@ERR_MSG, @ERR_SEVERITY, @ERR_STATE);
    END CATCH
END
GO
