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
AS SELECT FirstName+' ' + LastName AS FullNames
FROM Persons
GO

INSERT INTO Persons(FirstName,LastName,SSN)  VALUES	('Mango','Mangov','no security number')
GO

EXEC usp_SelectPersonsNames
GO