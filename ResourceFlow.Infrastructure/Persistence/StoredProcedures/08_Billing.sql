
-------------------------------------------------------------------------------------------------------------------------------------

/*{
  Title       : [dbo].[SP_BILLING]
  Description : Handles Billing read operations using FLAG-based logic
  CreatedOn and Owner : { 16/12/2025 : Ganga Suresh V }

  Execution Statements:

  -- Get all billing records
  EXEC dbo.SP_BILLING @FLAG = 'GETALL';

  -- Get billing by ID
  EXEC dbo.SP_BILLING @FLAG = 'GETBYID', @BILLINGID = 1;

  -- Get billing by Company ID
  EXEC dbo.SP_BILLING @FLAG = 'GETBYCOMPANYID', @COMPANYID = 10;

  -- Get billing by payment status
  EXEC dbo.SP_BILLING @FLAG = 'GETBYSTATUS', @PAYMENTSTATUS = 'PAID';
}*/

GO
CREATE OR ALTER   PROCEDURE [dbo].[SP_BILLING] 
    @FLAG                  VARCHAR(40),
    @BILLINGID             INT              = NULL,
    @COMPANYID             INT              = NULL,
    @SUBSCRIPTIONID        INT              = NULL,
    @COMPANYSUBSCRIPTIONID INT              = NULL,
    @INVOICENUMBER         NVARCHAR(100)    = NULL,
    @PAYMENTSTATUS         NVARCHAR(50)     = NULL,
    @PAYMENTMETHOD         NVARCHAR(50)     = NULL,
    @TRANSACTIONID         NVARCHAR(100)    = NULL,
    @BILLINGDATE           DATETIME2        = NULL,
    @SUBSCRIPTIONSTARTDATE DATETIME2        = NULL,
    @SUBSCRIPTIONENDDATE   DATETIME2        = NULL,
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
            SELECT 
                BillingId, CompanyId, SubscriptionId, CompanySubscriptionId,
                InvoiceNumber, TotalAmount, PaymentStatus, PaymentMethod,
                TransactionId, BillingDate, SubscriptionStartDate, SubscriptionEndDate
            FROM Billing
            WHERE IsDeleted = 0;
            RETURN;
        END

        IF @FLAG = 'GETBYID'
        BEGIN
            IF @BILLINGID IS NULL
            BEGIN
                RAISERROR('BILLINGID is required for GETBYID', 16, 1);
                RETURN;
            END
            SELECT 
                BillingId, CompanyId, SubscriptionId, CompanySubscriptionId,
                InvoiceNumber, TotalAmount, PaymentStatus, PaymentMethod,
                TransactionId, BillingDate, SubscriptionStartDate, SubscriptionEndDate
            FROM Billing
            WHERE BillingId = @BILLINGID AND IsDeleted = 0;
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
                BillingId, CompanyId, SubscriptionId, CompanySubscriptionId,
                InvoiceNumber, TotalAmount, PaymentStatus, PaymentMethod,
                TransactionId, BillingDate, SubscriptionStartDate, SubscriptionEndDate
            FROM Billing
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
                BillingId, CompanyId, SubscriptionId, CompanySubscriptionId,
                InvoiceNumber, TotalAmount, PaymentStatus, PaymentMethod,
                TransactionId, BillingDate, SubscriptionStartDate, SubscriptionEndDate
            FROM Billing
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
