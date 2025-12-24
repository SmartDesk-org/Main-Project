/*{
  Title       : [dbo].[SP_USER]
  Description : Handles all user-related read operations using FLAG-based logic
  CreatedOn and Owner  : { 16/12/2025 :Ganga Suresh V}

2.modifiedOn and Owner :{19-12-2025 : Mohammed Rinshad}
Description : created 'GET_COMPANYID_BY_USRERID'
}
  Execution Statements:

  -- Get all users
  EXEC dbo.USER_SP @FLAG = 'GETALL';
  
  --Get company id by user id
  EXEC dbo.USER_SP @FLAG = 'GET_COMPANYID_BY_USRERID';

  -- Get user by ID
  EXEC dbo.USER_SP @FLAG = 'GETBYID', @USERID = 1;

  -- Get user by Email
  EXEC dbo.USER_SP @FLAG = 'GETBYEMAIL', @EMAIL = 'user@example.com';

  -- Get users by Company
  EXEC dbo.USER_SP @FLAG = 'GETBYCOMPANYID', @COMPANYID = 10;

  -- Get admin users
  EXEC dbo.USER_SP @FLAG = 'GETADMINUSERS';



}*/
GO


CREATE PROCEDURE [dbo].[SP_USER]
    @FLAG                  VARCHAR(40),
    @USERID                INT              = NULL,
    @COMPANYID             INT              = NULL,
    @USERNAME              NVARCHAR(50)     = NULL,
    @EMAIL                 NVARCHAR(100)    = NULL,
    @PASSWORD              NVARCHAR(260)    = NULL,
    @ROLEID                INT              = NULL,
    @REFRESHTOKEN          NVARCHAR(MAX)    = NULL,
    @REFRESHTOKENEXPIRY    DATETIME2        = NULL,
    @PASSWORDRESETTOKEN    NVARCHAR(MAX)    = NULL,
    @PASSWORDRESETEXPIRY   DATETIME2        = NULL,
    @ISBLOCKED             BIT              = NULL,
    @ISACTIVE              BIT              = NULL,
    @CREATEAT              DATETIME2        = NULL,
    @CREATEDBY             INT              = NULL,
    @MODIFIEDAT            DATETIME2        = NULL,
    @MODIFIEDBY            INT              = NULL,
    @DELETEDAT             DATETIME2        = NULL,
    @DELETEDBY             INT              = NULL,

    @ISDELETED             BIT              = NULL

AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        IF @FLAG = 'GETALL'
        BEGIN
            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked, IsActive
            FROM dbo.Users
            WHERE IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYID'
        BEGIN
            IF @USERID IS NULL
                RAISERROR('USERID is required for GETBYID', 16, 1);

            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked, PassWord,
                   IsActive, RefreshToken, RefreshTokenExpiry,
                   PasswordResetToken, PasswordResetExpiry
            FROM dbo.Users
            WHERE UserId = @USERID AND IsDeleted = 0;
            RETURN;
        END

		IF (@FLAG = 'GET_COMPANYID_BY_USERID')
		BEGIN
			SELECT 
                  CompanyId
					FROM [dbo].[Users]
					WHERE UserId = @USERID
					  AND IsDeleted = 0;

			RETURN;
		END

        IF @FLAG = 'GETBYEMAIL'
        BEGIN
            IF @EMAIL IS NULL
                RAISERROR('EMAIL is required for GETBYEMAIL', 16, 1);

            SELECT UserId, CompanyId, UserName, Email, RoleId, PassWord,
                   RefreshToken, RefreshTokenExpiry, IsBlocked, IsActive
            FROM dbo.Users
            WHERE Email = @EMAIL AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYPASSWORDRESETTOKEN'
        BEGIN
            IF @PASSWORDRESETTOKEN IS NULL
                RAISERROR('PASSWORDRESETTOKEN is required', 16, 1);

            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked, IsActive,
                   PassWord, PasswordResetToken, PasswordResetExpiry
            FROM dbo.Users
            WHERE PasswordResetToken = @PASSWORDRESETTOKEN
              AND PasswordResetExpiry > GETUTCDATE()
              AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYROLEID'
        BEGIN
            IF @ROLEID IS NULL
                RAISERROR('ROLEID is required', 16, 1);

            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked, IsActive
            FROM dbo.Users
            WHERE RoleId = @ROLEID AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYREFRESHTOKEN'
        BEGIN
            IF @REFRESHTOKEN IS NULL
                RAISERROR('REFRESHTOKEN is required', 16, 1);

            SELECT UserId, CompanyId, UserName, Email, RoleId, PassWord,
                   RefreshToken, RefreshTokenExpiry, IsBlocked, IsActive
            FROM dbo.Users
            WHERE RefreshToken = @REFRESHTOKEN
              AND RefreshTokenExpiry > GETUTCDATE()
              AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYCOMPANYID'
        BEGIN
            IF @COMPANYID IS NULL
                RAISERROR('COMPANYID is required', 16, 1);

            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked, IsActive
            FROM dbo.Users
            WHERE CompanyId = @COMPANYID AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETADMINUSERS'
        BEGIN
            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked, IsActive
            FROM dbo.Users
            WHERE RoleId = 1 AND IsDeleted = 0;
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

