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

---------------------------------------------------------------------------------------