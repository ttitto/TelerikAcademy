CREATE TABLE [dbo].[Payments]
(
	[PaymentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PaymentDate] DATE NULL, 
    [Amount] MONEY NULL, 
    [UserId] INT NULL, 
    [CreditId] INT NULL, 
    CONSTRAINT [FK_Payments_Users] FOREIGN KEY (UserId) REFERENCES Users	(UserId), 
    CONSTRAINT [FK_Payments_Credits] FOREIGN KEY (CreditId) REFERENCES Credits(CreditId)
)
