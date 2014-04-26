
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
USE North
GO
CREATE PROCEDURE usp_SuppliersIncomeInTimeRange(
	@supplierName nvarchar(50),
	@startDate datetime,
	@endDate datetime)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT s.CompanyName ,o.OrderDate, SUM( od.UnitPrice*Quantity*(1-Discount) ) AS [Total Price]
FROM [Order Details] od 
JOIN Orders o	ON o.OrderID=od.OrderID
JOIN Products p ON od.ProductID=p.ProductID
JOIN Suppliers s ON p.SupplierID=s.SupplierID
GROUP BY s.CompanyName, o.OrderDate
HAVING s.CompanyName=@supplierName AND o.OrderDate>=@startDate AND o.OrderDate<=@endDate

END
GO

exec usp_SuppliersIncomeInTimeRange 'Ma Maison', '1996-07-11 00:00:00.000', '1996-07-12 00:00:00.000'
GO