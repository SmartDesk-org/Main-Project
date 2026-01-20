

-------------------------------------------------------------------------------------------------------------------------------------

/*{
  Title       : [dbo].[SP_COMPANYSUBSCRIPTION]
  Description : Handles Company Subscription read operations using FLAG-based logic
  CreatedOn and Owner : { 16/12/2025 : Ganga Suresh V }

2.ModifiedOn and Owner : {19/12/2025 : Rinshad}
Description : Updated and added new Flag named 'GETACTIVE_BYCOMPANYID' to retrieve active Subscription of a company

  Execution Statements:

  -- Get all company subscriptions
  EXEC dbo.SP_COMPANYSUBSCRIPTION @FLAG = 'GETALL';

  -- Get by ID
  EXEC dbo.SP_COMPANYSUBSCRIPTION @FLAG = 'GETBYID', @ID = 1;

  -- Get by Company ID
  EXEC dbo.SP_COMPANYSUBSCRIPTION @FLAG = 'GETBYCOMPANYID', @COMPANYID = 10;

  -- Get by Subscription ID
  EXEC dbo.SP_COMPANYSUBSCRIPTION @FLAG = 'GETBYSUBSCRIPTIONID', @SUBSCRIPTIONID = 2;

  -- Get active subscriptions
  EXEC dbo.SP_COMPANYSUBSCRIPTION @FLAG = 'GETACTIVE';

  -- Get expired subscriptions
  EXEC dbo.SP_COMPANYSUBSCRIPTION @FLAG = 'GETEXPIRED';

  -- Get subscriptions expiring today
  EXEC dbo.SP_COMPANYSUBSCRIPTION @FLAG = 'GETEXPIRINGTODAY';

  -- Get subscriptions expiring within a week
  EXEC dbo.SP_COMPANYSUBSCRIPTION @FLAG = 'GETEXPIRINGWITHINWEEK';
}*/

GO

CREATE OR ALTER  PROCEDURE [dbo].[SP_COMPANYSUBSCRIPTION]
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
            FROM CompanySubscription
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

        

            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscription
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
          
                    
            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscription
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
            

            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscription
            WHERE SubscriptionId = @SUBSCRIPTIONID AND IsDeleted = 0;
            RETURN;
        END



        IF @FLAG = 'GETACTIVE'
        BEGIN
            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscription
            WHERE IsActive = 1 AND IsDeleted = 0;
            RETURN;
        END

IF @FLAG = 'GETACTIVE_BYCOMPANYID'
BEGIN
    SELECT 
        cs.Id,
        cs.CompanyId,
        cs.SubscriptionId,
        cs.StartDate,
        cs.EndDate,
        cs.IsActive,
        cs.Status,
        cs.DesksLimit,
        cs.EmployeesLimit,
        cs.FloorsLimit,
        cs.MeetingRoomsLimit
    FROM dbo.CompanySubscription AS cs
    WHERE 
        cs.CompanyId = @COMPANYID
        AND cs.IsActive = 1
        AND cs.IsDeleted = 0;

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
            FROM CompanySubscription
            WHERE Status = @STATUS AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETEXPIRED'
        BEGIN
            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscription
            WHERE EndDate < GETUTCDATE() 
              AND IsDeleted = 0;
            RETURN;
        END
        IF @FLAG = 'GETEXPIRINGTODAY'
        BEGIN
            SELECT 
                Id, CompanyId, SubscriptionId, StartDate, EndDate,
                IsActive, Status
            FROM CompanySubscription
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
            FROM CompanySubscription
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

-------------------------------------------------------------------------------------------------------------------------------------
/*{
  Title       : [dbo].[SP_ACTIVE_SUBSCRIPTION_BYCOMPANY]
  Description : Get full details of active company subscription, including grace period validation
  CreatedOn and Owner : { 03/01/2026 : Ganga Suresh V }
  
  Execution Statements:

  -- Get Active Subscription By CompanyId
  EXEC dbo.SP_ACTIVE_SUBSCRIPTION_BYCOMPANY @COMPANYID = 1;
}*/

GO

CREATE OR ALTER PROCEDURE [dbo].[SP_ACTIVE_SUBSCRIPTION_BYCOMPANY]
    @COMPANYID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        
        IF @COMPANYID IS NULL
        BEGIN
            RAISERROR('COMPANYID is required.', 16, 1);
            RETURN;
        END

        
        SELECT 
            cs.Id AS SubscriptionId,
            cs.CompanyId,
            cs.SubscriptionId ,
            cs.StartDate,
            cs.EndDate,
            cs.IsActive,
            cs.Status AS CompanySubscription_Status,
            s.Id AS SubscriptionId,
            s.SubscriptionName AS SubscriptionName,
            s.GracePeriodDays
        FROM dbo.CompanySubscription AS cs
        INNER JOIN dbo.Subscriptions AS s
            ON cs.SubscriptionId = s.Id
        WHERE 
            cs.CompanyId = @COMPANYID
            AND cs.IsActive = 1
            AND cs.IsDeleted = 0
            AND (
                GETUTCDATE() BETWEEN cs.StartDate AND cs.EndDate
                OR GETUTCDATE() <= DATEADD(DAY, s.GracePeriodDays, cs.EndDate)
            );

        
        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('No active subscription found for company ''%d''.', 16, 1, @COMPANYID);
        END
    END TRY
    BEGIN CATCH
        DECLARE @ERR_MSG NVARCHAR(MAX), @ERR_SEVERITY INT, @ERR_STATE INT;

        SELECT  
            @ERR_MSG = ERROR_MESSAGE(),
            @ERR_SEVERITY = ERROR_SEVERITY(),
            @ERR_STATE = ERROR_STATE();

        RAISERROR(@ERR_MSG, @ERR_SEVERITY, @ERR_STATE);
    END CATCH
END
GO
