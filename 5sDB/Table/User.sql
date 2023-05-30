CREATE TABLE [dbo].[User]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [FirstName] VARCHAR(255),
    [LastName] VARCHAR(255),
    [Username] VARCHAR(255),
    [Password] VARCHAR(255),
    [Role] VARCHAR(255),
    [Field] VARBINARY(MAX)
);