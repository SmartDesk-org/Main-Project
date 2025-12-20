CREATE OR ALTER PROCEDURE dbo.sp_GetHistoryByCompany
( 
	@CompanyId INT
)
AS 
BEGIN
	SET NOCOUNT ON;
	SELECT 
		c.Name				AS CompanyName,
		s.SubscriptionName AS SubscriptionName,
		h.StartDate,
		h.EndDate,
		h.AmountPaid,
		h.Status,
		h.ChangeReason
	FROM Histories h
	INNER JOIN CompanyDetails c ON h.CompanyId=c.CompanyId
	INNER JOIN Subscriptions s ON h.SubscriptionId=s.Id
	WHERE c.IsDeleted=0 AND h.CompanyId=@CompanyId
	ORDER BY h.CreatedAt DESC
END;
GO