----------------------------------------------------------------------------------------------------------------------------------------
/*{
  Title       : [dbo].[SP_ROLES]
  Description : Handles all Roles-related read operations using FLAG-based logic
  CreatedOn and Owner  : { 16/12/1015 :Ganga Suresh V}

  Execution Statements:

  -- Get all Roles
  EXEC dbo.USER_SP @FLAG = 'GETALL';

  -- Get Role by ROLEID
  EXEC dbo.USER_SP @FLAG = 'GETBYID', @ROLEID = 1;

  -- Get Role by ROLENAME
  EXEC dbo.USER_SP @FLAG = 'GETBYNAME', @ROLENAME = 'Admin';

}*/

GO

CREATE  PROCEDURE [dbo].[SP_ROLES]

    @FLAG          VARCHAR(40),
    @ROLEID        INT             = NULL,
    @ROLENAME      NVARCHAR(100)   = NULL,
    @CREATEAT      DATETIME2       = NULL,
    @CREATEDBY     INT             = NULL,
    @MODIFIEDAT    DATETIME2       = NULL,
    @MODIFIEDBY    INT             = NULL,
    @DELETEDAT     DATETIME2       = NULL,
    @DELETEDBY     INT             = NULL,
    @ISDELETED      BIT             = NULL
AS
BEGIN

    BEGIN TRY

     
        IF @FLAG = 'GETALL'
        BEGIN
            SELECT Id AS RoleId,RoleName,CreatedBy
            FROM Roles 
            WHERE IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYID'
        BEGIN
            IF @ROLEID IS NULL
            BEGIN
                RAISERROR('ROLEID is required for GETBYID', 16, 1);
                RETURN;
            END
           

           SELECT Id AS RoleId,RoleName,CreatedBy
            FROM Roles
            WHERE Id = @ROLEID AND IsDeleted = 0;

            RETURN;
        END
       
        IF @FLAG = 'GETBYNAME'
        BEGIN
            IF @ROLENAME IS NULL
            BEGIN
                RAISERROR('ROLENAME is required for GETBYNAME', 16, 1);
                RETURN;
            END

           SELECT Id AS RoleId,RoleName,CreatedBy
            FROM Roles
            WHERE RoleName = @ROLENAME AND IsDeleted = 0;

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
--------------------------------------------------------------------------------------------------------------------------------------
/*{
  Title       : [dbo].[SP_EMPLOYEE]
  Description : Handles employee-related read operations using FLAG-based logic
  CreatedBy   : Ganga Suresh V
  CreatedOn   : 2025-12-16
  Owner       : Employee Module

  Execution Statements:

  -- Get all employees
  EXEC dbo.SP_EMPLOYEE @FLAG = 'GETALL';

  -- Get employee by ID
  EXEC dbo.SP_EMPLOYEE @FLAG = 'GETBYID', @ID = 1;

  -- Get employee by UserId
  EXEC dbo.SP_EMPLOYEE @FLAG = 'GETBYUSERID', @USERID = 101;

  -- Get employees by CompanyId
  EXEC dbo.SP_EMPLOYEE @FLAG = 'GETBYCOMPANYID', @COMPANYID = 10;

  -- Get employees by Status
  EXEC dbo.SP_EMPLOYEE @FLAG = 'GETBYSTATUS', @STATUS = 1;

  -- Get employees by Department
  EXEC dbo.SP_EMPLOYEE @FLAG = 'GETBYDEPARTMENT', @DEPARTMENT = 'HR';
}*/

