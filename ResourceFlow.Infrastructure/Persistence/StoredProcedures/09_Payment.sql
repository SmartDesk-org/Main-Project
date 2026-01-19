
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
