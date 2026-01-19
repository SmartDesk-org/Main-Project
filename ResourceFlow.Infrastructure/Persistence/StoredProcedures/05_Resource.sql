
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

CREATE PROCEDURE [dbo].[SP_RESOURCE] 
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
----------------------------------------------------------------------------------------------