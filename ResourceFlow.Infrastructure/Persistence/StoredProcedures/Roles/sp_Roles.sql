CREATE OR ALTER PROCEDURE [dbo].[ROLES_SP]
    @FLAG          VARCHAR(40),
    @ROLEID        INT             = NULL,
    @ROLENAME      NVARCHAR(100)   = NULL,
    @CREATEAT      DATETIME2       = NULL,
    @CREATEDBY     INT             = NULL,
    @MODIFIEDAT    DATETIME2       = NULL,
    @MODIFIEDBY    INT             = NULL,
    @DELETEDAT     DATETIME2       = NULL,
    @DELETEDBY     INT             = NULL,
    @ISDELETE      BIT             = NULL
AS
BEGIN

    BEGIN TRY

     
        IF @FLAG = 'GETALL'
        BEGIN
            SELECT Id AS RoleId,RoleName,CreatedBy
            FROM Roles
            WHERE IsDelete = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYID'
        BEGIN
            IF @ROLEID IS NULL
            BEGIN
                RAISERROR('ROLEID is required for GETBYID', 16, 1);
                RETURN;
            END
             IF NOT EXISTS (SELECT 1 FROM Roles  WHERE Id =@ROLEID  AND IsDelete = 0)
            BEGIN
                RAISERROR('Role with this id not found', 16, 1);
                RETURN;
            END

           SELECT Id AS RoleId,RoleName,CreatedBy
            FROM Roles
            WHERE Id = @ROLEID AND IsDelete = 0;

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
            WHERE RoleName = @ROLENAME AND IsDelete = 0;

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