GO

CREATE  PROCEDURE [dbo].[SP_EMPLOYEE]
    @FLAG              VARCHAR(40),
    @ID                INT              = NULL,
    @USERID            INT              = NULL,
    @COMPANYID         INT              = NULL,
    @DEFAULTFLOORID    INT              = NULL,
    @DEPARTMENT        NVARCHAR(200)    = NULL,
    @STATUS            INT              = NULL,   
    @CREATEAT          DATETIME2        = NULL,
    @CREATEDBY         INT              = NULL,
    @MODIFIEDAT        DATETIME2        = NULL,
    @MODIFIEDBY        INT              = NULL,
    @DELETEDAT         DATETIME2        = NULL,
    @DELETEDBY         INT              = NULL,
    @ISDELETED          BIT              = NULL
AS
BEGIN
    BEGIN TRY


        IF @FLAG = 'GETALL'
        BEGIN
            SELECT 
                Id, UserId, CompanyId, DefaultFloorId, 
                Department, Status
            FROM Employees
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
                Id, UserId, CompanyId, DefaultFloorId, 
                Department, Status
            FROM Employees
            WHERE Id = @ID AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYUSERID'
        BEGIN
            IF @USERID IS NULL
            BEGIN
                RAISERROR('USERID is required for GETBYUSERID', 16, 1);
                RETURN;
            END
            SELECT 
                Id, UserId, CompanyId, DefaultFloorId, 
                Department, Status
            FROM Employees
            WHERE UserId = @USERID AND IsDeleted = 0;
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
                Id, UserId, CompanyId, DefaultFloorId, 
                Department, Status
            FROM Employees
            WHERE CompanyId = @COMPANYID AND IsDeleted = 0;
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
                Id, UserId, CompanyId, DefaultFloorId, 
                Department, Status
            FROM Employees
            WHERE Status = @STATUS AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYDEPARTMENT'
        BEGIN
            IF @DEPARTMENT IS NULL
            BEGIN
                RAISERROR('DEPARTMENT is required for GETBYDEPARTMENT', 16, 1);
                RETURN;
            END
            SELECT 
                Id, UserId, CompanyId, DefaultFloorId, 
                Department, Status
            FROM Employees
            WHERE Department = @DEPARTMENT AND IsDeleted = 0;
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
------------------------------------------------------------------------------------------------------------------------------------
/*{
  Title       : [dbo].[SP_COMPANYDETAILS]
  Description : Handles Company details read operations using FLAG-based logic
  CreatedOn and Owner : { 16/12/2025 : Ganga Suresh V }

  Execution Statements:

  -- Get all companies
  EXEC dbo.SP_COMPANYDETAILS @FLAG = 'GETALL';

  -- Get company by ID
  EXEC dbo.SP_COMPANYDETAILS @FLAG = 'GETBYID', @COMPANYID = 1;

  -- Get active/inactive companies
  EXEC dbo.SP_COMPANYDETAILS @FLAG = 'GETBYACTIVE', @ISACTIVE = 1;

  -- Get company by name
  EXEC dbo.SP_COMPANYDETAILS @FLAG = 'GETBYNAME', @NAME = 'ABC Pvt Ltd';
}*/
GO


