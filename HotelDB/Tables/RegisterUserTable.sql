CREATE TABLE [dbo].[RegisterUserTable]
(
     [id] INT PRIMARY KEY IDENTITY,
	[FullName] VARCHAR(100) NOT NULL,
	[Email] VARCHAR(100) NOT NULL,
	[Password] VARCHAR(100) NOT NULL
)
