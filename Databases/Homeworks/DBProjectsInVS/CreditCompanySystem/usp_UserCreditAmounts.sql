CREATE PROCEDURE [dbo].[usp_UserCreditAmounts](@UserId int)
AS 
SET NOCOUNT ON;

SELECT u.FirstName, u.LastName,c.CreditId, c.RefundableAmount, sum(PaidPerUserCredit.Amount) AS RepaidMoney FROM 
(SELECT p.UserId, p.CreditId,p.Amount
FROM Payments p
JOIN Users u ON p.UserId=p.UserId
GROUP BY p.UserId, p.CreditId, p.Amount) AS PaidPerUserCredit
JOIN Users u ON u.UserId=PaidPerUserCredit.UserId
JOIN Credits c ON c.CreditId=PaidPerUserCredit.CreditId
GROUP BY PaidPerUserCredit.UserId, PaidPerUserCredit.CreditId, u.FirstName, u.LastName, c.CreditId,c.RefundableAmount
HAVING PaidPerUserCredit.UserId=@UserId