CREATE  PROCEDURE [dbo].[SP_COMPANYDETAILS]
    @FLAG              VARCHAR(40),
    @COMPANYID         INT              = NULL,
    @NAME              NVARCHAR(200)    = NULL,
    @ADDRESS           NVARCHAR(MAX)    = NULL,
    @ISACTIVE          BIT              = NULL,
    @CREATEAT          DATETIME2       = NULL,
    @CREATEDBY         INT              = NULL,
    @MODIFIEDAT        DATETIME2       = NULL,
    @MODIFIEDBY        INT              = NULL,
    @DELETEDAT         DATETIME2        = NULL,
    @DELETEDBY         INT              = NULL,
    @ISDELETED          BIT              = NULL
AS
BEGIN
    BEGIN TRY

       
        IF @FLAG = 'GETALL'
        BEGIN
            SELECT 
                CompanyId, Name, Address, IsActive
            FROM CompanyDetails
            WHERE IsDeleted = 0;
            RETURN;
        END

     
        IF @FLAG = 'GETBYID'
        BEGIN
            IF @COMPANYID IS NULL
            BEGIN
                RAISERROR('COMPANYID is required for GETBYID', 16, 1);
                RETURN;
            END
              
            SELECT 
                CompanyId, Name, Address, IsActive
            FROM CompanyDetails
            WHERE CompanyId = @COMPANYID AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETCOMPANY_ACTIVEBY_COMPANYID'
        BEGIN
            IF @COMPANYID IS NULL
            BEGIN
                RAISERROR('COMPANYID is required for GETBYID', 16, 1);
                RETURN;
            END
              
            SELECT 
                CompanyId, Name, Address, IsActive
            FROM CompanyDetails
            WHERE CompanyId = @COMPANYID AND IsDeleted = 0 AND IsActive=1;
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
                CompanyId, Name, Address, IsActive
            FROM CompanyDetails
            WHERE IsActive = @ISACTIVE AND IsDeleted = 0;
            RETURN;
        END

         IF @FLAG = 'GETBYNAME'
        BEGIN
            IF @NAME IS NULL
            BEGIN
                RAISERROR('NAME is required for GETBYNAME', 16, 1);
                RETURN;
            END

            SELECT 
                CompanyId, Name, Address, IsActive
            FROM CompanyDetails
            WHERE Name = @NAME AND IsDeleted = 0;
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

-------------------------------------------------------------------------------------------------------------------------------------
/*{
  Title       : [dbo].[SP_RESOURCE]
  Description : Handles Resource master read operations using FLAG-based logic
  CreatedOn and Owner : { 16/12/2025 : Ganga Suresh V }

  Execution Statements:

  -- Get all resources
  EXEC dbo.SP_RESOURCE @FLAG = 'GETALL';

  -- Get resource by ID
  EXEC dbo.SP_RESOURCE @FLAG = 'GETBYID', @RESOURCEID = 1;

  -- Get active resources
  EXEC dbo.SP_RESOURCE @FLAG = 'GETBYACTIVE', @ISACTIVE = 1;

  -- Get resource by name
  EXEC dbo.SP_RESOURCE @FLAG = 'GETBYNAME', @RESOURCENAME = 'Desk';
}*/

GO

CREATE  PROCEDURE [dbo].[SP_RESOURCE] 
    @FLAG       VARCHAR(40),
    @RESOURCEID INT              = NULL,
    @RESOURCENAME NVARCHAR(200)  = NULL,
    @ISACTIVE   BIT              = NULL,
    @CREATEAT   DATETIME2        = NULL,
    @CREATEDBY  INT              = NULL,
    @MODIFIEDAT DATETIME2        = NULL,
    @MODIFIEDBY INT              = NULL,
    @DELETEDAT  DATETIME2        = NULL,
    @DELETEDBY  INT              = NULL,
    @ISDELETED   BIT              = NULL
