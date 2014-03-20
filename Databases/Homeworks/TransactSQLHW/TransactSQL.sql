/*TASK 1: Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and 
Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. Write a stored 
procedure that selects the full names of all persons.
*/

 CREATE DATABASE BankAccounts
 GO

USE BankAccounts
GO

CREATE TABLE  Persons(
Id int IDENTITY PRIMARY KEY,
FirstName varchar(100),
LastName nvarchar(100),
SSN nvarchar(30))
GO

CREATE TABLE Accounts(
Id int IDENTITY PRIMARY KEY,
PersonId int FOREIGN KEY REFERENCES Persons(Id),
Balance money)
GO

CREATE PROC usp_SelectPersonsNames
AS (SELECT FirstName+' ' + LastName AS FullNames
FROM Persons)
GO

INSERT INTO Persons(FirstName,LastName,SSN)  VALUES	('Mango','Mangov','no security number')
INSERT INTO Persons(FirstName,LastName,SSN)  VALUES	('Boris','Tupalov','5409124576')
INSERT INTO Persons(FirstName,LastName,SSN)  VALUES	('Damyan','Hristov','7905124578')
INSERT INTO Persons(FirstName,LastName,SSN)  VALUES	('Hristina','Penkova','6565165164')
INSERT INTO Persons(FirstName,LastName,SSN)  VALUES	('Bogdan','Kaloyanov','8941654951')

INSERT INTO Accounts(PersonId,Balance	) VALUES(1,340.56)
INSERT INTO Accounts(PersonId,Balance	) VALUES(2,8500.56)
INSERT INTO Accounts(PersonId,Balance	) VALUES(3,9320.56)
INSERT INTO Accounts(PersonId,Balance	) VALUES(4,5340.56)
INSERT INTO Accounts(PersonId,Balance	) VALUES(5,389.56)

GO

EXEC usp_SelectPersonsNames
GO

/*TASK 02: Create a stored procedure that accepts a number as a parameter and returns all
 persons who have more money in their accounts than the supplied number.
*/
CREATE PROC usp_SelectPersonsAboveLimit( @limit money)
AS (SELECT p.FirstName+' '+p.LastName AS FullName
FROM Persons p JOIN Accounts a
	ON p.Id=a.Id
GROUP BY a.Balance, p.FirstName, p.LastName
HAVING a.Balance>@limit)
GO

EXEC usp_SelectPersonsAboveLimit 356
GO
EXEC usp_SelectPersonsAboveLimit 3560
GO

/*TASK 03: Create a function that accepts as parameters � sum, yearly interest rate and number of months. 
It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
*/
CREATE FUNCTION dbo.ufn_CalculateSumWithInterest(@sum money, @interest money, @monthsCount int)
RETURNS money
AS
 BEGIN
	DECLARE	@newSum as money
	SET @newSum=@sum+@sum*@monthsCount*@interest/(12*100)
	RETURN @newSum
END
GO

SELECT  dbo.ufn_CalculateSumWithInterest(3500,8.9,12)
GO

/*TASK 04: Create a stored procedure that uses the function from the previous example to give
 an interest to a person's account for one month. It should take the AccountId and the interest
  rate as parameters.
*/
USE BankAccounts
GO
CREATE PROC usp_MonthlyInterest(@AccountId int, @InterestRate money)
AS

DECLARE @Balance money
DECLARE @Interest money
SET @Balance=(SELECT Balance FROM Accounts WHERE Id=@AccountId)
SET @Interest=dbo.ufn_CalculateSumWithInterest(@Balance,@InterestRate,1)
-- PRINT @Interest
RETURN @Interest
GO

EXEC dbo.usp_MonthlyInterest 3,10.5
GO

/*TASK 05: Add two more stored procedures WithdrawMoney( AccountId, money) and 
DepositMoney (AccountId, money) that operate in transactions.
*/

/*TASK 06: Create another table � Logs(LogID, AccountID, OldSum, NewSum). Add a trigger
 to the Accounts table that enters a new entry into the Logs table every time the sum on
  an account changes.
*/

/*TASK 07: Define a function in the database TelerikAcademy that returns all Employee's 
names (first or middle or last name) and all town's names that are comprised of given set
 of letters. Example 'oistmiahf' will return 'Sofia', 'Smith', � but not 'Rob' and 'Guy'.
*/

/*TASK 08: Using database cursor write a T-SQL script that scans all employees and their 
addresses and prints all pairs of employees that live in the same town.
*/

/*TASK 09: * Write a T-SQL script that shows for each town a list of all employees that live in it.
 Sample output:
	Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
	Ottawa -> Jose Saraiva
*/

/*TASK 10: Define a .NET aggregate function StrConcat that takes as input a sequence of 
strings and return a single string that consists of the input strings separated by ','. 
For example the following SQL statement should return a single string:

SELECT StrConcat(FirstName + ' ' + LastName)
FROM Employees

*/