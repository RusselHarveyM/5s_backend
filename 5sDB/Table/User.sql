CREATE TABLE [dbo].[User]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [FirstName] VARCHAR(255),
    [LastName] VARCHAR(255),
    [Username] VARCHAR(255) UNIQUE,
    [Password] VARCHAR(255),
    [Role] VARCHAR(255),
    [Field] VARBINARY(MAX),
    PRIMARY KEY CLUSTERED ([Id] ASC)
);