AS
BEGIN
    BEGIN TRY

        IF @FLAG = 'GETALL'
        BEGIN
            SELECT 
                Id, ResourceName, IsActive
            FROM Resources
            WHERE IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYID'
        BEGIN
            IF @RESOURCEID IS NULL
            BEGIN
                RAISERROR('RESOURCEID is required for GETBYID', 16, 1);
                RETURN;
            END

           

            SELECT 
                Id, ResourceName, IsActive
            FROM Resources
            WHERE Id = @RESOURCEID AND IsDeleted = 0;
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
                Id, ResourceName, IsActive 
            FROM Resources
            WHERE IsActive = @ISACTIVE AND IsDeleted = 0;
            RETURN;
        END

        
        IF @FLAG = 'GETBYNAME'
        BEGIN
            IF @RESOURCENAME IS NULL
            BEGIN
                RAISERROR('RESOURCENAME is required for GETBYNAME', 16, 1);
                RETURN;
            END

            SELECT 
                Id, ResourceName, IsActive
            FROM Resources
            WHERE ResourceName = @RESOURCENAME AND IsDeleted = 0;
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
GO
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

CREATE  PROCEDURE [dbo].[SP_COMPANYSUBSCRIPTION]
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
        cs.Status
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
  Title       : [dbo].[SP_BILLING]
  Description : Handles Billing read operations using FLAG-based logic
  CreatedOn and Owner : { 16/12/2025 : Ganga Suresh V }

  Execution Statements:

  -- Get all billing records
  EXEC dbo.SP_BILLING @FLAG = 'GETALL';

  -- Get billing by ID
  EXEC dbo.SP_BILLING @FLAG = 'GETBYID', @BILLINGID = 1;

  -- Get billing by Company ID
  EXEC dbo.SP_BILLING @FLAG = 'GETBYCOMPANYID', @COMPANYID = 10;

  -- Get billing by payment status
  EXEC dbo.SP_BILLING @FLAG = 'GETBYSTATUS', @PAYMENTSTATUS = 'PAID';
}*/

GO
CREATE  PROCEDURE [dbo].[SP_BILLING] 
    @FLAG                  VARCHAR(40),
    @BILLINGID             INT              = NULL,
    @COMPANYID             INT              = NULL,
    @SUBSCRIPTIONID        INT              = NULL,
    @COMPANYSUBSCRIPTIONID INT              = NULL,
    @INVOICENUMBER         NVARCHAR(100)    = NULL,
    @PAYMENTSTATUS         NVARCHAR(50)     = NULL,
    @PAYMENTMETHOD         NVARCHAR(50)     = NULL,
    @TRANSACTIONID         NVARCHAR(100)    = NULL,
    @BILLINGDATE           DATETIME2        = NULL,
    @SUBSCRIPTIONSTARTDATE DATETIME2        = NULL,
    @SUBSCRIPTIONENDDATE   DATETIME2        = NULL,
    @CREATEAT              DATETIME2        = NULL,
    @CREATEDBY             INT              = NULL,
    @MODIFIEDAT            DATETIME2        = NULL,
    @MODIFIEDBY            INT              = NULL,
    @DELETEDAT             DATETIME2        = NULL,
    @DELETEDBY             INT              = NULL,
    @ISDELETED              BIT              = NULL
AS
BEGIN
    BEGIN TRY
        IF @FLAG = 'GETALL'
        BEGIN
            SELECT 
                BillingId, CompanyId, SubscriptionId, CompanySubscriptionId,
                InvoiceNumber, TotalAmount, PaymentStatus, PaymentMethod,
                TransactionId, BillingDate, SubscriptionStartDate, SubscriptionEndDate
            FROM Billing
            WHERE IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYID'
        BEGIN
            IF @BILLINGID IS NULL
            BEGIN
                RAISERROR('BILLINGID is required for GETBYID', 16, 1);
                RETURN;
            END
            SELECT 
                BillingId, CompanyId, SubscriptionId, CompanySubscriptionId,
                InvoiceNumber, TotalAmount, PaymentStatus, PaymentMethod,
                TransactionId, BillingDate, SubscriptionStartDate, SubscriptionEndDate
            FROM Billing
            WHERE BillingId = @BILLINGID AND IsDeleted = 0;
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
                BillingId, CompanyId, SubscriptionId, CompanySubscriptionId,
                InvoiceNumber, TotalAmount, PaymentStatus, PaymentMethod,
                TransactionId, BillingDate, SubscriptionStartDate, SubscriptionEndDate
            FROM Billing
            WHERE CompanyId = @COMPANYID AND IsDeleted = 0;
            RETURN;
        END
        IF @FLAG = 'GETBYSTATUS'
        BEGIN
            IF @PAYMENTSTATUS IS NULL
            BEGIN
                RAISERROR('PAYMENTSTATUS is required for GETBYSTATUS', 16, 1);
                RETURN;
            END
            SELECT 
                BillingId, CompanyId, SubscriptionId, CompanySubscriptionId,
                InvoiceNumber, TotalAmount, PaymentStatus, PaymentMethod,
                TransactionId, BillingDate, SubscriptionStartDate, SubscriptionEndDate
            FROM Billing
            WHERE PaymentStatus = @PAYMENTSTATUS AND IsDeleted = 0;
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

