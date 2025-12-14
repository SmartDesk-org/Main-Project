CREATE OR ALTER PROCEDURE [dbo].[USER_SP]
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
    @ISDELETED              BIT              = NULL
AS
BEGIN
    BEGIN TRY

        IF @FLAG = 'GETALL'
        BEGIN
            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked, IsActive
            FROM Users
            WHERE IsDeleted = 0;

            RETURN;
        END
        
        IF @FLAG = 'GETBYID'
        BEGIN
            IF @USERID IS NULL
            BEGIN
                RAISERROR('USERID is required for GETBYID', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM Users WHERE UserId = @USERID AND IsDeleted = 0)
            BEGIN
                RAISERROR('User not found', 16, 1);
                RETURN;
            END

            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked,PassWord,IsActive,RefreshToken,RefreshTokenExpiry,PasswordResetToken,PasswordResetExpiry
            FROM Users
            WHERE UserId = @USERID AND IsDeleted = 0;

            RETURN;
        END
        
        IF @FLAG = 'GETBYEMAIL'
        BEGIN
            IF @EMAIL IS NULL
            BEGIN
                RAISERROR('EMAIL is required for GETBYEMAIL', 16, 1);
                RETURN;
            END

            SELECT UserId, CompanyId, UserName, Email, RoleId, PassWord,
                   RefreshToken, RefreshTokenExpiry, IsBlocked, IsActive
            FROM Users
            WHERE Email = @EMAIL AND IsDeleted = 0;

            RETURN;
        END

        IF @FLAG = 'GETBYPASSWORDRESETTOKEN'
        BEGIN
            IF @PASSWORDRESETTOKEN IS NULL
            BEGIN
                RAISERROR('PASSWORDRESETTOKEN is required', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (
                SELECT 1 FROM Users
                WHERE PasswordResetToken = @PASSWORDRESETTOKEN
                  AND PasswordResetExpiry > GETUTCDATE() 
                  AND IsDeleted = 0
            )
            BEGIN
                RAISERROR('Invalid or expired password reset token', 16, 1);
                RETURN;
            END

            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked, IsActive,PassWord, PasswordResetToken, PasswordResetExpiry
            FROM Users
            WHERE PasswordResetToken = @PASSWORDRESETTOKEN
              AND PasswordResetExpiry > GETUTCDATE() 
              AND IsDeleted = 0;

            RETURN;
            END

        
        IF @FLAG = 'GETBYROLEID'
        BEGIN
            IF @ROLEID IS NULL
            BEGIN
                RAISERROR('ROLEID is required', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM Users WHERE RoleId = @ROLEID AND IsDeleted = 0)
            BEGIN
                RAISERROR('No users found for given RoleId', 16, 1);
                RETURN;
            END

            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked, IsActive
            FROM Users
            WHERE RoleId = @ROLEID AND IsDeleted = 0;

            RETURN;
        END
                
                
                
        IF @FLAG = 'GETBYREFRESHTOKEN'
        BEGIN
            IF @REFRESHTOKEN IS NULL
            BEGIN
                RAISERROR('REFRESHTOKEN is required for GETBYREFRESHTOKEN', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (
                SELECT 1 FROM Users
                WHERE RefreshToken = @REFRESHTOKEN
                  AND RefreshTokenExpiry > GETUTCDATE()
                  AND IsDeleted = 0
            )
            BEGIN
                RAISERROR('Invalid or expired refresh token', 16, 1);
                RETURN;
            END

            SELECT 
                UserId,
                CompanyId,
                UserName,
                Email,
                RoleId,
                PassWord,
                RefreshToken,
                RefreshTokenExpiry,
                IsBlocked,
                IsActive
            FROM Users
            WHERE RefreshToken = @REFRESHTOKEN
              AND RefreshTokenExpiry > GETUTCDATE()
              AND IsDeleted = 0;

            RETURN;
        END


        
        IF @FLAG = 'GETBYCOMPANYID'
        BEGIN
            IF @COMPANYID IS NULL
            BEGIN
                RAISERROR('COMPANYID is required', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM Users WHERE CompanyId = @COMPANYID AND IsDeleted = 0)
            BEGIN
                RAISERROR('No users found for given CompanyId', 16, 1);
                RETURN;
            END

            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked, IsActive
            FROM Users
            WHERE CompanyId = @COMPANYID AND IsDeleted = 0;

            RETURN;
        END

       
        IF @FLAG = 'GETADMINUSERS'
        BEGIN
            SELECT UserId, CompanyId, UserName, Email, RoleId, IsBlocked, IsActive
            FROM Users
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
