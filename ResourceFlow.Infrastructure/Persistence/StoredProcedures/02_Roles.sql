

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

CREATE OR ALTER  PROCEDURE [dbo].[SP_ROLES]

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