-------------------------------------------------------------------------------------------------------------------------------------

/*{
  Title       : [dbo].[SP_PAYMENT]
  Description : Handles Payment read operations using FLAG-based logic
  CreatedOn and Owner : { 16/12/2025 : Ganga Suresh V }

  Execution Statements:

  -- Get all payments
  EXEC dbo.SP_PAYMENT @FLAG = 'GETALL';

  -- Get payment by ID
  EXEC dbo.SP_PAYMENT @FLAG = 'GETBYID', @PAYMENTID = 1;

  -- Get payment by Company ID
  EXEC dbo.SP_PAYMENT @FLAG = 'GETBYCOMPANYID', @COMPANYID = 10;

  -- Get payment by Subscription ID
  EXEC dbo.SP_PAYMENT @FLAG = 'GETBYSUBSCRIPTIONID', @SUBSCRIPTIONID = 2;

  -- Get payment by status
  EXEC dbo.SP_PAYMENT @FLAG = 'GETBYSTATUS', @PAYMENTSTATUS = 'SUCCESS';
}*/

GO

CREATE  PROCEDURE [dbo].[SP_PAYMENT] 
    @FLAG           VARCHAR(40),
    @PAYMENTID      INT              = NULL,
    @COMPANYID      INT              = NULL,
    @PAYMENTINTENTID INT             = NULL,
    @RECEIPTID      NVARCHAR(200)    = NULL,
    @PAYMENTSTATUS  NVARCHAR(50)     = NULL,
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
                Id, CompanyId, PaymentIntentId, ReceiptId, Amount, PaymentDate, PaymentStatus
            FROM Payments
            WHERE IsDeleted = 0;
            RETURN;
        END        
        IF @FLAG = 'GETBYID'
        BEGIN
            IF @PAYMENTID IS NULL
            BEGIN
                RAISERROR('PAYMENTID is required for GETBYID', 16, 1);
                RETURN;
            END
            SELECT 
                Id, CompanyId, PaymentIntentId, ReceiptId, Amount, PaymentDate, PaymentStatus
            FROM Payments
            WHERE Id = @PAYMENTID AND IsDeleted = 0;
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
                Id, CompanyId, PaymentIntentId, ReceiptId, Amount, PaymentDate, PaymentStatus
            FROM Payments
            WHERE CompanyId = @COMPANYID AND IsDeleted = 0;
            RETURN;
        END

   

        IF @FLAG = 'GETBYSTATUS'
        BEGIN
            IF @PAYMENTSTATUS IS NULL
            BEGIN
                RAISERROR('PAYMENTSTATUS is required for GETBYSTATUS', 16, 1);
                RETURN;
            END

            SELECT 
                Id, CompanyId, PaymentIntentId,ReceiptId, Amount, PaymentDate, PaymentStatus
            FROM Payments
            WHERE PaymentStatus = @PAYMENTSTATUS AND IsDeleted = 0;
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
-------------------------------------------------------------------------------------------------------------------------------------
/*{
  Title       : [dbo].[SP_NOTIFICATION]
  Description : Handles Notification read operations using FLAG-based logic
  CreatedOn and Owner : { 16/12/2025 : Ganga Suresh V }

  Execution Statements:

  -- Get all notifications
  EXEC dbo.SP_NOTIFICATION @FLAG = 'GETALL';

  -- Get notification by ID
  EXEC dbo.SP_NOTIFICATION @FLAG = 'GETBYID', @ID = 1;

  -- Get notifications by Company ID
  EXEC dbo.SP_NOTIFICATION @FLAG = 'GETBYCOMPANYID', @COMPANYID = 10;

  -- Get notifications by User ID
  EXEC dbo.SP_NOTIFICATION @FLAG = 'GETBYUSERID', @USERID = 100;

  -- Get notifications by Role ID
  EXEC dbo.SP_NOTIFICATION @FLAG = 'GETBYROLEID', @ROLEID = 2;

  -- Get sent notifications
  EXEC dbo.SP_NOTIFICATION @FLAG = 'GETBYSENTSTATUS', @ISSENT = 1;

  -- Get unread notifications
  EXEC dbo.SP_NOTIFICATION @FLAG = 'GETBYREADSTATUS', @ISREAD = 0;
}*/
GO

