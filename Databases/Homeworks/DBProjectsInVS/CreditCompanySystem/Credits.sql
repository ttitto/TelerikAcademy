CREATE TABLE dbo.[Credits]
(
	[CreditId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GrandAmount] MONEY NOT NULL, 
    [RefundableAmount] MONEY NULL, 
    [StartDate] DATE NULL, 
    [ExpirationDate] DATE NULL, 
    [UserId] INT NOT NULL , 
    CONSTRAINT [FK_Credits_Users] FOREIGN KEY ([UserId]) REFERENCES dbo.Users(UserId)

	
)
