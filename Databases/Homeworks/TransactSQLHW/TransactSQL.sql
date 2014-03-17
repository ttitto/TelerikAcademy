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

/*TASK 3: Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
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