CREATE  PROCEDURE [dbo].[SP_NOTIFICATION]
    @FLAG            VARCHAR(40),
    @ID              INT              = NULL,
    @COMPANYID       INT              = NULL,
    @USERID          INT              = NULL,
    @ROLEID          INT              = NULL,
    @NOTIFICATIONTYPE INT             = NULL,
    @TARGETCHANNEL    INT             = NULL,
    @STATUS           INT             = NULL,
    @REFERENCETYPE    INT             = NULL,
    @REFERENCEID      INT             = NULL,
    @ISSENT           BIT             = NULL,
    @ISREAD           BIT             = NULL,
    @CREATEAT         DATETIME2       = NULL,
    @CREATEDBY        INT             = NULL,
    @MODIFIEDAT       DATETIME2       = NULL,
    @MODIFIEDBY       INT             = NULL,
    @DELETEDAT        DATETIME2       = NULL,
    @DELETEDBY        INT             = NULL,
    @ISDELETED         BIT             = NULL
AS
BEGIN
    BEGIN TRY

        
        IF @FLAG = 'GETALL'
        BEGIN
            SELECT 
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notifications
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
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notifications
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
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notifications
            WHERE CompanyId = @COMPANYID AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYUSERID'
        BEGIN
            IF @USERID IS NULL
            BEGIN
                RAISERROR('USERID is required for GETBYUSERID', 16, 1);
                RETURN;
            END
            SELECT 
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notifications
            WHERE UserId = @USERID AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYROLEID'
        BEGIN
            IF @ROLEID IS NULL
            BEGIN
                RAISERROR('ROLEID is required for GETBYROLEID', 16, 1);
                RETURN;
            END
            SELECT 
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notifications
            WHERE RoleId = @ROLEID AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYSENTSTATUS'
        BEGIN
            IF @ISSENT IS NULL
            BEGIN
                RAISERROR('ISSENT is required for GETBYSENTSTATUS', 16, 1);
                RETURN;
            END
            SELECT 
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notifications
            WHERE IsSent = @ISSENT AND IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYREADSTATUS'
        BEGIN
            IF @ISREAD IS NULL
            BEGIN
                RAISERROR('ISREAD is required for GETBYREADSTATUS', 16, 1);
                RETURN;
            END
            SELECT 
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notifications
            WHERE IsRead = @ISREAD AND IsDeleted = 0;
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
------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------
/*{[
  Title       : [dbo].[]
  Description : Handles history for companies 
  CreatedOn and Owner : { 20/12/2025 : Suhail}

  ModifiedOn and Owner:{ 23/12/2025 : Ganga Suresh V}
  Description :Added  error capture details

  Execution Statements:

  -- Get all histories of a company
  EXEC [dbo].[SP_HISTORYBYCOMPANY] @CompanyDi=companyID
  
}*/
CREATE  PROCEDURE [dbo].[SP_HISTORYBYCOMPANY]
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