CREATE OR ALTER PROCEDURE [dbo].[EMPLOYEE_SP]
    @FLAG              VARCHAR(40),
    @ID                INT              = NULL,
    @USERID            INT              = NULL,
    @COMPANYID         INT              = NULL,
    @DEFAULTFLOORID    INT              = NULL,
    @DEPARTMENT        NVARCHAR(200)     = NULL,
    @STATUS            INT              = NULL,
    @CREATEAT          DATETIME2         = NULL,
    @CREATEDBY         INT               = NULL,
    @MODIFIEDAT        DATETIME2         = NULL,
    @MODIFIEDBY        INT               = NULL,
    @DELETEDAT         DATETIME2         = NULL,
    @DELETEDBY         INT               = NULL,
    @ISDELETED         BIT               = NULL
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
                RAISERROR('ID is required for GETBYID', 16, 1);

            IF NOT EXISTS (SELECT 1 FROM Employees WHERE Id = @ID AND IsDeleted = 0)
                RAISERROR('Employee not found for the given ID', 16, 1);

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
                RAISERROR('USERID is required for GETBYUSERID', 16, 1);

            IF NOT EXISTS (SELECT 1 FROM Employees WHERE UserId = @USERID AND IsDeleted = 0)
                RAISERROR('Employee not found for the given UserId', 16, 1);

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
                RAISERROR('COMPANYID is required for GETBYCOMPANYID', 16, 1);

            -- IMPORTANT: NO ERROR IF ZERO ROWS
            SELECT 
                Id, UserId, CompanyId, DefaultFloorId,
                Department, Status
            FROM Employees
            WHERE CompanyId = @COMPANYID AND IsDeleted = 0;

            RETURN;
        END

        /* ---------------- GET BY STATUS ---------------- */
        IF @FLAG = 'GETBYSTATUS'
        BEGIN
            IF @STATUS IS NULL
                RAISERROR('STATUS is required for GETBYSTATUS', 16, 1);

            SELECT 
                Id, UserId, CompanyId, DefaultFloorId,
                Department, Status
            FROM Employees
            WHERE Status = @STATUS AND IsDeleted = 0;

            RETURN;
        END

        /* ---------------- GET BY DEPARTMENT ---------------- */
        IF @FLAG = 'GETBYDEPARTMENT'
        BEGIN
            IF @DEPARTMENT IS NULL
                RAISERROR('DEPARTMENT is required for GETBYDEPARTMENT', 16, 1);

            SELECT 
                Id, UserId, CompanyId, DefaultFloorId,
                Department, Status
            FROM Employees
            WHERE Department = @DEPARTMENT AND IsDeleted = 0;

            RETURN;
        END

        RAISERROR('INVALID INPUT FLAG', 16, 1);

    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO
