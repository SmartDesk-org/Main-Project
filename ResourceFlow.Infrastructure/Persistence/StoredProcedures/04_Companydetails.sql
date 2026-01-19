
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
                CompanyId, Name, Address, IsActive,CompanySubscriptionId
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

---------------------------------------------------------------------------------------------