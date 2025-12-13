CREATE OR ALTER PROCEDURE [dbo].[PAYMENT_SP] 
    @FLAG           VARCHAR(40),
    @PAYMENTID      INT              = NULL,
    @COMPANYID      INT              = NULL,
    @SUBSCRIPTIONID INT              = NULL,
    @TRANSACTIONID  NVARCHAR(200)    = NULL,
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
                Id, CompanyId, SubscriptionId, TransactionId, Amount, PaymentDate, PaymentStatus
            FROM Payment
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

            IF NOT EXISTS (SELECT 1 FROM Payment WHERE Id = @PAYMENTID AND IsDeleted = 0)
            BEGIN
                RAISERROR('Payment with this id not found', 16, 1);
                RETURN;
            END

            SELECT 
                Id, CompanyId, SubscriptionId, TransactionId, Amount, PaymentDate, PaymentStatus
            FROM Payment
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

            IF NOT EXISTS (SELECT 1 FROM Payment WHERE CompanyId = @COMPANYID AND IsDeleted = 0)
            BEGIN
                RAISERROR('No payments found for the given CompanyId', 16, 1);
                RETURN;
            END

            SELECT 
                Id, CompanyId, SubscriptionId, TransactionId, Amount, PaymentDate, PaymentStatus
            FROM Payment
            WHERE CompanyId = @COMPANYID AND IsDeleted = 0;
            RETURN;
        END

        
        IF @FLAG = 'GETBYSUBSCRIPTIONID'
        BEGIN
            IF @SUBSCRIPTIONID IS NULL
            BEGIN
                RAISERROR('SUBSCRIPTIONID is required for GETBYSUBSCRIPTIONID', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM Payment WHERE SubscriptionId = @SUBSCRIPTIONID AND IsDeleted = 0)
            BEGIN
                RAISERROR('No payments found for the given SubscriptionId', 16, 1);
                RETURN;
            END

            SELECT 
                Id, CompanyId, SubscriptionId, TransactionId, Amount, PaymentDate, PaymentStatus
            FROM Payment
            WHERE SubscriptionId = @SUBSCRIPTIONID AND IsDeleted = 0;
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
                Id, CompanyId, SubscriptionId, TransactionId, Amount, PaymentDate, PaymentStatus
            FROM Payment
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
