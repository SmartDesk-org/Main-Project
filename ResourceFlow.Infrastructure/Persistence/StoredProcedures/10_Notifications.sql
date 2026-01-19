
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
-----------------------------------------------------------------------