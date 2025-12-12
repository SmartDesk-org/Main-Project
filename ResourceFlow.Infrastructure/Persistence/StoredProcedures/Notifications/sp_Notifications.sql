CREATE OR ALTER PROCEDURE [dbo].[NOTIFICATION_SP]
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
    @ISDELETE         BIT             = NULL
AS
BEGIN
    BEGIN TRY

        -- GETALL: fetch all notifications
        IF @FLAG = 'GETALL'
        BEGIN
            SELECT 
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notification
            WHERE IsDelete = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYID'
        BEGIN
            IF @ID IS NULL
            BEGIN
                RAISERROR('ID is required for GETBYID', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM Notification WHERE Id = @ID AND IsDelete = 0)
            BEGIN
                RAISERROR('Notification record not found for the given ID', 16, 1);
                RETURN;
            END

            SELECT 
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notification
            WHERE Id = @ID AND IsDelete = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYCOMPANYID'
        BEGIN
            IF @COMPANYID IS NULL
            BEGIN
                RAISERROR('COMPANYID is required for GETBYCOMPANYID', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM Notification WHERE CompanyId = @COMPANYID AND IsDelete = 0)
            BEGIN
                RAISERROR('No notifications found for the given CompanyId', 16, 1);
                RETURN;
            END

            SELECT 
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notification
            WHERE CompanyId = @COMPANYID AND IsDelete = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYUSERID'
        BEGIN
            IF @USERID IS NULL
            BEGIN
                RAISERROR('USERID is required for GETBYUSERID', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM Notification WHERE UserId = @USERID AND IsDelete = 0)
            BEGIN
                RAISERROR('No notifications found for the given UserId', 16, 1);
                RETURN;
            END

            SELECT 
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notification
            WHERE UserId = @USERID AND IsDelete = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYROLEID'
        BEGIN
            IF @ROLEID IS NULL
            BEGIN
                RAISERROR('ROLEID is required for GETBYROLEID', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM Notification WHERE RoleId = @ROLEID AND IsDelete = 0)
            BEGIN
                RAISERROR('No notifications found for the given RoleId', 16, 1);
                RETURN;
            END

            SELECT 
                Id, CompanyId, UserId, RoleId, Title, Message,
                NotificationType, TargetChannel, Status,
                ReferenceType, ReferenceId, SentAt, IsSent,
                ReadAt, IsRead, RetryCount
            FROM Notification
            WHERE RoleId = @ROLEID AND IsDelete = 0;
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
            FROM Notification
            WHERE IsSent = @ISSENT AND IsDelete = 0;
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
            FROM Notification
            WHERE IsRead = @ISREAD AND IsDelete = 0;
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
