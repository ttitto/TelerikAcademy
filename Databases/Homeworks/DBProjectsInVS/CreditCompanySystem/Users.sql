CREATE TABLE dbo.Users
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Age] INT NULL, 
    [PIN] NVARCHAR(30) NULL, 
    [Address] NVARCHAR(100) NULL
)
